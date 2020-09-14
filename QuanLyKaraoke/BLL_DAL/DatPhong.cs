using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class DatPhong
    {
        QLKaraokeDataContext datacontext = new QLKaraokeDataContext();
        public IQueryable loadPhongTrong()
        {
            var phong = from p in datacontext.Phongs where p.TrangThai == "Trống" select new { p.ID, p.TenPhong,p.SoLuong, p.TrangThai,p.GiaPhongTheoGio };
            return phong;
        }
        public IQueryable loadPhongCoNguoi()
        {
            var phong = from p in datacontext.Phongs where p.TrangThai == "Có người" select new { p.ID, p.TenPhong, p.SoLuong, p.TrangThai, p.GiaPhongTheoGio };
            return phong;
        }
        public IQueryable locPhongTrongTheoLoai(int idloai)
        {
            var phong = from p in datacontext.Phongs where p.TrangThai == "Trống" && p.IDLoaiPhong == idloai select new { p.ID, p.TenPhong, p.SoLuong, p.TrangThai, p.GiaPhongTheoGio };
            return phong;
        }
        public void capNhatTrangThaiPhong(int id, string trangthai)
        {
            var phong = (from p in datacontext.Phongs where p.ID == id select p).FirstOrDefault();
            phong.TrangThai = trangthai;
            if(phong!=null)
            {
                datacontext.SubmitChanges();
            }
        }
        public IQueryable loadDV()
        {
            var dichvu = from dv in datacontext.DichVus select dv;
            return dichvu;
        }
        public IQueryable locDVTheoLoai(int idloai)
        {
            var dichvu = from dv in datacontext.DichVus where dv.IDLoaiDichVu == idloai select dv;
            return dichvu;
        }
        public DichVu layGiaDV(int id)
        {
            var dichvu = (from dv in datacontext.DichVus where dv.ID == id select dv).FirstOrDefault();
            return dichvu;
        }
        public void capNhatTrangThaiNguoiDung(string username,bool trangthai)
        {
            var nguoidung = (from nd in datacontext.NguoiDungs where nd.UserName==username select nd).FirstOrDefault();
            nguoidung.TrangThai = trangthai;
            if (nguoidung != null)
                datacontext.SubmitChanges();
        }
       public void dangXuat(string username)
        {
            var nguoidung = (from nd in datacontext.NguoiDungs where nd.UserName == username && nd.TrangThai == true select nd).FirstOrDefault();
            nguoidung.TrangThai = false;
            if (nguoidung != null)
                datacontext.SubmitChanges();
        }
        public bool kiemTraDN()
       {
            var nguoidung = (from nd in datacontext.NguoiDungs where nd.TrangThai==true select nd).Count();
            if(nguoidung>0)
                return true;
            return false;
       }
        public NguoiDung layNguoiDung()
        {
            NguoiDung nguoidung = (from nd in datacontext.NguoiDungs where nd.TrangThai==true select nd).FirstOrDefault();
            return nguoidung;
        }
        public void themHoaDon(int idnhanvien, int idphong, DateTime ngaylap, DateTime giovao)
        {
            HoaDon hoadon = new HoaDon();
            hoadon.IDNhanVien = idnhanvien;
            hoadon.IDPhong = idphong;
            hoadon.NgayLap = ngaylap;
            hoadon.GioVao = giovao;
            hoadon.TinhTrang = false;
            datacontext.HoaDons.InsertOnSubmit(hoadon);
            datacontext.SubmitChanges();
         
        }
        public int layIDNhanVien(string username)
        {
            var nhanvien = (from nv in datacontext.NguoiDungs where nv.UserName == username select nv.IDNhanVien).FirstOrDefault();
            return int.Parse(nhanvien.ToString());
        }
        public int layIDHoaDon(int idphong)
        {
            var id = datacontext.HoaDons.Where(hd => hd.IDPhong == idphong).Max(hd => hd.ID);
            return int.Parse(id.ToString());
        }
      
        public bool kiemTraDVTrongCTHD(int id, int iddv)
        {
            var dem = (from cthd in datacontext.ChiTietHoaDons where cthd.IDDichVu==iddv && cthd.IDHoaDon==id select cthd).Count();
            if (dem > 0)
                return true;
            return false;
        }
        public void themCTHD(int idhoadon, int iddv, int soluong, float dongia, float thanhtien)
        {
            ChiTietHoaDon cthd = new ChiTietHoaDon();
            cthd.IDHoaDon = idhoadon;
            cthd.IDDichVu = iddv;
            cthd.SoLuong = soluong;
            cthd.DonGia = dongia;
            cthd.ThanhTien = thanhtien;
            datacontext.ChiTietHoaDons.InsertOnSubmit(cthd);
            datacontext.SubmitChanges();
        }
        public IQueryable loadCTHDTheoHD(int idhoadon)
        {
            var cthd = (from dv in datacontext.DichVus join ct in datacontext.ChiTietHoaDons on dv.ID equals ct.IDDichVu where ct.IDHoaDon==idhoadon select new { ct.IDDichVu,dv.TenDichVu, ct.SoLuong, ct.ThanhTien });
            return cthd;
        }
        public void capNhatSoLuong(int idhoadon, int iddv, int soluong, float thanhtien)
        {
            var cthd = (from ct in datacontext.ChiTietHoaDons where ct.IDHoaDon == idhoadon && ct.IDDichVu == iddv select ct).FirstOrDefault();
            cthd.SoLuong = soluong;
            cthd.ThanhTien = thanhtien;
            if(cthd!=null)
            {
                datacontext.SubmitChanges();
            }
        }
        public void xoaDV(int idhoadon, int iddv)
        {
            var cthd = (from ct in datacontext.ChiTietHoaDons where ct.IDHoaDon == idhoadon && ct.IDDichVu == iddv select ct).FirstOrDefault();
            if (cthd != null)
            {
                datacontext.ChiTietHoaDons.DeleteOnSubmit(cthd);
                datacontext.SubmitChanges();
            }
        }
        public float tinhTongTienDVTheoHD(int idhoadon)
        {
            var tongtien = datacontext.ChiTietHoaDons.Where(ct => ct.IDHoaDon==idhoadon).Sum(ct => ct.ThanhTien);
            if(tongtien!=null)
                return float.Parse(tongtien.ToString());
            return 0;

        }
        public string layGioVaoTheoHD(int idhd)
        {
            var giovao = (from hd in datacontext.HoaDons where hd.ID == idhd select hd.GioVao).FirstOrDefault().ToString();
            return giovao;
        }
        public float layGiaPhong(int idphong)
        {
            var giaphong = (from g in datacontext.Phongs where g.ID == idphong select g.GiaPhongTheoGio).FirstOrDefault();
            return float.Parse(giaphong.ToString());
        }
        public void capNhatHoaDon(int id,DateTime giora, string giohat, float tiengio, float tongtien)
        {
            var hoadon = (from hd in datacontext.HoaDons where hd.ID == id select hd).FirstOrDefault();
            hoadon.GioRa = giora;
            hoadon.GioHat = giohat;
            hoadon.TienGio = tiengio;
            hoadon.TongTien = tongtien;
            hoadon.TinhTrang = true;
            if (hoadon != null)
                datacontext.SubmitChanges();
        }
        public bool kiemTraHDTrongCTHD(int id)
        {
            var dem = (from hd in datacontext.ChiTietHoaDons where hd.IDHoaDon == id select hd).Count();
            if (dem > 0)
                return true;
            return false;
        }
        public void doiphong(int idhoadon, int idphong)
        {
            HoaDon hoadon = (from hd in datacontext.HoaDons where hd.ID == idhoadon select hd).FirstOrDefault();
            hoadon.IDPhong = idphong;
         
           
            if(hoadon!=null)
            {
                datacontext.SubmitChanges();
            }
        }
    }
}
