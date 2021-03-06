﻿using System;
using System.Collections.Generic;

namespace Glyssen
{
	public class BlockSplitData
	{
		public static BlockSplitDataOffsetComparer BlockSplitDataOffsetComparer = new BlockSplitDataOffsetComparer();
		public static BlockSplitDataVerseAndOffsetComparer BlockSplitDataVerseAndOffsetComparer = new BlockSplitDataVerseAndOffsetComparer();
		public BlockSplitData(int id)
		{
			Id = id;
		}

		public BlockSplitData(int id, Block blockToSplit, string verseToSplit, int characterOffsetToSplit)
		{
			if (id < 1)
				throw new ArgumentException(@"The value for id must be greater than zero", "id");

			Id = id;
			BlockToSplit = blockToSplit;
			VerseToSplit = verseToSplit;
			CharacterOffsetToSplit = characterOffsetToSplit;
		}

		public int Id { get; private set; }
		public Block BlockToSplit { get; set; }
		public string VerseToSplit { get; set; }
		public int CharacterOffsetToSplit { get; set; }
	}

	public class BlockSplitDataVerseAndOffsetComparer : IComparer<BlockSplitData>
	{
		public int Compare(BlockSplitData x, BlockSplitData y)
		{
			if (x.VerseToSplit == y.VerseToSplit)
			{
				if (x.CharacterOffsetToSplit == y.CharacterOffsetToSplit)
					return 0;
				if (x.CharacterOffsetToSplit == BookScript.kSplitAtEndOfVerse)
					return 1;
				if (y.CharacterOffsetToSplit == BookScript.kSplitAtEndOfVerse)
					return -1;
				return x.CharacterOffsetToSplit < y.CharacterOffsetToSplit ? -1 : 1;
			}

			// PG-671: VerseToSplit can be null
			if (x.VerseToSplit == null)
				return -1;
			if (y.VerseToSplit == null)
				return 1;

			return int.Parse(x.VerseToSplit) < int.Parse(y.VerseToSplit) ? -1 : 1;
		}
	}

	public class BlockSplitDataOffsetComparer : IComparer<BlockSplitData>
	{
		public int Compare(BlockSplitData x, BlockSplitData y)
		{
			if (x.CharacterOffsetToSplit == y.CharacterOffsetToSplit)
				return 0;
			if (x.CharacterOffsetToSplit == BookScript.kSplitAtEndOfVerse)
				return 1;
			if (y.CharacterOffsetToSplit == BookScript.kSplitAtEndOfVerse)
				return -1;
			return x.CharacterOffsetToSplit < y.CharacterOffsetToSplit ? -1 : 1;
		}
	}
}
