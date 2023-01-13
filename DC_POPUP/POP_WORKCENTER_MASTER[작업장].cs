using System; 
using System.Data;
using System.Windows.Forms;
using Infragistics.Win;
using DC00_assm;
using DC00_PuMan;



namespace DC_POPUP
{
    public partial class POP_WORKCENTER_MASTER : DC00_WinForm.BasePopupForm
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

        public POP_WORKCENTER_MASTER(string[] param)
        {
            InitializeComponent();

            argument = new string[param.Length];
            Common _Common = new Common();

            DataTable rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  //사업장
            Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp);
            UltraGridUtil.SetComboUltraGrid(this.Grid1, "PlantCode", rtnDtTemp);

            
            rtnDtTemp = _Common.Standard_CODE("USEFLAG");     //사용여부
            Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp);
            UltraGridUtil.SetComboUltraGrid(this.Grid1, "UseFlag", rtnDtTemp);

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
                        txtOpCode.Text = argument[1].ToUpper(); //작업장코드
                        break;

                    case 2:
                        txtOpName.Text = argument[2].ToUpper(); //작업장명
                        break;

                    case 3:
                        cboUseFlag_H.Value = argument[3].ToUpper() == "" ? "" : argument[3].ToUpper(); //사용여부
                        break;
                }
                #endregion
            }
        }

        private void POP_WORKCENTER_MASTER_Load(object sender, EventArgs e)
        {
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            Common _Common = new Common();

            _GridUtil.InitializeGrid(this.Grid1);

            _GridUtil.InitColumnUltraGrid(Grid1, "PlantCode",       "사업장",      GridColDataType_emu.VarChar, 90,   HAlign.Left,   true, false );
            _GridUtil.InitColumnUltraGrid(Grid1, "WORKCENTERCODE",  "작업장코드",  GridColDataType_emu.VarChar, 110,  HAlign.Center, true, false );
            _GridUtil.InitColumnUltraGrid(Grid1, "WORKCENTERNAME",  "작업장명",    GridColDataType_emu.VarChar, 250,  HAlign.Left,   true, false );
            _GridUtil.InitColumnUltraGrid(Grid1, "UseFlag",         "사용유무",    GridColDataType_emu.VarChar, 100,  HAlign.Left,   true, false );

            _GridUtil.SetInitUltraGridBind(Grid1);

            rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  //사업장
            UltraGridUtil.SetComboUltraGrid(this.Grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            rtnDtTemp = _Common.Standard_CODE("USEFLAG");  // 사용유무
            UltraGridUtil.SetComboUltraGrid(this.Grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");


            search();
         
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            string RS_CODE    = string.Empty, RS_MSG = string.Empty;
            string sPlantCode = string.Empty;
            string sUseFlag   = string.Empty;
            string sOpCode    = txtOpCode.Text.Trim();
            string sOpName    = txtOpName.Text.Trim();

            sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);
            sUseFlag = Convert.ToString(this.cboUseFlag_H.Value); 
             
            _DtTemp = _biz.SEL_TBM0400(sPlantCode, sOpCode, sOpName, sUseFlag);

            Grid1.DataSource = _DtTemp;
            Grid1.DataBind();
        }
        private void Grid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            DataTable TmpDt = new DataTable();
            TmpDt.Columns.Add("OpCode", typeof(string));
            TmpDt.Columns.Add("OpName", typeof(string));

            TmpDt.Rows.Add(new object[] { e.Row.Cells["WORKCENTERCODE"].Value, e.Row.Cells["WORKCENTERNAME"].Value });

            this.Tag = TmpDt;
            this.Close();
        }

        private void txtOpCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                search();
            }
        }

        private void txtOpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                search();
            }
        }


    }
}
