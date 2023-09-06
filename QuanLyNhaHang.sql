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


insert into FoodItem Values (NEWID(),'6021301e-3301-4871-b5cc-81bcd888d57e',N'FRIED NOODLES',50000,N'Meat, Potatoes, Rice, Tomatoe','breakfast-1.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'6021301e-3301-4871-b5cc-81bcd888d57e',N'SQUID SALAD',50000,N'Meat, Potatoes, Rice, Tomatoe','breakfast-2.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'6021301e-3301-4871-b5cc-81bcd888d57e',N'BANANA CEREAL',50000,N'Meat, Potatoes, Rice, Tomatoe','breakfast-3.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'6021301e-3301-4871-b5cc-81bcd888d57e',N'FRIED EGGS VEGETABLES',50000,N'Meat, Potatoes, Rice, Tomatoe','breakfast-4.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'6021301e-3301-4871-b5cc-81bcd888d57e',N'FRIED SHRIMP',50000,N'Meat, Potatoes, Rice, Tomatoe','breakfast-5.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'6021301e-3301-4871-b5cc-81bcd888d57e',N'VEGETABLE EGG CAKE',50000,N'Meat, Potatoes, Rice, Tomatoe','breakfast-6.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'6021301e-3301-4871-b5cc-81bcd888d57e',N'TUNA',50000,N'Meat, Potatoes, Rice, Tomatoe','breakfast-7.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'6021301e-3301-4871-b5cc-81bcd888d57e',N'STRAWBERRY CEREAL',50000,N'Meat, Potatoes, Rice, Tomatoe','breakfast-8.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'6021301e-3301-4871-b5cc-81bcd888d57e',N'BRAISED FISH',50000,N'Meat, Potatoes, Rice, Tomatoe','breakfast-9.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())

insert into FoodItem Values (NEWID(),'62794b2b-e250-40b6-bedc-7b4e310e38ab',N'STEAK',50000,N'Meat, Potatoes, Rice, Tomatoe','lunch-1.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'62794b2b-e250-40b6-bedc-7b4e310e38ab',N'BBQ CHICKEN',50000,N'Meat, Potatoes, Rice, Tomatoe','lunch-2.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'62794b2b-e250-40b6-bedc-7b4e310e38ab',N'FRIED SQUID',50000,N'Meat, Potatoes, Rice, Tomatoe','lunch-3.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'62794b2b-e250-40b6-bedc-7b4e310e38ab',N'SKEWER',50000,N'Meat, Potatoes, Rice, Tomatoe','lunch-4.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'62794b2b-e250-40b6-bedc-7b4e310e38ab',N'SEAFOOD',50000,N'Meat, Potatoes, Rice, Tomatoe','lunch-5.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'62794b2b-e250-40b6-bedc-7b4e310e38ab',N'BEEF STEW',50000,N'Meat, Potatoes, Rice, Tomatoe','lunch-6.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'62794b2b-e250-40b6-bedc-7b4e310e38ab',N'STEAMED FRIED CHICKEN',50000,N'Meat, Potatoes, Rice, Tomatoe','lunch-7.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'62794b2b-e250-40b6-bedc-7b4e310e38ab',N'WHOLE GRILLED CHICKEN',50000,N'Meat, Potatoes, Rice, Tomatoe','lunch-8.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())

insert into FoodItem Values (NEWID(),'2060ec5c-3611-4bc6-9283-fd2f26b62d63',N'VEGETABLE RIBS',50000,N'Meat, Potatoes, Rice, Tomatoe','dinner-1.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'2060ec5c-3611-4bc6-9283-fd2f26b62d63',N'PORK NOODLES',50000,N'Meat, Potatoes, Rice, Tomatoe','dinner-2.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'2060ec5c-3611-4bc6-9283-fd2f26b62d63',N'EGG ROLL',50000,N'Meat, Potatoes, Rice, Tomatoe','dinner-3.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'2060ec5c-3611-4bc6-9283-fd2f26b62d63',N'MARINATED SALMON',50000,N'Meat, Potatoes, Rice, Tomatoe','dinner-4.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'2060ec5c-3611-4bc6-9283-fd2f26b62d63',N'PASTA',50000,N'Meat, Potatoes, Rice, Tomatoe','dinner-5.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'2060ec5c-3611-4bc6-9283-fd2f26b62d63',N'FRIED EGGS BREAD',50000,N'Meat, Potatoes, Rice, Tomatoe','dinner-6.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'2060ec5c-3611-4bc6-9283-fd2f26b62d63',N'Mixed Spaghetti',50000,N'Meat, Potatoes, Rice, Tomatoe','dinner-7.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())

insert into FoodItem Values (NEWID(),'6386dfe1-d169-4c71-af15-4e8a1f3be884',N'STRAWBERRY CAKE',50000,N'Meat, Potatoes, Rice, Tomatoe','dessert-1.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'6386dfe1-d169-4c71-af15-4e8a1f3be884',N'FRUIT YOGURT',50000,N'Meat, Potatoes, Rice, Tomatoe','dessert-2.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'6386dfe1-d169-4c71-af15-4e8a1f3be884',N'FLAN MILO CAKE',50000,N'Meat, Potatoes, Rice, Tomatoe','dessert-3.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'6386dfe1-d169-4c71-af15-4e8a1f3be884',N'CINNAMON SNAIL ICE CREAM',50000,N'Meat, Potatoes, Rice, Tomatoe','dessert-4.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'6386dfe1-d169-4c71-af15-4e8a1f3be884',N'BUCHI . ICE CREAM',50000,N'Meat, Potatoes, Rice, Tomatoe','dessert-5.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'6386dfe1-d169-4c71-af15-4e8a1f3be884',N'Chocolate Layered Sweet Treat',50000,N'Meat, Potatoes, Rice, Tomatoe','dessert-6.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'6386dfe1-d169-4c71-af15-4e8a1f3be884',N'Mini Cheesecakes',50000,N'Meat, Potatoes, Rice, Tomatoe','dessert-7.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())

insert into FoodItem Values (NEWID(),'7de64136-69dc-47db-9842-728bc29a5bda',N'WINE VILLA PRANDO',50000,N'Meat, Potatoes, Rice, Tomatoe','wine-1.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'7de64136-69dc-47db-9842-728bc29a5bda',N'PENSER NATURE WINE',50000,N'Meat, Potatoes, Rice, Tomatoe','wine-2.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'7de64136-69dc-47db-9842-728bc29a5bda',N'GRAPE WINE',50000,N'Meat, Potatoes, Rice, Tomatoe','wine-3.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'7de64136-69dc-47db-9842-728bc29a5bda',N'WINE MOCKUP',50000,N'Meat, Potatoes, Rice, Tomatoe','wine-4.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'7de64136-69dc-47db-9842-728bc29a5bda',N'WINE VAN',50000,N'Meat, Potatoes, Rice, Tomatoe','wine-5.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'7de64136-69dc-47db-9842-728bc29a5bda',N'DRY RIVER WINE',50000,N'Meat, Potatoes, Rice, Tomatoe','wine-6.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'7de64136-69dc-47db-9842-728bc29a5bda',N'WINE 6FT6',50000,N'Meat, Potatoes, Rice, Tomatoe','wine-7.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'7de64136-69dc-47db-9842-728bc29a5bda',N'GRAHAM S WINE',50000,N'Meat, Potatoes, Rice, Tomatoe','wine-8.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())

insert into FoodItem Values (NEWID(),'27c15a53-e2ac-4d4a-7695-08dba4864899',N'STRAWBERRY LEMONADE',50000,N'Meat, Potatoes, Rice, Tomatoe','drink-1.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'27c15a53-e2ac-4d4a-7695-08dba4864899',N'LEMONADE',50000,N'Meat, Potatoes, Rice, Tomatoe','drink-2.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'27c15a53-e2ac-4d4a-7695-08dba4864899',N'ORANGE JUICE',50000,N'Meat, Potatoes, Rice, Tomatoe','drink-3.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'27c15a53-e2ac-4d4a-7695-08dba4864899',N'COCA-COLA',50000,N'Meat, Potatoes, Rice, Tomatoe','drink-4.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'27c15a53-e2ac-4d4a-7695-08dba4864899',N'APPLE JUICE',50000,N'Meat, Potatoes, Rice, Tomatoe','drink-5.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'27c15a53-e2ac-4d4a-7695-08dba4864899',N'RED TEA WATER',50000,N'Meat, Potatoes, Rice, Tomatoe','drink-6.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into FoodItem Values (NEWID(),'27c15a53-e2ac-4d4a-7695-08dba4864899',N'OO MAI TEA',50000,N'Meat, Potatoes, Rice, Tomatoe','drink-7.jpg','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())

insert into Restaurants Values (newid(),'LCTNhan',N'157 Nguyễn Đức Cảnh','0905669865','lecao11102001@gmail.com', N'https://www.facebook.com/L.C.T.N.XuMuMMiM','0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())

insert into MenuCategory Values (NEWID(),'Specialties',null,'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into MenuCategory Values (NEWID(),'Reservation',null,'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into MenuCategory Values (NEWID(),'Srories',null,'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into MenuCategory Values (NEWID(),'ContactUs',null,'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())

insert into Events values (NEWID(),'Tasty Thursdays','o1.jpg','20% off',null,null,'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into Events values (NEWID(),'Pizza Days','o2.jpg','15% off',null,null,'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())
insert into Events values (NEWID(),'Wine Days','o3.jpg','10% off',null,null,'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())

insert into News values (NEWID(),'Spacious and comfortable place','image_1.jpg','At times, he takes up the exercise of the trouble here, blinded by the whole of things, his or, in. Exercise, and indeed the greater times, 
										from the architect of pleasures or duties and pains. Error, pain, pleasure, all trouble, hate, the guilt of them, unless it results in those whom he hates, as if he repulses those who fall into the rejection of duties, is not it here? 
										You must take advantage of it, or get it.'
								,'Whosoever may be some flight of distinction, is indeed chosen to reject the truth. I will not explain anything because it is them. Wherefore he is not bound by time, 
										unless he be guilty of the pleasure of greater duties, or he undertakes from the pursuit of none of the truth, which, because he is ashamed of bearing them, they are free. Error, he wants to go on. They leave less, for to some this will come, 
										but the matter is greater. He hates pleasures, it will happen or nothing with any of the pains of labor, which he wants the benefits of things to spare him indeed! Because this flight is held, does it itself or only result in pain? 
										I will open the pleasures of flattery not great. He reproaches us with hating the inventor, because he will accept them as laborious. But the fault is found, and his fault is paid for us. Pain, indeed, especially any pain, distinction of pain and the like, 
										for pleasure is more severe, training in reason or in a way which is just for some, pleasures are blessed by the right of no one toils. They succeed and beget the whole flight of choice, but they provide for pains. Pleasures, truth. For the blessed are never guilty of pleasures,
										bound to refuse! Pleasures are the most worthy of pains in times of pain, but we lead some to obtain responsibilities as if no one from the insight provides the great laborious right of repudiating the right advantage is owed to flattery, otherwise pain is toil. Dolores, rightly, 
										is to blame. They provide for the error, to be borne by passion and pain, or by reason. Do you owe these pleasures to the flexibility of those less present things, the things themselves?'
								,10,500,'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID(),'0001-01-01 00:00:00.0000000',NEWID())

insert into FoodItemEvents values(NEWID(),'3d052363-7505-4350-afcc-04256fdc53df','16550233-3ab2-48b3-a94c-08dba870d5fe')
insert into FoodItemEvents values(NEWID(),'6f629116-448a-4005-8d9e-0494450aa984','1f6aeb4d-5784-4028-a94d-08dba870d5fe')
insert into FoodItemEvents values(NEWID(),'3d052363-7505-4350-afcc-04256fdc53df','1f6aeb4d-5784-4028-a94d-08dba870d5fe')
insert into FoodItemEvents values(NEWID(),'505d2ff5-a8fe-49ee-8b4f-0565d83e7d94','16550233-3ab2-48b3-a94c-08dba870d5fe')
insert into FoodItemEvents values(NEWID(),'4b72e285-5ba7-495b-bdf3-12cbb74d042b','1f6aeb4d-5784-4028-a94d-08dba870d5fe')
insert into FoodItemEvents values(NEWID(),'2fb3971e-b948-42b0-bad9-169c748d3d11','1f6aeb4d-5784-4028-a94d-08dba870d5fe')
insert into FoodItemEvents values(NEWID(),'324eb6b2-a34d-43f2-a446-1ce1b9279c13','4640b004-63bd-428c-ba22-08dba93224a9')
