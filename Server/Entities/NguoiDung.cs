using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Server.Services.CustomDataAnnotationService;

namespace Server.Entities
{
    public class NguoiDung
    {
        private int id;
        private string? tenDangNhap;
        private string? matKhau;
        private string? hoTen;
        private DateOnly? ngaySinh;
        private string? soDienThoai;
        private string? email;
        private string? diaChi;
        private string? hinhAnh;
        private int vaiTro;
        private DateTime created;

        public NguoiDung()
        {
        }

        public NguoiDung(int id, string? tenDangNhap, string? matKhau, string? hoTen, DateOnly? ngaySinh, string? email, string? soDienThoai, string? diaChi, string? hinhanh, int vaiTro, DateTime created)
        {
            Id = id;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            Email = email;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
            HinhAnh = hinhanh;
            VaiTro = vaiTro;
        }

        [Key]
        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "{0} không được để trống!")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "{0} phải có ít nhất {2} ký tự và nhiều nhất {1} ký tự.")]
        [RegularExpression(@"^(?=.{8,20}$)(?!\d)(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$", ErrorMessage = "{0} phải dài từ {2} đến {1} ký tự, không được bắt đầu hoặc kết thúc bằng dấu gạch dưới, không được bắt đầu bằng chữ số.")]
        public string? TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }

        [Required(ErrorMessage = "{0} không được để trống!")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "{0} phải có ít nhất {2} ký tự và nhiều nhất {1} ký tự.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,16}$", ErrorMessage = "{0} phải có tối thiểu tám và tối đa 16 ký tự, ít nhất một chữ hoa, một chữ thường, một số và một ký tự đặc biệt")]
        public string? MatKhau { get => matKhau; set => matKhau = value; }

        [Required(ErrorMessage = "{0} không được để trống!")]
        [Column(TypeName = "NVARCHAR")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} phải có ít nhất {2} ký tự và nhiều nhất {1} ký tự.")]
        public string? HoTen { get => hoTen; set => hoTen = value; }

        [Required(ErrorMessage = "{0} không được để trống!")]
        [Column(TypeName = "DATE")]
        [NgaySinhValidation]
        public DateOnly? NgaySinh {get => ngaySinh; set => ngaySinh = value;}

        [Column(TypeName = "VARCHAR")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        [StringLength(50, MinimumLength = 15, ErrorMessage = "{0} phải có ít nhất {2} ký tự và nhiều nhất {1} ký tự.")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "{0} không đúng định dạng.")]
        public string? Email {get => email; set => email = value;}

        [RegularExpression("(84|0[3|5|7|8|9])+([0-9]{8,9})\b", ErrorMessage = "{0} định dạng không hợp lệ. {0} gồm 10 - 11 chữ số.")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "{0} phải có ít nhất {2} chữ số và nhiều nhất {1} chữ số.")]
        [Column(TypeName = "VARCHAR")]
        public string? SoDienThoai { get => soDienThoai; set => soDienThoai = value; }

        [StringLength(300, ErrorMessage = "{0} không được vượt quá {1} ký tự.")]
        [Column(TypeName = "NVARCHAR")]
        public string? DiaChi { get => diaChi; set => diaChi = value; }

        [Column(TypeName = "NVARCHAR")]
        [RegularExpression(@".*\.(gif|jpg|jpeg|tiff|png|bmp)$", ErrorMessage = "{0} không đúng định dạng.")]
        public string? HinhAnh { get => hinhAnh; set => hinhAnh = value; }
        public int VaiTro { get => vaiTro; set => vaiTro = value; }
        public DateTime Created { get => created; set => created = value;}

        public override string ToString()
        {
            return $"{Id}{TenDangNhap}{MatKhau}{HoTen}{NgaySinh}{Email}{SoDienThoai}{DiaChi}{HinhAnh}{VaiTro}{Created}";
        }
    }
}