#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM_StockShip
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
using DC00_PuMan;
using DC00_WinForm;

using Infragistics.Win.UltraWinGrid;
#endregion

namespace KDT_Form
{
    public partial class WM_StockShip : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA > 
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성 
        DataTable rtnDtTemp = new DataTable(); // 
        #endregion


        #region < CONSTRUCTOR >
        public WM_StockShip()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void WM_StockShip_Load(object sender, EventArgs e)
        { 
            string plantCode        = LoginInfo.PlantCode;

            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK"        ,"상차등록", GridColDataType_emu.CheckBox  , 120, Infragistics.Win.HAlign.Left , true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE"  ,"공장"    , GridColDataType_emu.VarChar   , 120, Infragistics.Win.HAlign.Left , true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE"   ,"품목"    , GridColDataType_emu.VarChar   , 140, Infragistics.Win.HAlign.Left , true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME"   ,"품명"    , GridColDataType_emu.VarChar   , 150, Infragistics.Win.HAlign.Left , true, false);
             _GridUtil.InitColumnUltraGrid(grid1, "LOTNO"     ,"LOTNO"   , GridColDataType_emu.VarChar   , 160, Infragistics.Win.HAlign.Left , true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE"     ,"창고"    , GridColDataType_emu.VarChar   , 120, Infragistics.Win.HAlign.Left , true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY"   ,"재고수량", GridColDataType_emu.Double    , 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE"   ,"단위"    , GridColDataType_emu.VarChar   , 100, Infragistics.Win.HAlign.Left , true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INDATE"     ,"입고일자", GridColDataType_emu.VarChar   , 100, Infragistics.Win.HAlign.Left , true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER"      ,"입고자"  , GridColDataType_emu.VarChar   , 100, Infragistics.Win.HAlign.Left , true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE"   ,"입고일시", GridColDataType_emu.DateTime24, 160, Infragistics.Win.HAlign.Left , true, false);




            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = Common.StandardCODE("PLANTCODE");  //사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp);
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp);

            rtnDtTemp = Common.StandardCODE("UNITCODE");   //단위
            UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp);

            rtnDtTemp = Common.StandardCODE("WHCODE");     //창고
            UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp);

            rtnDtTemp = Common.Get_ItemCode(new string[] {"FERT"});
            Common.FillComboboxMaster(this.cboItemCode, rtnDtTemp);

			#endregion

			#region ▶ POP-UP ◀
			BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtWorkID, txtWorkName, "WORKER_MASTER");
			btbManager.PopUpAdd(txtCustCode, txtCustName, "CUST_MASTER");

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
                string sStartdate = string.Format("{0:yyyy-MM-dd}", dtStartDate.Value);
                string sEndDate   = string.Format("{0:yyyy-MM-dd}", dtEnddate.Value);

                rtnDtTemp = helper.FillTable("07WM_StockShip_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE", sPlantCode)
                                    , helper.CreateParameter("ITEMCODE" ,  sItemCode)
                                    , helper.CreateParameter("LOTNO"    ,     sLotNo   )
                                    , helper.CreateParameter("STARTDATE", sStartdate)
                                    , helper.CreateParameter("ENDDATE"  ,   sEndDate )
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
            if (grid1.Rows.Count == 0) return;
            // 그리드에서 변경 된 행을 받아온다.
            DataTable dtChange = grid1.chkChange();
            if(dtChange == null) return;

            DBHelper helper = new DBHelper(false);
            try
            {
                // 차량 번호 입력 여부 확인
                string sCarNo = txtCarNo.Text;
                if(sCarNo == "")
                {
                    ShowDialog("차량 정보를 입력하지 않았습니다.");
                    return;
                }
				// 운송자 정보 입력 여부 확인
				string sWorker = txtWorkID.Text;
				if (sWorker == "")
				{
					ShowDialog("운송자 정보를 입력하지 않았습니다.");
					return;
				}
				// 거래처 정보 입력 여부 확인
				string sCustCode = txtCustCode.Text;
				if (sCustCode == "")
				{
					ShowDialog("거래처 정보를 입력하지 않았습니다.");
					return;
				}

                string sLotNo     = string.Empty;
                string sItemCode  = string.Empty;
                string sPlantCode = string.Empty;
                string sShipNO    = string.Empty;
                double dShipQTY   = 0;

				foreach (DataRow dr in dtChange.Rows)
                {
                    switch (dr.RowState)
                    {
                        case DataRowState.Modified:
                            sLotNo = Convert.ToString(dr["LOTNO"]);
							sItemCode = Convert.ToString(dr["ITEMCODE"]);
							sPlantCode = Convert.ToString(dr["PLANTCODE"]);
							dShipQTY = Convert.ToDouble(dr["STOCKQTY"]);

							helper.ExecuteNoneQuery("07WM_StockShip_U1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", sPlantCode)
                                                    , helper.CreateParameter("ITEMCODE" , sItemCode)
                                                    , helper.CreateParameter("LOTNO"    , sLotNo)
													, helper.CreateParameter("CARNO"    , sCarNo)
													, helper.CreateParameter("WORKER"   , sWorker)
													, helper.CreateParameter("CUSTCODE" , sCustCode)
													, helper.CreateParameter("SHIPQTY"  , dShipQTY)
													, helper.CreateParameter("SHIPNO"   , sShipNO)
													, helper.CreateParameter("MAKER"    , LoginInfo.UserID)
								);
                            sShipNO = Convert.ToString(helper.RSMSG);
							break;
                    }

					if (helper.RSCODE != "S") throw new Exception(helper.RSMSG);
				}
               
                helper.Commit();
                ShowDialog("상차 실적 등록을 완료하였습니다.");

            }
            catch (Exception ex)
            {
                helper.Rollback();
                ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
	}
}




