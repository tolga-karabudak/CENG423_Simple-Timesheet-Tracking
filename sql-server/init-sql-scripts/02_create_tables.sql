USE [TimesheetDB]
GO

/****** Object:  Table [dbo].[Timesheet]    Script Date: 23.04.2022 02:32:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Timesheet](
	[timesheet_id] [int] NOT NULL,
	[start_date] [date] NULL,
	[start_time] [time](7) NULL,
	[finish_date] [date] NULL,
	[finish_time] [time](7) NULL,
	[user_id] [uniqueidentifier] NOT NULL,
	[timesheet_task_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Timesheet] PRIMARY KEY CLUSTERED 
(
	[timesheet_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Timesheet]  WITH CHECK ADD  CONSTRAINT [FK_Timesheet_Timesheet_task] FOREIGN KEY([timesheet_task_id])
REFERENCES [dbo].[Timesheet_task] ([timesheet_task_id])
GO

ALTER TABLE [dbo].[Timesheet] CHECK CONSTRAINT [FK_Timesheet_Timesheet_task]
GO

ALTER TABLE [dbo].[Timesheet]  WITH CHECK ADD  CONSTRAINT [FK_Timesheet_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO

ALTER TABLE [dbo].[Timesheet] CHECK CONSTRAINT [FK_Timesheet_User]
GO

USE [TimesheetDB]
GO

/****** Object:  Table [dbo].[Timesheet_task]    Script Date: 23.04.2022 02:33:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Timesheet_task](
	[timesheet_task_id] [uniqueidentifier] NOT NULL,
	[timesheet_task_name] [varchar](50) NOT NULL,
	[timesheet_task_topic] [varchar](50) NOT NULL,
	[total_time] [time](7) NOT NULL,
 CONSTRAINT [PK_Timesheet_task] PRIMARY KEY CLUSTERED 
(
	[timesheet_task_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




USE [TimesheetDB]
GO

/****** Object:  Table [dbo].[User]    Script Date: 23.04.2022 02:34:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[user_id] [uniqueidentifier] NOT NULL,
	[mail] [varchar](100) NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

