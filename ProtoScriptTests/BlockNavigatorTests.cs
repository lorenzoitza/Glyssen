﻿using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ProtoScript;

namespace ProtoScriptTests
{
	[TestFixture]
	class BlockNavigatorTests
	{
		private List<BookScript> m_books;
		private BlockNavigator m_navigator;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			var blockA = new Block();
			var blockB = new Block();
			var blockC = new Block();
			var bookScriptA = new BookScript { Blocks = new List<Block> { blockA, blockB, blockC } };
			var blockD = new Block();
			var blockE = new Block();
			var blockF = new Block();
			var bookScriptB = new BookScript { Blocks = new List<Block> { blockD, blockE, blockF } };
			m_books = new List<BookScript> { bookScriptA, bookScriptB };

			m_navigator = new BlockNavigator(m_books);
		}

		[Test]
		public void GetBookScriptContainingBlock_EmptyList_ReturnsNull()
		{
			m_navigator.GetBookScriptContainingBlock(new Block());
		}

		[Test]
		public void GetBookScriptContainingBlock_BlockNotThere_ReturnsNull()
		{
			m_navigator.GetBookScriptContainingBlock(new Block());
		}

		[Test]
		public void GetBookScriptContainingBlock_BlockIsThere_FirstBook_FirstBlock_ReturnsCorrectBook()
		{
			var firstBook = m_books.First();
			var firstBlock = firstBook.Blocks.First();
			Assert.AreEqual(firstBook, m_navigator.GetBookScriptContainingBlock(firstBlock));
		}

		[Test]
		public void GetBookScriptContainingBlock_BlockIsThere_MiddleBook_MiddleBlock_ReturnsCorrectBook()
		{
			var middleBook = m_books[1];
			var middleBlock = middleBook.Blocks[1];
			Assert.AreEqual(middleBook, m_navigator.GetBookScriptContainingBlock(middleBlock));
		}

		[Test]
		public void GetBookScriptContainingBlock_BlockIsThere_LastBook_LastBlock_ReturnsCorrectBook()
		{
			var lastBook = m_books.Last();
			var lastBlock = lastBook.Blocks.Last();
			Assert.AreEqual(lastBook, m_navigator.GetBookScriptContainingBlock(lastBlock));
		}

		[Test]
		public void IsLastBlockInBook_True()
		{
			var firstBook = m_books.First();
			var lastBlock = firstBook.Blocks.Last();
			Assert.AreEqual(true, m_navigator.IsLastBlockInBook(firstBook, lastBlock));
		}

		[Test]
		public void IsLastBlockInBook_False()
		{
			var firstBook = m_books.First();
			var firstBlock = firstBook.Blocks.First();
			Assert.AreEqual(false, m_navigator.IsLastBlockInBook(firstBook, firstBlock));
		}

		[Test]
		public void IsLastBlock_True()
		{
			var lastBook = m_books.Last();
			var lastBlock = lastBook.Blocks.Last();
			Assert.AreEqual(true, m_navigator.IsLastBlock(lastBlock));
		}

		[Test]
		public void IsLastBlock_False()
		{
			var firstBook = m_books.First();
			var firstBlock = firstBook.Blocks.First();
			Assert.AreEqual(false, m_navigator.IsLastBlock(firstBlock));
		}

		[Test]
		public void IsLastBlock_LastBlockInOtherBook_False()
		{
			var firstBook = m_books.First();
			var lastBlock = firstBook.Blocks.Last();
			Assert.AreEqual(false, m_navigator.IsLastBlock(lastBlock));
		}

		[Test]
		public void IsLastBook_True()
		{
			var lastBook = m_books.Last();
			Assert.AreEqual(true, m_navigator.IsLastBook(lastBook));
		}

		[Test]
		public void IsFirstBlockInBook_True()
		{
			var firstBook = m_books.First();
			var firstBlock = firstBook.Blocks.First();
			Assert.AreEqual(true, m_navigator.IsFirstBlockInBook(firstBook, firstBlock));
		}

		[Test]
		public void IsFirstBlockInBookFalse()
		{
			var firstBook = m_books.First();
			var lastBlock = firstBook.Blocks.Last();
			Assert.AreEqual(false, m_navigator.IsFirstBlockInBook(firstBook, lastBlock));
		}

		[Test]
		public void IsFirstBlock_True()
		{
			var firstBook = m_books.First();
			var firstBlock = firstBook.Blocks.First();
			Assert.AreEqual(true, m_navigator.IsFirstBlock(firstBlock));
		}

		[Test]
		public void IsFirstBlock_False()
		{
			var lastBook = m_books.Last();
			var lastBlock = lastBook.Blocks.Last();
			Assert.AreEqual(false, m_navigator.IsFirstBlock(lastBlock));
		}

		[Test]
		public void IsFirstBlock_FirstBlockInOtherBook_False()
		{
			var lastBook = m_books.Last();
			var firstBlock = lastBook.Blocks.First();
			Assert.AreEqual(false, m_navigator.IsFirstBlock(firstBlock));
		}

		[Test]
		public void IsFirstBook_True()
		{
			var firstBook = m_books.First();
			Assert.AreEqual(true, m_navigator.IsFirstBook(firstBook));
		}

		[Test]
		public void GetNextBlock_SameBook()
		{
			var firstBook = m_books.First();
			var firstBlock = firstBook.Blocks.First();
			var secondBlock = firstBook.Blocks[1];
			m_navigator.CurrentBlock = firstBlock;
			Assert.AreEqual(secondBlock, m_navigator.NextBlock());
		}

		[Test]
		public void GetNextBlock_NextBook()
		{
			var firstBook = m_books.First();
			var lastBlock = firstBook.Blocks.Last();
			var secondBook = m_books[1];
			var firstBlock = secondBook.Blocks.First();
			m_navigator.CurrentBlock = lastBlock;
			Assert.AreEqual(firstBlock, m_navigator.NextBlock());
		}

		[Test]
		public void PeekNextBlock_SameBook()
		{
			var firstBook = m_books.First();
			var firstBlock = firstBook.Blocks.First();
			var secondBlock = firstBook.Blocks[1];
			m_navigator.CurrentBlock = firstBlock;
			BookScript currentBook = m_navigator.CurrentBook;
			Block currentBlock = m_navigator.CurrentBlock;
			Assert.AreEqual(secondBlock, m_navigator.PeekNextBlock());
			Assert.AreEqual(currentBlock, m_navigator.CurrentBlock);
			Assert.AreEqual(currentBook, m_navigator.CurrentBook);
		}

		[Test]
		public void PeekNextBlock_NextBook()
		{
			var firstBook = m_books.First();
			var lastBlock = firstBook.Blocks.Last();
			var secondBook = m_books[1];
			var firstBlock = secondBook.Blocks.First();
			m_navigator.CurrentBlock = lastBlock;
			BookScript currentBook = m_navigator.CurrentBook;
			Block currentBlock = m_navigator.CurrentBlock;
			Assert.AreEqual(firstBlock, m_navigator.PeekNextBlock());
			Assert.AreEqual(currentBlock, m_navigator.CurrentBlock);
			Assert.AreEqual(currentBook, m_navigator.CurrentBook);
		}

		[Test]
		public void GetNextBlock_LastReturnsNull()
		{
			var lastBook = m_books.Last();
			var lastBlock = lastBook.Blocks.Last();
			m_navigator.CurrentBlock = lastBlock;
			Assert.IsNull(m_navigator.NextBlock());
		}

		[Test]
		public void GetPreviousBlock_SameBook()
		{
			var firstBook = m_books.First();
			var firstBlock = firstBook.Blocks.First();
			var secondBlock = firstBook.Blocks[1];
			m_navigator.CurrentBlock = secondBlock;
			Assert.AreEqual(firstBlock, m_navigator.PreviousBlock());
		}

		[Test]
		public void GetPreviousBlock_PreviousBook()
		{
			var secondBook = m_books[1];
			var firstBlock = secondBook.Blocks.First();
			var firstBook = m_books.First();
			var lastBlock = firstBook.Blocks.Last();
			m_navigator.CurrentBlock = firstBlock;
			Assert.AreEqual(lastBlock, m_navigator.PreviousBlock());
		}

		[Test]
		public void PeekPreviousBlock_SameBook()
		{
			var firstBook = m_books.First();
			var firstBlock = firstBook.Blocks.First();
			var secondBlock = firstBook.Blocks[1];
			m_navigator.CurrentBlock = secondBlock;
			BookScript currentBook = m_navigator.CurrentBook;
			Block currentBlock = m_navigator.CurrentBlock;
			Assert.AreEqual(firstBlock, m_navigator.PeekPreviousBlock());
			Assert.AreEqual(currentBlock, m_navigator.CurrentBlock);
			Assert.AreEqual(currentBook, m_navigator.CurrentBook);
		}

		[Test]
		public void PeekPreviousBlock_PreviousBook()
		{
			var secondBook = m_books[1];
			var firstBlock = secondBook.Blocks.First();
			var firstBook = m_books.First();
			var lastBlock = firstBook.Blocks.Last();
			m_navigator.CurrentBlock = firstBlock;
			BookScript currentBook = m_navigator.CurrentBook;
			Block currentBlock = m_navigator.CurrentBlock;
			Assert.AreEqual(lastBlock, m_navigator.PeekPreviousBlock());
			Assert.AreEqual(currentBlock, m_navigator.CurrentBlock);
			Assert.AreEqual(currentBook, m_navigator.CurrentBook);
		}

		[Test]
		public void GetPreviousBlock_FirstReturnsNull()
		{
			var firstBook = m_books.First();
			var firstBlock = firstBook.Blocks.First();
			m_navigator.CurrentBlock = firstBlock;
			Assert.IsNull(m_navigator.PreviousBlock());
		}

		[Test]
		public void CurrentBlock_StartsAtFirstBlock()
		{
			Assert.AreEqual(m_books.First().Blocks.First(), m_navigator.CurrentBlock);
		}

		[Test]
		public void CurrentBlock_StartsAtFirstBook()
		{
			Assert.AreEqual(m_books.First(), m_navigator.CurrentBook);
		}

		[Test]
		public void GetNextBlock_GetPreviousBlock_BackToFirst()
		{
			m_navigator.NextBlock();
			Assert.AreEqual(m_books.First().Blocks.First(), m_navigator.PreviousBlock());
		}

		[Test]
		public void GetPreviousBlock_GetNextBlock_BackToLast()
		{
			m_navigator.CurrentBlock = m_books.Last().Blocks.Last();
			m_navigator.PreviousBlock();
			Assert.AreEqual(m_books.Last().Blocks.Last(), m_navigator.NextBlock());
		}
	}
}
