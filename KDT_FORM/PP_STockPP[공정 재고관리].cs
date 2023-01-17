#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_StockPP
//   Form Name    : 공정 재고 관리 및 원자재 출고 취소/환입
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
using DC00_PuMan;

using DC00_assm;
using DC00_WinForm;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
#endregion

namespace KDT_Form
{
    public partial class PP_StockPP : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataTable rtnDtTemp        = new DataTable(); // 
        UltraGridUtil _GridUtil    = new UltraGridUtil();  //그리드 객체 생성
        string plantCode           = LoginInfo.PlantCode;

        #endregion


        #region < CONSTRUCTOR >
        public PP_StockPP()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void PP_StockPP_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1 );
            _GridUtil.InitColumnUltraGrid(grid1, "CHK",            "원자재출고취소",   GridColDataType_emu.CheckBox,    80,  Infragistics.Win.HAlign.Left,    true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",      "공장",             GridColDataType_emu.VarChar,    120,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",       "품목",             GridColDataType_emu.VarChar,    140,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",       "품목명",           GridColDataType_emu.VarChar,    140,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE",       "품목구분",         GridColDataType_emu.VarChar,    120,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO",          "LOTNO",            GridColDataType_emu.VarChar,    120,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE",         "입고창고",         GridColDataType_emu.VarChar,    120,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY",       "재고수량",         GridColDataType_emu.Double,     100,  Infragistics.Win.HAlign.Right,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",       "단위",             GridColDataType_emu.VarChar,    100,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = Common.StandardCODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp );
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp );

            rtnDtTemp = Common.StandardCODE("UNITCODE");     //단위
            UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp );

            rtnDtTemp = Common.StandardCODE("WHCODE");     //입고 창고
            UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp );

            rtnDtTemp = Common.StandardCODE("ITEMTYPE");     //품목 구분
            Common.FillComboboxMaster(this.cboItemType, rtnDtTemp );
            UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMTYPE", rtnDtTemp);

            #endregion

            #region ▶ POP-UP ◀
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "ITEM_MASTER"  );
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
                string sItemType   = Convert.ToString(cboItemType.Value);
                string sLotNo      = Convert.ToString(txtLotNo.Text);
                string sItemCode   = Convert.ToString(txtItemCode_H.Text);

                rtnDtTemp = helper.FillTable("PP_StockPP_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE",   sPlantCode )
                                    , helper.CreateParameter("ITEMTYPE",    sItemType  )
                                    , helper.CreateParameter("LOTNO",       sLotNo     )
                                    , helper.CreateParameter("ITEMCODE",    sItemCode  )
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
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {   
           
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
             DataTable dt = new DataTable();

            dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", false);

            try
            {
                //base.DoSave();

                if (this.ShowDialog("원자재 생산 출고 취소를 하시겠습니까 ? ") == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                for (int i = 0; i < dt.Rows.Count; i++ )
                {
                    if (Convert.ToString(dt.Rows[i]["CHK"]) == "0") continue;
                    if (Convert.ToString(dt.Rows[i]["ITEMTYPE"]) != "ROH")
                    {
                        ShowDialog("원자재가 아닌 LOT 는 원자재 출고 취소/환입  할 수 없습니다.", DialogForm.DialogType.OK);
                        helper.Rollback();
                        return;
                    }

                    helper.ExecuteNoneQuery("07PP_StockPP_U1"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("PLANTCODE",      Convert.ToString(dt.Rows[i]["PLANTCODE"]) )
                                            , helper.CreateParameter("LOTNO",          Convert.ToString(dt.Rows[i]["LOTNO"]) )
                                            , helper.CreateParameter("ITEMCODE",       Convert.ToString(dt.Rows[i]["ITEMCODE"]) )
                                            , helper.CreateParameter("QTY",            Convert.ToString(dt.Rows[i]["STOCKQTY"]) )
                                            , helper.CreateParameter("UNITCODE",       Convert.ToString(dt.Rows[i]["UnitCode"]) )
                                            , helper.CreateParameter("WORKERID",       this.WorkerID ));

                    if (helper.RSCODE == "E")
                    {
                        this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                        helper.Rollback();
                        return;
                    }
                }

                helper.Commit();
                this.ShowDialog("데이터가 저장 되었습니다.", DialogForm.DialogType.OK);
                this.ClosePrgForm();
                DoInquire();
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
        #endregion

    }
}




