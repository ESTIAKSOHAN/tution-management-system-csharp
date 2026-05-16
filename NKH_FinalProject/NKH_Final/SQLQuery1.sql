-- Create Tables

CREATE TABLE [dbo].[ClassTbl] (
    [ClassID]   INT          IDENTITY (1, 1) NOT NULL,
    [ClassName] VARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([ClassID] ASC)
);

CREATE TABLE [dbo].[SectionTbl] (
    [SectionID]   INT          IDENTITY (1, 1) NOT NULL,
    [SectionName] VARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([SectionID] ASC)
);

CREATE TABLE [dbo].[UserTbl] (
    [UserID]   INT           IDENTITY (1, 1) NOT NULL,
    [Username] VARCHAR (50)  NOT NULL,
    [Password] VARCHAR (100) NOT NULL,
    [Role]     VARCHAR (20)  NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC),
    UNIQUE NONCLUSTERED ([Username] ASC),
    CHECK ([Role]='Teacher' OR [Role]='Admin')
);

CREATE TABLE [dbo].[StudentTbl] (
    [StudentID]   INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (50)  NOT NULL,
    [DateOfBirth] DATE          NOT NULL,
    [Phone]       VARCHAR (20)  NOT NULL,
    [Address]     VARCHAR (200) NOT NULL,
    [ClassID]     INT           NOT NULL,
    [SectionID]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([StudentID] ASC),
    CONSTRAINT [FK1] FOREIGN KEY ([ClassID]) REFERENCES [dbo].[ClassTbl] ([ClassID]),
    CONSTRAINT [FK2] FOREIGN KEY ([SectionID]) REFERENCES [dbo].[SectionTbl] ([SectionID])
);

drop table PaymentTbl

CREATE TABLE [dbo].[PaymentTbl] (
    [PaymentID]     INT             IDENTITY (1, 1) NOT NULL,
    [StudentID]     INT             NOT NULL,
    [PaymentDate]   DATE            NOT NULL,
    [TotalFees]     DECIMAL (10, 2) NOT NULL,
    [PayableAmount] DECIMAL (10, 2) NOT NULL,
    [PaymentType]   VARCHAR (20)    NOT NULL,
    PRIMARY KEY CLUSTERED ([PaymentID] ASC),
    CONSTRAINT [FK3] FOREIGN KEY ([StudentID]) REFERENCES [dbo].[StudentTbl] ([StudentID])
);

CREATE TABLE [dbo].[AttendenceTbl] (
    [SessionID] INT  IDENTITY (1, 1) NOT NULL,
    [ClassID]   INT  NOT NULL,
    [SectionID] INT  NOT NULL,
    [Date]      DATE NOT NULL,
    PRIMARY KEY CLUSTERED ([SessionID] ASC),
    CONSTRAINT [UQ_Att] UNIQUE NONCLUSTERED ([ClassID] ASC, [SectionID] ASC, [Date] ASC),
    CONSTRAINT [FK4] FOREIGN KEY ([ClassID]) REFERENCES [dbo].[ClassTbl] ([ClassID]),
    CONSTRAINT [FK5] FOREIGN KEY ([SectionID]) REFERENCES [dbo].[SectionTbl] ([SectionID])
);

CREATE TABLE [dbo].[AttendenceDetailTbl] (
    [AttendanceID] INT          IDENTITY (1, 1) NOT NULL,
    [SessionID]    INT          NOT NULL,
    [StudentID]    INT          NOT NULL,
    [Status]       VARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([AttendanceID] ASC),
    CHECK ([Status] = 'Late' OR [Status] = 'Absent' OR [Status] = 'Present'),
    CONSTRAINT [FK6] FOREIGN KEY ([SessionID]) REFERENCES [dbo].[AttendenceTbl] ([SessionID]),
    CONSTRAINT [FK7] FOREIGN KEY ([StudentID]) REFERENCES [dbo].[StudentTbl] ([StudentID])
);

-- ============================================================
-- Seed Data: Default Admin Login
-- Username: admin | Password: admin123
-- ============================================================
INSERT INTO [dbo].[UserTbl] (Username, Password, Role)
VALUES ('admin', 'admin123', 'Admin');

-- Sample Classes
INSERT INTO [dbo].[ClassTbl] (ClassName) VALUES ('Class 1'),('Class 2'),('Class 3'),('Class 4'),('Class 5'),('Class 6'),('Class 7'),('Class 8'),('Class 9'),('Class 10');


INSERT INTO [dbo].[SectionTbl] (SectionName) VALUES ('A'),('B'),('C'),('D');

select * from  ClassTbl,SectionTbl

select * from StudentTbl,ClassTbl,SectionTbl,PaymentTbl,AttendenceTbl,AttendenceDetailTbl