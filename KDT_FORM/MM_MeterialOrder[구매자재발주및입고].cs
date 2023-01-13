using DC00_assm;
using Infragistics.Win;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM_MeterialOrder
//   Form Name    : 구매자재발주및입고
//   Name Space   : KDT_Form
//   Created Date : 2023-01-04
//   Made By      : HJY
//   Description  : 구매자재발주및입고
// *---------------------------------------------------------------------------------------------*
#endregion

namespace KDT_Form
{
    public partial class MM_MeterialOrder : DC00_WinForm.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        UltraGridUtil GridUtill = new UltraGridUtil(); // 그리드를 셋팅하는 클래스.
        public MM_MeterialOrder()
        {
            InitializeComponent();
        }
        #endregion

        #region < EVENT AREA >
        private void MM_MeterialOrder_Load(object sender, EventArgs e)
        {
            // 1. 그리드 셋팅.
            GridUtill.InitializeGrid(grid1); // 그리드 초기화.
            GridUtill.InitColumnUltraGrid(grid1, "PLANTCODE", "공장"    , GridColDataType_emu.VarChar     , 150, HAlign.Left  , true, true);
                                                                                                          
            // 구매자재 발주                                                                              
            GridUtill.InitColumnUltraGrid(grid1, "PONO"     , "발주번호", GridColDataType_emu.VarChar     , 130, HAlign.Center, true, false);
            GridUtill.InitColumnUltraGrid(grid1, "ITEMCODE" , "발주품목", GridColDataType_emu.VarChar     , 200, HAlign.Left  , true, true);
            GridUtill.InitColumnUltraGrid(grid1, "PODATE"   , "발주일자", GridColDataType_emu.YearMonthDay, 120, HAlign.Left  , true, true);
            GridUtill.InitColumnUltraGrid(grid1, "POQTY"    , "발주수량", GridColDataType_emu.Double      ,  80, HAlign.Right , true, false);
            GridUtill.InitColumnUltraGrid(grid1, "UNITCODE" , "단위"    , GridColDataType_emu.VarChar     ,  80, HAlign.Left  , true, false);
            GridUtill.InitColumnUltraGrid(grid1, "CUSTCODE" , "거래처"  , GridColDataType_emu.VarChar     , 160, HAlign.Left  , true, false);
                                                            
            // 구매자재 입고                                
            GridUtill.InitColumnUltraGrid(grid1, "CHK"      , "입고"    , GridColDataType_emu.CheckBox    ,  80, HAlign.Center, true, true);
            GridUtill.InitColumnUltraGrid(grid1, "INQTY"    , "입고수량", GridColDataType_emu.Double      , 150, HAlign.Right , true, true);
            GridUtill.InitColumnUltraGrid(grid1, "LOTNO"    , "LOT번호" , GridColDataType_emu.VarChar     , 200, HAlign.Center, true, false);
            GridUtill.InitColumnUltraGrid(grid1, "INDATE"   , "입고일자", GridColDataType_emu.VarChar     , 150, HAlign.Left  , true, false);
            GridUtill.InitColumnUltraGrid(grid1, "INWORKER" , "입고자"  , GridColDataType_emu.VarChar     , 100, HAlign.Left  , true, false);
                                                                                                                                     
            GridUtill.InitColumnUltraGrid(grid1, "MAKEDATE" , "등록일시", GridColDataType_emu.DateTime24  , 150, HAlign.Left  , true, false);
            GridUtill.InitColumnUltraGrid(grid1, "MAKER"    , "등록자"  , GridColDataType_emu.VarChar     , 100, HAlign.Left  , true, false);
            GridUtill.InitColumnUltraGrid(grid1, "EDITDATE" , "수정일시", GridColDataType_emu.DateTime24  , 150, HAlign.Left  , true, false);
            GridUtill.InitColumnUltraGrid(grid1, "EDITOR"   , "수정자"  , GridColDataType_emu.VarChar     , 100, HAlign.Left  , true, false);
            GridUtill.SetInitUltraGridBind(grid1); // 그리드 데이터 바인딩 초기화

            // 2. 콤보박스 셋팅.
            DataTable dtTemp = new DataTable();  // 콤보박스 셋팅 할 데이터를 받아올 자료형

            // 공장
            dtTemp = Common.StandardCODE("PLANTCODE");                   // 공통기준정보 PLANTCODE 데이터 가져오기.
            Common.FillComboboxMaster(cboPlantCode, dtTemp);             // 콤보박스 컨트롤에 셋팅.
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtTemp); //그리드에 콤보박스 셋팅.

            // 거래처
            dtTemp = Common.GET_Cust_Code();
            Common.FillComboboxMaster(cboCustCode, dtTemp);
            UltraGridUtil.SetComboUltraGrid(grid1, "CUSTCODE", dtTemp);

            // 단위
            dtTemp = Common.StandardCODE("UNITCODE");
            UltraGridUtil.SetComboUltraGrid(grid1, "UNITCODE", dtTemp);

            // 품목
            // ROH : 원자재, HALB : 반제품, FERT : 완제품
            dtTemp = Common.Get_ItemCode(new string[] { "ROH"});
            Common.FillComboboxMaster(cboItemCode, dtTemp);
            UltraGridUtil.SetComboUltraGrid(grid1,"ITEMCODE", dtTemp);
        }
        #endregion

        #region < TOOLBAR AREA >
        public override void DoInquire()
        {
            base.DoInquire();

            // 트랜잭션을 사용하지 않을 helper
            DBHelper helper = new DBHelper(false);
            try
            {
                // 조회 조건 변수 등록 및 데이터 데입
                string sPlantCode   = Convert.ToString(cboPlantCode.Value);            // 공장
                string sCustCode    = Convert.ToString(cboCustCode.Value);             // 거래처 
                string sPoNo        = txtPoNo.Text;                                    // 발주 번호
                string sItemCode    = Convert.ToString(cboItemCode.Value);             // 품목
                string sPoStartDate = string.Format("{0:yyyy-MM-dd}", dtpStart.Value); // 발주시작 일자
                string sPoEndDate   = string.Format("{0:yyyy-MM-dd}", dtpEnd.Value);   // 발주종료 일자

                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("07MM_MeterialOrder_S1", CommandType.StoredProcedure
                                          , helper.CreateParameter("PlantCode"  , sPlantCode)
                                          , helper.CreateParameter("CustCode"   , sCustCode)
                                          , helper.CreateParameter("PoNo"       , sPoNo)
                                          , helper.CreateParameter("ItemCode"   , sItemCode)
                                          , helper.CreateParameter("PoStartDate", sPoStartDate)
                                          , helper.CreateParameter("PoEndDate"  , sPoEndDate)
                                          );
                if (dtTemp.Rows.Count == 0)
                {
                    ShowDialog("조회할 내역이 없습니다.");
                    // 그리드 초기화
                    GridUtill.Grid_Clear(grid1);
                    return;
                }
                grid1.DataSource = dtTemp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        public override void DoNew()
        {
            // 신규행 추가.
            grid1.InsertRow();

            // 기본 값 셋팅.
            grid1.SetDefaultValue("PLANTCODE", LoginInfo.PlantCode);
            grid1.SetDefaultValue("CHK", 0);  // 사용여부
            grid1.SetDefaultValue("PODATE", string.Format("{0:yyyy-MM-dd}",DateTime.Now));
        }

        public override void DoDelete()
        {
            grid1.DeleteRow();
        }
        #endregion

        public override void DoSave()
        {
            base.DoSave();
            // 저장 할 대상이 있는지 확인 (그리드에 번경된 내역이 있는지 추출)
            DataTable dt = grid1.chkChange();
            if (dt == null)
            {
                ShowDialog("저장 할 내역이 없습니다.");
                return;
            }

            string sMessge = string.Empty;

            DBHelper helper = new DBHelper(true); // 트랜잭션 사용 DB 커넥터.

            try
            {

                base.DoSave();

                foreach (DataRow drRow in dt.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges(); // 삭제된 데이터 원상 복귀.

                            // 생산계획을 취소
                            helper.ExecuteNoneQuery("07MM_MeterialOrder_D1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]))
                                                    , helper.CreateParameter("PLANNO"   , Convert.ToString(drRow["PLANNO"])));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            if (Convert.ToString(drRow["ITEMCODE"]) == "") sMessge = "발주품목";
                            else if (Convert.ToString(drRow["CUSTCODE"])  == "")   sMessge = "거래처";
                            else if (Convert.ToString(drRow["PODATE"])  == "")   sMessge = "발주일자";
                            else if (Convert.ToString(drRow["POQTY"]) == "") sMessge = "발주수량";
                            if (sMessge != "")
                            {
                                //throw new Exception(sMessge + "을 입력하지 않았습니다.");
                                ShowDialog(sMessge + "을 입력하지 않았습니다.");
                                return;
                            }

                            // 구매자재 발주 등록.
                            helper.ExecuteNoneQuery("07MM_MeterialOrder_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]))
                                                    , helper.CreateParameter("ITEMCODE" , Convert.ToString(drRow["ITEMCODE"]))
                                                    , helper.CreateParameter("POQTY"    , Convert.ToString(drRow["POQTY"]))
                                                    , helper.CreateParameter("UNITCODE" , Convert.ToString(drRow["UNITCODE"]))
                                                    , helper.CreateParameter("PODATE"   , Convert.ToString(drRow["PODATE"]))
                                                    , helper.CreateParameter("CUSTCODE" , Convert.ToString(drRow["CUSTCODE"]))
                                                    , helper.CreateParameter("MAKER"    , LoginInfo.UserID)
                                                    );  
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            // 발주내역으로 입고 등록
                            if (Convert.ToString(drRow["INQTY"]) == "") throw new Exception("입고수량을 입력하지 않았습니다..");

                            helper.ExecuteNoneQuery("07MM_MeterialOrder_U1"
                                                  , CommandType.StoredProcedure
                                                  , helper.CreateParameter("PLANTCODE" , Convert.ToString(drRow["PLANTCODE"]))
                                                  , helper.CreateParameter("PONO"      , Convert.ToString(drRow["PONO"]))
                                                  , helper.CreateParameter("INQTY"     , Convert.ToString(drRow["INQTY"]))
                                                  , helper.CreateParameter("ITEMCODE"  , Convert.ToString(drRow["ITEMCODE"]))
                                                  , helper.CreateParameter("EDITOR"    , LoginInfo.UserID)
                                                  );
                            #endregion
                            break;
                    }
                    if (helper.RSCODE != "S") 
                    { 
                        // 1번째 방법
                        helper.Rollback();
                        ShowDialog(helper.RSMSG);
                        return;
                        // 2번째 방법
                        //throw new Exception(helper.RSMSG); 
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
