USE [BookedUYDB]
GO
SET IDENTITY_INSERT [dbo].[Administrators] ON 

INSERT [dbo].[Administrators] ([Id], [Email], [Password]) VALUES (1, N'admin', N'123')
SET IDENTITY_INSERT [dbo].[Administrators] OFF
GO
SET IDENTITY_INSERT [dbo].[Tourists] ON 

INSERT [dbo].[Tourists] ([Id], [Name], [LastName], [Email]) VALUES (1, N'test', N'lastTest', N'test@test.com')
SET IDENTITY_INSERT [dbo].[Tourists] OFF
GO
SET IDENTITY_INSERT [dbo].[Regions] ON 

INSERT [dbo].[Regions] ([Id], [Name]) VALUES (1, N'Region Metropolitana')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (2, N'Region Centro Sur')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (3, N'Region Este')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (4, N'Region Norte')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (5, N'Region Pajaros Pintados')
SET IDENTITY_INSERT [dbo].[Regions] OFF
GO
SET IDENTITY_INSERT [dbo].[TouristicSpots] ON 

INSERT [dbo].[TouristicSpots] ([Id], [Name], [RegionId], [Description], [Image]) VALUES (1, N'La Paloma', 3, N'Pueblo de hermosas playas', N'FOTO')
SET IDENTITY_INSERT [dbo].[TouristicSpots] OFF
GO
SET IDENTITY_INSERT [dbo].[Accommodations] ON 

INSERT [dbo].[Accommodations] ([Id], [SpotId], [Name], [Address], [ContactNumber], [Information], [PricePerNight], [Full]) VALUES (1, 1, N'Hilton', N'Mar Sereno 1045', N'+598', N'Un Hotel muy lindo', 48.2, 0)
SET IDENTITY_INSERT [dbo].[Accommodations] OFF
GO
SET IDENTITY_INSERT [dbo].[Bookings] ON 

INSERT [dbo].[Bookings] ([Id], [AccommodationId], [CheckIn], [CheckOut], [TotalPrice], [GuestId]) VALUES (1, 1, CAST(N'2020-12-12T00:00:00.0000000' AS DateTime2), CAST(N'2020-12-24T00:00:00.0000000' AS DateTime2), 6, 1)
SET IDENTITY_INSERT [dbo].[Bookings] OFF
GO
SET IDENTITY_INSERT [dbo].[BookingStages] ON 

INSERT [dbo].[BookingStages] ([Id], [AdministratorId], [Status], [Description], [EntryDate], [AsociatedBookingId]) VALUES (1, 1, 2, N'Se Pago', CAST(N'2020-10-15T15:06:40.1270000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[BookingStages] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Campo')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Historico')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Playa')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
INSERT [dbo].[categoryTouristicSpots] ([CategoryId], [TouristicSpotId]) VALUES (1, 1)
INSERT [dbo].[categoryTouristicSpots] ([CategoryId], [TouristicSpotId]) VALUES (2, 1)
GO
SET IDENTITY_INSERT [dbo].[AccommodationImages] ON 

INSERT [dbo].[AccommodationImages] ([Id], [Image], [AccommodationId]) VALUES (1, N'fotoafuera', 1)
INSERT [dbo].[AccommodationImages] ([Id], [Image], [AccommodationId]) VALUES (2, N'fotohabitacion', 1)
INSERT [dbo].[AccommodationImages] ([Id], [Image], [AccommodationId]) VALUES (3, N'fotojardin', 1)
SET IDENTITY_INSERT [dbo].[AccommodationImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Guest] ON 

INSERT [dbo].[Guest] ([Id], [Amount], [Multiplier], [BookingId]) VALUES (1, 2, 1, 1)
INSERT [dbo].[Guest] ([Id], [Amount], [Multiplier], [BookingId]) VALUES (2, 1, 0.8, 1)
INSERT [dbo].[Guest] ([Id], [Amount], [Multiplier], [BookingId]) VALUES (3, 4, 0.8, 1)
SET IDENTITY_INSERT [dbo].[Guest] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200926211654_FirstMigration', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201010193757_SecondMigration', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201012173906_ThirdMigration', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201012175033_FourthMigration', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201012224214_EightMigrations', N'3.1.8')
GO
