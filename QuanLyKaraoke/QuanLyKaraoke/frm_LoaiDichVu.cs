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
    public partial class frm_LoaiDichVu : DevExpress.XtraEditors.XtraForm
    {
        QLKaraoke kara = new QLKaraoke();
        public frm_LoaiDichVu()
        {
            InitializeComponent();
        }

        private void frm_LoaiDichVu_Load(object sender, EventArgs e)
        {
            loadGvLoaiDV();
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtID.Enabled = false;
        }
        private void loadGvLoaiDV()
        {
            gcLoaiDichVu.DataSource = kara.loadLoaiDV();
        }

        private void gvLoaiDichVu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gvLoaiDichVu.GetRowCellValue(e.FocusedRowHandle, "ID").ToString();
            txtLoaiDV.Text = gvLoaiDichVu.GetRowCellValue(e.FocusedRowHandle, "TenLoaiDV").ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtLoaiDV.Clear();
            txtLoaiDV.Focus();
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            //int idmoi = kara.layIDLoaiDV() + 1;
            txtID.Text = "";
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (btnSua.Enabled == false)
            {
                if ( string.IsNullOrEmpty(txtLoaiDV.Text.ToString()))
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin");
                }
                else
                {
                   
                        kara.themLoaiDV( txtLoaiDV.Text.ToString());
                        MessageBox.Show("Thêm thành công");
                        loadGvLoaiDV();
                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        btnLuu.Enabled = false;
                        btnThem.Enabled = true;
                   
                }
            }
            else
            {
                if ( string.IsNullOrEmpty(txtLoaiDV.Text.ToString()))
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin");
                }
                else
                {
                    int id = int.Parse(txtID.Text.ToString());
                    if (kara.kiemTraKhoaChinhLoaiDV(id) == false)
                    {
                        MessageBox.Show("Không có loại dịch vụ cần sửa");
                    }
                    else
                    {
                        kara.suaLoaiDV(id, txtLoaiDV.Text.ToString());
                        MessageBox.Show("Sửa thành công");
                        loadGvLoaiDV();
                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        btnLuu.Enabled = false;
                        btnThem.Enabled = true;
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtLoaiDV.Focus();
            btnLuu.Enabled = true;
            btnThem.Enabled = false;

            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text.ToString());
            if (kara.kiemTraKhoaChinhLoaiDV(id) == true)
            {
                if (kara.kiemTraLoaiDVTrongDV(id) == true)
                {
                    MessageBox.Show("Bạn cần phải xóa những dịch vụ của loại dịch vụ này trước!!!");

                }
                else
                {
                    kara.xoaLoaiDV(id);
                    loadGvLoaiDV();
                    btnXoa.Enabled = false;
                    btnSua.Enabled = false;
                    btnLuu.Enabled = false;
                    btnThem.Enabled = true;
                    MessageBox.Show("Xóa thành công");
                }
            }
            else
            {
                MessageBox.Show("Không có loại dịch vụ cần xóa");
            }
        }
    }
}