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
using HopDen;
using BLL_DAL;
namespace QuanLyKaraoke
{
    public partial class frm_NhanVien : DevExpress.XtraEditors.XtraForm
    {
        XuLy hopden = new XuLy();
        QLKaraoke kara = new QLKaraoke();
        public frm_NhanVien()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtNgaySinh.Text = "";
            txtEmail.Text = "";
            txtID.Text = "";
            txtHoTen.Focus();

        }

        private void frm_NhanVien_Load(object sender, EventArgs e)
        {
            loadDgvNhanVien();
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            radNam.Checked = true;
        }
        private void loadDgvNhanVien()
        {
            gcNhanVien.DataSource = kara.loadNhanVien();
        }

        private void gvNhanVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gvNhanVien.GetRowCellValue(e.FocusedRowHandle, "ID").ToString();
            txtHoTen.Text = gvNhanVien.GetRowCellValue(e.FocusedRowHandle, "HoTen").ToString();
            txtDiaChi.Text = gvNhanVien.GetRowCellValue(e.FocusedRowHandle, "DiaChi").ToString();
            string gioitinh = gvNhanVien.GetRowCellValue(e.FocusedRowHandle, "GioiTinh").ToString();
            if (gioitinh == "Nam")
                radNam.Checked = true;
            else
                radNu.Checked = true;
            txtSDT.Text = gvNhanVien.GetRowCellValue(e.FocusedRowHandle, "SDT").ToString();
            txtNgaySinh.Text = gvNhanVien.GetRowCellValue(e.FocusedRowHandle, "NgaySinh").ToString();
            txtEmail.Text = gvNhanVien.GetRowCellValue(e.FocusedRowHandle, "Email").ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(btnSua.Enabled==false)
            {
                if(string.IsNullOrEmpty(txtHoTen.Text.ToString())||string.IsNullOrEmpty(txtDiaChi.Text.ToString())||string.IsNullOrEmpty(txtEmail.Text.ToString())||string.IsNullOrEmpty(txtNgaySinh.Text.ToString())||string.IsNullOrEmpty(txtSDT.Text.ToString()))
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin");
                }
                else
                {
                    string hoten = txtHoTen.Text.ToString();
                    string diachi = txtDiaChi.Text.ToString();
                    string gioitinh;
                    if (radNam.Checked == true)
                        gioitinh = "Nam";
                    else
                        gioitinh = "Nữ";
                    string sdt = txtSDT.Text.ToString();
                    string ngaysinh = txtNgaySinh.Text.ToString();
                    string email = txtEmail.Text.ToString();
                    if(hopden.kiemTraKTDB(hoten)==true)
                    {
                        MessageBox.Show("Họ tên không được chứa ký tự đặc biệt");
                        return;
                    }
                    if(hopden.kiemTraSDT(sdt)==false)
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ!!!\nSố điện thoại phải thuộc 1 trong các nhà mạng: Viettel, Mobifone, Vinaphone, Vietnamobile, Gmobile");
                        return;
                    }
                    if(hopden.kiemTraEmail(email)==false)
                    {
                        MessageBox.Show("Nhập email không hợp lệ");
                        return;
                    }
                    kara.themNV(hoten, diachi, gioitinh,sdt, ngaysinh, email);
                    MessageBox.Show("Thêm thành công");
                    loadDgvNhanVien();
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnLuu.Enabled = false;
                    btnThem.Enabled = true;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtHoTen.Text.ToString()) || string.IsNullOrEmpty(txtDiaChi.Text.ToString()) || string.IsNullOrEmpty(txtEmail.Text.ToString()) || string.IsNullOrEmpty(txtNgaySinh.Text.ToString()) || string.IsNullOrEmpty(txtSDT.Text.ToString()))
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin");
                }
                else
                {
                    int id = int.Parse(txtID.Text.ToString());
                    if(kara.kiemTraKhoaChinhNhanVien(id)==false)
                    {
                        MessageBox.Show("Không có nhân viên cần sửa");
                    }
                    else
                    {
                        string hoten = txtHoTen.Text.ToString();
                        string diachi = txtDiaChi.Text.ToString();
                        string gioitinh;
                        if (radNam.Checked == true)
                            gioitinh = "Nam";
                        else
                            gioitinh = "Nữ";
                        string sdt = txtSDT.Text.ToString();
                        string ngaysinh = txtNgaySinh.Text.ToString();
                        string email = txtEmail.Text.ToString();
                        if (hopden.kiemTraKTDB(hoten) == true)
                        {
                            MessageBox.Show("Họ tên không được chứa ký tự đặc biệt");
                            return;
                        }
                        if (hopden.kiemTraSDT(sdt) == false)
                        {
                            MessageBox.Show("Số điện thoại không hợp lệ!!!\nSố điện thoại phải thuộc 1 trong các nhà mạng: Viettel, Mobifone, Vinaphone, Vietnamobile, Gmobile");
                            return;
                        }
                        if (hopden.kiemTraEmail(email) == false)
                        {
                            MessageBox.Show("Nhập email không hợp lệ");
                            return;
                        }
                        kara.suaNV(id, hoten, diachi, gioitinh, sdt, ngaysinh, email);
                        MessageBox.Show("Sửa thành công");
                        loadDgvNhanVien();
                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        btnLuu.Enabled = false;
                        btnThem.Enabled = true;
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text.ToString());
            if(kara.kiemTraKhoaChinhNhanVien(id)==true)
            {
                if (kara.kiemTraNhanVienTrongTaiKhoan(id) == true)
                {
                    MessageBox.Show("Bạn cần phải xóa những tài khoản thuộc nhân viên này trước!!!");
                }
                else
                {
                    kara.xoaNV(id);
                    loadDgvNhanVien();
                    btnXoa.Enabled = false;
                    btnSua.Enabled = false;
                    btnLuu.Enabled = false;
                    btnThem.Enabled = true;
                    MessageBox.Show("Xóa thành công");
                }
            }
            else
            {
                MessageBox.Show("Không có nhân viên cần xóa");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtHoTen.Focus();
            btnLuu.Enabled = true;
            btnThem.Enabled = false;

            btnXoa.Enabled = false;
        }
    }
}