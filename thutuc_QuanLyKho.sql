

--//////////////////Hàng Hoá/////////////

--Thêm
CREATE PROC ThemHangHoa 
(    @MaHH char(10), 
     @TenHH nvarchar(50),
	  @MaNCC char(10),
	  @SoLuong int
  ) 
AS 
INSERT INTO HangHoa(maHH, tenHH, maNCC, soluong) 
VALUES(@MaHH, @TenHH, @MaNCC, @SoLuong);

--Sửa
CREATE PROC  SuaHangHoa
( 
     @MaHH char(10), 
     @TenHH nvarchar(50),
	  @MaNCC char(10),
	  @SoLuong int 
     ) 
AS 
UPDATE HangHoa 
SET tenHH = @TenHH, maNCC = @MaNCC, soluong = @SoLuong 
 WHERE maHH= @MaHH; 
   
--Xoá
CREATE PROC XoaHangHoa 
( 
     @MaHH char(10) 
) 
AS 
DELETE HangHoa 
WHERE MaHH = @MaHH; 
    


--//////////////////Nhà Cung Cấp/////////////

--Thêm
CREATE PROC ThemNCC 
(    @MaNCC char(10), 
     @TenNCC nvarchar(50),
	  @DiaChi char(10),
	  @SDT char(13),
	  @Email char(50)
  ) 
AS 
INSERT INTO NCC(maNCC, tenNCC, diaChi, SDT, email) 
VALUES(@MaNCC, @TenNCC, @DiaChi, @SDT, @Email);

--Sửa
CREATE PROC  SuaNCC
( 
     @MaNCC char(10), 
     @TenNCC nvarchar(50),
	  @DiaChi char(10),
	  @SDT char(13),
	  @Email char(50)
     ) 
AS 
UPDATE NCC 
SET tenNCC = @TenNCC, diaChi = @DiaChi, SDT = @SDT, email = @Email 
 WHERE maNCC= @MaNCC; 
   
--Xoá
CREATE PROC XoaNCC 
( 
     @MaNCC char(10) 
) 
AS 
DELETE NCC 
WHERE maNCC = @MaNCC; 


--//////////////////Phiếu Nhập/////////////

alter table Chitietnhap
alter column donGia int
--Thêm
CREATE PROC ThemPhieuNhap
(    @MaPN char(10) ,
	@NgayNhap date 
	
  ) 
AS 
INSERT INTO PhieuNhap(maPN, ngayNhap) 
VALUES(@MaPN, @NgayNhap);

drop proc ThemPhieuNhap

--Sửa
CREATE PROC  SuaPhieuNhap
( 
      @MaPN char(10) ,
	@NgayNhap date ,
	@TongTien int
     ) 
AS 
UPDATE PhieuNhap 
SET ngayNhap = @NgayNhap, tongTien = @TongTien
 WHERE maPN= @MaPN; 

 drop proc SuaPhieuNhap
   
--Xoá
CREATE PROC XoaPhieuNhap
( 
     @MaPN char(10) 
) 
AS 
DELETE PhieuNhap
WHERE maPN = @MaPN; 

-----CẬP NHẬT PHIẾU NHẬP-----
create proc LamMoiPN (@MaPN char(10))						
as
UPDATE PhieuNhap 
SET TongTien = TongTienPN
from (select maPN, Sum (donGia*soLuong ) as TongTienPN
from Chitietnhap
group by maPN ) n
where n.maPN=PhieuNhap.maPN and PhieuNhap.maPN = @MaPN

drop proc LamMoiPN

--//////////////////Chi Tiết Nhập/////////////

--Thêm
CREATE PROC ThemCTNhap
(    	
	@MaCTPN char(10),
	@MaHH char(10) ,
	@SoLuong int,
	@DonGia int
  ) 
AS 
INSERT INTO Chitietnhap(maPN, maHH, soLuong, donGia) 
VALUES( @MaCTPN, @MaHH, @SoLuong, @DonGia);

drop proc ThemCTNhap

--Sửa
CREATE PROC  SuaCTNhap
(     
	@MaCTPN char(10),
	@MaHH char(10) ,
	@SoLuong int,
	@DonGia int
     ) 
AS 
UPDATE Chitietnhap 
SET  maHH = @MaHH, soLuong = @SoLuong, donGia = @DonGia
from Chitietnhap, HangHoa
 WHERE maPN = @MaCTPN and Chitietnhap.maHH = HangHoa.maHH

 drop proc SuaCTNhap
   
--Xoá
CREATE PROC XoaCTNhap
( 
     @MaCTPN char(10) 
) 
AS 
DELETE Chitietnhap
WHERE maPN = @MaCTPN

DROP PROC XoaCTNhap



--//////////////////Phiếu Xuất/////////////

--Thêm
CREATE PROC ThemPhieuXuat
(    @MaPX char(10) ,
	@NgayXuat date 
  ) 
AS 
INSERT INTO PhieuXuat(maPX, ngayXuat) 
VALUES(@MaPX, @NgayXuat);

drop proc ThemPhieuXuat

--Sửa
CREATE PROC  SuaPhieuXuat
( 
      @MaPX char(10) ,
	@NgayXuat date ,
	@TongTien int
     ) 
AS 
UPDATE PhieuXuat 
SET ngayXuat = @NgayXuat, tongTien = @TongTien
 WHERE maPX= @MaPX; 

 drop proc SuaPhieuXuat
   
--Xoá
CREATE PROC XoaPhieuXuat
( 
     @MaPX char(10) 
) 
AS 
DELETE PhieuXuat
WHERE maPX = @MaPX; 

drop proc XoaPhieuXuat

-----CẬP NHẬT PHIẾU XUẤT-----
create proc LamMoiPX (@MaPX char(10))						
as
UPDATE PhieuXuat
SET TongTien = TongTienPX
from (select maPX, Sum (donGia*soLuong ) as TongTienPX
from Chitietxuat
group by maPX ) n
where n.maPX=PhieuXuat.maPX and PhieuXuat.maPX = @MaPX

drop proc LamMoiPX


--//////////////////Chi Tiết Xuất/////////////

--Thêm
CREATE PROC ThemCTXuat
(    
	@MaCTPX char(10),
	@MaHH char(10) ,
	@SoLuong int,
	@DonGia int
  ) 
AS 
INSERT INTO Chitietxuat(maPX, maHH, soLuong, donGia) 
VALUES( @MaCTPX, @MaHH, @SoLuong, @DonGia);

drop proc ThemCTXuat

--Sửa
CREATE PROC  SuaCTXuat
( 
	@MaCTPX char(10),
	@MaHH char(10) ,
	@SoLuong int,
	@DonGia int
     ) 
AS 
UPDATE Chitietxuat 
SET maPX = @MaCTPX, maHH = @MaHH, soLuong = @SoLuong, donGia = @DonGia
from Chitietxuat, HangHoa
 WHERE maPX= @MaCTPX and Chitietxuat.maHH= HangHoa.maHH

 drop proc SuaCTXuat
   
--Xoá
CREATE PROC XoaCTXuat
( 
     @MaCTPX char(10) 
) 
AS 
DELETE Chitietxuat
WHERE maPX = @MaCTPX; 

DROP PROC XoaCTXuat


--LỆNH UPDATE--


UPDATE PhieuNhap 
SET tongTien = TongTienPN 
from (select maPN, Sum (Chitietnhap.soLuong * Chitietnhap.donGia) as TongTienPN 
from Chitietnhap
group by maPN ) n
where n.maPN=PhieuNhap.maPN


UPDATE PhieuXuat 
SET TongTien = TongTienPX
from (select maPX, Sum (Chitietxuat.soLuong * Chitietxuat.donGia) as TongTienPX 
from Chitietxuat
group by maPX) n
where n.maPX=PhieuXuat.maPX


