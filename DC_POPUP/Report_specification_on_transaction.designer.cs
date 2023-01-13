namespace DC_POPUP
{
    partial class Report_specification_on_transaction
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Barcodes.Code128Encoder code128Encoder1 = new Telerik.Reporting.Barcodes.Code128Encoder();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report_specification_on_transaction));
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.pageBodySection1 = new Telerik.Reporting.DetailSection();
            this.textBox23 = new Telerik.Reporting.TextBox();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.barcode1 = new Telerik.Reporting.Barcode();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageBodySection1
            // 
            this.pageBodySection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.3D);
            this.pageBodySection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox23});
            this.pageBodySection1.Name = "pageBodySection1";
            this.pageBodySection1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pageBodySection1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(1D);
            // 
            // textBox23
            // 
            this.textBox23.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(16.3D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.textBox23.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox23.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBox23.Style.Font.Name = "굴림체";
            this.textBox23.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10D);
            this.textBox23.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox23.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox23.Value = "";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(3.1D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox17,
            this.barcode1,
            this.textBox5,
            this.pictureBox1});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // textBox17
            // 
            this.textBox17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(16.3D), Telerik.Reporting.Drawing.Unit.Cm(2.5D));
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.textBox17.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.textBox17.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox17.Style.Font.Bold = true;
            this.textBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox17.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox17.Value = "비    고";
            // 
            // barcode1
            // 
            this.barcode1.BarAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.barcode1.Encoder = code128Encoder1;
            this.barcode1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.5D), Telerik.Reporting.Drawing.Unit.Cm(0.3D));
            this.barcode1.Name = "barcode1";
            this.barcode1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5D), Telerik.Reporting.Drawing.Unit.Cm(0.9D));
            this.barcode1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.barcode1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.408D), Telerik.Reporting.Drawing.Unit.Cm(0.8D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.792D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.Value = "■반출번호  :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.2D), Telerik.Reporting.Drawing.Unit.Cm(0.2D));
            this.pictureBox1.MimeType = "image/jpeg";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.7D), Telerik.Reporting.Drawing.Unit.Cm(1.9D));
            this.pictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pictureBox1.Value = ((object)(resources.GetObject("pictureBox1.Value")));
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(4.9D);
            this.pageFooterSection1.Name = "pageFooterSection1";
            this.pageFooterSection1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pageFooterSection1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(1D);
            // 
            // Report_specification_on_transaction
            // 
            this.DataSource = null;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageBodySection1,
            this.pageFooterSection1,
            this.pageHeaderSection1});
            this.Name = "Report_BanChul";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(15D), Telerik.Reporting.Drawing.Unit.Mm(15D), Telerik.Reporting.Drawing.Unit.Mm(27D), Telerik.Reporting.Drawing.Unit.Mm(30D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.Name = "TraPlanDate";
            reportParameter1.Value = "TraPlanDate.Value";
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(1.5D);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(18D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection pageBodySection1;
        private Telerik.Reporting.TextBox textBox23;
        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.Barcode barcode1;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.PictureBox pictureBox1;
    }
}