using System; 
using System.Data; 
using System.Windows.Forms;
using Infragistics.Win;
using DC00_assm;
using DC00_PuMan;

namespace DC_POPUP
{
    public partial class POP_ITEM_MASTER : DC00_WinForm.BasePopupForm
    {
        string[] argument;

        #region [ 선언자 ]
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();

        //비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();

        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();
        #endregion

        public POP_ITEM_MASTER(string[] param)
        {
            InitializeComponent();

            argument = new string[param.Length];

            Common _Common = new Common();

            DataTable rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  //사업장
            Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp);
            UltraGridUtil.SetComboUltraGrid(this.Grid1, "PlantCode", rtnDtTemp);

            rtnDtTemp = _Common.Standard_CODE("ITEMTYPE"); //거래처
            Common.FillComboboxMaster(this.cboItemType_H, rtnDtTemp);
            UltraGridUtil.SetComboUltraGrid(this.Grid1, "ItemType", rtnDtTemp);

            for (int i = 0; i < param.Length; i++)
            {
                argument[i] = param[i];

                #region [품목 및 명 Parameter Show]
                switch (i)
                {
                    case 0:
                        cboPlantCode_H.Value = argument[0].ToUpper() == "" ? "" : argument[0].ToUpper(); //plant
                        break;

                    case 1:
                        cboItemType_H.Value = argument[1].ToUpper() == "" ? "" : argument[1].ToUpper(); //제품타입
                        break;

                    case 2:
                        txtItemCode.Text = argument[2] ; //품목
                        break;

                    case 3:
                        txtItemName.Text = argument[3]; //품목명
                        break;
                }
                #endregion
            }
        }

        private void POP_ITEM_MASTER_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(this.Grid1);

            _GridUtil.InitColumnUltraGrid(Grid1, "PlantCode", "사업장",   GridColDataType_emu.VarChar, 120, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(Grid1, "ItemType",  "품목타입", GridColDataType_emu.VarChar, 110, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(Grid1, "ItemCode",  "품목",     GridColDataType_emu.VarChar, 140, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(Grid1, "itemname",  "품목명",   GridColDataType_emu.VarChar, 170, HAlign.Left, true, false);            

            _GridUtil.SetInitUltraGridBind(Grid1);


            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            Common _Common = new Common();
            rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  //사업장
            UltraGridUtil.SetComboUltraGrid(this.Grid1, "PlantCode", rtnDtTemp);



            search();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            string RS_CODE    = string.Empty, RS_MSG = string.Empty;
            string splantcd   = string.Empty; //= cboPlantCode_H.Value.ToString();
            string sitemtype  = string.Empty; // cboItemType_H.Value.ToString();
            string sitem_cd   = txtItemCode.Text.Trim();
            string sitem_name = txtItemName.Text.Trim();

            //splantcd = Convert.ToSingle(cboPlantCode_H.sele)

            splantcd = Convert.ToString(cboPlantCode_H.Value);
            sitemtype = Convert.ToString(cboItemType_H.Value);
           
            if (splantcd == "ALL") splantcd = "";
            if (sitemtype == "ALL") sitemtype = "";

            _DtTemp = _biz.SEL_ItemMaster_POP(splantcd, sitem_cd ,sitem_name , sitemtype);

            Grid1.DataSource = _DtTemp;
            Grid1.DataBind();
        }
        private void Grid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            DataTable TmpDt = new DataTable();
            TmpDt.Columns.Add("ItemCode", typeof(string));
            TmpDt.Columns.Add("itemname", typeof(string));
            
            TmpDt.Rows.Add(new object[] { e.Row.Cells["ItemCode"].Value, e.Row.Cells["itemname"].Value});

            this.Tag = TmpDt;
            this.Close();
        }

        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                search();
            }
        }

        private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                search();
            }
        }

        private void Grid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

        }
    }
}
