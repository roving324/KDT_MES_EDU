namespace KDT_Form
{
    partial class BM_StopListMaster
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            this.sLabel4 = new DC00_Component.SLabel();
            this.sLabel2 = new DC00_Component.SLabel();
            this.cboPlantCode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.sLabel1 = new DC00_Component.SLabel();
            this.txtStopCode = new DC00_Component.STextBox(this.components);
            this.cboUseFlag = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.txtStopName = new DC00_Component.STextBox(this.components);
            this.sLabel3 = new DC00_Component.SLabel();
            this.grid1 = new DC00_Component.Grid(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStopCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUseFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStopName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.sLabel3);
            this.gbxHeader.Controls.Add(this.sLabel4);
            this.gbxHeader.Controls.Add(this.sLabel1);
            this.gbxHeader.Controls.Add(this.sLabel2);
            this.gbxHeader.Controls.Add(this.cboUseFlag);
            this.gbxHeader.Controls.Add(this.cboPlantCode);
            this.gbxHeader.Controls.Add(this.txtStopName);
            this.gbxHeader.Controls.Add(this.txtStopCode);
            this.gbxHeader.Size = new System.Drawing.Size(1096, 90);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(0, 90);
            this.gbxBody.Size = new System.Drawing.Size(1096, 446);
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
            this.sLabel4.Location = new System.Drawing.Point(276, 28);
            this.sLabel4.Name = "sLabel4";
            this.sLabel4.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel4.Size = new System.Drawing.Size(100, 23);
            this.sLabel4.TabIndex = 3;
            this.sLabel4.Text = "비가동코드";
            // 
            // sLabel2
            // 
            appearance15.FontData.BoldAsString = "False";
            appearance15.FontData.UnderlineAsString = "False";
            appearance15.ForeColor = System.Drawing.Color.Black;
            appearance15.TextHAlignAsString = "Right";
            appearance15.TextVAlignAsString = "Middle";
            this.sLabel2.Appearance = appearance15;
            this.sLabel2.DbField = null;
            this.sLabel2.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel2.Location = new System.Drawing.Point(736, 28);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel2.Size = new System.Drawing.Size(100, 23);
            this.sLabel2.TabIndex = 4;
            this.sLabel2.Text = "사용여부";
            // 
            // cboPlantCode
            // 
            this.cboPlantCode.Location = new System.Drawing.Point(121, 23);
            this.cboPlantCode.Name = "cboPlantCode";
            this.cboPlantCode.Size = new System.Drawing.Size(144, 29);
            this.cboPlantCode.TabIndex = 6;
            // 
            // sLabel1
            // 
            appearance16.FontData.BoldAsString = "False";
            appearance16.FontData.UnderlineAsString = "False";
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.sLabel1.Appearance = appearance16;
            this.sLabel1.DbField = null;
            this.sLabel1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel1.Location = new System.Drawing.Point(15, 28);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(100, 23);
            this.sLabel1.TabIndex = 5;
            this.sLabel1.Text = "공장";
            // 
            // txtStopCode
            // 
            appearance17.FontData.BoldAsString = "False";
            appearance17.FontData.UnderlineAsString = "False";
            appearance17.ForeColor = System.Drawing.Color.Black;
            this.txtStopCode.Appearance = appearance17;
            this.txtStopCode.Location = new System.Drawing.Point(382, 23);
            this.txtStopCode.Name = "txtStopCode";
            this.txtStopCode.RequireFlag = DC00_Component.STextBox.RequireFlagEnum.NO;
            this.txtStopCode.RequirePop = DC00_Component.STextBox.RequireFlagEnum.NO;
            this.txtStopCode.Size = new System.Drawing.Size(100, 29);
            this.txtStopCode.TabIndex = 8;
            // 
            // cboUseFlag
            // 
            this.cboUseFlag.Location = new System.Drawing.Point(851, 23);
            this.cboUseFlag.Name = "cboUseFlag";
            this.cboUseFlag.Size = new System.Drawing.Size(144, 29);
            this.cboUseFlag.TabIndex = 7;
            // 
            // txtStopName
            // 
            appearance18.FontData.BoldAsString = "False";
            appearance18.FontData.UnderlineAsString = "False";
            appearance18.ForeColor = System.Drawing.Color.Black;
            this.txtStopName.Appearance = appearance18;
            this.txtStopName.Location = new System.Drawing.Point(598, 23);
            this.txtStopName.Name = "txtStopName";
            this.txtStopName.RequireFlag = DC00_Component.STextBox.RequireFlagEnum.NO;
            this.txtStopName.RequirePop = DC00_Component.STextBox.RequireFlagEnum.NO;
            this.txtStopName.Size = new System.Drawing.Size(100, 29);
            this.txtStopName.TabIndex = 8;
            // 
            // sLabel3
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.sLabel3.Appearance = appearance1;
            this.sLabel3.DbField = null;
            this.sLabel3.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel3.Location = new System.Drawing.Point(492, 29);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel3.Size = new System.Drawing.Size(100, 23);
            this.sLabel3.TabIndex = 3;
            this.sLabel3.Text = "비가동명";
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
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance2;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance12;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.DisplayLayout.Override.AllowMultiCellOperations = ((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)(((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste)));
            this.grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance9;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            appearance13.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance13;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance11.BackColor = System.Drawing.SystemColors.Control;
            appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance11.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance11;
            appearance7.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance10;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance8;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(6, 6);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1084, 434);
            this.grid1.TabIndex = 1;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // BM_StopListMaster
            // 
            this.ClientSize = new System.Drawing.Size(1096, 536);
            this.Name = "BM_StopListMaster";
            this.Text = "비가동 항목 관리";
            this.Load += new System.EventHandler(this.BM_StopListMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStopCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUseFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStopName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DC00_Component.SLabel sLabel3;
        private DC00_Component.SLabel sLabel4;
        private DC00_Component.SLabel sLabel1;
        private DC00_Component.SLabel sLabel2;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboUseFlag;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode;
        private DC00_Component.STextBox txtStopName;
        private DC00_Component.STextBox txtStopCode;
        private DC00_Component.Grid grid1;
    }
}
