#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_STockWIP
//   Form Name    : 재공 재고 조회
//   Name Space   : DC_PP
//   Created Date : 2020/08
//   Made By      : DSH
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using DC00_PuMan;

using DC00_assm;
using DC00_WinForm;

using Infragistics.Win.UltraWinGrid;
using System.Windows.Forms;

#endregion

namespace KDT_Form
{
    public partial class PP_WCTRunStopList : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataTable rtnDtTemp        = new DataTable(); // 
        UltraGridUtil _GridUtil    = new UltraGridUtil();  //그리드 객체 생성 
        string plantCode           = LoginInfo.PlantCode;

        #endregion


        #region < CONSTRUCTOR >
        public PP_WCTRunStopList()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void PP_WCTRunStopList_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            // 상차 실적 공통 내역 조회 및 선택
            _GridUtil.InitializeGrid(this.grid1);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE"     , "공장"          , GridColDataType_emu.VarChar   , 120, Infragistics.Win.HAlign.Left  , true , false);
          
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장"        , GridColDataType_emu.VarChar   , 120, Infragistics.Win.HAlign.Left  , true , false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명"      , GridColDataType_emu.VarChar   , 120, Infragistics.Win.HAlign.Left  , true , false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO"       , "작업지시번호"  , GridColDataType_emu.VarChar   , 150, Infragistics.Win.HAlign.Center, true , false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE"      , "품목"          , GridColDataType_emu.VarChar   , 120, Infragistics.Win.HAlign.Left  , true , false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME"      , "품명"          , GridColDataType_emu.VarChar   , 120, Infragistics.Win.HAlign.Left  , true , false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME"    , "작업자"        , GridColDataType_emu.VarChar   , 100, Infragistics.Win.HAlign.Left  , true , false);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUSNAME"    , "가동/비가동 명", GridColDataType_emu.VarChar   ,  80, Infragistics.Win.HAlign.Left  , true , false);
            _GridUtil.InitColumnUltraGrid(grid1, "RSSTARTDATE"   , "시작일시"      , GridColDataType_emu.DateTime24, 150, Infragistics.Win.HAlign.Left  , true , false);
            _GridUtil.InitColumnUltraGrid(grid1, "RSENDDATE"     , "종료일시"      , GridColDataType_emu.DateTime24, 150, Infragistics.Win.HAlign.Left  , true , false);
           
			_GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2);
			_GridUtil.InitColumnUltraGrid(grid2, "RSSEQ"   , "순번"        , GridColDataType_emu.VarChar   ,  80, Infragistics.Win.HAlign.Left , false, false);
			_GridUtil.InitColumnUltraGrid(grid2, "TIMEDIFF", "소요시간(분)", GridColDataType_emu.VarChar   ,  80, Infragistics.Win.HAlign.Right,  true, false);
			_GridUtil.InitColumnUltraGrid(grid2, "PRODQTY" , "양품수량"    , GridColDataType_emu.Double    ,  80, Infragistics.Win.HAlign.Right,  true, false);
			_GridUtil.InitColumnUltraGrid(grid2, "BADQTY"  , "불량수량"    , GridColDataType_emu.Double    ,  80, Infragistics.Win.HAlign.Right,  true, false);
			_GridUtil.InitColumnUltraGrid(grid2, "REMARK"  , "사유"        , GridColDataType_emu.VarChar   , 120, Infragistics.Win.HAlign.Left ,  true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER"   , "등록자"      , GridColDataType_emu.VarChar   , 100, Infragistics.Win.HAlign.Left ,  true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "등록일시"    , GridColDataType_emu.DateTime24, 150, Infragistics.Win.HAlign.Left ,  true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITOR"  , "수정자"      , GridColDataType_emu.VarChar   ,  80, Infragistics.Win.HAlign.Left ,  true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일시"    , GridColDataType_emu.DateTime24, 100, Infragistics.Win.HAlign.Left ,  true, false);
			_GridUtil.SetInitUltraGridBind(grid2);
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = Common.StandardCODE("PLANTCODE");  // 공장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp );
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp );

			rtnDtTemp = Common.GET_Workcenter_Code(); // 작업장
			Common.FillComboboxMaster(this.cboWorkcenterCode, rtnDtTemp);

			rtnDtTemp = Common.GET_StopList(); // 비가동 사유
			UltraGridUtil.SetComboUltraGrid(this.grid2, "REMARK", rtnDtTemp);

			#endregion

			#region ▶ POP-UP ◀
			BizTextBoxManager btbManager = new BizTextBoxManager();
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
				string sPlantCode = Convert.ToString(cboPlantCode.Value);
				string sWorkcenterCode = Convert.ToString(cboWorkcenterCode.Value);
				string sStartDate = string.Format("{0:yyyy-MM-dd}", dtpStart.Value);
				string sEndDate = string.Format("{0:yyyy-MM-dd}", dtpEnd.Value);


				rtnDtTemp = helper.FillTable("07PP_WCTRunStopList_S1", CommandType.StoredProcedure
																   , helper.CreateParameter("PLANTCODE", sPlantCode)
																   , helper.CreateParameter("WORKCENTERCODE", sWorkcenterCode)
																   , helper.CreateParameter("STARTDATE", sStartDate)
																   , helper.CreateParameter("ENDDATE", sEndDate)
									);

				this.ClosePrgForm();
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

		private void grid1_AfterRowActivate(object sender, EventArgs e)
		{
			DBHelper helper = new DBHelper(false);
			try
			{
				_GridUtil.Grid_Clear(grid2);
                string sPlantCode     = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
				string sWorkcenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
				string sOrderNo = Convert.ToString(grid1.ActiveRow.Cells["ORDERNO"].Value);

				rtnDtTemp = helper.FillTable("07PP_WCTRunStopList_S2", CommandType.StoredProcedure
																   , helper.CreateParameter("PLANTCODE", sPlantCode)
																   , helper.CreateParameter("WORKCENTERCODE", sWorkcenterCode)
																   , helper.CreateParameter("ORDERNO", sOrderNo)
																   );
				this.grid2.DataSource = rtnDtTemp;
				grid2.Rows[0].Cells["REMARK"].Activate();
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

		public override void DoSave()
		{
			// 저장 할 대상이 있는지 확인 (그리드에 번경된 내역이 있는지 추출)
			DataTable dt = grid2.chkChange();
			if (dt == null)
			{
				ShowDialog("저장 할 내역이 없습니다.");
				return;
			}

			DBHelper helper = new DBHelper(true); // 트랜잭션 사용 DB 커넥터.
			try
			{
				foreach (DataRow drRow in dt.Rows)
				{
					switch (drRow.RowState)
					{
						case DataRowState.Modified:
							if (Convert.ToString(drRow["REMARK"]) == "") continue;
							string sPlantCode      = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
							string sWorkcenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
							string sOrderNo        = Convert.ToString(grid1.ActiveRow.Cells["ORDERNO"].Value);
							helper.ExecuteNoneQuery("07PP_WCTRunStopList_U1", CommandType.StoredProcedure
												  , helper.CreateParameter("PLANTCODE"     , sPlantCode)
												  , helper.CreateParameter("WORKCENTERCODE", sWorkcenterCode)
												  , helper.CreateParameter("ORDERNO"       , sOrderNo)
												  , helper.CreateParameter("RSSEQ"         , Convert.ToString(drRow["RSSEQ"]))
												  , helper.CreateParameter("REMARK"        , Convert.ToString(drRow["REMARK"]))
												  , helper.CreateParameter("MAKEDATE"      , Convert.ToString(drRow["MAKEDATE"]))
												  , helper.CreateParameter("EDITOR"        , LoginInfo.UserID)
												  );
							break;
					}
					if (helper.RSCODE != "S")
					{
						helper.Rollback();
						ShowDialog(helper.RSMSG);
						return;
					}
				}
				helper.Commit();
				ClosePrgForm();
				MessageBox.Show("정상적으로 등록을 완료 하였습니다.");

			}
			catch (Exception ex)
			{
				ClosePrgForm();
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




