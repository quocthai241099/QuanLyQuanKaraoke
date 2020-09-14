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
    public partial class frm_TaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        QLKaraoke kara = new QLKaraoke();
        public frm_TaiKhoan()
        {
            InitializeComponent();
        }

        private void frm_TaiKhoan_Load(object sender, EventArgs e)
        {
            loadDgvNguoiDung();
            loadCboNhanVien();
           
            cboNhanVien.SelectedIndex = 0;
            btnLuu.Enabled = false;
          
            btnXoa.Enabled = false;
        }
        private void loadDgvNguoiDung()
        {
            dgvNguoiDung.DataSource = kara.loadNguoiDung();
        }
        private void loadCboNhanVien()
        {
            cboNhanVien.DataSource = kara.loadCboNhanVien();
            cboNhanVien.ValueMember = "ID";
            cboNhanVien.DisplayMember = "HoTen";
        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            Int32.TryParse(cboNhanVien.SelectedValue.ToString(), out id);
            dgvNguoiDung.DataSource = kara.locNguoiDungTheoNhanVien(id);
        }

        private void dgvNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            btnXoa.Enabled = true;
            // cboMonhoc.Text = dgvDiem.Rows[dong].Cells[1].Value.ToString();
            int dong = e.RowIndex;
            txtTenDN.Text = dgvNguoiDung.Rows[dong].Cells[0].Value.ToString();
            cboNhanVien.Text = dgvNguoiDung.Rows[dong].Cells[1].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTenDN.Text = "";
            txtMatKhau.Text = "";
            txtNhapLai.Text = "";
            txtTenDN.Focus();
            btnLuu.Enabled = true;

            btnXoa.Enabled = false;
          
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTenDN.Text.ToString())||string.IsNullOrEmpty(txtMatKhau.Text.ToString())||string.IsNullOrEmpty(txtNhapLai.Text.ToString()))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin");
            }
            else
            {
                string tendn = txtTenDN.Text.ToString();
                if(kara.kiemTraKhoaChinhNguoiDung(tendn)==true)
                {
                    MessageBox.Show("Đã trùng tên đăng nhập");
                }
                else
                {
                    string matkhau = txtMatKhau.Text.ToString();
                    string nhaplai = txtNhapLai.Text.ToString();
                    int idnhanvien = int.Parse(cboNhanVien.SelectedValue.ToString());
                    bool phanquyen;
                    if (radAdmin.Checked == true)
                        phanquyen = true;
                    else
                        phanquyen = false;
                    if(matkhau==nhaplai)
                    {
                        kara.themNguoiDung(tendn, matkhau, idnhanvien,phanquyen);
                        MessageBox.Show("Thêm thành công");
                        loadDgvNguoiDung();
                     
                        btnXoa.Enabled = false;
                        btnLuu.Enabled = false;
                        btnThem.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Nhập lại mật khẩu không đúng");
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string tendn = txtTenDN.Text.ToString();
            if(kara.kiemTraKhoaChinhNguoiDung(tendn)==true)
            {
                if(kara.kiemTraNguoiDungTrongNhomNguoiDung(tendn)==true)
                {
                    MessageBox.Show("Bạn cần xóa người dùng này ra khỏi nhóm người dùng trước");
                }
                else
                {
                    kara.xoaNguoiDung(tendn);
                    MessageBox.Show("Xóa thành công");
                   loadDgvNguoiDung();
                    btnThem.Enabled = true;
                   
                    btnXoa.Enabled = false;
                    btnLuu.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Không có người dùng cần xóa");
            }
        }
    }
}