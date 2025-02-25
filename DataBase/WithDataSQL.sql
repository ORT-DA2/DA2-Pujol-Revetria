USE [master]
GO
/****** Object:  Database [BookedUYDB]    Script Date: 11/26/2020 6:38:31 PM ******/
CREATE DATABASE [BookedUYDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookedUYDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BookedUYDB.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BookedUYDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BookedUYDB_log.ldf' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BookedUYDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookedUYDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookedUYDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookedUYDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookedUYDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookedUYDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookedUYDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookedUYDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BookedUYDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookedUYDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookedUYDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookedUYDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookedUYDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookedUYDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookedUYDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookedUYDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookedUYDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BookedUYDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookedUYDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookedUYDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookedUYDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookedUYDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookedUYDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BookedUYDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookedUYDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BookedUYDB] SET  MULTI_USER 
GO
ALTER DATABASE [BookedUYDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookedUYDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookedUYDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookedUYDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BookedUYDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BookedUYDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/26/2020 6:38:31 PM ******/
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
/****** Object:  Table [dbo].[AccommodationImages]    Script Date: 11/26/2020 6:38:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccommodationImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[AccommodationId] [int] NOT NULL,
 CONSTRAINT [PK_AccommodationImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accommodations]    Script Date: 11/26/2020 6:38:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accommodations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SpotId] [int] NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[ContactNumber] [nvarchar](max) NULL,
	[Information] [nvarchar](max) NULL,
	[PricePerNight] [float] NOT NULL,
	[Full] [bit] NOT NULL,
 CONSTRAINT [PK_Accommodations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Accommodations_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Administrators]    Script Date: 11/26/2020 6:38:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrators](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](450) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Administrators] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Administrators_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 11/26/2020 6:38:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccommodationId] [int] NOT NULL,
	[CheckIn] [datetime2](7) NOT NULL,
	[CheckOut] [datetime2](7) NOT NULL,
	[TotalPrice] [float] NOT NULL,
	[GuestId] [int] NOT NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookingStages]    Script Date: 11/26/2020 6:38:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingStages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdministratorId] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[EntryDate] [datetime2](7) NOT NULL,
	[AsociatedBookingId] [int] NOT NULL,
 CONSTRAINT [PK_BookingStages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11/26/2020 6:38:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Categories_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categoryTouristicSpots]    Script Date: 11/26/2020 6:38:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoryTouristicSpots](
	[CategoryId] [int] NOT NULL,
	[TouristicSpotId] [int] NOT NULL,
 CONSTRAINT [PK_categoryTouristicSpots] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC,
	[TouristicSpotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guest]    Script Date: 11/26/2020 6:38:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [int] NOT NULL,
	[Multiplier] [float] NOT NULL,
	[BookingId] [int] NOT NULL,
 CONSTRAINT [PK_Guest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regions]    Script Date: 11/26/2020 6:38:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 11/26/2020 6:38:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookingId] [int] NOT NULL,
	[Score] [int] NOT NULL,
	[Comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TouristicSpots]    Script Date: 11/26/2020 6:38:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TouristicSpots](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[RegionId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TouristicSpots] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TouristicSpots_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tourists]    Script Date: 11/26/2020 6:38:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tourists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Tourists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Tourists_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_AccommodationImages_AccommodationId]    Script Date: 11/26/2020 6:38:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_AccommodationImages_AccommodationId] ON [dbo].[AccommodationImages]
(
	[AccommodationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Accommodations_SpotId]    Script Date: 11/26/2020 6:38:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Accommodations_SpotId] ON [dbo].[Accommodations]
(
	[SpotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Bookings_AccommodationId]    Script Date: 11/26/2020 6:38:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Bookings_AccommodationId] ON [dbo].[Bookings]
(
	[AccommodationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Bookings_GuestId]    Script Date: 11/26/2020 6:38:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Bookings_GuestId] ON [dbo].[Bookings]
(
	[GuestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BookingStages_AdministratorId]    Script Date: 11/26/2020 6:38:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_BookingStages_AdministratorId] ON [dbo].[BookingStages]
(
	[AdministratorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BookingStages_AsociatedBookingId]    Script Date: 11/26/2020 6:38:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_BookingStages_AsociatedBookingId] ON [dbo].[BookingStages]
(
	[AsociatedBookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_categoryTouristicSpots_TouristicSpotId]    Script Date: 11/26/2020 6:38:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_categoryTouristicSpots_TouristicSpotId] ON [dbo].[categoryTouristicSpots]
(
	[TouristicSpotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Guest_BookingId]    Script Date: 11/26/2020 6:38:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Guest_BookingId] ON [dbo].[Guest]
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reviews_BookingId]    Script Date: 11/26/2020 6:38:31 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Reviews_BookingId] ON [dbo].[Reviews]
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TouristicSpots_RegionId]    Script Date: 11/26/2020 6:38:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_TouristicSpots_RegionId] ON [dbo].[TouristicSpots]
(
	[RegionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BookingStages] ADD  DEFAULT (getdate()) FOR [EntryDate]
GO
ALTER TABLE [dbo].[AccommodationImages]  WITH CHECK ADD  CONSTRAINT [FK_AccommodationImages_Accommodations_AccommodationId] FOREIGN KEY([AccommodationId])
REFERENCES [dbo].[Accommodations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AccommodationImages] CHECK CONSTRAINT [FK_AccommodationImages_Accommodations_AccommodationId]
GO
ALTER TABLE [dbo].[Accommodations]  WITH CHECK ADD  CONSTRAINT [FK_Accommodations_TouristicSpots_SpotId] FOREIGN KEY([SpotId])
REFERENCES [dbo].[TouristicSpots] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Accommodations] CHECK CONSTRAINT [FK_Accommodations_TouristicSpots_SpotId]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Accommodations_AccommodationId] FOREIGN KEY([AccommodationId])
REFERENCES [dbo].[Accommodations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Accommodations_AccommodationId]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Tourists_GuestId] FOREIGN KEY([GuestId])
REFERENCES [dbo].[Tourists] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Tourists_GuestId]
GO
ALTER TABLE [dbo].[BookingStages]  WITH CHECK ADD  CONSTRAINT [FK_BookingStages_Administrators_AdministratorId] FOREIGN KEY([AdministratorId])
REFERENCES [dbo].[Administrators] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookingStages] CHECK CONSTRAINT [FK_BookingStages_Administrators_AdministratorId]
GO
ALTER TABLE [dbo].[BookingStages]  WITH CHECK ADD  CONSTRAINT [FK_BookingStages_Bookings_AsociatedBookingId] FOREIGN KEY([AsociatedBookingId])
REFERENCES [dbo].[Bookings] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookingStages] CHECK CONSTRAINT [FK_BookingStages_Bookings_AsociatedBookingId]
GO
ALTER TABLE [dbo].[categoryTouristicSpots]  WITH CHECK ADD  CONSTRAINT [FK_categoryTouristicSpots_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[categoryTouristicSpots] CHECK CONSTRAINT [FK_categoryTouristicSpots_Categories_CategoryId]
GO
ALTER TABLE [dbo].[categoryTouristicSpots]  WITH CHECK ADD  CONSTRAINT [FK_categoryTouristicSpots_TouristicSpots_TouristicSpotId] FOREIGN KEY([TouristicSpotId])
REFERENCES [dbo].[TouristicSpots] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[categoryTouristicSpots] CHECK CONSTRAINT [FK_categoryTouristicSpots_TouristicSpots_TouristicSpotId]
GO
ALTER TABLE [dbo].[Guest]  WITH CHECK ADD  CONSTRAINT [FK_Guest_Bookings_BookingId] FOREIGN KEY([BookingId])
REFERENCES [dbo].[Bookings] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Guest] CHECK CONSTRAINT [FK_Guest_Bookings_BookingId]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Bookings_BookingId] FOREIGN KEY([BookingId])
REFERENCES [dbo].[Bookings] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Bookings_BookingId]
GO
ALTER TABLE [dbo].[TouristicSpots]  WITH CHECK ADD  CONSTRAINT [FK_TouristicSpots_Regions_RegionId] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Regions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TouristicSpots] CHECK CONSTRAINT [FK_TouristicSpots_Regions_RegionId]
GO
USE [master]
GO
ALTER DATABASE [BookedUYDB] SET  READ_WRITE 
GO
