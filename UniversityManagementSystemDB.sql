USE [master]
GO
/****** Object:  Database [UniversityManagementSystemDB]    Script Date: 2/13/2018 10:30:39 PM ******/
CREATE DATABASE [UniversityManagementSystemDB] ON  PRIMARY 
( NAME = N'UniversityManagementSystemDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\UniversityManagementSystemDB.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniversityManagementSystemDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\UniversityManagementSystemDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniversityManagementSystemDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityManagementSystemDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityManagementSystemDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityManagementSystemDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityManagementSystemDB] SET DB_CHAINING OFF 
GO
USE [UniversityManagementSystemDB]
GO
/****** Object:  Table [dbo].[AllocateClassroom]    Script Date: 2/13/2018 10:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllocateClassroom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[DayId] [int] NOT NULL,
	[AllocateFromDate] [time](7) NULL,
	[AllocateToDate] [time](7) NULL,
	[IsActive] [int] NULL,
 CONSTRAINT [PK_AllocateClassroom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Course]    Script Date: 2/13/2018 10:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseCode] [varchar](50) NOT NULL,
	[CourseName] [varchar](50) NOT NULL,
	[Credit] [int] NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[SemesterId] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CourseAssignTeacher]    Script Date: 2/13/2018 10:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseAssignTeacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[IsActive] [int] NULL,
 CONSTRAINT [PK_CourseAssignTeacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Day]    Script Date: 2/13/2018 10:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Day](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DayName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Day] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 2/13/2018 10:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DeptCode] [varchar](50) NOT NULL,
	[DeptName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 2/13/2018 10:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DesignationName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EnrollCourse]    Script Date: 2/13/2018 10:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnrollCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentRegId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[EnrollDate] [datetime] NOT NULL,
	[IsActiveCourse] [int] NULL,
 CONSTRAINT [PK_EnrollCourse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Grade]    Script Date: 2/13/2018 10:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GradeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Grade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RollNumber]    Script Date: 2/13/2018 10:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RollNumber](
	[Id] [int] NOT NULL,
	[BBARoll] [int] NOT NULL,
	[CSERoll] [int] NOT NULL,
	[EEERoll] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_RollNumber] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room]    Script Date: 2/13/2018 10:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 2/13/2018 10:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semester](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SemesterName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentRegistration]    Script Date: 2/13/2018 10:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentRegistration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [varchar](50) NOT NULL,
	[StudentEmail] [varchar](50) NOT NULL,
	[StudentContactNo] [varchar](20) NOT NULL,
	[RegistrationDate] [date] NOT NULL,
	[StudentAddress] [varchar](100) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[StudentRegNo] [varchar](50) NOT NULL,
	[Roll] [int] NOT NULL,
 CONSTRAINT [PK_StudentRegistration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentResult]    Script Date: 2/13/2018 10:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentResult](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentRegId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[GradeId] [int] NOT NULL,
 CONSTRAINT [PK_StudentResult] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 2/13/2018 10:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [varchar](50) NOT NULL,
	[TeacherAddress] [varchar](100) NOT NULL,
	[TeacherEmail] [varchar](50) NOT NULL,
	[TeacherContactNo] [varchar](20) NOT NULL,
	[DesignationId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CreditToTaken] [int] NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/13/2018 10:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[ClassRoomScheduleViewModel]    Script Date: 2/13/2018 10:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create view [dbo].[ClassRoomScheduleViewModel]
as
select d.id as depId, d.DeptName, c.Id as CourseTableId, c.CourseCode, c.CourseName, c.DepartmentId, da.Id as dayTableId, 
da.DayName, r.Id as RoomTableId, r.RoomNo, ac.CourseId, ac.RoomId, ac.DayId, ac.AllocateFromDate, ac.AllocateToDate
From Department as d
left join Course as c on c.DepartmentId=d.Id
left join AllocateClassroom as ac on ac.CourseId=c.Id
left join Day as da on da.Id= ac.DayId
left join Room as r on r.Id= ac.RoomId
GO
/****** Object:  View [dbo].[CourseAssignTeacherViewModel]    Script Date: 2/13/2018 10:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CourseAssignTeacherViewModel]
AS
SELECT        d.Id, c.Id AS CrseId, c.CourseCode, c.CourseName, c.Credit, c.DepartmentId, c.SemesterId, t.Id AS teachId, t.TeacherName, s.Id AS semId, s.SemesterName, ca.CourseId, ca.TeacherId
FROM            dbo.Department AS d LEFT OUTER JOIN
                         dbo.Course AS c ON c.DepartmentId = d.Id LEFT OUTER JOIN
                         dbo.CourseAssignTeacher AS ca ON ca.CourseId = c.Id LEFT OUTER JOIN
                         dbo.Teacher AS t ON t.Id = ca.TeacherId LEFT OUTER JOIN
                         dbo.Semester AS s ON s.Id = c.SemesterId

GO
/****** Object:  View [dbo].[DepartmentCourseViewModel]    Script Date: 2/13/2018 10:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE View [dbo].[DepartmentCourseViewModel]
AS
SELECT StudentRegistration.Id, StudentRegistration.StudentRegNo, Department.DeptName, Department.DeptCode, Department.Id as DepartmentId, Course.Id as CourseId, 
Course.CourseCode, Course.CourseName
FROM StudentRegistration 
INNER JOIN Department On StudentRegistration.DepartmentId=Department.Id INNER JOIN Course On Course.DepartmentId = Department.Id
GO
/****** Object:  View [dbo].[EnrollCourseViewModel]    Script Date: 2/13/2018 10:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW 
[dbo].[EnrollCourseViewModel]
as
SELECT StudentRegistration.Id, StudentRegistration.StudentRegNo, StudentRegistration.StudentName, StudentRegistration.StudentEmail, Department.DeptName FROM StudentRegistration INNER JOIN Department On StudentRegistration.DepartmentId=Department.Id
GO
/****** Object:  View [dbo].[StudentCourseGradeViewModel]    Script Date: 2/13/2018 10:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StudentCourseGradeViewModel]
AS

SELECT StudentResult.Id, StudentResult.StudentRegId as StdRegId, Course.CourseCode, Course.CourseName, Course.Id as CourseId,Grade.Id as GradeId, Grade.GradeName 
FROM StudentResult INNER JOIN Course ON StudentResult.CourseId = Course.Id 
INNER JOIN Grade ON Grade.Id = StudentResult.GradeId





GO
/****** Object:  View [dbo].[StudentCourseViewModel]    Script Date: 2/13/2018 10:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW 
[dbo].[StudentCourseViewModel]
as
SELECT EnrollCourse.Id, EnrollCourse.StudentRegId, EnrollCourse.EnrollDate,Course.Id as CourseId, Course.CourseCode, Course.CourseName FROM EnrollCourse INNER JOIN Course On EnrollCourse.CourseId=Course.Id
GO
SET IDENTITY_INSERT [dbo].[AllocateClassroom] ON 

INSERT [dbo].[AllocateClassroom] ([Id], [CourseId], [RoomId], [DayId], [AllocateFromDate], [AllocateToDate], [IsActive]) VALUES (19, 1, 6, 3, CAST(0x0700A8E76F4B0000 AS Time), CAST(0x07007870335C0000 AS Time), 0)
INSERT [dbo].[AllocateClassroom] ([Id], [CourseId], [RoomId], [DayId], [AllocateFromDate], [AllocateToDate], [IsActive]) VALUES (22, 1, 4, 2, CAST(0x07003411995D0000 AS Time), CAST(0x0700587660670000 AS Time), 0)
INSERT [dbo].[AllocateClassroom] ([Id], [CourseId], [RoomId], [DayId], [AllocateFromDate], [AllocateToDate], [IsActive]) VALUES (23, 1, 1, 3, CAST(0x0700FC2092320000 AS Time), CAST(0x0700DC5527970000 AS Time), 0)
INSERT [dbo].[AllocateClassroom] ([Id], [CourseId], [RoomId], [DayId], [AllocateFromDate], [AllocateToDate], [IsActive]) VALUES (24, 1, 1, 1, CAST(0x0700FC2092320000 AS Time), CAST(0x0700DC5527970000 AS Time), 0)
INSERT [dbo].[AllocateClassroom] ([Id], [CourseId], [RoomId], [DayId], [AllocateFromDate], [AllocateToDate], [IsActive]) VALUES (25, 1, 1, 7, CAST(0x0700B6BA8C200000 AS Time), CAST(0x07002ECEA18E0000 AS Time), 0)
INSERT [dbo].[AllocateClassroom] ([Id], [CourseId], [RoomId], [DayId], [AllocateFromDate], [AllocateToDate], [IsActive]) VALUES (26, 10, 9, 5, CAST(0x0700B893419F0000 AS Time), CAST(0x0700881C05B00000 AS Time), 0)
INSERT [dbo].[AllocateClassroom] ([Id], [CourseId], [RoomId], [DayId], [AllocateFromDate], [AllocateToDate], [IsActive]) VALUES (27, 18, 8, 4, CAST(0x0700B0BD58750000 AS Time), CAST(0x0700E80A7E8E0000 AS Time), 0)
INSERT [dbo].[AllocateClassroom] ([Id], [CourseId], [RoomId], [DayId], [AllocateFromDate], [AllocateToDate], [IsActive]) VALUES (28, 21, 2, 2, CAST(0x070014D102450000 AS Time), CAST(0x0700F40598A90000 AS Time), 0)
INSERT [dbo].[AllocateClassroom] ([Id], [CourseId], [RoomId], [DayId], [AllocateFromDate], [AllocateToDate], [IsActive]) VALUES (29, 1, 1, 3, CAST(0x0700B20A87AC0000 AS Time), CAST(0x0700B20A87AC0000 AS Time), 0)
INSERT [dbo].[AllocateClassroom] ([Id], [CourseId], [RoomId], [DayId], [AllocateFromDate], [AllocateToDate], [IsActive]) VALUES (30, 1, 1, 7, CAST(0x0700B20A87AC0000 AS Time), CAST(0x0700B20A87AC0000 AS Time), 0)
INSERT [dbo].[AllocateClassroom] ([Id], [CourseId], [RoomId], [DayId], [AllocateFromDate], [AllocateToDate], [IsActive]) VALUES (31, 1, 1, 7, CAST(0x0700B20A87AC0000 AS Time), CAST(0x0700B20A87AC0000 AS Time), 0)
INSERT [dbo].[AllocateClassroom] ([Id], [CourseId], [RoomId], [DayId], [AllocateFromDate], [AllocateToDate], [IsActive]) VALUES (32, 22, 9, 5, CAST(0x0700C258884D0000 AS Time), CAST(0x0700AC5264600000 AS Time), 0)
SET IDENTITY_INSERT [dbo].[AllocateClassroom] OFF
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (1, N'CSE-101', N'Computer Algorithm', 2, N'Its important for all', 1, 6)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (3, N'CSE-102', N'Theory of Computing', 3, N'Important', 1, 6)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (5, N'CSE-202', N'Data Structure', 3, N'imoprtant', 1, 7)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (6, N'BBA-101', N'Accounting', 2, N'haloo', 2, 3)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (7, N'BBA-205', N'Finance', 3, N'bla bla', 2, 3)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (8, N'BBA-501', N'Statistics', 2, N'huhjhij', 2, 3)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (9, N'CSE-506', N'Assembly', 2, N'adfad', 1, 2)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (10, N'CSE-601', N'Data Communication', 3, N'agaga', 1, 6)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (11, N'EEE-201', N'Math4', 3, N'asdfasf', 3, 4)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (12, N'BBA-110', N'Introduction to Accounting', 3, N'It is accounting', 2, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (13, N'EEE-205', N'Basic Electronic Circuit', 3, N'Electrical Circuit', 3, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (15, N'CE-202', N'Building Structure', 3, N'Structure', 4, 2)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (16, N'ME-409', N'Mechanical Drawing', 3, N'Structure', 5, 2)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (17, N'PME-505', N'Petrolium', 3, N'Petrolium', 6, 5)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (18, N'DE-101', N'Disaster Management', 3, N'It is mandatory', 7, 1)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (19, N'CSE-511', N'Database Management System', 3, N'Database ', 1, 4)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (20, N'CSE-580', N'Artificial Intelligence Lab', 1, N'Artificial Intelligence Lab', 1, 8)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (21, N'CSE-581', N'Artificial Intelligence', 3, N'Artificial Intelligence', 1, 8)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (22, N'ARC-101', N'Design Principle', 3, N'Design Principle', 9, 1)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[CourseAssignTeacher] ON 

INSERT [dbo].[CourseAssignTeacher] ([Id], [TeacherId], [CourseId], [IsActive]) VALUES (1, 2, 1, 0)
INSERT [dbo].[CourseAssignTeacher] ([Id], [TeacherId], [CourseId], [IsActive]) VALUES (2, 13, 18, NULL)
SET IDENTITY_INSERT [dbo].[CourseAssignTeacher] OFF
SET IDENTITY_INSERT [dbo].[Day] ON 

INSERT [dbo].[Day] ([Id], [DayName]) VALUES (7, N'Friday')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (3, N'Monday')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (1, N'Saturday')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (2, N'Sunday')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (6, N'Thursday')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (4, N'Tuesday')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (5, N'Wednesday')
SET IDENTITY_INSERT [dbo].[Day] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([Id], [DeptCode], [DeptName]) VALUES (1, N'CSE', N'Computer Science And Engineering')
INSERT [dbo].[Department] ([Id], [DeptCode], [DeptName]) VALUES (2, N'BBA', N'Bachelor of Business Administrator')
INSERT [dbo].[Department] ([Id], [DeptCode], [DeptName]) VALUES (3, N'EEE', N'Electrical and Electronics Engineering')
INSERT [dbo].[Department] ([Id], [DeptCode], [DeptName]) VALUES (4, N'CE', N'Civil Engineering')
INSERT [dbo].[Department] ([Id], [DeptCode], [DeptName]) VALUES (5, N'ME', N'Mechanical Engineering')
INSERT [dbo].[Department] ([Id], [DeptCode], [DeptName]) VALUES (6, N'PME', N'Petroliam And Mining Engineering')
INSERT [dbo].[Department] ([Id], [DeptCode], [DeptName]) VALUES (7, N'DE', N'Disaster Engineering')
INSERT [dbo].[Department] ([Id], [DeptCode], [DeptName]) VALUES (8, N'OSCM', N'kkjhkjh')
INSERT [dbo].[Department] ([Id], [DeptCode], [DeptName]) VALUES (9, N'ARCHI', N'Architecture')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Designation] ON 

INSERT [dbo].[Designation] ([Id], [DesignationName]) VALUES (3, N'Associate Professor')
INSERT [dbo].[Designation] ([Id], [DesignationName]) VALUES (5, N'Guest Teacher')
INSERT [dbo].[Designation] ([Id], [DesignationName]) VALUES (1, N'Headsir')
INSERT [dbo].[Designation] ([Id], [DesignationName]) VALUES (4, N'Lecturer')
INSERT [dbo].[Designation] ([Id], [DesignationName]) VALUES (2, N'Professor')
SET IDENTITY_INSERT [dbo].[Designation] OFF
SET IDENTITY_INSERT [dbo].[EnrollCourse] ON 

INSERT [dbo].[EnrollCourse] ([Id], [StudentRegId], [CourseId], [EnrollDate], [IsActiveCourse]) VALUES (20, 2, 1, CAST(0x0000A87200000000 AS DateTime), NULL)
INSERT [dbo].[EnrollCourse] ([Id], [StudentRegId], [CourseId], [EnrollDate], [IsActiveCourse]) VALUES (21, 2, 3, CAST(0x0000A87900000000 AS DateTime), NULL)
INSERT [dbo].[EnrollCourse] ([Id], [StudentRegId], [CourseId], [EnrollDate], [IsActiveCourse]) VALUES (22, 2, 10, CAST(0x0000A87900000000 AS DateTime), NULL)
INSERT [dbo].[EnrollCourse] ([Id], [StudentRegId], [CourseId], [EnrollDate], [IsActiveCourse]) VALUES (23, 1, 11, CAST(0x0000A87A00000000 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[EnrollCourse] OFF
SET IDENTITY_INSERT [dbo].[Grade] ON 

INSERT [dbo].[Grade] ([Id], [GradeName]) VALUES (2, N'A')
INSERT [dbo].[Grade] ([Id], [GradeName]) VALUES (1, N'A+')
INSERT [dbo].[Grade] ([Id], [GradeName]) VALUES (3, N'A-')
INSERT [dbo].[Grade] ([Id], [GradeName]) VALUES (5, N'B')
INSERT [dbo].[Grade] ([Id], [GradeName]) VALUES (4, N'B+')
INSERT [dbo].[Grade] ([Id], [GradeName]) VALUES (6, N'B-')
INSERT [dbo].[Grade] ([Id], [GradeName]) VALUES (8, N'C')
INSERT [dbo].[Grade] ([Id], [GradeName]) VALUES (7, N'C+')
INSERT [dbo].[Grade] ([Id], [GradeName]) VALUES (9, N'C-')
INSERT [dbo].[Grade] ([Id], [GradeName]) VALUES (11, N'D')
INSERT [dbo].[Grade] ([Id], [GradeName]) VALUES (10, N'D+')
INSERT [dbo].[Grade] ([Id], [GradeName]) VALUES (12, N'D-')
INSERT [dbo].[Grade] ([Id], [GradeName]) VALUES (13, N'F')
SET IDENTITY_INSERT [dbo].[Grade] OFF
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (1, N'A-101')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (2, N'A-201')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (3, N'A-301')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (4, N'A-401')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (5, N'A-501')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (6, N'B-102')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (7, N'B-202')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (8, N'B-302')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (9, N'B-402')
SET IDENTITY_INSERT [dbo].[Room] OFF
SET IDENTITY_INSERT [dbo].[Semester] ON 

INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (1, N'1st')
INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (2, N'2nd')
INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (3, N'3rd')
INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (4, N'4th')
INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (5, N'5th')
INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (6, N'6th')
INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (7, N'7th')
INSERT [dbo].[Semester] ([Id], [SemesterName]) VALUES (8, N'8th')
SET IDENTITY_INSERT [dbo].[Semester] OFF
SET IDENTITY_INSERT [dbo].[StudentRegistration] ON 

INSERT [dbo].[StudentRegistration] ([Id], [StudentName], [StudentEmail], [StudentContactNo], [RegistrationDate], [StudentAddress], [DepartmentId], [StudentRegNo], [Roll]) VALUES (1, N'Naimul', N'naim@gmail.com', N'01885661211', CAST(0xCF3D0B00 AS Date), N'dfsfsdf', 3, N'EEE-2018-00001', 1)
INSERT [dbo].[StudentRegistration] ([Id], [StudentName], [StudentEmail], [StudentContactNo], [RegistrationDate], [StudentAddress], [DepartmentId], [StudentRegNo], [Roll]) VALUES (2, N'Alam', N'alam@gmail.com', N'01885661211', CAST(0xCF3D0B00 AS Date), N'dfsfsdf', 1, N'CSE-2018-00001', 1)
INSERT [dbo].[StudentRegistration] ([Id], [StudentName], [StudentEmail], [StudentContactNo], [RegistrationDate], [StudentAddress], [DepartmentId], [StudentRegNo], [Roll]) VALUES (3, N'Ziku', N'ziku@gmail.com', N'01885661211', CAST(0xCF3D0B00 AS Date), N'dfsfsdf', 1, N'CSE-2018-00002', 2)
INSERT [dbo].[StudentRegistration] ([Id], [StudentName], [StudentEmail], [StudentContactNo], [RegistrationDate], [StudentAddress], [DepartmentId], [StudentRegNo], [Roll]) VALUES (4, N'dip', N'dip@gmail.com', N'01885661234', CAST(0xC63D0B00 AS Date), N'adasda', 2, N'BBA-2018-00001', 1)
INSERT [dbo].[StudentRegistration] ([Id], [StudentName], [StudentEmail], [StudentContactNo], [RegistrationDate], [StudentAddress], [DepartmentId], [StudentRegNo], [Roll]) VALUES (5, N'Jishan', N'jisan@gmail.com', N'4234234234', CAST(0xCF3D0B00 AS Date), N'kljflksdjflkfdj', 2, N'BBA-2018-00002', 2)
INSERT [dbo].[StudentRegistration] ([Id], [StudentName], [StudentEmail], [StudentContactNo], [RegistrationDate], [StudentAddress], [DepartmentId], [StudentRegNo], [Roll]) VALUES (6, N'mojambbel', N'mojo@gmail.com', N'1312313', CAST(0xCF3D0B00 AS Date), N'wffsdfsdf', 1, N'CSE-2018-00003', 3)
INSERT [dbo].[StudentRegistration] ([Id], [StudentName], [StudentEmail], [StudentContactNo], [RegistrationDate], [StudentAddress], [DepartmentId], [StudentRegNo], [Roll]) VALUES (7, N'Jamal Uddin', N'jamal@gmail.com', N'01834654132', CAST(0xD13D0B00 AS Date), N'Chawkbazar', 2, N'BBA-2018-00003', 3)
INSERT [dbo].[StudentRegistration] ([Id], [StudentName], [StudentEmail], [StudentContactNo], [RegistrationDate], [StudentAddress], [DepartmentId], [StudentRegNo], [Roll]) VALUES (9, N'Anup Dhar', N'anup@gmail.com', N'01885661211', CAST(0xD33D0B00 AS Date), N'sdfadsfasdf', 1, N'CSE-2018-00004', 4)
INSERT [dbo].[StudentRegistration] ([Id], [StudentName], [StudentEmail], [StudentContactNo], [RegistrationDate], [StudentAddress], [DepartmentId], [StudentRegNo], [Roll]) VALUES (10, N'Anup Dey', N'anupdey@gmail.com', N'018856612116666', CAST(0xD33D0B00 AS Date), N'sdfadsfasdf', 4, N'CE-2018-00001', 1)
INSERT [dbo].[StudentRegistration] ([Id], [StudentName], [StudentEmail], [StudentContactNo], [RegistrationDate], [StudentAddress], [DepartmentId], [StudentRegNo], [Roll]) VALUES (12, N'Piku Dhar', N'piku@yahoo.com', N'0188566123455555555', CAST(0xD33D0B00 AS Date), N'fasdf', 2, N'BBA-2018-00004', 4)
INSERT [dbo].[StudentRegistration] ([Id], [StudentName], [StudentEmail], [StudentContactNo], [RegistrationDate], [StudentAddress], [DepartmentId], [StudentRegNo], [Roll]) VALUES (13, N'Pinky Dhar', N'piku2@yahoo.com', N'01732675132', CAST(0xD33D0B00 AS Date), N'fasdf', 5, N'ME-2018-00001', 1)
INSERT [dbo].[StudentRegistration] ([Id], [StudentName], [StudentEmail], [StudentContactNo], [RegistrationDate], [StudentAddress], [DepartmentId], [StudentRegNo], [Roll]) VALUES (14, N'Shourav Chowdhury', N'shourav@yahoo.com', N'018856612116666', CAST(0xD33D0B00 AS Date), N'Hazarilane', 3, N'EEE-2018-00002', 2)
INSERT [dbo].[StudentRegistration] ([Id], [StudentName], [StudentEmail], [StudentContactNo], [RegistrationDate], [StudentAddress], [DepartmentId], [StudentRegNo], [Roll]) VALUES (15, N'Swarup Kumar', N'swarup@yahoo.com', N'01885661211', CAST(0xD33D0B00 AS Date), N'fasdf', 1, N'CSE-2018-00005', 5)
SET IDENTITY_INSERT [dbo].[StudentRegistration] OFF
SET IDENTITY_INSERT [dbo].[StudentResult] ON 

INSERT [dbo].[StudentResult] ([Id], [StudentRegId], [CourseId], [GradeId]) VALUES (9, 2, 1, 2)
INSERT [dbo].[StudentResult] ([Id], [StudentRegId], [CourseId], [GradeId]) VALUES (10, 2, 10, 5)
SET IDENTITY_INSERT [dbo].[StudentResult] OFF
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([Id], [TeacherName], [TeacherAddress], [TeacherEmail], [TeacherContactNo], [DesignationId], [DepartmentId], [CreditToTaken]) VALUES (1, N'Md ariful Islam', N'Bohadderhat,Chittagong', N'arif25@gmail.com', N'01827835274', 4, 1, 14)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [TeacherAddress], [TeacherEmail], [TeacherContactNo], [DesignationId], [DepartmentId], [CreditToTaken]) VALUES (2, N'Rashik', N'dampara,chittagong', N'rashiknasty@gmail.com', N'018265665', 5, 1, 12)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [TeacherAddress], [TeacherEmail], [TeacherContactNo], [DesignationId], [DepartmentId], [CreditToTaken]) VALUES (3, N'Swarup', N'bohadderhat,chittagong', N'swarup64@gmail.com', N'015522565', 5, 1, 13)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [TeacherAddress], [TeacherEmail], [TeacherContactNo], [DesignationId], [DepartmentId], [CreditToTaken]) VALUES (4, N'Morshed', N'chittagong', N'morshed@gmail.com', N'015325646563', 4, 2, 15)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [TeacherAddress], [TeacherEmail], [TeacherContactNo], [DesignationId], [DepartmentId], [CreditToTaken]) VALUES (5, N'arfat', N'dhaka', N'arfatjk@gmail.com', N'01855655664', 4, 2, 16)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [TeacherAddress], [TeacherEmail], [TeacherContactNo], [DesignationId], [DepartmentId], [CreditToTaken]) VALUES (6, N'Imrul Kayes', N'asfafdafaa', N'imrul@afgmail.com', N'02154154666', 4, 2, 13)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [TeacherAddress], [TeacherEmail], [TeacherContactNo], [DesignationId], [DepartmentId], [CreditToTaken]) VALUES (7, N'Masud', N'Dhaka', N'masud@gmail.com', N'018265616', 5, 1, 12)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [TeacherAddress], [TeacherEmail], [TeacherContactNo], [DesignationId], [DepartmentId], [CreditToTaken]) VALUES (8, N'Rashik hafiz', N'dfjsaijidjf', N'rashiknastyr@gmail.com', N'01549655499', 4, 3, 13)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [TeacherAddress], [TeacherEmail], [TeacherContactNo], [DesignationId], [DepartmentId], [CreditToTaken]) VALUES (9, N'Tufiq', N'asjifia', N'tufiq@gmail.com', N'0154546494994', 2, 3, 13)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [TeacherAddress], [TeacherEmail], [TeacherContactNo], [DesignationId], [DepartmentId], [CreditToTaken]) VALUES (10, N'Himel', N'kajdfijiajf', N'himel@gmail.com', N'02121454845', 1, 3, 14)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [TeacherAddress], [TeacherEmail], [TeacherContactNo], [DesignationId], [DepartmentId], [CreditToTaken]) VALUES (11, N'Ashutosh Chakraborty', N'Jamalkhane', N'ashu@hotmail.com', N'01832564714', 3, 2, 14)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [TeacherAddress], [TeacherEmail], [TeacherContactNo], [DesignationId], [DepartmentId], [CreditToTaken]) VALUES (12, N'werer', N'wrerwer', N'werwer@gmaill.com', N'23423423', 3, 1, 5)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [TeacherAddress], [TeacherEmail], [TeacherContactNo], [DesignationId], [DepartmentId], [CreditToTaken]) VALUES (13, N'Sukla Nandi', N'Patia', N'sukla@gmail.com', N'01832873987', 2, 7, 18)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [TeacherAddress], [TeacherEmail], [TeacherContactNo], [DesignationId], [DepartmentId], [CreditToTaken]) VALUES (14, N'Debangshu Chowdhury', N'Anderkilla', N'debangshu@hotmail.com', N'01832465312', 2, 9, 18)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [UserName], [Password]) VALUES (1, N'Admin', N'123456')
SET IDENTITY_INSERT [dbo].[User] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Course]    Script Date: 2/13/2018 10:30:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Course] ON [dbo].[Course]
(
	[CourseCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Course_1]    Script Date: 2/13/2018 10:30:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Course_1] ON [dbo].[Course]
(
	[CourseName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Day]    Script Date: 2/13/2018 10:30:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Day] ON [dbo].[Day]
(
	[DayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Department]    Script Date: 2/13/2018 10:30:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Department] ON [dbo].[Department]
(
	[DeptName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Department_1]    Script Date: 2/13/2018 10:30:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Department_1] ON [dbo].[Department]
(
	[DeptCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Designation]    Script Date: 2/13/2018 10:30:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Designation] ON [dbo].[Designation]
(
	[DesignationName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Grade]    Script Date: 2/13/2018 10:30:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Grade] ON [dbo].[Grade]
(
	[GradeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Room]    Script Date: 2/13/2018 10:30:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Room] ON [dbo].[Room]
(
	[RoomNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Semester]    Script Date: 2/13/2018 10:30:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Semester] ON [dbo].[Semester]
(
	[SemesterName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_StudentRegistration]    Script Date: 2/13/2018 10:30:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_StudentRegistration] ON [dbo].[StudentRegistration]
(
	[StudentEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_StudentRegistration_1]    Script Date: 2/13/2018 10:30:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_StudentRegistration_1] ON [dbo].[StudentRegistration]
(
	[StudentRegNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_StudentRegistration_2]    Script Date: 2/13/2018 10:30:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_StudentRegistration_2] ON [dbo].[StudentRegistration]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_StudentRegistration_3]    Script Date: 2/13/2018 10:30:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_StudentRegistration_3] ON [dbo].[StudentRegistration]
(
	[Roll] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Teacher]    Script Date: 2/13/2018 10:30:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Teacher] ON [dbo].[Teacher]
(
	[TeacherEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AllocateClassroom] ADD  CONSTRAINT [DF_AllocateClassroom_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[AllocateClassroom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassroom_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassroom] CHECK CONSTRAINT [FK_AllocateClassroom_Course]
GO
ALTER TABLE [dbo].[AllocateClassroom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassroom_Day] FOREIGN KEY([DayId])
REFERENCES [dbo].[Day] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassroom] CHECK CONSTRAINT [FK_AllocateClassroom_Day]
GO
ALTER TABLE [dbo].[AllocateClassroom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassroom_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassroom] CHECK CONSTRAINT [FK_AllocateClassroom_Room]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Department]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Semester] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semester] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Semester]
GO
ALTER TABLE [dbo].[CourseAssignTeacher]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssignTeacher_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[CourseAssignTeacher] CHECK CONSTRAINT [FK_CourseAssignTeacher_Course]
GO
ALTER TABLE [dbo].[CourseAssignTeacher]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssignTeacher_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[CourseAssignTeacher] CHECK CONSTRAINT [FK_CourseAssignTeacher_Teacher]
GO
ALTER TABLE [dbo].[EnrollCourse]  WITH CHECK ADD  CONSTRAINT [FK_EnrollCourse_Course1] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[EnrollCourse] CHECK CONSTRAINT [FK_EnrollCourse_Course1]
GO
ALTER TABLE [dbo].[EnrollCourse]  WITH CHECK ADD  CONSTRAINT [FK_EnrollCourse_StudentRegistration1] FOREIGN KEY([StudentRegId])
REFERENCES [dbo].[StudentRegistration] ([Id])
GO
ALTER TABLE [dbo].[EnrollCourse] CHECK CONSTRAINT [FK_EnrollCourse_StudentRegistration1]
GO
ALTER TABLE [dbo].[StudentRegistration]  WITH CHECK ADD  CONSTRAINT [FK_StudentRegistration_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[StudentRegistration] CHECK CONSTRAINT [FK_StudentRegistration_Department]
GO
ALTER TABLE [dbo].[StudentResult]  WITH CHECK ADD  CONSTRAINT [FK_StudentResult_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[StudentResult] CHECK CONSTRAINT [FK_StudentResult_Course]
GO
ALTER TABLE [dbo].[StudentResult]  WITH CHECK ADD  CONSTRAINT [FK_StudentResult_Grade] FOREIGN KEY([GradeId])
REFERENCES [dbo].[Grade] ([Id])
GO
ALTER TABLE [dbo].[StudentResult] CHECK CONSTRAINT [FK_StudentResult_Grade]
GO
ALTER TABLE [dbo].[StudentResult]  WITH CHECK ADD  CONSTRAINT [FK_StudentResult_StudentRegistration] FOREIGN KEY([StudentRegId])
REFERENCES [dbo].[StudentRegistration] ([Id])
GO
ALTER TABLE [dbo].[StudentResult] CHECK CONSTRAINT [FK_StudentResult_StudentRegistration]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Department]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Designation] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designation] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Designation]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "d"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ca"
            Begin Extent = 
               Top = 120
               Left = 38
               Bottom = 250
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "t"
            Begin Extent = 
               Top = 138
               Left = 246
               Bottom = 268
               Right = 435
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "s"
            Begin Extent = 
               Top = 252
               Left = 38
               Bottom = 348
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CourseAssignTeacherViewModel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CourseAssignTeacherViewModel'
GO
USE [master]
GO
ALTER DATABASE [UniversityManagementSystemDB] SET  READ_WRITE 
GO
