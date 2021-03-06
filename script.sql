/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2014 (12.0.2269)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [RealtyDB]    Script Date: 2.01.2018 22:37:10 ******/
CREATE DATABASE [RealtyDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmlakDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\EmlakDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EmlakDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\EmlakDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [RealtyDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RealtyDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RealtyDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RealtyDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RealtyDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RealtyDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RealtyDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [RealtyDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RealtyDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RealtyDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RealtyDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RealtyDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RealtyDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RealtyDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RealtyDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RealtyDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RealtyDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RealtyDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RealtyDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RealtyDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RealtyDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RealtyDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RealtyDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RealtyDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RealtyDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RealtyDB] SET  MULTI_USER 
GO
ALTER DATABASE [RealtyDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RealtyDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RealtyDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RealtyDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [RealtyDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [RealtyDB]
GO
/****** Object:  Table [dbo].[Ads]    Script Date: 2.01.2018 22:37:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ads](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Currency] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Type] [int] NOT NULL,
	[Area] [int] NOT NULL,
	[Lat] [float] NULL,
	[Lang] [float] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currencies]    Script Date: 2.01.2018 22:37:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currencies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2.01.2018 22:37:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserRoles] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statues]    Script Date: 2.01.2018 22:37:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statues](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Statues] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Types]    Script Date: 2.01.2018 22:37:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Types](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Types] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2.01.2018 22:37:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [int] NOT NULL,
	[Role] [int] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Ads] ON 

INSERT [dbo].[Ads] ([Id], [Title], [Status], [Price], [Currency], [Description], [Type], [Area], [Lat], [Lang]) VALUES (1, N'A New House!', 1, 150000, 1, N'Really cheap', 1, 150, 40.927773, 29.129965)
INSERT [dbo].[Ads] ([Id], [Title], [Status], [Price], [Currency], [Description], [Type], [Area], [Lat], [Lang]) VALUES (2, N'An Old House!', 2, 2000, 2, N'Really old', 1, 320, 40.928377, 29.130255)
INSERT [dbo].[Ads] ([Id], [Title], [Status], [Price], [Currency], [Description], [Type], [Area], [Lat], [Lang]) VALUES (11, N'A New Apartment!', 1, 250000, 3, N'Really clean', 2, 10, 40.928811, 29.129571)
INSERT [dbo].[Ads] ([Id], [Title], [Status], [Price], [Currency], [Description], [Type], [Area], [Lat], [Lang]) VALUES (9, N'An Old Apartment!', 2, 3500, 4, N'Really comfortable', 2, 235, 40.929273, 29.129067)
INSERT [dbo].[Ads] ([Id], [Title], [Status], [Price], [Currency], [Description], [Type], [Area], [Lat], [Lang]) VALUES (12, N'A New Store!', 1, 180000, 5, N'Really exist', 5, 453, 40.928913, 29.128579)
INSERT [dbo].[Ads] ([Id], [Title], [Status], [Price], [Currency], [Description], [Type], [Area], [Lat], [Lang]) VALUES (13, N'An Old Store!', 2, 500, 1, N'Really warm', 5, 200, 40.929264, 29.1272)
INSERT [dbo].[Ads] ([Id], [Title], [Status], [Price], [Currency], [Description], [Type], [Area], [Lat], [Lang]) VALUES (14, N'A New Building!', 1, 1000000, 2, N'Really new', 3, 2500, 40.930243, 29.127267)
INSERT [dbo].[Ads] ([Id], [Title], [Status], [Price], [Currency], [Description], [Type], [Area], [Lat], [Lang]) VALUES (16, N'An Old Building!', 2, 15000, 3, N'Really cold', 3, 2250, 40.936072, 29.122845)
INSERT [dbo].[Ads] ([Id], [Title], [Status], [Price], [Currency], [Description], [Type], [Area], [Lat], [Lang]) VALUES (17, N'A New Lot!', 1, 13000, 4, N'Really empty', 4, 1500, 40.937992, 29.113153)
INSERT [dbo].[Ads] ([Id], [Title], [Status], [Price], [Currency], [Description], [Type], [Area], [Lat], [Lang]) VALUES (18, N'An Old Lot!', 2, 1300, 5, N'Really small', 4, 50, 40.94408, 29.112674)
SET IDENTITY_INSERT [dbo].[Ads] OFF
SET IDENTITY_INSERT [dbo].[Currencies] ON 

INSERT [dbo].[Currencies] ([Id], [Description]) VALUES (1, N'Euro')
INSERT [dbo].[Currencies] ([Id], [Description]) VALUES (2, N'Dollar')
INSERT [dbo].[Currencies] ([Id], [Description]) VALUES (3, N'Pound')
INSERT [dbo].[Currencies] ([Id], [Description]) VALUES (4, N'Lira')
INSERT [dbo].[Currencies] ([Id], [Description]) VALUES (5, N'Yang')
SET IDENTITY_INSERT [dbo].[Currencies] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [UserRoles]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([Id], [UserRoles]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Statues] ON 

INSERT [dbo].[Statues] ([Id], [Description]) VALUES (1, N'Sale')
INSERT [dbo].[Statues] ([Id], [Description]) VALUES (2, N'Rent')
INSERT [dbo].[Statues] ([Id], [Description]) VALUES (3, N'Closed')
SET IDENTITY_INSERT [dbo].[Statues] OFF
SET IDENTITY_INSERT [dbo].[Types] ON 

INSERT [dbo].[Types] ([Id], [Description]) VALUES (1, N'House')
INSERT [dbo].[Types] ([Id], [Description]) VALUES (2, N'Apartment')
INSERT [dbo].[Types] ([Id], [Description]) VALUES (3, N'Building')
INSERT [dbo].[Types] ([Id], [Description]) VALUES (4, N'Lot')
INSERT [dbo].[Types] ([Id], [Description]) VALUES (5, N'Store')
SET IDENTITY_INSERT [dbo].[Types] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (1, N'admin', 123456, 1)
INSERT [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (2, N'user', 654321, 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Ads]  WITH CHECK ADD  CONSTRAINT [FK_Ads_Currencies] FOREIGN KEY([Currency])
REFERENCES [dbo].[Currencies] ([Id])
GO
ALTER TABLE [dbo].[Ads] CHECK CONSTRAINT [FK_Ads_Currencies]
GO
ALTER TABLE [dbo].[Ads]  WITH CHECK ADD  CONSTRAINT [FK_Ads_Statues] FOREIGN KEY([Status])
REFERENCES [dbo].[Statues] ([Id])
GO
ALTER TABLE [dbo].[Ads] CHECK CONSTRAINT [FK_Ads_Statues]
GO
ALTER TABLE [dbo].[Ads]  WITH CHECK ADD  CONSTRAINT [FK_Ads_Types] FOREIGN KEY([Type])
REFERENCES [dbo].[Types] ([Id])
GO
ALTER TABLE [dbo].[Ads] CHECK CONSTRAINT [FK_Ads_Types]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([Role])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
USE [master]
GO
ALTER DATABASE [RealtyDB] SET  READ_WRITE 
GO
