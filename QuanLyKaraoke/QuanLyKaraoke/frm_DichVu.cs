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
    public partial class frm_DichVu : DevExpress.XtraEditors.XtraForm
    {
        QLKaraoke kara = new QLKaraoke();
        public frm_DichVu()
        {
            InitializeComponent();
        }

        private void frm_DichVu_Load(object sender, EventArgs e)
        {
            loadDgvDV();
            loadCboLoaiDV();
            cboLoaiDV.SelectedIndex = 0;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void loadDgvDV()
        {
            dgvDichVu.DataSource = kara.loadDV();
        }
        private void loadCboLoaiDV()
        {

            cboLoaiDV.DataSource = kara.loadCboLoaiDV();
            cboLoaiDV.ValueMember = "ID";
            cboLoaiDV.DisplayMember = "TenLoaiDV";

        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            // cboMonhoc.Text = dgvDiem.Rows[dong].Cells[1].Value.ToString();
            int dong = e.RowIndex;
            txtIDDV.Text = dgvDichVu.Rows[dong].Cells[0].Value.ToString();
            txtTenDV.Text = dgvDichVu.Rows[dong].Cells[1].Value.ToString();
            txtDVT.Text = dgvDichVu.Rows[dong].Cells[2].Value.ToString();
            txtDonGia.Text = dgvDichVu.Rows[dong].Cells[3].Value.ToString();
            cboLoaiDV.Text = dgvDichVu.Rows[dong].Cells[4].Value.ToString();
        }

        private void cboLoaiDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            Int32.TryParse(cboLoaiDV.SelectedValue.ToString(), out id);
            dgvDichVu.DataSource = kara.locDichVuTheoLoai(id);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtIDDV.Text = "";
            txtTenDV.Text = "";
            txtDVT.Text = "";
            txtDonGia.Text = "";
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            cboLoaiDV.SelectedIndex = 0;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtTenDV.Focus();
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (btnSua.Enabled == false)
            {
                try
                {
                    if (string.IsNullOrEmpty(txtTenDV.Text.ToString()) ||  string.IsNullOrEmpty(txtDVT.Text.ToString()) || string.IsNullOrEmpty(txtDonGia.Text.ToString()))
                    {
                        MessageBox.Show("Bạn chưa nhập đủ thông tin");
                    }
                    else
                    {
                       
                            string tendv = txtTenDV.Text.ToString();
                            string dvt = txtDVT.Text.ToString();
                            float dongia = float.Parse(txtDonGia.Text.ToString());
                            int idloai = int.Parse(cboLoaiDV.SelectedValue.ToString());
                            kara.themDV( tendv, dvt, dongia, idloai);
                            MessageBox.Show("Thêm thành công");
                            loadDgvDV();
                            btnSua.Enabled = false;
                            btnXoa.Enabled = false;
                            btnLuu.Enabled = false;
                            btnThem.Enabled = true;
                       
                    }
                }
                catch
                {
                    MessageBox.Show("Bạn chưa chọn loại phòng");
                }
            }
            else
            {
                try
                {
                    if (string.IsNullOrEmpty(txtTenDV.Text.ToString()) || string.IsNullOrEmpty(txtDVT.Text.ToString()) || string.IsNullOrEmpty(txtDonGia.Text.ToString()))
                    {
                        MessageBox.Show("Bạn chưa nhập đủ thông tin");
                    }
                    else
                    {
                        int iddv = int.Parse(txtIDDV.Text.ToString());
                        if (kara.kiemTraKhoaChinhPhong(iddv) == false)
                        {
                            MessageBox.Show("Không có dịch vụ cần sửa");
                        }
                        else
                        {
                            string tendv = txtTenDV.Text.ToString();
                            string dvt = txtDVT.Text.ToString();
                            float dongia = float.Parse(txtDonGia.Text.ToString());
                            int idloai = int.Parse(cboLoaiDV.SelectedValue.ToString());
                            kara.suaDV(iddv, tendv, dvt, dongia, idloai);
                            MessageBox.Show("Sửa thành công");
                            btnSua.Enabled = false;
                            btnXoa.Enabled = false;
                            btnLuu.Enabled = false;
                            btnThem.Enabled = true;
                            loadDgvDV();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Bạn chưa chọn loại phòng");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtIDDV.Text.ToString());
            if (kara.kiemTraKhoaChinhDV(id) == true)
            {
                if (kara.kiemTraDVTrongCTHD(id) == true)
                {
                    MessageBox.Show("Bạn cần xóa những chi tiết hóa đơn của dịch vụ này trước");
                }
                else
                {
                    kara.xoaDV(id);
                    MessageBox.Show("Xóa thành công");
                    loadDgvDV();
                    btnThem.Enabled = true;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnLuu.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Không có dịch vụ cần xóa");
            }
        }
    }
}