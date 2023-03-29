CREATE DATABASE QLCuaHangTienLoi
GO

USE QLCuaHangTienLoi
GO

select * from Bill

-- Customer
-- Account
-- TypeAcc
-- Product
-- ProductCategory
-- Bill
-- BillInfo
-- Warehouse

CREATE TABLE Customer
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL,
	sdt  NVARCHAR(100) NOT NULL
)
GO

CREATE TABLE TypeAcc
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL
)
GO

CREATE TABLE Account
(
	id INT IDENTITY PRIMARY KEY,
	UserName NVARCHAR(100),
	DisplayName NVARCHAR(100) NOT NULL,
	Avatar NVARCHAR(max) DEFAULT 0,
	PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
	idType INT NOT NULL,
	Xoa int not null DEFAULT 0

	FOREIGN KEY (idType) REFERENCES dbo.TypeAcc(id)
)
GO

CREATE TABLE ProductCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL,
	Xoa int not null DEFAULT 0
)
GO

CREATE TABLE Product
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL,
	idCategory INT NOT NULL,
	price Float NOT NULL DEFAULT 0,
	url NVARCHAR(Max) NOT NULL DEFAULT N'URL',
	discount INT NOT NULL DEFAULT 0,
	Xoa int not null DEFAULT 0
	--thêm tình trạng 0 - xoá 1- còn
	FOREIGN KEY (idCategory) REFERENCES dbo.ProductCategory(id)
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	Date_ DATE NOT NULL DEFAULT GETDATE(),
	idCustomer INT NOT NULL DEFAULT 1,
	totalbill FLOAT NOT NULL DEFAULT 0,
	status INT NOT NULL DEFAULT 0 --1 thanh toán, 0 chưa thanh toán

	FOREIGN KEY (idCustomer) REFERENCES dbo.Customer(id)
)
GO

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idProduct INT NOT NULL,
	count INT NOT NULL DEFAULT 0,
	totalbillinfo FLOAT NOT NULL DEFAULT 0

	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idProduct) REFERENCES dbo.Product(id)
)
GO

CREATE TABLE Input
(
	id INT IDENTITY PRIMARY KEY,
	idCategory INT NOT NULL,
	idProduct INT NOT NULL,
	Date_Input DATETIME NOT NULL DEFAULT GETDATE(),
	count INT NOT NULL DEFAULT 0,
	priceInput Float NOT NULL DEFAULT 0

	FOREIGN KEY (idCategory) REFERENCES dbo.ProductCategory(id),
	FOREIGN KEY (idProduct) REFERENCES dbo.Product(id)
)
GO
-- thêm category
INSERT dbo.ProductCategory
        ( name )
VALUES  ( N'Fast Food'  -- name - nvarchar(100)
          )
INSERT dbo.ProductCategory
        ( name )
VALUES  ( N'MÌ, MIẾN, CHÁO, PHỞ'  -- name - nvarchar(100)
          )
INSERT dbo.ProductCategory
        ( name )
VALUES  ( N'GẠO, BỘT, ĐỒ KHÔ'  -- name - nvarchar(100)
          )
INSERT dbo.ProductCategory
        ( name )
VALUES  ( N'DẦU ĂN, NƯỚC CHẤM, GIA VỊ'  -- name - nvarchar(100)
          )
INSERT dbo.ProductCategory
        ( name )
VALUES  ( N'BIA, NƯỚC GIẢI KHÁT'  -- name - nvarchar(100)
          )
INSERT dbo.ProductCategory
        ( name )
VALUES  ( N'SỮA CÁC LOẠI'  -- name - nvarchar(100)
          )
INSERT dbo.ProductCategory
        ( name )
VALUES  ( N'BÁNH KẸO CÁC LOẠI'  -- name - nvarchar(100)
          )
INSERT dbo.ProductCategory
        ( name )
VALUES  ( N'CHĂM SÓC CÁ NHÂN'  -- name - nvarchar(100)
          )
INSERT dbo.ProductCategory
        ( name )
VALUES  ( N'ĐỒ DÙNG GIA ĐÌNH'  -- name - nvarchar(100)
          )
INSERT dbo.ProductCategory
        ( name )
VALUES  ( N'KEM, THỰC PHẨM ĐÔNG MÁT'  -- name - nvarchar(100)
          )
--thêm Customer
INSERT dbo.Customer
        ( name, sdt )
VALUES  ( N'#####',N'##########'
          )
INSERT dbo.Customer
        ( name, sdt )
VALUES  ( N'Sang',N'0909'
          )
--Type
INSERT dbo.TypeAcc
        ( name )
VALUES  ( N'Admin'  -- name - nvarchar(100)
          )
INSERT dbo.TypeAcc
        ( name )
VALUES  ( N'User'  -- name - nvarchar(100)
          )
-- thêm account
INSERT dbo.Account
        ( UserName, DisplayName, PassWord, Avatar, idType )
VALUES  ( N'admin',N'Admin', N'12345', N'C:\Users\THANH DUY\Downloads\avatar.jpg', 1
          )
update Account set Avatar = N'C:\Users\THANH DUY\Downloads\avatar.jpg' where idType = 1

select * from bill
insert bill (Date_, idCustomer, totalbill, status) values ('2023-02-06', 1, 800000, 1) 

--INSERT dbo.Account
--        ( UserName, DisplayName, PassWord, Avatar, idType )
--VALUES  ( N'user',N'User', N'12345', N'0', 2
--          )
--INSERT dbo.Account
--        ( UserName, DisplayName, PassWord, Avatar, idType )
--VALUES  ( N'sang',N'ThanhSang', N'1', N'0', 2
--          )

--thêm bill
INSERT dbo.Bill
        ( idCustomer)
VALUES  ( 1)



--select Product.name, BillInfo.count, BillInfo.totalbillinfo from Product,BillInfo where BillInfo.idBill = 1

--SELECT
--Customer.name, Bill.Date_, BillInfo.totalbillinfo
--FROM Bill
--JOIN Customer
--  ON Bill.idCustomer = Customer.id
--JOIN BillInfo
--  ON Bill.id = BillInfo.idBill

--SELECT
--Product.name, BillInfo.count, BillInfo.totalbillinfo
--FROM BillInfo
--JOIN Product
--  ON BillInfo.idProduct = Product.id 

--SELECT
--Product.name, ProductCategory.name, Input.Date_Input, Input.count, Input.priceInput
--FROM Input
--JOIN Product
--  ON Product.id = Input.idProduct
--JOIN ProductCategory
--  ON ProductCategory.id = Input.idCategory