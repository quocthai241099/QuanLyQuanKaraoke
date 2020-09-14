using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace QuanLyKaraoke
{
    public partial class QuanLy : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public QuanLy()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemTraForm(typeof(frm_LoaiPhong));
            if (frm == null)
            {
                frm_LoaiPhong form = new frm_LoaiPhong();
                form.MdiParent = this;
                form.Show();
            }
            else
                frm.Activate();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemTraForm(typeof(frm_Phong));
            if (frm == null)
            {
                frm_Phong form = new frm_Phong();
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {

        }
        private Form kiemTraForm(Type type)
        {
            foreach (Form frm in MdiChildren)
            {
                if (frm.GetType() == type)
                {

                    return frm;
                }
            }
            return null;
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemTraForm(typeof(frm_LoaiDichVu));
            if (frm == null)
            {
                frm_LoaiDichVu form = new frm_LoaiDichVu();
                form.MdiParent = this;
                form.Show();
            }
            else
                frm.Activate();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemTraForm(typeof(frm_DichVu));
            if (frm == null)
            {
                frm_DichVu form = new frm_DichVu();
                form.MdiParent = this;
                form.Show();
            }
            else
                frm.Activate();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemTraForm(typeof(frm_NhanVien));
            if (frm == null)
            {
                frm_NhanVien form = new frm_NhanVien();
                form.MdiParent = this;
                form.Show();
            }
            else
                frm.Activate();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemTraForm(typeof(frm_TaiKhoan));
            if (frm == null)
            {
                frm_TaiKhoan form = new frm_TaiKhoan();
                form.MdiParent = this;
                form.Show();
            }
            else
                frm.Activate();
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemTraForm(typeof(HoaDon));
            if (frm == null)
            {
                HoaDon form = new HoaDon();
                form.MdiParent = this;
                form.Show();
            }
            else
                frm.Activate();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemTraForm(typeof(CTHoaDon));
            if (frm == null)
            {
                CTHoaDon form = new CTHoaDon();
                form.MdiParent = this;
                form.Show();
            }
            else
                frm.Activate();
        }
    }
}