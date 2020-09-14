using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKaraoke
{
    public partial class frm_HoaDon : Form
    {
        public frm_HoaDon(int idhoadon)
        {
            InitializeComponent();
            HoaDonReport rpt = new HoaDonReport();
            crystalReportViewer1.ReportSource = rpt;
            rpt.SetDatabaseLogon("sa", "sa2012", "DESKTOP-7SG3LH3\\SQLEXPRESS", "QLKaraoke");
            rpt.SetParameterValue("locHoaDon", idhoadon);
        }
       
        private void frm_HoaDon_Load(object sender, EventArgs e)
        {
            
        }
        
        
    }
}
