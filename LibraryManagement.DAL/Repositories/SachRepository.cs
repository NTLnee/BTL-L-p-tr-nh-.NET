using Dapper;
using LibraryManagement.Models;

namespace LibraryManagement.DAL.Repositories
{
    public class SachRepository : IRepository<Sach>
    {
        public IEnumerable<Sach> GetAll()
        {
            using var db = new DatabaseContext();
            return db.Connection.Query<Sach>("SELECT * FROM Sach");
        }

        public Sach GetById(object id)
        {
            using var db = new DatabaseContext();
            return db.Connection.QueryFirstOrDefault<Sach>(
                "SELECT * FROM Sach WHERE MaSach = @MaSach",
                new { MaSach = id });
        }

        public void Add(Sach entity)
        {
            using var db = new DatabaseContext();
            db.Connection.Execute(
                "INSERT INTO Sach(MaSach,TenSach,MaDanhMuc,NamXB,SoLuong,TrangThai) " +
                "VALUES(@MaSach,@TenSach,@MaDanhMuc,@NamXB,@SoLuong,@TrangThai)",
                entity);
        }

        public void Update(Sach entity)
        {
            using var db = new DatabaseContext();
            db.Connection.Execute(
                "UPDATE Sach SET TenSach=@TenSach, MaDanhMuc=@MaDanhMuc, " +
                "NamXB=@NamXB, SoLuong=@SoLuong, TrangThai=@TrangThai " +
                "WHERE MaSach=@MaSach", entity);
        }

        public void Delete(object id)
        {
            using var db = new DatabaseContext();
            db.Connection.Execute(
                "DELETE FROM Sach WHERE MaSach=@MaSach",
                new { MaSach = id });
        }

        // Tìm kiếm nâng cao — dùng chung cho TV3 (hÀ bẠcH dƯơNg)
        public IEnumerable<Sach> Search(string keyword, string maDanhMuc, string trangThai)
        {
            using var db = new DatabaseContext();
            var sql = "SELECT * FROM Sach WHERE 1=1";
            if (!string.IsNullOrEmpty(keyword))
                sql += " AND TenSach LIKE @Keyword";
            if (!string.IsNullOrEmpty(maDanhMuc))
                sql += " AND MaDanhMuc = @MaDanhMuc";
            if (!string.IsNullOrEmpty(trangThai))
                sql += " AND TrangThai = @TrangThai";

            return db.Connection.Query<Sach>(sql, new {
                Keyword = $"%{keyword}%",
                MaDanhMuc = maDanhMuc,
                TrangThai = trangThai
            });
        }
    }
}
