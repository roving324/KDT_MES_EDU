namespace DC_POPUP
{
    partial class Report_LotBacodeFERT
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.detail = new Telerik.Reporting.DetailSection();
            this.panel1 = new Telerik.Reporting.Panel();
            this.panel7 = new Telerik.Reporting.Panel();
            this.panel2 = new Telerik.Reporting.Panel();
            this.textBox1 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(8.3999996185302734D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1});
            this.detail.Name = "detail";
            this.detail.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.detail.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5D);
            // 
            // panel1
            // 
            this.panel1.Docking = Telerik.Reporting.DockingStyle.Fill;
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel7});
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(11.800000190734863D), Telerik.Reporting.Drawing.Unit.Cm(8.3999996185302734D));
            this.panel1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5D);
            // 
            // panel7
            // 
            this.panel7.Docking = Telerik.Reporting.DockingStyle.Fill;
            this.panel7.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel2});
            this.panel7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel7.Name = "panel7";
            this.panel7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(11.800000190734863D), Telerik.Reporting.Drawing.Unit.Cm(8.3999996185302734D));
            this.panel7.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5D);
            // 
            // panel2
            // 
            this.panel2.Docking = Telerik.Reporting.DockingStyle.Top;
            this.panel2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1});
            this.panel2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel2.Name = "panel2";
            this.panel2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(11.800000190734863D), Telerik.Reporting.Drawing.Unit.Cm(2D));
            this.panel2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5D);
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.2002003192901611D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.4000000953674316D), Telerik.Reporting.Drawing.Unit.Cm(2D));
            this.textBox1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5D);
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Name = "HY견고딕";
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(24D);
            this.textBox1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = "부품식별표";
            // 
            // Report_LotBacodeFERT
            // 
            this.DataSource = null;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "Report_LotBacodeFERT";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Cm(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Cm(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896D), Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PageSettings.PaperSize = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9D), Telerik.Reporting.Drawing.Unit.Cm(12D));
            reportParameter1.Name = "TraPlanDate";
            reportParameter1.Value = "TraPlanDate.Value";
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(1D);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(11.800000190734863D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.Panel panel1;
        private Telerik.Reporting.Panel panel7;
        private Telerik.Reporting.Panel panel2;
        private Telerik.Reporting.TextBox textBox1;
    }
}