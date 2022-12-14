USE [master]
GO
/****** Object:  Database [#fundMe]    Script Date: 2019/10/16 16:52:36 ******/
CREATE DATABASE [#fundMe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'#fundMe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\#fundMe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'#fundMe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\#fundMe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [#fundMe] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [#fundMe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [#fundMe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [#fundMe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [#fundMe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [#fundMe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [#fundMe] SET ARITHABORT OFF 
GO
ALTER DATABASE [#fundMe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [#fundMe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [#fundMe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [#fundMe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [#fundMe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [#fundMe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [#fundMe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [#fundMe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [#fundMe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [#fundMe] SET  DISABLE_BROKER 
GO
ALTER DATABASE [#fundMe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [#fundMe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [#fundMe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [#fundMe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [#fundMe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [#fundMe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [#fundMe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [#fundMe] SET RECOVERY FULL 
GO
ALTER DATABASE [#fundMe] SET  MULTI_USER 
GO
ALTER DATABASE [#fundMe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [#fundMe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [#fundMe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [#fundMe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [#fundMe] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'#fundMe', N'ON'
GO
ALTER DATABASE [#fundMe] SET QUERY_STORE = OFF
GO
USE [#fundMe]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 2019/10/16 16:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[admin_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[admin_firstName] [char](20) NOT NULL,
	[admin_lastName] [char](20) NOT NULL,
	[admin_cell] [char](15) NOT NULL,
	[admin_email] [char](50) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[admin_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Applicant]    Script Date: 2019/10/16 16:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applicant](
	[applicant_IDno] [char](13) NOT NULL,
	[admin_id] [bigint] NULL,
	[applicant_firstName] [char](20) NOT NULL,
	[applicant_lastName] [char](20) NOT NULL,
	[applicant_dob] [char](20) NOT NULL,
	[applicant_cell] [char](15) NOT NULL,
	[applicant_email] [char](50) NOT NULL,
	[applicant_addressLine1] [char](50) NOT NULL,
	[applicant_addressLine2] [char](50) NULL,
	[applicant_postalCode] [char](10) NOT NULL,
	[applicant_university] [char](50) NOT NULL,
	[applicant_degree] [char](30) NOT NULL,
	[applicant_studentNo] [char](15) NOT NULL,
	[applicant_status] [char](10) NOT NULL,
	[applicant_creationDate] [date] NOT NULL,
	[applicant_city] [char](20) NOT NULL,
 CONSTRAINT [PK_Applicant] PRIMARY KEY CLUSTERED 
(
	[applicant_IDno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Application]    Script Date: 2019/10/16 16:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Application](
	[application_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[applicant_IDNo] [char](13) NOT NULL,
	[admin_ID] [bigint] NOT NULL,
	[application_fundType] [char](30) NOT NULL,
	[application_requiredAmount] [decimal](18, 0) NOT NULL,
	[application_date] [date] NOT NULL,
	[application_status] [char](16) NOT NULL,
	[application_fundedAmount] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[application_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donation]    Script Date: 2019/10/16 16:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donation](
	[donation_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[application_ID] [bigint] NOT NULL,
	[donor_ID] [bigint] NOT NULL,
	[admin_ID] [bigint] NOT NULL,
	[donation_amount] [decimal](18, 0) NOT NULL,
	[donation_date] [date] NOT NULL,
 CONSTRAINT [PK_Donation] PRIMARY KEY CLUSTERED 
(
	[donation_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donor]    Script Date: 2019/10/16 16:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donor](
	[donor_firstName] [char](20) NOT NULL,
	[donor_lastName] [char](20) NOT NULL,
	[donor_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[admin_ID] [bigint] NOT NULL,
	[donor_orgType] [char](50) NOT NULL,
	[donor_phone] [char](15) NOT NULL,
	[donor_email] [char](50) NOT NULL,
	[donor_addressLine1] [char](50) NOT NULL,
	[donor_addressLine2] [char](50) NULL,
	[donor_postalCode] [char](10) NOT NULL,
	[donor_city] [char](20) NOT NULL,
	[donor_maxAmount] [decimal](18, 0) NOT NULL,
	[donor_fundBalance] [decimal](18, 0) NOT NULL,
	[donor_organisation] [char](50) NULL,
 CONSTRAINT [PK_Donor] PRIMARY KEY CLUSTERED 
(
	[donor_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Applicant]  WITH CHECK ADD  CONSTRAINT [FK_Applicant_Applicant] FOREIGN KEY([admin_id])
REFERENCES [dbo].[Admin] ([admin_ID])
GO
ALTER TABLE [dbo].[Applicant] CHECK CONSTRAINT [FK_Applicant_Applicant]
GO
ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_Admin] FOREIGN KEY([admin_ID])
REFERENCES [dbo].[Admin] ([admin_ID])
GO
ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Application_Admin]
GO
ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_Applicant] FOREIGN KEY([applicant_IDNo])
REFERENCES [dbo].[Applicant] ([applicant_IDno])
GO
ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Application_Applicant]
GO
ALTER TABLE [dbo].[Donation]  WITH CHECK ADD  CONSTRAINT [FK_Donation_Admin] FOREIGN KEY([admin_ID])
REFERENCES [dbo].[Admin] ([admin_ID])
GO
ALTER TABLE [dbo].[Donation] CHECK CONSTRAINT [FK_Donation_Admin]
GO
ALTER TABLE [dbo].[Donation]  WITH CHECK ADD  CONSTRAINT [FK_Donation_Application] FOREIGN KEY([application_ID])
REFERENCES [dbo].[Application] ([application_ID])
GO
ALTER TABLE [dbo].[Donation] CHECK CONSTRAINT [FK_Donation_Application]
GO
ALTER TABLE [dbo].[Donation]  WITH CHECK ADD  CONSTRAINT [FK_Donation_Donor] FOREIGN KEY([donor_ID])
REFERENCES [dbo].[Donor] ([donor_ID])
GO
ALTER TABLE [dbo].[Donation] CHECK CONSTRAINT [FK_Donation_Donor]
GO
ALTER TABLE [dbo].[Donor]  WITH CHECK ADD  CONSTRAINT [FK_Donor_Donor] FOREIGN KEY([admin_ID])
REFERENCES [dbo].[Admin] ([admin_ID])
GO
ALTER TABLE [dbo].[Donor] CHECK CONSTRAINT [FK_Donor_Donor]
GO
/****** Object:  StoredProcedure [dbo].[CreateAdmin]    Script Date: 2019/10/16 16:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateAdmin] 
	@admin_ID bigint,
	@admin_firstName char(20),
	@admin_lastName char(20),
	@admin_cell char(15),
	@admin_email char(50)
AS
BEGIN
	INSERT INTO Admin(admin_ID, admin_firstName, admin_lastName, admin_cell, admin_email)
	values (@admin_ID, @admin_firstName, @admin_lastName, @admin_cell, @admin_email)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateAdmin2]    Script Date: 2019/10/16 16:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateAdmin2]
	@admin_firstName char(20),
	@admin_lastName char(20),
	@admin_cell char(15),
	@admin_email char(50)
AS
BEGIN
	INSERT INTO Admin( admin_firstName, admin_lastName, admin_cell, admin_email)
	values ( @admin_firstName, @admin_lastName, @admin_cell, @admin_email)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateApplicant]    Script Date: 2019/10/16 16:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateApplicant]
	@applicant_IDNo char(13),
	@admin_ID bigint,
    @applicant_firstName char(20),
    @applicant_lastName char(20),
    @applicant_dob char(20),
    @applicant_cell char(15),
    @applicant_email char(50),
    @applicant_addressLine1 char(50),
    @applicant_addressLine2 char(50),
    @applicant_postalCode char(10),
    @applicant_university char(50),
    @applicant_degree char(30),
    @applicant_studentNo char(15),
    @applicant_status char(10)
AS
BEGIN
	INSERT INTO Applicant(applicant_IDNo, admin_ID, applicant_firstName, applicant_lastName, applicant_dob, applicant_cell, applicant_email, applicant_addressLine1, applicant_addressLine2, applicant_postalCode, applicant_university, applicant_degree, applicant_studentNo, applicant_status)
	values (@applicant_IDNo, @admin_ID, @applicant_firstName, @applicant_lastName, @applicant_dob, @applicant_cell, @applicant_email, @applicant_addressLine1, @applicant_addressLine2, @applicant_postalCode, @applicant_university, @applicant_degree, @applicant_studentNo, @applicant_status)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateApplicant2]    Script Date: 2019/10/16 16:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateApplicant2]
	@applicant_IDNo char(13),
	@admin_ID bigint,
    @applicant_firstName char(20),
    @applicant_lastName char(20),
    @applicant_dob char(20),
    @applicant_cell char(15),
    @applicant_email char(50),
    @applicant_addressLine1 char(50),
    @applicant_addressLine2 char(50),
    @applicant_postalCode char(10),
    @applicant_university char(50),
    @applicant_degree char(30),
    @applicant_studentNo char(15),
    @applicant_status char(10),
	@applicant_creationDate date,
	@applicant_greenDate date,
	@applicant_city char(20)
AS
BEGIN
	INSERT INTO Applicant(applicant_IDNo, admin_ID, applicant_firstName, applicant_lastName, applicant_dob, applicant_cell, applicant_email, applicant_addressLine1, applicant_addressLine2, applicant_postalCode, applicant_university, applicant_degree, applicant_studentNo, applicant_status, applicant_creationDate, applicant_greenDate, applicant_city)
	values (@applicant_IDNo, @admin_ID, @applicant_firstName, @applicant_lastName, @applicant_dob, @applicant_cell, @applicant_email, @applicant_addressLine1, @applicant_addressLine2, @applicant_postalCode, @applicant_university, @applicant_degree, @applicant_studentNo, @applicant_status, @applicant_creationDate, @applicant_greenDate, @applicant_city)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateApplicant3]    Script Date: 2019/10/16 16:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateApplicant3] 
	@applicant_IDNo char(13),
	@admin_ID bigint,
    @applicant_firstName char(20),
    @applicant_lastName char(20),
    @applicant_dob char(20),
    @applicant_cell char(15),
    @applicant_email char(50),
    @applicant_addressLine1 char(50),
    @applicant_addressLine2 char(50),
    @applicant_postalCode char(10),
    @applicant_university char(50),
    @applicant_degree char(30),
    @applicant_studentNo char(15),
    @applicant_status char(10),
	@applicant_creationDate date,
	@applicant_city char(20)
AS
BEGIN
	INSERT INTO Applicant(applicant_IDNo, admin_ID, applicant_firstName, applicant_lastName, applicant_dob, applicant_cell, applicant_email, applicant_addressLine1, applicant_addressLine2, applicant_postalCode, applicant_university, applicant_degree, applicant_studentNo, applicant_status, applicant_creationDate, applicant_city)
	values (@applicant_IDNo, @admin_ID, @applicant_firstName, @applicant_lastName, @applicant_dob, @applicant_cell, @applicant_email, @applicant_addressLine1, @applicant_addressLine2, @applicant_postalCode, @applicant_university, @applicant_degree, @applicant_studentNo, @applicant_status, @applicant_creationDate, @applicant_city)
END
GO
/****** Object:  StoredProcedure [dbo].[createApplication]    Script Date: 2019/10/16 16:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[createApplication]
	@applicant_IDno char(13),
	@admin_ID int,
	@application_fundType char(30),
	@application_requiredAmount decimal(18,0),
	@application_date date

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	INSERT INTO Application(applicant_IDNo,admin_ID,application_fundType,application_requiredAmount,application_date)
	values (@applicant_IDno,@admin_ID,@application_fundType,@application_requiredAmount,@application_date)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateApplication2]    Script Date: 2019/10/16 16:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateApplication2]
	@applicant_IDno char(13),
	@admin_ID int,
	@application_fundType char(30),
	@application_requiredAmount decimal(18,0),
	@application_date date,
	@application_status char(16),
	@application_fundedAmount decimal(18,0)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	INSERT INTO Application(applicant_IDNo,admin_ID,application_fundType,application_requiredAmount,application_date, application_status,
	application_fundedAmount)
	values (@applicant_IDno,@admin_ID,@application_fundType,@application_requiredAmount,@application_date, @application_status,
	@application_fundedAmount)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateDonation]    Script Date: 2019/10/16 16:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateDonation]
	@donation_ID bigint,
	@application_ID bigint,
	@donor_ID bigint,
	@admin_ID bigint,
	@donation_amount decimal(18, 0),
	@donation_date date
AS
BEGIN
	INSERT INTO Donation(donation_ID, application_ID, donor_ID, admin_ID, donation_amount, donation_date)
	values (@donation_ID, @application_ID, @donor_ID, @admin_ID, @donation_amount, @donation_date)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateDonation2]    Script Date: 2019/10/16 16:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateDonation2]
	@application_ID bigint,
	@donor_ID bigint,
	@admin_ID bigint,
	@donation_amount decimal(18, 0),
	@donation_date date
AS
BEGIN
	INSERT INTO Donation(application_ID, donor_ID, admin_ID, donation_amount, donation_date)
	values (@application_ID, @donor_ID, @admin_ID, @donation_amount, @donation_date)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateDonor]    Script Date: 2019/10/16 16:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateDonor]
	-- Add the parameters for the stored procedure here
	@admin_ID bigint,
	@donor_firstName char(20),
	@donor_lastName char(20),
	@donor_orgType char(50),
	@donor_phone char(15),
	@donor_email char(50),
	@donor_addressLine1 char(50),
	@donor_addressLine2 char(50),
	@donor_postalCode char(10),
	@donor_city char(20),
	@donor_maxAmount decimal(18),
	@donor_fundBalance decimal(18)
AS
BEGIN
	INSERT INTO Donor (admin_ID, donor_firstName, donor_lastName, donor_orgType, donor_phone, donor_email, donor_addressLine1, donor_addressLine2, donor_postalCode, donor_city, donor_maxAmount, donor_fundBalance)
	values (@admin_ID, @donor_firstName, @donor_lastName, @donor_orgType, @donor_phone, @donor_email, @donor_addressLine1, @donor_addressLine2, @donor_postalCode, @donor_city, @donor_maxAmount, @donor_fundBalance)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateDonor2]    Script Date: 2019/10/16 16:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateDonor2]
	-- Add the parameters for the stored procedure here
	@admin_ID bigint,
	@donor_firstName char(20),
	@donor_lastName char(20),
	@donor_orgType char(50),
	@donor_phone char(15),
	@donor_email char(50),
	@donor_addressLine1 char(50),
	@donor_addressLine2 char(50),
	@donor_postalCode char(10),
	@donor_city char(20),
	@donor_maxAmount decimal(18),
	@donor_fundBalance decimal(18), 
	@donor_organisation char(50)
AS
BEGIN
	INSERT INTO Donor (admin_ID, donor_firstName, donor_lastName, donor_orgType, donor_phone, donor_email, donor_addressLine1, donor_addressLine2, donor_postalCode, donor_city, donor_maxAmount, donor_fundBalance, donor_organisation)
	values (@admin_ID, @donor_firstName, @donor_lastName, @donor_orgType, @donor_phone, @donor_email, @donor_addressLine1, @donor_addressLine2, @donor_postalCode, @donor_city, @donor_maxAmount, @donor_fundBalance, @donor_organisation)
END
GO
USE [master]
GO
ALTER DATABASE [#fundMe] SET  READ_WRITE 
GO
