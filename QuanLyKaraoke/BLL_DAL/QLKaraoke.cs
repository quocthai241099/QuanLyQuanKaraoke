using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class QLKaraoke
    {
        QLKaraokeDataContext datacontext = new QLKaraokeDataContext();
        public bool kiemTraUser(string user, string pass)
        {
            int dem = (from ng in datacontext.NguoiDungs where ng.UserName==user && ng.MatKhau==pass select ng).Count();
            if (dem > 0)
                return true;
            return false;
        }
        public IQueryable loadGvLoaiPhong()
        {
            var loaiphong = from lp in datacontext.LoaiPhongs select lp;
            return loaiphong;
        }
        public int layIDLoaiPhong()
        {
            var id = datacontext.LoaiPhongs.Max(lp => lp.ID);
            return int.Parse(id.ToString());
        }
        public bool kiemTraKhoaChinh(int id)
        {
            int dem = (from lp in datacontext.LoaiPhongs where lp.ID==id select lp).Count();
            if (dem > 0)
                return true;
            return false;
        }
        public void them( string tenloai)
        {
            LoaiPhong loaiphong = new LoaiPhong();
       
            loaiphong.TenLoai = tenloai;
            datacontext.LoaiPhongs.InsertOnSubmit(loaiphong);
            datacontext.SubmitChanges();
        }
        public void sua(int id, string tenloai)
        {
            LoaiPhong loaiphong = (from lp in datacontext.LoaiPhongs where lp.ID == id select lp).FirstOrDefault();
            loaiphong.TenLoai = tenloai;
            if(loaiphong!=null)
            {
                datacontext.SubmitChanges();
            }
        }
        public void xoa(int id)
        {
            var loaiphong = (from lp in datacontext.LoaiPhongs where lp.ID == id select lp).FirstOrDefault();
            if(loaiphong!=null)
            {
                datacontext.LoaiPhongs.DeleteOnSubmit(loaiphong);
                datacontext.SubmitChanges();
            }
        }
        public bool kiemTraPhong(int idloaiphong)
        {
            int dem = (from lp in datacontext.Phongs where lp.IDLoaiPhong == idloaiphong select lp).Count();
            if (dem > 0)
                return true;
            return false;
        }
        public IQueryable loadGvPhong()
        {
            var phong = from p in datacontext.Phongs select new { p.ID, p.TenPhong, p.SoLuong, p.TrangThai, p.GiaPhongTheoGio, p.IDLoaiPhong };
            return phong;
        }
        public IQueryable loadCboLoaiPhong()
        {
            var loaiphong = from lp in datacontext.LoaiPhongs select lp;
            return loaiphong;
        }
        public IQueryable locPhongTheoLoai(int idloaiphong)
        {
            
            var phong = from p in datacontext.Phongs where p.IDLoaiPhong==idloaiphong select new { p.ID, p.TenPhong, p.SoLuong, p.TrangThai, p.GiaPhongTheoGio, p.IDLoaiPhong };
            return phong;
        }
        public string layTenLoaiPhong(int id)
        {
            string tenphong = (from lp in datacontext.LoaiPhongs where lp.ID == id select new { lp.TenLoai }).FirstOrDefault().ToString();
            return tenphong;
        }
        public int layIDPhong()
        {
            var id = datacontext.Phongs.Max(lp => lp.ID);
            return int.Parse(id.ToString());
        }
        public bool kiemTraKhoaChinhPhong(int id)
        {
            int dem = (from p in datacontext.Phongs where p.ID == id select p).Count();
            if (dem > 0)
                return true;
            return false;
        }
        public void themPhong( string tenphong, int soluong, string trangthai, float giaphong, int idloai)
        {
            Phong phong = new Phong();
            
            phong.TenPhong = tenphong;
            phong.SoLuong = soluong;
            phong.TrangThai = trangthai;
            phong.GiaPhongTheoGio = giaphong;
            phong.IDLoaiPhong = idloai;
            datacontext.Phongs.InsertOnSubmit(phong);
            datacontext.SubmitChanges();

        }
        public void suaPhong(int idphong, string tenphong, int soluong, string trangthai, float giaphong, int idloai)
        {
            Phong phong = (from p in datacontext.Phongs where p.ID == idphong select p).FirstOrDefault();
           
            phong.TenPhong = tenphong;
            phong.SoLuong = soluong;
            phong.TrangThai = trangthai;
            phong.GiaPhongTheoGio = giaphong;
     
            if (phong != null)
            {
                datacontext.SubmitChanges();
            }
        }
        public void xoaPhong(int id)
        {
            Phong phong = (from p in datacontext.Phongs where p.ID == id select p).FirstOrDefault();
            if (phong != null)
            {
                datacontext.Phongs.DeleteOnSubmit(phong);
                datacontext.SubmitChanges();
            }
        }
        public bool kiemTraPhongTrongHD(int idphong)
        {
            var dem = (from phong in datacontext.HoaDons where phong.IDPhong == idphong select phong).Count();
            if (dem > 0)
                return true;
            return false;
        }
       public IQueryable loadLoaiDV()
        {
            var dichvu = from dv in datacontext.LoaiDichVus select dv;
            return dichvu;
        }
        public int layIDLoaiDV()
       {
           var id = datacontext.LoaiDichVus.Max(lp => lp.ID);
           return int.Parse(id.ToString());
       }
        public bool kiemTraKhoaChinhLoaiDV(int id)
        {
            var dem = (from ldv in datacontext.LoaiDichVus where ldv.ID == id select ldv).Count();
            if (dem > 0)
                return true;
            return false;
        }
        public void themLoaiDV( string tenloai)
        {
            LoaiDichVu ldv = new LoaiDichVu();
            
            ldv.TenLoaiDV = tenloai;
            datacontext.LoaiDichVus.InsertOnSubmit(ldv);
            datacontext.SubmitChanges();
        }
        public void suaLoaiDV(int id, string tenloai)
        {
            LoaiDichVu ldv = (from lp in datacontext.LoaiDichVus where lp.ID == id select lp).FirstOrDefault();
            ldv.TenLoaiDV = tenloai;
            if (ldv != null)
            {
                datacontext.SubmitChanges();
            }
        }
        public bool kiemTraLoaiDVTrongDV(int id)
        {
            var dem = (from ldv in datacontext.DichVus where ldv.IDLoaiDichVu == id select ldv).Count();
            if (dem > 0)
                return true;
            return false;
        }
        public void xoaLoaiDV(int id)
        {
            LoaiDichVu ldv = (from lp in datacontext.LoaiDichVus where lp.ID == id select lp).FirstOrDefault();
            if (ldv != null)
            {
                datacontext.LoaiDichVus.DeleteOnSubmit(ldv);
                datacontext.SubmitChanges();
            }
        }
        public IQueryable loadDV()
        {
            var dichvu = from p in datacontext.DichVus select new { p.ID, p.TenDichVu, p.DonViTinh, p.DonGia, p.IDLoaiDichVu};
            return dichvu;
        }
       
        public IQueryable loadCboLoaiDV()
        {
            var loaidv = from lp in datacontext.LoaiDichVus select lp;
            return loaidv;
        }
        public IQueryable locDichVuTheoLoai(int idloaidv)
        {

            var dv = from p in datacontext.DichVus where p.IDLoaiDichVu == idloaidv select new { p.ID, p.TenDichVu, p.DonViTinh, p.DonGia, p.IDLoaiDichVu };
            return dv;
        }
        
       
        public bool kiemTraKhoaChinhDV(int id)
        {
            int dem = (from p in datacontext.DichVus where p.ID == id select p).Count();
            if (dem > 0)
                return true;
            return false;
        }
        public void themDV( string tendv, string dvt, float dongia,  int idloai)
        {
            DichVu dv = new DichVu();
           
            dv.TenDichVu = tendv;
            dv.DonViTinh = dvt;
            dv.DonGia = dongia;
            dv.IDLoaiDichVu = idloai;
            datacontext.DichVus.InsertOnSubmit(dv);
            datacontext.SubmitChanges();

        }
        public void suaDV(int iddv, string tendv, string dvt, float dongia, int idloai)
        {
            DichVu dv = (from p in datacontext.DichVus where p.ID == iddv select p).FirstOrDefault();
            dv.TenDichVu = tendv;
            dv.DonViTinh = dvt;
            dv.DonGia = dongia;
            dv.IDLoaiDichVu = idloai;

            if (dv != null)
            {
                datacontext.SubmitChanges();
            }
        }
        public void xoaDV(int iddv)
        {
            DichVu dv = (from p in datacontext.DichVus where p.ID == iddv select p).FirstOrDefault();
            if (dv != null)
            {
                datacontext.DichVus.DeleteOnSubmit(dv);
                datacontext.SubmitChanges();
            }
        }
        public bool kiemTraDVTrongCTHD(int id)
        {
            var dem = (from dv in datacontext.ChiTietHoaDons where dv.IDDichVu == id select dv).Count();
            if (dem > 0)
                return true;
            return false;
        }
        public IQueryable loadNhanVien()
        {
            var nhanvien = from nv in datacontext.NhanViens select nv;
            return nhanvien;
        }
        public bool kiemTraKhoaChinhNhanVien(int id)
        {
            var dem = (from nv in datacontext.NhanViens where nv.ID == id select nv).Count();
            if (dem > 0)
                return true;
            return false;
        }
        public void themNV(string hoten, string diachi, string gioitinh,string sdt, string ngaysinh, string email)
        {
            NhanVien nv = new NhanVien();
            nv.HoTen = hoten;
            nv.DiaChi = diachi;
            nv.GioiTinh = gioitinh;
            nv.Email = email;
            nv.SDT = sdt;
            
            DateTime date = DateTime.ParseExact(ngaysinh, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            nv.NgaySinh = date;
            datacontext.NhanViens.InsertOnSubmit(nv);
            datacontext.SubmitChanges();
        }
        public void suaNV(int id, string hoten, string diachi, string gioitinh,string sdt, string ngaysinh, string email)
        {
            NhanVien nv = (from p in datacontext.NhanViens where p.ID == id select p).FirstOrDefault();
            nv.HoTen = hoten;
            nv.DiaChi = diachi;
            nv.GioiTinh = gioitinh;
            nv.Email = email;
            nv.SDT = sdt;
            DateTime date = DateTime.ParseExact(ngaysinh, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            nv.NgaySinh = date;
            if (nv != null)
            {
                datacontext.SubmitChanges();
            }
        }
        public void xoaNV(int id)
        {
            NhanVien nv = (from p in datacontext.NhanViens where p.ID == id select p).FirstOrDefault();
            if (nv != null)
            {
                datacontext.NhanViens.DeleteOnSubmit(nv);
                datacontext.SubmitChanges();
            }
        }
        public bool kiemTraNhanVienTrongTaiKhoan(int id)
        {
            var dem = (from nv in datacontext.NguoiDungs where nv.IDNhanVien==id select nv).Count();
            if(dem>0)
                return true;
            return false;
        }
        public IQueryable loadCboNhanVien()
        {
            var nhanvien = from nv in datacontext.NhanViens select nv;
            return nhanvien;
        }
        public IQueryable loadNguoiDung()
        {
            var nguoidung = from nd in datacontext.NguoiDungs select new { nd.UserName, nd.IDNhanVien };
            return nguoidung;
        }
        public IQueryable locNguoiDungTheoNhanVien(int idnhanvien)
        {
            var nguoidung = from nd in datacontext.NguoiDungs where nd.IDNhanVien==idnhanvien select new { nd.UserName, nd.IDNhanVien };
            return nguoidung;
        }
        public bool kiemTraKhoaChinhNguoiDung(string tendn)
        {
            var nguoidung = (from nd in datacontext.NguoiDungs where nd.UserName == tendn select nd).Count();
            if (nguoidung > 0)
                return true;
            return false;
        }
        public void themNguoiDung(string username, string matkhau, int idnhanvien, bool phanquyen)
        {
            NguoiDung nguoidung = new NguoiDung();
            nguoidung.UserName = username;
            nguoidung.MatKhau = matkhau;
            nguoidung.IDNhanVien = idnhanvien;
            nguoidung.TrangThai = false;
            nguoidung.PhanQuyen = phanquyen;
            datacontext.NguoiDungs.InsertOnSubmit(nguoidung);
            datacontext.SubmitChanges();
        }
        public bool kiemTraNguoiDungTrongNhomNguoiDung(string username)
        {
            var dem = (from nd in datacontext.NguoiDungNhomNguoiDungs where nd.UserName == username select nd).Count();
            if (dem > 0)
                return true;
            return false;
        }
        public void xoaNguoiDung(string username)
        {
            var nguoidung = (from nd in datacontext.NguoiDungs where nd.UserName == username select nd).FirstOrDefault();
            if (nguoidung != null)
            {
                datacontext.NguoiDungs.DeleteOnSubmit(nguoidung);
                datacontext.SubmitChanges();
            }
        }
        public IQueryable loadHoaDon()
        {
            var hoadon = from hd in datacontext.HoaDons select new { hd.ID, hd.IDNhanVien, hd.IDPhong, hd.NgayLap, hd.GioVao, hd.GioRa, hd.GioHat, hd.TienGio, hd.TongTien, hd.TinhTrang };
            return hoadon;
        }
        public IQueryable locCTHD(int idhoadon)
        {
            var hoadon = from hd in datacontext.ChiTietHoaDons where hd.IDHoaDon==idhoadon select new{hd.IDHoaDon,hd.IDDichVu,hd.SoLuong,hd.DonGia,hd.ThanhTien};
            return hoadon;
        }
        public IQueryable loadCTHD()
        {
            var hoadon = from hd in datacontext.ChiTietHoaDons  select new { hd.IDHoaDon, hd.IDDichVu, hd.SoLuong, hd.DonGia, hd.ThanhTien };
            return hoadon;
        }
       public bool kiemTraMatKhau(string user, string matkhau)
        {
            var dem = (from nd in datacontext.NguoiDungs where nd.UserName == user && nd.MatKhau == matkhau select nd).Count();
            if (dem > 0)
                return true;
            return false;
        }
        public void doimatkhau(string user,string matkhau)
       {
           NguoiDung nguoidung = (from nd in datacontext.NguoiDungs where nd.UserName == user select nd).FirstOrDefault();
           nguoidung.MatKhau = matkhau;
           nguoidung.TrangThai = true;
           if (nguoidung != null)
               datacontext.SubmitChanges();
       }
        public bool phanQuyen(string user)
        {
            var nguoidung = (from nd in datacontext.NguoiDungs where nd.UserName == user select nd.PhanQuyen).FirstOrDefault();
            return bool.Parse(nguoidung.ToString());
        }
    }
}
