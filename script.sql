USE [master]
GO
/****** Object:  Database [PropertyBook]    Script Date: 4/11/2021 10:45:49 PM ******/
CREATE DATABASE [PropertyBook]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PropertyBook', FILENAME = N'/var/opt/mssql/data/PropertyBook.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PropertyBook_log', FILENAME = N'/var/opt/mssql/data/PropertyBook_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PropertyBook].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PropertyBook] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PropertyBook] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PropertyBook] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PropertyBook] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PropertyBook] SET ARITHABORT OFF 
GO
ALTER DATABASE [PropertyBook] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PropertyBook] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PropertyBook] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PropertyBook] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PropertyBook] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PropertyBook] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PropertyBook] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PropertyBook] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PropertyBook] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PropertyBook] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PropertyBook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PropertyBook] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PropertyBook] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PropertyBook] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PropertyBook] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PropertyBook] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [PropertyBook] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PropertyBook] SET RECOVERY FULL 
GO
ALTER DATABASE [PropertyBook] SET  MULTI_USER 
GO
ALTER DATABASE [PropertyBook] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PropertyBook] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PropertyBook] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PropertyBook] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PropertyBook] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PropertyBook', N'ON'
GO
USE [PropertyBook]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/11/2021 10:45:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Owner]    Script Date: 4/11/2021 10:45:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owner](
	[OwnerId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Photo] [nvarchar](max) NULL,
	[Birthday] [datetime2](7) NOT NULL,
	[PropertyId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Owner] PRIMARY KEY CLUSTERED 
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Property]    Script Date: 4/11/2021 10:45:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property](
	[PropertyId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Price] [real] NOT NULL,
	[CodeInternal] [int] NOT NULL,
	[Year] [int] NOT NULL,
 CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED 
(
	[PropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyImage]    Script Date: 4/11/2021 10:45:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyImage](
	[PropertyImageId] [uniqueidentifier] NOT NULL,
	[PropertyId] [uniqueidentifier] NOT NULL,
	[Photo] [nvarchar](max) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_PropertyImage] PRIMARY KEY CLUSTERED 
(
	[PropertyImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyTrace]    Script Date: 4/11/2021 10:45:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyTrace](
	[PropertyTraceId] [uniqueidentifier] NOT NULL,
	[DateSale] [datetime2](7) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Value] [real] NOT NULL,
	[Tax] [real] NOT NULL,
	[PropertyId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_PropertyTrace] PRIMARY KEY CLUSTERED 
(
	[PropertyTraceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210411034944_InitialMigration', N'5.0.4')
INSERT [dbo].[Property] ([PropertyId], [Name], [Address], [Price], [CodeInternal], [Year]) VALUES (N'f299117f-8d40-4a04-e135-08d8fd5aab50', N'Building Stars', N'Fake Street 123', 500000, 123, 1985)
INSERT [dbo].[Property] ([PropertyId], [Name], [Address], [Price], [CodeInternal], [Year]) VALUES (N'b78eee4e-bd48-479f-569d-08d8fd5bc4e1', N'Building 1', N'Address 1', 1000000, 10, 2000)
INSERT [dbo].[Property] ([PropertyId], [Name], [Address], [Price], [CodeInternal], [Year]) VALUES (N'844d4fd5-7d6f-4d93-569e-08d8fd5bc4e1', N'Building 2', N'Address 2', 2000000, 20, 2002)
INSERT [dbo].[Property] ([PropertyId], [Name], [Address], [Price], [CodeInternal], [Year]) VALUES (N'3cc1c8e2-7d3c-4427-569f-08d8fd5bc4e1', N'Building 3', N'Address 3', 3000000, 30, 2003)
INSERT [dbo].[Property] ([PropertyId], [Name], [Address], [Price], [CodeInternal], [Year]) VALUES (N'370b428e-6b79-45ac-56a0-08d8fd5bc4e1', N'Building 4', N'Address 4', 4000000, 40, 4003)
INSERT [dbo].[Property] ([PropertyId], [Name], [Address], [Price], [CodeInternal], [Year]) VALUES (N'75ed4dc5-212b-4780-56a1-08d8fd5bc4e1', N'Building 4', N'Address 4', 4000000, 40, 2004)
INSERT [dbo].[Property] ([PropertyId], [Name], [Address], [Price], [CodeInternal], [Year]) VALUES (N'b81c4378-d257-4333-56a2-08d8fd5bc4e1', N'Building 5', N'Address 5', 5000000, 50, 2005)
INSERT [dbo].[Property] ([PropertyId], [Name], [Address], [Price], [CodeInternal], [Year]) VALUES (N'733cb3e2-3fe4-464f-56a3-08d8fd5bc4e1', N'Building 5', N'Address 5', 5000000, 50, 2005)
INSERT [dbo].[Property] ([PropertyId], [Name], [Address], [Price], [CodeInternal], [Year]) VALUES (N'f0b442d2-d782-48cd-56a4-08d8fd5bc4e1', N'Building 6', N'Address 6', 6000000, 60, 2006)
INSERT [dbo].[Property] ([PropertyId], [Name], [Address], [Price], [CodeInternal], [Year]) VALUES (N'f91aa989-12c3-49ad-56a5-08d8fd5bc4e1', N'Building 7', N'Address 7', 7000000, 70, 2007)
INSERT [dbo].[Property] ([PropertyId], [Name], [Address], [Price], [CodeInternal], [Year]) VALUES (N'53c926a7-8c46-4237-56a6-08d8fd5bc4e1', N'Building 8', N'Address 8', 8000000, 80, 2008)
INSERT [dbo].[Property] ([PropertyId], [Name], [Address], [Price], [CodeInternal], [Year]) VALUES (N'05533611-5d28-4f51-56a7-08d8fd5bc4e1', N'Building 9', N'Address 9', 9000000, 90, 2009)
INSERT [dbo].[PropertyImage] ([PropertyImageId], [PropertyId], [Photo], [Enabled]) VALUES (N'db49eaf9-2bc0-4e87-54ee-08d8fd5ca189', N'f299117f-8d40-4a04-e135-08d8fd5aab50', N'97ab6768-ea75-4906-9f5a-7234cc955b95.jpg', 1)
INSERT [dbo].[PropertyImage] ([PropertyImageId], [PropertyId], [Photo], [Enabled]) VALUES (N'f299c9f7-8bf5-4a33-54ef-08d8fd5ca189', N'b78eee4e-bd48-479f-569d-08d8fd5bc4e1', N'd0ab9ebd-304f-441b-bb52-8e84c4d562ea.jpg', 1)
INSERT [dbo].[PropertyImage] ([PropertyImageId], [PropertyId], [Photo], [Enabled]) VALUES (N'18ffbee6-afe9-4424-54f0-08d8fd5ca189', N'844d4fd5-7d6f-4d93-569e-08d8fd5bc4e1', N'96134998-4e37-4857-b222-9ac96165e519.jpg', 1)
INSERT [dbo].[PropertyImage] ([PropertyImageId], [PropertyId], [Photo], [Enabled]) VALUES (N'3b6320fd-aaba-41c9-54f1-08d8fd5ca189', N'3cc1c8e2-7d3c-4427-569f-08d8fd5bc4e1', N'45c86f46-511d-459c-bd07-0cd78bdd3872.jpg', 1)
INSERT [dbo].[PropertyImage] ([PropertyImageId], [PropertyId], [Photo], [Enabled]) VALUES (N'85ed30fb-ee16-434c-54f2-08d8fd5ca189', N'370b428e-6b79-45ac-56a0-08d8fd5bc4e1', N'75033eb9-88f1-410c-b686-b0a60145d5c3.jpg', 1)
INSERT [dbo].[PropertyImage] ([PropertyImageId], [PropertyId], [Photo], [Enabled]) VALUES (N'cb579d30-4213-470c-54f3-08d8fd5ca189', N'75ed4dc5-212b-4780-56a1-08d8fd5bc4e1', N'1388dab0-e030-49c1-ae3e-dce6babd42ae.jpg', 1)
INSERT [dbo].[PropertyImage] ([PropertyImageId], [PropertyId], [Photo], [Enabled]) VALUES (N'5e92aa83-fa5c-46cf-54f4-08d8fd5ca189', N'b81c4378-d257-4333-56a2-08d8fd5bc4e1', N'5e647877-7df9-49d9-8a79-1384a0c3082b.jpg', 1)
/****** Object:  Index [IX_Owner_PropertyId]    Script Date: 4/11/2021 10:45:50 PM ******/
CREATE NONCLUSTERED INDEX [IX_Owner_PropertyId] ON [dbo].[Owner]
(
	[PropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyImage_PropertyId]    Script Date: 4/11/2021 10:45:50 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyImage_PropertyId] ON [dbo].[PropertyImage]
(
	[PropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyTrace_PropertyId]    Script Date: 4/11/2021 10:45:50 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyTrace_PropertyId] ON [dbo].[PropertyTrace]
(
	[PropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Owner]  WITH CHECK ADD  CONSTRAINT [FK_Owner_Property_PropertyId] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([PropertyId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Owner] CHECK CONSTRAINT [FK_Owner_Property_PropertyId]
GO
ALTER TABLE [dbo].[PropertyImage]  WITH CHECK ADD  CONSTRAINT [FK_PropertyImage_Property_PropertyId] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([PropertyId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PropertyImage] CHECK CONSTRAINT [FK_PropertyImage_Property_PropertyId]
GO
ALTER TABLE [dbo].[PropertyTrace]  WITH CHECK ADD  CONSTRAINT [FK_PropertyTrace_Property_PropertyId] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([PropertyId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PropertyTrace] CHECK CONSTRAINT [FK_PropertyTrace_Property_PropertyId]
GO
USE [master]
GO
ALTER DATABASE [PropertyBook] SET  READ_WRITE 
GO
