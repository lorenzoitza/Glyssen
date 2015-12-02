﻿namespace Glyssen.Dialogs
{
	partial class NarrationOptionsDlg
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NarrationOptionsDlg));
			this.m_lblExplanatory = new System.Windows.Forms.Label();
			this.m_lblDesiredNarratorNum = new System.Windows.Forms.Label();
			this.m_lblNarratorRolesFilledBy = new System.Windows.Forms.Label();
			this.m_rdoMaleOnly = new System.Windows.Forms.RadioButton();
			this.m_rdoFemaleOnly = new System.Windows.Forms.RadioButton();
			this.m_rdoMaleOrFemale = new System.Windows.Forms.RadioButton();
			this.m_selectionsTableLayout = new System.Windows.Forms.TableLayoutPanel();
			this.m_numNarratorNum = new System.Windows.Forms.NumericUpDown();
			this.m_buttonsTableLayout = new System.Windows.Forms.TableLayoutPanel();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_btnOk = new System.Windows.Forms.Button();
			this.m_selectionsTableLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_numNarratorNum)).BeginInit();
			this.m_buttonsTableLayout.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_lblExplanatory
			// 
			this.m_lblExplanatory.AutoSize = true;
			this.m_selectionsTableLayout.SetColumnSpan(this.m_lblExplanatory, 2);
			this.m_lblExplanatory.ForeColor = System.Drawing.Color.White;
			this.m_lblExplanatory.Location = new System.Drawing.Point(3, 0);
			this.m_lblExplanatory.MaximumSize = new System.Drawing.Size(1050, 0);
			this.m_lblExplanatory.Name = "m_lblExplanatory";
			this.m_lblExplanatory.Padding = new System.Windows.Forms.Padding(0, 20, 20, 40);
			this.m_lblExplanatory.Size = new System.Drawing.Size(1050, 348);
			this.m_lblExplanatory.TabIndex = 0;
			this.m_lblExplanatory.Text = resources.GetString("m_lblExplanatory.Text");
			// 
			// m_lblDesiredNarratorNum
			// 
			this.m_lblDesiredNarratorNum.AutoSize = true;
			this.m_lblDesiredNarratorNum.ForeColor = System.Drawing.Color.White;
			this.m_lblDesiredNarratorNum.Location = new System.Drawing.Point(10, 348);
			this.m_lblDesiredNarratorNum.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
			this.m_lblDesiredNarratorNum.Name = "m_lblDesiredNarratorNum";
			this.m_lblDesiredNarratorNum.Padding = new System.Windows.Forms.Padding(0, 0, 20, 40);
			this.m_lblDesiredNarratorNum.Size = new System.Drawing.Size(395, 72);
			this.m_lblDesiredNarratorNum.TabIndex = 2;
			this.m_lblDesiredNarratorNum.Text = "Desired number of narrators:";
			// 
			// m_lblNarratorRolesFilledBy
			// 
			this.m_lblNarratorRolesFilledBy.AutoSize = true;
			this.m_lblNarratorRolesFilledBy.ForeColor = System.Drawing.Color.White;
			this.m_lblNarratorRolesFilledBy.Location = new System.Drawing.Point(3, 420);
			this.m_lblNarratorRolesFilledBy.Name = "m_lblNarratorRolesFilledBy";
			this.m_lblNarratorRolesFilledBy.Padding = new System.Windows.Forms.Padding(0, 0, 20, 20);
			this.m_lblNarratorRolesFilledBy.Size = new System.Drawing.Size(412, 52);
			this.m_lblNarratorRolesFilledBy.TabIndex = 3;
			this.m_lblNarratorRolesFilledBy.Text = "Narrator roles can be filled by:";
			// 
			// m_rdoMaleOnly
			// 
			this.m_rdoMaleOnly.AutoSize = true;
			this.m_selectionsTableLayout.SetColumnSpan(this.m_rdoMaleOnly, 2);
			this.m_rdoMaleOnly.ForeColor = System.Drawing.Color.White;
			this.m_rdoMaleOnly.Location = new System.Drawing.Point(3, 517);
			this.m_rdoMaleOnly.Name = "m_rdoMaleOnly";
			this.m_rdoMaleOnly.Size = new System.Drawing.Size(346, 36);
			this.m_rdoMaleOnly.TabIndex = 2;
			this.m_rdoMaleOnly.Text = "Male Voice Actors Only";
			this.m_rdoMaleOnly.UseVisualStyleBackColor = true;
			// 
			// m_rdoFemaleOnly
			// 
			this.m_rdoFemaleOnly.AutoSize = true;
			this.m_selectionsTableLayout.SetColumnSpan(this.m_rdoFemaleOnly, 2);
			this.m_rdoFemaleOnly.ForeColor = System.Drawing.Color.White;
			this.m_rdoFemaleOnly.Location = new System.Drawing.Point(3, 559);
			this.m_rdoFemaleOnly.Name = "m_rdoFemaleOnly";
			this.m_rdoFemaleOnly.Size = new System.Drawing.Size(379, 36);
			this.m_rdoFemaleOnly.TabIndex = 3;
			this.m_rdoFemaleOnly.Text = "Female Voice Actors Only";
			this.m_rdoFemaleOnly.UseVisualStyleBackColor = true;
			// 
			// m_rdoMaleOrFemale
			// 
			this.m_rdoMaleOrFemale.AutoSize = true;
			this.m_rdoMaleOrFemale.Checked = true;
			this.m_selectionsTableLayout.SetColumnSpan(this.m_rdoMaleOrFemale, 2);
			this.m_rdoMaleOrFemale.ForeColor = System.Drawing.Color.White;
			this.m_rdoMaleOrFemale.Location = new System.Drawing.Point(3, 475);
			this.m_rdoMaleOrFemale.Name = "m_rdoMaleOrFemale";
			this.m_rdoMaleOrFemale.Size = new System.Drawing.Size(496, 36);
			this.m_rdoMaleOrFemale.TabIndex = 1;
			this.m_rdoMaleOrFemale.TabStop = true;
			this.m_rdoMaleOrFemale.Text = "Either Male or Female Voice Actors";
			this.m_rdoMaleOrFemale.UseVisualStyleBackColor = true;
			// 
			// m_selectionsTableLayout
			// 
			this.m_selectionsTableLayout.ColumnCount = 2;
			this.m_selectionsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_selectionsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_selectionsTableLayout.Controls.Add(this.m_rdoFemaleOnly, 0, 5);
			this.m_selectionsTableLayout.Controls.Add(this.m_rdoMaleOrFemale, 0, 3);
			this.m_selectionsTableLayout.Controls.Add(this.m_rdoMaleOnly, 0, 4);
			this.m_selectionsTableLayout.Controls.Add(this.m_lblDesiredNarratorNum, 0, 1);
			this.m_selectionsTableLayout.Controls.Add(this.m_lblNarratorRolesFilledBy, 0, 2);
			this.m_selectionsTableLayout.Controls.Add(this.m_lblExplanatory, 0, 0);
			this.m_selectionsTableLayout.Controls.Add(this.m_numNarratorNum, 1, 1);
			this.m_selectionsTableLayout.Location = new System.Drawing.Point(21, 23);
			this.m_selectionsTableLayout.Name = "m_selectionsTableLayout";
			this.m_selectionsTableLayout.RowCount = 6;
			this.m_selectionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_selectionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_selectionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_selectionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_selectionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_selectionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_selectionsTableLayout.Size = new System.Drawing.Size(1066, 645);
			this.m_selectionsTableLayout.TabIndex = 7;
			// 
			// m_numNarratorNum
			// 
			this.m_numNarratorNum.Location = new System.Drawing.Point(421, 351);
			this.m_numNarratorNum.Maximum = new decimal(new int[] {
            66,
            0,
            0,
            0});
			this.m_numNarratorNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.m_numNarratorNum.Name = "m_numNarratorNum";
			this.m_numNarratorNum.Size = new System.Drawing.Size(89, 38);
			this.m_numNarratorNum.TabIndex = 4;
			this.m_numNarratorNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// m_buttonsTableLayout
			// 
			this.m_buttonsTableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_buttonsTableLayout.ColumnCount = 2;
			this.m_buttonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.m_buttonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.m_buttonsTableLayout.Controls.Add(this.m_btnCancel, 1, 0);
			this.m_buttonsTableLayout.Controls.Add(this.m_btnOk, 0, 0);
			this.m_buttonsTableLayout.Location = new System.Drawing.Point(654, 750);
			this.m_buttonsTableLayout.Name = "m_buttonsTableLayout";
			this.m_buttonsTableLayout.RowCount = 1;
			this.m_buttonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.m_buttonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.m_buttonsTableLayout.Size = new System.Drawing.Size(420, 105);
			this.m_buttonsTableLayout.TabIndex = 8;
			// 
			// m_btnCancel
			// 
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Location = new System.Drawing.Point(213, 3);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(186, 77);
			this.m_btnCancel.TabIndex = 5;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			// 
			// m_btnOk
			// 
			this.m_btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_btnOk.Location = new System.Drawing.Point(3, 3);
			this.m_btnOk.Name = "m_btnOk";
			this.m_btnOk.Size = new System.Drawing.Size(168, 77);
			this.m_btnOk.TabIndex = 4;
			this.m_btnOk.Text = "OK";
			this.m_btnOk.UseVisualStyleBackColor = true;
			this.m_btnOk.Click += new System.EventHandler(this.BtnOk_Clicked);
			// 
			// NarrationOptionsDlg
			// 
			this.AcceptButton = this.m_btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(73)))), ((int)(((byte)(108)))));
			this.CancelButton = this.m_btnCancel;
			this.ClientSize = new System.Drawing.Size(1099, 903);
			this.Controls.Add(this.m_buttonsTableLayout);
			this.Controls.Add(this.m_selectionsTableLayout);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "NarrationOptionsDlg";
			this.Text = "Narration Preferences";
			this.m_selectionsTableLayout.ResumeLayout(false);
			this.m_selectionsTableLayout.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_numNarratorNum)).EndInit();
			this.m_buttonsTableLayout.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label m_lblExplanatory;
		private System.Windows.Forms.TableLayoutPanel m_selectionsTableLayout;
		private System.Windows.Forms.RadioButton m_rdoFemaleOnly;
		private System.Windows.Forms.RadioButton m_rdoMaleOrFemale;
		private System.Windows.Forms.RadioButton m_rdoMaleOnly;
		private System.Windows.Forms.Label m_lblDesiredNarratorNum;
		private System.Windows.Forms.Label m_lblNarratorRolesFilledBy;
		private System.Windows.Forms.TableLayoutPanel m_buttonsTableLayout;
		private System.Windows.Forms.Button m_btnCancel;
		private System.Windows.Forms.Button m_btnOk;
		private System.Windows.Forms.NumericUpDown m_numNarratorNum;
	}
}