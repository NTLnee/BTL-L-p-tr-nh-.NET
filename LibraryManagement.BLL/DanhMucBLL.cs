using LibraryManagement.DAL.Repositories;
using LibraryManagement.Models;

namespace LibraryManagement.BLL
{
    public class DanhMucBLL
    {
        private readonly DanhMucRepository _repo = new();

        public IEnumerable<DanhMuc> GetAll() => _repo.GetAll();
        public IEnumerable<DanhMuc> GetByLoai(string loai) => _repo.GetByLoai(loai);
        public void Add(DanhMuc dm) => _repo.Add(dm);
        public void Update(DanhMuc dm) => _repo.Update(dm);
        public void Delete(string id) => _repo.Delete(id);
    }
}
