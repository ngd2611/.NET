-- ============================================================
--  HỆ THỐNG QUẢN LÝ CỬA HÀNG VĂN PHÒNG PHẨM
--  Database Script - SQL Server Management Studio
--  Môn: Lập trình .NET | Học viện Ngân hàng
--  Tác giả: Thanh (Người 1)
-- ============================================================

USE master;
GO

-- Xóa DB cũ nếu tồn tại (tiện cho việc reset test)
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'QuanLyVanPhongPham')
BEGIN
    ALTER DATABASE QuanLyVanPhongPham SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QuanLyVanPhongPham;
END
GO

CREATE DATABASE QuanLyVanPhongPham
    COLLATE Vietnamese_CI_AS;
GO

USE QuanLyVanPhongPham;
GO

-- ============================================================
-- BẢNG 1: Users - Tài khoản & Phân quyền
-- ============================================================
CREATE TABLE Users (
    UserID      INT IDENTITY(1,1) PRIMARY KEY,
    Username    NVARCHAR(50)  NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL,          -- SHA-256 hash
    FullName    NVARCHAR(100) NOT NULL,
    Email       NVARCHAR(150) NULL,
    Phone       NVARCHAR(20)  NULL,
    Role        NVARCHAR(30)  NOT NULL
                    CONSTRAINT CK_Users_Role
                    CHECK (Role IN (N'Admin', N'NhanVienBanHang', N'NhanVienKho')),
    IsActive    BIT           NOT NULL DEFAULT 1,
    CreatedAt   DATETIME      NOT NULL DEFAULT GETDATE(),
    UpdatedAt   DATETIME      NULL
);
GO

-- ============================================================
-- BẢNG 2: Category - Danh mục sản phẩm (có phân cấp cha/con)
-- ============================================================
CREATE TABLE Category (
    CategoryID   INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL,
    Description  NVARCHAR(255) NULL,
    ParentID     INT           NULL,               -- NULL = danh mục gốc
    IsActive     BIT           NOT NULL DEFAULT 1,
    CONSTRAINT FK_Category_Parent FOREIGN KEY (ParentID)
        REFERENCES Category(CategoryID)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION
);
GO

-- ============================================================
-- BẢNG 3: Brand - Thương hiệu
-- ============================================================
CREATE TABLE Brand (
    BrandID     INT IDENTITY(1,1) PRIMARY KEY,
    BrandName   NVARCHAR(100) NOT NULL UNIQUE,
    LogoUrl     NVARCHAR(300) NULL,
    IsActive    BIT           NOT NULL DEFAULT 1
);
GO

-- ============================================================
-- BẢNG 4: Supplier - Nhà cung cấp
-- ============================================================
CREATE TABLE Supplier (
    SupplierID   INT IDENTITY(1,1) PRIMARY KEY,
    SupplierName NVARCHAR(150) NOT NULL,
    ContactName  NVARCHAR(100) NULL,
    Phone        NVARCHAR(20)  NULL,
    Email        NVARCHAR(150) NULL,
    Address      NVARCHAR(300) NULL,
    TaxCode      NVARCHAR(20)  NULL,
    IsActive     BIT           NOT NULL DEFAULT 1
);
GO

-- ============================================================
-- BẢNG 5: Product - Sản phẩm
-- ============================================================
CREATE TABLE Product (
    ProductID     INT IDENTITY(1,1) PRIMARY KEY,
    ProductCode   NVARCHAR(30)    NOT NULL UNIQUE,  -- Mã sản phẩm (VD: VPP001)
    ProductName   NVARCHAR(200)   NOT NULL,
    Description   NVARCHAR(500)   NULL,
    CategoryID    INT             NULL,
    BrandID       INT             NULL,
    Unit          NVARCHAR(30)    NOT NULL DEFAULT N'Cái', -- Đơn vị tính
    CostPrice     DECIMAL(18,2)   NOT NULL DEFAULT 0,  -- Giá nhập
    UnitPrice     DECIMAL(18,2)   NOT NULL DEFAULT 0,  -- Giá bán
    StockQuantity INT             NOT NULL DEFAULT 0,
    MinStockLevel INT             NOT NULL DEFAULT 5,  -- Ngưỡng cảnh báo tồn kho
    ImageUrl      NVARCHAR(300)   NULL,
    IsActive      BIT             NOT NULL DEFAULT 1,
    CreatedAt     DATETIME        NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Product_Category FOREIGN KEY (CategoryID)
        REFERENCES Category(CategoryID)
        ON DELETE SET NULL,
    CONSTRAINT FK_Product_Brand FOREIGN KEY (BrandID)
        REFERENCES Brand(BrandID)
        ON DELETE SET NULL,
    CONSTRAINT CK_Product_CostPrice  CHECK (CostPrice  >= 0),
    CONSTRAINT CK_Product_UnitPrice  CHECK (UnitPrice  >= 0),
    CONSTRAINT CK_Product_StockQty   CHECK (StockQuantity >= 0)
);
GO

-- ============================================================
-- BẢNG 6: PurchaseOrder - Phiếu nhập kho
-- ============================================================
CREATE TABLE PurchaseOrder (
    PurchaseID   INT IDENTITY(1,1) PRIMARY KEY,
    PurchaseCode NVARCHAR(20)    NOT NULL UNIQUE,   -- NK-20240001
    SupplierID   INT             NOT NULL,
    UserID       INT             NOT NULL,          -- Nhân viên kho tạo phiếu
    PurchaseDate DATETIME        NOT NULL DEFAULT GETDATE(),
    TotalAmount  DECIMAL(18,2)   NOT NULL DEFAULT 0,
    Note         NVARCHAR(500)   NULL,
    Status       NVARCHAR(30)    NOT NULL DEFAULT N'Đã nhập'
                     CONSTRAINT CK_PO_Status
                     CHECK (Status IN (N'Chờ duyệt', N'Đã nhập', N'Hủy')),
    CONSTRAINT FK_PO_Supplier FOREIGN KEY (SupplierID)
        REFERENCES Supplier(SupplierID),
    CONSTRAINT FK_PO_User FOREIGN KEY (UserID)
        REFERENCES Users(UserID)
);
GO

-- ============================================================
-- BẢNG 7: PurchaseDetail - Chi tiết phiếu nhập kho
-- ============================================================
CREATE TABLE PurchaseDetail (
    PurchaseDetailID INT IDENTITY(1,1) PRIMARY KEY,
    PurchaseID       INT           NOT NULL,
    ProductID        INT           NOT NULL,
    Quantity         INT           NOT NULL,
    UnitPrice        DECIMAL(18,2) NOT NULL,
    TotalPrice       AS (Quantity * UnitPrice) PERSISTED, -- Cột tính toán tự động
    CONSTRAINT FK_PD_Purchase FOREIGN KEY (PurchaseID)
        REFERENCES PurchaseOrder(PurchaseID)
        ON DELETE CASCADE,
    CONSTRAINT FK_PD_Product FOREIGN KEY (ProductID)
        REFERENCES Product(ProductID),
    CONSTRAINT CK_PD_Quantity CHECK (Quantity > 0)
);
GO

-- ============================================================
-- BẢNG 8: [Order] - Đơn bán hàng
-- ============================================================
CREATE TABLE [Order] (
    OrderID      INT IDENTITY(1,1) PRIMARY KEY,
    OrderCode    NVARCHAR(20)    NOT NULL UNIQUE,   -- DH-20240001
    CustomerName NVARCHAR(150)   NULL,
    CustomerPhone NVARCHAR(20)   NULL,
    OrderDate    DATETIME        NOT NULL DEFAULT GETDATE(),
    UserID       INT             NOT NULL,          -- Nhân viên bán hàng
    Status       NVARCHAR(30)    NOT NULL DEFAULT N'Chờ xử lý'
                     CONSTRAINT CK_Order_Status
                     CHECK (Status IN (N'Chờ xử lý', N'Đang giao', N'Đã giao', N'Hoàn thành', N'Hủy')),
    TotalAmount  DECIMAL(18,2)   NOT NULL DEFAULT 0,
    Discount     DECIMAL(18,2)   NOT NULL DEFAULT 0,
    FinalAmount  DECIMAL(18,2)   NOT NULL DEFAULT 0, -- Sau khi trừ giảm giá
    Note         NVARCHAR(500)   NULL,
    CreatedAt    DATETIME        NOT NULL DEFAULT GETDATE(),
    UpdatedAt    DATETIME        NULL,
    CONSTRAINT FK_Order_User FOREIGN KEY (UserID)
        REFERENCES Users(UserID)
);
GO

-- ============================================================
-- BẢNG 9: OrderDetail - Chi tiết đơn bán hàng
-- ============================================================
CREATE TABLE OrderDetail (
    OrderDetailID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID       INT           NOT NULL,
    ProductID     INT           NOT NULL,
    Quantity      INT           NOT NULL,
    UnitPrice     DECIMAL(18,2) NOT NULL,
    Discount      DECIMAL(18,2) NOT NULL DEFAULT 0,  -- Giảm giá theo dòng
    TotalPrice    AS (Quantity * UnitPrice - Discount) PERSISTED,
    CONSTRAINT FK_OD_Order FOREIGN KEY (OrderID)
        REFERENCES [Order](OrderID)
        ON DELETE CASCADE,
    CONSTRAINT FK_OD_Product FOREIGN KEY (ProductID)
        REFERENCES Product(ProductID),
    CONSTRAINT CK_OD_Quantity CHECK (Quantity > 0)
);
GO

-- ============================================================
-- BẢNG 10: ReturnOrder - Phiếu trả hàng
-- ============================================================
CREATE TABLE ReturnOrder (
    ReturnID    INT IDENTITY(1,1) PRIMARY KEY,
    ReturnCode  NVARCHAR(20)    NOT NULL UNIQUE,    -- TH-20240001
    OrderID     INT             NOT NULL,
    UserID      INT             NOT NULL,           -- NV xử lý trả hàng
    ReturnDate  DATETIME        NOT NULL DEFAULT GETDATE(),
    Reason      NVARCHAR(500)   NULL,
    TotalRefund DECIMAL(18,2)   NOT NULL DEFAULT 0,
    Status      NVARCHAR(30)    NOT NULL DEFAULT N'Đã hoàn tiền'
                    CONSTRAINT CK_Return_Status
                    CHECK (Status IN (N'Chờ xử lý', N'Đã hoàn tiền', N'Từ chối')),
    CONSTRAINT FK_Return_Order FOREIGN KEY (OrderID)
        REFERENCES [Order](OrderID),
    CONSTRAINT FK_Return_User FOREIGN KEY (UserID)
        REFERENCES Users(UserID)
);
GO

-- ============================================================
-- BẢNG 11: ReturnDetail - Chi tiết phiếu trả hàng (CẢI TIẾN)
-- ============================================================
CREATE TABLE ReturnDetail (
    ReturnDetailID INT IDENTITY(1,1) PRIMARY KEY,
    ReturnID       INT           NOT NULL,
    ProductID      INT           NOT NULL,
    Quantity       INT           NOT NULL,
    RefundAmount   DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_RD_Return FOREIGN KEY (ReturnID)
        REFERENCES ReturnOrder(ReturnID)
        ON DELETE CASCADE,
    CONSTRAINT FK_RD_Product FOREIGN KEY (ProductID)
        REFERENCES Product(ProductID),
    CONSTRAINT CK_RD_Quantity CHECK (Quantity > 0)
);
GO

-- ============================================================
-- BẢNG 12: ActivityLog - Nhật ký thao tác (CẢI TIẾN - Bổ sung)
-- Giúp Admin xem lịch sử ai đã làm gì
-- ============================================================
CREATE TABLE ActivityLog (
    LogID       INT IDENTITY(1,1) PRIMARY KEY,
    UserID      INT           NULL,
    Action      NVARCHAR(100) NOT NULL,   -- VD: 'Tạo đơn hàng', 'Nhập kho'
    TableName   NVARCHAR(50)  NULL,
    RecordID    INT           NULL,
    Description NVARCHAR(500) NULL,
    LogTime     DATETIME      NOT NULL DEFAULT GETDATE()
);
GO

-- ============================================================
-- INDEX - Tối ưu truy vấn tìm kiếm
-- ============================================================
CREATE INDEX IX_Product_CategoryID  ON Product(CategoryID);
CREATE INDEX IX_Product_BrandID     ON Product(BrandID);
CREATE INDEX IX_Product_ProductCode ON Product(ProductCode);
CREATE INDEX IX_Order_UserID        ON [Order](UserID);
CREATE INDEX IX_Order_OrderDate     ON [Order](OrderDate);
CREATE INDEX IX_Order_Status        ON [Order](Status);
CREATE INDEX IX_PO_SupplierID       ON PurchaseOrder(SupplierID);
CREATE INDEX IX_PO_PurchaseDate     ON PurchaseOrder(PurchaseDate);
GO

-- ============================================================
-- TRIGGER: Tự động cộng tồn kho khi nhập hàng
-- ============================================================
CREATE OR ALTER TRIGGER trg_PurchaseDetail_UpdateStock
ON PurchaseDetail
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE p
    SET p.StockQuantity = p.StockQuantity + i.Quantity
    FROM Product p
    INNER JOIN inserted i ON p.ProductID = i.ProductID;
END
GO

-- ============================================================
-- TRIGGER: Tự động trừ tồn kho khi tạo đơn bán (Status = Hoàn thành)
-- ============================================================
CREATE OR ALTER TRIGGER trg_Order_DeductStock
ON [Order]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (
        SELECT 1 FROM inserted i
        JOIN deleted d ON i.OrderID = d.OrderID
        WHERE i.Status = N'Hoàn thành' AND d.Status <> N'Hoàn thành'
    )
    BEGIN
        UPDATE p
        SET p.StockQuantity = p.StockQuantity - od.Quantity
        FROM Product p
        INNER JOIN OrderDetail od ON p.ProductID = od.ProductID
        INNER JOIN inserted i ON od.OrderID = i.OrderID
        WHERE i.Status = N'Hoàn thành';
    END
END
GO

-- ============================================================
-- TRIGGER: Hoàn trả tồn kho khi trả hàng
-- ============================================================
CREATE OR ALTER TRIGGER trg_ReturnDetail_RestoreStock
ON ReturnDetail
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE p
    SET p.StockQuantity = p.StockQuantity + i.Quantity
    FROM Product p
    INNER JOIN inserted i ON p.ProductID = i.ProductID;
END
GO

-- ============================================================
-- VIEW: Tổng hợp doanh thu theo ngày (cho Dashboard)
-- ============================================================
CREATE OR ALTER VIEW vw_RevenueByDate AS
SELECT
    CAST(OrderDate AS DATE) AS OrderDay,
    COUNT(OrderID)          AS TotalOrders,
    SUM(FinalAmount)        AS Revenue
FROM [Order]
WHERE Status = N'Hoàn thành'
GROUP BY CAST(OrderDate AS DATE);
GO

-- ============================================================
-- VIEW: Tồn kho cảnh báo
-- ============================================================
CREATE OR ALTER VIEW vw_LowStockAlert AS
SELECT
    p.ProductID, p.ProductCode, p.ProductName,
    p.StockQuantity, p.MinStockLevel,
    c.CategoryName, b.BrandName
FROM Product p
LEFT JOIN Category c ON p.CategoryID = c.CategoryID
LEFT JOIN Brand    b ON p.BrandID    = b.BrandID
WHERE p.StockQuantity <= p.MinStockLevel AND p.IsActive = 1;
GO

-- ============================================================
-- VIEW: Top sản phẩm bán chạy
-- ============================================================
CREATE OR ALTER VIEW vw_TopSellingProducts AS
SELECT TOP 10
    p.ProductID, p.ProductCode, p.ProductName,
    SUM(od.Quantity)    AS TotalSold,
    SUM(od.TotalPrice)  AS TotalRevenue
FROM OrderDetail od
INNER JOIN Product p ON od.ProductID = p.ProductID
INNER JOIN [Order] o ON od.OrderID   = o.OrderID
WHERE o.Status = N'Hoàn thành'
GROUP BY p.ProductID, p.ProductCode, p.ProductName
ORDER BY TotalSold DESC;
GO

-- ============================================================
-- STORED PROCEDURE: Thống kê doanh thu theo tháng/năm
-- ============================================================
CREATE OR ALTER PROCEDURE sp_GetRevenueByMonth
    @Year INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF @Year IS NULL SET @Year = YEAR(GETDATE());

    SELECT
        MONTH(OrderDate)    AS [Month],
        COUNT(OrderID)      AS TotalOrders,
        SUM(FinalAmount)    AS Revenue
    FROM [Order]
    WHERE Status = N'Hoàn thành'
      AND YEAR(OrderDate) = @Year
    GROUP BY MONTH(OrderDate)
    ORDER BY [Month];
END
GO

-- ============================================================
--  DỮ LIỆU GIẢ (SEED DATA)
-- ============================================================

-- ---- Users (mật khẩu gốc: "123456" - đây là SHA-256 hash) ----
-- Trong C# dùng: SHA256.HashData(Encoding.UTF8.GetBytes("123456"))
-- Hash của "123456": 8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92

INSERT INTO Users (Username, PasswordHash, FullName, Email, Phone, Role) VALUES
(N'admin',      N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Nguyễn Văn Admin',    N'admin@vpp.vn',   N'0901234560', N'Admin'),
(N'nv_banhang', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Trần Thị Bán Hàng',   N'banhang@vpp.vn', N'0901234561', N'NhanVienBanHang'),
(N'nv_kho',     N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Lê Văn Kho',         N'kho@vpp.vn',     N'0901234562', N'NhanVienKho');
GO

-- ---- Category ----
INSERT INTO Category (CategoryName, Description, ParentID) VALUES
(N'Bút viết',                 N'Các loại bút viết',             NULL),  -- 1
(N'Vở & Giấy',                N'Vở, giấy các loại',             NULL),  -- 2
(N'Văn phòng phẩm khác',      N'Dụng cụ văn phòng tổng hợp',    NULL),  -- 3
(N'Bút bi',                   N'Bút bi các loại',               1),     -- 4 (con của Bút viết)
(N'Bút chì',                  N'Bút chì gỗ và bút chì bấm',     1),     -- 5
(N'Bút lông',                 N'Bút lông bảng, bút dạ',         1),     -- 6
(N'Vở học sinh',               N'Vở 96 trang, 200 trang...',     2),     -- 7
(N'Giấy in',                  N'Giấy A4, A5 các loại',          2),     -- 8
(N'Kẹp & Ghim',               N'Kẹp bướm, ghim dập',            3),     -- 9
(N'Dụng cụ cắt dán',          N'Kéo, băng dính, hồ dán',        3);     -- 10
GO

-- ---- Brand ----
INSERT INTO Brand (BrandName) VALUES
(N'Thiên Long'),    -- 1
(N'Bến Nghé'),     -- 2
(N'Double A'),     -- 3
(N'Pilot'),        -- 4
(N'Staedtler');    -- 5
GO

-- ---- Supplier ----
INSERT INTO Supplier (SupplierName, ContactName, Phone, Email, Address, TaxCode) VALUES
(N'Công ty TNHH Thiên Long',      N'Nguyễn Minh Hùng',  N'02838123456', N'sales@thienlonggroup.com', N'123 Bình Dương',  N'0301234560'),
(N'Công ty CP Phát Tiến',         N'Trần Thị Mai',       N'02438987654', N'info@phattien.vn',        N'45 Hà Nội',      N'0100234561'),
(N'Công ty TNHH Double A VN',     N'Lê Quang Minh',      N'02839876543', N'contact@doublea.vn',      N'67 TP.HCM',      N'0302345678');
GO

-- ---- Product (10 sản phẩm) ----
INSERT INTO Product (ProductCode, ProductName, Description, CategoryID, BrandID, Unit, CostPrice, UnitPrice, StockQuantity, MinStockLevel) VALUES
(N'VPP001', N'Bút bi Thiên Long TL-027',    N'Bút bi xanh, ngòi 0.7mm, mực đều',      4,  1, N'Cái',    2000,   4000,   200, 20),
(N'VPP002', N'Bút bi Pilot BP-S',            N'Bút bi Nhật, ngòi 0.7mm siêu mịn',      4,  4, N'Cái',    8000,  15000,   100, 10),
(N'VPP003', N'Bút chì 2B Staedtler',         N'Bút chì gỗ 2B, vẽ kỹ thuật',            5,  5, N'Cái',    3000,   6000,   150, 15),
(N'VPP004', N'Bút lông bảng Thiên Long',     N'Bút lông bảng xóa được, xanh',          6,  1, N'Cái',   10000,  20000,    80, 10),
(N'VPP005', N'Vở 96 trang Bến Nghé ô ly',   N'Vở học sinh 96 trang, bìa cứng',        7,  2, N'Quyển',  8000,  15000,   300, 30),
(N'VPP006', N'Vở 200 trang Thiên Long',      N'Vở 200 trang dày, bìa đẹp',             7,  1, N'Quyển', 15000,  28000,   150, 20),
(N'VPP007', N'Giấy in A4 Double A 70gsm',   N'500 tờ/ream, trắng sáng 96%',           8,  3, N'Ream',  60000, 100000,    50,  5),
(N'VPP008', N'Kẹp bướm 19mm Thiên Long',    N'Hộp 12 cái, kẹp chắc',                  9,  1, N'Hộp',    8000,  15000,    60, 10),
(N'VPP009', N'Băng dính trong 1.8cm x 30m', N'Băng keo trong suốt, cuộn lớn',         10,  1, N'Cuộn',   5000,  10000,    90, 10),
(N'VPP010', N'Kéo văn phòng cán nhựa',      N'Kéo inox lưỡi sắc, cán nhựa an toàn',  10,  2, N'Cái',   12000,  22000,    70,  8);
GO

-- ---- PurchaseOrder: 2 phiếu nhập kho ----
INSERT INTO PurchaseOrder (PurchaseCode, SupplierID, UserID, PurchaseDate, TotalAmount, Note, Status) VALUES
(N'NK-20240001', 1, 3, '2024-04-01 09:00:00', 0, N'Nhập hàng đầu tháng từ Thiên Long', N'Đã nhập'),
(N'NK-20240002', 2, 3, '2024-04-10 14:00:00', 0, N'Nhập bổ sung từ Phát Tiến',         N'Đã nhập');
GO

-- ---- PurchaseDetail (trigger sẽ tự cộng stock) ----
-- Phiếu 1
INSERT INTO PurchaseDetail (PurchaseID, ProductID, Quantity, UnitPrice) VALUES
(1, 1, 100, 2000),   -- Bút bi TL-027 x100
(1, 4, 30,  10000),  -- Bút lông bảng x30
(1, 5, 100, 8000),   -- Vở 96 trang x100
(1, 8, 20,  8000);   -- Kẹp bướm x20

-- Phiếu 2
INSERT INTO PurchaseDetail (PurchaseID, ProductID, Quantity, UnitPrice) VALUES
(2, 2, 50,  8000),   -- Bút bi Pilot x50
(2, 7, 20,  60000),  -- Giấy A4 Double A x20
(2, 6, 50,  15000);  -- Vở 200 trang x50
GO

-- Cập nhật TotalAmount cho phiếu nhập (sau khi có detail)
UPDATE PurchaseOrder SET TotalAmount = (
    SELECT SUM(TotalPrice) FROM PurchaseDetail WHERE PurchaseID = 1
) WHERE PurchaseID = 1;

UPDATE PurchaseOrder SET TotalAmount = (
    SELECT SUM(TotalPrice) FROM PurchaseDetail WHERE PurchaseID = 2
) WHERE PurchaseID = 2;
GO

-- ---- Orders: 5 đơn hàng với trạng thái khác nhau ----
INSERT INTO [Order] (OrderCode, CustomerName, CustomerPhone, OrderDate, UserID, Status, TotalAmount, Discount, FinalAmount, Note) VALUES
(N'DH-20240001', N'Nguyễn Thị Lan',   N'0912345001', '2024-04-05 10:30:00', 2, N'Hoàn thành',  119000, 0,      119000, NULL),
(N'DH-20240002', N'Trần Minh Quân',   N'0912345002', '2024-04-07 14:00:00', 2, N'Đang giao',    85000, 5000,    80000, N'Giao trước 5h chiều'),
(N'DH-20240003', N'Lê Thị Hoa',       N'0912345003', '2024-04-08 09:15:00', 2, N'Chờ xử lý',   200000, 10000, 190000, NULL),
(N'DH-20240004', N'Phạm Văn Bình',    N'0912345004', '2024-04-09 11:00:00', 2, N'Hủy',          50000, 0,       50000, N'Khách hủy đơn'),
(N'DH-20240005', N'Hoàng Thị Thanh',  N'0912345005', '2024-04-10 16:00:00', 2, N'Đã giao',     156000, 6000,   150000, NULL);
GO

-- ---- OrderDetail ----
-- Đơn 1: Hoàn thành
INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice, Discount) VALUES
(1, 1, 5,  4000,  0),   -- 5 bút bi TL-027
(1, 5, 3, 15000, 2000), -- 3 vở 96 trang, giảm 2000
(1, 9, 4, 10000,  0);   -- 4 băng dính

-- Đơn 2: Đang giao
INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice, Discount) VALUES
(2, 3, 5,  6000,  0),   -- 5 bút chì
(2, 4, 2, 20000,  0),   -- 2 bút lông
(2, 8, 1, 15000, 5000); -- 1 kẹp bướm, giảm 5000

-- Đơn 3: Chờ xử lý  chưa chạy đc 
INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice, Discount) VALUES
(3, 7, 2, 100000,  0),  -- 2 ream giấy A4
(3, 1, 1,   4000,  0);  -- 1 bút bi TL-027

-- Đơn 4: Hủy
INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice, Discount) VALUES
(4, 10, 2, 22000, 0),   -- 2 cái kéo (đơn bị hủy)
(4,  9, 1, 10000, 4000); -- 1 băng dính

-- Đơn 5: Đã giao
INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice, Discount) VALUES
(5, 2, 5, 15000,  0),   -- 5 bút Pilot
(5, 6, 3, 28000,  0),   -- 3 vở 200 trang
(5, 3, 3,  6000, 6000); -- 3 bút chì, giảm 6000
GO

-- ---- ReturnOrder: 1 phiếu trả hàng (từ đơn đã hoàn thành) ----
INSERT INTO ReturnOrder (ReturnCode, OrderID, UserID, ReturnDate, Reason, TotalRefund, Status) VALUES
(N'TH-20240001', 1, 2, '2024-04-06 09:00:00', N'Bút bị lỗi mực không ra', 8000, N'Đã hoàn tiền');
GO

INSERT INTO ReturnDetail (ReturnID, ProductID, Quantity, RefundAmount) VALUES
(1, 1, 2, 8000); -- Trả lại 2 bút bi
GO

-- ============================================================
-- KIỂM TRA DỮ LIỆU SAU KHI INSERT
-- ============================================================
PRINT '=== KIỂM TRA DỮ LIỆU ===';

SELECT 'Users'          AS TableName, COUNT(*) AS [Count] FROM Users         UNION ALL
SELECT 'Category',       COUNT(*) FROM Category   UNION ALL
SELECT 'Brand',          COUNT(*) FROM Brand       UNION ALL
SELECT 'Supplier',       COUNT(*) FROM Supplier    UNION ALL
SELECT 'Product',        COUNT(*) FROM Product     UNION ALL
SELECT 'PurchaseOrder',  COUNT(*) FROM PurchaseOrder UNION ALL
SELECT 'PurchaseDetail', COUNT(*) FROM PurchaseDetail UNION ALL
SELECT '[Order]',        COUNT(*) FROM [Order]     UNION ALL
SELECT 'OrderDetail',    COUNT(*) FROM OrderDetail  UNION ALL
SELECT 'ReturnOrder',    COUNT(*) FROM ReturnOrder  UNION ALL
SELECT 'ReturnDetail',   COUNT(*) FROM ReturnDetail;

-- Kiểm tra tồn kho sau khi trigger chạy
PRINT '=== TỒN KHO HIỆN TẠI ===';
SELECT p.ProductCode, p.ProductName, p.StockQuantity
FROM Product p ORDER BY p.ProductID;

-- Kiểm tra doanh thu
PRINT '=== DOANH THU ĐƠN HOÀN THÀNH ===';
SELECT OrderCode, CustomerName, FinalAmount, Status FROM [Order] ORDER BY OrderID;
GO
