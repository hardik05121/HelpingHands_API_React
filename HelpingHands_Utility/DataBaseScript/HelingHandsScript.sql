USE [HelpingHands]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/12/2023 11:43:24 AM ******/
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
/****** Object:  Table [dbo].[Amenities]    Script Date: 12/12/2023 11:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amenities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AmenityName] [nvarchar](max) NOT NULL,
	[FirstCategoryId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Amenities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 12/12/2023 11:43:24 AM ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/12/2023 11:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/12/2023 11:43:24 AM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/12/2023 11:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/12/2023 11:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/12/2023 11:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[PassWord] [nvarchar](max) NULL,
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
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 12/12/2023 11:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 12/12/2023 11:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](max) NOT NULL,
	[CountryId] [int] NOT NULL,
	[StateId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 12/12/2023 11:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](max) NOT NULL,
	[FirstCategoryId] [int] NOT NULL,
	[SecondCategoryId] [int] NULL,
	[ThirdCategoryId] [int] NULL,
	[CompanyLogo] [nvarchar](max) NULL,
	[CityId] [int] NOT NULL,
	[StateId] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Certificate] [nvarchar](max) NULL,
	[IsDelete] [bit] NULL,
	[IsActive] [bit] NOT NULL,
	[WhatsApp] [nvarchar](max) NULL,
	[InstagramId] [nvarchar](max) NULL,
	[Facebook] [nvarchar](max) NULL,
	[Website] [nvarchar](max) NULL,
	[Twitter] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[EstablishDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyImages]    Script Date: 12/12/2023 11:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_CompanyImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyXAmenities]    Script Date: 12/12/2023 11:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyXAmenities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AmenityId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_CompanyXAmenities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyXPayments]    Script Date: 12/12/2023 11:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyXPayments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[PaymentId] [int] NOT NULL,
 CONSTRAINT [PK_CompanyXPayments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyXServices]    Script Date: 12/12/2023 11:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyXServices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
 CONSTRAINT [PK_CompanyXServices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 12/12/2023 11:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enquiries]    Script Date: 12/12/2023 11:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enquiries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PhoneNumber] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Enquiries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FirstCategories]    Script Date: 12/12/2023 11:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FirstCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstCategoryName] [nvarchar](max) NOT NULL,
	[FirstCategoryImage] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_FirstCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 12/12/2023 11:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentName] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 12/12/2023 11:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ApplicationUserId] [nvarchar](450) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[LikeCount] [int] NULL,
	[DisLikeCount] [int] NULL,
	[ViewCount] [int] NULL,
	[Rating] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReviewXComments]    Script Date: 12/12/2023 11:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReviewXComments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ReviewId] [int] NOT NULL,
	[ApplicationUserId] [nvarchar](450) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ReviewXComments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SecondCategories]    Script Date: 12/12/2023 11:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecondCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SecondCategoryName] [nvarchar](max) NOT NULL,
	[SecondCategoryImage] [nvarchar](max) NULL,
	[FirstCategoryId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_SecondCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 12/12/2023 11:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [nvarchar](max) NOT NULL,
	[FirstCategoryId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[States]    Script Date: 12/12/2023 11:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [nvarchar](max) NOT NULL,
	[CountryId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThirdCategories]    Script Date: 12/12/2023 11:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThirdCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ThirdCategoryName] [nvarchar](max) NOT NULL,
	[ThirdCategoryImage] [nvarchar](max) NULL,
	[FirstCategoryId] [int] NOT NULL,
	[SecondCategoryId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_ThirdCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230915142044_Addinitial', N'7.0.9')
GO
SET IDENTITY_INSERT [dbo].[Amenities] ON 

INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (1, N'On-Site Retail Spaces', 1, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (2, N'Swimming Pool', 1, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (3, N'Sun Deck', 5, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (4, N'Controlled Access Parking', 3, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (5, N' Bike Parking', 1, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (6, N'Community Lounge with Coffee Station', 9, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (7, N'24 Hour State-of-the-Art Fitness Center – Technogym Equipped', 5, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (8, N'Security Access', 3, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (9, N'Pet-Friendly', 3, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (10, N' Business Center', 6, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (11, N'Private Meeting Rooms', 3, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (12, N'Keyless Electronic Unit Entry', 4, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (13, N'Private Bedrooms and Bathrooms', 1, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (14, N'Stainless Steel Appliances', 6, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (15, N' TV Included', 1, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (16, N'Wi-Fi Included', 3, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (17, N'Private Balconies and Patios', 9, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (18, N' Dining Room', 9, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (19, N'Conference Rooms', 3, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (20, N' Online Payments', 1, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (21, N'High Ceilings', 5, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (22, N' Spacious Walk-In Closets', 8, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (23, N' Movie Theater', 3, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (24, N'Sun Tanning Salon', 7, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (25, N' Indoor Basketball', 9, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (26, N'Personal Tanning', 5, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (27, N' Hair and Nail Salons', 7, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (28, N' Library', 3, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (29, N' Cooking Classes', 1, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (30, N'Lake', 9, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (31, N'Sound-Proof Music JamRoom with Piano', 3, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (32, N'Food Shopping', 1, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (34, N'Washer and dryer', 2, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (35, N'Air conditioning', 4, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (36, N'Community kitchen', 2, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (37, N'Gym or fitness center', 5, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (38, N'Jogging or walking paths', 5, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (39, N' Newspaper', 1, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (40, N' CCTV Cameras', 4, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (41, N' 24 hour Concierge/Help Desk', 4, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (42, N'Wheel Chair Accessible In Car Parking', 4, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (43, N' Wheel Chair Accessible Entrance And Exit', 4, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (44, N' Common Bathroom', 4, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (45, N' Lgbt Friendly', 4, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (46, N' Fixed Prosthodontics', 8, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (47, N' Endo Surgery Or Apicoectomy', 8, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (48, N' Oral And Maxillofacial Surgery', 8, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (49, N' BPS Dentures Fixing', 8, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (50, N' Maxillofacial Prosthetics', 8, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (51, N' Online Appointments', 10, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (52, N'CCTV Cameras', 4, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (53, N'Business Center', 6, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (54, N'Online Payments', 1, 1)
INSERT [dbo].[Amenities] ([Id], [AmenityName], [FirstCategoryId], [IsActive]) VALUES (56, N'Bike Parking', 1, 1)
SET IDENTITY_INSERT [dbo].[Amenities] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Discriminator], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1836fb31-4b64-4422-9de6-e867cbea53a8', N'ApplicationRole', N'SuperAdmin', N'SUPERADMIN', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Discriminator], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'4099aa4c-1193-4fd3-9946-a12a268a3e7c', N'ApplicationRole', N'Customer', N'CUSTOMER', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Discriminator], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'78f22741-c4f6-4bfe-9a70-849774804734', N'ApplicationRole', N'Employee', N'EMPLOYEE', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Discriminator], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'd3addf18-ebab-4be0-9f25-96080bfca576', N'ApplicationRole', N'Admin', N'ADMIN', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [Discriminator]) VALUES (N'c8a8f664-12d0-41ee-87ba-eba6508e079b', N'1836fb31-4b64-4422-9de6-e867cbea53a8', N'ApplicationUserRole')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [Discriminator]) VALUES (N'c8a8f664-12d0-41ee-87ba-eba6508e079b', N'4099aa4c-1193-4fd3-9946-a12a268a3e7c', N'ApplicationUserRole')
GO
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Address], [PassWord], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c8a8f664-12d0-41ee-87ba-eba6508e079b', N'test', N'test', N'test try ', N'Test@123', N'test123@gmail.com', N'TEST123@GMAIL.COM', N'test123@gmail.com', N'TEST123@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEDV0Mms25GKudYxe6H5eGdKpa9w680Wbt7PwtDPFBHw/ghwQ6+55MIOC1Utnj9MURQ==', N'RKGHJXBEOZQQ7IY3RTK6XKSRUZ32NI5S', N'518733f4-9e99-4adf-add9-1ff48bbab2a7', N'111111111', 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([Id], [CityName], [CountryId], [StateId], [IsActive]) VALUES (1, N'Rajkot', 7, 11, 1)
INSERT [dbo].[Cities] ([Id], [CityName], [CountryId], [StateId], [IsActive]) VALUES (2, N' Vadodara', 7, 11, 1)
INSERT [dbo].[Cities] ([Id], [CityName], [CountryId], [StateId], [IsActive]) VALUES (3, N' Ahmedabad', 7, 11, 1)
INSERT [dbo].[Cities] ([Id], [CityName], [CountryId], [StateId], [IsActive]) VALUES (4, N' Surat', 7, 11, 1)
INSERT [dbo].[Cities] ([Id], [CityName], [CountryId], [StateId], [IsActive]) VALUES (5, N'Jamnagar', 7, 11, 1)
INSERT [dbo].[Cities] ([Id], [CityName], [CountryId], [StateId], [IsActive]) VALUES (6, N' Porbanda', 7, 11, 1)
INSERT [dbo].[Cities] ([Id], [CityName], [CountryId], [StateId], [IsActive]) VALUES (7, N'Gandhinagar', 7, 11, 1)
INSERT [dbo].[Cities] ([Id], [CityName], [CountryId], [StateId], [IsActive]) VALUES (8, N' Deesa', 7, 11, 1)
INSERT [dbo].[Cities] ([Id], [CityName], [CountryId], [StateId], [IsActive]) VALUES (9, N' Upleta', 7, 11, 1)
INSERT [dbo].[Cities] ([Id], [CityName], [CountryId], [StateId], [IsActive]) VALUES (10, N'Junagadh', 7, 11, 1)
INSERT [dbo].[Cities] ([Id], [CityName], [CountryId], [StateId], [IsActive]) VALUES (11, N'Mehsana', 7, 11, 1)
INSERT [dbo].[Cities] ([Id], [CityName], [CountryId], [StateId], [IsActive]) VALUES (12, N' Bharuch', 7, 11, 1)
INSERT [dbo].[Cities] ([Id], [CityName], [CountryId], [StateId], [IsActive]) VALUES (13, N'Jetpur', 7, 11, 1)
INSERT [dbo].[Cities] ([Id], [CityName], [CountryId], [StateId], [IsActive]) VALUES (14, N' Veraval', 7, 11, 1)
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
SET IDENTITY_INSERT [dbo].[Companies] ON 

INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (1, N'Hotel Nova Bopal', 1, NULL, NULL, N'\images\companies\company-1\015373fe-0866-4765-80b9-230513e59d35.jpg', 3, 11, 7, N'Gota Gam,Near Gopal Vadi', N'I wish I had taken a few photos but after a journey from Manali to New Delhi, I was tired and skipped the photo part. ', N'8596741452', N'hardikkkanzariya@gmail.com', N'Claimed', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.nilkasnth.com/', N'https://web.twitter.com/', NULL, CAST(N'2023-09-20T18:06:42.8241789' AS DateTime2), CAST(N'2023-02-02T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (2, N'TGM Hotels', 1, NULL, NULL, N'\images\companies\company-2\9bfba309-82e4-4de8-8fda-bb58025f156a.jpg', 1, 11, 7, N'CG road', N'Excellent Hotel Hygenic room central location friendly staff', N'9565754565', N'tgmhotels@345.com', N'Claimed', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.tgm.com/', N'https://web.twitter.com/', NULL, CAST(N'2023-09-20T18:09:55.7232532' AS DateTime2), CAST(N'2020-02-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (3, N'Sai House Hotels ', 1, NULL, NULL, N'\images\companies\company-3\fe307b2e-ba68-420d-9d95-2aa81ddfaad9.jpg', 1, 11, 7, N'Nava Vadaj,near gopal vadi', N'Had a good experience', N'8575152363', N'saihouse@345.com', N'Claimed', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.sai.com/', N'https://web.twitter.com/', NULL, CAST(N'2023-09-05T17:25:43.0237822' AS DateTime2), CAST(N'2023-02-02T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (4, N'Hotel Red house', 1, NULL, NULL, N'\images\companies\company-4\5006608d-a424-403c-b51a-fd5a6566c438.jpg', 1, 11, 7, N'Naroda Gam.near shyam park', N'Nice Hotel & Good Staff', N'9636251454', N'redhouse@3434.com', N'Claimed', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.sai.com/', N'https://web.twitter.com/', NULL, CAST(N'2023-09-12T15:59:30.7681467' AS DateTime2), CAST(N'2020-04-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (5, N'Silver Life Gym', 5, NULL, NULL, N'\images\companies\company-5\fa2f282f-00a4-4ee7-a193-6f0f1a65da01.jpg', 1, 11, 7, N'Cross Road NaranPura', N'Love this place! The trainers are amazing and offer tons of support and encouragement on your fitness journey. ', N'7896541232', N'silverlifegym@345.com', N'Claimed', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.silver.com/', N'https://web.twitter.com/', NULL, CAST(N'2023-09-20T18:14:12.4913809' AS DateTime2), CAST(N'2019-02-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (6, N'Fiteness Favor', 5, NULL, NULL, N'\images\companies\company-6\2d81f6a5-6da6-4dee-b170-a95233341d8f.jpg', 1, 11, 7, N'Sindhu bhavan Road', N'Amazing personal trainers and complete, clean gym. the overall vibe is great and I have had nothing ', N'7485963625', N'finess@3434.co9m', N'verified', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.nilkasnth.com/', N'https://web.twitter.com/', NULL, CAST(N'2023-09-20T18:12:48.2895998' AS DateTime2), CAST(N'2018-08-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (7, N'Fitness Destination', 5, NULL, NULL, N'\images\companies\company-7\f1e2bf91-59ed-4d7d-bcdb-b7990e34cb86.jpg', 3, 11, 7, N'South Bopal, Ahmedabad', N'This is a fantastic gym!! All the trainers are super nice and take an interest in you no matter what fitness level you`re at. ', N'8596362512', N'hardikkkanzariya@gmail.com', N'verified', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.Fintess.com/', N'https://web.twitter.com/', NULL, CAST(N'2023-09-20T18:13:30.7261207' AS DateTime2), CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (8, N'Commando Gym', 5, NULL, NULL, N'\images\companies\company-8\778ecda9-01f1-4f34-94ed-2215b175da29.jpg', 2, 11, 7, N'Krishna Nagar, Ahmedabad
', N'AMAZING GYM ! The staffs here are incredibly friendly and extremely qualified.. ', N'84596362514', N'redhouse@3434.com', N'verified', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.silver.com/', N'https://web.twitter.com/', NULL, CAST(N'2023-09-20T18:11:02.4475313' AS DateTime2), CAST(N'2020-02-02T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (9, N'T32 Dental Care', 8, NULL, NULL, N'\images\companies\company-9\f2c8f3a1-0911-4737-a66c-85e69de5ecc9.jpg', 1, 11, 7, N'Satellite, Ahmedabad', N'The professionalism and friendliness of the whole team is outstanding.', N'8585964745', N'tai9@3434.co9m', N'verified', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.t32.com/', N'https://web.twitter.com/', NULL, CAST(N'2023-09-12T14:45:05.3989365' AS DateTime2), CAST(N'2023-02-02T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (10, N'PRIME DENTAL CARE Dr.Ankita Bhatt', 8, NULL, NULL, N'\images\companies\company-10\38883a4f-e026-4419-b1cb-450c2b63077f.jpg', 3, 11, 7, N'Chharodi, Ahmedabad', N'Very nice dental clinic with good and kind doctor', N'74859636254', N'deep@3434.com', N'verified', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.ankita.com/', N'https://web.twitter.com/', NULL, CAST(N'2023-09-20T18:16:19.2760815' AS DateTime2), CAST(N'2023-02-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (11, N'Karnavati Dental Care', 8, NULL, NULL, N'\images\companies\company-11\12246d89-cf58-45b5-a0f9-8e6489eea755.jpg', 2, 11, 7, N'Vastrapur, Ahmedabad', N' got my wisdom tooth removed successfully and without any pain', N'8575489564', N'dental@3434.co9m', N'Claimed', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.denatal.com/', N'https://web.twitter.com/', NULL, CAST(N'2023-09-20T18:16:02.4633561' AS DateTime2), CAST(N'2021-06-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (12, N'House Of Dontics', 8, NULL, NULL, N'\images\companies\company-12\ae1c3655-309b-49d5-8626-57cb2de0cb64.jpg', 10, 11, 7, N'Prahladnagar, Ahmedabad
', N'The staff was great.', N'9636251455', N'housedontices@345.com', N'verified', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.house.com/', N'https://web.twitter.com/', NULL, CAST(N'2023-09-20T18:15:40.8922826' AS DateTime2), CAST(N'2021-02-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (13, N'Radhe Krishna Paying Guest', 9, NULL, NULL, NULL, 3, 11, 7, N'Chandkheda, Ahmedabad', N'.The PG is a nice play to stay, is hygienic and rooms are spacious. The food is GREAT', N'8596362514', N'radhe@3434.co9m', N'Claimed', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.radhekrisha.com/', N'https://web.twitter.com/', NULL, NULL, CAST(N'2023-05-02T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (14, N'Apna Ghar Girls Pg', 9, NULL, NULL, N'\images\companies\company-14\4bc0a58f-37ae-4ccc-9722-1e96357ea272.jpg', 4, 11, 7, N'Chandkheda, Ahmedabad', N'Best pg with excellent service good food and all the facilities area available', N'7595654785', N'apna@3434.co9m', N'verified', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.apnaa.com/', N'https://web.twitter.com/', NULL, CAST(N'2023-09-20T10:36:06.0520803' AS DateTime2), CAST(N'2020-04-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (15, N'Navkar Pg', 9, NULL, NULL, NULL, 3, 11, 7, N'Navrangpura, Ahmedabad
', N'It was a good experience staying in Paradise Pg behaviour is very good.', N'8596362514', N'deep@gmail.com', N'verified', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.narkar.com/', N'https://web.twitter.com/', NULL, NULL, CAST(N'2023-02-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (16, N'VP Brother pg', 9, NULL, NULL, NULL, 3, 11, 7, N'Gota Gam ,Near Vastnagar ', N'Awesome food and service', N'8596362514', N'vpbro@345.com', N'Claimed', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.vp.com/', N'https://web.twitter.com/', NULL, NULL, CAST(N'2023-02-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (19, N'Om Real Estate', 10, NULL, NULL, NULL, 3, 11, 7, N'Chandkheda, Ahmedabad', N'Nice person, good behaviour.. thanks for ur help.', N'85963625147', N'hardikkkanzariya@gmail.com', N'Claimed', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.omreal.com/', N'https://web.twitter.com/', NULL, CAST(N'2023-09-05T10:35:49.3422000' AS DateTime2), CAST(N'2021-02-22T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (20, N' Estate Agents Estate Agents For Residential Rental', 10, NULL, NULL, NULL, 3, 11, 7, N'Vastral, ahmedabad', N'My home loan was taken from LIC Housing', N'7898653212', N'estateagnets@gmail.com', N'verified', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.estateangents.com/', N'https://web.twitter.com/', NULL, CAST(N'2023-09-05T10:35:57.7959643' AS DateTime2), CAST(N'2020-02-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (21, N'Sarvodaya School', 3, 5, NULL, NULL, 1, 11, 7, N'Godal Road Near Gopal Vadi', N'After learning at this school for two years, I can confidently', N'7565153212', N'Sarvodaya@gmail.com', N'Claimed', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.sarvodaya.com/', N'https://web.twitter.com/', NULL, NULL, CAST(N'2023-02-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (22, N'SOS School', 3, 5, NULL, N'\images\companies\company-22\a38c8aea-10e3-4cdd-9456-95b7bcf81ef7.jpg', 1, 11, 7, N'KKV hall Near indra Circle', N'Personal attention lete hain personal security hai reasonable price', N'8596362510', N'sos@3434.com', N'Claimed', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.soso.com/', N'https://web.twitter.com/', NULL, CAST(N'2023-09-12T15:35:41.9080229' AS DateTime2), CAST(N'2023-02-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (23, N'Dholkiya School', 3, 5, NULL, N'\images\companies\company-23\602e52bd-610e-48a2-974a-45e1505e5171.jpg', 1, 11, 7, N'Balaji Chowk Rajkot', N'It`s a very good preschool helped my child to develop socially and emotionally ,', N'6354419505', N'dholkiya@3434.com', N'verified', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.dokscl.com/', N'https://web.twitter.com/', NULL, CAST(N'2023-09-12T15:37:24.4839388' AS DateTime2), CAST(N'2005-05-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (24, N'Modi School', 3, 5, NULL, NULL, 2, 11, 7, N'Sagar Hall  Near papayawadi', N'RP vasunny school Nicole narayana bought a chief college but I may study my own cave faculty', N'8160889565', N'modi@3434.co9m', N'Claimed', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.modi.com/', N'https://web.twitter.com/', NULL, NULL, CAST(N'2001-12-23T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (25, N'LD College', 3, 6, NULL, N'\images\companies\company-25\c5df6fa3-0731-4309-9bc0-88281ac816d9.jpg', 1, 11, 7, N'Naranpura Vistar, Ahmedabad', N'It`s a very good institute for hotel management, faculties are very good at teaching,', N'6554654575', N'ld@3434.co9m', N'Claimed', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.ld.com/', N'https://web.twitter.com/', NULL, CAST(N'2023-09-12T14:46:05.3850809' AS DateTime2), CAST(N'2001-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (26, N'SIlver Oak', 3, 6, NULL, NULL, 1, 11, 7, N'Gota Gam near Bhavarsar Society', N'I had an amazing experience with Aishwarya achievers academy. we gained deep knowledge', N'8596362514', N'silveroak@3434.co9m', N'verified', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.silver.com/', N'https://web.twitter.com/', NULL, NULL, CAST(N'1991-12-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (27, N'Sal College', 3, 6, NULL, NULL, 3, 11, 7, N'Nava Vadaj,', N'If it was possible I would give zero to this hospital. For the time being, we had got our child treated here', N'0281963625', N'hardikkkanzariya@gmail.com', N'Claimed', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.nilkasnth.com/', NULL, NULL, NULL, CAST(N'1991-05-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (28, N'Kidzee Prahladnagar & Moon Stars Day Care', 3, 17, NULL, NULL, 3, 11, 7, N'Juna Vadaj', N'For preprimary put your kids in this in for Pralahnagar area, good teaching with trained teachers. ', N'0281632541', N'hardikkkanzariya@gmail.com', N'verified', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.paly.com/', NULL, NULL, NULL, CAST(N'1991-12-31T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (29, N'Jsk Dance Academy & Events', 3, 17, NULL, NULL, 3, 11, 7, N'gota gam,near Gopal vadi', N'I`ve been at multiple dance studios, but this one has the nicest staff, most beautiful and relaxing environment, ', N'8596362514', N'Deepjadav@gmail.com', N'Claimed', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.nilkasnth.com/', N'https://web.twitter.com/', NULL, NULL, CAST(N'1999-12-30T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (30, N'Kanchi Kala Classes', 3, 17, NULL, NULL, 3, 11, 7, N'Nava Naroda', N'My daughter has been going to Kanchi Kala class for various activities since last 4 years.', N'78986545236', N'hardikkkanzariya@gmail.com', N'verified', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.t32.com/', N'https://web.twitter.com/', NULL, NULL, CAST(N'1980-02-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (31, N'Shree Sahjanand Realty', 10, NULL, NULL, NULL, 1, 11, 7, N'Nava naroda', N'Nice the same building he lives in.was extremely helpful, open, transparent, and reliable through the whole process,', N'8596362541', N'finess@3434.co9m', N'verified', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.Fintess.com/', N'https://web.twitter.com/', NULL, NULL, CAST(N'1999-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (32, N'Sebhriya Real Estate', 10, NULL, NULL, NULL, 3, 11, 7, N'Nava Naroda', N'it is good ', N'9636251478', N'hardikkkanzariya@gmail.com', N'Claimed', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.tgm.com/', N'https://web.twitter.com/', NULL, NULL, CAST(N'1974-05-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (33, N'Komal Beauty Parlour', 7, 13, NULL, NULL, 1, 11, 7, N'Nava Naroda', N'Cheap, good and beautiful means Komal Beauty Parlour.', N'963625145', N'hardikkkanzariya@gmail.com', N'verified', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', NULL, N'https://web.koml.com/', N'https://web.twitter.com/', NULL, NULL, CAST(N'1990-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (34, N'Jawed Habib Hair & Beauty Salon', 7, 13, NULL, NULL, 3, 11, 7, N'Nava Nikoal', N'I have gone there with my friend he is taking services from them since last 3 months he recommended', N'02816536252', N'redhouse@3434.com', N'verified', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.Fintess.com/', N'https://web.twitter.com/', NULL, NULL, CAST(N'1993-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (35, N' The Aesthetica Center', 7, 14, NULL, NULL, 3, 11, 7, N'Gota Gam', N'I was absolutely shocked at the level of expertise and professionalism of the cosmetic surgeon doctor ', N'8596969697', N'deep@gmail.com', N'verified', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.t32.com/', N'https://web.twitter.com/', NULL, NULL, CAST(N'1999-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (36, N'Neetu''s Studio & Academy and Beautycare', 7, 14, NULL, NULL, 3, 11, 7, N'vastanagar near gota gam', N'Good customer services.', N'8985647589', N'tgmhotels@345.com', N'Claimed', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.nilkasnth.com/', NULL, NULL, NULL, CAST(N'2020-01-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (37, N'Makeover By Namrata Solani', 7, 15, NULL, NULL, 3, 11, 7, N'Nava Naroda', N'good Service ', N'8596471456', N'hardikkkanzariya@gmail.com', N'Claimed', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.nilkasnth.com/', N'https://web.twitter.com/', NULL, NULL, CAST(N'2022-12-31T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (38, N'Astha Unisex Salon', 7, 15, NULL, NULL, 3, 11, 7, N'Nava Naroda', N'Ashtha very impress you too many others and I also we have very happy image to all of them ', N'88585859636', N'hardikkkanzariya@gmail.com', N'Claimed', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.nilkasnth.com/', NULL, NULL, NULL, CAST(N'2002-12-31T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (39, N'Bhargav Bhatt and Associates', 6, 18, NULL, NULL, 1, 11, 7, N'Nava Vadaj', N'I`ve been using this CA for quite a while and I have to say, I am immensely pleased with the results.', N'7898654535', N'deep@gmail.com', N'Claimed', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.nilkasnth.com/', NULL, NULL, NULL, CAST(N'2022-12-31T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (40, N'Hiral Prajapati & Co', 6, 18, NULL, NULL, 1, 11, 7, N'Nava vadaj', N'To the hiral Prajapati and group thank you so much for an absolute support for my specific starting of businessah', N'7898654515', N'hirale@gmail.com', N'verified', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.tgm.com/', N'https://web.twitter.com/', NULL, NULL, CAST(N'2002-12-31T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (41, N'JIGAR SHAH AND ASSOCIATES', 6, 18, NULL, NULL, 3, 11, 7, N'Hiraeadi Near Bapunagar', N'Excellent CA Firm. Good work culture', N'7898789878', N'hardikkkanzariya@gmail.com', N'Claimed', NULL, 1, N'https://web.whatsapp.com/', N'https://web.Instagram.com/', N'https://web.Facebook.com/', N'https://web.sai.com/', N'https://web.twitter.com/', NULL, NULL, CAST(N'1993-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (42, N'Hardik Hotels', 1, NULL, NULL, N'\images\companies\company-42\72763228-bc00-46e1-bd50-ee9dae410b87.jpg', 12, 11, 7, N'Gota Gam,near Gopal Vadi', N'It was good Experience in this hotels', N'9651094585', N'deep@123', N'Verified', NULL, 1, N'https://www.whatsapp.com/', N'https://www.whatsapp.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, CAST(N'2023-09-20T18:08:26.1866520' AS DateTime2), CAST(N'2010-02-25T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (43, N'New Kathiyawadi Dhaba', 2, 1, 1, NULL, 3, 11, 7, N'Krushanji-4, near Gopal vadi , Shahkar main road', N'Food is excellent, service is excellent, and the setting is gorgeous. I appreciate that for the price, you get a lot of food', N'8596362541', N'deep@123', N'Verified', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.newdhaba.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2020-05-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (44, N'The Food Town', 2, 1, 1, NULL, 3, 11, 7, N'Gota Gam,Near Nava Vadaj', N'Excellent ambiance and super tasty food', N'7898654512', N'Foodtown@123.com', N'Verified', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.foodtown.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2023-05-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (45, N'Malti''s Kathiiyawadi Dhaba', 2, 1, 1, NULL, 3, 11, 7, N'Nava Vadaj,near Gopal Vadi', N'First time in (Malti kathiyawadi) and YOU have to go! It`s the cutest little spot with amazing food. The (Malti kathiyawadi) is to die for', N'8596362514', N'matkidhaba@345.com', N'Verified', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2020-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (46, N'Radhakrishna Pure Veg Restaurant', 2, 1, 1, NULL, 1, 11, 7, N'Sidhu Bhavan Road', N'Will recommend to every one', N'8998784565', N'pureveg@123', N'Claimed', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', NULL, NULL, NULL, CAST(N'2001-08-07T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (47, N'Sapre & Sons Restaurant', 2, 1, 2, NULL, 1, 11, 7, N'Krushanji-4, near Gopal vadi , Shahkar main road', N'It`s a great experience. The ambiance is very welcoming and charming. Amazing food and service.', N'8978984565', N'spareandsons@123', N'Claimed', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2002-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (48, N'New Kathiyawadi', 2, 1, 2, NULL, 3, 11, 7, N' Gopal vadi , Shahkar main road', N'Food is excellent, service is excellent, and the setting is gorgeous. ', N'8596474474', N'newkadhba@123', N'Verified', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2020-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (49, N'Chinese.com', 2, 1, 2, NULL, 1, 11, 7, N'Gota Gam,near Papayawadi', N'Awesome experience.', N'7898654525', N'chinsesscom@2345.com', N'Verified', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2001-01-30T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (50, N'Club Escape', 2, 2, 3, NULL, 2, 11, 7, N'Krushanji-4, near Gopal vadi , Shahkar main road', N'Good place to hangout at night with friends.', N'8475956242', N'clubsespe@123', N'Verified', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2020-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (51, N'Shachi Caterers', 2, 2, 3, NULL, 3, 11, 7, N'Krushanji-4, near Gopal vadi , Shahkar main road', N'Food is good too eat ', N'8596147525', N'sachicheteee@123', N'Claimed', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2000-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (52, N'Up & Down The Lounge & Sports Bar', 2, 2, 3, NULL, 4, 11, 7, N' Shahkar main road,gopal nagar', N'Up & Down The Lounge & Sports Bar is a must-visit restaurant for', N'8798654565', N'upanddown@123', N'Claimed', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2020-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (53, N'Arena Lounge', 2, 2, 4, NULL, 11, 11, 7, N'Krushanji-4, near Gopal vadi , Shahkar main road', N'This cozy lounge has left the best impressions! ', N'7898654525', N'arenalog@123', N'Claimed', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.arena.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2000-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (54, N'Madeira & Mime', 2, 2, 4, NULL, 4, 11, 7, N'Gota Gam,Near Gopal Wadi', N'Absolutely amazing experience. Food, ambience, everything was just amazing! ', N'78986544562', N'mine@123', N'Verified', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2002-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (55, N'LEVEL 1 - BET BAR', 2, 2, 4, NULL, 10, 11, 7, N'Krushanji-4, near Gopal vadi , Shahkar main road', N'Good place for enjoy the evening with music and booze hand.', N'8596362514', N'betbar1@123', N'Claimed', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.bar.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2023-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (56, N' Cafe Coffee Day ', 2, 3, 6, N'\images\companies\company-56\736be378-86d2-4ccb-96bb-643e34e55551.jpg', 3, 11, 7, N'Krushanji-4, near Gopal vadi , Shahkar main road', N'Cafe Coffee Day is a must-visit place for coffee lovers ', N'9986655225', N'deep@123', N'Verified', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, CAST(N'2023-09-20T10:34:26.7095510' AS DateTime2), CAST(N'2020-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (57, N'The Vintage Cafe', 2, 3, 6, NULL, 1, 11, 7, N'Gota gam, Shahkar main road', N'Wonderful food with good atmosphere, and fantastic service', N'9852362541', N'vintagecafe@345.com', N'Claimed', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2002-06-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (58, N' Starbucks', 2, 3, 6, N'\images\companies\company-58\748bb65d-307a-4b70-8a3f-4a788bc766a2.jpg', 3, 11, 7, N'gota gam,near  jalaram chowak
', N'You will certainly find your self way back in in time once you enter.', N'9898653526', N'starbuks@123', N'Claimed', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.starbuks.com/', N'https://www.twitter.com/', NULL, CAST(N'2023-09-19T11:05:52.4031677' AS DateTime2), CAST(N'2000-02-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (59, N'Natural Ice Cream Parlour', 2, 3, 5, NULL, 2, 11, 7, N'Krushanji-4, near Gopal vadi , Shahkar main road', N'This is some of the best ice cream found in India. ', N'9865147562', N'natural@345', N'Claimed', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2005-05-07T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (60, N' Havmor Ice Cream', 2, 3, 5, NULL, 1, 11, 7, N'Papaywadi-4 near gopal wadi', N'Delivery was fast. Requested flavours were not available in shop, though they informed and sent other options', N'9865456525', N'icecream@3434.com', N'Verified', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2002-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (61, N'Cream Stone', 2, 3, 5, NULL, 7, 11, 7, N'Krushanji-4, near Gopal vadi , Shahkar main road
"Lunai krupa"', N'They serves variety of ice-creams. ', N'98778888855', N'creamstone@345.com', N'Verified', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2000-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (62, N'Dr. Anand Kumta Eye Retina Clinic Laser Centre', 4, 7, NULL, NULL, 1, 11, 7, N'Malad West,Rajkot
', N'Dr kumta is good in retina checking and treating any basic eye infection problem.', N'9878456512', N'anadakumar@345', N'Claimed', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2002-05-07T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (63, N'Dr. Ashish Sharma & Dr. Shubha Sharma Yashmeet Eye Dent Hospital', 4, 7, NULL, NULL, 12, 11, 7, N'Kalwa Thane,near papayawadi-4', N'Excellent service..very caring and friendly doctors and staff..', N'7865451232', N'shramabro@1323.com', N'Verified', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2023-06-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (64, N' Surya Eye Institute & Research Centre', 4, 7, NULL, NULL, 12, 11, 7, N'Krushanji-4, near Gopal vadi , Shahkar main road', N'I am really happy with the services given by Suriya Eye in Mulund', N'8956231252', N'suryayeye@345.com', N'Verified', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2020-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (65, N'Shreeji Hospital Multispeciality', 4, 8, NULL, NULL, 2, 11, 7, N'Krushanji-4, near Gopal vadi , Shahkar main road', N'Very good doctor their treatment is very good Anyone', N'9878456523', N'deep@123', N'Claimed', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2001-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (66, N'Saanvi Multispeciality Hospital Trauma Centre', 4, 8, NULL, NULL, 8, 11, 7, N'Krushanji-4, near Gopal vadi , Shahkar main road', N'Very good doctor their treatment is very good Anyone in my house has any problem, ', N'74859632125', N'saanvi@44474.com', N'Verified', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2020-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (67, N'Apex Hospitals', 4, 8, NULL, NULL, 3, 11, 7, N'Krushanji-4, near Gopal vadi , Shahkar main road', N'Dr. Are excellent and identifying the source of your problems.', N'7415252363', N'deep@123', N'Claimed', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, CAST(N'2023-09-12T12:56:06.2323951' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (68, N'Shiv Shakti', 1, NULL, NULL, N'\images\companies\company-68\df845bac-e5a1-4449-be36-29cb1c3d83f4.jpg', 5, 11, 7, N'New Jamnagar highway', N'Extremely high level of service throughout this entire hotel', N'9878456512', N'deep@123', N'Verified', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, CAST(N'2023-09-20T18:07:41.1638875' AS DateTime2), CAST(N'2002-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (69, N'Darshan Hotel', 1, NULL, NULL, N'\images\companies\company-69\b1527c78-0a70-4450-a613-30765ba68c96.jpg', 1, 11, 7, N'Ahmedabad Highway,near rajkot', N'Wow what a service like really im so happy with there services', N'6352147485', N'dhrashankorat@345.com', N'Verified', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.whatsapp.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, CAST(N'2023-09-20T18:10:05.9449449' AS DateTime2), CAST(N'2020-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (70, N'TGT Hotels', 1, NULL, NULL, N'\images\companies\company-70\7b4b37f5-f02e-43f9-8b03-9d8248b4d471.jpg', 1, 11, 7, N'new Papayawadi-4 ', N'Wow what a service like really im so happy', N'78986545123', N'tgthotels@345.com', N'Verified', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, CAST(N'2023-09-20T18:09:47.4450735' AS DateTime2), CAST(N'2023-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (71, N'SWARAM E.N.T. HOSPITAL', 4, 9, NULL, NULL, 6, 11, 7, N'Krushanji-4, near Gopal vadi , Shahkar main road', N'``For someone who has anxiety issues with clinical environments like hospitals', N'8563251445', N'ENThos@345.com', N'Claimed', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2020-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (72, N'Spiral Ent Care', 4, 9, NULL, NULL, 9, 11, 7, N'Nava Vadaj,NEar GOta', N' The clinic was also sterile and hygienic', N'8795635214', N'deep@123', N'Claimed', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2002-05-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (73, N'Amata Multi Speciality Hospital', 4, 9, NULL, NULL, 9, 11, 7, N'nava vadaj', N'Samata Multi Specialty Hospital located at Chandlodiya doing excellent work for the society. ', N'7452362545', N'deep@123', N'Verified', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, NULL, CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (75, N'Deep Fast Food & Restaurent', 1, NULL, NULL, N'\images\companies\company-75\ba034522-383a-46e6-929a-81ae2a7e3f1f.jpg', 1, 11, 7, N'Krushanji-4, near Gopal vadi , Shahkar main road
"Lunai krupa"', N'This is the Famous Branch 9in the gujarati  and  south indian food.', N'951094913', N'deep@123', N'Verified', NULL, 1, N'https://www.whatsapp.com/', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.website.com/', N'https://www.twitter.com/', NULL, CAST(N'2023-09-20T18:04:16.4905930' AS DateTime2), CAST(N'2023-09-14T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (77, N'Deep Fast Food', 2, 1, 1, N'\images\companies\company-77\1e693aae-0953-4ce6-a1c2-dc161d3c41ae.jpg', 1, 11, 7, N'Krushanji-4, near Gopal vadi , Shahkar main road
"Lunai krupa"', N'desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc
desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc
desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc
desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc
desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc
desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc
desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc
desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc
desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc
desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc
desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc
desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc descdesc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc
desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc
desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc
desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc descdesc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc
desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc
desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc
desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc descdesc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc
desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc
desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc
desc descdesc desc desc descdesc desc desc descdesc desc desc descdesc desc', N'123456789000000000000', N'deep@123.com', N'Verified', NULL, 1, N'https://www.whatsapp.com', N'https://www.instagram.com/', N'https://www.facebook.com/', N'https://www.bar.com/', N'https://www.twitter.com/', NULL, CAST(N'2023-09-15T16:32:24.4886113' AS DateTime2), CAST(N'2023-09-02T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Companies] ([Id], [CompanyName], [FirstCategoryId], [SecondCategoryId], [ThirdCategoryId], [CompanyLogo], [CityId], [StateId], [CountryId], [Address], [Description], [PhoneNumber], [Email], [Certificate], [IsDelete], [IsActive], [WhatsApp], [InstagramId], [Facebook], [Website], [Twitter], [CreatedDate], [UpdatedDate], [EstablishDate]) VALUES (83, N'jay food', 8, 14, 1, NULL, 3, 11, 7, N'<p>rdfeddd</p>', N'<p>ededededededvvvv eded</p>', N'8596547855', N'asdfg@gmail.com', N'ededededede', NULL, 1, N'https://Whatsapp:44332/', N'https://www.instagram.com', N'https://www.Facebook.com', N'https://www.website.com', NULL, NULL, NULL, CAST(N'2023-10-10T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Companies] OFF
GO
SET IDENTITY_INSERT [dbo].[CompanyImages] ON 

INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (3, N'\images\companies\company-2\9bfba309-82e4-4de8-8fda-bb58025f156a.jpg', 2, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (5, N'\images\companies\company-3\fe307b2e-ba68-420d-9d95-2aa81ddfaad9.jpg', 3, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (6, N'\images\companies\company-4\5006608d-a424-403c-b51a-fd5a6566c438.jpg', 4, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (8, N'\images\companies\company-9\f2c8f3a1-0911-4737-a66c-85e69de5ecc9.jpg', 9, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (9, N'\images\companies\company-25\2e83f419-6348-4449-836a-9d504b1a435d.jpg', 25, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (10, N'\images\companies\company-25\c5df6fa3-0731-4309-9bc0-88281ac816d9.jpg', 25, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (11, N'\images\companies\company-21\45e42fac-5768-494c-8caf-00815c36f313.jpg', 21, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (12, N'\images\companies\company-22\a38c8aea-10e3-4cdd-9456-95b7bcf81ef7.jpg', 22, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (13, N'\images\companies\company-23\602e52bd-610e-48a2-974a-45e1505e5171.jpg', 23, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (14, N'\images\companies\company-23\dc2c63e7-68a8-4671-9dcd-f8f3fc32a64a.jpg', 23, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (15, N'\images\companies\company-23\a27529dc-27a1-44a4-a489-997c7dd216d5.jpg', 23, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (16, N'\images\companies\company-32\8c07a422-9326-4dc9-92ba-ebf5636acabc.jpg', 32, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (17, N'\images\companies\company-24\25633849-f5a6-474b-93cf-d8ea5d8f982c.jpg', 24, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (18, N'\images\companies\company-10\38883a4f-e026-4419-b1cb-450c2b63077f.jpg', 10, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (19, N'\images\companies\company-77\75f637d1-d4e0-4131-b1ee-3355037489f3.jpg', 77, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (20, N'\images\companies\company-77\4e2efc31-2799-42c4-8a46-91d5b85a1481.jpg', 77, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (21, N'\images\companies\company-77\ac72b3f6-c229-49e0-ade7-2f497655ba01.jpg', 77, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (22, N'\images\companies\company-77\f4a083bd-8fc9-4a96-8796-8c83ef3f4ffb.jpg', 77, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (23, N'\images\companies\company-77\69c47f68-7d42-408c-9384-86bf03a46ed8.jpg', 77, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (24, N'\images\companies\company-77\38cf6bca-2480-4163-b654-e36309e21610.jpg', 77, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (25, N'\images\companies\company-77\ab544604-b5fa-4877-b5c7-e606cf67fabe.jpg', 77, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (26, N'\images\companies\company-77\39856800-f161-43db-81fc-54ec35ff84f5.jpg', 77, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (27, N'\images\companies\company-77\1e693aae-0953-4ce6-a1c2-dc161d3c41ae.jpg', 77, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (28, N'\images\companies\company-77\da51c7e7-17c7-471f-907c-421c1114348f.jpg', 77, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (29, N'\images\companies\company-77\e4db0bb9-623e-4a08-9b00-b9bf7c960152.jpg', 77, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (30, N'\images\companies\company-77\4f21cc8e-94b0-43a9-bec2-bef70b236044.jpg', 77, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (31, N'\images\companies\company-77\453b6f67-842a-4aa7-b424-d874cd4b0e82.jpg', 77, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (32, N'\images\companies\company-77\ce152634-bab4-4e86-a848-622768125821.jpg', 77, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (33, N'\images\companies\company-77\6ffaa98e-d85f-4974-ba24-2f5de8d0ce2c.jpg', 77, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (34, N'\images\companies\company-77\b96f2a69-b1c7-4af8-a182-39cc5bac4573.jpg', 77, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (35, N'\images\companies\company-77\fd64adec-0e75-45e9-b7ac-e8a523169b5f.jpg', 77, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (36, N'\images\companies\company-14\3ad7b2e5-5b1e-403c-98f3-cc257bc10a9a.jpg', 14, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (37, N'\images\companies\company-58\748bb65d-307a-4b70-8a3f-4a788bc766a2.jpg', 58, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (38, N'\images\companies\company-56\07fe5dda-a93e-499b-9fde-daa181c44ba6.jpg', 56, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (55, N'\images\companies\company-56\736be378-86d2-4ccb-96bb-643e34e55551.jpg', 56, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (56, N'\images\companies\company-60\2a9919e6-6d5a-4d32-a9db-edf153ab0b47.jpg', 60, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (57, N'\images\companies\company-14\4bc0a58f-37ae-4ccc-9722-1e96357ea272.jpg', 14, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (58, N'\images\companies\company-69\b1527c78-0a70-4450-a613-30765ba68c96.jpg', 69, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (59, N'\images\companies\company-75\ba034522-383a-46e6-929a-81ae2a7e3f1f.jpg', 75, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (60, N'\images\companies\company-1\015373fe-0866-4765-80b9-230513e59d35.jpg', 1, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (61, N'\images\companies\company-68\df845bac-e5a1-4449-be36-29cb1c3d83f4.jpg', 68, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (62, N'\images\companies\company-42\72763228-bc00-46e1-bd50-ee9dae410b87.jpg', 42, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (63, N'\images\companies\company-70\7b4b37f5-f02e-43f9-8b03-9d8248b4d471.jpg', 70, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (64, N'\images\companies\company-8\778ecda9-01f1-4f34-94ed-2215b175da29.jpg', 8, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (65, N'\images\companies\company-6\2d81f6a5-6da6-4dee-b170-a95233341d8f.jpg', 6, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (66, N'\images\companies\company-7\84794463-6d4b-4650-9b59-b9bfb79d22f5.jpg', 7, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (67, N'\images\companies\company-7\9dfe25ed-37f1-401b-9eaa-ba9c0ef70ddf.jpg', 7, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (68, N'\images\companies\company-7\f3c9f424-89cc-4b30-a9a1-9ed4fe6b5bbc.jpg', 7, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (69, N'\images\companies\company-7\f1e2bf91-59ed-4d7d-bcdb-b7990e34cb86.jpg', 7, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (70, N'\images\companies\company-7\f19fa1a7-d3f2-4710-a433-14e5a8f57dd2.jpg', 7, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (71, N'\images\companies\company-5\7953c3f8-9599-4992-b0e7-fbfa33c16747.jpg', 5, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (72, N'\images\companies\company-5\fa2f282f-00a4-4ee7-a193-6f0f1a65da01.jpg', 5, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (73, N'\images\companies\company-5\d382ef2b-b219-438f-a9f7-a314001d6b60.jpg', 5, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (74, N'\images\companies\company-5\e8b15c5d-0627-4605-83bb-22b4e17b4e1a.jpg', 5, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (75, N'\images\companies\company-5\5a544ecb-3478-4603-866c-897b8f10b3cb.jpg', 5, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (76, N'\images\companies\company-12\4a0e6048-f64e-4605-8bf2-a0eaa0b17974.jpg', 12, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (77, N'\images\companies\company-12\ae1c3655-309b-49d5-8626-57cb2de0cb64.jpg', 12, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (78, N'\images\companies\company-12\d82fe1d8-8f50-4c57-a9bf-481a4789f458.jpg', 12, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (79, N'\images\companies\company-12\483d6dfc-72e0-41c6-aa83-f2223828762b.jpg', 12, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (80, N'\images\companies\company-12\c3253ead-b4da-4d41-ab01-8acc2ee99169.jpg', 12, 1)
INSERT [dbo].[CompanyImages] ([Id], [Image], [CompanyId], [IsActive]) VALUES (81, N'\images\companies\company-11\12246d89-cf58-45b5-a0f9-8e6489eea755.jpg', 11, 1)
SET IDENTITY_INSERT [dbo].[CompanyImages] OFF
GO
SET IDENTITY_INSERT [dbo].[CompanyXAmenities] ON 

INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (3, 15, 2)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (4, 20, 2)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (5, 13, 3)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (6, 15, 3)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (7, 20, 3)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (10, 7, 6)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (11, 21, 6)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (12, 3, 8)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (13, 7, 8)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (16, 22, 12)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (17, 17, 13)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (18, 18, 13)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (19, 25, 13)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (20, 8, 21)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (21, 11, 21)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (22, 16, 21)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (23, 19, 21)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (24, 31, 21)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (25, 22, 9)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (26, 47, 9)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (27, 25, 15)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (28, 21, 7)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (29, 26, 7)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (30, 2, 4)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (31, 5, 4)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (32, 48, 11)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (33, 49, 11)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (34, 17, 14)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (35, 25, 14)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (36, 30, 14)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (37, 6, 16)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (38, 17, 16)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (39, 51, 19)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (40, 9, 22)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (41, 16, 22)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (42, 19, 22)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (43, 23, 22)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (44, 41, 72)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (45, 42, 72)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (46, 40, 71)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (47, 41, 71)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (48, 16, 26)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (49, 19, 26)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (50, 23, 26)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (51, 28, 26)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (52, 9, 27)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (53, 11, 27)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (54, 16, 27)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (55, 19, 27)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (56, 8, 28)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (57, 9, 28)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (58, 22, 10)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (59, 47, 10)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (60, 16, 23)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (61, 19, 23)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (62, 23, 23)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (63, 11, 24)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (64, 16, 24)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (65, 23, 24)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (66, 9, 29)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (67, 11, 29)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (68, 16, 29)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (69, 2, 68)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (70, 5, 68)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (71, 13, 68)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (72, 34, 61)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (73, 36, 61)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (75, 7, 5)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (76, 21, 5)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (77, 37, 5)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (78, 2, 1)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (79, 5, 1)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (80, 34, 77)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (81, 36, 77)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (84, 34, 56)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (85, 36, 56)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (86, 2, 1)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (87, 5, 1)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (88, 13, 1)
INSERT [dbo].[CompanyXAmenities] ([Id], [AmenityId], [CompanyId]) VALUES (89, 15, 1)
SET IDENTITY_INSERT [dbo].[CompanyXAmenities] OFF
GO
SET IDENTITY_INSERT [dbo].[CompanyXPayments] ON 

INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (5, 4, 2)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (6, 4, 3)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (7, 4, 4)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (8, 5, 5)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (9, 5, 6)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (10, 5, 7)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (11, 6, 6)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (12, 6, 7)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (13, 7, 4)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (14, 7, 6)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (15, 7, 7)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (19, 10, 4)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (20, 10, 5)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (21, 10, 7)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (22, 13, 6)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (23, 13, 7)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (24, 13, 8)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (25, 14, 7)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (26, 14, 8)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (27, 11, 5)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (28, 11, 6)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (29, 12, 5)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (30, 12, 6)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (34, 20, 3)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (35, 20, 4)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (36, 20, 5)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (37, 22, 3)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (38, 22, 4)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (39, 22, 5)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (40, 22, 7)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (41, 72, 3)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (42, 72, 4)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (43, 30, 3)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (44, 30, 4)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (45, 26, 2)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (46, 26, 3)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (47, 26, 4)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (48, 25, 3)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (49, 25, 4)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (50, 25, 5)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (51, 23, 4)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (52, 23, 5)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (53, 23, 6)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (54, 23, 7)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (55, 23, 8)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (56, 24, 4)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (57, 24, 6)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (58, 24, 7)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (59, 29, 5)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (60, 29, 6)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (61, 29, 7)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (62, 68, 4)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (63, 68, 6)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (64, 68, 7)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (65, 68, 8)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (66, 61, 3)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (67, 61, 4)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (91, 56, 2)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (92, 56, 3)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (97, 3, 1)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (98, 2, 7)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (99, 2, 8)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (100, 2, 5)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (101, 2, 3)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (102, 2, 10)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (111, 15, 1)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (112, 15, 3)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (113, 83, 1)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (114, 83, 3)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (115, 83, 5)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (116, 83, 7)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (117, 83, 9)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (118, 77, 2)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (119, 77, 4)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (120, 77, 6)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (121, 77, 8)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (122, 77, 10)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (123, 75, 1)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (124, 75, 2)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (125, 75, 3)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (126, 75, 4)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (127, 75, 5)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (128, 75, 6)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (129, 75, 7)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (130, 75, 8)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (131, 75, 9)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (132, 75, 10)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (147, 1, 9)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (148, 1, 10)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (149, 1, 1)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (150, 1, 2)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (151, 1, 3)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (152, 1, 4)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (162, 9, 4)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (163, 9, 5)
INSERT [dbo].[CompanyXPayments] ([Id], [CompanyId], [PaymentId]) VALUES (164, 9, 6)
SET IDENTITY_INSERT [dbo].[CompanyXPayments] OFF
GO
SET IDENTITY_INSERT [dbo].[CompanyXServices] ON 

INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (5, 3, 9)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (6, 3, 10)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (7, 3, 11)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (8, 5, 5)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (9, 5, 6)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (10, 7, 3)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (11, 7, 5)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (12, 7, 6)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (13, 9, 37)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (14, 9, 38)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (15, 10, 36)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (16, 10, 37)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (19, 14, 40)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (20, 14, 41)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (21, 14, 42)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (22, 14, 44)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (23, 4, 9)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (24, 4, 10)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (25, 6, 3)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (26, 6, 4)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (27, 6, 5)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (31, 11, 34)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (32, 11, 35)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (33, 11, 38)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (34, 12, 35)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (35, 12, 36)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (36, 12, 37)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (37, 13, 41)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (38, 13, 42)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (39, 13, 43)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (40, 15, 44)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (41, 20, 47)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (42, 20, 53)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (43, 20, 54)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (44, 21, 20)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (45, 21, 21)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (46, 21, 22)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (47, 23, 19)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (48, 23, 20)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (49, 23, 21)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (50, 72, 25)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (51, 72, 26)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (52, 26, 20)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (53, 26, 21)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (54, 26, 22)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (55, 27, 22)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (56, 24, 20)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (57, 24, 21)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (58, 29, 20)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (59, 29, 21)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (60, 29, 22)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (61, 68, 8)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (62, 68, 9)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (63, 68, 10)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (68, 77, 12)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (69, 77, 13)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (70, 77, 14)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (71, 77, 16)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (72, 77, 17)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (73, 56, 12)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (74, 56, 13)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (75, 56, 14)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (76, 56, 16)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (77, 56, 17)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (78, 56, 18)
INSERT [dbo].[CompanyXServices] ([Id], [CompanyId], [ServiceId]) VALUES (84, 2, 55)
SET IDENTITY_INSERT [dbo].[CompanyXServices] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (1, N'Afghanistanf', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (2, N'Albania', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (3, N'Algeria', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (4, N'Andorra', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (5, N'Angola', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (6, N'Antigua and Barbuda', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (7, N'India', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (8, N'Bahamas', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (9, N'Bahrain', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (10, N'Bangladesh', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (12, N'Brazil', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (13, N'Canada', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (14, N'China', 0)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (15, N'Cuba', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (16, N'Denmark', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (17, N'Dominica', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (18, N'Dominican Republic', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (19, N'Egypt', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (20, N'Estonia', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (21, N'Fiji', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (22, N'France', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (23, N'Finland', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (24, N'Germany', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (25, N'Greece', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (26, N'Guyana', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (27, N'Haiti', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (28, N'Hungary', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (29, N'Iceland', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (30, N'Indonesia', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (31, N'Iran', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (33, N'Iraq', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (34, N'Italy', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (35, N'Jordan', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (37, N'Korea, North', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (38, N'Korea, South', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (39, N'Laos', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (40, N'Liberia', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (41, N'Malaysia', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (42, N'Maldives', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (43, N'Nepal', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (44, N'North Macedonia', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (45, N'Oman', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (46, N'Pakistan', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (47, N'Philippines', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (48, N'Qatar', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (49, N'Russia', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (50, N'South Africa', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (51, N'Spain', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (52, N'Thailand', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (53, N'Uganda', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (54, N'United Kingdom', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (55, N'United States', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (56, N'Vietnam', 1)
INSERT [dbo].[Countries] ([Id], [CountryName], [IsActive]) VALUES (57, N'Yemenhhdd', 1)
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[Enquiries] ON 

INSERT [dbo].[Enquiries] ([Id], [CompanyID], [UserName], [Email], [PhoneNumber], [Title], [Description]) VALUES (1, 60, N'Hardik', N'hardik123@gmail.com', 951094913, N'Hardik', N'hardik kanzariya ')
INSERT [dbo].[Enquiries] ([Id], [CompanyID], [UserName], [Email], [PhoneNumber], [Title], [Description]) VALUES (2, 53, N'try', N'try123@gmail.com', 951094913, N'trt', N'dugsdjg')
SET IDENTITY_INSERT [dbo].[Enquiries] OFF
GO
SET IDENTITY_INSERT [dbo].[FirstCategories] ON 

INSERT [dbo].[FirstCategories] ([Id], [FirstCategoryName], [FirstCategoryImage], [IsActive]) VALUES (1, N'Hotels', N'/images/firstcategory/d6bbb842-bf03-4d35-a320-259bcfeb3ed1.jpg', 1)
INSERT [dbo].[FirstCategories] ([Id], [FirstCategoryName], [FirstCategoryImage], [IsActive]) VALUES (2, N'Restaurants', N'/images/firstcategory/ae4a6783-b05d-4cff-b61b-d195ba319073.jpg', 1)
INSERT [dbo].[FirstCategories] ([Id], [FirstCategoryName], [FirstCategoryImage], [IsActive]) VALUES (3, N'Education', N'/images/firstcategory/4550c36c-a62f-422b-9912-4205f6692085.jpg', 1)
INSERT [dbo].[FirstCategories] ([Id], [FirstCategoryName], [FirstCategoryImage], [IsActive]) VALUES (4, N'Hospitals', N'/images/firstcategory/b9d4e812-78f2-4849-a23c-325abf220b7f.jpg', 1)
INSERT [dbo].[FirstCategories] ([Id], [FirstCategoryName], [FirstCategoryImage], [IsActive]) VALUES (5, N'GYM', N'/images/firstcategory/fb115bf3-df6d-492e-a79d-7221322d4bca.jpg', 1)
INSERT [dbo].[FirstCategories] ([Id], [FirstCategoryName], [FirstCategoryImage], [IsActive]) VALUES (6, N'Consultants', N'/images/firstcategory/20f043d6-e57a-491a-aacf-5b7664c48741.jpg', 1)
INSERT [dbo].[FirstCategories] ([Id], [FirstCategoryName], [FirstCategoryImage], [IsActive]) VALUES (7, N'Beauty Spa', N'/images/firstcategory/d8f6bf81-d99a-4160-aeab-71c8ddb329e3.jpg', 1)
INSERT [dbo].[FirstCategories] ([Id], [FirstCategoryName], [FirstCategoryImage], [IsActive]) VALUES (8, N'Dentists', N'/images/firstcategory/3cfe83e5-bce3-4853-a2c2-d8f072b37334.jpg', 1)
INSERT [dbo].[FirstCategories] ([Id], [FirstCategoryName], [FirstCategoryImage], [IsActive]) VALUES (9, N'PG/Hostels', N'/images/firstcategory/23f6b37a-9b9a-45c6-9b48-432d3303c482.jpg', 1)
INSERT [dbo].[FirstCategories] ([Id], [FirstCategoryName], [FirstCategoryImage], [IsActive]) VALUES (10, N'Esate Agent', N'/images/firstcategory/ab6f3db2-a849-4735-acdd-b09380635ca5.jpg', 1)
SET IDENTITY_INSERT [dbo].[FirstCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([Id], [PaymentName], [IsActive]) VALUES (1, N'PayPal', 1)
INSERT [dbo].[Payments] ([Id], [PaymentName], [IsActive]) VALUES (2, N' Wire transfer', 1)
INSERT [dbo].[Payments] ([Id], [PaymentName], [IsActive]) VALUES (3, N'Cash', 1)
INSERT [dbo].[Payments] ([Id], [PaymentName], [IsActive]) VALUES (4, N'Credit card', 1)
INSERT [dbo].[Payments] ([Id], [PaymentName], [IsActive]) VALUES (5, N'Digital wallet', 1)
INSERT [dbo].[Payments] ([Id], [PaymentName], [IsActive]) VALUES (6, N'Mobile payment', 1)
INSERT [dbo].[Payments] ([Id], [PaymentName], [IsActive]) VALUES (7, N'Cash on delivery', 1)
INSERT [dbo].[Payments] ([Id], [PaymentName], [IsActive]) VALUES (8, N'ACH Direct Debit', 1)
INSERT [dbo].[Payments] ([Id], [PaymentName], [IsActive]) VALUES (9, N'Direct debit', 1)
INSERT [dbo].[Payments] ([Id], [PaymentName], [IsActive]) VALUES (10, N'American Express', 1)
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
SET IDENTITY_INSERT [dbo].[SecondCategories] ON 

INSERT [dbo].[SecondCategories] ([Id], [SecondCategoryName], [SecondCategoryImage], [FirstCategoryId], [IsActive]) VALUES (1, N'Indian Falvours', N'/images/secondcategory/fc1205f3-98c4-442a-91c3-62c483993e5e.jpg', 2, 1)
INSERT [dbo].[SecondCategories] ([Id], [SecondCategoryName], [SecondCategoryImage], [FirstCategoryId], [IsActive]) VALUES (2, N'NightLife', N'/images/secondcategory/3b6ca7eb-a243-49ec-9d14-a627a4ac9b99.jpg', 2, 1)
INSERT [dbo].[SecondCategories] ([Id], [SecondCategoryName], [SecondCategoryImage], [FirstCategoryId], [IsActive]) VALUES (3, N'Foodie', N'/images/secondcategory/c3eddb85-cde9-4c2a-9783-a02b6a4bc7be.jpg', 2, 1)
INSERT [dbo].[SecondCategories] ([Id], [SecondCategoryName], [SecondCategoryImage], [FirstCategoryId], [IsActive]) VALUES (5, N'School', N'/images/secondcategory/a5770e31-c490-4aec-8907-87cfbe0a86c3.jpg', 3, 1)
INSERT [dbo].[SecondCategories] ([Id], [SecondCategoryName], [SecondCategoryImage], [FirstCategoryId], [IsActive]) VALUES (6, N'Colleges', N'/images/secondcategory/432fa331-6643-4c42-a133-cb17057f6905.jpg', 3, 1)
INSERT [dbo].[SecondCategories] ([Id], [SecondCategoryName], [SecondCategoryImage], [FirstCategoryId], [IsActive]) VALUES (7, N'Eye Hospitals', N'/images/secondcategory/b7259db8-f57b-4bf9-bc12-3c0af1457ef0.jpg', 4, 1)
INSERT [dbo].[SecondCategories] ([Id], [SecondCategoryName], [SecondCategoryImage], [FirstCategoryId], [IsActive]) VALUES (8, N'Children Hospitals ', N'/images/secondcategory/9077967e-d64a-4e65-8ab7-c2d5a5c3b7a9.jpg', 4, 1)
INSERT [dbo].[SecondCategories] ([Id], [SecondCategoryName], [SecondCategoryImage], [FirstCategoryId], [IsActive]) VALUES (9, N'ENT Hospitals', N'/images/secondcategory/23262f70-b29b-4fbe-800c-41134deb9c50.jpg', 4, 1)
INSERT [dbo].[SecondCategories] ([Id], [SecondCategoryName], [SecondCategoryImage], [FirstCategoryId], [IsActive]) VALUES (13, N'Beauty Parlours', N'/images/secondcategory/1b00a789-1ff7-40eb-867a-6c30def33d36.jpg', 7, 1)
INSERT [dbo].[SecondCategories] ([Id], [SecondCategoryName], [SecondCategoryImage], [FirstCategoryId], [IsActive]) VALUES (14, N'Beauty Clinics ', N'/images/secondcategory/75c11696-df53-4e64-872f-2b0c5cb21196.jpg', 7, 1)
INSERT [dbo].[SecondCategories] ([Id], [SecondCategoryName], [SecondCategoryImage], [FirstCategoryId], [IsActive]) VALUES (15, N'Bridal Makeup', N'/images/secondcategory/edfb7a08-0011-44e9-830d-7460177f02db.jpg', 7, 1)
INSERT [dbo].[SecondCategories] ([Id], [SecondCategoryName], [SecondCategoryImage], [FirstCategoryId], [IsActive]) VALUES (17, N'Hobbies', N'/images/secondcategory/3914fa66-0063-4554-af80-a4cbe59568e1.jpg', 3, 1)
INSERT [dbo].[SecondCategories] ([Id], [SecondCategoryName], [SecondCategoryImage], [FirstCategoryId], [IsActive]) VALUES (18, N'Income Tax Consultants ', N'/images/secondcategory/746eee4d-f332-4d67-98ec-a2a193207a44.jpg', 6, 1)
SET IDENTITY_INSERT [dbo].[SecondCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (1, N'Drive Business Services', 1, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (2, N' Nutritional Support', 5, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (3, N'Personal Training', 5, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (4, N'Personal Trainers', 5, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (5, N'Weight Gain Program', 5, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (6, N' Weight Loss Treatment', 5, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (7, N' Credit and Debit Card facility', 1, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (8, N'Fireplace', 1, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (9, N'Breakfast', 1, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (10, N' Bicycle on Rent', 1, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (11, N' Currency Exchange', 1, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (12, N' Serves Beer', 2, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (13, N'Serves Craft Beer', 2, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (14, N'Ac', 2, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (15, N'Non Ac', 1, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (16, N' Dine-in', 2, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (17, N'Home Delivery', 2, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (18, N'Dinner Menu', 2, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (19, N' Kindergarten', 3, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (20, N'Higher Secondary', 3, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (21, N' English', 3, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (22, N' Upper Primary', 3, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (23, N' Medical Oncology', 4, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (24, N' Diabetes', 4, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (25, N' Gynaecological Cancer Treatment', 4, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (26, N' 24 Hours Open', 4, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (27, N'Cardiology', 4, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (28, N' Blood Group', 4, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (29, N'Diagnostic And Pathology', 4, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (30, N' Visiting Charges-500', 6, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (31, N'Commercial', 6, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (32, N' Residence', 6, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (33, N' Furniture', 6, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (34, N' Tooth Straightening', 8, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (35, N' Growth And Development Evaluation And Management', 8, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (36, N'Tooth Polishing', 8, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (37, N'Laser Dentistry', 8, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (38, N' Traumatic Dental Injuires', 8, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (39, N' Forensic Odontology', 8, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (40, N' Corporate', 9, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (41, N' Students', 9, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (42, N'Womens', 9, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (43, N'Mens', 9, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (44, N'Visitors allowed', 9, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (45, N' Rental', 10, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (46, N' Residence  home', 10, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (47, N' Commercial', 10, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (48, N'RICA WAX.', 7, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (49, N'PEDICURE.', 7, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (50, N'MASSAGES.', 7, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (51, N'MANICURE.', 7, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (52, N'Honey Wax.', 7, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (53, N' Plot', 10, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (54, N'Residence', 10, 1)
INSERT [dbo].[Services] ([Id], [ServiceName], [FirstCategoryId], [IsActive]) VALUES (55, N'Bicycle on Rent', 1, 1)
SET IDENTITY_INSERT [dbo].[Services] OFF
GO
SET IDENTITY_INSERT [dbo].[States] ON 

INSERT [dbo].[States] ([Id], [StateName], [CountryId], [IsActive]) VALUES (2, N'MP', 7, 1)
INSERT [dbo].[States] ([Id], [StateName], [CountryId], [IsActive]) VALUES (3, N'rajasthan', 7, 1)
INSERT [dbo].[States] ([Id], [StateName], [CountryId], [IsActive]) VALUES (4, N'Punjab', 7, 1)
INSERT [dbo].[States] ([Id], [StateName], [CountryId], [IsActive]) VALUES (6, N'Goa', 7, 1)
INSERT [dbo].[States] ([Id], [StateName], [CountryId], [IsActive]) VALUES (7, N'Maharashtra', 7, 1)
INSERT [dbo].[States] ([Id], [StateName], [CountryId], [IsActive]) VALUES (8, N'Haryana', 7, 1)
INSERT [dbo].[States] ([Id], [StateName], [CountryId], [IsActive]) VALUES (10, N' Delhi', 7, 1)
INSERT [dbo].[States] ([Id], [StateName], [CountryId], [IsActive]) VALUES (11, N' Gujarat', 7, 1)
SET IDENTITY_INSERT [dbo].[States] OFF
GO
SET IDENTITY_INSERT [dbo].[ThirdCategories] ON 

INSERT [dbo].[ThirdCategories] ([Id], [ThirdCategoryName], [ThirdCategoryImage], [FirstCategoryId], [SecondCategoryId], [IsActive]) VALUES (1, N'Gujarati', N'/images/thirdcategory/1fdc74f6-90fa-4478-8af9-b43e0ea5a0c8.jpg', 2, 1, 1)
INSERT [dbo].[ThirdCategories] ([Id], [ThirdCategoryName], [ThirdCategoryImage], [FirstCategoryId], [SecondCategoryId], [IsActive]) VALUES (2, N'Pure Veg', N'/images/thirdcategory/63b20119-0f34-4ef2-a4a9-27103936b520.jpg', 2, 1, 1)
INSERT [dbo].[ThirdCategories] ([Id], [ThirdCategoryName], [ThirdCategoryImage], [FirstCategoryId], [SecondCategoryId], [IsActive]) VALUES (3, N'Night Clubs', N'/images/thirdcategory/34cadb7d-3dee-41f9-a407-f2a060b3e865.jpg', 2, 2, 1)
INSERT [dbo].[ThirdCategories] ([Id], [ThirdCategoryName], [ThirdCategoryImage], [FirstCategoryId], [SecondCategoryId], [IsActive]) VALUES (4, N'Lounge Bars', N'/images/thirdcategory/cc59c9b1-4f56-4fe3-8ed7-25905d25c139.jpg', 2, 2, 1)
INSERT [dbo].[ThirdCategories] ([Id], [ThirdCategoryName], [ThirdCategoryImage], [FirstCategoryId], [SecondCategoryId], [IsActive]) VALUES (5, N'Best Ice Cream ', N'/images/thirdcategory/d520fe75-e136-4571-abc5-f1477afe2690.jpg', 2, 3, 1)
INSERT [dbo].[ThirdCategories] ([Id], [ThirdCategoryName], [ThirdCategoryImage], [FirstCategoryId], [SecondCategoryId], [IsActive]) VALUES (6, N'Coffee Shops ', N'/images/thirdcategory/eeff9d42-e3e3-4eec-963f-3b50bebd637c.jpg', 2, 3, 1)
SET IDENTITY_INSERT [dbo].[ThirdCategories] OFF
GO
ALTER TABLE [dbo].[Amenities]  WITH CHECK ADD  CONSTRAINT [FK_Amenities_FirstCategories_FirstCategoryId] FOREIGN KEY([FirstCategoryId])
REFERENCES [dbo].[FirstCategories] ([Id])
GO
ALTER TABLE [dbo].[Amenities] CHECK CONSTRAINT [FK_Amenities_FirstCategories_FirstCategoryId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_Countries_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_Cities_Countries_CountryId]
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_States_StateId] FOREIGN KEY([StateId])
REFERENCES [dbo].[States] ([Id])
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_Cities_States_StateId]
GO
ALTER TABLE [dbo].[Companies]  WITH CHECK ADD  CONSTRAINT [FK_Companies_Cities_CityId] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[Companies] CHECK CONSTRAINT [FK_Companies_Cities_CityId]
GO
ALTER TABLE [dbo].[Companies]  WITH CHECK ADD  CONSTRAINT [FK_Companies_Countries_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Companies] CHECK CONSTRAINT [FK_Companies_Countries_CountryId]
GO
ALTER TABLE [dbo].[Companies]  WITH CHECK ADD  CONSTRAINT [FK_Companies_FirstCategories_FirstCategoryId] FOREIGN KEY([FirstCategoryId])
REFERENCES [dbo].[FirstCategories] ([Id])
GO
ALTER TABLE [dbo].[Companies] CHECK CONSTRAINT [FK_Companies_FirstCategories_FirstCategoryId]
GO
ALTER TABLE [dbo].[Companies]  WITH CHECK ADD  CONSTRAINT [FK_Companies_SecondCategories_SecondCategoryId] FOREIGN KEY([SecondCategoryId])
REFERENCES [dbo].[SecondCategories] ([Id])
GO
ALTER TABLE [dbo].[Companies] CHECK CONSTRAINT [FK_Companies_SecondCategories_SecondCategoryId]
GO
ALTER TABLE [dbo].[Companies]  WITH CHECK ADD  CONSTRAINT [FK_Companies_States_StateId] FOREIGN KEY([StateId])
REFERENCES [dbo].[States] ([Id])
GO
ALTER TABLE [dbo].[Companies] CHECK CONSTRAINT [FK_Companies_States_StateId]
GO
ALTER TABLE [dbo].[Companies]  WITH CHECK ADD  CONSTRAINT [FK_Companies_ThirdCategories_ThirdCategoryId] FOREIGN KEY([ThirdCategoryId])
REFERENCES [dbo].[ThirdCategories] ([Id])
GO
ALTER TABLE [dbo].[Companies] CHECK CONSTRAINT [FK_Companies_ThirdCategories_ThirdCategoryId]
GO
ALTER TABLE [dbo].[CompanyImages]  WITH CHECK ADD  CONSTRAINT [FK_CompanyImages_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[CompanyImages] CHECK CONSTRAINT [FK_CompanyImages_Companies_CompanyId]
GO
ALTER TABLE [dbo].[CompanyXAmenities]  WITH CHECK ADD  CONSTRAINT [FK_CompanyXAmenities_Amenities_AmenityId] FOREIGN KEY([AmenityId])
REFERENCES [dbo].[Amenities] ([Id])
GO
ALTER TABLE [dbo].[CompanyXAmenities] CHECK CONSTRAINT [FK_CompanyXAmenities_Amenities_AmenityId]
GO
ALTER TABLE [dbo].[CompanyXAmenities]  WITH CHECK ADD  CONSTRAINT [FK_CompanyXAmenities_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[CompanyXAmenities] CHECK CONSTRAINT [FK_CompanyXAmenities_Companies_CompanyId]
GO
ALTER TABLE [dbo].[CompanyXPayments]  WITH CHECK ADD  CONSTRAINT [FK_CompanyXPayments_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[CompanyXPayments] CHECK CONSTRAINT [FK_CompanyXPayments_Companies_CompanyId]
GO
ALTER TABLE [dbo].[CompanyXPayments]  WITH CHECK ADD  CONSTRAINT [FK_CompanyXPayments_Payments_PaymentId] FOREIGN KEY([PaymentId])
REFERENCES [dbo].[Payments] ([Id])
GO
ALTER TABLE [dbo].[CompanyXPayments] CHECK CONSTRAINT [FK_CompanyXPayments_Payments_PaymentId]
GO
ALTER TABLE [dbo].[CompanyXServices]  WITH CHECK ADD  CONSTRAINT [FK_CompanyXServices_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[CompanyXServices] CHECK CONSTRAINT [FK_CompanyXServices_Companies_CompanyId]
GO
ALTER TABLE [dbo].[CompanyXServices]  WITH CHECK ADD  CONSTRAINT [FK_CompanyXServices_Services_ServiceId] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Services] ([Id])
GO
ALTER TABLE [dbo].[CompanyXServices] CHECK CONSTRAINT [FK_CompanyXServices_Services_ServiceId]
GO
ALTER TABLE [dbo].[Enquiries]  WITH CHECK ADD  CONSTRAINT [FK_Enquiries_Companies_CompanyID] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[Enquiries] CHECK CONSTRAINT [FK_Enquiries_Companies_CompanyID]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_AspNetUsers_ApplicationUserId] FOREIGN KEY([ApplicationUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_AspNetUsers_ApplicationUserId]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Companies_CompanyId]
GO
ALTER TABLE [dbo].[ReviewXComments]  WITH CHECK ADD  CONSTRAINT [FK_ReviewXComments_AspNetUsers_ApplicationUserId] FOREIGN KEY([ApplicationUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ReviewXComments] CHECK CONSTRAINT [FK_ReviewXComments_AspNetUsers_ApplicationUserId]
GO
ALTER TABLE [dbo].[ReviewXComments]  WITH CHECK ADD  CONSTRAINT [FK_ReviewXComments_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[ReviewXComments] CHECK CONSTRAINT [FK_ReviewXComments_Companies_CompanyId]
GO
ALTER TABLE [dbo].[ReviewXComments]  WITH CHECK ADD  CONSTRAINT [FK_ReviewXComments_Reviews_ReviewId] FOREIGN KEY([ReviewId])
REFERENCES [dbo].[Reviews] ([Id])
GO
ALTER TABLE [dbo].[ReviewXComments] CHECK CONSTRAINT [FK_ReviewXComments_Reviews_ReviewId]
GO
ALTER TABLE [dbo].[SecondCategories]  WITH CHECK ADD  CONSTRAINT [FK_SecondCategories_FirstCategories_FirstCategoryId] FOREIGN KEY([FirstCategoryId])
REFERENCES [dbo].[FirstCategories] ([Id])
GO
ALTER TABLE [dbo].[SecondCategories] CHECK CONSTRAINT [FK_SecondCategories_FirstCategories_FirstCategoryId]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_FirstCategories_FirstCategoryId] FOREIGN KEY([FirstCategoryId])
REFERENCES [dbo].[FirstCategories] ([Id])
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_FirstCategories_FirstCategoryId]
GO
ALTER TABLE [dbo].[States]  WITH CHECK ADD  CONSTRAINT [FK_States_Countries_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[States] CHECK CONSTRAINT [FK_States_Countries_CountryId]
GO
ALTER TABLE [dbo].[ThirdCategories]  WITH CHECK ADD  CONSTRAINT [FK_ThirdCategories_FirstCategories_FirstCategoryId] FOREIGN KEY([FirstCategoryId])
REFERENCES [dbo].[FirstCategories] ([Id])
GO
ALTER TABLE [dbo].[ThirdCategories] CHECK CONSTRAINT [FK_ThirdCategories_FirstCategories_FirstCategoryId]
GO
ALTER TABLE [dbo].[ThirdCategories]  WITH CHECK ADD  CONSTRAINT [FK_ThirdCategories_SecondCategories_SecondCategoryId] FOREIGN KEY([SecondCategoryId])
REFERENCES [dbo].[SecondCategories] ([Id])
GO
ALTER TABLE [dbo].[ThirdCategories] CHECK CONSTRAINT [FK_ThirdCategories_SecondCategories_SecondCategoryId]
GO
