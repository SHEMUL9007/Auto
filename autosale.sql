USE [master]
GO
/****** Object:  Database [Autosale]    Script Date: 9/10/2019 4:44:06 PM ******/
CREATE DATABASE [Autosale]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Auto sale', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Auto sale.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Auto sale_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Auto sale_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Autosale] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Autosale].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Autosale] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Autosale] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Autosale] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Autosale] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Autosale] SET ARITHABORT OFF 
GO
ALTER DATABASE [Autosale] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Autosale] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Autosale] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Autosale] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Autosale] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Autosale] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Autosale] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Autosale] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Autosale] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Autosale] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Autosale] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Autosale] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Autosale] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Autosale] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Autosale] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Autosale] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Autosale] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Autosale] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Autosale] SET  MULTI_USER 
GO
ALTER DATABASE [Autosale] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Autosale] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Autosale] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Autosale] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Autosale] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Autosale] SET QUERY_STORE = OFF
GO
USE [Autosale]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoriesID] [int] IDENTITY(1,1) NOT NULL,
	[Categories] [nvarchar](70) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoriesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogTrace]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogTrace](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](80) NULL,
	[Trace] [nvarchar](max) NULL,
	[Time] [datetime2](7) NULL,
 CONSTRAINT [PK_LogRrace] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Offer]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offer](
	[OfferID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[BuyerID] [int] NOT NULL,
	[OfferPrice] [decimal](18, 2) NULL,
	[Offerstate] [int] NULL,
	[ExpireDate] [datetime] NULL,
	[Comments] [nvarchar](max) NULL,
 CONSTRAINT [PK_Offer] PRIMARY KEY CLUSTERED 
(
	[OfferID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductsID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[SellerID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[ReservePrice] [decimal](18, 2) NULL,
	[WinningOfferID] [int] NULL,
	[Comments] [nvarchar](max) NULL,
	[photos] [nvarchar](max) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[EmailAdderess] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Password] [nvarchar](150) NULL,
	[Hash] [nvarchar](150) NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoriesID], [Categories]) VALUES (1, N'Toyota')
INSERT [dbo].[Categories] ([CategoriesID], [Categories]) VALUES (2, N'Nissan')
INSERT [dbo].[Categories] ([CategoriesID], [Categories]) VALUES (3, N'Mazda')
INSERT [dbo].[Categories] ([CategoriesID], [Categories]) VALUES (4, N'Ford')
INSERT [dbo].[Categories] ([CategoriesID], [Categories]) VALUES (5, N'Mistubesi')
INSERT [dbo].[Categories] ([CategoriesID], [Categories]) VALUES (6, N'Corvette')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Offer] ON 

INSERT [dbo].[Offer] ([OfferID], [ProductID], [BuyerID], [OfferPrice], [Offerstate], [ExpireDate], [Comments]) VALUES (1, 1, 1, CAST(1500.00 AS Decimal(18, 2)), 25, CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'ok')
INSERT [dbo].[Offer] ([OfferID], [ProductID], [BuyerID], [OfferPrice], [Offerstate], [ExpireDate], [Comments]) VALUES (2, 1, 1, CAST(1450.00 AS Decimal(18, 2)), 23, CAST(N'2019-09-08T00:00:00.000' AS DateTime), N'good')
INSERT [dbo].[Offer] ([OfferID], [ProductID], [BuyerID], [OfferPrice], [Offerstate], [ExpireDate], [Comments]) VALUES (3, 2, 1, CAST(1200.00 AS Decimal(18, 2)), 25, CAST(N'2019-10-08T00:00:00.000' AS DateTime), N'vvp')
INSERT [dbo].[Offer] ([OfferID], [ProductID], [BuyerID], [OfferPrice], [Offerstate], [ExpireDate], [Comments]) VALUES (6, 3, 3, CAST(1425.00 AS Decimal(18, 2)), 20, CAST(N'2019-10-28T00:00:00.000' AS DateTime), N'ivp')
INSERT [dbo].[Offer] ([OfferID], [ProductID], [BuyerID], [OfferPrice], [Offerstate], [ExpireDate], [Comments]) VALUES (7, 3, 3, CAST(2300.00 AS Decimal(18, 2)), 23, CAST(N'2019-11-11T00:00:00.000' AS DateTime), N'op')
INSERT [dbo].[Offer] ([OfferID], [ProductID], [BuyerID], [OfferPrice], [Offerstate], [ExpireDate], [Comments]) VALUES (8, 2, 1, CAST(0.00 AS Decimal(18, 2)), 0, CAST(N'2009-01-01T00:00:00.000' AS DateTime), N'666')
SET IDENTITY_INSERT [dbo].[Offer] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductsID], [CategoryID], [SellerID], [Name], [Description], [ReservePrice], [WinningOfferID], [Comments], [photos]) VALUES (1, 1, 1, N'Toyota red', N'four doors', CAST(3500.00 AS Decimal(18, 2)), NULL, N'gt', NULL)
INSERT [dbo].[Products] ([ProductsID], [CategoryID], [SellerID], [Name], [Description], [ReservePrice], [WinningOfferID], [Comments], [photos]) VALUES (2, 2, 2, N'Nissan', N'two doors', CAST(2400.00 AS Decimal(18, 2)), 0, N'ko', N'xxx')
INSERT [dbo].[Products] ([ProductsID], [CategoryID], [SellerID], [Name], [Description], [ReservePrice], [WinningOfferID], [Comments], [photos]) VALUES (3, 3, 3, N'Mazda', N'suv', CAST(4000.00 AS Decimal(18, 2)), 0, N'okish', N'')
INSERT [dbo].[Products] ([ProductsID], [CategoryID], [SellerID], [Name], [Description], [ReservePrice], [WinningOfferID], [Comments], [photos]) VALUES (5, 4, 3, N'Mazda', N'suv', CAST(4000.00 AS Decimal(18, 2)), 0, N'okish', N'')
INSERT [dbo].[Products] ([ProductsID], [CategoryID], [SellerID], [Name], [Description], [ReservePrice], [WinningOfferID], [Comments], [photos]) VALUES (6, 5, 5, N'Ford', N'crownvic', CAST(1000.00 AS Decimal(18, 2)), 0, N'goodish', N'')
INSERT [dbo].[Products] ([ProductsID], [CategoryID], [SellerID], [Name], [Description], [ReservePrice], [WinningOfferID], [Comments], [photos]) VALUES (11, 3, 1, N'israt', N'xxx', CAST(500.00 AS Decimal(18, 2)), 0, N'ok', N'xxx')
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [Role]) VALUES (1, N'Administrator')
INSERT [dbo].[Roles] ([RoleID], [Role]) VALUES (2, N'User')
INSERT [dbo].[Roles] ([RoleID], [Role]) VALUES (3, N'Dealer')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [EmailAdderess], [Name], [Password], [Hash], [RoleID]) VALUES (1, N'zafor@gmail.com', N'zafor', N'zafor', N'123456', 1)
INSERT [dbo].[Users] ([UserID], [EmailAdderess], [Name], [Password], [Hash], [RoleID]) VALUES (2, N'ikbal@yahoo.com', N'ikbal', N'ikbal1', N'654321', 1)
INSERT [dbo].[Users] ([UserID], [EmailAdderess], [Name], [Password], [Hash], [RoleID]) VALUES (3, N'mahammad@hotmail.com', N'mahammad', N'mahammad3', N'123456', 3)
INSERT [dbo].[Users] ([UserID], [EmailAdderess], [Name], [Password], [Hash], [RoleID]) VALUES (5, N'israt@yahoo.com', N'israt', N'israt4', N'654321', 2)
INSERT [dbo].[Users] ([UserID], [EmailAdderess], [Name], [Password], [Hash], [RoleID]) VALUES (6, N'parven@hotmail.com', N'parven', N'parven5', N'123456', 2)
INSERT [dbo].[Users] ([UserID], [EmailAdderess], [Name], [Password], [Hash], [RoleID]) VALUES (7, N'ishan@hotmail.com', N'ishan', N'ishan6', N'654321', 3)
INSERT [dbo].[Users] ([UserID], [EmailAdderess], [Name], [Password], [Hash], [RoleID]) VALUES (11, N'intaj@gmail.com', N'intaj', N'intaj8', N'123456', 3)
INSERT [dbo].[Users] ([UserID], [EmailAdderess], [Name], [Password], [Hash], [RoleID]) VALUES (12, N'sohana@gmail.com', N'sohana', N'sohana7', N'654321', 1)
INSERT [dbo].[Users] ([UserID], [EmailAdderess], [Name], [Password], [Hash], [RoleID]) VALUES (13, N'abdul@gmail.com', N'abdul', N'abdul9', N'123456', 2)
INSERT [dbo].[Users] ([UserID], [EmailAdderess], [Name], [Password], [Hash], [RoleID]) VALUES (23, N'ma@gmail.com', N'ma', N'Dearsdp1', N'AEDGMSEbcqKQb3MIOceUHL8FS9kMXspTwZ7LFqxt0mwQmc/bHU', 3)
INSERT [dbo].[Users] ([UserID], [EmailAdderess], [Name], [Password], [Hash], [RoleID]) VALUES (24, N'jkp@gmail.com', N'jkp', N'Hell0Jerry', N'AAFTk5r3QxwuUVQITLMXG6VuuRUxdz0ebMsIDV2AsiYi/PwoTV', 2)
INSERT [dbo].[Users] ([UserID], [EmailAdderess], [Name], [Password], [Hash], [RoleID]) VALUES (27, N'a@a.com', N'a', N'abcDEF123', N'ADAwF0JGe9PoPy5NvMDmHu1dG1Trx1qzm8I386Hzo5/7UxbfbnKOxYEYDf+d/tULjg==', 3)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Offer]  WITH CHECK ADD  CONSTRAINT [FK_Offer_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductsID])
GO
ALTER TABLE [dbo].[Offer] CHECK CONSTRAINT [FK_Offer_Products]
GO
ALTER TABLE [dbo].[Offer]  WITH CHECK ADD  CONSTRAINT [FK_Offer_Users] FOREIGN KEY([BuyerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Offer] CHECK CONSTRAINT [FK_Offer_Users]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoriesID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Users] FOREIGN KEY([SellerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
/****** Object:  StoredProcedure [dbo].[createCategoris]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[createCategoris]

@CategorisID int output,
@Categoris nvarchar (70)
as
begin

insert into Categories (Categories)
values (@Categoris)
select @categorisID=@@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[createOffer]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[createOffer]
@OfferID int output, 
@ProductID int,
@BuyerID int,
@OfferPrice decimal(18,2),
@Offerstate int,
@Expire Datetime ,
@Comments nvarchar(max)

as

begin

insert into Offer(ProductID,BuyerID,OfferPrice,Offerstate,ExpireDate,Comments)

values (@ProductID,@BuyerID,@OfferPrice,@Offerstate,@Expire,@Comments);

select @offerID=@@IDENTITY

end
GO
/****** Object:  StoredProcedure [dbo].[createProducts]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[createProducts]
@ProductID int output,
@CategoryID int,
@SellerID int,
@Name nvarchar(50),
@Description nvarchar(Max),
@ReservePrice decimal(18,2),
@WinningOfferID int,
@Comments nvarchar(max),
@Photos nvarchar(max)

as

begin

insert into Products(CategoryID,SellerID,Name,Description,ReservePrice,WinningOfferID,Comments,Photos)

values (@CategoryID,@SellerID,@Name,@Description,@ReservePrice,@WinningOfferID,@Comments,@Photos);

select @ProductID =@@IDENTITY

end
GO
/****** Object:  StoredProcedure [dbo].[createRole]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[createRole]
@roleid int output,
@Role nvarchar(50)
as
begin

insert into roles (Role) values (@Role)
select @roleid = @@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[createUser]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[createUser]
@UserID int output,
@Email nvarchar(50),
@Name nvarchar(50),
@password nvarchar(150),
@Hash nvarchar(150),
@roleID int
as
begin

insert into Users (EmailAdderess,Name,password,Hash,roleID)
values (@Email,@Name,@password,@hash,@roleID)
select @userid = @@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteCategorie]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[DeleteCategorie]
@CategoriesID int 

as
begin 
delete from products where CategoryID = @CategoriesID
delete from Categories where  CategoriesID = @CategoriesID

END
GO
/****** Object:  StoredProcedure [dbo].[DeleteOffer]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[DeleteOffer]
@OfferID int 

as
begin 
delete from Offer where  OfferID = @OfferID

END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[DeleteProduct]
@ProductsID int 

as
begin 
delete from Products where  ProductsID = @ProductsID

END
GO
/****** Object:  StoredProcedure [dbo].[DeleteRole]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[DeleteRole]
@RoleID int 

as
begin 
delete from Roles where  RoleID = @RoleID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[DeleteUser]
@UserID int 

as
begin 
delete from Users where UserID = @UserID
END
GO
/****** Object:  StoredProcedure [dbo].[FindCategoryByID]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[FindCategoryByID]
	@CategoryID int
AS
BEGIN

	Select CategoriesID, Categories from Categories where CategoriesID = @CategoryID
END

GO
/****** Object:  StoredProcedure [dbo].[FindOfferByID]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[FindOfferByID]
	@OfferID int
AS
BEGIN
	SET NOCOUNT ON;

	Select OfferID, Offer.ProductID, BuyerID, OfferPrice, Offerstate, ExpireDate, Offer.Comments,
	     Products.Name as ProductName,
		 Users.Name as BuyerName, Users.EmailAdderess
	     from offer
		 inner join Users on Users.UserID = Offer.BuyerID
		 inner join Products on Products.ProductsID = Offer.ProductID
		 where OfferID = @OfferID
END

GO
/****** Object:  StoredProcedure [dbo].[FindProductByID]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FindProductByID]
	@ProductID int
AS
BEGIN

	Select ProductsID, Products.CategoryID, SellerID, Products.Name as ProductName,Description, ReservePrice, WinningOfferID, Comments,
	    Categories,Photos,
		EmailAdderess as SellerEMail, Users.Name as SellerName
		
		from Products 
	inner join Users on users.UserID = SellerID
	inner join Categories on Products.CategoryID = Categories.CategoriesID
	where ProductsID = @ProductID
END

GO
/****** Object:  StoredProcedure [dbo].[FindRoleByID]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[FindRoleByID]
	@RoleID int
AS
BEGIN
	Select RoleID, Role from Roles where RoleID = @RoleID
END

GO
/****** Object:  StoredProcedure [dbo].[findUserbyEmail]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[findUserbyEmail]
@Email nvarchar (50)

as
begin
select Users.UserID,users.EmailAdderess,users.Name,users.Password,users.Hash,users.RoleID,Roles.Role
From Users
inner join Roles on users.RoleID=Roles.RoleID
where EmailAdderess =@Email
end
GO
/****** Object:  StoredProcedure [dbo].[findUserbyID]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[findUserbyID]
@ID int

as
begin
select Users.UserID,users.EmailAdderess,users.Name,users.Password,users.Hash,users.RoleID,Roles.Role
From Users
inner join Roles on users.RoleID=Roles.RoleID
where UserID =@ID
end
GO
/****** Object:  StoredProcedure [dbo].[GetCategories]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetCategories]

   @skip int,
   @take int

AS
BEGIN


	select Categories.CategoriesID, Categories from Categories 
	order by categories 
	offset @skip rows 
fetch next  @take rows only
end

GO
/****** Object:  StoredProcedure [dbo].[GetOffers]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetOffers]

   @skip int,
   @take int

AS
BEGIN
	SET NOCOUNT ON;

	Select OfferID, Offer.ProductID, BuyerID, OfferPrice, Offerstate, ExpireDate, Offer.Comments,
	     Products.Name ProductName,
		 Users.Name BuyerName, Users.EmailAdderess
	     from offer
		 inner join Users on Users.UserID = Offer.BuyerID
		 inner join Products on Products.ProductsID = Offer.ProductID
	order by OfferID OFFSET @skip rows fetch next @take rows only
end
GO
/****** Object:  StoredProcedure [dbo].[GetProducts]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProducts]

   @skip int,
   @take int

AS
BEGIN
	SET NOCOUNT ON;

	Select ProductsID, Products.CategoryID, SellerID, Products.Name as ProductName,Description, ReservePrice, WinningOfferID, Comments,
	    Categories,Photos,
		EmailAdderess as SellerEMail, Users.Name as SellerName
		
		from Products 
	inner join Users on users.UserID = SellerID
	inner join Categories on Products.CategoryID = Categories.CategoriesID
	order by ProductName, ProductsID OFFSET @skip rows fetch next @take rows only;
end

GO
/****** Object:  StoredProcedure [dbo].[GetRoles]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetRoles]

   @skip int,
   @take int

AS
BEGIN
	SET NOCOUNT ON;

	select RoleID, Role from Roles order by Role OFFSET @skip rows fetch next @take rows only;
end

GO
/****** Object:  StoredProcedure [dbo].[getUsers]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getUsers]
@skip int,
@take int
as
begin
select Users.UserID,users.EmailAdderess,users.Name,users.Password,users.Hash,users.RoleID,Roles.Role
From Users
inner join Roles on users.RoleID=Roles.RoleID
order by UserID
offset @skip rows 
fetch next  @take rows only

end
GO
/****** Object:  StoredProcedure [dbo].[insertLogItem]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[insertLogItem]

@message nvarchar(80),
@Trace nvarchar(Max)


As
Begin
Insert into [dbo].[LogTrace]
([Message],[Trace],[Time])
Values
(@message,@Trace,Getdate())

End
GO
/****** Object:  StoredProcedure [dbo].[obtainCategoriecount]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[obtainCategoriecount]


AS
BEGIN

select COUNT(*) from Categories

end
GO
/****** Object:  StoredProcedure [dbo].[obtainOffercount]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[obtainOffercount]


AS
BEGIN

select COUNT(*) from Offer

end
GO
/****** Object:  StoredProcedure [dbo].[obtainProductcount]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[obtainProductcount]


AS
BEGIN

select COUNT(*) from Products

end
GO
/****** Object:  StoredProcedure [dbo].[obtainrolecount]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[obtainrolecount]


AS
BEGIN

select COUNT(*) from Roles

end
GO
/****** Object:  StoredProcedure [dbo].[obtainusercount]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[obtainusercount]


AS
BEGIN

select COUNT(*) from Users

end
GO
/****** Object:  StoredProcedure [dbo].[reload]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[reload]


as
begin
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoriesID], [Categories]) VALUES (1, N'Toyota')
INSERT [dbo].[Categories] ([CategoriesID], [Categories]) VALUES (2, N'Nissan')
INSERT [dbo].[Categories] ([CategoriesID], [Categories]) VALUES (3, N'Mazda')
INSERT [dbo].[Categories] ([CategoriesID], [Categories]) VALUES (4, N'Ford')
INSERT [dbo].[Categories] ([CategoriesID], [Categories]) VALUES (5, N'Mistubesi')
SET IDENTITY_INSERT [dbo].[Categories] OFF

SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [Role]) VALUES (1, N'Administrator')
INSERT [dbo].[Roles] ([RoleID], [Role]) VALUES (2, N'User')
INSERT [dbo].[Roles] ([RoleID], [Role]) VALUES (3, N'Dealer')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [EmailAdderess], [Name], [Password], [Hash], [RoleID]) VALUES (1, N'zafor@gmail.com', N'zafor', N'zafor', N'123456', 1)
INSERT [dbo].[Users] ([UserID], [EmailAdderess], [Name], [Password], [Hash], [RoleID]) VALUES (2, N'ikbal@yahoo.com', N'ikbal', N'ikbal1', N'654321', 1)
INSERT [dbo].[Users] ([UserID], [EmailAdderess], [Name], [Password], [Hash], [RoleID]) VALUES (3, N'mahammad@hotmail.com', N'mahammad', N'mahammad3', N'123456', 3)
INSERT [dbo].[Users] ([UserID], [EmailAdderess], [Name], [Password], [Hash], [RoleID]) VALUES (5, N'israt@yahoo.com', N'israt', N'israt4', N'654321', 2)
INSERT [dbo].[Users] ([UserID], [EmailAdderess], [Name], [Password], [Hash], [RoleID]) VALUES (6, N'parven@hotmail.com', N'parven', N'parven5', N'123456', 2)
INSERT [dbo].[Users] ([UserID], [EmailAdderess], [Name], [Password], [Hash], [RoleID]) VALUES (7, N'ishan@hotmail.com', N'ishan', N'ishan6', N'654321', 3)
INSERT [dbo].[Users] ([UserID], [EmailAdderess], [Name], [Password], [Hash], [RoleID]) VALUES (11, N'intaj@gmail.com', N'intaj', N'intaj8', N'123456', 3)
INSERT [dbo].[Users] ([UserID], [EmailAdderess], [Name], [Password], [Hash], [RoleID]) VALUES (12, N'sohana@gmail.com', N'sohana', N'sohana7', N'654321', 1)
INSERT [dbo].[Users] ([UserID], [EmailAdderess], [Name], [Password], [Hash], [RoleID]) VALUES (13, N'abdul@gmail.com', N'abdul', N'abdul9', N'123456', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF

SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductsID], [CategoryID], [SellerID], [Name], [Description], [ReservePrice], [WinningOfferID], [Comments], [Photos]) VALUES (1, 1, 1, N'Toyota red', N'four doors', CAST(3500.00 AS Decimal(18, 2)), NULL, N'gt', NULL)
INSERT [dbo].[Products] ([ProductsID], [CategoryID], [SellerID], [Name], [Description], [ReservePrice], [WinningOfferID], [Comments], [Photos]) VALUES (2, 2, 2, N'Nissan', N'two doors', CAST(2400.00 AS Decimal(18, 2)), NULL, N'ko', NULL)
INSERT [dbo].[Products] ([ProductsID], [CategoryID], [SellerID], [Name], [Description], [ReservePrice], [WinningOfferID], [Comments], [Photos]) VALUES (3, 3, 3, N'Mazda', N'suv', CAST(4000.00 AS Decimal(18, 2)), NULL, N'ok', NULL)
INSERT [dbo].[Products] ([ProductsID], [CategoryID], [SellerID], [Name], [Description], [ReservePrice], [WinningOfferID], [Comments], [Photos]) VALUES (5, 4, 5, N'Ford', N'crownvic', CAST(1000.00 AS Decimal(18, 2)), NULL, N'good', NULL)
INSERT [dbo].[Products] ([ProductsID], [CategoryID], [SellerID], [Name], [Description], [ReservePrice], [WinningOfferID], [Comments], [Photos]) VALUES (6, 5, 5, N'Mistubesi', N'car', CAST(5812.00 AS Decimal(18, 2)), NULL, N'ok', NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Offer] ON 

INSERT [dbo].[Offer] ([OfferID], [ProductID], [BuyerID], [OfferPrice], [Offerstate], [ExpireDate], [Comments]) VALUES (1, 1, 32, CAST(1500.00 AS Decimal(18, 2)), 25, CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'ok')
INSERT [dbo].[Offer] ([OfferID], [ProductID], [BuyerID], [OfferPrice], [Offerstate], [ExpireDate], [Comments]) VALUES (2, 1, 30, CAST(1450.00 AS Decimal(18, 2)), 23, CAST(N'2019-09-08T00:00:00.000' AS DateTime), N'good')
INSERT [dbo].[Offer] ([OfferID], [ProductID], [BuyerID], [OfferPrice], [Offerstate], [ExpireDate], [Comments]) VALUES (3, 2, 1, CAST(1200.00 AS Decimal(18, 2)), 25, CAST(N'2019-10-08T00:00:00.000' AS DateTime), N'vvp')
INSERT [dbo].[Offer] ([OfferID], [ProductID], [BuyerID], [OfferPrice], [Offerstate], [ExpireDate], [Comments]) VALUES (6, 3, 21, CAST(1425.00 AS Decimal(18, 2)), 20, CAST(N'2019-10-28T00:00:00.000' AS DateTime), N'ivp')
INSERT [dbo].[Offer] ([OfferID], [ProductID], [BuyerID], [OfferPrice], [Offerstate], [ExpireDate], [Comments]) VALUES (7, 3, 58, CAST(2300.00 AS Decimal(18, 2)), 23, CAST(N'2019-11-11T00:00:00.000' AS DateTime), N'op')
SET IDENTITY_INSERT [dbo].[Offer] OFF
end
GO
/****** Object:  StoredProcedure [dbo].[ResetDatabase]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ResetDatabase]

AS
BEGIN
	
	delete from Offer;
	delete from products;
	delete from users;
	delete from categories;
	delete from roles;

	DBCC CHECKIDENT ('offer', RESEED, 0)  
    DBCC CHECKIDENT ('products', RESEED, 0)  
	DBCC CHECKIDENT ('users', RESEED, 0)  
	DBCC CHECKIDENT ('categories', RESEED, 0)  
	DBCC CHECKIDENT ('roles', RESEED, 0)  
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCategori]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[UpdateCategori]

@CategorisID int ,
@Categoris nvarchar (70)
as
begin

update Categories set Categories =@Categoris
where CategoriesID =@CategorisID

end
GO
/****** Object:  StoredProcedure [dbo].[updateOffer]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[updateOffer]
@OfferID int , 
@ProductID int,
@BuyerID int,
@OfferPrice decimal(18,2),
@Offerstate int,
@Expire Datetime ,
@Comments nvarchar(max)

as

begin

update Offer Set ProductID =@productID,BuyerID=@BuyerID,OfferPrice =@OfferPrice,Offerstate =@Offerstate,
ExpireDate =@Expire,Comments =@Comments

where OfferID =@OfferID
end
GO
/****** Object:  StoredProcedure [dbo].[updateProduct]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[updateProduct]
@ProductID int ,
@CategoryID int,
@SellerID int,
@Name nvarchar(50),
@Description nvarchar(Max),
@ReservePrice decimal(18,2),
@WinningOfferID int,
@Comments nvarchar(max),
@Photos nvarchar(max)

as

begin

update Products Set   SellerID =@SellerID,Name =@Name,Description =@Description,ReservePrice=@ReservePrice,
WinningOfferID=@WinningOfferID,Comments =@Comments,Photos =@Photos


where ProductsID =@ProductID
end
GO
/****** Object:  StoredProcedure [dbo].[updateRole]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[updateRole]
@roleid int,
@Role nvarchar(50)
as
begin

update roles set Role = @role
where roleID = @roleid
end
GO
/****** Object:  StoredProcedure [dbo].[updateUser]    Script Date: 9/10/2019 4:44:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[updateUser]
@UserID int,
@Email nvarchar(50),
@Name nvarchar(50),
@password nvarchar(150),
@Hash nvarchar(150),
@roleID int
as
begin

update Users set  EmailAdderess =@Email,Name =@Name,password =@password,Hash =@Hash,roleID=@roleID

where userID =@userID
end
GO
USE [master]
GO
ALTER DATABASE [Autosale] SET  READ_WRITE 
GO
