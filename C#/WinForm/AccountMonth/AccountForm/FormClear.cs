using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccountWithSQL
{
    public partial class FormClear : Form
    {
        public FormClear()
        {
            InitializeComponent();
        }
        public FormClear(DataTable dt,string userCode)
        {
            InitializeComponent();
            if (dt == null)
                return;
            Init(dt);
            gv.OptionsBehavior.Editable = false;
        }

        private void Init(DataTable dtAccount)
        {
            int cnt = dtAccount==null?0: dtAccount.Rows.Count;//总行数
            if(cnt<=0)
                return;

            dtAccount.Columns.Add("money", typeof(double));
            for (int i = 0; i < dtAccount.Rows.Count; i++)
            {
                dtAccount.Rows[i]["money"] = dtAccount.Rows[i]["moneytmp"];
            }

            dtAccount.AcceptChanges();
            DataRow[] drsX = dtAccount.Select(string.Format("name = '01'"));
            int cntX = drsX==null?0: drsX.Length;
            DataRow[] drsZ = dtAccount.Select(string.Format("name = '02'"));
            int cntZ = drsZ==null?0: drsZ.Length;
            DataRow[] drsS = dtAccount.Select(string.Format("name = '03'"));
            int cntS = drsS==null?0: drsS.Length;

            decimal dcSum = Convert.ToDecimal( dtAccount.Compute("sum(money)",""));
            decimal dcAvg = cnt==0?0:dcSum / cnt;
            decimal dcAvg3 = dcSum/3;
            dcAvg3 = Decimal.Round(dcAvg3,2);

            decimal dcSumX = Convert.ToDecimal(dtAccount.Compute("sum(money)", string.Format("name = '01'")));
            decimal dcAvgX = cntX == 0 ? 0 : dcSumX / cntX;

            decimal dcSumZ= Convert.ToDecimal(dtAccount.Compute("sum(money)", string.Format("name = '02'")));
            decimal dcAvgZ = cntZ == 0 ? 0 : dcSumZ / cntZ;

            decimal dcSumS = Convert.ToDecimal(dtAccount.Compute("sum(money)", string.Format("name = '03'")));
            decimal dcAvgS = cntS == 0 ? 0 : dcSumS / cntS;


            DataTable dtShow = new DataTable("show");
            dtShow.Columns.Add("name",typeof(string));
            dtShow.Columns.Add("sum", typeof(string));
            dtShow.Columns.Add("avg", typeof(string));
            dtShow.Columns.Add("clear", typeof(double));
            dtShow.Rows.Add("许", dcSumX, dcAvgX,dcAvgX-dcAvg3);
            dtShow.Rows.Add("张", dcSumZ, dcAvgZ, dcAvgZ - dcAvg3);
            dtShow.Rows.Add("宋", dcSumS, dcAvgS, dcAvgS - dcAvg3);
            dtShow.Rows.Add("总", dcSum, dcAvg);

            gc.DataSource = dtShow;
        }
    }
}
