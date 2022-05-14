USE [master]
GO
/****** Object:  Database [Artist]    Script Date: 14/05/2022 9:18:32 CH ******/
CREATE DATABASE [Artist]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Artist', FILENAME = N'E:\SQL\Microsoft SQL SERVER\MSSQL15.SQLEXPRESS\MSSQL\DATA\Artist.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Artist_log', FILENAME = N'E:\SQL\Microsoft SQL SERVER\MSSQL15.SQLEXPRESS\MSSQL\DATA\Artist_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Artist] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Artist].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Artist] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Artist] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Artist] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Artist] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Artist] SET ARITHABORT OFF 
GO
ALTER DATABASE [Artist] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Artist] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Artist] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Artist] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Artist] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Artist] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Artist] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Artist] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Artist] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Artist] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Artist] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Artist] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Artist] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Artist] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Artist] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Artist] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Artist] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Artist] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Artist] SET  MULTI_USER 
GO
ALTER DATABASE [Artist] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Artist] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Artist] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Artist] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Artist] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Artist] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Artist] SET QUERY_STORE = OFF
GO
USE [Artist]
GO
/****** Object:  User [nvh2001]    Script Date: 14/05/2022 9:18:32 CH ******/
CREATE USER [nvh2001] FOR LOGIN [nvh2001] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Album]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album](
	[AlbumID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ReleaseDay] [date] NOT NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[AlbumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlbumImage]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlbumImage](
	[AlbumImageID] [int] IDENTITY(1,1) NOT NULL,
	[ImageID] [int] NOT NULL,
	[AlbumID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AlbumImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlbumSong]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlbumSong](
	[AlbumSongID] [int] IDENTITY(1,1) NOT NULL,
	[SongID] [int] NOT NULL,
	[AlbumID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AlbumSongID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Artist]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artist](
	[ArtistID] [int] IDENTITY(1,1) NOT NULL,
	[StageName] [nvarchar](50) NOT NULL,
	[RealName] [nvarchar](50) NOT NULL,
	[BirthDay] [date] NOT NULL,
	[BirthPlace] [nvarchar](100) NULL,
	[DebutDay] [date] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[FandomID] [int] NOT NULL,
	[Height] [float] NULL,
	[Weight] [float] NULL,
	[IsActivate] [bit] NOT NULL,
	[LabelID] [int] NOT NULL,
	[SnsID] [int] NOT NULL,
	[Gender] [bit] NOT NULL,
 CONSTRAINT [PK__Artist__25706B7016F2C4F6] PRIMARY KEY CLUSTERED 
(
	[ArtistID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArtistGroup]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArtistGroup](
	[ArtistGroupID] [int] IDENTITY(1,1) NOT NULL,
	[GroupID] [int] NOT NULL,
	[ArtistID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ArtistGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArtistImage]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArtistImage](
	[ArtistImageID] [int] IDENTITY(1,1) NOT NULL,
	[ImageID] [int] NOT NULL,
	[ArtistID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ArtistImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArtistSong]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArtistSong](
	[ArtistSongID] [int] IDENTITY(1,1) NOT NULL,
	[SongID] [int] NOT NULL,
	[ArtistID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ArtistSongID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fandom]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fandom](
	[FandomID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[FandomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DebutDay] [date] NOT NULL,
	[FandomID] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[LabelID] [int] NULL,
	[SnsID] [int] NULL,
	[IsActivate] [bit] NULL,
 CONSTRAINT [PK__Group__149AF30A48D6A1B6] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupImage]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupImage](
	[GroupImageID] [int] IDENTITY(1,1) NOT NULL,
	[ImageID] [int] NOT NULL,
	[GroupID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GroupImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupSong]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupSong](
	[GroupSongID] [int] IDENTITY(1,1) NOT NULL,
	[SongID] [int] NOT NULL,
	[GroupID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GroupSongID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[ImageID] [int] IDENTITY(1,1) NOT NULL,
	[ImageURL] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Label]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Label](
	[LabelID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Founder] [nvarchar](100) NOT NULL,
	[Founded] [date] NOT NULL,
	[Location] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[LabelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SNS]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SNS](
	[SnsID] [int] IDENTITY(1,1) NOT NULL,
	[Youtube] [nvarchar](max) NULL,
	[Instagram] [nvarchar](max) NULL,
	[Facebook] [nvarchar](max) NULL,
	[Twitter] [nvarchar](max) NULL,
	[Tiktok] [nvarchar](max) NULL,
	[Vlive] [nvarchar](max) NULL,
	[AppleMusic] [nvarchar](max) NULL,
	[Spotify] [nvarchar](max) NULL,
	[Website] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[SnsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Song]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Song](
	[SongID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ReleaseDay] [date] NOT NULL,
	[Genre] [nvarchar](100) NULL,
	[Producer] [nvarchar](200) NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[SongID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SongImage]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SongImage](
	[SongImageID] [int] IDENTITY(1,1) NOT NULL,
	[ImageID] [int] NOT NULL,
	[SongID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SongImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestRegister]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestRegister](
	[username] [varchar](100) NOT NULL,
	[password] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [varchar](10) NOT NULL,
	[UserName] [varchar](30) NOT NULL,
	[Password] [varchar](30) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[PhoneNumber] [varchar](30) NULL,
	[Description] [nvarchar](500) NULL,
	[Birthday] [date] NOT NULL,
	[Role] [int] NOT NULL,
	[isBan] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Album] ON 

INSERT [dbo].[Album] ([AlbumID], [Name], [ReleaseDay], [Description]) VALUES (1, N'Heartbreaker', CAST(N'2009-08-19' AS Date), N'Heartbreaker là album solo đầu tay của nghệ sĩ Hàn Quốc G-Dragon, thành viên và trưởng nhóm nhạc Big Bang. Album được phát hành vào ngày 19 tháng 8 năm 2009 thông qua hãng đĩa YG Entertainment. Đĩa đơn chủ đề "Heartbreaker" đứng đầu nhiều bảng xếp hạng âm nhạc lớn của Hàn Quốc ngay sau khi ra mắt.Tới nay album đã bán ra trên 285.000 bản tại Hàn Quốc.')
INSERT [dbo].[Album] ([AlbumID], [Name], [ReleaseDay], [Description]) VALUES (1003, N'AD Mare', CAST(N'2022-02-22' AS Date), N'"Ad Mare" (cách điệu trong tất cả các mũ) là album đơn đầu tay của NMIXX. Nó được phát hành vào ngày 22 tháng 2 năm 2022 với "O.O" đóng vai trò là ca khúc chủ đề của đĩa đơn.
Album vật lý có hai phiên bản: Light và phiên bản giới hạn và độc quyền được gọi là Blind Package.')
SET IDENTITY_INSERT [dbo].[Album] OFF
GO
SET IDENTITY_INSERT [dbo].[AlbumSong] ON 

INSERT [dbo].[AlbumSong] ([AlbumSongID], [SongID], [AlbumID]) VALUES (1, 1, 1)
INSERT [dbo].[AlbumSong] ([AlbumSongID], [SongID], [AlbumID]) VALUES (2, 2, 1)
INSERT [dbo].[AlbumSong] ([AlbumSongID], [SongID], [AlbumID]) VALUES (1005, 6, 1003)
INSERT [dbo].[AlbumSong] ([AlbumSongID], [SongID], [AlbumID]) VALUES (1006, 7, 1003)
SET IDENTITY_INSERT [dbo].[AlbumSong] OFF
GO
SET IDENTITY_INSERT [dbo].[Artist] ON 

INSERT [dbo].[Artist] ([ArtistID], [StageName], [RealName], [BirthDay], [BirthPlace], [DebutDay], [Description], [FandomID], [Height], [Weight], [IsActivate], [LabelID], [SnsID], [Gender]) VALUES (1, N'G-Dragon', N'Kwon Ji-young', CAST(N'1988-08-18' AS Date), N'Seoul, Hàn Quốc', CAST(N'2022-05-04' AS Date), N'Kwon Ji-yong (tiếng Hàn: 권지용; Hanja: 權志龍; Hán-Việt: Quyền Chí Long, sinh ngày 18 tháng 8 năm 1988), thường được biết đến với nghệ danh G-Dragon, là một nam rapper, ca sĩ, nhạc sĩ và nhà sản xuất thu âm người Hàn Quốc. Anh được mệnh danh là "Ông hoàng K-pop". G-Dragon được đào tạo trong sáu năm, từ năm 12 tuổi, tại công ty giải trí YG Entertainment trước khi ra mắt vào năm 2006 với tư cách là thủ lĩnh nhóm nhạc Big Bang, một trong những nhóm nhạc nam bán đĩa nhạc chạy nhất thế giới.

Album solo đầu tay của anh Heartbreaker và ca khúc chủ đề cùng tên, phát hành năm 2009, là thành công về mặt thương mại, trở thành album bán chạy nhất của một nghệ sĩ solo Hàn Quốc vào thời điểm đó và giành giải Album của năm tại lễ trao giải thưởng Âm nhạc Châu Á Mnet 2009. G-Dragon cùng với thành viên cùng nhóm T.O.P phát hành album GD & TOP vào năm 2010. EP đầu tay của anh One of a Kind (2012), được giới phê bình đánh giá cao bao gồm ba đĩa đơn: "One of a Kind", "Crayon" và đĩa đơn quán quân "That XX". EP này đã giành được Bản thu âm của năm tại lễ trao giải thưởng âm nhạc Seoul 2013. Năm 2013, anh bắt đầu chuyến lưu diễn toàn thế giới đầu tiên của mình với tư cách là một nghệ sĩ solo, giúp anh trở thành nghệ sĩ solo Hàn Quốc đầu tiên lưu diễn các sân vận động mái vòm của Nhật Bản. G-Dragon được trao giải Nghệ sĩ của năm tại lễ trao giải thưởng Âm nhạc Châu Á Mnet 2013 sau thành công của album thứ hai Coup d''Etat (2013). EP năm 2017 của anh, Kwon Ji Yong, gồm đĩa đơn quán quân "Untitled, 2014" và chuyến lưu diễn quảng bá Act III: M.O.T.T.E trở thành chuyến lưu diễn lớn nhất từng được thực hiện bởi một nghệ sĩ solo Hàn Quốc.

Được công nhận rộng rãi vì tầm ảnh hưởng của anh đối với văn hóa, xu hướng thời trang và âm nhạc của giới trẻ Hàn Quốc, G-Dragon được Forbes bình chọn là người dưới 30 tuổi có ảnh hưởng nhất trong làng giải trí và thể thao châu Á năm 2016. G-Dragon đã viết và đồng sáng tác 23 ca khúc số một trên Gaon Digital Chart, hầu hết trong số đó anh cũng đồng sản xuất.', 1, 1.8200000524520874, 65, 1, 1, 2, 1)
INSERT [dbo].[Artist] ([ArtistID], [StageName], [RealName], [BirthDay], [BirthPlace], [DebutDay], [Description], [FandomID], [Height], [Weight], [IsActivate], [LabelID], [SnsID], [Gender]) VALUES (32, N'Haewon', N'Oh Haewon', CAST(N'2003-02-25' AS Date), N'Namdong-gu, Incheon, Hàn Quốc', CAST(N'2022-02-22' AS Date), N'Vào ngày 9 tháng 7 năm 2021, một teaser đã được tiết lộ, chứa cụm từ "Nhóm nhạc nữ được yêu thích tiếp theo của bạn" làm dấy lên tin đồn rằng JYP Entertainment sẽ sớm ra mắt một nhóm nhạc nữ mới (bây giờ được biết đến là NMIXX.) Vào ngày 5 tháng 11, Haewon được tiết lộ là thành viên thứ sáu của nhóm thông qua bản cover "I Love You 3000" của Stephanie Poetri. ', 8, 1.6399999856948853, 48, 1, 3, 43, 0)
INSERT [dbo].[Artist] ([ArtistID], [StageName], [RealName], [BirthDay], [BirthPlace], [DebutDay], [Description], [FandomID], [Height], [Weight], [IsActivate], [LabelID], [SnsID], [Gender]) VALUES (33, N'Yeji', N'Hwang Ye-ji', CAST(N'2000-05-26' AS Date), N'Jeonju, Bắc Jeolla, Hàn Quốc', CAST(N'2019-02-12' AS Date), N'Yeji (예지) là một rapper, vũ công và ca sĩ hàn Quốc thuộc JYP Entertainment. Cô là trưởng nhóm của nhóm nhạc nữ ITZY.

Yeji tham gia bộ phim truyền hình cạnh tranh thực tế của SBS The Fan, nhưng đã bị loại trong tập 5.

Vào ngày 20 tháng 1, cô đã được tiết lộ, cùng với các thành viên khác, là thành viên của ITZY, nhóm nhạc nữ mới nhất của JYP Entertainment. Họ ra mắt vào ngày 12 tháng 2 với đĩa đơn kỹ thuật số "IT''z Different".', 3, 1.6699999570846558, 48, 1, 3, 44, 0)
INSERT [dbo].[Artist] ([ArtistID], [StageName], [RealName], [BirthDay], [BirthPlace], [DebutDay], [Description], [FandomID], [Height], [Weight], [IsActivate], [LabelID], [SnsID], [Gender]) VALUES (34, N'Yuna', N'Oh Yuna', CAST(N'2022-05-14' AS Date), N'vn', CAST(N'2019-05-14' AS Date), N'mô tả', 3, 0, 0, 1, 3, 45, 0)
SET IDENTITY_INSERT [dbo].[Artist] OFF
GO
SET IDENTITY_INSERT [dbo].[ArtistGroup] ON 

INSERT [dbo].[ArtistGroup] ([ArtistGroupID], [GroupID], [ArtistID]) VALUES (1, 1, 1)
INSERT [dbo].[ArtistGroup] ([ArtistGroupID], [GroupID], [ArtistID]) VALUES (2, 6, 1)
INSERT [dbo].[ArtistGroup] ([ArtistGroupID], [GroupID], [ArtistID]) VALUES (1006, 20, 32)
INSERT [dbo].[ArtistGroup] ([ArtistGroupID], [GroupID], [ArtistID]) VALUES (1007, 3, 34)
INSERT [dbo].[ArtistGroup] ([ArtistGroupID], [GroupID], [ArtistID]) VALUES (1008, 6, 34)
INSERT [dbo].[ArtistGroup] ([ArtistGroupID], [GroupID], [ArtistID]) VALUES (1009, 4, 34)
SET IDENTITY_INSERT [dbo].[ArtistGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[ArtistImage] ON 

INSERT [dbo].[ArtistImage] ([ArtistImageID], [ImageID], [ArtistID]) VALUES (1, 1, 1)
INSERT [dbo].[ArtistImage] ([ArtistImageID], [ImageID], [ArtistID]) VALUES (2, 2, 1)
INSERT [dbo].[ArtistImage] ([ArtistImageID], [ImageID], [ArtistID]) VALUES (10, 12, 1)
INSERT [dbo].[ArtistImage] ([ArtistImageID], [ImageID], [ArtistID]) VALUES (13, 14, 32)
INSERT [dbo].[ArtistImage] ([ArtistImageID], [ImageID], [ArtistID]) VALUES (14, 15, 32)
INSERT [dbo].[ArtistImage] ([ArtistImageID], [ImageID], [ArtistID]) VALUES (15, 16, 32)
INSERT [dbo].[ArtistImage] ([ArtistImageID], [ImageID], [ArtistID]) VALUES (16, 17, 33)
INSERT [dbo].[ArtistImage] ([ArtistImageID], [ImageID], [ArtistID]) VALUES (17, 18, 33)
INSERT [dbo].[ArtistImage] ([ArtistImageID], [ImageID], [ArtistID]) VALUES (18, 19, 34)
INSERT [dbo].[ArtistImage] ([ArtistImageID], [ImageID], [ArtistID]) VALUES (20, 4, 34)
SET IDENTITY_INSERT [dbo].[ArtistImage] OFF
GO
SET IDENTITY_INSERT [dbo].[ArtistSong] ON 

INSERT [dbo].[ArtistSong] ([ArtistSongID], [SongID], [ArtistID]) VALUES (1, 1, 1)
INSERT [dbo].[ArtistSong] ([ArtistSongID], [SongID], [ArtistID]) VALUES (2, 2, 1)
INSERT [dbo].[ArtistSong] ([ArtistSongID], [SongID], [ArtistID]) VALUES (3, 3, 1)
INSERT [dbo].[ArtistSong] ([ArtistSongID], [SongID], [ArtistID]) VALUES (1006, 3, 34)
INSERT [dbo].[ArtistSong] ([ArtistSongID], [SongID], [ArtistID]) VALUES (1007, 4, 34)
INSERT [dbo].[ArtistSong] ([ArtistSongID], [SongID], [ArtistID]) VALUES (1008, 6, 34)
INSERT [dbo].[ArtistSong] ([ArtistSongID], [SongID], [ArtistID]) VALUES (1009, 7, 34)
SET IDENTITY_INSERT [dbo].[ArtistSong] OFF
GO
SET IDENTITY_INSERT [dbo].[Fandom] ON 

INSERT [dbo].[Fandom] ([FandomID], [Name], [Description]) VALUES (0, N'Không có', NULL)
INSERT [dbo].[Fandom] ([FandomID], [Name], [Description]) VALUES (1, N'V.I.P', N'Fandom của BigBang')
INSERT [dbo].[Fandom] ([FandomID], [Name], [Description]) VALUES (2, N'Army', N'Fandom của BTS')
INSERT [dbo].[Fandom] ([FandomID], [Name], [Description]) VALUES (3, N'Midzy', N'Fandom của Itzy')
INSERT [dbo].[Fandom] ([FandomID], [Name], [Description]) VALUES (4, N'Once', N'Fandom của Twice')
INSERT [dbo].[Fandom] ([FandomID], [Name], [Description]) VALUES (5, N'Blink', N'Fandom của Blackpink')
INSERT [dbo].[Fandom] ([FandomID], [Name], [Description]) VALUES (6, N'Sone', N'Fandom của SNSD')
INSERT [dbo].[Fandom] ([FandomID], [Name], [Description]) VALUES (7, N'Dive', N'Fandom của IVE')
INSERT [dbo].[Fandom] ([FandomID], [Name], [Description]) VALUES (8, N'Snwer', N'Fandom của Nmixx')
INSERT [dbo].[Fandom] ([FandomID], [Name], [Description]) VALUES (9, N'NCTZen', N'Fandom của NCT')
INSERT [dbo].[Fandom] ([FandomID], [Name], [Description]) VALUES (10, N'Stay', N'Fandom của StrayKids')
INSERT [dbo].[Fandom] ([FandomID], [Name], [Description]) VALUES (11, N'EXO-L', N'Fandom của EXO')
INSERT [dbo].[Fandom] ([FandomID], [Name], [Description]) VALUES (12, N'YOUNG ONE', N'Fandom của TXT')
INSERT [dbo].[Fandom] ([FandomID], [Name], [Description]) VALUES (13, N'ENGENE', N'Fandom của ENHYPEN')
INSERT [dbo].[Fandom] ([FandomID], [Name], [Description]) VALUES (14, N'Treasure Maker', N'Fandom của Treasure')
INSERT [dbo].[Fandom] ([FandomID], [Name], [Description]) VALUES (15, N'iKONNIC', N'Fandom của iKON')
INSERT [dbo].[Fandom] ([FandomID], [Name], [Description]) VALUES (16, N'FLOVER', N'Fandom của Fromis_9')
INSERT [dbo].[Fandom] ([FandomID], [Name], [Description]) VALUES (17, N'ReVeluv', N'Fandom của Redvelvet')
INSERT [dbo].[Fandom] ([FandomID], [Name], [Description]) VALUES (18, N'Ujung', N'Fandom của WJSN')
INSERT [dbo].[Fandom] ([FandomID], [Name], [Description]) VALUES (19, N'Neverland', N'Fandom của (G)-IDLE')
INSERT [dbo].[Fandom] ([FandomID], [Name], [Description]) VALUES (20, N'InnerCircle', N'Fandom của Winner')
INSERT [dbo].[Fandom] ([FandomID], [Name], [Description]) VALUES (21, N'Uaena', N'Chín năm sau khi ra mắt, IU cuối cùng đã đặt tên cho cơ sở người hâm mộ của mình, Uaena. “You” (U) là từ tiếng Anh, “ae” (爱) là từ Hán-Hàn nghĩa là “tình yêu”, và “na” (나) là tiếng Hàn có nghĩa là “tôi”. Fancafe của IU từng được gọi là Uaena và theo thời gian, fan của IU được gọi là uaena')
SET IDENTITY_INSERT [dbo].[Fandom] OFF
GO
SET IDENTITY_INSERT [dbo].[Group] ON 

INSERT [dbo].[Group] ([GroupID], [Name], [DebutDay], [FandomID], [Description], [LabelID], [SnsID], [IsActivate]) VALUES (1, N'BigBang', CAST(N'2006-08-19' AS Date), 1, N'Big Bang (Hàn: 빅뱅; Romaja: Big Baeng; cách điệu là BIGBANG), là một nhóm nhạc nam Hàn Quốc được thành lập bởi YG Entertainment. Nhóm bao gồm 5 thành viên G-Dragon, T.O.P, Taeyang, Daesung và Seungri.
Big Bang được biết đến lần đầu tiên qua những tập phim tài liệu ghi lại quá trình hình thành nhóm được chiếu trên TV với tựa đề The Big Bang Documentary từ tháng 7 đến tháng 8 năm 2006. Những tập phim này cũng được phát lại trên GomTV và MTV Hàn Quốc. Thời điểm này nhóm có 6 thành viên, sau đó thành viên SO-1 (Jang Hyun Seung) đã phải rời khỏi nhóm trong lúc các tập tài liệu đang phát sóng trước khi nhóm chính thức ra mắt. Đội hình ra mắt gồm 5 thành viên bao gồm G-Dragon, T.O.P, Taeyang, Daesung và Seungri.
Dưới sự dẫn dắt của YG Entertainment, Big Bang liên tiếp phát hành những chuỗi đĩa đơn và EP nhưng chỉ đạt được những thành công khiêm tốn. Nhóm chỉ thực sự đột phá với EP Always được phát hành vào năm 2007, cùng với đĩa đơn số một của họ là "Lies" (Tiếng Triều Tiên: 거짓말; Romaja quốc ngữ: Geojitmal). Những EP tiếp theo Hot Issue và Stand Up tiếp tục khẳng định vị trí của họ trong số những nhóm nhạc hip-hop hàng đầu tại Hàn Quốc. Sau khi nhận giải "Nghệ sĩ của năm" của chương trình Mnet KM Music Festival và giải thưởng "Seoul Gayo Daesang", nhóm mở rộng hoạt động sang thị trường Nhật Bản bằng việc phát hành một số mini album và đĩa đơn được phát sóng trên các kênh truyền thông. Tuy nhiên, những sản phẩm này không có được bất kỳ sự quảng bá nào cho đến khi đĩa đơn chính thức đầu tiên tại Nhật Bản của họ là My Heaven phát hành vào năm kế tiếp. Họ sau đó tiếp tục ra mắt tại Nhật 2 album gồm: Big Bang (2009), Big Bang 2 (2011). Trong thời gian quảng bá tại Nhật Bản, các thành viên bắt đầu thực hiện các dự án solo như các album và EP của Taeyang và G-Dragon, G-Dragon và T.O.P hợp tác với tên GD & TOP.
Sau hai năm vắng bóng tại Hàn Quốc, Big Bang trở lại vào năm 2011 với album Tonight. Tuy nhiên các hoạt động quảng bá bất ngờ bị gián đoạn bởi những rắc rối liên quan đến pháp luật của các thành viên. Tháng 11 năm 2011 tại Belfast, Bắc Ireland, Big Bang đại diện cho khu vực châu Á Thái Bình Dương tham dự giải thưởng âm nhạc MTV Europe Music Awards 2011 và giành chiến thắng ở hạng mục Best Worldwide Act nhờ 58 triệu lượt phiếu bầu của người hâm mộ. Ba tháng sau chiến thắng tại châu Âu, Big Bang ra mắt album thành công nhất của mình, Alive, album tiếng Hàn đầu tiên được xếp hạng trên Billboard 200, trước khi bắt đầu chuyến lưu diễn vòng quanh thế giới đầu tiên. Vào năm 2015, Big Bang ra mắt bốn album đĩa đơn, "M," "A," "D," và "E,", mở đường cho album Made. Các bài hát trong các đĩa đơn giúp ban nhạc mang về nhiều thành công về thương mại và giành giải Nghệ sĩ của năm tại MAMA 2015.', 1, 1, 1)
INSERT [dbo].[Group] ([GroupID], [Name], [DebutDay], [FandomID], [Description], [LabelID], [SnsID], [IsActivate]) VALUES (3, N'BlackPink', CAST(N'2016-08-08' AS Date), 5, N'Blackpink (tiếng Hàn: 블랙핑크; thường được viết cách điệu là BLACKPINK hoặc BLΛƆKPIИK) là nhóm nhạc nữ Hàn Quốc do công ty YG Entertainment thành lập và quản lý. Nhóm gồm 4 thành viên Jisoo, Jennie, Rosé, Lisa. Blackpink chính thức ra mắt với album đĩa đơn đầu tay mang tên Square One gồm hai ca khúc "Boombayah" và "Whistle". Cả hai sau đó đã lọt vào bảng xếp hạng World Digital Songs của Billboard và bảng xếp hạng nhạc số Gaon của Hàn Quốc.

Blackpink là nhóm nhạc nữ Hàn Quốc có thứ hạng cao nhất trên bảng xếp hạng Billboard Hot 100 khi đạt vị trí thứ 13 với "Ice Cream" (2020) và trên Billboard 200 với The Album (2020) ở vị trí thứ hai. Blackpink là nhóm nhạc nữ K-pop đầu tiên lọt vào và dẫn đầu bảng xếp hạng Emerging Artists của Billboard đồng thời sở hữu ba đĩa đơn quán quân trên bảng xếp hạng World Digital Song Sales của Billboard. Họ cũng là nhóm nhạc nữ Hàn Quốc đầu tiên nhận được chứng nhận từ Hiệp hội Công nghiệp ghi âm Hoa Kỳ (RIAA) cho đĩa đơn "Ddu-Du Ddu-Du" (2018) – video âm nhạc có nhiều lượt xem nhất trên YouTube của một nhóm nhạc Hàn Quốc. Blackpink cũng là nhóm sở hữu số lượng bài hát lọt vào top 40 tại Vương quốc Anh nhiều nhất. Ca khúc "Kiss and Make Up" là bài hát đầu tiên của một nhóm nhạc nữ Hàn Quốc nhận được chứng nhận từ British Phonographic Industry và được chứng nhận đĩa bạch kim bởi Hiệp hội Công nghiệp Ghi âm Úc (ARIA).

Nhóm đã phá vỡ nhiều kỷ lục trực tuyến trong suốt quãng thời gian hoạt động. Các video âm nhạc "Kill This Love" (2019) và "How You Like That" (2020) đều từng lập kỷ lục video âm nhạc được xem nhiều nhất trong vòng 24 giờ đầu tiên kể từ khi phát hành trên nền tảng phát video trực tuyến YouTube, trong đó "How You Like That" phá ba và thiết lập hai kỷ lục Guinness thế giới. Nhóm cũng trở thành nhóm nhạc Kpop đầu tiên có năm video âm nhạc ("Ddu-Du Ddu-Du", "Kill This Love" "Boombayah", "As If It''s Your Last", "How You Like That") đạt 1 tỷ lượt xem trên nền tảng này. Blackpink hiện là nhóm nhạc nữ có số lượt theo dõi nhiều nhất trên Spotify và là nhóm nhạc, nghệ sĩ nữ và nghệ sĩ châu Á có số lượt đăng ký nhiều nhất ở nền tảng YouTube trên toàn cầu.

Các giải thưởng khác của Blackpink bao gồm chiến thắng ở hạng mục "Nghệ sĩ mới của năm" tại lễ trao giải Golden Disc Awards lần thứ 31 và Seoul Music Awards lần thứ 26. Họ được tạp chí Forbes Korea công nhận là một trong những người nổi tiếng quyền lực nhất Hàn Quốc, xếp thứ nhất vào năm 2019, thứ ba vào năm 2020, thứ hai vào năm 2021[12] và là nhóm nhạc nữ Hàn Quốc đầu tiên lọt vào danh sách 30 gương mặt xuất sắc nhất dưới 30 tuổi của Forbes. Blackpink cũng là nhóm nhạc nữ K-pop đầu tiên giành giải tại Giải Video âm nhạc của MTV.', 1, 0, 1)
INSERT [dbo].[Group] ([GroupID], [Name], [DebutDay], [FandomID], [Description], [LabelID], [SnsID], [IsActivate]) VALUES (4, N'Twice', CAST(N'2015-05-05' AS Date), 4, N'Twice (tiếng Hàn: 트와이스; Romaja: Teuwaiseu; tiếng Nhật: トゥワイス, Hepburn: To~uwaisu; thường được viết cách điệu là TWICE) là một nhóm nhạc nữ Hàn Quốc được thành lập bởi JYP Entertainment. Nhóm bao gồm 9 thành viên: Nayeon, Jeongyeon, Momo, Sana, Jihyo, Mina, Dahyun, Chaeyoung và Tzuyu. Twice được thành lập trong chương trình truyền hình Sixteen và chính thức ra mắt vào ngày 20 tháng 10 năm 2015, với EP The Story Begins.

Twice trở nên nổi tiếng trong nước vào năm 2016 với đĩa đơn "Cheer Up", đứng ở vị trí số một trên Gaon Digital Chart, trở thành đĩa đơn có thành tích tốt nhất trong năm và giành giải "Bài hát của năm" tại Melon Music Awards và Mnet Asian Music Awards. Đĩa đơn tiếp theo của họ, "TT", trích từ EP thứ ba Twicecoaster: Lane 1, đứng đầu bảng xếp hạng Gaon trong bốn tuần liên tiếp. EP này là album của một nhóm nhạc nữ Hàn Quốc bán chạy nhất năm 2016. Trong vòng 19 tháng sau khi ra mắt, Twice đã bán được hơn 1,2 triệu bản trong số 4 EP và album của họ. Tính đến cuối năm 2021, Twice đã bán được hơn 7,29 triệu bản album tại Hàn Quốc vào năm 2019. Tính đến tháng 12 năm 2020, nhóm đã bán được hơn 10 triệu bản album tại Hàn Quốc và Nhật Bản.

Nhóm ra mắt tại Nhật Bản vào ngày 28 tháng 6 năm 2017 dưới sự quản lý của Warner Music Japan, với việc phát hành một album tổng hợp mang tên #Twice. Album đứng ở vị trí thứ 2 trên Oricon Albums Chart với lượng bán album trong tuần đầu tiên cao nhất của một nghệ sĩ K-pop ở Nhật Bản trong hai năm. Tiếp theo là phát hành đĩa đơn gốc tiếng Nhật đầu tiên của Twice mang tên "One More Time" vào tháng 10. Twice trở thành nhóm nhạc nữ Hàn Quốc đầu tiên được chứng nhận Bạch kim từ Hiệp hội Công nghiệp Ghi âm Nhật Bản (RIAJ) cho cả album và đĩa đơn CD trong cùng năm. Twice đứng thứ ba trong hạng mục Nghệ sĩ hàng đầu của Billboard Japan vào năm 2017 và năm 2019, họ trở thành nhóm nhạc nữ Hàn Quốc đầu tiên thực hiện chuyến lưu diễn tại Nhật Bản.

Twice đã gặt hái được nhiều thành công trên thị trường quốc tế, khi trở thành nghệ sĩ nữ Hàn Quốc đầu tiên đứng đầu cả bảng xếp hạng Billboard World Albums và World Digital Song Sales khi phát hành album phòng thu đầu tiên Twicetagram và đĩa đơn chủ đạo "Likey" vào năm 2017. Với việc phát hành đĩa đơn "Feel Special" vào năm 2019, Twice đã trở thành nghệ sĩ nữ Hàn Quốc thứ ba lọt vào bảng xếp hạng Canadian Hot 100. Sau khi ký hợp đồng với Republic Records cho các hoạt động quảng bá tại Mỹ trong khuôn khổ hợp tác với JYP Entertainment, nhóm đã lọt vào bảng xếp hạng Billboard 200 với More & More và Eyes Wide Open vào năm 2020, Taste of Love và Formula of Love: O+T=<3 vào năm 2021. Đĩa đơn tiếng Anh đầu tiên của Twice, "The Feels", đã trở thành bài hát đầu tiên của họ lọt vào Billboard Hot 100 và UK Singles Chart, lần lượt đạt vị trí thứ 83 và 80 trên các bảng xếp hạng này. Họ được mệnh danh là "Nhóm nhạc nữ quốc dân" tiếp theo, vũ đạo trong các bài hát của nhóm—bao gồm "Cheer Up" (2016), "TT" (2016), "Signal" (2017) và "What Is Love?" (2018)—nhanh chóng trở thành cơn sốt và meme lan truyền được nhiều người nổi tiếng bắt chước.', 3, 0, 1)
INSERT [dbo].[Group] ([GroupID], [Name], [DebutDay], [FandomID], [Description], [LabelID], [SnsID], [IsActivate]) VALUES (5, N'BTS', CAST(N'2013-06-13' AS Date), 2, N'BTS (tiếng Hàn: 방탄소년단; Romaja: Bangtan Sonyeondan), còn được gọi là Bangtan Boys, là một nhóm nhạc nam Hàn Quốc được thành lập vào năm 2010 và ra mắt vào năm 2013 bởi Big Hit Entertainment.[5] Nhóm bao gồm 7 thành viên: Jin, Suga, J-Hope, RM, Jimin, V và Jungkook. Các thành viên đồng sáng tác và sản xuất cho phần lớn các sản phẩm âm nhạc của họ. Khởi đầu là một nhóm nhạc hip hop, phong cách âm nhạc của nhóm đã dần phát triển để thể hiện nhiều thể loại đa dạng. Ca từ của nhóm thường tập trung vào lời bình luận cá nhân và xã hội, đề cập đến các chủ đề về sức khỏe tinh thần, những rắc rối của tuổi học đường và tuổi thành niên, sự mất mát, hành trình hướng tới tình yêu bản thân và chủ nghĩa cá nhân. Các sản phẩm của nhóm còn thường đề cập đến khái niệm văn học, tâm lý học và bao gồm một cốt truyện vũ trụ song song.

Sau khi ra mắt vào năm 2013 với album đĩa đơn 2 Cool 4 Skool, BTS phát hành album phòng thu tiếng Hàn đầu tiên Dark & Wild và album phòng thu tiếng Nhật Wake Up vào năm 2014. Album phòng thu tiếng Hàn thứ hai Wings (2016) là album đầu tiên của nhóm bán được 1 triệu bản tại Hàn Quốc. Đến năm 2017, BTS thâm nhập vào thị trường âm nhạc quốc tế, dẫn đầu làn sóng Hàn Quốc vào Hoa Kỳ và phá vỡ nhiều kỷ lục doanh thu. Họ là nhóm nhạc Hàn Quốc đầu tiên được Hiệp hội Công nghiệp Ghi âm Hoa Kỳ (RIAA) trao chứng nhận với đĩa đơn "Mic Drop", đồng thời là nghệ sĩ Hàn Quốc đầu tiên dẫn đầu bảng xếp hạng Billboard 200 của Hoa Kỳ với album phòng thu Love Yourself: Tear (2018). BTS còn là nhóm nhạc đầu tiên kể từ The Beatles tích lũy được 4 album quán quân tại Hoa Kỳ trong vòng chưa đầy 2 năm và Love Yourself: Answer (2018) là album Hàn Quốc đầu tiên được RIAA trao chứng nhận Bạch kim. Năm 2020, BTS trở thành nghệ sĩ Hàn Quốc đầu tiên đạt vị trí số 1 trên bảng xếp hạng Billboard Hot 100 và Billboard Global 200 của Hoa Kỳ với "Dynamite" — đĩa đơn được đề cử cho giải Grammy. Các đĩa đơn kế tiếp bao gồm "Savage Love", "Life Goes On", "Butter" và "Permission to Dance" đã đưa BTS trở thành nghệ sĩ nhanh nhất tích lũy được 5 đĩa đơn quán quân tại Hoa Kỳ kể từ Michael Jackson.

Với hơn 32 triệu bản album bán ra trên bảng xếp hạng Gaon Music Chart, BTS là nghệ sĩ bán đĩa nhạc chạy nhất trong lịch sử Hàn Quốc và nắm giữ kỷ lục album bán chạy nhất tại Hàn Quốc với Map of the Soul: 7. Nhóm còn là nghệ sĩ châu Á và không nói tiếng Anh đầu tiên được Liên đoàn Công nghiệp Ghi âm Quốc tế (IFPI) vinh danh là Nghệ sĩ thu âm toàn cầu của năm (2020–2021), ra mắt trên bảng xếp hạng Nghệ sĩ lưu diễn hàng đầu trong những năm 2010 của Billboard (ở vị trí số 45), đồng thời là nghệ sĩ châu Á đầu tiên tổ chức buổi hòa nhạc riêng và bán cháy vé tại sân vận động Wembley và sân vận động Rose Bowl — thuộc khuôn khổ Love Yourself World Tour năm 2019. Xuất hiện trên trang bìa của tạp chí Time với tư cách là "Những nhà lãnh đạo thế hệ tương lai" và được mệnh danh là "Những chàng hoàng tử nhạc Pop", BTS cũng được tạp chí này vinh danh trong danh sách 25 nhân vật có tầm ảnh hưởng lớn nhất trên mạng xã hội (2017–2019) và 100 nhân vật có tầm ảnh hưởng lớn nhất thế giới (2019). Nhóm đã nhận được nhiều giải thưởng, bao gồm 9 giải American Music Awards, 9 giải Billboard Music Awards, 28 giải Golden Disk Awards với đề cử cho 2 giải Grammy Awards và 2 giải Brit Awards. Ngoài hoạt động nghệ thuật, nhóm còn hợp tác với UNICEF để thành lập chiến dịch chống bạo lực Love Myself, tham dự 3 phiên họp của Đại Hội đồng Liên Hợp Quốc và là những người trẻ tuổi nhất từng được Tổng thống Hàn Quốc trao tặng Huân chương Văn hóa nhờ những đóng góp của nhóm trong việc truyền bá văn hoá và ngôn ngữ Hàn Quốc.', 4, 0, 1)
INSERT [dbo].[Group] ([GroupID], [Name], [DebutDay], [FandomID], [Description], [LabelID], [SnsID], [IsActivate]) VALUES (6, N'GDYB', CAST(N'2014-11-20' AS Date), 1, N'GD X Taeyang (còn được gọi là GDYB) là một bộ đôi người Hàn Quốc từ YG Entertainment, bao gồm G-Dragon và Tae Yang từ Big Bang. Sau nhiều năm xuất hiện trên các vật liệu độc tấu của nhau, bộ đôi đã chính thức phát hành single "Good Boy" vào năm 2014, trong đó tiếp tục đầu bảng xếp hạng Billboard Bài hát kỹ thuật số trên thế giới và bán được hơn một triệu đơn vị kỹ thuật số tại Hàn Quốc.', 1, 0, 1)
INSERT [dbo].[Group] ([GroupID], [Name], [DebutDay], [FandomID], [Description], [LabelID], [SnsID], [IsActivate]) VALUES (20, N'NMIXX', CAST(N'2022-02-22' AS Date), 8, N'NMIXX (엔믹스) là một nhóm nhạc nữ gồm bảy thành viên trực thuộc JYP Entertainment. Họ ra mắt vào ngày 22 tháng 2 năm 2022 với album đơn "Ad Mare".
Tên của họ NMIXX là một từ được tạo thành từ chữ "N", có nghĩa là bây giờ, mới, gần gũi và chưa biết n, và từ "MIX", tượng trưng cho sự kết hợp và đa dạng, có nghĩa là "sự kết hợp tốt nhất cho một kỷ nguyên mới".
Vào ngày 8 tháng 7 năm 2021, tài khoản SNS cho ''JYPn'' đã được mở và một teaser có tựa đề "Blind Package" đã được tiết lộ.

Vào ngày 9 tháng 7 năm 2021, một teaser thứ hai đã được tiết lộ, chứa cụm từ "Nhóm nhạc nữ được yêu thích tiếp theo của bạn" làm dấy lên tin đồn rằng JYP Entertainment sẽ sớm ra mắt nhóm nhạc nữ mới của họ. Sau đó cùng ngày JYP Entertainment xác nhận rằng họ sẽ ra mắt nhóm nhạc nữ mới vào tháng 2 năm 2022 và một đĩa đơn đầu tay phiên bản giới hạn mang tên "Blind Package" sẽ chỉ được bán trong 10 ngày, từ ngày 16 đến 25 tháng 7 và chỉ có thể được mua trong thời gian trước khi bán. "Blind Package" sẽ được gửi khi nhóm ra mắt vào tháng 2 năm 2022 và bao gồm một đĩa CD phiên bản giới hạn, sách ảnh, áp phích, thẻ thành viên cao cấp, polaroid ngẫu nhiên và những người khác. Vào ngày 22 tháng 7 năm 2021, có thông báo rằng "Blind Package" đã đạt 40.000 bản trong đơn đặt hàng trước. Vào ngày 27 tháng 7 năm 2021, JYP Entertainment báo cáo rằng "Blind Package" đã bán được 60.000 bản sau khi đơn đặt hàng trước kết thúc. Vào ngày 6 tháng 8, JYP Entertainment đã phát hành một video của 3 thành viên, Jinni, Jiwoo và Kyujin''s Press dance cover trên kênh Youtube của JYPn.  Vào ngày 20 tháng 8 năm 2021, một video cover mới của Jinni đã được phát hành. Vào ngày 3 tháng 9 năm 2021, một bản cover "Full Moon" của Sunmi đã được phát hành, tiết lộ thành viên mới Sullyoon. ', 3, 42, 1)
SET IDENTITY_INSERT [dbo].[Group] OFF
GO
SET IDENTITY_INSERT [dbo].[GroupSong] ON 

INSERT [dbo].[GroupSong] ([GroupSongID], [SongID], [GroupID]) VALUES (1, 4, 3)
INSERT [dbo].[GroupSong] ([GroupSongID], [SongID], [GroupID]) VALUES (1006, 3, 6)
INSERT [dbo].[GroupSong] ([GroupSongID], [SongID], [GroupID]) VALUES (1010, 6, 20)
INSERT [dbo].[GroupSong] ([GroupSongID], [SongID], [GroupID]) VALUES (1011, 7, 20)
SET IDENTITY_INSERT [dbo].[GroupSong] OFF
GO
SET IDENTITY_INSERT [dbo].[Image] ON 

INSERT [dbo].[Image] ([ImageID], [ImageURL], [Description]) VALUES (1, N'https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEil4D-R6UJwpdgvxU3Dpj9h3JBUUxF0JCQe0LSNY7TXpoAlw8tqboq3YGUYcx7fZDRYCkeZLKuwDb61OF8fdr1l3MLX9thcjsNZR4dg5R3reDT62oql9LPw7Qso1D8QbQ555bspp3eIJDvo8mtWg9ZNxOZRS8lsV9F4RpSgc2MlWXX3BUnJmWotA5vN/w213-h320/Gdragon.jpg', N'Artist_G-dragon')
INSERT [dbo].[Image] ([ImageID], [ImageURL], [Description]) VALUES (2, N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRzpb5uE_OnG6ReR8gZin19ottAUktNqrdkHw&usqp=CAU', N'Artist_G-dragon')
INSERT [dbo].[Image] ([ImageID], [ImageURL], [Description]) VALUES (3, N'https://www.elle.vn/wp-content/uploads/2015/05/28/taeyang-big-bang-dara-2ne1-31959178-1568-1002.jpg', N'Artist_Taeyang')
INSERT [dbo].[Image] ([ImageID], [ImageURL], [Description]) VALUES (4, N'https://nld.mediacdn.vn/2017/t-o-p-bigbang-1496650913669.jpg', N'Artist_TOP')
INSERT [dbo].[Image] ([ImageID], [ImageURL], [Description]) VALUES (5, N'https://vnn-imgs-f.vgcloud.vn/2020/02/19/21/iu-2.jpg', N'Artist_IU')
INSERT [dbo].[Image] ([ImageID], [ImageURL], [Description]) VALUES (6, N'https://kenh14cdn.com/2019/7/29/h1-15643771450081390479664.jpg', N'Artist_Daesung')
INSERT [dbo].[Image] ([ImageID], [ImageURL], [Description]) VALUES (7, N'https://kenh14cdn.com/2020/3/9/1f648c6894e3bd1da348b10009295402-1583768891232325699524.jpg', N'Artist_IU')
INSERT [dbo].[Image] ([ImageID], [ImageURL], [Description]) VALUES (8, N'https://image.phunuonline.com.vn/fckeditor/upload/2020/20200901/images/em-gai-quoc-dan-iu-lan-_791598924030.png', N'Artist_IU')
INSERT [dbo].[Image] ([ImageID], [ImageURL], [Description]) VALUES (9, N'https://cuoifly.tuoitre.vn/820/0/ttc/r/2021/10/31/em-gai-quoc-dan-iu-1635647752.jpeg', N'Artist_IU')
INSERT [dbo].[Image] ([ImageID], [ImageURL], [Description]) VALUES (10, N'https://i.vietgiaitri.com/2020/5/21/my-nhan-thi-phi-duong-tu-tung-bo-anh-moi-nhung-lai-vuong-nghi-van-dao-nhai-nu-than-kbiz-iu-4a4-4948265.jpg', N'Artist_IU')
INSERT [dbo].[Image] ([ImageID], [ImageURL], [Description]) VALUES (11, N'http://static1.bestie.vn/Mlog/ImageContent/201707/iu-at-incheon-airport-6-january-2017-03-20170731213605.jpg', N'Artist_IU')
INSERT [dbo].[Image] ([ImageID], [ImageURL], [Description]) VALUES (12, N'https://i.ex-cdn.com/tintucvietnam.vn/files/f1/2018/08/18/g-dragon-la-ai-va-noi-tieng-nhu-the-nao-bb-baaadKdQzG.jpg?v=1534559008319', N'Artist_Gdragon')
INSERT [dbo].[Image] ([ImageID], [ImageURL], [Description]) VALUES (13, N'https://static1.bestie.vn/Mlog/ImageContent/201910/nhan-sac-dinh-cao-cua-my-nhan-bao-nam-van-chim-heejin-987d93.jpg', N'')
INSERT [dbo].[Image] ([ImageID], [ImageURL], [Description]) VALUES (14, N'https://file.tinnhac.com/resize/600x-/2021/11/05/20211105143644-5ec6.jpg', N'Artist_Haewon')
INSERT [dbo].[Image] ([ImageID], [ImageURL], [Description]) VALUES (15, N'https://www.allkpop.com/upload/2022/04/content/260959/web_data/allkpop_1650981962_20220426-nmixx.jpg', N'Artist_Haewon')
INSERT [dbo].[Image] ([ImageID], [ImageURL], [Description]) VALUES (16, N'https://i.pinimg.com/originals/0c/ce/a6/0ccea6c65c2f3679f3f159cf83a12719.jpg', N'Artist_Haewon')
INSERT [dbo].[Image] ([ImageID], [ImageURL], [Description]) VALUES (17, N'https://kenh14cdn.com/thumb_w/660/203336854389633024/2022/2/27/photo-1-16459421336531006818076.jpg', N'Artist_Yeji')
INSERT [dbo].[Image] ([ImageID], [ImageURL], [Description]) VALUES (18, N'https://baotuoitre.net/wp-content/uploads/2019/07/tieu-su-yeji-3.jpg', N'Artist_Yeji')
INSERT [dbo].[Image] ([ImageID], [ImageURL], [Description]) VALUES (19, N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSqEoL9szBGj0e3o_foJLYx-k3pgjt-HOgX5sTKUom9C4mSIhhRan5BI-hv3JqEn157_-U&usqp=CAU', N'yuna')
INSERT [dbo].[Image] ([ImageID], [ImageURL], [Description]) VALUES (20, N'https://kenh14cdn.com/203336854389633024/2021/9/27/photo-1-16327395463141610580818.jpg
', N'yuna')
SET IDENTITY_INSERT [dbo].[Image] OFF
GO
SET IDENTITY_INSERT [dbo].[Label] ON 

INSERT [dbo].[Label] ([LabelID], [Name], [Founder], [Founded], [Location], [Description]) VALUES (0, N'Không có', N'Không có', CAST(N'1990-01-01' AS Date), NULL, NULL)
INSERT [dbo].[Label] ([LabelID], [Name], [Founder], [Founded], [Location], [Description]) VALUES (1, N'YG', N'Yang Hyun Suk', CAST(N'1996-02-24' AS Date), N'Seoul, Hàn Quốc', N'YG Entertainment (tiếng Hàn: YG 엔터테인먼트; RR: YG enteoteinmeonteu) được thành lập vào năm 1996 bởi Yang Hyun-suk. Công ty hoạt động như một hãng thu âm, công ty tài năng, công ty sản xuất âm nhạc, công ty quản lý sự kiện, sản xuất buổi hòa nhạc và nhà xuất bản âm nhạc. YG còn điều hành một số công ty con thuộc một công ty thương mại công cộng riêng biệt gồm một thương hiệu quần áo, một cơ quan quản lý sân golf và một thương hiệu mỹ phẩm.
Các nghệ sĩ hiện tại bao gồm Sechskies, Big Bang, Akdong Musician, Winner, iKon, Blackpink và Treasure cũng như các diễn viên Kang Dong-won, Choi Ji-woo, Cha Seung-won, Lee Sung-kyung và Yoo In-na và Son Na-eun. Các nghệ sĩ nổi bật khác bao gồm Jeon So-mi (trực thuộc công ty con The Black Label) và Anda (trực thuộc công ty con YGX).
Các cựu nghệ sĩ của công ty bao gồm Wheesung, Epik High, 1TYM, Gummy, Seven, Minzy, Park Bom, 2NE1, Nam Tae-hyun, Lee Jong-suk, Psy, Seungri, B.I, One, CL, Lee Hi, Jinusean và Sandara Park.')
INSERT [dbo].[Label] ([LabelID], [Name], [Founder], [Founded], [Location], [Description]) VALUES (2, N'SM', N'Lee So Man', CAST(N'1989-02-14' AS Date), N'Seongsu-dong, Seongdong-gu, Seoul, Hàn Quốc', N'SM Entertainment Co., Ltd. (tiếng Hàn: SM엔터테인먼트) là một công ty giải trí của Hàn Quốc. Đây là một trong những công ty giải trí lớn nhất Hàn Quốc (cùng với Big Hit Music, YG Entertainment và JYP Entertainment), do chủ tịch kiêm nhà sản xuất âm nhạc Lee Soo-man sáng lập vào ngày 14 tháng 2 năm 1995 (lúc đầu là SM Studio vào năm 1989). Đến nay, công ty đã phát triển nhiều ngôi sao K-pop nổi tiếng với lượng người hâm mộ đông đảo.

Công ty hoạt động với tư cách là một hãng thu âm, công ty tài năng, công ty sản xuất âm nhạc, công ty tổ chức sự kiện và sản xuất buổi hòa nhạc và nhà xuất bản âm nhạc. SM Entertainment được biết đến vì là công ty tiên phong trong việc quảng bá K-pop trên toàn thế giới, tạo ra một làn sóng mới có tên là "Làn sóng Hàn Quốc".

SM hiện đang quản lý các nghệ sĩ K-pop như TVXQ!, Super Junior, Girls'' Generation, J-Min, Shinee, Zhou Mi, EXO, Red Velvet, NCT, SuperM và gần đây là aespa; trước đó SM từng quản lý các nhóm H.O.T, S.E.S., Shinhwa, Fly to the Sky, TraxX, Jang Na-ra, The Grace, f(x) và Henry Lau.

SM cũng quản lý các diễn viên, bao gồm Kim Min-jong, Lee Jae-ryong, Yoo Ho-jeong, Ki Do-hun và từng quản lý Lee Yeon-hee, Go Ara. Tại Nhật Bản, SM Entertainment với Avex Trax cùng đồng quản lý cho các nghệ sĩ như Ayumi Hamasaki, Namie Amuro và Koda Kumi, cũng như các nghệ sĩ của Johnny''s Entertainment bao gồm Arashi và KAT-TUN.')
INSERT [dbo].[Label] ([LabelID], [Name], [Founder], [Founded], [Location], [Description]) VALUES (3, N'JYP', N'Park Jin Young, Hong Seung-sung', CAST(N'1997-04-25' AS Date), N'Seoul, Hàn Quốc', N'JYP Entertainment (tiếng Triều Tiên: J.Y.P 엔터테인먼트) được thành lập vào năm 1997 bởi J. Y. Park. JYP hoạt động như một hãng thu âm, công ty tài năng, công ty sản xuất âm nhạc, công ty quản lý sự kiện, công ty tổ chức buổi hòa nhạc và nhà xuất bản âm nhạc. Công ty điều hành nhiều công ty con và bộ phận khác nhau trên toàn thế giới.
			Các nghệ sĩ hiện tại bao gồm 2PM, Day6, TWICE, Boy Story, Stray Kids, ITZY, NiziU và NMIXX, và các cựu nghệ sĩ bao gồm Rain, g.o.d, Wonder Girls, 2AM, Miss A, 15&, JJ Project, Got7, Jus2 và Baek A-yeon.')
INSERT [dbo].[Label] ([LabelID], [Name], [Founder], [Founded], [Location], [Description]) VALUES (4, N'Hybe', N'Bang Si Hyuk', CAST(N'2005-02-01' AS Date), N'Yongsan-gu, Seoul, Hàn Quốc', N'Hybe Co., Ltd. (tiếng Hàn: 하이브; cách điệu là HYBE Corporation) là một công ty giải trí Hàn Quốc được thành lập vào năm 2005 bởi Bang Si-hyuk với tên gọi Big Hit Entertainment. Công ty hoạt động như một hãng thu âm, công ty quản lý tài năng, công ty sản xuất âm nhạc, công ty tổ chức sự kiện, công ty sản xuất buổi hòa nhạc và nhà xuất bản âm nhạc. Công ty sở hữu nhiều công ty con, bao gồm Big Hit Music, Source Music, Pledis Entertainment, Belift Lab, Hybe Japan và KOZ Entertainment, thường được biết đến với tên gọi chung là Hybe Labels.')
INSERT [dbo].[Label] ([LabelID], [Name], [Founder], [Founded], [Location], [Description]) VALUES (5, N'Starship', N'Kim Shi-dae, Seo Hyun-joo, Kim Young-suk', CAST(N'2008-01-28' AS Date), N'Gangnam-gu, Seoul, Hàn Quốc', N'Starship Entertainment (tiếng Hàn: 스타쉽 엔터테인먼트) là một công ty giải trí của Hàn Quốc được thành lập vào năm 2008 và là công ty con của Kakao Entertainment. Công ty đã được công nhận vì những đóng góp của họ cho Làn sóng Hallyu, là công ty của một số nhóm nhạc K-pop và nghệ sĩ solo nổi tiếng. Công ty hiện đang quản lý các nhóm nhạc như Monsta X, Cosmic Girls, Cravity và Ive, và những nghệ sĩ solo như K.Will, Jooyoung, Wonho, I.M, Yoo Seung-woo, Brother Su , Jeong Se-woon. Công ty trước đây từng quản lý Sistar, Boyfriend, Junggigo và Mad Clown. Starship cũng quản lý các diễn viên dưới công ty con King Kong by Starship.')
INSERT [dbo].[Label] ([LabelID], [Name], [Founder], [Founded], [Location], [Description]) VALUES (6, N'Stone Music', N'Jung Hyung-jin', CAST(N'1994-06-29' AS Date), N'Seoul, Hàn Quốc', N'Stone Music Entertainment (Hangul: 스톤뮤직엔터테인먼트) là một công ty giải trí tư nhân của Hàn Quốc thuộc CJ E&M và CJ ENM. Đây hiện là một trong những công ty đồng phát hành lớn nhất ở Hàn Quốc. Công ty hoạt động như một hãng thu âm, công ty quản lý tài năng, công ty sản xuất âm nhạc, quản lý sự kiện, công ty sản xuất concert, nhà xuất bản âm nhạc và nhà đầu tư.

Từng là ngôi nhà của các nghệ sĩ như SeeYa, Lee Hyori, I.O.I, Park Bo-ram, Wanna One và X1, hiện tại công ty đang quản lý các nghệ sĩ như SG Wannabe, Davichi, Roy Kim, Son Ho-young, Eric Nam, Heize, Fromis 9, Kep1er, HEDY, Quankune và TO1 . Cái sau có lẽ sẽ được chuyển sang các nhãn khác sau tháng 4 năm 2021.

Stone Music Entertainment (trước đây là CJ E&M Music) được vinh danh là Nhà phân phối âm nhạc của năm tại Giải thưởng K-Pop Gaon chart năm 2014.')
SET IDENTITY_INSERT [dbo].[Label] OFF
GO
SET IDENTITY_INSERT [dbo].[SNS] ON 

INSERT [dbo].[SNS] ([SnsID], [Youtube], [Instagram], [Facebook], [Twitter], [Tiktok], [Vlive], [AppleMusic], [Spotify], [Website]) VALUES (0, N'https://youtube.com/channel/iuofficial', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[SNS] ([SnsID], [Youtube], [Instagram], [Facebook], [Twitter], [Tiktok], [Vlive], [AppleMusic], [Spotify], [Website]) VALUES (1, N'https://www.youtube.com/ygentertainment', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SNS] ([SnsID], [Youtube], [Instagram], [Facebook], [Twitter], [Tiktok], [Vlive], [AppleMusic], [Spotify], [Website]) VALUES (2, N'https://www.youtube.com/officialgdragon', N'https://www.instagram.com/xxxibgdrgn/', N'https://www.facebook.com/gdragon', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[SNS] ([SnsID], [Youtube], [Instagram], [Facebook], [Twitter], [Tiktok], [Vlive], [AppleMusic], [Spotify], [Website]) VALUES (42, N'https://www.youtube.com/channel/UCnUAyD4t2LkvW68YrDh7fDg', N'https://www.instagram.com/nmixx_official/', N'https://www.facebook.com/NMIXXOfficial', N'https://twitter.com/NMIXX_official', N'https://www.tiktok.com/@nmixx_official', N'https://www.vlive.tv/channel/81BFAF', N'https://music.apple.com/us/artist/nmixx/1600411676', N'https://open.spotify.com/artist/28ot3wh4oNmoFOdVajibBl', N'')
INSERT [dbo].[SNS] ([SnsID], [Youtube], [Instagram], [Facebook], [Twitter], [Tiktok], [Vlive], [AppleMusic], [Spotify], [Website]) VALUES (43, N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[SNS] ([SnsID], [Youtube], [Instagram], [Facebook], [Twitter], [Tiktok], [Vlive], [AppleMusic], [Spotify], [Website]) VALUES (44, N'', N'https://www.instagram.com/yeji.ltzy/', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[SNS] ([SnsID], [Youtube], [Instagram], [Facebook], [Twitter], [Tiktok], [Vlive], [AppleMusic], [Spotify], [Website]) VALUES (45, N'', N'https://www.instagram.com/yuna.itzy/', N'', N'', N'', N'', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[SNS] OFF
GO
SET IDENTITY_INSERT [dbo].[Song] ON 

INSERT [dbo].[Song] ([SongID], [Name], [ReleaseDay], [Genre], [Producer], [Description]) VALUES (1, N'Heartbreaker', CAST(N'2009-08-11' AS Date), N'Hiphop', N'Teddy Park, G-dragon', N'Heartbreaker là bài hát thuộc album solo đầu tiên cùng tên của G-Dragon, chàng trưởng nhóm tài năng của Big Bang. Ca khúc chủ đề "Heartbreaker" đã chiếm vị trí cao trên các bảng xếp hạng ngay từ khi ra mắt. Tính đến nay, album đã bán được khoảng hơn 285 nghìn bản.')
INSERT [dbo].[Song] ([SongID], [Name], [ReleaseDay], [Genre], [Producer], [Description]) VALUES (2, N'Butterfly', CAST(N'2009-10-23' AS Date), N'R&B', N'Choice37, G-Dragon', N'Butterfly là bài hát thuộc album solo đầu tiên mang tên Heartbreaker của G-Dragon, chàng trưởng nhóm tài năng của Big Bang.')
INSERT [dbo].[Song] ([SongID], [Name], [ReleaseDay], [Genre], [Producer], [Description]) VALUES (3, N'Palette', CAST(N'2017-04-21' AS Date), N'R&B', N'Lee Jong-hoon, IU, G-dragon.', N'"Palette" (팔레트; Palleteu) là bài hát thu âm bởi ca sĩ Hàn QuốcIU và G-Dragon cho album phòng thu thứ tư cùng tên. IU đã sáng tác âm nhạc và viết lời với sự hợp tác của G-Dragon. Bài hát được phát hành vào ngày 21 tháng 4 năm 2017 kết hợp với việc phát hành album như là single thứ ba của album, kế tiếp "Through the Night" và "Can''t Love You Anymore".

"Palette" đã nhận được những phản hồi tích cực và thành công thương mại khi đứng đầu trên các trang web âm nhạc lớn của Hàn Quốc. Bài hát ra mắt đứng vị trí thứ nhất trên Gaon Digital Chart trở thành single thứ 16 của IU đạt vị trí thứ nhất tại Hàn Quốc.

MV được đạo diễn bởi Lee Rae-kyung, và là MV của nữ ca sĩ solo đạt được lượt xem cao nhất tại Hàn Quốc trên YouTube năm 2017.')
INSERT [dbo].[Song] ([SongID], [Name], [ReleaseDay], [Genre], [Producer], [Description]) VALUES (4, N'How You Like That', CAST(N'2020-06-26' AS Date), N'Trap, Hiphop', N'Teddy Park, Danny Chung, Park Hong-jun, R. Tee, Emon74, 24', N'"How You Like That" là một bài hát của nhóm nhạc nữ Hàn Quốc Blackpink. Bài hát ra mắt vào ngày 26 tháng 6 năm 2020, thông qua YG và Interscope. Đây cũng là đĩa đơn mở đường cho album phòng thu tiếng Hàn đầu tay của nhóm, The Album, được phát hành vào tháng 10 năm 2020. Teddy Park tham gia viết bài hát cùng Danny Chung, Emon74 và R.Tee tham gia sáng tác cùng 24, Lisa, Rosé, Jioo, Jennie.
MV cho bài hát được đạo diễn bởi Seo Hyun-seung và được đăng tải trên kênh Youtube của Blackpink cùng lúc với phát hành single. Sau khi phát hành, MV đã phá vỡ nhiều kỉ lục, bao gồm kỉ lục của video có nhiều người xem công chiếu nhất, kỉ lục video âm nhạc được xem nhiều nhất trong 24 giờ với 86,3 triệu view, cũng như các kỷ lục đạt 100 triệu và 200 triệu lượt xem nhanh nhất và nhanh chóng trở thành một trong những video có lượt like nhiều nhất trên YouTube với hơn 20,6 triệu like.
Về mặt thương mại, single đã xếp hạng tại 26 nước. Đạt vị trí thứ nhất tại Hàn Quốc (cả Gaon và K-Pop Hot 100), Singapore và Malaysia. Single đã đồng thứ hạng với màn kết hợp với Lady Gaga, "Sour Candy", thứ hạng cao nhất bởi nghệ sĩ nữ Hàn Quốc trên Billboard Hot 100, đạt vị trí 33.')
INSERT [dbo].[Song] ([SongID], [Name], [ReleaseDay], [Genre], [Producer], [Description]) VALUES (6, N'O.O', CAST(N'2022-02-22' AS Date), N'Pop, Hiphop, Trap', N'Brian U, Enan, MarkAlong, Charlotte Wilson, Chanti, EJAEAwry, Dr.JO', N'"O.O" (cách điệu là "().()") là một bài hát được thu âm bởi nhóm nhạc nữ Hàn Quốc NMIXX. Đây là bài hát thứ hai và ca khúc chủ đề của album đầu tay "AD MARE", phát hành vào ngày 22 tháng 2 năm 2022.
Đây là bài hát đầu tiên giới thiệu với thế giới thể loại độc đáo của NMIXX ''MIXX POP'', nơi bạn có thể cảm nhận được thị hiếu khác nhau bằng cách đặt nhiều hơn một thể loại trong một bài hát. Đây là một bài hát thử nghiệm với ''MIXX''. Tiêu đề bài hát ''O.O'', dường như có đôi mắt mở to trong sự ngạc nhiên và thể hiện câu cảm thán "Oh!", là một biểu hiện của sự tự tin mạnh mẽ để nhìn thấy một cái gì đó mới và chuẩn bị để được ngạc nhiên.')
INSERT [dbo].[Song] ([SongID], [Name], [ReleaseDay], [Genre], [Producer], [Description]) VALUES (7, N'Tank', CAST(N'2022-02-22' AS Date), N'Trap', N'Dr.JO, Oh Hyun-seon, Jung Jun-hoOh, Yu-won, Dwayne Abernathy Jr.Ryan S. JhunEricka J. CoulterDeanna', N'Nó so sánh thái độ trang nghiêm và đầy tham vọng của NMIXX với một ''chiếc xe tăng'', và đó là một bài hát chứa đựng một câu chuyện táo bạo về việc sạc và chiến đấu với thế giới. Tiêu đề của bài hát là nhân vật Trung Quốc ''thần thánh'', gợi nhớ đến một chiếc xe tăng, và thể hiện ấn tượng khát vọng tiếp quản thế giới. Đây là một bài hát R & B hip-hop dựa trên Punk Rock với phần mở đầu guitar biến dạng thô.')
INSERT [dbo].[Song] ([SongID], [Name], [ReleaseDay], [Genre], [Producer], [Description]) VALUES (8, N'Dynamite', CAST(N'2020-08-21' AS Date), N'Disco, Pop', N'David Stewart, Jessica Agombar, David Stewart', N'"Dynamite" là đĩa đơn kỹ thuật số tiếng Anh đầu tiên (với tư cách là nghệ sĩ chính, tổng thể thứ sáu, cũng là bài hát hoàn toàn bằng tiếng Anh đầu tiên) của BTS. Nó được phát hành vào ngày 21 tháng 8 năm 2020, lúc 1 giờ chiều KST. Một bản remix EDM và một bản phối lại acoustic đã được phát hành vào ngày 24 tháng 8 năm 2020, cũng là một bản remix nhiệt đới và một bản phối lại bên hồ bơi đã được phát hành vào ngày 28 tháng 8 năm 2020.')
INSERT [dbo].[Song] ([SongID], [Name], [ReleaseDay], [Genre], [Producer], [Description]) VALUES (9, N'Feel Special', CAST(N'2019-09-23' AS Date), N'Future bass', N'Park Jin Young (JYP), Ollipop, Hayley Aitken', N'"Feel Special" là một bài hát được thu âm bởi nhóm nhạc nữ Hàn Quốc Twice. Đây là ca khúc chủ đề của vở kịch mở rộng cùng tên. Đĩa đơn và video âm nhạc của nó đã được phát hành vào ngày 23 tháng 9 năm 2019.')
SET IDENTITY_INSERT [dbo].[Song] OFF
GO
INSERT [dbo].[TestRegister] ([username], [password]) VALUES (N'1234', N'123')
INSERT [dbo].[TestRegister] ([username], [password]) VALUES (N'aoeteam', N'1234')
INSERT [dbo].[TestRegister] ([username], [password]) VALUES (N'aoeteam2', N'1234')
GO
INSERT [dbo].[User] ([UserID], [UserName], [Password], [FullName], [Email], [PhoneNumber], [Description], [Birthday], [Role], [isBan]) VALUES (N'U000000001', N'nvh2001', N'nvh2001', N'Nguyễn Văn Hào', N'vanhao.dev@gmail.com', N'0972597463', N'OK man', CAST(N'2001-10-25' AS Date), 3, 0)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [FullName], [Email], [PhoneNumber], [Description], [Birthday], [Role], [isBan]) VALUES (N'U000000003', N'haewon', N'haewon', N'Haewon', N'unknow@gmail.com', NULL, N'Người này không để lại gì cả!', CAST(N'1900-01-01' AS Date), 0, 0)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [FullName], [Email], [PhoneNumber], [Description], [Birthday], [Role], [isBan]) VALUES (N'U000000004', N'lilym', N'12346789', N'LilyM happu', N'unknow@gmail.com', NULL, N'Người này không để lại gì cả!', CAST(N'1900-01-01' AS Date), 0, 0)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [FullName], [Email], [PhoneNumber], [Description], [Birthday], [Role], [isBan]) VALUES (N'U000000005', N'nct127', N'nvh2001', N'nvh2001', N'unknow@gmail.com', NULL, N'Người này không để lại gì cả!', CAST(N'1900-01-01' AS Date), 0, 0)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [FullName], [Email], [PhoneNumber], [Description], [Birthday], [Role], [isBan]) VALUES (N'U000000006', N'somi', N'1234@', N'Jeon Somi', N'unknow@gmail.com', NULL, N'Người này không để lại gì cả!', CAST(N'1900-01-01' AS Date), 0, 0)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [FullName], [Email], [PhoneNumber], [Description], [Birthday], [Role], [isBan]) VALUES (N'U000000007', N'stayc', N'@5555', N'StayC', N'unknow@gmail.com', NULL, N'Người này không để lại gì cả!', CAST(N'1900-01-01' AS Date), 0, 0)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [FullName], [Email], [PhoneNumber], [Description], [Birthday], [Role], [isBan]) VALUES (N'U000000008', N'nmixx', N'1234', N'N-MIX-X', N'unknow@gmail.com', NULL, N'Người này không để lại gì cả!', CAST(N'1900-01-01' AS Date), 0, 0)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [FullName], [Email], [PhoneNumber], [Description], [Birthday], [Role], [isBan]) VALUES (N'U000000009', N'nmixx2', N'123456789', N'N-MIX-22222', N'unknow@gmail.com', NULL, N'Người này không để lại gì cả!', CAST(N'1900-01-01' AS Date), 0, 0)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__User__C9F2845688B10F78]    Script Date: 14/05/2022 9:18:32 CH ******/
ALTER TABLE [dbo].[User] ADD UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Album] ADD  DEFAULT ('1900-1-1') FOR [ReleaseDay]
GO
ALTER TABLE [dbo].[Artist] ADD  CONSTRAINT [DF__Artist__BirthDay__5070F446]  DEFAULT ('1900-1-1') FOR [BirthDay]
GO
ALTER TABLE [dbo].[Artist] ADD  CONSTRAINT [DF__Artist__DebutDay__5165187F]  DEFAULT ('1900-1-1') FOR [DebutDay]
GO
ALTER TABLE [dbo].[Artist] ADD  CONSTRAINT [DF__Artist__IsActiva__52593CB8]  DEFAULT ((1)) FOR [IsActivate]
GO
ALTER TABLE [dbo].[Artist] ADD  CONSTRAINT [DF_Artist_Gender]  DEFAULT ((1)) FOR [Gender]
GO
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF__Group__DebutDay__619B8048]  DEFAULT ('1900-1-1') FOR [DebutDay]
GO
ALTER TABLE [dbo].[Group] ADD  CONSTRAINT [DF_Group_IsActivate]  DEFAULT ((1)) FOR [IsActivate]
GO
ALTER TABLE [dbo].[Image] ADD  DEFAULT (N'https://bombyxplm.com/wp-content/uploads/2021/01/421-4213053_default-avatar-icon-hd-png-download.png') FOR [ImageURL]
GO
ALTER TABLE [dbo].[Label] ADD  DEFAULT ('1900-1-1') FOR [Founded]
GO
ALTER TABLE [dbo].[Song] ADD  DEFAULT ('1900-1-1') FOR [ReleaseDay]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (N'Người này không để lại gì cả!') FOR [Description]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ('1900-1-1') FOR [Birthday]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((1)) FOR [Role]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [isBan]
GO
ALTER TABLE [dbo].[AlbumImage]  WITH CHECK ADD  CONSTRAINT [FK_AlbumImage_Album] FOREIGN KEY([AlbumID])
REFERENCES [dbo].[Album] ([AlbumID])
GO
ALTER TABLE [dbo].[AlbumImage] CHECK CONSTRAINT [FK_AlbumImage_Album]
GO
ALTER TABLE [dbo].[AlbumImage]  WITH CHECK ADD  CONSTRAINT [FK_AlbumImage_Image] FOREIGN KEY([ImageID])
REFERENCES [dbo].[Image] ([ImageID])
GO
ALTER TABLE [dbo].[AlbumImage] CHECK CONSTRAINT [FK_AlbumImage_Image]
GO
ALTER TABLE [dbo].[AlbumSong]  WITH CHECK ADD  CONSTRAINT [FK_AlbumSong_Album] FOREIGN KEY([AlbumID])
REFERENCES [dbo].[Album] ([AlbumID])
GO
ALTER TABLE [dbo].[AlbumSong] CHECK CONSTRAINT [FK_AlbumSong_Album]
GO
ALTER TABLE [dbo].[AlbumSong]  WITH CHECK ADD  CONSTRAINT [FK_AlbumSong_Song] FOREIGN KEY([SongID])
REFERENCES [dbo].[Song] ([SongID])
GO
ALTER TABLE [dbo].[AlbumSong] CHECK CONSTRAINT [FK_AlbumSong_Song]
GO
ALTER TABLE [dbo].[Artist]  WITH CHECK ADD  CONSTRAINT [FK_Artist_Fandom] FOREIGN KEY([FandomID])
REFERENCES [dbo].[Fandom] ([FandomID])
GO
ALTER TABLE [dbo].[Artist] CHECK CONSTRAINT [FK_Artist_Fandom]
GO
ALTER TABLE [dbo].[Artist]  WITH CHECK ADD  CONSTRAINT [FK_Artist_Label] FOREIGN KEY([LabelID])
REFERENCES [dbo].[Label] ([LabelID])
GO
ALTER TABLE [dbo].[Artist] CHECK CONSTRAINT [FK_Artist_Label]
GO
ALTER TABLE [dbo].[Artist]  WITH CHECK ADD  CONSTRAINT [FK_Artist_SNS] FOREIGN KEY([SnsID])
REFERENCES [dbo].[SNS] ([SnsID])
GO
ALTER TABLE [dbo].[Artist] CHECK CONSTRAINT [FK_Artist_SNS]
GO
ALTER TABLE [dbo].[ArtistGroup]  WITH CHECK ADD  CONSTRAINT [FK_ArtistGroup_Artist] FOREIGN KEY([ArtistID])
REFERENCES [dbo].[Artist] ([ArtistID])
GO
ALTER TABLE [dbo].[ArtistGroup] CHECK CONSTRAINT [FK_ArtistGroup_Artist]
GO
ALTER TABLE [dbo].[ArtistGroup]  WITH CHECK ADD  CONSTRAINT [FK_ArtistGroup_Group] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Group] ([GroupID])
GO
ALTER TABLE [dbo].[ArtistGroup] CHECK CONSTRAINT [FK_ArtistGroup_Group]
GO
ALTER TABLE [dbo].[ArtistImage]  WITH CHECK ADD  CONSTRAINT [FK_ArtistImage_Artist] FOREIGN KEY([ArtistID])
REFERENCES [dbo].[Artist] ([ArtistID])
GO
ALTER TABLE [dbo].[ArtistImage] CHECK CONSTRAINT [FK_ArtistImage_Artist]
GO
ALTER TABLE [dbo].[ArtistImage]  WITH CHECK ADD  CONSTRAINT [FK_ArtistImage_Image] FOREIGN KEY([ImageID])
REFERENCES [dbo].[Image] ([ImageID])
GO
ALTER TABLE [dbo].[ArtistImage] CHECK CONSTRAINT [FK_ArtistImage_Image]
GO
ALTER TABLE [dbo].[ArtistSong]  WITH CHECK ADD  CONSTRAINT [FK_ArtistSong_Artist] FOREIGN KEY([ArtistID])
REFERENCES [dbo].[Artist] ([ArtistID])
GO
ALTER TABLE [dbo].[ArtistSong] CHECK CONSTRAINT [FK_ArtistSong_Artist]
GO
ALTER TABLE [dbo].[ArtistSong]  WITH CHECK ADD  CONSTRAINT [FK_ArtistSong_Song] FOREIGN KEY([SongID])
REFERENCES [dbo].[Song] ([SongID])
GO
ALTER TABLE [dbo].[ArtistSong] CHECK CONSTRAINT [FK_ArtistSong_Song]
GO
ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_Fandom] FOREIGN KEY([FandomID])
REFERENCES [dbo].[Fandom] ([FandomID])
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_Fandom]
GO
ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_Label] FOREIGN KEY([LabelID])
REFERENCES [dbo].[Label] ([LabelID])
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_Label]
GO
ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_SNS] FOREIGN KEY([SnsID])
REFERENCES [dbo].[SNS] ([SnsID])
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_SNS]
GO
ALTER TABLE [dbo].[GroupImage]  WITH CHECK ADD  CONSTRAINT [FK_GroupImage_Group] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Group] ([GroupID])
GO
ALTER TABLE [dbo].[GroupImage] CHECK CONSTRAINT [FK_GroupImage_Group]
GO
ALTER TABLE [dbo].[GroupImage]  WITH CHECK ADD  CONSTRAINT [FK_GroupImage_Image] FOREIGN KEY([ImageID])
REFERENCES [dbo].[Image] ([ImageID])
GO
ALTER TABLE [dbo].[GroupImage] CHECK CONSTRAINT [FK_GroupImage_Image]
GO
ALTER TABLE [dbo].[GroupSong]  WITH CHECK ADD  CONSTRAINT [FK_GroupSong_Group] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Group] ([GroupID])
GO
ALTER TABLE [dbo].[GroupSong] CHECK CONSTRAINT [FK_GroupSong_Group]
GO
ALTER TABLE [dbo].[GroupSong]  WITH CHECK ADD  CONSTRAINT [FK_GroupSong_Song] FOREIGN KEY([SongID])
REFERENCES [dbo].[Song] ([SongID])
GO
ALTER TABLE [dbo].[GroupSong] CHECK CONSTRAINT [FK_GroupSong_Song]
GO
ALTER TABLE [dbo].[SongImage]  WITH CHECK ADD  CONSTRAINT [FK_SongImage_Image] FOREIGN KEY([ImageID])
REFERENCES [dbo].[Image] ([ImageID])
GO
ALTER TABLE [dbo].[SongImage] CHECK CONSTRAINT [FK_SongImage_Image]
GO
ALTER TABLE [dbo].[SongImage]  WITH CHECK ADD  CONSTRAINT [FK_SongImage_Song] FOREIGN KEY([SongID])
REFERENCES [dbo].[Song] ([SongID])
GO
ALTER TABLE [dbo].[SongImage] CHECK CONSTRAINT [FK_SongImage_Song]
GO
/****** Object:  StoredProcedure [dbo].[Album_Basic_Infor]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Album_Basic_Infor]
AS
SELECT
AlbumID as 'ID', 
Name as N'Tên',
ReleaseDay as N'Ra mắt'
FROM [Album] WHERE AlbumID <> 0
GO
/****** Object:  StoredProcedure [dbo].[Album_Delete]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Album_Delete](@AlbumID INT)AS
DELETE [AlbumSong] WHERE AlbumID = @AlbumID
DELETE [Album] WHERE AlbumID = @AlbumID
GO
/****** Object:  StoredProcedure [dbo].[Album_DeleteSong]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Album_DeleteSong]
(@AlbumID INT, @SongID INT)
AS
	BEGIN 
	DELETE [AlbumSong] WHERE SongID = @SongID AND AlbumID = @AlbumID
	END
GO
/****** Object:  StoredProcedure [dbo].[Album_GetSong]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Album_GetSong](@AlbumID INT)
AS
SELECT _Song.* FROM [Song] _Song
LEFT JOIN [AlbumSong] _AlbumSong ON _AlbumSong.SongID = _Song.SongID
LEFT JOIN [Album] _Album ON _Album.AlbumID = _AlbumSong.AlbumID
WHERE _Album.AlbumID = @AlbumID
GO
/****** Object:  StoredProcedure [dbo].[Album_InsertBase]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Album_InsertBase]
(@Name NVARCHAR(50),
@ReleaseDay DATE,
@Description NVARCHAR(MAX))
AS

DECLARE @AlbumInsertedID int;

	INSERT INTO [Album](Name, ReleaseDay, Description)
	VALUES
	(@Name, @ReleaseDay, @Description);

	SET @AlbumInsertedID = SCOPE_IDENTITY()
SELECT @AlbumInsertedID
GO
/****** Object:  StoredProcedure [dbo].[Album_InsertSong]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Album_InsertSong]
(@AlbumID INT, @SongID INT) AS
	BEGIN
	INSERT INTO [AlbumSong](SongID, AlbumID)VALUES 
	(@SongID, @AlbumID)
	END
GO
/****** Object:  StoredProcedure [dbo].[Album_Search]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Album_Search]
(@SearchType NVARCHAR(50), @AlbumID INT, @Name NVARCHAR(50), @Description NVARCHAR(MAX))
AS
	IF(@SearchType = 'ID')
		BEGIN
			SELECT 
			AlbumID as 'ID', 
			Name as N'Tên',
			ReleaseDay as N'Ra mắt'

			FROM [Album] WHERE AlbumID = @AlbumID
		END
	ELSE IF(@SearchType = 'Name')
		BEGIN
			SELECT 
			AlbumID as 'ID', 
			Name as N'Tên',
			ReleaseDay as N'Ra mắt'
			FROM [Album] WHERE Name LIKE CONCAT('%',@Name,'%')
		END
	ELSE IF(@SearchType = 'Description')
		BEGIN
			SELECT 
			AlbumID as 'ID', 
			Name as N'Tên',
			ReleaseDay as N'Ra mắt'
			FROM [Album] WHERE Description LIKE CONCAT('%',@Description,'%')
		END
GO
/****** Object:  StoredProcedure [dbo].[Album_UpdateBase]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Album_UpdateBase]
(@AlbumID INT,
@Name NVARCHAR(50),
@ReleaseDay DATE,
@Description NVARCHAR(MAX))
AS
UPDATE [Album] SET
Name =@Name, ReleaseDay = @ReleaseDay, Description = @Description
WHERE AlbumID = @AlbumID
GO
/****** Object:  StoredProcedure [dbo].[Artist_Basic_Infor]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Artist_Basic_Infor]
AS
SELECT
--_Image.ImageURL as 'Ảnh',
--_Image.ImageURL as 'Ảnh',
ArtistID as 'ID', 
StageName as N'Nghệ danh', 
RealName as N'Tên thật', 
BirthDay as N'Ngày sinh',
BirthPlace as N'Nơi sinh',
DebutDay as N'Ra mắt'
FROM [Artist] WHERE IsActivate = 1 AND  ArtistID <> 0
GO
/****** Object:  StoredProcedure [dbo].[Artist_Delete]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Artist_Delete]
(@ArtistID INT)
AS
declare @SnsID INT = (SELECT SnsID FROM [Artist] WHERE ArtistID = @ArtistID)
BEGIN
DELETE [ArtistImage] WHERE ArtistID = @ArtistID
DELETE [ArtistGroup] WHERE ArtistID = @ArtistID
DELETE [ArtistSong] WHERE ArtistID = @ArtistID
DELETE [Artist] WHERE ArtistID = @ArtistID
DELETE [SNS] WHERE SnsID = @SnsID
END
GO
/****** Object:  StoredProcedure [dbo].[Artist_DeleteGroup]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Artist_DeleteGroup]
(@ArtistID INT, @GroupID INT)
AS
	BEGIN 
	DELETE [ArtistGroup] WHERE GroupID = @GroupID AND ArtistID = @ArtistID
	END
GO
/****** Object:  StoredProcedure [dbo].[Artist_DeleteImage]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Artist_DeleteImage]
(@ArtistID INT, @ImageID INT)
AS
	DELETE [ArtistImage] WHERE ImageID = @ImageID AND ArtistID = @ArtistID
GO
/****** Object:  StoredProcedure [dbo].[Artist_DeleteSong]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Artist_DeleteSong]
(@ArtistID INT, @SongID INT)
AS
	BEGIN 
	DELETE [ArtistSong] WHERE SongID = @SongID AND ArtistID = @ArtistID
	END
GO
/****** Object:  StoredProcedure [dbo].[Artist_GetAlbum]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Artist_GetAlbum] 
(@ArtistID INT)
AS
SELECT DISTINCT  _Album.* FROM [Album] _Album


LEFT JOIN [AlbumSong] _AlbumSong ON _AlbumSong.AlbumID = _Album.AlbumID

LEFT JOIN [Song] _Song ON _Song.SongID = _AlbumSong.SongID

LEFT JOIN [ArtistSong] _ArtistSong ON _ArtistSong.SongID = _Song.SongID

LEFT JOIN [Artist] _Artist ON _Artist.ArtistID = _ArtistSong.ArtistID

WHERE _Artist.ArtistID = @ArtistID
GO
/****** Object:  StoredProcedure [dbo].[Artist_GetGroup]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Artist_GetGroup] 
(@ArtistID INT)
AS 
IF EXISTS (SELECT _Group.* FROM [Group] _Group
LEFT JOIN [ArtistGroup] _ArtistGroup ON _ArtistGroup.GroupID = _Group.GroupID
LEFT JOIN [Artist] _Artist ON _Artist.ArtistID = _ArtistGroup.ArtistID
WHERE _Artist.ArtistID = @ArtistID)
BEGIN
	SELECT _Group.* FROM [Group] _Group
	LEFT JOIN [ArtistGroup] _ArtistGroup ON _ArtistGroup.GroupID = _Group.GroupID
	LEFT JOIN [Artist] _Artist ON _Artist.ArtistID = _ArtistGroup.ArtistID
	WHERE _Artist.ArtistID = @ArtistID
	END

	ELSE
BEGIN
	SELECT 0 as 'GroupID', N'Không có' as 'Name', CONVERT(datetime, '1900-1-1') as 'DebutDay', 0 as 'FandomID', N'Không có' as 'Description'
	END
GO
/****** Object:  StoredProcedure [dbo].[Artist_GetImage]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Artist_GetImage] 
(@ArtistID INT)
AS
SELECT _Image.* FROM [Image] _Image
LEFT JOIN [ArtistImage] _ArtistImage ON _ArtistImage.ImageID = _Image.ImageID
LEFT JOIN [Artist] _Artist ON _ArtistImage.ArtistID = _Artist.ArtistID
WHERE _Artist.ArtistID = @ArtistID
GO
/****** Object:  StoredProcedure [dbo].[Artist_GetLabel]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Artist_GetLabel]
(@ArtistID INT)
AS
IF EXISTS (SELECT _Label.Name FROM [Label] _Label
LEFT JOIN [ArtistLabel] _ArtistLabel ON _ArtistLabel.LabelID = _Label.LabelID
LEFT JOIN [Artist] _Artist ON _ArtistLabel.ArtistID = _Artist.ArtistID
WHERE _Artist.ArtistID = @ArtistID)
BEGIN
SELECT _Label.Name FROM [Label] _Label
LEFT JOIN [ArtistLabel] _ArtistLabel ON _ArtistLabel.LabelID = _Label.LabelID
LEFT JOIN [Artist] _Artist ON _ArtistLabel.ArtistID = _Artist.ArtistID
WHERE _Artist.ArtistID = @ArtistID
END
ELSE
BEGIN SELECT N'Không có' as 'Name'
END
GO
/****** Object:  StoredProcedure [dbo].[Artist_GetSNS]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Artist_GetSNS]
(@ArtistID INT)
AS
SELECT _SNS.Youtube, _SNS.Instagram, _SNS.Facebook, _SNS.Twitter, _SNS.Tiktok FROM [SNS] _SNS
LEFT JOIN [ArtistSNS] _ArtistSNS ON _ArtistSNS.SnsID = _SNS.SnsID
LEFT JOIN [Artist] _Artist ON _ArtistSNS.ArtistID = _Artist.ArtistID
WHERE _Artist.ArtistID = @ArtistID
GO
/****** Object:  StoredProcedure [dbo].[Artist_GetSong]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Artist_GetSong](@ArtistID INT)
AS
SELECT _Song.* FROM [Song] _Song
LEFT JOIN [ArtistSong] _ArtistSong ON _ArtistSong.SongID = _Song.SongID
LEFT JOIN [Artist] _Artist ON _Artist.ArtistID = _ArtistSong.ArtistID
WHERE _Artist.ArtistID = @ArtistID
GO
/****** Object:  StoredProcedure [dbo].[Artist_Hide]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Artist_Hide]
(@ArtistID INT)
AS
BEGIN
	UPDATE [Artist] SET IsActivate = 0 
	WHERE ArtistID = @ArtistID
END
GO
/****** Object:  StoredProcedure [dbo].[Artist_InsertBase]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Artist_InsertBase]
(@StageName NVARCHAR(50),
@RealName NVARCHAR(50),
@Gender BIT,
@BirthDay DATE,
@BirthPlace NVARCHAR(100),
@DebutDay DATE,
@Description NVARCHAR(MAX),
@FandomID INT,
@Height FLOAT,
@Weight FLOAT,
@LabelID INT)
AS
----------RESET IDENTITY ID----------
--DECLARE @CountID int;
--SET @CountID = (SELECT Count(*) FROM [Artist])
--DBCC CHECKIDENT ([Artist], RESEED, @CountID);
-------------------------------------
DECLARE @ArtistInsertedID int;

	INSERT INTO [Artist](StageName, RealName, Gender, BirthDay, BirthPlace,
	DebutDay, Description, FandomID, Height, Weight, LabelID, SnsID)
	VALUES
	(@StageName, @RealName, @Gender, @BirthDay, @BirthPlace,
	@DebutDay, @Description, @FandomID, @Height, @Weight, @LabelID, 0);

	SET @ArtistInsertedID = SCOPE_IDENTITY()
SELECT @ArtistInsertedID
GO
/****** Object:  StoredProcedure [dbo].[Artist_InsertGroup]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Artist_InsertGroup]
(@ArtistID INT, @GroupID INT) AS
	BEGIN
	INSERT INTO [ArtistGroup](GroupID, ArtistID) VALUES (@GroupID, @ArtistID);
	END
GO
/****** Object:  StoredProcedure [dbo].[Artist_InsertImage]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Artist_InsertImage]
(@ArtistID INT, @ImageID INT, @ImageURL NVARCHAR(MAX), @Description NVARCHAR(100))
AS

	BEGIN
	DECLARE @ImageInsertedID int;

	IF(@ImageID = 0)
		BEGIN
		INSERT INTO [Image](ImageURL, Description)
		VALUES(@ImageURL, @Description);
		SET @ImageInsertedID = (SELECT ImageID FROM [Image] WHERE ImageURL = @ImageURL); -- SCOPE_IDENTITY() cũng được
		END
	ELSE
		BEGIN
		SET @ImageInsertedID = @ImageID;
		END

	INSERT INTO [ArtistImage] (ImageID, ArtistID) VALUES (@ImageInsertedID, @ArtistID)
	END
GO
/****** Object:  StoredProcedure [dbo].[Artist_InsertSNS]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Artist_InsertSNS](
@ArtistID INT,
@Youtube NVARCHAR(MAX),
@Instagram NVARCHAR(MAX),
@Facebook NVARCHAR(MAX),
@Twitter NVARCHAR(MAX),
@Tiktok NVARCHAR(MAX),
@Vlive NVARCHAR(MAX),
@AppleMusic NVARCHAR(MAX),
@Spotify NVARCHAR(MAX),
@Website NVARCHAR(MAX))
AS 
	BEGIN
	DECLARE @SNSInsertedID int;
	INSERT INTO [SNS](Youtube,	Instagram, Facebook,
	Twitter, Tiktok, Vlive, AppleMusic, Spotify, Website)
	VALUES
	(@Youtube,	@Instagram, @Facebook,
	@Twitter, @Tiktok, @Vlive, @AppleMusic, @Spotify, @Website)
	SET @SNSInsertedID = SCOPE_IDENTITY();
	
	UPDATE [Artist] 
	SET SnsID = @SNSInsertedID
	WHERE ArtistID = @ArtistID
	END
GO
/****** Object:  StoredProcedure [dbo].[Artist_InsertSong]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Artist_InsertSong]
(@ArtistID INT, @SongID INT) AS
	BEGIN
	INSERT INTO [ArtistSong](SongID, ArtistID)VALUES 
	(@SongID, @ArtistID)
	END
GO
/****** Object:  StoredProcedure [dbo].[Artist_Search]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Artist_Search]
(@SearchType NVARCHAR(50), @ArtistID INT, @StageName NVARCHAR(50), @RealName NVARCHAR(50), @Description NVARCHAR(MAX))
AS
	IF(@SearchType = 'ID')
		BEGIN
			SELECT
			ArtistID as 'ID', 
			StageName as N'Nghệ danh', 
			RealName as N'Tên thật', 
			BirthDay as N'Ngày sinh',
			BirthPlace as N'Nơi sinh',
			DebutDay as N'Ra mắt'
			FROM [Artist] WHERE IsActivate = 1 AND  ArtistID <> 0 AND ArtistID = @ArtistID
		END
	ELSE IF(@SearchType = 'StageName')
		BEGIN
			SELECT
			ArtistID as 'ID', 
			StageName as N'Nghệ danh', 
			RealName as N'Tên thật', 
			BirthDay as N'Ngày sinh',
			BirthPlace as N'Nơi sinh',
			DebutDay as N'Ra mắt'
			FROM [Artist] WHERE IsActivate = 1 AND  ArtistID <> 0 AND StageName LIKE CONCAT('%',@StageName,'%')
		END
	ELSE IF(@SearchType = 'RealName')
		BEGIN
			SELECT
			ArtistID as 'ID', 
			StageName as N'Nghệ danh', 
			RealName as N'Tên thật', 
			BirthDay as N'Ngày sinh',
			BirthPlace as N'Nơi sinh',
			DebutDay as N'Ra mắt'
			FROM [Artist] WHERE IsActivate = 1 AND  ArtistID <> 0 AND RealName LIKE CONCAT('%',@RealName,'%')
		END
	ELSE IF(@SearchType = 'Description')
		BEGIN
			SELECT
			ArtistID as 'ID', 
			StageName as N'Nghệ danh', 
			RealName as N'Tên thật', 
			BirthDay as N'Ngày sinh',
			BirthPlace as N'Nơi sinh',
			DebutDay as N'Ra mắt'
			FROM [Artist] WHERE IsActivate = 1 AND  ArtistID <> 0 AND Description LIKE CONCAT('%',@Description,'%')
		END

GO
/****** Object:  StoredProcedure [dbo].[Artist_Trash]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Artist_Trash]
AS
SELECT
ArtistID as 'ID', 
StageName as N'Nghệ danh', 
RealName as N'Tên thật', 
BirthDay as N'Ngày sinh',
BirthPlace as N'Nơi sinh',
DebutDay as N'Ra mắt'
FROM [Artist] WHERE IsActivate = 0 AND  ArtistID <> 0
GO
/****** Object:  StoredProcedure [dbo].[Artist_UpdateBase]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Artist_UpdateBase]
(@ArtistID INT,
@StageName NVARCHAR(50),
@RealName NVARCHAR(50),
@Gender BIT,
@BirthDay DATE,
@BirthPlace NVARCHAR(100),
@DebutDay DATE,
@Description NVARCHAR(MAX),
@FandomID INT,
@Height FLOAT,
@Weight FLOAT,
@LabelID INT)
AS
	BEGIN
	UPDATE [Artist] 
	SET
	StageName = @StageName,
	RealName = @RealName,
	Gender = @Gender,
	BirthDay = @BirthDay,
	BirthPlace = @BirthPlace,
	DebutDay = @DebutDay,
	Description = @Description,
	FandomID = @FandomID,
	Height = @Height,
	Weight = @Weight,
	LabelID = @LabelID
	WHERE ArtistID = @ArtistID
	END

GO
/****** Object:  StoredProcedure [dbo].[Artist_UpdateImage]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Artist_UpdateImage]
(@ImageID INT, @ImageURL nvarchar(MAX), @Description nvarchar(100))
AS
UPDATE [Image] SET ImageURL = @ImageURL,Description = @Description
WHERE ImageID =  @ImageID
GO
/****** Object:  StoredProcedure [dbo].[Artist_UpdateSNS]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Artist_UpdateSNS](
@ArtistID INT,
@Youtube NVARCHAR(MAX),
@Instagram NVARCHAR(MAX),
@Facebook NVARCHAR(MAX),
@Twitter NVARCHAR(MAX),
@Tiktok NVARCHAR(MAX),
@Vlive NVARCHAR(MAX),
@AppleMusic NVARCHAR(MAX),
@Spotify NVARCHAR(MAX),
@Website NVARCHAR(MAX))
AS 
	BEGIN
	DECLARE @SnsID int;
	SET @SnsID = (SELECT SnsID FROM Artist WHERE ArtistID =  @ArtistID)
	
	UPDATE [SNS] SET
	Youtube = @Youtube, 
	Instagram = @Instagram, 
	Facebook = @Facebook,
	Twitter = @Twitter, 
	Tiktok = @Tiktok, 
	Vlive = @Vlive, 
	AppleMusic = @AppleMusic, 
	Spotify = @Spotify, 
	Website = @Website
	WHERE SnsID = @SnsID
	END
GO
/****** Object:  StoredProcedure [dbo].[Fandom_Basic_Infor]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Fandom_Basic_Infor]
AS
SELECT
FandomID as 'ID', 
Name as N'Tên',
Description as N'Mô tả'

FROM [Fandom]  WHERE FandomID <> 0
GO
/****** Object:  StoredProcedure [dbo].[Fandom_Delete]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Fandom_Delete]
(@FandomID INT)AS

-- Cập nhật artist label về 0
UPDATE [Artist] SET FandomID = 0 WHERE FandomID = @FandomID
-- Cập nhật group label về 0
UPDATE [Group] SET FandomID = 0 WHERE FandomID = @FandomID
DELETE [Fandom] WHERE FandomID = @FandomID
GO
/****** Object:  StoredProcedure [dbo].[Fandom_InsertBase]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Fandom_InsertBase](
@Name NVARCHAR(50),
@Description NVARCHAR(MAX))
AS 
	BEGIN
	DECLARE @FandomInsertedID int;
	INSERT INTO [Fandom](Name, Description)
	VALUES
	(@Name, @Description)
	SET @FandomInsertedID = SCOPE_IDENTITY();
	SELECT @FandomInsertedID

	END
GO
/****** Object:  StoredProcedure [dbo].[Fandom_Search]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Fandom_Search]
(@SearchType NVARCHAR(50), @FandomID INT, @Name NVARCHAR(50), @Description NVARCHAR(MAX))
AS
	IF(@SearchType = 'ID')
		BEGIN
			SELECT 
			FandomID as 'ID', 
			Name as N'Tên',
			Description as N'Mô tả'

			FROM [Fandom] WHERE FandomID = @FandomID
		END
	ELSE IF(@SearchType = 'Name')
		BEGIN
			SELECT 
			FandomID as 'ID', 
			Name as N'Tên',
			Description as N'Mô tả'
			FROM [Fandom] WHERE Name LIKE CONCAT('%',@Name,'%')
		END
	ELSE IF(@SearchType = 'Description')
		BEGIN
			SELECT 
			FandomID as 'ID', 
			Name as N'Tên',
			Description as N'Mô tả'
			FROM [Fandom] WHERE Description LIKE CONCAT('%',@Description,'%')
		END
GO
/****** Object:  StoredProcedure [dbo].[Fandom_UpdateBase]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROC [dbo].[Fandom_UpdateBase](@FandomID INT, @Name nvarchar(50), @Description nvarchar(max))
	AS
	UPDATE [Fandom] SET
	Name = @Name, Description = @Description
	WHERE FandomID = @FandomID
GO
/****** Object:  StoredProcedure [dbo].[Group_Basic_Infor]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Group_Basic_Infor]
AS
SELECT
GroupID as 'ID', 
Name as N'Tên',
DebutDay as N'Ra mắt'
FROM [Group] WHERE IsActivate = 1 AND GroupID <> 0
GO
/****** Object:  StoredProcedure [dbo].[Group_Delete]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Group_Delete]
(@GroupID INT)
AS
declare @SnsID int = (SELECT SnsID FROM [Group] WHERE GroupID = @GroupID);
BEGIN
DELETE FROM [ArtistGroup] WHERE GroupID = @GroupID;
DELETE FROM [GroupSong] WHERE GroupID = @GroupID;
DELETE FROM [Group] WHERE GroupID = @GroupID;
DELETE FROM [SNS] WHERE SnsID = @SnsID
END
GO
/****** Object:  StoredProcedure [dbo].[Group_DeleteSong]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Group_DeleteSong]
(@GroupID INT, @SongID INT)
AS
	BEGIN 
	DELETE [GroupSong] WHERE SongID = @SongID AND GroupID = @GroupID
	END
GO
/****** Object:  StoredProcedure [dbo].[Group_GetAlbum]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Group_GetAlbum]
(@GroupID INT)
AS
SELECT DISTINCT  _Album.* FROM [Album] _Album


LEFT JOIN [AlbumSong] _AlbumSong ON _AlbumSong.AlbumID = _Album.AlbumID

LEFT JOIN [Song] _Song ON _Song.SongID = _AlbumSong.SongID

LEFT JOIN [GroupSong] _GroupSong ON _GroupSong.SongID = _Song.SongID

LEFT JOIN [Group] _Group ON _Group.GroupID = _GroupSong.GroupID

WHERE _Group.GroupID = @GroupID
GO
/****** Object:  StoredProcedure [dbo].[Group_GetImage]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Group_GetImage]
(@GroupID INT)
AS
SELECT _Image.* FROM [Image] _Image
LEFT JOIN [GroupImage] _GroupImage ON _GroupImage.ImageID = _Image.ImageID
LEFT JOIN [Group] _Group ON _GroupImage.GroupID = _Group.GroupID
WHERE _Group.GroupID = @GroupID
GO
/****** Object:  StoredProcedure [dbo].[Group_GetSong]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Group_GetSong](@GroupID INT)
AS
SELECT _Song.* FROM [Song] _Song
LEFT JOIN [GroupSong] _GroupSong ON _GroupSong.SongID = _Song.SongID
LEFT JOIN [Group] _Group ON _Group.GroupID = _GroupSong.GroupID
WHERE _Group.GroupID = @GroupID
GO
/****** Object:  StoredProcedure [dbo].[Group_Hide]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Group_Hide]
(@GroupID INT)
AS
BEGIN
	UPDATE [Group] SET IsActivate = 0 
	WHERE GroupID = @GroupID
END
GO
/****** Object:  StoredProcedure [dbo].[Group_InsertBase]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Group_InsertBase]
(@Name NVARCHAR(50),
@DebutDay DATE,
@FandomID INT,
@Description Nvarchar(MAX),
@LabelID INT)
AS
DECLARE @GroupInsertedID int;
	INSERT INTO [Group](Name, DebutDay, FandomID, Description, LabelID)
	VALUES
	(@Name, @DebutDay, @FandomID, @Description, @LabelID);

	SET @GroupInsertedID = SCOPE_IDENTITY()
	SELECT @GroupInsertedID
GO
/****** Object:  StoredProcedure [dbo].[Group_InsertSNS]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Group_InsertSNS](
@GroupID INT,
@Youtube NVARCHAR(MAX),
@Instagram NVARCHAR(MAX),
@Facebook NVARCHAR(MAX),
@Twitter NVARCHAR(MAX),
@Tiktok NVARCHAR(MAX),
@Vlive NVARCHAR(MAX),
@AppleMusic NVARCHAR(MAX),
@Spotify NVARCHAR(MAX),
@Website NVARCHAR(MAX))
AS 
	BEGIN
	DECLARE @SNSInsertedID int;
	INSERT INTO [SNS](Youtube,	Instagram, Facebook,
	Twitter, Tiktok, Vlive, AppleMusic, Spotify, Website)
	VALUES
	(@Youtube,	@Instagram, @Facebook,
	@Twitter, @Tiktok, @Vlive, @AppleMusic, @Spotify, @Website)
	SET @SNSInsertedID = SCOPE_IDENTITY();
	
	UPDATE [Group] 
	SET SnsID = @SNSInsertedID
	WHERE GroupID = @GroupID
	END
GO
/****** Object:  StoredProcedure [dbo].[Group_InsertSong]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Group_InsertSong]
(@GroupID INT, @SongID INT) AS
	BEGIN
	INSERT INTO [GroupSong](SongID, GroupID)VALUES 
	(@SongID, @GroupID)
	END
GO
/****** Object:  StoredProcedure [dbo].[Group_Search]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Group_Search]
(@SearchType NVARCHAR(50), @GroupID INT, @Name NVARCHAR(50), @Description NVARCHAR(MAX))
AS
	IF(@SearchType = 'ID')
		BEGIN
			SELECT
			GroupID as 'ID', 
			Name as N'Tên',
			DebutDay as N'Ra mắt'
			FROM [Group] WHERE IsActivate = 1 AND GroupID <> 0 AND GroupID = @GroupID
		END
	ELSE IF(@SearchType = 'Name')
		BEGIN
			SELECT
			GroupID as 'ID', 
			Name as N'Tên',
			DebutDay as N'Ra mắt'
			FROM [Group] WHERE IsActivate = 1 AND GroupID <> 0 AND Name LIKE CONCAT('%',@Name,'%')
		END
	ELSE IF(@SearchType = 'Description')
		BEGIN
			SELECT
			GroupID as 'ID', 
			Name as N'Tên',
			DebutDay as N'Ra mắt'
			FROM [Group] WHERE IsActivate = 1 AND GroupID <> 0 AND Description LIKE CONCAT('%',@Description,'%')
		END
			
GO
/****** Object:  StoredProcedure [dbo].[Group_UpdateBase]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Group_UpdateBase]
(@GroupID INT,
@Name NVARCHAR(50),
@DebutDay DATE,
@FandomID INT,
@Description Nvarchar(MAX),
@LabelID INT)
AS
	BEGIN 
	UPDATE [Group] SET
	Name = @Name,
	DebutDay = @DebutDay,
	FandomID = @FandomID,
	Description = @Description,
	LabelID = @LabelID
	WHERE GroupID = @GroupID
	END
GO
/****** Object:  StoredProcedure [dbo].[Group_UpdateSNS]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Group_UpdateSNS](
@GroupID INT,
@Youtube NVARCHAR(MAX),
@Instagram NVARCHAR(MAX),
@Facebook NVARCHAR(MAX),
@Twitter NVARCHAR(MAX),
@Tiktok NVARCHAR(MAX),
@Vlive NVARCHAR(MAX),
@AppleMusic NVARCHAR(MAX),
@Spotify NVARCHAR(MAX),
@Website NVARCHAR(MAX))
AS 
	BEGIN
	DECLARE @SnsID int;
	SET @SnsID = (SELECT SnsID FROM [Group] WHERE GroupID =  @GroupID)
	
	UPDATE [SNS] SET
	Youtube = @Youtube, 
	Instagram = @Instagram, 
	Facebook = @Facebook,
	Twitter = @Twitter, 
	Tiktok = @Tiktok, 
	Vlive = @Vlive, 
	AppleMusic = @AppleMusic, 
	Spotify = @Spotify, 
	Website = @Website
	WHERE SnsID = @SnsID
	END
GO
/****** Object:  StoredProcedure [dbo].[Label_Basic_Infor]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Label_Basic_Infor]
AS
SELECT
LabelID as 'ID', 
Name as N'Tên',
Founder as N'Người t.lập',
Founded as N'Ngày t.lập',
Location as N'Vị trí'
FROM [Label] WHERE LabelID <> 0
GO
/****** Object:  StoredProcedure [dbo].[Label_Delete]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Label_Delete]
(@LabelID INT)AS

-- Cập nhật artist label về 0
UPDATE [Artist] SET LabelID = 0 WHERE LabelID = @LabelID
-- Cập nhật group label về 0
UPDATE [Group] SET LabelID = 0 WHERE LabelID = @LabelID
DELETE [Label] WHERE LabelID = @LabelID
GO
/****** Object:  StoredProcedure [dbo].[Label_InsertBase]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Label_InsertBase]
(@Name nvarchar(30), @Founder nvarchar(100), 
@Founded DATE, @Location nvarchar(100), @Description nvarchar(max))
AS
	DECLARE @LabelInsertedID int;
	INSERT INTO [Label](Name, Founder, Founded, Location, Description) VALUES (@Name, @Founder, @Founded, @Location, @Description)
		SET @LabelInsertedID = SCOPE_IDENTITY()
SELECT @LabelInsertedID
GO
/****** Object:  StoredProcedure [dbo].[Label_Search]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Label_Search]
(@SearchType NVARCHAR(50), @LabelID INT, @Name NVARCHAR(50), @Description NVARCHAR(MAX))
AS
	IF(@SearchType = 'ID')
		BEGIN
			SELECT 
			LabelID as 'ID', 
			Name as N'Tên',
			Founder as N'Người t.lập',
			Founded as N'Ngày t.lập',
			Location as N'Vị trí'

			FROM [Label] WHERE LabelID = @LabelID
		END
	ELSE IF(@SearchType = 'Name')
		BEGIN
			SELECT 
			LabelID as 'ID', 
			Name as N'Tên',
			Founder as N'Người t.lập',
			Founded as N'Ngày t.lập',
			Location as N'Vị trí'
			FROM [Label] WHERE Name LIKE CONCAT('%',@Name,'%')
		END
	ELSE IF(@SearchType = 'Description')
		BEGIN
			SELECT 
			LabelID as 'ID', 
			Name as N'Tên',
			Founder as N'Người t.lập',
			Founded as N'Ngày t.lập',
			Location as N'Vị trí'
			FROM [Label] WHERE Description LIKE CONCAT('%',@Description,'%')
		END
GO
/****** Object:  StoredProcedure [dbo].[Label_UpdateBase]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Label_UpdateBase]
(@LabelID INT,
@Name NVARCHAR(30),
@Founder NVARCHAR(100),
@Founded DATE,
@Location Nvarchar(100),
@Description NVARCHAR(MAX))
AS
	BEGIN 
	UPDATE [Label] SET
	Name = @Name,
	Founder = @Founder,
	Founded = @Founded,
	Location = @Location,
	Description = @Description
	WHERE LabelID = @LabelID
	END
GO
/****** Object:  StoredProcedure [dbo].[Song_Basic_Infor]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Song_Basic_Infor]
AS
SELECT 
SongID as 'ID',
Name as N'Tên',
ReleaseDay as N'Phát hành',
Genre as N'Thể loại'
FROM [Song] 
GO
/****** Object:  StoredProcedure [dbo].[Song_Delete]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Song_Delete](@SongID INT)AS
DELETE [ArtistSong] WHERE SongID = @SongID
DELETE [GroupSong] WHERE SongID = @SongID
DELETE [AlbumSong] WHERE SongID = @SongID
DELETE [Song] WHERE SongID = @SongID
GO
/****** Object:  StoredProcedure [dbo].[Song_InsertBase]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Song_InsertBase]
(@Name NVARCHAR(50), @ReleaseDay DATE, 
@Genre NVARCHAR(100), @Producer NVARCHAR(200), @Description nvarchar(max))
AS
	DECLARE @SongInsertedID int;
	INSERT INTO [Song](Name, ReleaseDay, Genre, Producer, Description)VALUES
	(@Name, @ReleaseDay, @Genre, @Producer, @Description)

		SET @SongInsertedID = SCOPE_IDENTITY()
SELECT @SongInsertedID
GO
/****** Object:  StoredProcedure [dbo].[Song_Search]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Song_Search]
(@SearchType NVARCHAR(50), @SongID INT, @Name NVARCHAR(50), @Description NVARCHAR(MAX))
AS
	IF(@SearchType = 'ID')
		BEGIN
			SELECT 
			SongID as 'ID',
			Name as N'Tên',
			ReleaseDay as N'Phát hành',
			Genre as N'Thể loại'
			FROM [Song] WHERE SongID = @SongID
		END
	ELSE IF(@SearchType = 'Name')
		BEGIN
			SELECT 
			SongID as 'ID',
			Name as N'Tên',
			ReleaseDay as N'Phát hành',
			Genre as N'Thể loại'
			FROM [Song] WHERE Name LIKE CONCAT('%',@Name,'%')
		END
	ELSE IF(@SearchType = 'Description')
		BEGIN
			SELECT 
			SongID as 'ID',
			Name as N'Tên',
			ReleaseDay as N'Phát hành',
			Genre as N'Thể loại'
			FROM [Song] WHERE Description LIKE CONCAT('%',@Description,'%')
		END
GO
/****** Object:  StoredProcedure [dbo].[Song_UpdateBase]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Song_UpdateBase]
(@SongID INT, @Name NVARCHAR(50), @ReleaseDay DATE, 
@Genre NVARCHAR(100), @Producer NVARCHAR(200), @Description nvarchar(max))
AS
	BEGIN
	UPDATE [Song] SET
	Name = @Name,
	ReleaseDay = @ReleaseDay,
	Genre = @Genre,
	Producer = @Producer,
	Description = @Description
	WHERE SongID = @SongID
	END
GO
/****** Object:  StoredProcedure [dbo].[TestUserRegister]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TestUserRegister]
    (@username VARCHAR(100),
    @password VARCHAR(100))
AS
BEGIN
    SET NOCOUNT ON;
     
    IF EXISTS(SELECT username FROM TestRegister WHERE username = @username)
    BEGIN
        SELECT -1  as 'Status'--username exists already
    END
    ELSE
    BEGIN
        INSERT INTO TestRegister
                (username, password)
        VALUES (@username,
                @password)
        SELECT 1 as 'Status'
    END
END
GO
/****** Object:  StoredProcedure [dbo].[User_ChangePassword]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[User_ChangePassword](@UserName nvarchar(30), @OldPwd nvarchar(30), @NewPwd nvarchar(30)) AS
IF EXISTS(SELECT * FROM [User] WHERE UserName = @UserName AND Password = @OldPwd)
	BEGIN
	UPDATE [User] SET Password = @NewPwd WHERE UserName = @UserName
	Select 1
	END
ELSE
	SELECT 0
GO
/****** Object:  StoredProcedure [dbo].[UserLogin]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserLogin] 
@username varchar(30), @password varchar(30)
AS
IF EXISTS (SELECT * FROM [User] WHERE username = @username AND password = @password) 
	BEGIN
    SELECT 1 as 'Status', UserName, FullName FROM [User] WHERE username = @username
	END
ELSE
	BEGIN
    SELECT 0 as 'Status',''
	END
GO
/****** Object:  StoredProcedure [dbo].[UserRegister]    Script Date: 14/05/2022 9:18:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserRegister]
    (@username VARCHAR(30),
    @password VARCHAR(30),
	@fullname NVARCHAR(50),
    @email VARCHAR (100))
AS
BEGIN
    SET NOCOUNT ON;
    

    IF EXISTS(SELECT username FROM [User] WHERE username = @username)
    BEGIN
        SELECT -1  --username exists already
    END
    ELSE
    BEGIN
		declare @UserID varchar(10);
		declare @count int;
		select @count=count(*) from [User];
		if @count=0
		set @UserID = 'U000000001';
		else
		select @UserID= 'U'+ right(replicate('0',9) + cast(max(cast(substring(UserID,2,9) as int))+1 as nvarchar),9) from [User];

        INSERT INTO [User]
                (UserID, username, password, FullName, email, role)
        VALUES (@UserID,
				@username,
                @password,
				@fullname,
                @email, 0)
        SELECT 1
    END
END
GO
USE [master]
GO
ALTER DATABASE [Artist] SET  READ_WRITE 
GO
