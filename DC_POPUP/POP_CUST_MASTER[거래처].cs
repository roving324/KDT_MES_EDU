using System;  
using System.Data;
using System.Windows.Forms;
using Infragistics.Win;

using DC00_assm;
using DC00_PuMan;


namespace DC_POPUP
{
    public partial class POP_CUST_MASTER : DC00_WinForm.BasePopupForm
    {
        string[] argument;

        #region [ 선언자 ]
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();

        //비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();

        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();
        #endregion

        public POP_CUST_MASTER(string[] param)
        {
            InitializeComponent();

            argument = new string[param.Length];

            Common _Common = new Common();

            DataTable rtnDtTemp = _Common.Standard_CODE("CUSTTYPE");  //사업장
            Common.FillComboboxMaster(this.cboCustType_H, rtnDtTemp);

            rtnDtTemp = _Common.Standard_CODE("USEFLAG");  //사업장
            Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp);

            for (int i = 0; i < param.Length; i++)
            {
                argument[i] = param[i];

                #region [거래선코드 및 명 Parameter Show]
                switch (i)
                {
                    case 0:
                        txtCustCode.Text = argument[0].ToUpper(); //거래처코드
                        break;
                    case 1:
                        txtCustName.Text = argument[1].ToUpper(); //거래처명
                        break;
                    case 2:
                        cboCustType_H.Text = argument[2] == "" ? "ALL" : argument[2];
                        break;
                    case 3:
                        cboUseFlag_H.Text = argument[3] == "" ? "ALL" : argument[3];
                        break;
                }
                #endregion
            }
        }

        private void POP_CUST_MASTER_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(this.Grid1);

            _GridUtil.InitColumnUltraGrid(Grid1, "CustType",   "구분",          GridColDataType_emu.VarChar, 90,  HAlign.Left,   true,  false );
            _GridUtil.InitColumnUltraGrid(Grid1, "CustTypeNm", "구분명",        GridColDataType_emu.VarChar, 80,  HAlign.Center, false, false );
            _GridUtil.InitColumnUltraGrid(Grid1, "CustCode",   "거래처코드",    GridColDataType_emu.VarChar, 90,  HAlign.Default, true, false );
            _GridUtil.InitColumnUltraGrid(Grid1, "CustName",   "거래처명",      GridColDataType_emu.VarChar, 200, HAlign.Default, true, false );
            _GridUtil.InitColumnUltraGrid(Grid1, "CustEName",  "업체명(영문)",  GridColDataType_emu.VarChar, 200, HAlign.Default, true, false );    

            _GridUtil.SetInitUltraGridBind(Grid1);


            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            Common _Common = new Common();
            rtnDtTemp = _Common.Standard_CODE("CUSTTYPE");  //거래처
            UltraGridUtil.SetComboUltraGrid(this.Grid1, "CustType", rtnDtTemp);


            search();
         
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            string RS_CODE   = string.Empty, RS_MSG = string.Empty;
            string sCustType = string.Empty;
            string sUseFlag  = string.Empty;
            string sCustCode = txtCustCode.Text.Trim();
            string sCustName = txtCustName.Text.Trim();

            sCustType = Convert.ToString(cboCustType_H.Value);
            sUseFlag = Convert.ToString(cboUseFlag_H.Value); 

            _DtTemp = _biz.SEL_TBM0300(sCustCode, sCustName, sCustType, sUseFlag);

            Grid1.DataSource = _DtTemp;
            Grid1.DataBind();
        }
        private void Grid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            DataTable TmpDt = new DataTable();
            TmpDt.Columns.Add("CustCode", typeof(string));
            TmpDt.Columns.Add("CustName", typeof(string));

            TmpDt.Rows.Add(new object[] { e.Row.Cells["CustCode"].Value, e.Row.Cells["CustName"].Value });

            this.Tag = TmpDt;
            this.Close();
        }

        private void txtCustCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                search();
            }
        }

        private void txtCustName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                search();
            }
        }


    }
}
