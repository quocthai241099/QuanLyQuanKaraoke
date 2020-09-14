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
    public partial class frm_Phong : DevExpress.XtraEditors.XtraForm
    {
        QLKaraoke kara = new QLKaraoke();
        public frm_Phong()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm_Phong_Load(object sender, EventArgs e)
        {
            loadGvPhong();
            loadCboLoaiPhong();
            cboLoaiPhong.SelectedIndex = 0;
            radTrong.Checked = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtIDPhong.Enabled = false;
            
        }
        private void loadGvPhong()
        {
            dgvPhong.DataSource = kara.loadGvPhong();
        }
        private void loadCboLoaiPhong()
        {
            
            cboLoaiPhong.DataSource = kara.loadCboLoaiPhong();
            cboLoaiPhong.ValueMember = "ID";
            cboLoaiPhong.DisplayMember = "TenLoai";
            
        }

        private void cboLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            Int32.TryParse(cboLoaiPhong.SelectedValue.ToString(), out id);
            dgvPhong.DataSource = kara.locPhongTheoLoai(id);
        }
        private void locTheoLoaiPhong()
        {
           

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           
         //   int idmoi = kara.layIDPhong() + 1;
            txtIDPhong.Text = "";
            txtGiaPhong.Text = "";
            txtSoLuong.Text = "";
            txtTenPhong.Text = "";
            txtTenPhong.Focus();
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            cboLoaiPhong.SelectedIndex = 0;
            
        }

        private void gvPhong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
           
        }

        private void gvPhong_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
           
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
           // cboMonhoc.Text = dgvDiem.Rows[dong].Cells[1].Value.ToString();
            int dong = e.RowIndex;
            txtIDPhong.Text = dgvPhong.Rows[dong].Cells[0].Value.ToString();
            txtTenPhong.Text = dgvPhong.Rows[dong].Cells[1].Value.ToString();
            txtSoLuong.Text = dgvPhong.Rows[dong].Cells[2].Value.ToString();
            txtGiaPhong.Text = dgvPhong.Rows[dong].Cells[4].Value.ToString();
            string trangthai = dgvPhong.Rows[dong].Cells[3].Value.ToString();
          
            if (trangthai == "Trống")
                radTrong.Checked = true;
            else
                radCoNguoi.Checked = true;
           
            cboLoaiPhong.Text = dgvPhong.Rows[dong].Cells[5].Value.ToString();
       
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(btnSua.Enabled==false)
            {
                try
                {
                    if(string.IsNullOrEmpty(txtGiaPhong.Text.ToString())||string.IsNullOrEmpty(txtSoLuong.Text.ToString())||string.IsNullOrEmpty(txtTenPhong.Text.ToString()))
                    {
                        MessageBox.Show("Bạn chưa nhập đủ thông tin");
                    }
                    else
                    {
                       
                            string tenphong = txtTenPhong.Text.ToString();
                            int soluong = int.Parse(txtSoLuong.Text.ToString());
                            float giaphong = float.Parse(txtGiaPhong.Text.ToString());
                            int idloaiphong = int.Parse(cboLoaiPhong.SelectedValue.ToString());
                            string trangthai;
                            if (radCoNguoi.Checked == true)
                                trangthai = "Có người";
                            else
                                trangthai = "Trống";
                            kara.themPhong( tenphong, soluong, trangthai, giaphong, idloaiphong);
                            MessageBox.Show("Thêm thành công");
                            loadGvPhong();
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
                    if (string.IsNullOrEmpty(txtGiaPhong.Text.ToString()) || string.IsNullOrEmpty(txtSoLuong.Text.ToString()) || string.IsNullOrEmpty(txtTenPhong.Text.ToString()))
                    {
                        MessageBox.Show("Bạn chưa nhập đủ thông tin");
                    }
                    else
                    {
                        int idphong = int.Parse(txtIDPhong.Text.ToString());
                        if (kara.kiemTraKhoaChinhPhong(idphong) == false)
                        {
                            MessageBox.Show("Không có phòng cần sửa");
                        }
                        else
                        {
                             string tenphong = txtTenPhong.Text.ToString();
                            int soluong = int.Parse(txtSoLuong.Text.ToString());
                            float giaphong = float.Parse(txtGiaPhong.Text.ToString());
                            int idloaiphong = int.Parse(cboLoaiPhong.SelectedValue.ToString());
                            string trangthai;
                            if (radCoNguoi.Checked == true)
                                trangthai = "Có người";
                            else
                                trangthai = "Trống";
                            kara.suaPhong(idphong, tenphong, soluong, trangthai, giaphong, idloaiphong);
                            MessageBox.Show("Sửa thành công");
                            btnSua.Enabled = false;
                            btnXoa.Enabled = false;
                            btnLuu.Enabled = false;
                            btnThem.Enabled = true;
                            loadGvPhong();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Bạn chưa chọn loại phòng");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
          
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtTenPhong.Focus();
          
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtIDPhong.Text.ToString());
            if(kara.kiemTraKhoaChinhPhong(id)==true)
            {
                if(kara.kiemTraPhongTrongHD(id)==true)
                {
                    MessageBox.Show("Bạn cần xóa những hóa đơn của phòng này trước");
                }
                else
                {
                    kara.xoaPhong(id);
                    MessageBox.Show("Xóa thành công");
                    loadGvPhong();
                    btnThem.Enabled = true;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnLuu.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Không có phòng cần xóa");
            }
                
        }
    }
}