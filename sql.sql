USE [HungTest]
GO
/****** Object:  Table [dbo].[TransactionDetail]    Script Date: 2019/10/23 15:49:07 ******/
DROP TABLE [dbo].[TransactionDetail]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 2019/10/23 15:49:07 ******/
DROP TABLE [dbo].[Transaction]
GO
/****** Object:  Table [dbo].[SysParam]    Script Date: 2019/10/23 15:49:07 ******/
DROP TABLE [dbo].[SysParam]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 2019/10/23 15:49:07 ******/
DROP TABLE [dbo].[Supplier]
GO
/****** Object:  Table [dbo].[ProductHistory]    Script Date: 2019/10/23 15:49:07 ******/
DROP TABLE [dbo].[ProductHistory]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2019/10/23 15:49:07 ******/
DROP TABLE [dbo].[Product]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 2019/10/23 15:49:07 ******/
DROP TABLE [dbo].[Discount]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2019/10/23 15:49:07 ******/
DROP TABLE [dbo].[Customer]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 2019/10/23 15:49:07 ******/
DROP TABLE [dbo].[Category]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 2019/10/23 15:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](250) NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2019/10/23 15:49:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[Contact] [nvarchar](15) NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 2019/10/23 15:49:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [tinyint] NOT NULL,
	[CategoryId] [int] NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[Barcode] [nvarchar](20) NULL,
 CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2019/10/23 15:49:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Barcode] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Quantity] [int] NULL,
	[Price] [money] NULL,
	[CategoryId] [int] NULL,
	[SupplierId] [int] NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[Pin] [tinyint] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Barcode] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductHistory]    Script Date: 2019/10/23 15:49:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BuyDate] [datetime] NULL,
	[ExDate] [datetime] NULL,
	[SupplierId] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [money] NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[Barcode] [nvarchar](20) NULL,
 CONSTRAINT [PK_ProductHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 2019/10/23 15:49:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[Contact1] [nvarchar](15) NULL,
	[Contact2] [nvarchar](15) NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SysParam]    Script Date: 2019/10/23 15:49:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysParam](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](50) NULL,
	[Value] [nvarchar](50) NULL,
 CONSTRAINT [PK_SysParam] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 2019/10/23 15:49:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [tinyint] NULL,
	[CustomerId] [int] NULL,
	[SuplierId] [int] NULL,
	[IsPayment] [tinyint] NULL,
	[Amount] [money] NULL,
	[Payment] [money] NULL,
	[PayBack] [money] NULL,
	[BillNumber] [int] NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionDetail]    Script Date: 2019/10/23 15:49:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionDetail](
	[Barcode] [nvarchar](20) NOT NULL,
	[TracsactionId] [int] NOT NULL,
	[SuplierId] [int] NULL,
	[Quantity] [int] NULL,
	[IsPayment] [tinyint] NULL,
	[Amount] [money] NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [nvarchar](50) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [Description], [CreateAt], [CreateBy]) VALUES (10, N'Thực phẩm', N'Thực phẩm', CAST(N'2019-10-18T00:00:00.000' AS DateTime), N'Hung')
INSERT [dbo].[Category] ([Id], [Name], [Description], [CreateAt], [CreateBy]) VALUES (11, N'Bánh kẹo', N'Bánh kẹo', CAST(N'2019-10-18T00:00:00.000' AS DateTime), N'Hung')
INSERT [dbo].[Category] ([Id], [Name], [Description], [CreateAt], [CreateBy]) VALUES (12, N'Mỹ phẩm', N'Mỹ phẩm', CAST(N'2019-10-18T00:00:00.000' AS DateTime), N'Hung')
INSERT [dbo].[Category] ([Id], [Name], [Description], [CreateAt], [CreateBy]) VALUES (13, N'Đồ uống', N'Đồ uống', CAST(N'2019-10-18T00:00:00.000' AS DateTime), N'Hung')
INSERT [dbo].[Category] ([Id], [Name], [Description], [CreateAt], [CreateBy]) VALUES (14, N'Hàng tiêu dùng thiết yếu', N'Hàng tiêu dùng thiết yếu', CAST(N'2019-10-18T00:00:00.000' AS DateTime), N'Hung')
INSERT [dbo].[Category] ([Id], [Name], [Description], [CreateAt], [CreateBy]) VALUES (15, N'Hàng gia dụng', N'Hàng gia dụng', CAST(N'2019-10-18T00:00:00.000' AS DateTime), N'Hung')
INSERT [dbo].[Category] ([Id], [Name], [Description], [CreateAt], [CreateBy]) VALUES (16, N'Đồ chơi', N'Đồ chơi', CAST(N'2019-10-18T00:00:00.000' AS DateTime), N'Hung')
INSERT [dbo].[Category] ([Id], [Name], [Description], [CreateAt], [CreateBy]) VALUES (17, N'Rượu, bia', N'Rượu, bia', CAST(N'2019-10-18T00:00:00.000' AS DateTime), N'Hung')
INSERT [dbo].[Category] ([Id], [Name], [Description], [CreateAt], [CreateBy]) VALUES (18, N'Văn phòng phẩm', N'Văn phòng phẩm', CAST(N'2019-10-18T00:00:00.000' AS DateTime), N'Hung')
SET IDENTITY_INSERT [dbo].[Category] OFF
INSERT [dbo].[Product] ([Barcode], [Name], [Quantity], [Price], [CategoryId], [SupplierId], [CreateAt], [CreateBy], [Pin]) VALUES (N'11271679', N'Cocacola Chai nhựa 1lit', 5, 15000.0000, 1, 1, CAST(N'2019-10-21T10:43:29.787' AS DateTime), N'Hung', 0)
INSERT [dbo].[Product] ([Barcode], [Name], [Quantity], [Price], [CategoryId], [SupplierId], [CreateAt], [CreateBy], [Pin]) VALUES (N'17969565', N'Bia 333 1 lon', 5, 12000.0000, 1, 1, CAST(N'2019-10-21T10:43:39.017' AS DateTime), N'Hung', 0)
INSERT [dbo].[Product] ([Barcode], [Name], [Quantity], [Price], [CategoryId], [SupplierId], [CreateAt], [CreateBy], [Pin]) VALUES (N'21424136', N'Bim Bim snak 100g', 5, 7000.0000, 1, 1, CAST(N'2019-10-21T10:43:10.817' AS DateTime), N'Hung', 0)
INSERT [dbo].[Product] ([Barcode], [Name], [Quantity], [Price], [CategoryId], [SupplierId], [CreateAt], [CreateBy], [Pin]) VALUES (N'32076004', N'Muối 1kg', 5, 5000.0000, 1, 1, CAST(N'2019-10-21T10:43:01.607' AS DateTime), N'Hung', 0)
INSERT [dbo].[Product] ([Barcode], [Name], [Quantity], [Price], [CategoryId], [SupplierId], [CreateAt], [CreateBy], [Pin]) VALUES (N'37433653', N'Bỏng ngô 100g', 5, 3000.0000, 1, 1, CAST(N'2019-10-21T10:43:21.663' AS DateTime), N'Hung', 0)
INSERT [dbo].[Product] ([Barcode], [Name], [Quantity], [Price], [CategoryId], [SupplierId], [CreateAt], [CreateBy], [Pin]) VALUES (N'70749924', N'Thuốc lá 3 số 1 điếu', 10, 1500.0000, 2, 3, CAST(N'2019-10-23T10:43:18.250' AS DateTime), N'Hung', 1)
INSERT [dbo].[Product] ([Barcode], [Name], [Quantity], [Price], [CategoryId], [SupplierId], [CreateAt], [CreateBy], [Pin]) VALUES (N'76361663', N'Thạch rau câu LH 400g', 5, 25000.0000, 1, 1, CAST(N'2019-10-18T15:11:54.030' AS DateTime), N'Hung', 0)
INSERT [dbo].[Product] ([Barcode], [Name], [Quantity], [Price], [CategoryId], [SupplierId], [CreateAt], [CreateBy], [Pin]) VALUES (N'86302492', N'Sữa Vinamilk 1lit', 10, 40000.0000, 2, 1, CAST(N'2019-10-23T10:47:42.147' AS DateTime), N'Hung', 1)
INSERT [dbo].[Product] ([Barcode], [Name], [Quantity], [Price], [CategoryId], [SupplierId], [CreateAt], [CreateBy], [Pin]) VALUES (N'87960954', N'Thuốc lá Thăng Long 1 điếu', 10, 1000.0000, 2, 2, CAST(N'2019-10-23T10:41:17.793' AS DateTime), N'Hung', 1)
INSERT [dbo].[Product] ([Barcode], [Name], [Quantity], [Price], [CategoryId], [SupplierId], [CreateAt], [CreateBy], [Pin]) VALUES (N'89426446', N'Đường cát trắng 1kg', 5, 10000.0000, 1, 1, CAST(N'2019-10-21T10:42:33.660' AS DateTime), N'Hung', 0)
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([Id], [Name], [Address], [Contact1], [Contact2], [CreateAt], [CreateBy]) VALUES (1, N'Bibica sale', N'Ha Noi', N'So139 LY HD HN', NULL, CAST(N'2019-10-17T00:00:00.000' AS DateTime), N'Hung')
INSERT [dbo].[Supplier] ([Id], [Name], [Address], [Contact1], [Contact2], [CreateAt], [CreateBy]) VALUES (2, N'Hai ha sale', N'Hung Yen', N'Ngo 6 HN', NULL, CAST(N'2019-10-17T00:00:00.000' AS DateTime), N'Hung')
SET IDENTITY_INSERT [dbo].[Supplier] OFF
