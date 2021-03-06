USE [master]
GO
/****** Object:  Database [OICAR]    Script Date: 17/07/2020 20:48:00 ******/
CREATE DATABASE [OICAR]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OICAR', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OICAR.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OICAR_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OICAR_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OICAR] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OICAR].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OICAR] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OICAR] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OICAR] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OICAR] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OICAR] SET ARITHABORT OFF 
GO
ALTER DATABASE [OICAR] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OICAR] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OICAR] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OICAR] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OICAR] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OICAR] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OICAR] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OICAR] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OICAR] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OICAR] SET  ENABLE_BROKER 
GO
ALTER DATABASE [OICAR] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OICAR] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OICAR] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OICAR] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OICAR] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OICAR] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OICAR] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OICAR] SET RECOVERY FULL 
GO
ALTER DATABASE [OICAR] SET  MULTI_USER 
GO
ALTER DATABASE [OICAR] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OICAR] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OICAR] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OICAR] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OICAR] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'OICAR', N'ON'
GO
ALTER DATABASE [OICAR] SET QUERY_STORE = OFF
GO
USE [OICAR]
GO
/****** Object:  UserDefinedTableType [dbo].[BasicCDT]    Script Date: 17/07/2020 20:48:00 ******/
CREATE TYPE [dbo].[BasicCDT] AS TABLE(
	[EatingHabit] [nvarchar](50) NULL,
	[CategoryName] [nvarchar](50) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[EatingHabbit]    Script Date: 17/07/2020 20:48:00 ******/
CREATE TYPE [dbo].[EatingHabbit] AS TABLE(
	[EatingHabit] [nvarchar](50) NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[IDHabits]    Script Date: 17/07/2020 20:48:00 ******/
CREATE TYPE [dbo].[IDHabits] AS TABLE(
	[ID] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[ItemsType]    Script Date: 17/07/2020 20:48:00 ******/
CREATE TYPE [dbo].[ItemsType] AS TABLE(
	[IngredientName] [nvarchar](50) NOT NULL
)
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 17/07/2020 20:48:00 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Adress]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adress](
	[IdAdress] [int] IDENTITY(1,1) NOT NULL,
	[Rating] [int] NULL,
	[Adress] [nvarchar](50) NOT NULL,
	[Lat] [nvarchar](50) NULL,
	[Long] [nvarchar](50) NULL,
 CONSTRAINT [PK_Adress] PRIMARY KEY CLUSTERED 
(
	[IdAdress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[PhotoPath] [nvarchar](max) NULL,
	[SaladFilter] [bit] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Caterer]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Caterer](
	[IdCaterer] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IDRegisteredCaterer] [nvarchar](50) NULL,
 CONSTRAINT [PK_Caterer] PRIMARY KEY CLUSTERED 
(
	[IdCaterer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CateringFacility]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CateringFacility](
	[IDCateringFacility] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CatererID] [int] NOT NULL,
	[AdressID] [int] NOT NULL,
 CONSTRAINT [PK_CateringFacility] PRIMARY KEY CLUSTERED 
(
	[IDCateringFacility] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[IDCustomer] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Gender] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCustomer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomersHabit]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomersHabit](
	[EatingHabitID] [int] NOT NULL,
	[CustomerID] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EatingHabitID] ASC,
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EatingHabit]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EatingHabit](
	[IDEatingHabit] [int] IDENTITY(1,1) NOT NULL,
	[EatingHabit] [nvarchar](50) NOT NULL,
	[EatingHabitCategoryID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDEatingHabit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EatingHabitCategory]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EatingHabitCategory](
	[IDEatingHabitCategory] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDEatingHabitCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredient]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredient](
	[IdIngredient] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Ingredient] PRIMARY KEY CLUSTERED 
(
	[IdIngredient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[IDItem] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[IDItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemIngredient]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemIngredient](
	[IDItemIngredient] [int] IDENTITY(1,1) NOT NULL,
	[IngredientID] [int] NOT NULL,
	[ItemID] [int] NOT NULL,
	[MeasuringUnitID] [int] NOT NULL,
	[Amount] [int] NULL,
 CONSTRAINT [PK_ItemIngredient] PRIMARY KEY CLUSTERED 
(
	[IDItemIngredient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeasuringUnit]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeasuringUnit](
	[IDMeasureUnit] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_MeasuringUnit] PRIMARY KEY CLUSTERED 
(
	[IDMeasureUnit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[IDMenu] [int] IDENTITY(1,1) NOT NULL,
	[CatererFacilityID] [int] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[IDMenu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuItem]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuItem](
	[IDMenuItem] [int] IDENTITY(1,1) NOT NULL,
	[ItemID] [int] NOT NULL,
	[MenuID] [int] NOT NULL,
	[Price] [int] NULL,
 CONSTRAINT [PK_MenuItem] PRIMARY KEY CLUSTERED 
(
	[IDMenuItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200530124141_Extend_IdentityUser', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200530155257_Photo_Path', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200530155656_IForm_File', N'3.1.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200611161117_filerTest', N'3.1.0')
GO
SET IDENTITY_INSERT [dbo].[Adress] ON 

INSERT [dbo].[Adress] ([IdAdress], [Rating], [Adress], [Lat], [Long]) VALUES (1, NULL, N'Adamićeva ul. 4, 51000, Rijeka, Hrvatska', N'45.3259', N'14.4434')
INSERT [dbo].[Adress] ([IdAdress], [Rating], [Adress], [Lat], [Long]) VALUES (2, NULL, N'Adamićeva ul. 4, 51000, Rijeka, Hrvatska', N'45.3259', N'14.4434')
INSERT [dbo].[Adress] ([IdAdress], [Rating], [Adress], [Lat], [Long]) VALUES (3, NULL, N'15129 Sunnyland Ln, Wellington, FL 33414, Sjedinje', N'26.6303', N'-80.2893')
INSERT [dbo].[Adress] ([IdAdress], [Rating], [Adress], [Lat], [Long]) VALUES (1002, NULL, N'Adamićeva ul. 4, 51000, Rijeka, Hrvatska', N'45.3259', N'14.4434')
INSERT [dbo].[Adress] ([IdAdress], [Rating], [Adress], [Lat], [Long]) VALUES (1003, NULL, N'Adamićeva ul. 4, 51000, Rijeka, Hrvatska', N'45.3259', N'14.4434')
INSERT [dbo].[Adress] ([IdAdress], [Rating], [Adress], [Lat], [Long]) VALUES (1004, NULL, N'Adamićeva ul. 4, 51000, Rijeka, Hrvatska', N'45.3259', N'14.4434')
INSERT [dbo].[Adress] ([IdAdress], [Rating], [Adress], [Lat], [Long]) VALUES (1005, NULL, N'Adamićeva ul. 4, 51000, Rijeka, Hrvatska', N'45.3259', N'14.4434')
INSERT [dbo].[Adress] ([IdAdress], [Rating], [Adress], [Lat], [Long]) VALUES (1006, NULL, N'15524 East Quail Road Bldg 2, Nevada, MO 64772, Sj', N'37.8074', N'-94.3563')
INSERT [dbo].[Adress] ([IdAdress], [Rating], [Adress], [Lat], [Long]) VALUES (1007, NULL, N'Adamićeva ul. 4, 51000, Rijeka, Hrvatska', N'45.3259', N'14.4434')
INSERT [dbo].[Adress] ([IdAdress], [Rating], [Adress], [Lat], [Long]) VALUES (1008, NULL, N'Adamićeva ul. 4, 51000, Rijeka, Hrvatska', N'45.3259', N'14.4434')
INSERT [dbo].[Adress] ([IdAdress], [Rating], [Adress], [Lat], [Long]) VALUES (1009, NULL, N'Adamićeva ul. 4, 51000, Rijeka, Hrvatska', N'45.3259', N'14.4434')
INSERT [dbo].[Adress] ([IdAdress], [Rating], [Adress], [Lat], [Long]) VALUES (1010, NULL, N'Adamićeva ul. 4, 51000, Rijeka, Hrvatska', N'45.3259', N'14.4434')
INSERT [dbo].[Adress] ([IdAdress], [Rating], [Adress], [Lat], [Long]) VALUES (1011, NULL, N'Adamićeva ul. 4, 51000, Rijeka, Hrvatska', N'45.3259', N'14.4434')
SET IDENTITY_INSERT [dbo].[Adress] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'8d66010b-f487-4349-94a8-9f9c6a10371e', N'User', N'USER', N'90241ddf-9228-4cb9-8c82-08a0e810cbbe')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'f01095d3-1761-4e51-a084-94572f96b8e1', N'Caterer', N'CATERER', N'bdb10dbf-e29c-4c50-b5a9-bc4012c98b04')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6d9b27cc-267e-480a-9eac-432f03392c25', N'8d66010b-f487-4349-94a8-9f9c6a10371e')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'78496f57-2f16-454e-84f2-a8c0d94a2a9e', N'8d66010b-f487-4349-94a8-9f9c6a10371e')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'188e747c-6254-4316-810e-8a3f87d2123f', N'f01095d3-1761-4e51-a084-94572f96b8e1')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [PhotoPath], [SaladFilter]) VALUES (N'188e747c-6254-4316-810e-8a3f87d2123f', N'test1@test1.com', N'TEST1@TEST1.COM', N'test1@test1.com', N'TEST1@TEST1.COM', 1, N'AQAAAAEAACcQAAAAEJJCX/Bc8gJFv2WcW2cW6Z3ONtYA3bGCNBqNr5J5vlZdEQtgbGcGyDcnT7lvMHtO9A==', N'OGY2J5CL2K6XMJZZFYWLKR4KYRZYCNPZ', N'248e2ccd-f450-4cd9-a12d-1af996317beb', NULL, 0, 0, NULL, 1, 0, N'jhb', N'bla', NULL, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [PhotoPath], [SaladFilter]) VALUES (N'6d9b27cc-267e-480a-9eac-432f03392c25', N'test2@2.com', N'TEST2@2.COM', N'test2@2.com', N'TEST2@2.COM', 1, N'AQAAAAEAACcQAAAAEDZRHxUwSbi9wu8RwFYSPGdnDJ3MziWX1fXUt/YFUh6jSqqyHWhwKt8pzNddTi+Ieg==', N'V7MB36B2ND2PWID7ERJ7RZ5FY7IWH7NB', N'5bd100b1-d39f-4fbd-8717-cc16ea9bf6dc', NULL, 0, 0, NULL, 1, 0, N'gfdgfd', N'dfgdfg', NULL, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [PhotoPath], [SaladFilter]) VALUES (N'78496f57-2f16-454e-84f2-a8c0d94a2a9e', N'nsricaz@racunarstvo.hr', N'NSRICAZ@RACUNARSTVO.HR', N'nsricaz@racunarstvo.hr', N'NSRICAZ@RACUNARSTVO.HR', 0, N'AQAAAAEAACcQAAAAEErAsfPh3pg0YUVYY3w/WWTocu7BQ53xQJrvDL49zic47b47iANtRr7MCUTeilFLRw==', N'5VQQSI4SGEAWZTFC5G7Y7ZYMFWOTMK6P', N'4f73fc5f-cdb6-45b4-8a05-44c448d8c178', NULL, 0, 0, NULL, 1, 0, N'Mark', N'bla', NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Caterer] ON 

INSERT [dbo].[Caterer] ([IdCaterer], [Name], [IDRegisteredCaterer]) VALUES (1010, N'asdf', N'0')
INSERT [dbo].[Caterer] ([IdCaterer], [Name], [IDRegisteredCaterer]) VALUES (1011, N'xfhfd', N'0')
SET IDENTITY_INSERT [dbo].[Caterer] OFF
GO
SET IDENTITY_INSERT [dbo].[CateringFacility] ON 

INSERT [dbo].[CateringFacility] ([IDCateringFacility], [Name], [CatererID], [AdressID]) VALUES (1011, N'sdf', 1010, 1010)
INSERT [dbo].[CateringFacility] ([IDCateringFacility], [Name], [CatererID], [AdressID]) VALUES (1012, N'sfgh', 1011, 1011)
SET IDENTITY_INSERT [dbo].[CateringFacility] OFF
GO
INSERT [dbo].[Customer] ([IDCustomer], [FullName], [Gender]) VALUES (N'8f669c8f-dfe5-4a82-8d58-10f4eb673b49', N'nikola', N'F')
INSERT [dbo].[Customer] ([IDCustomer], [FullName], [Gender]) VALUES (N'a6f8db23-99f2-4e48-958e-5ed20a4ab9e1', N'aDFASdf', N'M')
GO
INSERT [dbo].[CustomersHabit] ([EatingHabitID], [CustomerID]) VALUES (7, N'8f669c8f-dfe5-4a82-8d58-10f4eb673b49')
INSERT [dbo].[CustomersHabit] ([EatingHabitID], [CustomerID]) VALUES (7, N'a6f8db23-99f2-4e48-958e-5ed20a4ab9e1')
INSERT [dbo].[CustomersHabit] ([EatingHabitID], [CustomerID]) VALUES (13, N'a6f8db23-99f2-4e48-958e-5ed20a4ab9e1')
INSERT [dbo].[CustomersHabit] ([EatingHabitID], [CustomerID]) VALUES (14, N'a6f8db23-99f2-4e48-958e-5ed20a4ab9e1')
GO
SET IDENTITY_INSERT [dbo].[EatingHabit] ON 

INSERT [dbo].[EatingHabit] ([IDEatingHabit], [EatingHabit], [EatingHabitCategoryID]) VALUES (7, N'VEGAN', 4)
INSERT [dbo].[EatingHabit] ([IDEatingHabit], [EatingHabit], [EatingHabitCategoryID]) VALUES (9, N'Pizza', 1)
INSERT [dbo].[EatingHabit] ([IDEatingHabit], [EatingHabit], [EatingHabitCategoryID]) VALUES (12, N'Pizza', 2)
INSERT [dbo].[EatingHabit] ([IDEatingHabit], [EatingHabit], [EatingHabitCategoryID]) VALUES (13, N'SVE', 4)
INSERT [dbo].[EatingHabit] ([IDEatingHabit], [EatingHabit], [EatingHabitCategoryID]) VALUES (14, N'DIJABETES', 4)
SET IDENTITY_INSERT [dbo].[EatingHabit] OFF
GO
SET IDENTITY_INSERT [dbo].[EatingHabitCategory] ON 

INSERT [dbo].[EatingHabitCategory] ([IDEatingHabitCategory], [CategoryName]) VALUES (1, N'Favorite Food')
INSERT [dbo].[EatingHabitCategory] ([IDEatingHabitCategory], [CategoryName]) VALUES (2, N'Dislike')
INSERT [dbo].[EatingHabitCategory] ([IDEatingHabitCategory], [CategoryName]) VALUES (3, N'Allergy')
INSERT [dbo].[EatingHabitCategory] ([IDEatingHabitCategory], [CategoryName]) VALUES (4, N'Eating habit')
SET IDENTITY_INSERT [dbo].[EatingHabitCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[Ingredient] ON 

INSERT [dbo].[Ingredient] ([IdIngredient], [Name]) VALUES (1019, N'meso')
INSERT [dbo].[Ingredient] ([IdIngredient], [Name]) VALUES (1020, N'papar')
INSERT [dbo].[Ingredient] ([IdIngredient], [Name]) VALUES (1021, N'cesnjak')
INSERT [dbo].[Ingredient] ([IdIngredient], [Name]) VALUES (1022, N'jaja')
INSERT [dbo].[Ingredient] ([IdIngredient], [Name]) VALUES (1023, N'mlijeko')
INSERT [dbo].[Ingredient] ([IdIngredient], [Name]) VALUES (1024, N'povrće')
INSERT [dbo].[Ingredient] ([IdIngredient], [Name]) VALUES (1025, N'sol')
INSERT [dbo].[Ingredient] ([IdIngredient], [Name]) VALUES (1026, N'papar')
SET IDENTITY_INSERT [dbo].[Ingredient] OFF
GO
SET IDENTITY_INSERT [dbo].[Item] ON 

INSERT [dbo].[Item] ([IDItem], [Name]) VALUES (1016, N'Cevepi')
INSERT [dbo].[Item] ([IDItem], [Name]) VALUES (1017, N'omlet')
SET IDENTITY_INSERT [dbo].[Item] OFF
GO
SET IDENTITY_INSERT [dbo].[ItemIngredient] ON 

INSERT [dbo].[ItemIngredient] ([IDItemIngredient], [IngredientID], [ItemID], [MeasuringUnitID], [Amount]) VALUES (1019, 1019, 1016, 1, 20)
INSERT [dbo].[ItemIngredient] ([IDItemIngredient], [IngredientID], [ItemID], [MeasuringUnitID], [Amount]) VALUES (1020, 1020, 1016, 1, 20)
INSERT [dbo].[ItemIngredient] ([IDItemIngredient], [IngredientID], [ItemID], [MeasuringUnitID], [Amount]) VALUES (1021, 1021, 1016, 1, 20)
INSERT [dbo].[ItemIngredient] ([IDItemIngredient], [IngredientID], [ItemID], [MeasuringUnitID], [Amount]) VALUES (1022, 1022, 1017, 1, 20)
INSERT [dbo].[ItemIngredient] ([IDItemIngredient], [IngredientID], [ItemID], [MeasuringUnitID], [Amount]) VALUES (1023, 1023, 1017, 1, 20)
INSERT [dbo].[ItemIngredient] ([IDItemIngredient], [IngredientID], [ItemID], [MeasuringUnitID], [Amount]) VALUES (1024, 1024, 1017, 1, 20)
INSERT [dbo].[ItemIngredient] ([IDItemIngredient], [IngredientID], [ItemID], [MeasuringUnitID], [Amount]) VALUES (1025, 1025, 1017, 1, 20)
INSERT [dbo].[ItemIngredient] ([IDItemIngredient], [IngredientID], [ItemID], [MeasuringUnitID], [Amount]) VALUES (1026, 1026, 1017, 1, 20)
SET IDENTITY_INSERT [dbo].[ItemIngredient] OFF
GO
SET IDENTITY_INSERT [dbo].[MeasuringUnit] ON 

INSERT [dbo].[MeasuringUnit] ([IDMeasureUnit], [Name]) VALUES (1, N'kom')
SET IDENTITY_INSERT [dbo].[MeasuringUnit] OFF
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([IDMenu], [CatererFacilityID]) VALUES (12, 1012)
INSERT [dbo].[Menu] ([IDMenu], [CatererFacilityID]) VALUES (13, 1012)
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
SET IDENTITY_INSERT [dbo].[MenuItem] ON 

INSERT [dbo].[MenuItem] ([IDMenuItem], [ItemID], [MenuID], [Price]) VALUES (10, 1016, 12, 23)
INSERT [dbo].[MenuItem] ([IDMenuItem], [ItemID], [MenuID], [Price]) VALUES (11, 1017, 13, 32)
SET IDENTITY_INSERT [dbo].[MenuItem] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 17/07/2020 20:48:00 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 17/07/2020 20:48:00 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 17/07/2020 20:48:00 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 17/07/2020 20:48:00 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 17/07/2020 20:48:00 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 17/07/2020 20:48:00 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 17/07/2020 20:48:00 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (CONVERT([bit],(0))) FOR [SaladFilter]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CateringFacility]  WITH CHECK ADD  CONSTRAINT [FK_CateringFacility_Adress] FOREIGN KEY([AdressID])
REFERENCES [dbo].[Adress] ([IdAdress])
GO
ALTER TABLE [dbo].[CateringFacility] CHECK CONSTRAINT [FK_CateringFacility_Adress]
GO
ALTER TABLE [dbo].[CateringFacility]  WITH CHECK ADD  CONSTRAINT [FK_CateringFacility_Caterer] FOREIGN KEY([CatererID])
REFERENCES [dbo].[Caterer] ([IdCaterer])
GO
ALTER TABLE [dbo].[CateringFacility] CHECK CONSTRAINT [FK_CateringFacility_Caterer]
GO
ALTER TABLE [dbo].[CustomersHabit]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([IDCustomer])
GO
ALTER TABLE [dbo].[CustomersHabit]  WITH CHECK ADD FOREIGN KEY([EatingHabitID])
REFERENCES [dbo].[EatingHabit] ([IDEatingHabit])
GO
ALTER TABLE [dbo].[EatingHabit]  WITH CHECK ADD FOREIGN KEY([EatingHabitCategoryID])
REFERENCES [dbo].[EatingHabitCategory] ([IDEatingHabitCategory])
GO
ALTER TABLE [dbo].[ItemIngredient]  WITH CHECK ADD  CONSTRAINT [FK_ItemIngredient_Ingredient] FOREIGN KEY([IngredientID])
REFERENCES [dbo].[Ingredient] ([IdIngredient])
GO
ALTER TABLE [dbo].[ItemIngredient] CHECK CONSTRAINT [FK_ItemIngredient_Ingredient]
GO
ALTER TABLE [dbo].[ItemIngredient]  WITH CHECK ADD  CONSTRAINT [FK_ItemIngredient_Item] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Item] ([IDItem])
GO
ALTER TABLE [dbo].[ItemIngredient] CHECK CONSTRAINT [FK_ItemIngredient_Item]
GO
ALTER TABLE [dbo].[ItemIngredient]  WITH CHECK ADD  CONSTRAINT [FK_ItemIngredient_MeasuringUnit] FOREIGN KEY([MeasuringUnitID])
REFERENCES [dbo].[MeasuringUnit] ([IDMeasureUnit])
GO
ALTER TABLE [dbo].[ItemIngredient] CHECK CONSTRAINT [FK_ItemIngredient_MeasuringUnit]
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_CateringFacility] FOREIGN KEY([CatererFacilityID])
REFERENCES [dbo].[CateringFacility] ([IDCateringFacility])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_CateringFacility]
GO
ALTER TABLE [dbo].[MenuItem]  WITH CHECK ADD  CONSTRAINT [FK_MenuItem_Item] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Item] ([IDItem])
GO
ALTER TABLE [dbo].[MenuItem] CHECK CONSTRAINT [FK_MenuItem_Item]
GO
ALTER TABLE [dbo].[MenuItem]  WITH CHECK ADD  CONSTRAINT [FK_MenuItem_Menu] FOREIGN KEY([MenuID])
REFERENCES [dbo].[Menu] ([IDMenu])
GO
ALTER TABLE [dbo].[MenuItem] CHECK CONSTRAINT [FK_MenuItem_Menu]
GO
/****** Object:  StoredProcedure [dbo].[AddCaterer]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AddCaterer]
@catererName nvarchar(50),
@CatererId nvarchar(50),
@FacilityName nvarchar(50),
@Adress nvarchar(50),
@lat nvarchar(50),
@long nvarchar(50)
as

insert into Caterer ( [Name], [IDRegisteredCaterer])values (@catererName,@CatererId)

Declare @iDCaterer int=SCOPE_IDENTITY();

insert into Adress ( [Adress], [Lat], [Long]) values (@Adress,@lat,@long)

Declare @iDAdress int=SCOPE_IDENTITY();

insert into CateringFacility ( [Name], [CatererID], [AdressID])values (@FacilityName,@iDCaterer,@iDAdress)

select SCOPE_IDENTITY();

GO
/****** Object:  StoredProcedure [dbo].[AddCustomer]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---AddCustomer
CREATE proc [dbo].[AddCustomer]
		@ID int,
		@FullName nvarchar(50)
as

INSERT INTO Customer (FullName,IDCustomer) VALUES (@FullName,@ID)

GO
/****** Object:  StoredProcedure [dbo].[AddCustomer2]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddCustomer2]
AS
    DECLARE @Ids AS TABLE (Id int);
    DECLARE @Vals BasicCDT;
    INSERT INTO @Vals ([EatingHabit], [CategoryName]) VALUES ('vegan','Eating habit'), ('gluten','Dislike'), ('pizza','Eating habit');

    INSERT INTO @Ids
    EXEC AddHabbits @Vals;

    -- should return three rows with the values 1, 2 and 3.    
    SELECT *
    FROM @Ids;

GO
/****** Object:  StoredProcedure [dbo].[AddCustomertest]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AddCustomertest]
		@customerHabbits BasicCDT readonly,	
		@CustomerID nvarchar(50),
		@Customer nvarchar(50),
		@Gender varchar(10)

as


--declare @CTest nvarchar(50)
--declare @CGender varchar(10)
--declare @CcustomerHabbits as BasicCDT 

--set @CTest ='Nikola'

--set @CGender ='M'

--insert into @CcustomerHabbits values ('Pizza','Favorite Food'),('Burgers','Favorite Food')

INSERT INTO Customer ([IDCustomer],FullName,[Gender]) VALUES (@CustomerID,@Customer,@Gender)

--Declare @iD int=SCOPE_IDENTITY();

--INSERT INTO Customer ([IDCustomer],FullName,[Gender]) VALUES (14,@CTest,@CGender)


 exec sp_GetIDForHabits  @customerHabbits, @CustomerID
GO
/****** Object:  StoredProcedure [dbo].[AddHabbits]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddHabbits] 
@Values dbo.BasicCDT READONLY
AS

declare @UniqueEatingHabits as BasicCDT

insert into @UniqueEatingHabits
exec GetUnique @Values



    INSERT   INTO EatingHabit([EatingHabit], [EatingHabitCategoryID])
    --OUTPUT INSERTED.IDEatingHabit
   select a.EatingHabit, EatingHabitCategory.IDEatingHabitCategory from EatingHabitCategory 
	inner join @UniqueEatingHabits as a on EatingHabitCategory.CategoryName=a.CategoryName 
GO
/****** Object:  StoredProcedure [dbo].[addItems]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[addItems]  
@Title nvarchar(50),
 @Price int,
 @Ingredients ItemsType readonly,
 @IDCateringFacility int
as

-- DECLARE @NewIdsItems TABLE(Name nvarchar(50))


--insert into @NewIdsItems values('Coca cola')
--insert into @NewIdsItems values('Pizza')
--insert into @NewIdsItems values('Salata')

insert into Item ([Name]) values (@Title)

Declare @iDItem int=SCOPE_IDENTITY();

exec  AddMenu @iDItem,@IDCateringFacility,@Price


DECLARE @NewIds TABLE(ID INT)
   insert into Ingredient OUTPUT Inserted.IdIngredient  INTO @NewIds select * from @Ingredients;
   
   	With CTE_CustomerHabit	(IdHabit,iDItem,unit,amount)
as
(
select ID,@iDItem,1,20 from @NewIds

)

   insert into ItemIngredient ([IngredientID], [ItemID], [MeasuringUnitID], [Amount]) (select * from CTE_CustomerHabit )

 

GO
/****** Object:  StoredProcedure [dbo].[AddMenu]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AddMenu]
@IDItem int,
@IDCatererFacility int,
@Price int

as


--delete from CateringFacility

insert into Menu ( [CatererFacilityID])values(@IDCatererFacility)

declare @ID int = SCOPE_IDENTITY();

insert into MenuItem values (@IDItem,@ID,@Price)



GO
/****** Object:  StoredProcedure [dbo].[GetUnique]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetUnique]
@Values dbo.BasicCDT READONLY
as


SELECT EatingHabit ,CategoryName
FROM   @Values l 
WHERE  NOT EXISTS (
   SELECT  *
   FROM   EatingHabit
   WHERE  EatingHabit = l.EatingHabit
   );
GO
/****** Object:  StoredProcedure [dbo].[sp_GetIDForHabits]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_GetIDForHabits]
	@Vals dbo.BasicCDT READONLY,
	@IDCustomer nvarchar(50)
AS
BEGIN

DECLARE @HabitsIds AS TABLE (IdHabit int);

--INSERT INTO @HabitsIds
 EXEC AddHabbits @Vals;

 insert into @HabitsIds
 select IDEatingHabit from EatingHabit
 inner join @Vals as s on s.EatingHabit=EatingHabit.EatingHabit;

 --select * from @HabitsIds


---//CTE//
	
	With CTE_CustomerHabit	(IdHabit,idCustomer)
as
(
select IdHabit,@IDCustomer from @HabitsIds

)


insert into CustomersHabit select * from CTE_CustomerHabit


--    DECLARE @HabitsIds AS TABLE (IdHabit int);
--	Declare @CustomersHabitVals AS TABLE (IdHabbit int,IdCustomer int);
--	declare @idCustomer  AS TABLE (IdCustomer int);
	

--	insert into @HabitsIds values(1),(2)

--	  --INSERT INTO @HabitsIds
--   -- EXEC AddHabbits @Vals;

--	DECLARE @cnt INT = 0;
--	DECLARE @times int

--	SELECT @times = COUNT(*)
--FROM @HabitsIds

--WHILE @cnt < @times
--BEGIN
--   insert into @idCustomer values(1)

--   SET @cnt = @cnt + 1;
--END;



----select A.IdCustomer,B.IdHabit 
----from(
----    SELECT IdCustomer,row_number() over (order by IdCustomer) as row_num
----    FROM @idCustomer)A
----join
----    (SELECT IdHabit,row_number() over (order by IdHabit) as row_num
----    FROM @HabitsIds)B
----on  A.row_num=B.row_num





----select * from @idCustomer

-- insert into @CustomersHabitVals select B.IdHabit,A.IdCustomer 
--from(
--    SELECT IdCustomer,row_number() over (order by IdCustomer) as row_num
--    FROM @idCustomer)A
--join
--    (SELECT IdHabit,row_number() over (order by IdHabit) as row_num
--    FROM @HabitsIds)B
--on  A.row_num=B.row_num

-- --select * from @CustomersHabitVals

-- insert into CustomersHabit select * from @CustomersHabitVals


--    -- should return three rows with the values 1, 2 and 3.    
  
  END

GO
/****** Object:  StoredProcedure [dbo].[stp_TestOutputClauseInsert]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_TestOutputClauseInsert]
(@Values dbo.BasicCDT READONLY)
AS
  INSERT INTO EatingHabit([EatingHabit], [EatingHabitCategoryID])
    OUTPUT INSERTED.IDEatingHabit
    SELECT EatingHabit,(select IDEatingHabitCategory from EatingHabitCategory where CategoryName=CategoryName)
    FROM @Values;

GO
/****** Object:  StoredProcedure [dbo].[temp]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[temp]

as
Declare @table as TAble (name nvarchar(50))

insert into @table values('nista'),('nista2');


SELECT EatingHabit.IDEatingHabit
FROM EatingHabit
INNER JOIN @table as t ON EatingHabit.EatingHabit=t.name;

select * from EatingHabit where EatingHabit.EatingHabit =(select * from @table)
GO
/****** Object:  StoredProcedure [dbo].[TestOne]    Script Date: 17/07/2020 20:48:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[TestOne] 

@HabbitList dbo.EatingHabbit READONLY
AS
BEGIN
insert into EatingHabits([EatingHabit])select
[EatingHabit] from @HabbitList;

END
GO
USE [master]
GO
ALTER DATABASE [OICAR] SET  READ_WRITE 
GO
