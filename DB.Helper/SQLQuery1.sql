USE [master]
GO

IF EXISTS(SELECT 1 FROM sysdatabases WHERE NAME=N'ContentExt')
BEGIN
    DROP DATABASE ContentExt   --如果数据库存在先删掉数据库
END
GO

CREATE DATABASE ContentExt
ON
PRIMARY  --创建主数据库文件
(
    NAME='ContentExt',
    FILENAME='D:\Program Files\Microsoft SQL Server\MSSQL10_50.SQL2008\MSSQL\DATA\ContentExt.dbf',
    SIZE=5MB,
    MaxSize=20MB,
    FileGrowth=1MB
)
LOG ON --创建日志文件
(
    NAME='HkTempLog',
    FileName='D:\Program Files\Microsoft SQL Server\MSSQL10_50.SQL2008\MSSQL\DATA\ContentExt.ldf',
    Size=2MB,
    MaxSize=20MB,
    FileGrowth=1MB
)
GO

USE [ContentExt]
GO
--添加表
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Scenic') AND type in (N'U'))
BEGIN
CREATE TABLE Scenic
(
    Id INT IDENTITY(1,1) NOT NULL,
	Sname nvarchar(100),
    Slevel NVARCHAR(100),
    Saddress NVARCHAR(200),
    Sseoname NVARCHAR(100),
    Sarea NVARCHAR(100),
    Stopic NVARCHAR(100),
    Stopicseo NVARCHAR(100),
    Strafficintro NVARCHAR(2000),
    Sbookintro text,
    Sscenicdetail text,
    Sscenicintro nvarchar(300)
    
    PRIMARY KEY CLUSTERED
    (
        Id ASC
    )WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

USE [ContentExt]
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'TicketPrice') AND type in (N'U'))
BEGIN
CREATE TABLE TicketPrice
(
    Id INT IDENTITY(1,1) NOT NULL,
    Tscenic NVARCHAR(100),
    Tname NVARCHAR(20),
    Torgprice NVARCHAR(10),
    Tolprice NVARCHAR(10)
    
    PRIMARY KEY CLUSTERED
    (
        Id ASC
    )WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO