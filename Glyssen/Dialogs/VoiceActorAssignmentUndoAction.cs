﻿using System;
using System.Linq;
using Glyssen.Character;
using L10NSharp;

namespace Glyssen.Dialogs
{
	public class VoiceActorAssignmentUndoAction : CharacterGroupsUndoAction
	{
		private readonly Project m_project;
		private readonly int m_newActorId;
		private readonly int m_oldActorId;
		private readonly string m_groupName;

		public VoiceActorAssignmentUndoAction(Project project, CharacterGroup group, int newActorId) : base(group)
		{
			m_project = project;
			m_oldActorId = group.VoiceActorId;
			m_newActorId = newActorId;
			m_groupName = group.Name;
			group.AssignVoiceActor(newActorId);
		}

		private string ActorName
		{
			get { return m_project.VoiceActorList.GetVoiceActorById(m_newActorId).Name; }
		}

		public override string Description
		{
			get { return string.Format(LocalizationManager.GetString("DialogBoxes.VoiceActorAssignmentDlg.Undo.VoiceActorAssignment", "Assign voice actor {0}"), ActorName); }
		}

		protected override bool PerformUndo()
		{
			CharacterGroup group = null;
			try
			{
				group = m_project.CharacterGroupList.CharacterGroups.SingleOrDefault(g => g.VoiceActorId == m_newActorId);
			}
			catch (InvalidOperationException)
			{
			}
			if (group == null)
				group = m_project.CharacterGroupList.GetGroupByName(m_groupName);
			if (group == null)
				return false;
			group.AssignVoiceActor(m_oldActorId);
			AddGroupAffected(group);
			return true;
		}

		protected override bool PerformRedo()
		{
			CharacterGroup group = null;
			try
			{
				group = m_project.CharacterGroupList.CharacterGroups.SingleOrDefault(g => g.VoiceActorId == m_oldActorId);
			}
			catch (InvalidOperationException)
			{
			}
			if (group == null)
				group = m_project.CharacterGroupList.GetGroupByName(m_groupName);
			if (group == null)
				return false;
			group.AssignVoiceActor(m_newActorId);
			AddGroupAffected(group);
			return true;
		}
	}
}
