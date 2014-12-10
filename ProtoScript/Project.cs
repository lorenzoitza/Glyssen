﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using L10NSharp;
using Palaso.Reporting;
using Palaso.Xml;
using ProtoScript.Bundle;
using ProtoScript.Properties;
using SIL.ScriptureUtils;
using Canon = ProtoScript.Bundle.Canon;

namespace ProtoScript
{
	public class Project
	{
		public const string kProjectFileExtension = ".pgproj";
		public const string kBookScriptFileExtension = ".xml";
		private readonly DblMetadata m_metadata;
		private QuoteSystem m_defaultQuoteSystem = QuoteSystem.Default;
		private readonly List<BookScript> m_books = new List<BookScript>();

		public Project(DblMetadata metadata)
		{
			m_metadata = metadata;
		}

		public Project(Bundle.Bundle bundle) : this(bundle.Metadata)
		{
			PopulateAndParseBooks(bundle);
		}

		public Project(DblMetadata metadata, IEnumerable<UsxDocument> books, IStylesheet stylesheet) : this(metadata)
		{
			AddAndParseBooks(books, stylesheet);
		}

		public string Id
		{
			get { return m_metadata.id; }
		}

		public string Language
		{
			get { return m_metadata.language.ToString(); }
		}

		public string FontFamily
		{
			get { return m_metadata.FontFamily; }
		}

		public int FontSizeInPoints
		{
			get { return m_metadata.FontSizeInPoints; }
		}

		public QuoteSystem QuoteSystem
		{
			get { return m_metadata.QuoteSystem ?? m_defaultQuoteSystem; }
			set
			{
				bool quoteSystemBeingSetForFirstTime = ConfirmedQuoteSystem == null;
				bool quoteSystemChanged = ConfirmedQuoteSystem != value;
				m_metadata.QuoteSystem = value;
				if (quoteSystemChanged)
				{
					if (quoteSystemBeingSetForFirstTime)
						DoQuoteParse();
					else
						HandleQuoteSystemChanged();
				}
			}
		}

		public QuoteSystem ConfirmedQuoteSystem
		{
			get { return m_metadata.QuoteSystem; }
		}

		public IReadOnlyList<BookScript> Books { get { return m_books; } }

		public static Project Load(string projectFilePath)
		{
			Project existingProject = LoadExistingProject(projectFilePath);

			if (existingProject.m_metadata.PgUsxParserVersion != Settings.Default.PgUsxParserVersion &&
				File.Exists(existingProject.m_metadata.OriginalPathOfDblFile))
			{
				var bundle = new Bundle.Bundle(existingProject.m_metadata.OriginalPathOfDblFile);
				// See if we already have a project for this bundle and open it instead.
				var upgradedProject = new Project(bundle.Metadata);
				upgradedProject.QuoteSystem = existingProject.m_metadata.QuoteSystem;
				upgradedProject.m_metadata.Books = existingProject.m_metadata.Books;
				upgradedProject.PopulateAndParseBooks(bundle);
				upgradedProject.ApplyUserDecisions(existingProject);
				return upgradedProject;
			}
			
			existingProject.InitializeLoadedProject();
			return existingProject;
		}

		private static Project LoadExistingProject(string projectFilePath)
		{
			Exception exception;
			var metadata = DblMetadata.Load(projectFilePath, out exception);
			if (exception != null)
			{
				ErrorReport.ReportNonFatalExceptionWithMessage(exception,
					LocalizationManager.GetString("File.ProjectMetadataInvalid", "Project could not be loaded: {0}"), projectFilePath);
				return null;
			}
			Project project = new Project(metadata);
			var projectDir = Path.GetDirectoryName(projectFilePath);
			Debug.Assert(projectDir != null);
			string[] files = Directory.GetFiles(projectDir, "???" + kBookScriptFileExtension);
			for (int i = 1; i <= BCVRef.LastBook; i++)
			{
				string bookCode = BCVRef.NumberToBookCode(i);
				string possibleFileName = Path.Combine(projectDir, bookCode + kBookScriptFileExtension);
				if (files.Contains(possibleFileName))
					project.m_books.Add(XmlSerializationHelper.DeserializeFromFile<BookScript>(possibleFileName));
			}
			return project;
		}

		private void InitializeLoadedProject()
		{
			var cvData = CharacterVerseData.Singleton;
			if (ConfirmedQuoteSystem == null)
			{
				GuessAtQuoteSystem();
				DoQuoteParse();
				m_metadata.ControlFileVersion = cvData.ControlFileVersion;
			}
			else if (m_metadata.ControlFileVersion != cvData.ControlFileVersion)
			{
				new CharacterAssigner(cvData).AssignAll(m_books);
				m_metadata.ControlFileVersion = cvData.ControlFileVersion;
			}
		}

		private void ApplyUserDecisions(Project sourceProject)
		{
			for (int iBook = 0; iBook < m_books.Count; iBook++)
			{
				var targetBookScript = m_books[iBook];
				var sourceBookScript = sourceProject.m_books[iBook];
				Debug.Assert(targetBookScript.BookId == sourceBookScript.BookId);
				targetBookScript.ApplyUserDecisions(sourceBookScript);
			}
		}

		private void PopulateAndParseBooks(Bundle.Bundle bundle)
		{
			Canon canon;
			if (bundle.TryGetCanon(1, out canon))
			{
				foreach (var book in m_metadata.Books.Where(b => b.IncludeInScript))
				{
					UsxDocument usxBook;
					if (canon.TryGetBook(book.Code, out usxBook))
					{
						AddAndParseBooks(new[] { usxBook }, bundle.Stylesheet);
					}
				}
			}
		}

		private void AddAndParseBooks(IEnumerable<UsxDocument> books, IStylesheet stylesheet)
		{
			foreach (var book in books)
			{
				var bookId = book.BookId;
				m_books.Add(new BookScript(bookId, new UsxParser(bookId, stylesheet, book.GetChaptersAndParas()).Parse()));
			}

			if (ConfirmedQuoteSystem == null)
				GuessAtQuoteSystem();

			DoQuoteParse();
		}

		private void GuessAtQuoteSystem()
		{
			bool certain;
			m_defaultQuoteSystem = QuoteSystemGuesser.Guess(CharacterVerseData.Singleton, m_books, out certain);
			if (certain)
				m_metadata.QuoteSystem = m_defaultQuoteSystem;
		}

		private void DoQuoteParse()
		{
			var cvInfo = CharacterVerseData.Singleton;
			foreach (var bookScript in m_books)
				bookScript.Blocks = new QuoteParser(cvInfo, bookScript.BookId, bookScript.GetScriptBlocks(), ConfirmedQuoteSystem).Parse().ToList();
		}

		public static string GetProjectFilePath(string basePath, string langId, string bundleId)
		{
			return Path.Combine(basePath, langId, bundleId, langId + kProjectFileExtension);
		}

		public void Save(string path)
		{
			var projectPath = GetProjectFilePath(path, m_metadata.language.ToString(), m_metadata.id);
			Directory.CreateDirectory(Path.GetDirectoryName(projectPath));
			Exception error;
			XmlSerializationHelper.SerializeToFile(projectPath, m_metadata, out error);
			if (error != null)
			{
				MessageBox.Show(error.Message);
				return;
			}
			Settings.Default.CurrentProject = projectPath;
			var projectFolder = Path.GetDirectoryName(projectPath);
			foreach (var book in m_books)
			{
				var filePath = Path.ChangeExtension(Path.Combine(projectFolder, book.BookId), "xml");
				XmlSerializationHelper.SerializeToFile(filePath, book, out error);
				if (error != null)
					MessageBox.Show(error.Message);
			}
		}

		public void ExportTabDelimited(string fileName)
		{
			int blockNumber = 1;
			using (StreamWriter stream = new StreamWriter(fileName, false, Encoding.UTF8))
			{
				foreach (var book in m_books)
				{
					foreach (var block in book.GetScriptBlocks(true))
					{
						stream.WriteLine((blockNumber++) + "\t" + block.GetAsTabDelimited(book.BookId));
					}
				}
			}
		}

		private void HandleQuoteSystemChanged()
		{
			if (File.Exists(m_metadata.OriginalPathOfDblFile) && QuoteSystem != null)
			{
				var bundle = new Bundle.Bundle(m_metadata.OriginalPathOfDblFile);
				PopulateAndParseBooks(bundle);
			}
			else
			{
				//TODO
				throw new ApplicationException();
			}
		}
	}
}
