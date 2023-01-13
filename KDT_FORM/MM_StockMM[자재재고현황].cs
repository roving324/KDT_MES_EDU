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
//   Form ID      : MM_StockMM
//   Form Name    : 자재 재고 현황
//   Name Space   : KDT_Form
//   Created Date : 2023-01-04
//   Made By      : HJY
//   Description  : 자재 재고 현황
// *---------------------------------------------------------------------------------------------*
#endregion

namespace KDT_Form
{
    public partial class MM_StockMM : DC00_WinForm.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        UltraGridUtil GridUtill = new UltraGridUtil(); // 그리드를 셋팅하는 클래스.
        public MM_StockMM()
        {
            InitializeComponent();
        }
        #endregion

        #region < EVENT AREA >
        private void MM_StockMM_Load(object sender, EventArgs e)
        {
            // 1. 그리드 셋팅.
            GridUtill.InitializeGrid(grid1); // 그리드 초기화.
            GridUtill.InitColumnUltraGrid(grid1, "PLANTCODE", "공장"    , GridColDataType_emu.VarChar   , 150, HAlign.Left  , true, false);
                                                                                                        
            // 구매자재 발주                                                                            
            GridUtill.InitColumnUltraGrid(grid1, "ITEMCODE" , "품목"    , GridColDataType_emu.VarChar   , 200, HAlign.Left  , true, false);
            GridUtill.InitColumnUltraGrid(grid1, "ITEMNAME" , "품목명"  , GridColDataType_emu.VarChar   , 120, HAlign.Left  , true, false);
            GridUtill.InitColumnUltraGrid(grid1, "MARLOTNO" , "LOT번호" , GridColDataType_emu.VarChar   , 200, HAlign.Center, true, false);
            GridUtill.InitColumnUltraGrid(grid1, "WHCODE"   , "창고"    , GridColDataType_emu.VarChar   , 150, HAlign.Left  , true, false);
            GridUtill.InitColumnUltraGrid(grid1, "STOCKQTY" , "재고수량", GridColDataType_emu.Double    ,  80, HAlign.Right , true, false);
            GridUtill.InitColumnUltraGrid(grid1, "UNITCODE" , "단위"    , GridColDataType_emu.VarChar   ,  60, HAlign.Left  , true, false);
            GridUtill.InitColumnUltraGrid(grid1, "CUSTCODE" , "거래처"  , GridColDataType_emu.VarChar   ,  80, HAlign.Left  , true, false);
            GridUtill.InitColumnUltraGrid(grid1, "CUSTNAME" , "거래처명", GridColDataType_emu.VarChar   , 150, HAlign.Left  , true, false);

            // 구매자재 입고                                

            GridUtill.InitColumnUltraGrid(grid1, "INDATE"   , "입고일자", GridColDataType_emu.VarChar   , 100, HAlign.Left  , true, false);
            GridUtill.InitColumnUltraGrid(grid1, "MAKER"    , "등록자"  , GridColDataType_emu.VarChar   , 100, HAlign.Left  , true, false);
            GridUtill.InitColumnUltraGrid(grid1, "MAKEDATE" , "등록일시", GridColDataType_emu.DateTime24, 150, HAlign.Left  , true, false);
            
            GridUtill.SetInitUltraGridBind(grid1); // 그리드 데이터 바인딩 초기화

            // 2. 콤보박스 셋팅.
            DataTable dtTemp = new DataTable();  // 콤보박스 셋팅 할 데이터를 받아올 자료형

            // 공장
            dtTemp = Common.StandardCODE("PLANTCODE");                   // 공통기준정보 PLANTCODE 데이터 가져오기.
            Common.FillComboboxMaster(cboPlantCode, dtTemp);             // 콤보박스 컨트롤에 셋팅.
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtTemp); //그리드에 콤보박스 셋팅.

            // 창고
            dtTemp = Common.StandardCODE("WHCODE");
            UltraGridUtil.SetComboUltraGrid(grid1, "WHCODE", dtTemp);

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
                string sPlantCode = Convert.ToString(cboPlantCode.Value); // 공장
                string sItemCode  = Convert.ToString(cboItemCode.Value);  // 품목코드
                string sMATLOTNO = txtLotNo.Text;                         // LotNo 번호

                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("07MM_StockMM_S1", CommandType.StoredProcedure
                                          , helper.CreateParameter("PlantCode", sPlantCode)
                                          , helper.CreateParameter("ITEMCODE" , sItemCode)
                                          , helper.CreateParameter("MATLOTNO", sMATLOTNO)
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
        #endregion
    }
}
