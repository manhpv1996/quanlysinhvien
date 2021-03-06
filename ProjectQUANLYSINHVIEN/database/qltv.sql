USE [QuanLySinhVien]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 10/4/2018 5:10:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Tendangnhap] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Tendangnhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ketquahoctap]    Script Date: 10/4/2018 5:10:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ketquahoctap](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Masv] [nvarchar](50) NOT NULL,
	[Mamh] [nvarchar](50) NOT NULL,
	[Diem] [float] NOT NULL,
 CONSTRAINT [PK__Ketquaho__5A1CEDE17641E047] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Khoa]    Script Date: 10/4/2018 5:10:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khoa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Makhoa] [nvarchar](50) NOT NULL,
	[Tenkhoa] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Makhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ky]    Script Date: 10/4/2018 5:10:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ky](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Tenky] [int] NOT NULL,
 CONSTRAINT [PK_Ky] PRIMARY KEY CLUSTERED 
(
	[Tenky] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Loaimonhoc]    Script Date: 10/4/2018 5:10:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loaimonhoc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Tenloaimh] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Loaimonhoc] PRIMARY KEY CLUSTERED 
(
	[Tenloaimh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lop]    Script Date: 10/4/2018 5:10:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lop](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Malop] [nvarchar](50) NOT NULL,
	[Tenlop] [nvarchar](50) NOT NULL,
	[Makhoa] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Malop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Monhoc]    Script Date: 10/4/2018 5:10:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Monhoc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Mamh] [nvarchar](50) NOT NULL,
	[Tenmh] [nvarchar](100) NOT NULL,
	[Kyhoc] [int] NOT NULL,
	[Loaimonhoc] [nvarchar](50) NOT NULL,
	[Makhoa] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Mamh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 10/4/2018 5:10:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Masv] [nvarchar](50) NOT NULL,
	[Tensv] [nvarchar](50) NOT NULL,
	[Gioitinh] [int] NOT NULL,
	[Malop] [nvarchar](50) NOT NULL,
	[Diachi] [nvarchar](50) NOT NULL,
	[Image] [nvarchar](50) NULL,
 CONSTRAINT [PK__SinhVien__27240C228F3886E9] PRIMARY KEY CLUSTERED 
(
	[Masv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
