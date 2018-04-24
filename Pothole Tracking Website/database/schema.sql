USE [master]
GO
/****** Object:  Database [Potholes]    Script Date: 4/19/2018 8:03:38 PM ******/
CREATE DATABASE [Potholes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Potholes', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Potholes.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Potholes_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Potholes_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Potholes] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Potholes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Potholes] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Potholes] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Potholes] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Potholes] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Potholes] SET ARITHABORT OFF 
GO
ALTER DATABASE [Potholes] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Potholes] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Potholes] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Potholes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Potholes] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Potholes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Potholes] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Potholes] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Potholes] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Potholes] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Potholes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Potholes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Potholes] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Potholes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Potholes] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Potholes] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Potholes] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Potholes] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Potholes] SET  MULTI_USER 
GO
ALTER DATABASE [Potholes] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Potholes] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Potholes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Potholes] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Potholes] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Potholes] SET QUERY_STORE = OFF
GO
USE [Potholes]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Potholes]
GO
/****** Object:  Table [dbo].[Claims]    Script Date: 4/19/2018 8:03:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Claims](
	[User_ID] [int] NOT NULL,
	[Claims_ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[Estimated_Cost] [decimal](18, 0) NOT NULL,
	[Submission_Date] [date] NOT NULL,
	[Status] [varchar](50) NULL,
	[PotHole_ID] [int] NOT NULL,
 CONSTRAINT [PK_Claims] PRIMARY KEY CLUSTERED 
(
	[Claims_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pothole]    Script Date: 4/19/2018 8:03:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pothole](
	[PotHole_ID] [int] IDENTITY(1,1) NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[Severity] [int] NULL,
	[Date_Reported] [date] NOT NULL,
	[Picture] [image] NULL,
	[User_ID] [int] NULL,
	[Longitude] [decimal](18, 6) NOT NULL,
	[Latitude] [decimal](18, 6) NOT NULL,
	[Repair_Date] [date] NULL,
	[Inspect_Date] [date] NULL,
 CONSTRAINT [PK_Pothole] PRIMARY KEY CLUSTERED 
(
	[PotHole_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/19/2018 8:03:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[User_ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Is_Employee] [bit] NOT NULL,
	[Email] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Claims]  WITH CHECK ADD  CONSTRAINT [FK_Claims_Users] FOREIGN KEY([PotHole_ID])
REFERENCES [dbo].[Pothole] ([PotHole_ID])
GO
ALTER TABLE [dbo].[Claims] CHECK CONSTRAINT [FK_Claims_Users]
GO
USE [master]
GO
ALTER DATABASE [Potholes] SET  READ_WRITE 
GO
