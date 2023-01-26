#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM_StockWmRec
//   Form Name    : 공정 재고 입출 이력
//   Name Space   : KDT_Form
//   Created Date : 2023-01-16
//   Made By      : HJY
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using DC_POPUP;

using DC00_assm;
using DC00_WinForm;

using Infragistics.Win.UltraWinGrid;
#endregion

namespace KDT_Form
{
    public partial class WM_StockWmRec : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA > 
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성 
        DataTable rtnDtTemp = new DataTable(); // 
        #endregion


        #region < CONSTRUCTOR >
        public WM_StockWmRec()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void WM_StockWmRec_Load(object sender, EventArgs e)
        { 
            string plantCode        = LoginInfo.PlantCode;

            #region ▶ GRID1 ◀
            //_GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            //_GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE"  ,"공장",       true, GridColDataType_emu.VarChar,    120, 120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitializeGrid(this.grid1);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장"   , GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE" ,"품목"    , GridColDataType_emu.VarChar,    140, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME" ,"품명"    , GridColDataType_emu.VarChar,    150, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE" ,"품목구분", GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left,   true, false);
			_GridUtil.InitColumnUltraGrid(grid1, "LOTNO"    ,"LOTNO"   , GridColDataType_emu.VarChar,    160, Infragistics.Win.HAlign.Left,   true, false);
			_GridUtil.InitColumnUltraGrid(grid1, "WHCODE"   ,"창고"    , GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY" ,"재고수량", GridColDataType_emu.Double,    100, Infragistics.Win.HAlign.Right,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE" ,"단위"    , GridColDataType_emu.VarChar,    100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SHIPFLAG" ,"상차여부", GridColDataType_emu.VarChar,     100, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER"    ,"입고자"  , GridColDataType_emu.DateTime24, 160, Infragistics.Win.HAlign.Left,   true, false);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region ▶ GRID2 ◀
            _GridUtil.InitializeGrid(this.grid2);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE"  ,"공장",        GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left,  false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTNO"      , "LOTNO",      GridColDataType_emu.VarChar,    160, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE"   ,"품목",        GridColDataType_emu.VarChar,    140, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME"   ,"품명",        GridColDataType_emu.VarChar,    150, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "RECDATE"    ,"입/출일자",   GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left,   true, false);
			_GridUtil.InitColumnUltraGrid(grid2, "WHCODE"     ,"창고",        GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INOUTCODE"  ,"입출유형",    GridColDataType_emu.VarChar,    100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INOUTFLAG"  ,"입출구분",    GridColDataType_emu.VarChar,    100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INOUTQTY"   ,"입출수량",    GridColDataType_emu.Double,     100, Infragistics.Win.HAlign.Right,  true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "BASEUNIT"   ,"단위",        GridColDataType_emu.VarChar,    100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER"      ,"등록자",      GridColDataType_emu.VarChar,    100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE"   ,"등록일시",    GridColDataType_emu.DateTime24, 160, Infragistics.Win.HAlign.Left,   true, false);

            _GridUtil.SetInitUltraGridBind(grid2);
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = Common.StandardCODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp);
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp);

            rtnDtTemp = Common.StandardCODE("UNITCODE");     //단위
            UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp);
			UltraGridUtil.SetComboUltraGrid(this.grid2, "BASEUNIT", rtnDtTemp);

			rtnDtTemp = Common.Get_ItemCode(new string[] { "FERT" });
            Common.FillComboboxMaster(this.cboItemCode, rtnDtTemp);


            rtnDtTemp = Common.StandardCODE("WHCODE");     //창고
            UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp);
			UltraGridUtil.SetComboUltraGrid(this.grid2, "WHCODE", rtnDtTemp);

			rtnDtTemp = Common.StandardCODE("INOUTCODE");     //입출유형
            UltraGridUtil.SetComboUltraGrid(this.grid2, "INOUTCODE", rtnDtTemp);

            rtnDtTemp = Common.StandardCODE("INOUTFLAG");     //입출 구분 
            UltraGridUtil.SetComboUltraGrid(this.grid2, "INOUTFLAG", rtnDtTemp);

			rtnDtTemp = Common.StandardCODE("ITEMTYPE");     //품목 구분 
			UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMTYPE", rtnDtTemp);

			rtnDtTemp = Common.StandardCODE("YESNO");     //상차 여부 
			UltraGridUtil.SetComboUltraGrid(this.grid1, "SHIPFLAG", rtnDtTemp);

			#endregion

			#region ▶ POP-UP ◀
			#endregion

			#region ▶ ENTER-MOVE ◀
			cboPlantCode.Value = plantCode;
            #endregion
        }
        #endregion


        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            DoFind();
        }
        private void DoFind()
        {
            DBHelper helper = new DBHelper(false);
            try
            { 
                _GridUtil.Grid_Clear(grid1);
                string sPlantCode = Convert.ToString(this.cboPlantCode.Value);
                string sItemCode  = Convert.ToString(this.cboItemCode.Value); 
                string sLotNo     = Convert.ToString(txtLotNo.Text );

                rtnDtTemp = helper.FillTable("07WM_StockWMRec_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE", sPlantCode)
                                    , helper.CreateParameter("ITEMCODE",  sItemCode)
                                    , helper.CreateParameter("LOTNO",     sLotNo   )
                                    );
                 
                this.grid1.DataSource = rtnDtTemp;
               
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion 

        public override void DoSave()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                _GridUtil.Grid_Clear(grid1);
                string sPlantCode = Convert.ToString(this.cboPlantCode.Value);
                string sItemCode = Convert.ToString(this.cboItemCode.Value);
                string sLotNo = Convert.ToString(txtLotNo.Text);

                rtnDtTemp = helper.FillTable("PP_StockPP_U1", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE", sPlantCode)
                                    , helper.CreateParameter("ITEMCODE", sItemCode)
                                    , helper.CreateParameter("LOTNO", sLotNo)
                                    );

                this.grid1.DataSource = rtnDtTemp;

            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

		private void grid1_AfterRowActivate(object sender, EventArgs e)
		{
			DBHelper helper = new DBHelper(false);
			try
			{
				_GridUtil.Grid_Clear(grid2);
				string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
				string sLotNo = Convert.ToString(grid1.ActiveRow.Cells["LOTNO"].Value);
				rtnDtTemp = helper.FillTable("07WM_StockWMRec_S2", CommandType.StoredProcedure
									, helper.CreateParameter("PLANTCODE", sPlantCode)
									, helper.CreateParameter("LOTNO", sLotNo)
									);

				this.grid2.DataSource = rtnDtTemp;

			}
			catch (Exception ex)
			{
				ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
			}
			finally
			{
				helper.Close();
			}
		}
	}
}




