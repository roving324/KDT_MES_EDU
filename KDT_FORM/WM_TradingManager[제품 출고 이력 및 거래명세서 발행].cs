#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_STockWIP
//   Form Name    : 제품 출고 이력 및 거래명세서 발행
//   Name Space   : DC_PP
//   Created Date : 2020/08
//   Made By      : HJY
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
using DC_POPUP;
using Telerik.Reporting;
#endregion

namespace KDT_Form
{
    public partial class WM_TradingManager : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataTable rtnDtTemp        = new DataTable(); // 
        UltraGridUtil _GridUtil    = new UltraGridUtil();  //그리드 객체 생성 
        string plantCode           = LoginInfo.PlantCode;

        #endregion


        #region < CONSTRUCTOR >
        public WM_TradingManager()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void WM_TradingManager_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE"  , "공장"    , GridColDataType_emu.VarChar   , 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TRADINGNO"  , "출고번호", GridColDataType_emu.VarChar   , 140, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TRADINGDATE", "출고일자", GridColDataType_emu.VarChar   , 140, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CARNO"      , "차량번호", GridColDataType_emu.VarChar   , 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE"   , "등록일시", GridColDataType_emu.DateTime24, 150, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER"      , "등록자"  , GridColDataType_emu.VarChar   , 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE" , "공장"    , GridColDataType_emu.VarChar   , 120, Infragistics.Win.HAlign.Left  , false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "TRADINGNO" , "출고번호", GridColDataType_emu.VarChar   , 150, Infragistics.Win.HAlign.Center, true , false);
            _GridUtil.InitColumnUltraGrid(grid2, "TRADINGSEQ", "출고순번", GridColDataType_emu.VarChar   ,  80, Infragistics.Win.HAlign.Left  , true , false);
            _GridUtil.InitColumnUltraGrid(grid2, "SHIPNO"    , "상차번호", GridColDataType_emu.VarChar   , 150, Infragistics.Win.HAlign.Center, true , false);
            _GridUtil.InitColumnUltraGrid(grid2, "SHIPSEQ"   , "상차순번", GridColDataType_emu.VarChar   ,  80, Infragistics.Win.HAlign.Left  , true , false);
            _GridUtil.InitColumnUltraGrid(grid2, "WORKER"    , "작업자"  , GridColDataType_emu.VarChar   , 100, Infragistics.Win.HAlign.Left  , true , false);
            _GridUtil.InitColumnUltraGrid(grid2, "CUSTCODE"  , "거래처"  , GridColDataType_emu.VarChar   , 100, Infragistics.Win.HAlign.Left  , true , false);
            _GridUtil.InitColumnUltraGrid(grid2, "CUSTNAME"  , "거래처명", GridColDataType_emu.VarChar   , 130, Infragistics.Win.HAlign.Left  , true , false);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTNO"     , "LOTNO"   , GridColDataType_emu.VarChar   , 160, Infragistics.Win.HAlign.Center, true , false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE"  , "품번"    , GridColDataType_emu.VarChar   , 150, Infragistics.Win.HAlign.Left  , true , false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME"  , "품명"    , GridColDataType_emu.VarChar   , 160, Infragistics.Win.HAlign.Left  , true , false);
            _GridUtil.InitColumnUltraGrid(grid2, "TRADINGQTY", "상차수량", GridColDataType_emu.Double   ,   80, Infragistics.Win.HAlign.Right , true , false);
            _GridUtil.InitColumnUltraGrid(grid2, "BASEUNIT"  , "단위"    , GridColDataType_emu.VarChar   , 100, Infragistics.Win.HAlign.Left  , true , false);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE"  , "상차일시", GridColDataType_emu.DateTime24, 160, Infragistics.Win.HAlign.Left  , true , false);
			_GridUtil.SetInitUltraGridBind(grid2);
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = Common.StandardCODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp );
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp );

            rtnDtTemp = Common.StandardCODE("UNITCODE");   // 단위
            UltraGridUtil.SetComboUltraGrid(this.grid2, "BASEUNIT", rtnDtTemp);

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
                base.DoInquire();
                _GridUtil.Grid_Clear(grid1);
                string sPlantCode  = Convert.ToString(cboPlantCode.Value);
                string sInvoiceNo  = Convert.ToString(txtInvoiceNo.Text);
				string sCarNo      = Convert.ToString(txtCarNo.Text);
				string sStartDate  = string.Format("{0:yyyy-MM-dd}", dtpStart.Value);
				string sEndDate    = string.Format("{0:yyyy-MM-dd}", dtpEnd.Value);

				rtnDtTemp = helper.FillTable("07WM_TradingManager_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", sPlantCode)                  
                                                                   , helper.CreateParameter("INVOICENO", sInvoiceNo)
                                                                   , helper.CreateParameter("CARNO"    , sCarNo)
                                                                   , helper.CreateParameter("STARTDATE", sStartDate)
                                                                   , helper.CreateParameter("ENDDATE"  , sEndDate)
																   );
                this.ClosePrgForm();
                this.grid1.DataSource = rtnDtTemp;
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(),DialogForm.DialogType.OK);    
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
				string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
				string sTradingNo = Convert.ToString(grid1.ActiveRow.Cells["TRADINGNO"].Value);

				rtnDtTemp = helper.FillTable("07WM_TradingManager_S2", CommandType.StoredProcedure
																   , helper.CreateParameter("PLANTCODE", sPlantCode)
																   , helper.CreateParameter("TRADINGNO", sTradingNo)
																   );
				this.ClosePrgForm();
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

		private void btnInvPrint_Click(object sender, EventArgs e)
		{
            // 거래 명세서 발행 버튼 클릭.
            if (grid1.Rows.Count == 0) return;
            if (grid1.ActiveRow == null) return;

			DBHelper helper = new DBHelper(false);
			try
			{
				string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
				string sTradingNo = Convert.ToString(grid1.ActiveRow.Cells["TRADINGNO"].Value);

				rtnDtTemp = helper.FillTable("07WM_TradingManager_S3", CommandType.StoredProcedure
																   , helper.CreateParameter("PLANTCODE", sPlantCode)
																   , helper.CreateParameter("TRADINGNO", sTradingNo)
																   );
				#region < 거래처 별로 거래 명세서 발행 >
				// 거래처 별로 거래 명세서 발행.
				if (rtnDtTemp.Rows.Count == 0) return;

                // 받아온 데이터의 행 중에 업체의 개수가 몇 개인지 파악.
                int iCustCount = 1; // 업체의 개수
                string sCustName = Convert.ToString(rtnDtTemp.Rows[0]["CUSTNAME"]); // 업체명

				for (int i = 1; i < rtnDtTemp.Rows.Count; i++)
                {
                    if(sCustName != Convert.ToString(rtnDtTemp.Rows[i]["CUSTNAME"])) // 일자별 업체 종류 파악
                    {
						sCustName = Convert.ToString(rtnDtTemp.Rows[i]["CUSTNAME"]);
						iCustCount++;
					}
                }

                // 데이터 테이블 배열 선언
                DataTable[] dtReport = new DataTable[iCustCount];

                // 새로 만든 데이터 테이블 배열의 컬럼 초기화.
                dtReport[0] = new DataTable();
                dtReport[0] = rtnDtTemp.Clone();

                // 거래처 별로 데이터 배열에 나누어 담기
                int iCustCount_2 = 0;
                sCustName = Convert.ToString(rtnDtTemp.Rows[0]["CUSTNAME"]);
				for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
				{
					if (sCustName != Convert.ToString(rtnDtTemp.Rows[i]["CUSTNAME"]))
                    {
						iCustCount_2++;
					    dtReport[iCustCount_2] = new DataTable();
						dtReport[iCustCount_2] = rtnDtTemp.Clone();
                        sCustName = Convert.ToString(rtnDtTemp.Rows[i]["CUSTNAME"]);
					}
                    dtReport[iCustCount_2].ImportRow(rtnDtTemp.Rows[i]);
				}

				// 거래명세 디자인 업체 수만큼 배연선언.
				Report_specification_on_transaction[] report_Tran = new Report_specification_on_transaction[iCustCount];

                ReportBook RepBook = new ReportBook();

				// 거래명세 디자인 배열에 데이터 테이블 매핑
				for (int i = 0; i < iCustCount; i++)
                {
                    report_Tran[i] = new Report_specification_on_transaction();
					report_Tran[i].DataSource = dtReport[i];
                    RepBook.Reports.Add(report_Tran[i]);
				}

				ReportViewer Viewer = new ReportViewer(RepBook);
				Viewer.ShowDialog();

				#endregion
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




