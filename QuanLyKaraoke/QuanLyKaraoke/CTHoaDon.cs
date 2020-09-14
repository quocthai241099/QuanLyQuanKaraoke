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
    public partial class CTHoaDon : DevExpress.XtraEditors.XtraForm
    {
        QLKaraoke kara = new QLKaraoke();
        public CTHoaDon()
        {
            InitializeComponent();
        }

        private void CTHoaDon_Load(object sender, EventArgs e)
        {
            cboHoaDon.DataSource = kara.loadHoaDon();
            cboHoaDon.DisplayMember = "ID";
            cboHoaDon.ValueMember = "ID";
            loadCTHD();
        }
        private void loadCTHD()
        {
            gcCTHD.DataSource = kara.loadCTHD();
        }

        private void cboHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            Int32.TryParse(cboHoaDon.SelectedValue.ToString(), out id);
            gcCTHD.DataSource = kara.locCTHD(id);
        }
    }
}