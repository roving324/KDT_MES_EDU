#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM_StopListMaster
//   Form Name    : 비가동 항목
//   Name Space   : KDT_Form
//   Created Date : 2023-01-02
//   Made By      : HJY
//   Description  : 기준정보(비가동 항목) 관리 화면
// *------------------------------------
#endregion

using DC00_assm;
using DC00_Component;
using Infragistics.Win;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KDT_Form
{
    public partial class BM_StopListMaster : DC00_WinForm.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        UltraGridUtil GridUtill = new UltraGridUtil(); // 그리드를 셋팅하는 클래스.

        public BM_StopListMaster()
        {
            InitializeComponent();
        }
        #endregion

        #region < EVENT AREA >
        private void BM_StopListMaster_Load(object sender, EventArgs e)
        {
            // 1. 그리드 셋팅.

            GridUtill.InitializeGrid(grid1); // 그리드 초기화.
            GridUtill.InitColumnUltraGrid(grid1, "PLANTCODE", "공장"      , GridColDataType_emu.VarChar   , 100, HAlign.Left, true, true);
            GridUtill.InitColumnUltraGrid(grid1, "STOPNAME" , "비가동명"  , GridColDataType_emu.VarChar   , 130, HAlign.Left, true, true);
            GridUtill.InitColumnUltraGrid(grid1, "REMARK"   , "비고"      , GridColDataType_emu.VarChar   , 100, HAlign.Left, true, true);
            GridUtill.InitColumnUltraGrid(grid1, "USEFLAG"  , "사용여부"  , GridColDataType_emu.VarChar   , 100, HAlign.Left, true, true);

            GridUtill.InitColumnUltraGrid(grid1, "STOPCODE" , "비가동코드", GridColDataType_emu.VarChar   , 100, HAlign.Left, true, false);
            GridUtill.InitColumnUltraGrid(grid1, "MAKEDATE" , "등록일시"  , GridColDataType_emu.DateTime24, 150, HAlign.Left, true, false);
            GridUtill.InitColumnUltraGrid(grid1, "MAKER"    , "등록자"    , GridColDataType_emu.VarChar   , 100, HAlign.Left, true, false);
            GridUtill.InitColumnUltraGrid(grid1, "EDITDATE" , "수정일시"  , GridColDataType_emu.DateTime24, 150, HAlign.Left, true, false);
            GridUtill.InitColumnUltraGrid(grid1, "EDITOR"   , "수정자"    , GridColDataType_emu.VarChar   , 100, HAlign.Left, true, false);
            GridUtill.SetInitUltraGridBind(grid1); // 그리드 데이터 바인딩 초기화

            // 2. 콤보박스 셋팅.
            Common _Common   = new Common();    // Common 클래스 객체 생성
            DataTable dtTemp = new DataTable(); // 콤보박스 셋팅 할 데이터를 받아올 자료형

            // 공장
            dtTemp = _Common.Standard_CODE("PLANTCODE");                 // 공통기준정보 PLANTCODE 데이터 가져오기.
            Common.FillComboboxMaster(cboPlantCode, dtTemp);             // 콤보박스 컨트롤에 셋팅.
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtTemp); //그리드에 콤보박스 셋팅.

            // 사용여부
            dtTemp = _Common.Standard_CODE("USEFLAG");
            Common.FillComboboxMaster(cboUseFlag, dtTemp);
            UltraGridUtil.SetComboUltraGrid(grid1, "USEFLAG", dtTemp);  // 사용여부
            UltraGridUtil.SetComboUltraGrid(grid1, "ATSTFLAG", dtTemp); // 무사유여부
            UltraGridUtil.SetComboUltraGrid(grid1, "MOLDUSE", dtTemp);  // 금형여부
        }
        #endregion

        #region < TOOLBAR AREA >
        public override void DoNew()
        {
            // 신규행 추가.
            grid1.InsertRow();

            // 기본 값 셋팅.
            grid1.SetDefaultValue("PLANTCODE", LoginInfo.PlantCode);
            grid1.SetDefaultValue("USEFLAG"  , "Y");  // 사용여부

            //grid1.ActiveRow.Cells["MAKER"].Activation
        }

        public override void DoDelete()
        {
            grid1.DeleteRow();
        }

        public override void DoInquire()
        {
            base.DoInquire();

            // 트랜잭션을 사용하지 않을 helper
            DBHelper helper = new DBHelper(false);
            try
            {
                // 조회 조건 변수 등록 및 데이터 데입
                string sPlantCode = Convert.ToString(cboPlantCode.Value); // 공장
                string sStopCode  = txtStopCode.Text;                     // 비가동 코드
                string sStopName  = txtStopName.Text;                     // 비가동명
                string sUseFlag   = Convert.ToString(cboUseFlag.Value);   // 사용여부

                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("07BM_StopList_S1", CommandType.StoredProcedure
                                          , helper.CreateParameter("PLANTCODE", sPlantCode)
                                          , helper.CreateParameter("StopCode" , sStopCode)
                                          , helper.CreateParameter("StopName" , sStopName)
                                          , helper.CreateParameter("UseFlag"  , sUseFlag)
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

                            helper.ExecuteNoneQuery("07BM_StopList_D1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE"     , Convert.ToString(drRow["PLANTCODE"]))
                                                    , helper.CreateParameter("StopCode", Convert.ToString(drRow["StopCode"])));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("07BM_StopList_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE" , Convert.ToString(drRow["PLANTCODE"]))
                                                    , helper.CreateParameter("StopCode"  , Convert.ToString(drRow["StopCode"]))
                                                    , helper.CreateParameter("StopName"  , Convert.ToString(drRow["StopName"]))
                                                    , helper.CreateParameter("REMARK"    , Convert.ToString(drRow["REMARK"]))
                                                    , helper.CreateParameter("USEFLAG"   , Convert.ToString(drRow["USEFLAG"]))
                                                    , helper.CreateParameter("MAKER"     , LoginInfo.UserID)
                                                    );
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                              helper.ExecuteNoneQuery("07BM_StopList_U1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]))
                                                    , helper.CreateParameter("StopCode" , Convert.ToString(drRow["StopCode"]))
                                                    , helper.CreateParameter("StopName" , Convert.ToString(drRow["StopName"]))
                                                    , helper.CreateParameter("REMARK"   , Convert.ToString(drRow["REMARK"]))
                                                    , helper.CreateParameter("USEFLAG"  , Convert.ToString(drRow["USEFLAG"]))
                                                    , helper.CreateParameter("EDITOR"   , LoginInfo.UserID)
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
        #endregion
    }
}
