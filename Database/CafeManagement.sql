create database DB_CafeManagement;
go
use DB_CafeManagement
go

-- Thuc An
-- Ban
-- Danh Muc Thuc An
-- Tai Khoan
-- Hoa Don
-- Thong Tin Hoa Don
--------------------------------------------------------------------------
--Create Table
--Ban
create table Ban
(
	id int identity primary key,
	name nvarchar(100) not null default N'Chưa đặt tên',
	status nvarchar(100) not null default N'Trống'  -- Trống chưa có người
)
go

-- TAI KHOAN
create table TaiKhoan
(
	UserName nvarchar(100) primary key,
	DisplayName nvarchar(100) not null default N'Chưa đặt tên',
	PassWord nvarchar(100) not null default 0,
	Type int not null -- 1 Quản lý, 0 Nhân viên
)
go

-- DANH MUC THUC AN
create table DanhMucTA
(
	id int identity primary key,
	name nvarchar(100) not null default N'Chưa đặt tên'
)
go

-- THUC AN
create table ThucAn
(
	id int identity primary key,
	name nvarchar(100) not null default N'Chưa đặt tên',
	idCategory int not null,
	price float not null default 0
	foreign key (idCategory) references dbo.DanhMucTA(id)
)
go

-- HOA DON
create table HoaDon
(
	id int identity primary key,
	DateCheckIn Date not null default getdate(),
	DateCheckOut Date,
	idTable int not null,
	status int not null default 0, -- 1 thanh toan,0 chua thanh toan
	discount int null,
	totalprice float null
	foreign key (idTable) references  dbo.Ban(id)
)
go

-- THONG TIN HOA DON
create table ThongTinHD
(
	id int identity primary key,
	idBill int not null,
	idFood int not null,
	noteOrder nvarchar(100),
	count int not null default 0
	foreign key (idBill) references dbo.HoaDon(id),
	foreign key (idFood) references dbo.ThucAn(id)
)
go

-- THONG KE
create table ThongKe
(
	idFood int not null,
	name nvarchar(100) not null,
	count int not null
)
go

-- THONG KE MAX MIN
create table ThongKeMaxMin
(
	name nvarchar(100) not null,
	count int not null
)
go

-- TONG THONG KE THEO ID HOA DON
create table TongThongKeTheoIDBill
(
	TotalPrice float null
)
-- End Create Table
go

-- Them Du Lieu Danh Muc TA
INSERT INTO dbo.DanhMucTA
        ( name )
VALUES  ( N'Cà Phê')

INSERT INTO dbo.DanhMucTA
        ( name )
VALUES  ( N'Sinh Tố')

INSERT INTO dbo.DanhMucTA
        ( name )
VALUES  ( N'Nước Ép')

INSERT INTO dbo.DanhMucTA
        ( name )
VALUES  ( N'Thức Ăn Nhanh')

INSERT INTO dbo.DanhMucTA
        ( name )
VALUES  ( N'Bánh')
-- End Them Du Lieu Danh Muc TA
go

-- Them Du Lieu Thuc An
INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Cà Phê Đen', 1, 12000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Cà Phê Sữa', 1, 15000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Cà Phê Dừa', 1, 25000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Cà Phê Espresso', 1, 15000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Cà Phê Latte', 1, 25000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Cà Phê Cappuccino', 1, 25000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Cà Phê Mocaccino', 1, 25000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Cà Phê Americano', 1, 20000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Cà Phê Machiato', 1, 25000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Sinh Tố Bơ', 2, 20000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Sinh Tố Dâu', 2, 20000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Sinh Tố Xoài', 2, 20000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Sinh Tố Táo', 2, 20000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Nước Ép Cà Chua', 3, 15000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Nước Ép Carrot', 3, 15000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Nước Ép Cam', 3, 15000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Nước Ép Dưa Hấu', 3, 15000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Khoai Tây Chiên', 4, 15000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Đồ Chiên', 4, 15000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Hamburger', 4, 20000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Bánh Kem', 5, 20000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Bánh Pudding', 5, 20000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Bánh Phồng Tôm', 5, 15000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Bánh Bông Lan', 5, 20000)

INSERT INTO dbo.ThucAn
        ( name, idCategory, price )
VALUES  ( N'Bánh Mì', 5, 15000)
-- End Them Du Lieu Thuc An
go

-- Them Du Lieu Tai Khoan
INSERT INTO dbo.TaiKhoan
        ( UserName ,
          DisplayName ,
          PassWord ,
          Type
        )
VALUES  ( N'admin' , -- UserName - nvarchar(100)
          N'Viola Van Astrea' , -- DisplayName - nvarchar(100)
          N'1' , -- PassWord - nvarchar(1000)
          1  -- Type - int
        )
INSERT INTO dbo.TaiKhoan
        ( UserName ,
          DisplayName ,
          PassWord ,
          Type
        )
VALUES  ( N'staff' , -- UserName - nvarchar(100)
          N'Huỳnh Thanh Cao Bách' , -- DisplayName - nvarchar(100)
          N'1' , -- PassWord - nvarchar(1000)
          0  -- Type - int
        )
-- End Them Du Lieu Tai Khoan
go

-- Them Ban
declare @i int = 1
while @i <=10
begin
	insert dbo.Ban (name) values (N'' + cast(@i as nvarchar(100)))
	set @i = @i +1 
end
-- End Them Ban
go

--Stored Procedure Login
create PROC USP_GetAccountByUserName
@userName nvarchar(100)
as 
begin
	select * from dbo.TaiKhoan where UserName = @userName
end
go
 create proc USP_Login
@userName nvarchar(100), @passWord nvarchar(100)
as
begin
	select * from dbo.TaiKhoan where UserName = @userName and PassWord = @passWord
end
--End Procedure Login
go

--Stored Procedure GetTableList
create proc USP_GetTableList
as select * from dbo.Ban
--End Procedure GetTableList
go

--Stored Procedure InsertBill
create proc USP_InsertBill
@idTable int
as
begin
	insert dbo.HoaDon
			( DateCheckIn,DateCheckOut,idTable,status,discount)
	values  ( GETDATE(), null, @idTable, 0,0)
end
--End Procedure InsertBill
go

--Stored Procedure InsertBillInfo
create proc USP_InsertBillInfo
@idBill int, @idFood int, @count int, @noteOrder nvarchar(100)
as
begin

	declare @isExitsBillInfo int
	declare @foodCount int = 1
	
	select @isExitsBillInfo = id, @foodCount = b.count 
	from dbo.ThongTinHD as b 
	where idBill = @idBill and idFood = @idFood and noteOrder = @noteOrder

	if (@isExitsBillInfo > 0)
	begin
		declare @newCount int = @foodCount + @count
		if (@newCount > 0)
			update dbo.ThongTinHD	set count = @foodCount + @count where idFood = @idFood and noteOrder = @noteOrder
		else
			delete dbo.ThongTinHD where idBill = @idBill and idFood = @idFood
	end
	else
	begin
		insert	dbo.ThongTinHD
        ( idBill, idFood, count, noteOrder )
		values  ( @idBill, @idFood, @count, @noteOrder )
	end
end
--End Procedure InsertBillInfo
go

--Trigger UpdateBillInfor
create trigger UTG_UpdateBillInfor
On dbo.ThongTinHD for insert, update
as
begin 
	declare @idBill int

	select @idBill = idBill From inserted

	declare @idTable int

	select @idTable = idTable from dbo.HoaDon where id = @idBill and status = 0

	declare @count int
	select @count = count(*) from dbo.ThongTinHD where idBill = @idBill
	if(@count > 0)
		update dbo.Ban set status = N'Có Người' where id = @idTable
	else
		update dbo.Ban set status = N'Trống' where id = @idTable

end
--End Trigger UpdateBillInfor
go

--Trigger UpdateBill
create trigger UTG_UpdateBill
on dbo.HoaDon for update
as
begin
	declare @idBill int

	select @idBill = id from inserted

	declare @idTable int

	select @idTable = idTable from dbo.HoaDon where id = @idBill

	declare @count int = 0

	select @count = count(*) from dbo.HoaDon where idTable = @idTable and status = 0

	if(@count = 0)
		update dbo.Ban set status = N'Trống' where id = @idTable
end
--End Trigger UpdateBill
go

--Stored Procedure GetListBillByDate
create proc USP_GetListBillByDate
@checkIn date, @checkOut date
as
begin
	select  h.id as [ID], b.name as [Table],h.totalPrice as [Total Price (vnd)], DateCheckIn as [Check In], DateCheckOut as [Check Out]--, discount as [Discount (%)]
	from dbo.HoaDon as h, dbo.Ban as b
	where DateCheckIn >= @checkIn and DateCheckOut <= @checkOut and h.status = 1
	and b.id = h.idTable 
end
--End Procedure GetListBillByDate
go

--Stored Procedure UpdateAccount
create proc USP_UpdateAccount
@userName nvarchar(100), @displayName nvarchar(100), @passWord nvarchar(100), @newPassWord nvarchar (100)
as
begin
	declare @isRightPass int = 0

	select @isRightPass = count(*) from dbo.TaiKhoan where UserName = @userName and PassWord = @passWord

	if (@isRightPass = 1)
	begin
		if(@newPassWord = null or @newPassWord = '')
		begin
			update dbo.TaiKhoan set DisplayName = @displayName where UserName = @userName
		end

		else
			update dbo.TaiKhoan set DisplayName = @displayName, PassWord = @newPassWord where UserName = @userName

	end

end
--End Procedure UpdateAccount
go

--Trigger DeleteBillInfo
create trigger UTG_DeleteBillInfo
ON dbo.ThongTinHD for delete
as
begin
	declare @idBillInfo int
	declare @idBill int
	select @idBillInfo = id, @idBill = deleted.idBill from deleted

	declare @idTable int
	select @idTable = idTable from dbo.HoaDon where id = @idBill

	declare @count int = 0
	select @count = count(*) from dbo.ThongTinHD as td, dbo.HoaDon as hd where hd.id = td.idBill and hd.id = @idBill and status = 0

	if(@count = 0)
		update dbo.Ban set status = N'Trống' where id = @idTable
end
--End Trigger DeleteBillInfo
go

--Create Function
CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
--End Function
go

--Stored Procedure GetListBillByDateAndPage
create proc USP_GetListBillByDateAndPage
@checkIn date, @checkOut date,@page int
as
begin
	declare @pageRows int = 20
	declare @selectRows int = @pageRows
	declare @exceptRows int = (@page - 1) * @pageRows

	;with BillShow as (select h.id as [ID], b.name as [Table],h.totalPrice as [Total Price (vnd)], DateCheckIn as [Check In], DateCheckOut as [Check Out]--, discount as [Discount (%)]
	from dbo.HoaDon as h, dbo.Ban as b
	where DateCheckIn >= @checkIn and DateCheckOut <= @checkOut and h.status = 1
	and b.id = h.idTable )

	select top (@selectRows) * from BillShow where id not in (select top (@exceptRows) id from BillShow)
	

end
--End Procedure GetListBillByDateAndPage
go

--Stored Procedure GetNumBillBydate
create proc USP_GetNumBillBydate
@checkIn date, @checkOut date
as
begin
	select  count(*)
	from dbo.HoaDon as h, dbo.Ban as b
	where DateCheckIn >= @checkIn and DateCheckOut <= @checkOut and h.status = 1
	and b.id = h.idTable 
end
--End Procedure GetNumBillBydate
go

--Stored Procedure GetMaxMinFoodByDate
create proc USP_GetMaxMinFoodByDate
@checkIn date, @checkOut date
as
begin
	insert into dbo.ThongKe
	select  th.idFood, f.name, th.count
	from dbo.ThongTinHD  as th ,dbo.HoaDon as h, dbo.Ban as b, dbo.ThucAn as f 
	where  th.idBill=h.id and th.idFood = f.id and DateCheckIn >= @checkIn and DateCheckOut <= @checkOut and h.status = 1 and b.id = h.idTable

	declare @j int = 1
	while @j <=(select max(id) from dbo.ThucAn)
	begin
		insert dbo.ThongKe(idFood,name,count) values (cast(@j as nvarchar(100)),(select name from dbo.ThucAn where id = @j),0)
		set @j = @j +1 
	end

	declare @i int = 1
    while @i <= (select max(id) from dbo.ThucAn)
    begin
		insert into dbo.ThongKeMaxMin
		select name ,sum(count)
		from dbo.ThongKe
		where idFood = @i group by name
		set @i = @i +1 
    end
end
--End Procedure GetMaxMinFoodByDate
go

--Stored Procedure GetTotalPriceIDBill
create proc USP_GetTotalPriceIDBill
@checkIn date, @checkOut date
as
begin
	insert into dbo.TongThongKeTheoIDBill
	select h.totalPrice
	from dbo.HoaDon as h, dbo.Ban as b
	where DateCheckIn >= @checkIn and DateCheckOut <= @checkOut and h.status = 1
	and b.id = h.idTable 
end
--End Procedure GetTotalPriceIDBill
go
