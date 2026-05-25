using BCrypt.Net;
using LibraryManagement.DAL.Repositories;
using LibraryManagement.Models;

namespace LibraryManagement.BLL
{
    public class AuthBLL
    {
        private readonly TaiKhoanRepository _repo = new();

        public TaiKhoan? Login(string tenDangNhap, string matKhau)
        {
            var tk = _repo.GetByUsername(tenDangNhap);
            if (tk == null) return null;

            // Verify BCrypt hash
            bool isValid = BCrypt.Verify(matKhau, tk.MatKhauHash);
            return isValid ? tk : null;
        }

        public string HashPassword(string matKhau)
        {
            return BCrypt.HashPassword(matKhau, workFactor: 11);
        }
    }
}
