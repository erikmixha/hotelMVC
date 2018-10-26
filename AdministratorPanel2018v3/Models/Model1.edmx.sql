
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/11/2018 22:55:07
-- Generated from EDMX file: C:\Users\Akademia\Desktop\HOTEL\AdministratorPanel2018v4\AdministratorPanel2018v3\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HotelDatabase2018];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Booking__ClientI__1ED998B2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK__Booking__ClientI__1ED998B2];
GO
IF OBJECT_ID(N'[dbo].[FK__Booking__Employe__1DE57479]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK__Booking__Employe__1DE57479];
GO
IF OBJECT_ID(N'[dbo].[FK__Booking_R__Booki__300424B4]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Booking_Rooms] DROP CONSTRAINT [FK__Booking_R__Booki__300424B4];
GO
IF OBJECT_ID(N'[dbo].[FK__Booking_R__RoomI__2F10007B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Booking_Rooms] DROP CONSTRAINT [FK__Booking_R__RoomI__2F10007B];
GO
IF OBJECT_ID(N'[dbo].[FK__Employee__Accoun__1A14E395]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK__Employee__Accoun__1A14E395];
GO
IF OBJECT_ID(N'[dbo].[FK__Employee__RoleID__1B0907CE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK__Employee__RoleID__1B0907CE];
GO
IF OBJECT_ID(N'[dbo].[FK__FeedBack__Client__173876EA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FeedBacks] DROP CONSTRAINT [FK__FeedBack__Client__173876EA];
GO
IF OBJECT_ID(N'[dbo].[FK__Images__RoomID__286302EC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Images] DROP CONSTRAINT [FK__Images__RoomID__286302EC];
GO
IF OBJECT_ID(N'[dbo].[FK__Rooms__FacilityI__25869641]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rooms] DROP CONSTRAINT [FK__Rooms__FacilityI__25869641];
GO
IF OBJECT_ID(N'[dbo].[FK_Booking_Rooms_Booking_Rooms]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Booking_Rooms] DROP CONSTRAINT [FK_Booking_Rooms_Booking_Rooms];
GO
IF OBJECT_ID(N'[dbo].[FK_Clients_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clients] DROP CONSTRAINT [FK_Clients_Role];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[Booking_Rooms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Booking_Rooms];
GO
IF OBJECT_ID(N'[dbo].[Bookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bookings];
GO
IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[FeedBacks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FeedBacks];
GO
IF OBJECT_ID(N'[dbo].[Images]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Images];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[RoomFacilities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoomFacilities];
GO
IF OBJECT_ID(N'[dbo].[Rooms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rooms];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [AccountID] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(50)  NULL,
    [Password] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL
);
GO

-- Creating table 'Booking_Rooms'
CREATE TABLE [dbo].[Booking_Rooms] (
    [Link_ID] int IDENTITY(1,1) NOT NULL,
    [RoomID] int  NULL,
    [BookingID] int  NULL
);
GO

-- Creating table 'Bookings'
CREATE TABLE [dbo].[Bookings] (
    [BookingID] int IDENTITY(1,1) NOT NULL,
    [Numberofpeople] int  NULL,
    [Arrival_date] datetime  NULL,
    [Departure_date] datetime  NULL,
    [EmployeeID] int  NULL,
    [ClientID] int  NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [ClientID] int IDENTITY(1,1) NOT NULL,
    [Firstname] nvarchar(50)  NULL,
    [Lastname] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [RoleID] int  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [EmployeeID] int IDENTITY(1,1) NOT NULL,
    [Firstname] nvarchar(50)  NULL,
    [Lastname] nvarchar(50)  NULL,
    [Salary] decimal(19,4)  NULL,
    [Status] nvarchar(50)  NULL,
    [AccountID] int  NULL,
    [RoleID] int  NULL
);
GO

-- Creating table 'FeedBacks'
CREATE TABLE [dbo].[FeedBacks] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(max)  NULL,
    [ClientID] int  NULL
);
GO

-- Creating table 'Images'
CREATE TABLE [dbo].[Images] (
    [ImgID] int IDENTITY(1,1) NOT NULL,
    [Img_Path] varchar(max)  NULL,
    [RoomID] int  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleID] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(50)  NULL
);
GO

-- Creating table 'RoomFacilities'
CREATE TABLE [dbo].[RoomFacilities] (
    [FacilityID] int IDENTITY(1,1) NOT NULL,
    [AirCon] bit  NULL,
    [Tv] bit  NULL,
    [Telephone] bit  NULL,
    [Balcony] bit  NULL,
    [Parking] bit  NULL
);
GO

-- Creating table 'Rooms'
CREATE TABLE [dbo].[Rooms] (
    [RoomID] int IDENTITY(1,1) NOT NULL,
    [RoomDescription] varchar(max)  NULL,
    [RoomStatus] nvarchar(50)  NULL,
    [FacilityID] int  NULL,
    [Price] decimal(19,4)  NULL,
    [Floor] int  NULL,
    [Size] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AccountID] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([AccountID] ASC);
GO

-- Creating primary key on [Link_ID] in table 'Booking_Rooms'
ALTER TABLE [dbo].[Booking_Rooms]
ADD CONSTRAINT [PK_Booking_Rooms]
    PRIMARY KEY CLUSTERED ([Link_ID] ASC);
GO

-- Creating primary key on [BookingID] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [PK_Bookings]
    PRIMARY KEY CLUSTERED ([BookingID] ASC);
GO

-- Creating primary key on [ClientID] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([ClientID] ASC);
GO

-- Creating primary key on [EmployeeID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC);
GO

-- Creating primary key on [ID] in table 'FeedBacks'
ALTER TABLE [dbo].[FeedBacks]
ADD CONSTRAINT [PK_FeedBacks]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ImgID] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [PK_Images]
    PRIMARY KEY CLUSTERED ([ImgID] ASC);
GO

-- Creating primary key on [RoleID] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleID] ASC);
GO

-- Creating primary key on [FacilityID] in table 'RoomFacilities'
ALTER TABLE [dbo].[RoomFacilities]
ADD CONSTRAINT [PK_RoomFacilities]
    PRIMARY KEY CLUSTERED ([FacilityID] ASC);
GO

-- Creating primary key on [RoomID] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [PK_Rooms]
    PRIMARY KEY CLUSTERED ([RoomID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AccountID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK__Employee__Accoun__1A14E395]
    FOREIGN KEY ([AccountID])
    REFERENCES [dbo].[Accounts]
        ([AccountID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Employee__Accoun__1A14E395'
CREATE INDEX [IX_FK__Employee__Accoun__1A14E395]
ON [dbo].[Employees]
    ([AccountID]);
GO

-- Creating foreign key on [BookingID] in table 'Booking_Rooms'
ALTER TABLE [dbo].[Booking_Rooms]
ADD CONSTRAINT [FK__Booking_R__Booki__300424B4]
    FOREIGN KEY ([BookingID])
    REFERENCES [dbo].[Bookings]
        ([BookingID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Booking_R__Booki__300424B4'
CREATE INDEX [IX_FK__Booking_R__Booki__300424B4]
ON [dbo].[Booking_Rooms]
    ([BookingID]);
GO

-- Creating foreign key on [RoomID] in table 'Booking_Rooms'
ALTER TABLE [dbo].[Booking_Rooms]
ADD CONSTRAINT [FK__Booking_R__RoomI__2F10007B]
    FOREIGN KEY ([RoomID])
    REFERENCES [dbo].[Rooms]
        ([RoomID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Booking_R__RoomI__2F10007B'
CREATE INDEX [IX_FK__Booking_R__RoomI__2F10007B]
ON [dbo].[Booking_Rooms]
    ([RoomID]);
GO

-- Creating foreign key on [Link_ID] in table 'Booking_Rooms'
ALTER TABLE [dbo].[Booking_Rooms]
ADD CONSTRAINT [FK_Booking_Rooms_Booking_Rooms]
    FOREIGN KEY ([Link_ID])
    REFERENCES [dbo].[Booking_Rooms]
        ([Link_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ClientID] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK__Booking__ClientI__1ED998B2]
    FOREIGN KEY ([ClientID])
    REFERENCES [dbo].[Clients]
        ([ClientID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Booking__ClientI__1ED998B2'
CREATE INDEX [IX_FK__Booking__ClientI__1ED998B2]
ON [dbo].[Bookings]
    ([ClientID]);
GO

-- Creating foreign key on [EmployeeID] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK__Booking__Employe__1DE57479]
    FOREIGN KEY ([EmployeeID])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Booking__Employe__1DE57479'
CREATE INDEX [IX_FK__Booking__Employe__1DE57479]
ON [dbo].[Bookings]
    ([EmployeeID]);
GO

-- Creating foreign key on [ClientID] in table 'FeedBacks'
ALTER TABLE [dbo].[FeedBacks]
ADD CONSTRAINT [FK__FeedBack__Client__173876EA]
    FOREIGN KEY ([ClientID])
    REFERENCES [dbo].[Clients]
        ([ClientID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__FeedBack__Client__173876EA'
CREATE INDEX [IX_FK__FeedBack__Client__173876EA]
ON [dbo].[FeedBacks]
    ([ClientID]);
GO

-- Creating foreign key on [ClientID] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [FK_Clients_Role]
    FOREIGN KEY ([ClientID])
    REFERENCES [dbo].[Roles]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RoleID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK__Employee__RoleID__1B0907CE]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[Roles]
        ([RoleID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Employee__RoleID__1B0907CE'
CREATE INDEX [IX_FK__Employee__RoleID__1B0907CE]
ON [dbo].[Employees]
    ([RoleID]);
GO

-- Creating foreign key on [RoomID] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [FK__Images__RoomID__286302EC]
    FOREIGN KEY ([RoomID])
    REFERENCES [dbo].[Rooms]
        ([RoomID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Images__RoomID__286302EC'
CREATE INDEX [IX_FK__Images__RoomID__286302EC]
ON [dbo].[Images]
    ([RoomID]);
GO

-- Creating foreign key on [FacilityID] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [FK__Rooms__FacilityI__25869641]
    FOREIGN KEY ([FacilityID])
    REFERENCES [dbo].[RoomFacilities]
        ([FacilityID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Rooms__FacilityI__25869641'
CREATE INDEX [IX_FK__Rooms__FacilityI__25869641]
ON [dbo].[Rooms]
    ([FacilityID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------