USE [master]
GO
/****** Object:  Database [ECom]    Script Date: 2017/3/9 19:44:02 ******/
CREATE DATABASE [ECom]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ECom', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ECom.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ECom_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ECom_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ECom] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ECom].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ECom] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ECom] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ECom] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ECom] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ECom] SET ARITHABORT OFF 
GO
ALTER DATABASE [ECom] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ECom] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ECom] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ECom] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ECom] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ECom] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ECom] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ECom] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ECom] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ECom] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ECom] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ECom] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ECom] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ECom] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ECom] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ECom] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ECom] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ECom] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ECom] SET  MULTI_USER 
GO
ALTER DATABASE [ECom] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ECom] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ECom] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ECom] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ECom] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ECom]
GO
/****** Object:  Table [dbo].[AddressInformation]    Script Date: 2017/3/9 19:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddressInformation](
	[Id] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[OrderToStreet] [nvarchar](100) NULL,
	[OrderToCity] [nvarchar](50) NULL,
	[OrderToState] [nvarchar](50) NULL,
	[OrderToCountry] [nvarchar](50) NULL,
	[OrderToZipCode] [nvarchar](25) NULL,
	[CustomerPhone] [nvarchar](25) NULL,
 CONSTRAINT [PK_AddressInformation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 2017/3/9 19:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](200) NULL,
	[isActive] [bit] NOT NULL,
	[Sequence] [int] NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifiedBy] [varchar](25) NULL,
	[LastModifiedDate] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderInformation]    Script Date: 2017/3/9 19:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderInformation](
	[Id] [int] NOT NULL,
	[OrderNumber] [varchar](50) NOT NULL,
	[CustomerId] [int] NULL,
	[OrderDate] [datetime] NULL,
	[OrderStatus] [varchar](25) NULL,
	[OrderTotalAmt] [money] NULL,
	[OrderPaymentType] [varchar](50) NULL,
	[SubtotalBeforeTax] [money] NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifiedBy] [varchar](25) NULL,
	[LastModifiedDate] [datetime] NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: 2017/3/9 19:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderItem](
	[Id] [int] NOT NULL,
	[Name] [varchar](100) NULL,
	[Description] [varchar](200) NULL,
	[isActive] [bit] NOT NULL,
	[UnitPrice] [money] NULL,
	[ItemId] [int] NULL,
	[ItemSequence] [int] NULL,
	[NumberOrdered] [int] NULL,
	[StockNumber] [int] NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifyBy] [varchar](25) NULL,
	[LastModifyDate] [datetime] NULL,
	[OrderId] [nchar](10) NULL,
 CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2017/3/9 19:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] NULL,
	[Name] [varchar](50) NULL,
	[UnitPrice] [money] NULL,
	[Quantity] [decimal](18, 0) NULL,
	[SubTotal] [decimal](18, 0) NULL,
	[Description] [varchar](100) NULL,
	[Review] [varchar](100) NULL,
	[DishesCategory] [nchar](10) NULL,
	[UnitCaloric] [int] NULL,
	[Hours] [datetime] NULL,
	[DateAvaliable] [time](7) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ShippingAddress]    Script Date: 2017/3/9 19:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShippingAddress](
	[Id] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
 CONSTRAINT [PK_ShippingAddress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_isActive]  DEFAULT ((1)) FOR [isActive]
GO
USE [master]
GO
ALTER DATABASE [ECom] SET  READ_WRITE 
GO
