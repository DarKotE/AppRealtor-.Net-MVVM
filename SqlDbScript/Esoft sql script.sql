USE [Esoft]
GO
/****** Object:  Table [dbo].[Apartments]    Script Date: 21/06/20 16:10:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apartments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_LCD] [int] NOT NULL,
	[Number_Apartament] [int] NOT NULL,
	[Area] [float] NOT NULL,
	[Number_Of_Rooms] [int] NOT NULL,
	[Porch] [int] NOT NULL,
	[Floor] [int] NOT NULL,
	[Status_Sale] [varchar](50) NOT NULL,
	[Added_value] [bigint] NOT NULL,
	[Expenses_Building_An_Apartment] [bigint] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Apartments_in_houses2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Complex]    Script Date: 21/06/20 16:10:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Complex](
	[IdComplex] [int] IDENTITY(1,1) NOT NULL,
	[Name_Housing_Complex] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Status_Construction_Housing_Complex] [nvarchar](50) NOT NULL,
	[Added_Value] [bigint] NOT NULL,
	[Building_Costs] [bigint] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Complex] PRIMARY KEY CLUSTERED 
(
	[IdComplex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[House]    Script Date: 21/06/20 16:10:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[House](
	[IdHouse] [int] IDENTITY(1,1) NOT NULL,
	[Street] [nvarchar](50) NOT NULL,
	[Number_House] [nvarchar](50) NOT NULL,
	[Cost_House_Construction] [bigint] NOT NULL,
	[Additional_Cost_Apartament_House] [bigint] NOT NULL,
	[IdComplex] [int] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_House] PRIMARY KEY CLUSTERED 
(
	[IdHouse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Apartments] ON 
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (1, 1, 1, 67.6, 2, 1, 1, N'sold', 300000, 11882000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (2, 1, 2, 79.2, 3, 1, 1, N'sold', 375000, 13925000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (3, 1, 320, 79.2, 3, 2, 15, N'sold', 375000, 13925000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (4, 1, 321, 35.4, 1, 2, 15, N'sold', 200000, 7852000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (5, 1, 322, 35.4, 1, 2, 15, N'sold', 200000, 7852000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (6, 1, 467, 79.2, 3, 2, 39, N'ready', 375000, 13925000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (7, 1, 468, 67.6, 2, 2, 39, N'sold', 300000, 11882000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (8, 3, 1, 67.6, 2, 1, 1, N'sold', 300000, 10697000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (9, 3, 2, 79.2, 3, 1, 1, N'ready', 375000, 12558000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (10, 3, 78, 67.6, 2, 1, 13, N'sold', 300000, 10697000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (11, 3, 79, 67.6, 2, 1, 14, N'sold', 300000, 10697000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (12, 3, 80, 79.2, 3, 1, 14, N'sold', 375000, 12558000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (13, 3, 81, 35.4, 1, 1, 14, N'ready', 200000, 6900000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (14, 3, 228, 67.6, 2, 1, 38, N'sold', 300000, 10697000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (15, 3, 229, 67.6, 2, 1, 39, N'sold', 300000, 10697000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (16, 3, 230, 79.2, 3, 1, 39, N'sold', 375000, 12558000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (17, 3, 486, 67.6, 2, 3, 3, N'sold', 300000, 10697000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (18, 3, 487, 67.6, 2, 3, 4, N'ready', 300000, 10697000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (19, 3, 488, 79.2, 3, 3, 4, N'ready', 375000, 12558000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (20, 6, 21, 35.4, 1, 1, 4, N'sold', 300000, 7200000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (21, 6, 22, 35.4, 1, 1, 4, N'sold', 300000, 7200000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (22, 6, 23, 79.7, 3, 1, 4, N'ready', 475000, 12560000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (23, 6, 210, 68.7, 2, 2, 8, N'ready', 400000, 10854000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (24, 6, 211, 68.7, 2, 2, 9, N'sold', 400000, 10854000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (25, 5, 28, 35.4, 1, 1, 5, N'ready', 350000, 8955000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (26, 5, 29, 79.7, 3, 1, 5, N'sold', 525000, 14432000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (27, 5, 30, 68.7, 2, 1, 5, N'ready', 450000, 16885000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (28, 5, 31, 68.7, 2, 1, 6, N'ready', 450000, 16885000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (29, 5, 324, 68.7, 2, 2, 27, N'ready', 450000, 16885000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (30, 8, 1, 68.9, 2, 1, 1, N'sold', 375000, 10975000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (31, 8, 2, 79.2, 3, 1, 1, N'sold', 420000, 12787000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (32, 8, 323, 79.2, 3, 2, 27, N'sold', 420000, 14432000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (33, 8, 324, 68.9, 2, 2, 27, N'ready', 375000, 16885000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (34, 9, 1, 68.9, 2, 1, 1, N'ready', 420000, 14552000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (35, 9, 2, 59.1, 3, 1, 1, N'ready', 440000, 11198000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (36, 9, 189, 39.5, 1, 2, 8, N'sold', 305000, 8196000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (37, 9, 190, 39.5, 1, 2, 8, N'sold', 305000, 8196000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (38, 10, 37, 65.5, 2, 2, 1, N'ready', 650000, 7731000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (39, 10, 38, 40.6, 1, 2, 1, N'ready', 390000, 5850000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (40, 10, 39, 40.6, 1, 2, 1, N'ready', 390000, 5850000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (41, 11, 91, 40.9, 1, 3, 5, N'ready', 350000, 5955000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (42, 11, 92, 62.7, 2, 3, 5, N'sold', 450000, 7453000, 0)
GO
INSERT [dbo].[Apartments] ([Id], [Id_LCD], [Number_Apartament], [Area], [Number_Of_Rooms], [Porch], [Floor], [Status_Sale], [Added_value], [Expenses_Building_An_Apartment], [IsDeleted]) VALUES (43, 11, 93, 63.3, 2, 3, 6, N'ready', 450000, 7453000, 0)
GO
SET IDENTITY_INSERT [dbo].[Apartments] OFF
GO
SET IDENTITY_INSERT [dbo].[Complex] ON 
GO
INSERT [dbo].[Complex] ([IdComplex], [Name_Housing_Complex], [City], [Status_Construction_Housing_Complex], [Added_Value], [Building_Costs], [IsDeleted]) VALUES (1, N'Level Амурская', N'Москва', N'2', 500000, 60000, 0)
GO
INSERT [dbo].[Complex] ([IdComplex], [Name_Housing_Complex], [City], [Status_Construction_Housing_Complex], [Added_Value], [Building_Costs], [IsDeleted]) VALUES (2, N'Испанские кварталы', N'Москва', N'1', 7000000, 950000, 0)
GO
SET IDENTITY_INSERT [dbo].[Complex] OFF
GO
SET IDENTITY_INSERT [dbo].[House] ON 
GO
INSERT [dbo].[House] ([IdHouse], [Street], [Number_House], [Cost_House_Construction], [Additional_Cost_Apartament_House], [IdComplex], [IsDeleted]) VALUES (1, N'Амурская', N'Г8', 400000, 500000, 1, 0)
GO
INSERT [dbo].[House] ([IdHouse], [Street], [Number_House], [Cost_House_Construction], [Additional_Cost_Apartament_House], [IdComplex], [IsDeleted]) VALUES (3, N'Амурская', N'Г7', 500000, 550000, 1, 0)
GO
INSERT [dbo].[House] ([IdHouse], [Street], [Number_House], [Cost_House_Construction], [Additional_Cost_Apartament_House], [IdComplex], [IsDeleted]) VALUES (5, N'Амурская', N'А2', 700000, 850000, 1, 0)
GO
INSERT [dbo].[House] ([IdHouse], [Street], [Number_House], [Cost_House_Construction], [Additional_Cost_Apartament_House], [IdComplex], [IsDeleted]) VALUES (6, N'Амурская', N'А1', 700000, 850000, 1, 0)
GO
INSERT [dbo].[House] ([IdHouse], [Street], [Number_House], [Cost_House_Construction], [Additional_Cost_Apartament_House], [IdComplex], [IsDeleted]) VALUES (8, N'Амурская', N'Б3', 450000, 550000, 1, 0)
GO
INSERT [dbo].[House] ([IdHouse], [Street], [Number_House], [Cost_House_Construction], [Additional_Cost_Apartament_House], [IdComplex], [IsDeleted]) VALUES (9, N'Амурская', N'Б4', 450000, 550000, 1, 0)
GO
INSERT [dbo].[House] ([IdHouse], [Street], [Number_House], [Cost_House_Construction], [Additional_Cost_Apartament_House], [IdComplex], [IsDeleted]) VALUES (10, N'Калужское шоссе', N'1.1', 650000, 700000, 2, 0)
GO
INSERT [dbo].[House] ([IdHouse], [Street], [Number_House], [Cost_House_Construction], [Additional_Cost_Apartament_House], [IdComplex], [IsDeleted]) VALUES (11, N'Калужское шоссе', N'1.2', 450000, 500000, 2, 0)
GO
SET IDENTITY_INSERT [dbo].[House] OFF
GO
ALTER TABLE [dbo].[Apartments]  WITH CHECK ADD  CONSTRAINT [FK_Apartments_Apartments] FOREIGN KEY([Id])
REFERENCES [dbo].[Apartments] ([Id])
GO
ALTER TABLE [dbo].[Apartments] CHECK CONSTRAINT [FK_Apartments_Apartments]
GO
ALTER TABLE [dbo].[Apartments]  WITH CHECK ADD  CONSTRAINT [FK_Apartments_Apartments1] FOREIGN KEY([Id])
REFERENCES [dbo].[Apartments] ([Id])
GO
ALTER TABLE [dbo].[Apartments] CHECK CONSTRAINT [FK_Apartments_Apartments1]
GO
ALTER TABLE [dbo].[Apartments]  WITH CHECK ADD  CONSTRAINT [FK_Apartments_House] FOREIGN KEY([Id_LCD])
REFERENCES [dbo].[House] ([IdHouse])
GO
ALTER TABLE [dbo].[Apartments] CHECK CONSTRAINT [FK_Apartments_House]
GO
ALTER TABLE [dbo].[House]  WITH CHECK ADD  CONSTRAINT [FK_House_Complex] FOREIGN KEY([IdComplex])
REFERENCES [dbo].[Complex] ([IdComplex])
GO
ALTER TABLE [dbo].[House] CHECK CONSTRAINT [FK_House_Complex]
GO
ALTER TABLE [dbo].[House]  WITH CHECK ADD  CONSTRAINT [FK_House_House] FOREIGN KEY([IdHouse])
REFERENCES [dbo].[House] ([IdHouse])
GO
ALTER TABLE [dbo].[House] CHECK CONSTRAINT [FK_House_House]
GO
ALTER TABLE [dbo].[House]  WITH CHECK ADD  CONSTRAINT [FK_House_House1] FOREIGN KEY([IdHouse])
REFERENCES [dbo].[House] ([IdHouse])
GO
ALTER TABLE [dbo].[House] CHECK CONSTRAINT [FK_House_House1]
GO
ALTER TABLE [dbo].[House]  WITH CHECK ADD  CONSTRAINT [FK_House_House2] FOREIGN KEY([IdHouse])
REFERENCES [dbo].[House] ([IdHouse])
GO
ALTER TABLE [dbo].[House] CHECK CONSTRAINT [FK_House_House2]
GO
