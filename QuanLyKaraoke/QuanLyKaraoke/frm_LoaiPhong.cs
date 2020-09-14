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
using DevExpress.XtraGrid.Views.Grid;
namespace QuanLyKaraoke
{
    public partial class frm_LoaiPhong : DevExpress.XtraEditors.XtraForm
    {
       
        QLKaraoke kara = new QLKaraoke();
        public frm_LoaiPhong()
        {
            InitializeComponent();
        }

        private void frm_LoaiPhong_Load(object sender, EventArgs e)
        {
            loadGvLoaiPhong();
            txtID.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void loadGvLoaiPhong()
        {
            grLoaiPhong.DataSource = kara.loadGvLoaiPhong();
        }

        private void gvLoaiPhong_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            
        }

        private void gvLoaiPhong_RowCellClick(object sender, RowCellClickEventArgs e)
        {
          
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //int id = kara.layIDLoaiPhong();
          //  int idmoi = id + 1;
            txtID.Text = "";
            txtLoaiPhong.Clear();
            txtLoaiPhong.Focus();
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void gvLoaiPhong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gvLoaiPhong.GetRowCellValue(e.FocusedRowHandle, "ID").ToString();
            txtLoaiPhong.Text = gvLoaiPhong.GetRowCellValue(e.FocusedRowHandle, "TenLoai").ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
           
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           
            if(btnSua.Enabled==false)
            {
                if ( string.IsNullOrEmpty(txtLoaiPhong.Text.ToString()))
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin");
                }
                else
                {
                    
                    
                        kara.them( txtLoaiPhong.Text.ToString());
                        MessageBox.Show("Thêm thành công");
                        loadGvLoaiPhong();
                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        btnLuu.Enabled = false;
                        btnThem.Enabled = true;
                    
                }
            }
            else
            {
                if ( string.IsNullOrEmpty(txtLoaiPhong.Text.ToString()))
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin");
                }
                else
                {
                    int id = int.Parse(txtID.Text.ToString());
                    if (kara.kiemTraKhoaChinh(id) == false)
                    {
                        MessageBox.Show("Không có loại phòng cần sửa");
                    }
                    else
                    {
                        kara.sua(id, txtLoaiPhong.Text.ToString());
                        MessageBox.Show("Sửa thành công");
                        loadGvLoaiPhong();
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
            txtLoaiPhong.Focus();
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
           
            btnXoa.Enabled = false;
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
                int id = int.Parse(txtID.Text.ToString());
                if (kara.kiemTraKhoaChinh(id) == true)
                {
                    if (kara.kiemTraPhong(id) == true)
                    {
                        MessageBox.Show("Bạn cần phải xóa những phòng của loại phòng này trước!!!");

                    }
                    else
                    {
                        kara.xoa(id);
                        loadGvLoaiPhong();
                        btnXoa.Enabled = false;
                        btnSua.Enabled = false;
                        btnLuu.Enabled = false;
                        btnThem.Enabled = true;
                        MessageBox.Show("Xóa thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Không có loại phòng cần xóa");
                }
           
        }

        private void grLoaiPhong_Click(object sender, EventArgs e)
        {

        }
    }
}