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
using System.Globalization;
namespace QuanLyKaraoke
{
    public partial class frm_Main : DevExpress.XtraEditors.XtraForm
    {
        QLKaraoke kara = new QLKaraoke();
        int idphongtrong;
        int idphongconguoi;
        int IDDICHVU;
        DatPhong datphong = new DatPhong();
        DateTime giovao;
        DateTime giora;
        NguoiDung nguoidung;
        string username;
        public frm_Main()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
           QuanLy frm = new QuanLy();
           
            frm.Show();
        }
       

        public frm_Main(string user):this()
        {
            username = user;
        }
        private void loadCboPhongTrong()
        {
            cboPhongTrong.DataSource = datphong.loadPhongTrong();
            cboPhongTrong.DisplayMember = "TenPhong";
            cboPhongTrong.ValueMember = "ID";
        }
        private void loadCboLoaiPhong()
        {
            cboLoaiPhong.DataSource = kara.loadCboLoaiPhong();
            cboLoaiPhong.ValueMember = "ID";
            cboLoaiPhong.DisplayMember = "TenLoai";
             nguoidung = datphong.layNguoiDung();
        }
        private void frm_Main_Load(object sender, EventArgs e)
        {
            loadCboPhongTrong();
            loadPhongTrong();
            loadPhongCoNguoi();
            loadCboLoaiPhong();
            loadCboLoaiDV();
            loadCboDV();
            cboLoaiDV.SelectedIndex = 0;
            cboDichVu.SelectedIndex = 0;
            datphong.capNhatTrangThaiNguoiDung(username, true);
            hienThi();
           
        }
        private void hienThi()
        {
            if (kara.phanQuyen(username) == true)
                toolStripLabel1.Visible = true;
            else
                toolStripLabel1.Visible = false;
        }
        private void loadCTHD(int idhoadon)
        {
            dgvDichVu.DataSource = datphong.loadCTHDTheoHD(idhoadon);
        }
        private void loadCboLoaiDV()
        {
            cboLoaiDV.DataSource = kara.loadCboLoaiDV();
            cboLoaiDV.ValueMember = "ID";
            cboLoaiDV.DisplayMember = "TenLoaiDV";
        }
        private void loadCboDV()
        {
            cboDichVu.DataSource = datphong.loadDV();
            cboDichVu.ValueMember = "ID";
            cboDichVu.DisplayMember = "TenDichVu";
        }
        private void loadPhongTrong()
        {
            dgvPhongTrong.DataSource = datphong.loadPhongTrong();
        }
        private void loadPhongCoNguoi()
        {
            dgvCoNguoi.DataSource = datphong.loadPhongCoNguoi();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            if (idphongtrong == 0)
            {
                MessageBox.Show("Bạn chưa chọn phòng");
                return;
            }

            try
            {
                datphong.capNhatTrangThaiPhong(idphongtrong, "Có người");
                loadPhongTrong();
                loadPhongCoNguoi();
                giovao = DateTime.Now;

                int idnhanvien = datphong.layIDNhanVien(username);
                DateTime ngaylap = DateTime.Now;
                try
                {
                    datphong.themHoaDon(idnhanvien, idphongtrong, ngaylap, giovao);
                    MessageBox.Show("Thêm thành công");
                    loadCboPhongTrong();
                }
                catch
                {
                    MessageBox.Show("Thêm thất bại");
                }

            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn phòng");
            }
        }

        private void dgvPhongTrong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            idphongtrong = int.Parse(dgvPhongTrong.Rows[dong].Cells[0].Value.ToString());
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (idphongconguoi == 0)
            {
                MessageBox.Show("Bạn chưa chọn phòng");
                return;
            }

            try
            {
                datphong.capNhatTrangThaiPhong(idphongconguoi, "Trống");
                loadPhongCoNguoi();
                loadPhongTrong();
                giora = DateTime.Now;
                int idhoadon = datphong.layIDHoaDon(idphongconguoi);
                string str = datphong.layGioVaoTheoHD(idhoadon);
                DateTime timevao = DateTime.Parse(str);
                TimeSpan timeofdayvao = timevao.TimeOfDay;

                DateTime timera = DateTime.Now;
                TimeSpan timeofdayra = timera.TimeOfDay;


                int hourvao = timeofdayvao.Hours;
                int hourra = timeofdayra.Hours;
                int minvao = timevao.Minute;
                int minra = timera.Minute;

                int hour = 0;
                int min = 0;
                if (minra >= minvao)
                {
                    hour = hourra - hourvao;
                    min = minra - minvao;

                }
                else
                {
                    hour = hourra - hourvao - 1;
                    min = 60 - minvao + minra;
                }
                float giaphong = datphong.layGiaPhong(idphongconguoi);
                double tienphong = 0;
                tienphong = Math.Round((giaphong / 60.0) * (hour * 60 + min), 0);
                double tongtien = tienphong + float.Parse(txtTienDV.Text.ToString());
                datphong.capNhatHoaDon(idhoadon, giora, hour + " giờ " + min + " phút", float.Parse(tienphong.ToString()), float.Parse(tongtien.ToString()));
                MessageBox.Show("Thanh toán thành công");
                loadCTHD(0);
                loadCboPhongTrong();
                    frm_HoaDon frm = new frm_HoaDon(idhoadon);
                    frm.Show();
               

            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn phòng");
            }
        }

        private void dgvCoNguoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            idphongconguoi = int.Parse(dgvCoNguoi.Rows[dong].Cells[0].Value.ToString());
            loadCTHD(datphong.layIDHoaDon(idphongconguoi));
            txtTienDV.Text = datphong.tinhTongTienDVTheoHD(datphong.layIDHoaDon(idphongconguoi)).ToString();
            txtGioVao.Text = datphong.layGioVaoTheoHD(datphong.layIDHoaDon(idphongconguoi)).ToString();
            btnDoiPhong.Enabled = true;
        }

        private void cboLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            Int32.TryParse(cboLoaiPhong.SelectedValue.ToString(), out id);
            dgvPhongTrong.DataSource = datphong.locPhongTrongTheoLoai(id);
        }

        private void cboLoaiDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            Int32.TryParse(cboLoaiDV.SelectedValue.ToString(), out id);
            cboDichVu.DataSource = datphong.locDVTheoLoai(id);
        }

        private void cboDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            Int32.TryParse(cboDichVu.SelectedValue.ToString(), out id);

            DichVu dichvu = datphong.layGiaDV(id);
            if (dichvu != null)
                txtDonGia.Text = dichvu.DonGia.ToString();
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
            else
            {

                datphong.dangXuat(username);
        //        MessageBox.Show(nguoidung.UserName + "-" + nguoidung.TrangThai + "");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idhoadon = datphong.layIDHoaDon(idphongconguoi);
            //string str = datphong.layGioVaoTheoHD(idhoadon);
            //DateTime timevao = DateTime.Parse(str);
            //TimeSpan timeofdayvao = timevao.TimeOfDay;

            //DateTime timera = DateTime.Now;
            //TimeSpan timeofdayra = timera.TimeOfDay;


            //int hourvao = timeofdayvao.Hours;
            //int hourra = timeofdayra.Hours;
            //int minvao = timevao.Minute;
            //int minra = timera.Minute;
           
            //int hour=0;
            //int min=0;
            //if(minra>=minvao)
            //{
            //    hour = hourra - hourvao;
            //    min = minra - minvao;
                
            //}
            //else
            //{
            //    hour = hourra - hourvao - 1;
            //    min = 60 - minvao + minra;
            //}
            //float giaphong = datphong.layGiaPhong(idphongconguoi);
            //double tienphong = 0;
            //tienphong =Math.Round( (giaphong / 60.0) * (hour * 60 + min),0);
            //double tongtien = tienphong + float.Parse(txtTienDV.Text.ToString());
            //MessageBox.Show(tongtien+"");
            frm_HoaDon frm = new frm_HoaDon(idhoadon);
            frm.Show();
            
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            if(idphongconguoi==0)
            {
                MessageBox.Show("Bạn chưa chọn phòng cần thêm dịch vụ");
            }
            else
            {
                try
                {
                   try
                   {    
                       int iddichvu;
                       Int32.TryParse(cboDichVu.SelectedValue.ToString(), out iddichvu);
                       try
                       {
                           int soluong = int.Parse(txtSoLuong.Value.ToString());
                           if(soluong<1)
                           {
                               MessageBox.Show("Bạn chọn số lượng không hợp lệ");
                               return;
                           }
                           float dongia = float.Parse(txtDonGia.Text.ToString());
                           float thanhtien = soluong * dongia;
                           int idhoadon = datphong.layIDHoaDon(idphongconguoi);
                           if (datphong.kiemTraDVTrongCTHD(idhoadon, iddichvu) == false)
                           {
                               datphong.themCTHD(idhoadon, iddichvu, soluong, dongia, thanhtien);
                               MessageBox.Show("Thêm thành công");
                               loadCTHD(idhoadon);
                               txtTienDV.Text = datphong.tinhTongTienDVTheoHD(idhoadon).ToString();
                           }
                           else
                           {
                               datphong.capNhatSoLuong(idhoadon, iddichvu, soluong, thanhtien);
                               MessageBox.Show("Cập nhật thành công");
                               loadCTHD(idhoadon);
                               txtTienDV.Text = datphong.tinhTongTienDVTheoHD(idhoadon).ToString();
                           }
                           
                       }
                       catch
                       {
                           MessageBox.Show("Bạn chọn số lượng không hợp lệ");
                       }
                   }
                    catch
                   {
                       MessageBox.Show("Bạn chưa chọn dịch vụ cần thêm");
                   }
                }
                catch
                {
                    MessageBox.Show("Bạn chưa chọn phòng cần thêm dịch vụ");
                }
            }
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnXoa.Enabled = true;
            int dong = e.RowIndex;
            try
            {
                IDDICHVU = int.Parse(dgvDichVu.Rows[dong].Cells[0].Value.ToString());
            }
            catch
            {

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            if(idphongconguoi==0)
            {
                MessageBox.Show("Bạn chưa chọn phòng cần xóa dịch vụ");
            }
            else
            {
                try
                {
                    if(IDDICHVU==0)
                    {
                        MessageBox.Show("Bạn chưa chọn dịch vụ cần xóa");
                        return;
                    }
                    int idhoadon = datphong.layIDHoaDon(idphongconguoi);
                    DialogResult r = MessageBox.Show("Bạn có muốn xóa dịch vụ này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.No)
                    {
                        return;
                    }
                    datphong.xoaDV(idhoadon, IDDICHVU);
                    loadCTHD(idhoadon);
                    txtTienDV.Text = datphong.tinhTongTienDVTheoHD(idhoadon).ToString();

                }
                catch
                {
                    MessageBox.Show("Bạn chưa chọn phòng");
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frm_ChinhSuaTaiKhoan frm = new frm_ChinhSuaTaiKhoan(username);
            frm.Show();
        }

        private void btnDoiPhong_Click(object sender, EventArgs e)
        {
            int iddoiphong;
            Int32.TryParse(cboPhongTrong.SelectedValue.ToString(), out iddoiphong);
            if(cboPhongTrong.SelectedIndex==-1)
            {
                MessageBox.Show("Bạn chưa chọn phòng cần đổi");
                return;
            }
            if(idphongconguoi==0)
            {
                MessageBox.Show("Bạn chưa chọn phòng cần đổi");
                return;
            }
            DialogResult r = MessageBox.Show("Bạn có muốn đổi phòng không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                return;
            int idhoadon = datphong.layIDHoaDon(idphongconguoi);

            datphong.doiphong(idhoadon, iddoiphong);
            datphong.capNhatTrangThaiPhong(iddoiphong, "Có người");
            datphong.capNhatTrangThaiPhong(idphongconguoi, "Trống");
            loadPhongCoNguoi();
            loadPhongTrong();
            MessageBox.Show("Đổi phòng thành công");
            btnDoiPhong.Enabled = false;
            loadCboPhongTrong();
        }
        
        
    }
}