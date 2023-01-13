#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM_WorkerMaster
//   Form Name    : 작업자 마스터
//   Name Space   : KDT_Form
//   Created Date : 
//   Made By      : 
//   Description  : 기준정보(작업자마스터) 관리 화면
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DC00_assm;
using DC00_WinForm;
using DC00_PuMan;
using Infragistics.Win.UltraWinGrid;
using System.Configuration;
using Infragistics.Win;
#endregion

namespace KDT_Form
{
    public partial class BM_WorkerMaster : DC00_WinForm.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp     = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        string plantCode = LoginInfo.PlantCode;

        #endregion

        #region < CONSTRUCTOR >
        public BM_WorkerMaster()
        {
            InitializeComponent();
            
        }
        #endregion

        #region < BM_WorkerMaster_Load >
        private void BM_WorkerMaster_Load(object sender, EventArgs e)
        {
            try
            {
                #region Grid 셋팅
                _GridUtil.InitializeGrid(this.grid1); //_GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",    "공장",             GridColDataType_emu.VarChar,   130,  HAlign.Left,   true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERID",     "작업자ID",         GridColDataType_emu.VarChar,    90,  HAlign.Left,   true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME",   "작업자명",         GridColDataType_emu.VarChar,    90,  HAlign.Left,   true,  true);
                _GridUtil.InitColumnUltraGrid(grid1, "BANCODE",      "작업반",           GridColDataType_emu.VarChar,   140,  HAlign.Left,   true,  true);
                _GridUtil.InitColumnUltraGrid(grid1, "GRPID",        "그룹",             GridColDataType_emu.VarChar,   130,  HAlign.Left,   true,  true);
                _GridUtil.InitColumnUltraGrid(grid1, "DEPTCODE",     "부서",             GridColDataType_emu.VarChar,   130,  HAlign.Left,   true,  true);
                //_GridUtil.InitColumnUltraGrid(grid1, "PDALOGINFLAG", "PDA 사용유무",    GridColDataType_emu.VarChar,   130,  HAlign.Left,  false, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "SPCFLAG",      "초중종관리여부",  GridColDataType_emu.VarChar,   130,  HAlign.Left,  false, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "PATROLFLAG",   "순회검사자여부",  GridColDataType_emu.VarChar,   130,  HAlign.Left,  false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PHONENO",      "연락처",          GridColDataType_emu.HandPhone, 120,   HAlign.Left,   true,  true);
                _GridUtil.InitColumnUltraGrid(grid1, "INDATE",       "입사일",          GridColDataType_emu.VarChar,   100,   HAlign.Center, true,  true);
                _GridUtil.InitColumnUltraGrid(grid1, "OUTDATE",      "퇴사일",          GridColDataType_emu.VarChar,   100,   HAlign.Center, true,  true);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG",      "사용유무",        GridColDataType_emu.VarChar,    80,   HAlign.Left,   true,  true);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER",        "등록자",          GridColDataType_emu.VarChar,    90,   HAlign.Left,   true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",     "등록일시",        GridColDataType_emu.VarChar,   140,   HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR",       "수정자",          GridColDataType_emu.VarChar,    90,   HAlign.Left,   true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE",     "수정일시",        GridColDataType_emu.VarChar,   140,   HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.Blue;
                grid1.DisplayLayout.Bands[0].Columns["WORKERID"].Header.Appearance.ForeColor  = Color.Blue;
                #endregion

                #region < 콤보박스 세팅 >
                rtnDtTemp = Common.StandardCODE("PLANTCODE"); //사업장
                Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp);
                UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp);

                rtnDtTemp = Common.StandardCODE("BANCODE");  // 작업반
                Common.FillComboboxMaster(this.cboBanCode_H, rtnDtTemp);
                UltraGridUtil.SetComboUltraGrid(this.grid1, "BanCode", rtnDtTemp);

                rtnDtTemp = Common.StandardCODE("USEFLAG");  // 사용여부
                Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp);
                UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp);

                rtnDtTemp = Common.StandardCODE("GRPID");  // 그룹 
                UltraGridUtil.SetComboUltraGrid(this.grid1, "GRPID", rtnDtTemp);

                rtnDtTemp = Common.StandardCODE("DEPTCODE"); // 부서
                UltraGridUtil.SetComboUltraGrid(this.grid1, "DEPTCODE", rtnDtTemp);

                
                #endregion

                #region <   팝업 호출 >
                //BizTextBoxManager btbManager = new BizTextBoxManager();
                //btbManager.PopUpAdd(txtWorker_H, txtWorkerName2_H, "WORKER_MASTER", new object[] { "", "", "", "", "" });

                #endregion


                cboPlantCode_H.Value = plantCode;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, DialogForm.DialogType.OK);
                   
            }
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPLANTCODE  = DBHelper.nvlString(cboPlantCode_H.Value);
                string sBANCODE    = DBHelper.nvlString(cboBanCode_H.Value);
                string sWORKERID   = txtWorkerID_H.Text.Trim();
                string sWorkerName = txtWorkerName_H.Text.Trim();
                string sUseFlag    = DBHelper.nvlString(cboUseFlag_H.Value);

                rtnDtTemp = helper.FillTable("BM_WorkerMaster_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PLANTCODE",   sPLANTCODE )
                                                            , helper.CreateParameter("WORKERID",    sWORKERID )
                                                            , helper.CreateParameter("BANCODE",     sBANCODE )
                                                            , helper.CreateParameter("WORKERNAME",  sWorkerName )
                                                            , helper.CreateParameter("USEFLAG",     sUseFlag ));
                this.ClosePrgForm();
                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    //grid1.DataBinds(rtnDtTemp); // 그리드 내용과 데이터 테이블 내용을 바인딩(일치화 시킴), 0번째 줄 행 선택.
                    //grid1.DataBinds();
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    this.ShowDialog("R00111", DialogForm.DialogType.OK);    
                    return;
                }

                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["WORKERID"].CellActivation  = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["MAKER"].CellActivation     = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["MAKEDATE"].CellActivation  = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["EDITOR"].CellActivation    = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["EDITDATE"].CellActivation  = Activation.NoEdit; 
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            try
            {
                base.DoNew();

                this.grid1.InsertRow();

                this.grid1.ActiveRow.Cells["PLANTCODE"].Value = this.plantCode;
                this.grid1.ActiveRow.Cells["GRPID"].Value     = "SW";
                this.grid1.ActiveRow.Cells["USEFLAG"].Value   = "Y";
                this.grid1.ActiveRow.Cells["INDATE"].Value    = DateTime.Now.ToString("yyyy-MM-dd");

                grid1.ActiveRow.Cells["MAKER"].Activation    = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITOR"].Activation   = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();

            this.grid1.DeleteRow();
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper(true);

            try
            {
                // 해당 내역을 저장 하시겠습니까 ? 
                if (this.ShowDialog("C:Q00009") == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                foreach (DataRow drRow in dt.Rows)
                { 
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("BM_WorkerMaster_D1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]) )
                                                    , helper.CreateParameter("WORKERID", Convert.ToString(drRow["WORKERID"]) ));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            if (Convert.ToString(drRow["WORKERID"]) == string.Empty) throw new Exception("작업자 ID 를 입력하지 않았습니다.");
                           
                            helper.ExecuteNoneQuery("BM_WorkerMaster_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE",    Convert.ToString(drRow["PLANTCODE"]) )
                                                    , helper.CreateParameter("WORKERID",     Convert.ToString(drRow["WORKERID"]) )
                                                    , helper.CreateParameter("WORKERNAME",   Convert.ToString(drRow["WORKERNAME"]) )
                                                    , helper.CreateParameter("GRPID",        Convert.ToString(drRow["GRPID"]) )
                                                    , helper.CreateParameter("DEPTCODE",     Convert.ToString(drRow["DEPTCODE"]) )
                                                    
                                                    , helper.CreateParameter("BANCODE",      Convert.ToString(drRow["BANCODE"]) )
                                                    , helper.CreateParameter("USEFLAG",      Convert.ToString(drRow["USEFLAG"]) )
                                                    , helper.CreateParameter("PHONENO",      Convert.ToString(drRow["PHONENO"]) )
                                                    , helper.CreateParameter("INDATE",       Convert.ToString(drRow["INDATE"]) )
                                                    , helper.CreateParameter("OUTDATE",      Convert.ToString(drRow["OUTDATE"]))
                                                    , helper.CreateParameter("MAKER",        LoginInfo.UserID )
                                                    //, helper.CreateParameter("SPCFLAG",      Convert.ToString(drRow["SPCFLAG"]),      DbType.String, ParameterDirection.Input)
                                                    //, helper.CreateParameter("PATROLFLAG",      Convert.ToString(drRow["PATROLFLAG"]),      DbType.String, ParameterDirection.Input)
                                                    //, helper.CreateParameter("PDALOGINFLAG", Convert.ToString(drRow["PDALOGINFLAG"]), DbType.String, ParameterDirection.Input)
                                                    );
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            if (Convert.ToString(drRow["WORKERID"]) == string.Empty) throw new Exception("작업자 ID 를 입력하지 않았습니다.");

                            helper.ExecuteNoneQuery("BM_WorkerMaster_U1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE",    Convert.ToString(drRow["PLANTCODE"]) )
                                                    , helper.CreateParameter("WORKERID",     Convert.ToString(drRow["WORKERID"]) )
                                                    , helper.CreateParameter("WORKERNAME",   Convert.ToString(drRow["WORKERNAME"]) )
                                                    , helper.CreateParameter("GRPID",        Convert.ToString(drRow["GRPID"]),        DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DEPTCODE",     Convert.ToString(drRow["DEPTCODE"]),     DbType.String, ParameterDirection.Input)
                                                    
                                                    , helper.CreateParameter("BANCODE",      Convert.ToString(drRow["BANCODE"]),      DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("USEFLAG",      Convert.ToString(drRow["USEFLAG"]),      DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PHONENO",      Convert.ToString(drRow["PHONENO"]),      DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("INDATE",       Convert.ToString(drRow["INDATE"]),       DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("OUTDATE",      Convert.ToString(drRow["OUTDATE"]),      DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MAKER",        LoginInfo.UserID,                  DbType.String, ParameterDirection.Input)
                                                    //, helper.CreateParameter("SPCFLAG",      Convert.ToString(drRow["SPCFLAG"]),      DbType.String, ParameterDirection.Input)
                                                    //, helper.CreateParameter("PATROLFLAG",    Convert.ToString(drRow["PATROLFLAG"]), DbType.String, ParameterDirection.Input)
                                                    //, helper.CreateParameter("PDALOGINFLAG", Convert.ToString(drRow["PDALOGINFLAG"]), DbType.String, ParameterDirection.Input)
                                                    );
                            #endregion
                            break;
                    }
                    if (helper.RSCODE != "S")
                    {
                        throw new Exception($"등록 중 오류가 발생하였습니다.\r\n{helper.RSMSG}");
                    }
                }
                 
                ClosePrgForm();
                helper.Commit();
                ShowDialog("정상적으로 등록 하였습니다.");
                DoInquire();
                
                
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

        #region < EVENT AREA >
        #endregion

    }
}