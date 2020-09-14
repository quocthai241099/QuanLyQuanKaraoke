using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL_DAL;
namespace QuanLyKaraoke
{
    public partial class frm_DangNhap : DevExpress.XtraEditors.XtraForm
    {
        QLKaraoke kara = new QLKaraoke();
        DatPhong datphong = new DatPhong();
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_DangNhap.Text.ToString())&&string.IsNullOrEmpty(txt_MatKhau.Text.ToString()))
            {
                MessageBox.Show("Bạn chưa nhập thông tin đăng nhập");
            }
            else
            {
                if (kara.kiemTraUser(txt_DangNhap.Text.ToString(), txt_MatKhau.Text.ToString()) == true)
                {
              
                    this.Hide();
                    frm_Main frm = new frm_Main(txt_DangNhap.Text.ToString());
                    frm.ShowDialog();
                    this.Show();                    
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                    txt_DangNhap.Focus();
                }
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
           
            this.Close();
            
        }

        private void frm_DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}
