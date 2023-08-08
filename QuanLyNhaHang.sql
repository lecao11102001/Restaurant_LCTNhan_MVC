CREATE TABLE [Customers] (
  [CustomerId] uniqueidentifier PRIMARY KEY NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [Gender] bit,
  [Address] nvarchar(255) NOT NULL,
  [Phone] nvarchar(10) NOT NULL,
  [Email] nvarchar(255) NOT NULL,
  [DateOfBirth] datetime,
  [CreatedDate] datetime,
  [CreatedById] uniqueidentifier,
  [ModifiedDate] datetime,
  [ModifiedById] uniqueidentifier,
  [DeleteDate] datetime,
  [DeleteById] uniqueidentifier
)
GO

CREATE TABLE [Restaurants] (
  [Name] nvarchar(100) NOT NULL,
  [Address] nvarchar(225) NOT NULL,
  [Phone] nvarchar(10) NOT NULL,
  [Email] nvarchar(255) NOT NULL,
  [Website] nvarchar(4000) NOT NULL,
  [CreatedDate] datetime NOT NULL,
  [CreatedById] uniqueidentifier NOT NULL,
  [ModifiedDate] datetime NOT NULL,
  [ModifiedById] uniqueidentifier NOT NULL,
  [DeleteDate] datetime NOT NULL,
  [DeleteById] uniqueidentifier NOT NULL
)
GO

CREATE TABLE [Chefs] (
  [ChefId] uniqueidentifier PRIMARY KEY NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [Position] nvarchar(100),
  [Description] nvarchar(max),
  [Image] nvarchar(max),
  [Info] nvarchar(max),
  [CreatedDate] datetime NOT NULL,
  [CreatedById] uniqueidentifier NOT NULL,
  [ModifiedDate] datetime NOT NULL,
  [ModifiedById] uniqueidentifier NOT NULL,
  [DeleteDate] datetime NOT NULL,
  [DeleteById] uniqueidentifier NOT NULL
)
GO

CREATE TABLE [FoodCategory] (
  [FoodCategoryId] uniqueidentifier PRIMARY KEY NOT NULL,
  [Name] nvarchar(255),
  [CreatedDate] datetime NOT NULL,
  [CreatedById] uniqueidentifier NOT NULL,
  [ModifiedDate] datetime NOT NULL,
  [ModifiedById] uniqueidentifier NOT NULL,
  [DeleteDate] datetime NOT NULL,
  [DeleteById] uniqueidentifier NOT NULL
)
GO

CREATE TABLE [FoodItem] (
  [FoodItemId] uniqueidentifier PRIMARY KEY NOT NULL,
  [FoodCategoryId] uniqueidentifier NOT NULL,
  [Name] nvarchar(255),
  [Price] decimal(18,0),
  [Description] nvarchar(max),
  [Images] nvarchar(max),
  [CreatedDate] datetime NOT NULL,
  [CreatedById] uniqueidentifier NOT NULL,
  [ModifiedDate] datetime NOT NULL,
  [ModifiedById] uniqueidentifier NOT NULL,
  [DeleteDate] datetime NOT NULL,
  [DeleteById] uniqueidentifier NOT NULL
)
GO

CREATE TABLE [CommentFood] (
  [CommentFoodId] uniqueidentifier PRIMARY KEY NOT NULL,
  [FoodItemId] uniqueidentifier NOT NULL,
  [CustomerId] uniqueidentifier NOT NULL,
  [Name] nvarchar(255),
  [Image] nvarchar(max),
  [Message] nvarchar(max),
  [CreatedDate] datetime NOT NULL,
  [DeleteDate] datetime NOT NULL,
  [DeleteById] uniqueidentifier NOT NULL
)
GO

CREATE TABLE [StoriesCategory] (
  [StoriesCategoryId] uniqueidentifier PRIMARY KEY NOT NULL,
  [Name] nvarchar(255),
  [CreatedDate] datetime NOT NULL,
  [CreatedById] uniqueidentifier NOT NULL,
  [ModifiedDate] datetime NOT NULL,
  [ModifiedById] uniqueidentifier NOT NULL,
  [DeleteDate] datetime NOT NULL,
  [DeleteById] uniqueidentifier NOT NULL
)
GO

CREATE TABLE [StoriesItem] (
  [StoriesItemId] uniqueidentifier PRIMARY KEY NOT NULL,
  [StoriesCategoryID] uniqueidentifier NOT NULL,
  [Name] nvarchar(255),
  [Image] nvarchar(max),
  [Viewer] int,
  [Comments] int,
  [CreatedDate] datetime NOT NULL,
  [CreatedById] uniqueidentifier NOT NULL,
  [ModifiedDate] datetime NOT NULL,
  [ModifiedById] uniqueidentifier NOT NULL,
  [DeleteDate] datetime NOT NULL,
  [DeleteById] uniqueidentifier NOT NULL
)
GO

CREATE TABLE [StoriesItemInFo] (
  [StoriesItemId] uniqueidentifier PRIMARY KEY NOT NULL,
  [Name] nvarchar(255),
  [Image] nvarchar(max),
  [Description] nvarchar(max),
  [CreatedDate] datetime NOT NULL,
  [CreatedById] uniqueidentifier NOT NULL,
  [ModifiedDate] datetime NOT NULL,
  [ModifiedById] uniqueidentifier NOT NULL,
  [DeleteDate] datetime NOT NULL,
  [DeleteById] uniqueidentifier NOT NULL
)
GO

CREATE TABLE [CommentStory] (
  [CommentStoryId] uniqueidentifier PRIMARY KEY NOT NULL,
  [StoriesItemId] uniqueidentifier NOT NULL,
  [CustomerId] uniqueidentifier NOT NULL,
  [Name] nvarchar(255),
  [Image] nvarchar(4000),
  [Message] nvarchar(max),
  [CreatedDate] datetime NOT NULL,
  [DeleteDate] datetime NOT NULL,
  [DeleteById] uniqueidentifier NOT NULL
)
GO

CREATE TABLE [Reservations] (
  [ReservationsId] uniqueidentifier PRIMARY KEY NOT NULL,
  [CustomerId] uniqueidentifier NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [Email] nvarchar(255) NOT NULL,
  [Phone] nvarchar(10) NOT NULL,
  [Date] date NOT NULL,
  [Time] time NOT NULL,
  [NumberOfGuests] int NOT NULL,
  [CreatedDate] datetime NOT NULL,
  [CreatedById] uniqueidentifier NOT NULL,
  [ModifiedDate] datetime NOT NULL,
  [ModifiedById] uniqueidentifier NOT NULL,
  [DeleteDate] datetime NOT NULL,
  [DeleteById] uniqueidentifier NOT NULL
)
GO

CREATE TABLE [ContactUs] (
  [ContactUsId] uniqueidentifier PRIMARY KEY NOT NULL,
  [CustomerId] uniqueidentifier NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [Email] nvarchar(255) NOT NULL,
  [Subject] nvarchar(255) NOT NULL,
  [Message] nvarchar(max) NOT NULL,
  [CreatedDate] datetime NOT NULL,
  [CreatedById] uniqueidentifier NOT NULL,
  [ModifiedDate] datetime NOT NULL,
  [ModifiedById] uniqueidentifier NOT NULL,
  [DeleteDate] datetime NOT NULL,
  [DeleteById] uniqueidentifier NOT NULL
)
GO

CREATE TABLE [Account] (
  [AccountId] uniqueidentifier PRIMARY KEY NOT NULL,
  [CustomerId] uniqueidentifier NOT NULL,
  [UserName] nvarchar(255),
  [PassWord] nvarchar(50),
  [Role] bit,
  [CreatedDate] datetime,
  [CreatedById] uniqueidentifier,
  [ModifiedDate] datetime,
  [ModifiedById] uniqueidentifier,
  [DeleteDate] datetime,
  [DeleteById] uniqueidentifier
)
GO

CREATE TABLE [History] (
  [HistoryId] uniqueidentifier PRIMARY KEY NOT NULL,
  [CustomerId] uniqueidentifier NOT NULL,
  [Date] date,
  [Time] time,
  [NumberOfGuests] int,
  [CreatedDate] datetime NOT NULL,
  [CreatedById] uniqueidentifier NOT NULL,
  [ModifiedDate] datetime NOT NULL,
  [ModifiedById] uniqueidentifier NOT NULL,
  [DeleteDate] datetime NOT NULL,
  [DeleteById] uniqueidentifier NOT NULL
)
GO

ALTER TABLE [FoodItem] ADD FOREIGN KEY ([FoodCategoryId]) REFERENCES [FoodCategory] ([FoodCategoryId])
GO

ALTER TABLE [CommentFood] ADD FOREIGN KEY ([FoodItemId]) REFERENCES [FoodItem] ([FoodItemId])
GO

ALTER TABLE [CommentFood] ADD FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([CustomerId])
GO

ALTER TABLE [StoriesItem] ADD FOREIGN KEY ([StoriesCategoryID]) REFERENCES [StoriesCategory] ([StoriesCategoryId])
GO

ALTER TABLE [StoriesItemInFo] ADD FOREIGN KEY ([StoriesItemId]) REFERENCES [StoriesItem] ([StoriesItemId])
GO

ALTER TABLE [CommentStory] ADD FOREIGN KEY ([StoriesItemId]) REFERENCES [StoriesItemInFo] ([StoriesItemId])
GO

ALTER TABLE [CommentStory] ADD FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([CustomerId])
GO

ALTER TABLE [Reservations] ADD FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([CustomerId])
GO

ALTER TABLE [ContactUs] ADD FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([CustomerId])
GO

ALTER TABLE [Account] ADD FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([CustomerId])
GO

ALTER TABLE [History] ADD FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([CustomerId])
GO

insert into Customers Values(NEWID(),N'Lê Cao Thành Nhân',0,N'157 Nguyễn Đức Cảnh',0905669865,'lecao11102001@gmail.com',11/10/2001,0,NEWID(),0,NEWID(),0,NEWID())
insert into Account Values(NEWID(),'e7684e59-14aa-451f-bd04-fb4319529cca','lecao11102001','11102001',1,0,NEWID(),0,NEWID(),0,NEWID())


insert into FoodItem Values (NEWID(),'ffea725a-0b0d-4855-9e93-2a78a2bdb5c4',N'Thành Nhân',50,N'Lê Cao Thành Nhân','ava.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'6386dfe1-d169-4c71-af15-4e8a1f3be884',N'Thành Nhân1',50,N'Lê Cao Thành Nhân 1','ava.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'7de64136-69dc-47db-9842-728bc29a5bda',N'Thành Nhân2',50,N'Lê Cao Thành Nhân 2','ava.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'62794b2b-e250-40b6-bedc-7b4e310e38ab',N'Thành Nhân3',50,N'Lê Cao Thành Nhân 3','ava.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'6021301e-3301-4871-b5cc-81bcd888d57e',N'Thành Nhân4',50,N'Lê Cao Thành Nhân 4','ava.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'2060ec5c-3611-4bc6-9283-fd2f26b62d63',N'Thành Nhân5',50,N'Lê Cao Thành Nhân 5','ava.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())








