﻿using SIL.Scripture;

namespace DevTools.FCBH
{
	public class TemplateDatum
	{
		public TemplateDatum(BCVRef bcvRef, string characterId)
		{
			BcvRef = bcvRef;
			CharacterId = characterId;
		}

		public BCVRef BcvRef { get; set; }
		public string CharacterId { get; set; }
		public bool IsProcessed { get; set; }

		public string ToTabSeparated()
		{
			return BcvRef + "\t" + CharacterId;
		}
	}
}
