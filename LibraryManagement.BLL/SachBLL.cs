using LibraryManagement.DAL.Repositories;
using LibraryManagement.Models;

namespace LibraryManagement.BLL
{
    public class SachBLL
    {
        private readonly SachRepository _repo = new();

        public IEnumerable<Sach> GetAll() => _repo.GetAll();

        public Sach GetById(string maSach) => _repo.GetById(maSach);

        public void Add(Sach sach)
        {
            if (string.IsNullOrWhiteSpace(sach.TenSach))
                throw new Exception("Tên sách không được để trống!");
            if (sach.SoLuong < 0)
                throw new Exception("Số lượng không hợp lệ!");
            _repo.Add(sach);
        }

        public void Update(Sach sach) => _repo.Update(sach);

        public void Delete(string maSach) => _repo.Delete(maSach);

        public IEnumerable<Sach> Search(string keyword, string maDanhMuc, string trangThai)
            => _repo.Search(keyword, maDanhMuc, trangThai);
    }
}
