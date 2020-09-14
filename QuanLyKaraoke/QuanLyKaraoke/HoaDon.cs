using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL_DAL;
namespace QuanLyKaraoke
{
    public partial class HoaDon : DevExpress.XtraEditors.XtraForm
    {
        QLKaraoke kara = new QLKaraoke();
        public HoaDon()
        {
            InitializeComponent();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            gcHoaDon.DataSource = kara.loadHoaDon();
        }
    }
}