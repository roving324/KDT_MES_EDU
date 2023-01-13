using System; 
using System.Data; 
using System.Windows.Forms;
using Infragistics.Win;
using DC00_assm;
using DC00_WinForm;


namespace DC_POPUP
{
    public partial class POP_ORDERNO : BasePopupForm
    {
        string[] argument;

        #region [ 선언자 ]
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();

        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();
        private string sWorkcenterCode = string.Empty;
        private string sWorkcenterName = string.Empty;


        #endregion

        public POP_ORDERNO(string WorkcenterCode, string WorkcenterName)
        {
            InitializeComponent();

            sWorkcenterCode = WorkcenterCode;
            sWorkcenterName = WorkcenterName;
            txtWorkcenterCode.Text = sWorkcenterCode;
            txtWorkcenterName.Text = sWorkcenterName;

            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  //사업장
            Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp);
            UltraGridUtil.SetComboUltraGrid(this.Grid1, "PlantCode", rtnDtTemp);
        }

        private void POP_ORDERNO_Load(object sender, EventArgs e)
        {
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            Common _Common = new Common();
            _GridUtil.InitializeGrid(this.Grid1);

            _GridUtil.InitColumnUltraGrid(Grid1, "PlantCode",       "사업장",           GridColDataType_emu.VarChar,  90,  HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(Grid1, "WORKCENTERCODE",  "작업장코드",       GridColDataType_emu.VarChar, 110,  HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(Grid1, "WORKCENTERNAME",  "작업장명",         GridColDataType_emu.VarChar, 130,  HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(Grid1, "ORDERNO",         "작업지시 번호",    GridColDataType_emu.VarChar, 140,  HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(Grid1, "ORDERDATE",       "작업지시 일자",    GridColDataType_emu.VarChar, 120,  HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(Grid1, "ITEMCODE",        "지시 품목",        GridColDataType_emu.VarChar, 120,  HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(Grid1, "ITEMNAME",        "지시 품명",        GridColDataType_emu.VarChar, 160,  HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(Grid1, "ORDERQTY",        "지시 수량",        GridColDataType_emu.Double,  100,  HAlign.Right,  true, false);
            _GridUtil.SetInitUltraGridBind(Grid1);
            search();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            string RS_CODE    = string.Empty, RS_MSG = string.Empty;
            string sPlantCode      = Convert.ToString(cboPlantCode_H.Value);
            string sWorkcenterCode = txtWorkcenterCode.Text;
            string sWorkcenterNamr = txtWorkcenterName.Text;
            string sStartDate      = string.Format("{0:yyyy-MM-dd}", dtStartDate.Value);
            string sEndDate        = string.Format("{0:yyyy-MM-dd}", dtEnddate.Value);

            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            DBHelper helper = new DBHelper(false);
            try
            {
                rtnDtTemp = helper.FillTable("USP_OrderNo_POP", CommandType.StoredProcedure
                , helper.CreateParameter("PLANTCODE",      sPlantCode      )
                , helper.CreateParameter("WORKCENTERCODE", sWorkcenterCode  )
                , helper.CreateParameter("WORKCENTERNAME", sWorkcenterNamr  )
                , helper.CreateParameter("STARTDATE",      sStartDate      )
                , helper.CreateParameter("ENDDATE",        sEndDate      ));

                if (rtnDtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("금일 작업장에 내려진 작업지시가 없습니다.");
                }
                else
                {
                    this.Grid1.DataSource = rtnDtTemp;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                helper.Close();
            }
        }
        private void Grid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            this.Tag = Convert.ToString(this.Grid1.ActiveRow.Cells["ORDERNO"].Value);
            this.Close();
        }

  


    }
}
