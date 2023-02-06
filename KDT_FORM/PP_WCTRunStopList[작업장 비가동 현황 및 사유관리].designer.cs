namespace KDT_Form
{
    partial class PP_WCTRunStopList
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
			Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
			Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
			this.lblPlantCode = new DC00_Component.SLabel();
			this.cboPlantCode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.grid1 = new DC00_Component.Grid(this.components);
			this.lblItemCode = new DC00_Component.SLabel();
			this.dtpEnd = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
			this.dtpStart = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
			this.sLabel6 = new DC00_Component.SLabel();
			this.sLabel4 = new DC00_Component.SLabel();
			this.cboWorkcenterCode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
			this.gbxHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
			this.gbxBody.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cboPlantCode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtpStart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cboWorkcenterCode)).BeginInit();
			this.SuspendLayout();
			// 
			// gbxHeader
			// 
			this.gbxHeader.ContentPadding.Bottom = 2;
			this.gbxHeader.ContentPadding.Left = 2;
			this.gbxHeader.ContentPadding.Right = 2;
			this.gbxHeader.ContentPadding.Top = 4;
			this.gbxHeader.Controls.Add(this.dtpEnd);
			this.gbxHeader.Controls.Add(this.dtpStart);
			this.gbxHeader.Controls.Add(this.sLabel6);
			this.gbxHeader.Controls.Add(this.sLabel4);
			this.gbxHeader.Controls.Add(this.lblItemCode);
			this.gbxHeader.Controls.Add(this.cboWorkcenterCode);
			this.gbxHeader.Controls.Add(this.cboPlantCode);
			this.gbxHeader.Controls.Add(this.lblPlantCode);
			this.gbxHeader.Location = new System.Drawing.Point(3, 3);
			this.gbxHeader.Size = new System.Drawing.Size(1292, 108);
			// 
			// gbxBody
			// 
			this.gbxBody.ContentPadding.Bottom = 4;
			this.gbxBody.ContentPadding.Left = 4;
			this.gbxBody.ContentPadding.Right = 4;
			this.gbxBody.ContentPadding.Top = 6;
			this.gbxBody.Controls.Add(this.grid1);
			this.gbxBody.Location = new System.Drawing.Point(3, 111);
			this.gbxBody.Size = new System.Drawing.Size(1292, 664);
			// 
			// lblPlantCode
			// 
			appearance2.FontData.BoldAsString = "False";
			appearance2.FontData.UnderlineAsString = "False";
			appearance2.ForeColor = System.Drawing.Color.Black;
			appearance2.TextHAlignAsString = "Right";
			appearance2.TextVAlignAsString = "Middle";
			this.lblPlantCode.Appearance = appearance2;
			this.lblPlantCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
			this.lblPlantCode.DbField = null;
			this.lblPlantCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblPlantCode.Location = new System.Drawing.Point(45, 22);
			this.lblPlantCode.Name = "lblPlantCode";
			this.lblPlantCode.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
			this.lblPlantCode.Size = new System.Drawing.Size(83, 23);
			this.lblPlantCode.TabIndex = 181;
			this.lblPlantCode.Text = "공장";
			// 
			// cboPlantCode
			// 
			this.cboPlantCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
			this.cboPlantCode.Location = new System.Drawing.Point(134, 21);
			this.cboPlantCode.Name = "cboPlantCode";
			this.cboPlantCode.Size = new System.Drawing.Size(145, 27);
			this.cboPlantCode.TabIndex = 0;
			// 
			// grid1
			// 
			this.grid1.AutoResizeColumn = true;
			this.grid1.AutoUserColumn = true;
			this.grid1.ContextMenuCopyEnabled = true;
			this.grid1.ContextMenuDeleteEnabled = true;
			this.grid1.ContextMenuExcelEnabled = true;
			this.grid1.ContextMenuInsertEnabled = true;
			this.grid1.ContextMenuPasteEnabled = true;
			this.grid1.DeleteButtonEnable = true;
			appearance5.BackColor = System.Drawing.SystemColors.Window;
			appearance5.BorderColor = System.Drawing.SystemColors.InactiveCaption;
			this.grid1.DisplayLayout.Appearance = appearance5;
			this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
			this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
			appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder;
			appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
			appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance6.BorderColor = System.Drawing.SystemColors.Window;
			this.grid1.DisplayLayout.GroupByBox.Appearance = appearance6;
			appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
			this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance7;
			this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			this.grid1.DisplayLayout.GroupByBox.Hidden = true;
			appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight;
			appearance8.BackColor2 = System.Drawing.SystemColors.Control;
			appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
			appearance8.ForeColor = System.Drawing.SystemColors.GrayText;
			this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance8;
			this.grid1.DisplayLayout.MaxColScrollRegions = 1;
			this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
			appearance9.BackColor = System.Drawing.SystemColors.Window;
			appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
			this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance9;
			appearance10.BackColor = System.Drawing.SystemColors.Highlight;
			appearance10.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance10;
			this.grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
			this.grid1.DisplayLayout.Override.AllowMultiCellOperations = ((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)((((((((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Delete) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Undo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Redo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Reserved)));
			this.grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
			this.grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
			appearance11.BackColor = System.Drawing.SystemColors.Window;
			this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance11;
			appearance13.BorderColor = System.Drawing.Color.Silver;
			appearance13.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
			this.grid1.DisplayLayout.Override.CellAppearance = appearance13;
			this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
			this.grid1.DisplayLayout.Override.CellPadding = 0;
			appearance15.BackColor = System.Drawing.SystemColors.Control;
			appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark;
			appearance15.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
			appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
			appearance15.BorderColor = System.Drawing.SystemColors.Window;
			this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance15;
			this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
			this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
			appearance18.BackColor = System.Drawing.SystemColors.Window;
			appearance18.BorderColor = System.Drawing.Color.Silver;
			this.grid1.DisplayLayout.Override.RowAppearance = appearance18;
			this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			appearance19.BackColor = System.Drawing.SystemColors.ControlLight;
			this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance19;
			this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
			this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
			this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid1.EnterNextRowEnable = true;
			this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.grid1.Location = new System.Drawing.Point(6, 6);
			this.grid1.Name = "grid1";
			this.grid1.Size = new System.Drawing.Size(1280, 652);
			this.grid1.TabIndex = 6;
			this.grid1.TabStop = false;
			this.grid1.Text = "grid1";
			this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
			this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
			this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
			this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			// 
			// lblItemCode
			// 
			appearance1.FontData.BoldAsString = "False";
			appearance1.FontData.UnderlineAsString = "False";
			appearance1.ForeColor = System.Drawing.Color.Black;
			appearance1.TextHAlignAsString = "Right";
			appearance1.TextVAlignAsString = "Middle";
			this.lblItemCode.Appearance = appearance1;
			this.lblItemCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
			this.lblItemCode.DbField = null;
			this.lblItemCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblItemCode.Location = new System.Drawing.Point(346, 24);
			this.lblItemCode.Name = "lblItemCode";
			this.lblItemCode.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
			this.lblItemCode.Size = new System.Drawing.Size(83, 23);
			this.lblItemCode.TabIndex = 193;
			this.lblItemCode.Text = "작업장";
			// 
			// dtpEnd
			// 
			this.dtpEnd.DateButtons.Add(dateButton1);
			this.dtpEnd.Location = new System.Drawing.Point(1121, 24);
			this.dtpEnd.Name = "dtpEnd";
			this.dtpEnd.NonAutoSizeHeight = 26;
			this.dtpEnd.Size = new System.Drawing.Size(121, 26);
			this.dtpEnd.TabIndex = 198;
			// 
			// dtpStart
			// 
			this.dtpStart.DateButtons.Add(dateButton2);
			this.dtpStart.Location = new System.Drawing.Point(971, 24);
			this.dtpStart.Name = "dtpStart";
			this.dtpStart.NonAutoSizeHeight = 26;
			this.dtpStart.Size = new System.Drawing.Size(121, 26);
			this.dtpStart.TabIndex = 199;
			// 
			// sLabel6
			// 
			appearance16.FontData.BoldAsString = "False";
			appearance16.FontData.UnderlineAsString = "False";
			appearance16.ForeColor = System.Drawing.Color.Black;
			appearance16.TextHAlignAsString = "Right";
			appearance16.TextVAlignAsString = "Middle";
			this.sLabel6.Appearance = appearance16;
			this.sLabel6.DbField = null;
			this.sLabel6.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.sLabel6.Location = new System.Drawing.Point(1098, 26);
			this.sLabel6.Name = "sLabel6";
			this.sLabel6.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
			this.sLabel6.Size = new System.Drawing.Size(17, 23);
			this.sLabel6.TabIndex = 196;
			this.sLabel6.Text = "~";
			// 
			// sLabel4
			// 
			appearance14.FontData.BoldAsString = "False";
			appearance14.FontData.UnderlineAsString = "False";
			appearance14.ForeColor = System.Drawing.Color.Black;
			appearance14.TextHAlignAsString = "Right";
			appearance14.TextVAlignAsString = "Middle";
			this.sLabel4.Appearance = appearance14;
			this.sLabel4.DbField = null;
			this.sLabel4.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.sLabel4.Location = new System.Drawing.Point(865, 26);
			this.sLabel4.Name = "sLabel4";
			this.sLabel4.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
			this.sLabel4.Size = new System.Drawing.Size(100, 23);
			this.sLabel4.TabIndex = 197;
			this.sLabel4.Text = "가동 일자";
			// 
			// cboWorkcenterCode
			// 
			this.cboWorkcenterCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
			this.cboWorkcenterCode.Location = new System.Drawing.Point(435, 20);
			this.cboWorkcenterCode.Name = "cboWorkcenterCode";
			this.cboWorkcenterCode.Size = new System.Drawing.Size(145, 27);
			this.cboWorkcenterCode.TabIndex = 0;
			// 
			// PP_WCTRunStopList
			// 
			this.ClientSize = new System.Drawing.Size(1298, 778);
			this.Name = "PP_WCTRunStopList";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Text = "작업장 비가동 현황 및 사유관리";
			this.Load += new System.EventHandler(this.PP_WCTRunStopList_Load);
			((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
			this.gbxHeader.ResumeLayout(false);
			this.gbxHeader.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
			this.gbxBody.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cboPlantCode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtpStart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cboWorkcenterCode)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private DC00_Component.SLabel lblPlantCode;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode;
        private DC00_Component.Grid grid1;
        private DC00_Component.SLabel lblItemCode;
		private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo dtpEnd;
		private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo dtpStart;
		private DC00_Component.SLabel sLabel6;
		private DC00_Component.SLabel sLabel4;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor cboWorkcenterCode;
	}
}
