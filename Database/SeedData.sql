USE LibraryManagement;
GO

-- Tài khoản (mật khẩu sẽ hash bằng BCrypt khi chạy app lần đầu)
-- Tạm dùng hash giả để test, sau thay bằng hash thật
INSERT INTO TaiKhoan VALUES ('TK001','admin','$2a$11$HASH_THẬT_Ở_ĐÂY','SALT','Admin');
INSERT INTO TaiKhoan VALUES ('TK002','thuthu1','$2a$11$HASH','SALT','ThuThu');
INSERT INTO TaiKhoan VALUES ('TK003','docgia1','$2a$11$HASH','SALT','DocGia');

-- Danh mục
INSERT INTO DanhMuc VALUES ('DM001',N'Khoa học','TheLoai');
INSERT INTO DanhMuc VALUES ('DM002',N'Văn học','TheLoai');
INSERT INTO DanhMuc VALUES ('DM003',N'NXB Kim Đồng','NXB');
INSERT INTO DanhMuc VALUES ('DM004',N'NXB Trẻ','NXB');

-- Sách
INSERT INTO Sach VALUES ('S001',N'Lập trình C# cơ bản','DM001',2022,5,N'CoSan');
INSERT INTO Sach VALUES ('S002',N'Truyện Kiều','DM002',2020,3,N'CoSan');
INSERT INTO Sach VALUES ('S003',N'Clean Code','DM001',2021,2,N'CoSan');

-- Độc giả
INSERT INTO DocGia VALUES ('DG001',N'Nguyễn Văn A','0901234567',
    'a@gmail.com','2024-01-01','TK003');
