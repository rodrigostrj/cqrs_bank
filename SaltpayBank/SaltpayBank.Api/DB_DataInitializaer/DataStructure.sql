
IF NOT EXISTS  (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'Accounts'))
	CREATE TABLE [dbo].[Accounts](
		[Id] [int] NOT NULL IDENTITY (1,1),
		[Customer_Id] [int] NOT NULL,
		[Amount] [decimal](18, 0) NOT NULL,
	 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]


IF NOT EXISTS  (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'Customers'))
	CREATE TABLE [dbo].[Customers](
		[Id] [int] NOT NULL,
		[Name] [nvarchar](50) NOT NULL,
	 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

IF NOT EXISTS  (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'Transfers'))
	CREATE TABLE [dbo].[Transfers](
		[Id] [int] NOT NULL IDENTITY (1,1),
		[OriginAccount_id] [int] NOT NULL,
		[DestinyAccount_id] [int] NOT NULL,
		[AmountToTransfer] [decimal](18, 0) NOT NULL,
		[OriginAccountAmountBeforeTransfer] [decimal](18, 0) NOT NULL,
		[DateTransfer] [datetime] NOT NULL,
	 CONSTRAINT [PK_Transfers] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

IF NOT EXISTS  (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'FK_Accounts_Customers'))
	ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Customers] FOREIGN KEY([Customer_Id])
	REFERENCES [dbo].[Customers] ([Id])
	ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Customers]

IF NOT EXISTS  (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'FK_Transfer_Accounts_Destiny'))
	ALTER TABLE [dbo].[Transfers]  WITH CHECK ADD  CONSTRAINT [FK_Transfer_Accounts_Destiny] FOREIGN KEY([DestinyAccount_id])
	REFERENCES [dbo].[Accounts] ([Id])
	ALTER TABLE [dbo].[Transfers] CHECK CONSTRAINT [FK_Transfer_Accounts_Destiny]

IF NOT EXISTS  (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'FK_Transfer_Accounts_Origin'))
	ALTER TABLE [dbo].[Transfers]  WITH CHECK ADD  CONSTRAINT [FK_Transfer_Accounts_Origin] FOREIGN KEY([OriginAccount_id])
	REFERENCES [dbo].[Accounts] ([Id])
	ALTER TABLE [dbo].[Transfers] CHECK CONSTRAINT [FK_Transfer_Accounts_Origin]

