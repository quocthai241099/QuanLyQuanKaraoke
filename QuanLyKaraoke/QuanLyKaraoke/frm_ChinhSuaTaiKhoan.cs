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
    public partial class frm_ChinhSuaTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        QLKaraoke kara = new QLKaraoke();
        DatPhong datphong = new DatPhong();
        string user;
        public frm_ChinhSuaTaiKhoan()
        {
            InitializeComponent();
        }

        private void frm_ChinhSuaTaiKhoan_Load(object sender, EventArgs e)
        {
            load();
        }
        public frm_ChinhSuaTaiKhoan(string username):this()
        {
            user = username;
        }
        public void load()
        {
            int idnhanvien = datphong.layIDNhanVien(user);
            txtID.Text = idnhanvien.ToString();
            txtUser.Text = user;
            
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtMatKhau.Text.ToString())||string.IsNullOrEmpty(txtMatKhauMoi.Text.ToString())||string.IsNullOrEmpty(txtNhapLai.Text.ToString()))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin");
                return;
            }
           if(kara.kiemTraMatKhau(user,txtMatKhau.Text.ToString())==true)
           {
               if(txtMatKhauMoi.Text.ToString().Equals(txtNhapLai.Text.ToString()))
               {
                   kara.doimatkhau(user, txtMatKhauMoi.Text.ToString());
                   MessageBox.Show("Thay đổi mật khẩu thành công");
                  
               }
               else
               {
                   MessageBox.Show("Nhập lại mật khẩu sai");
               }
           }
           else
           {
               MessageBox.Show("Mật khẩu cũ không đúng");
           }
        }
    }
}