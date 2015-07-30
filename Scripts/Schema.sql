USE [SaleAssistant]
GO

/* -- DROP ALL TABLES

DROP TABLE [dbo].[Customer]
DROP TABLE [dbo].[Vendor]
DROP TABLE [dbo].[ProductPricing]
DROP TABLE [dbo].[InventoryItem]
DROP TABLE [dbo].[Inventory]
DROP TABLE [dbo].[Product]
DROP TABLE [dbo].[Unit]

*/

CREATE TABLE [dbo].[Unit](
	[Id] [uniqueidentifier] NOT NULL DEFAULT(NEWSEQUENTIALID()),
	[Name] [nvarchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[IsTrash] [bit] NOT NULL DEFAULT(0),
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Product](
	[Id] [uniqueidentifier] NOT NULL DEFAULT(NEWSEQUENTIALID()),
	[Name] [nvarchar](200) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[UnitId] [uniqueidentifier] NOT NULL,
	[Status] [int] NOT NULL,
	[IsTrash] [bit] NOT NULL DEFAULT(0),
 CONSTRAINT [PK_dbo.Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Unit_UnitId] FOREIGN KEY([UnitId])
REFERENCES [dbo].[Unit] ([Id])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Unit_UnitId]
GO

CREATE TABLE [dbo].[Inventory](
	[Id] [uniqueidentifier] NOT NULL DEFAULT(NEWSEQUENTIALID()),
	[Name] [nvarchar](200) NOT NULL,
	[Status] [int] NOT NULL,
	[IsTrash] [bit] NOT NULL DEFAULT(0),
 CONSTRAINT [PK_dbo.Inventory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[InventoryItem](
	[Id] [uniqueidentifier] NOT NULL DEFAULT(NEWSEQUENTIALID()),
	[InventoryId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[Quantity] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_dbo.InventoryItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[InventoryItem]  WITH CHECK ADD  CONSTRAINT [FK_InventoryItem_Inventory_InventoryId] FOREIGN KEY([InventoryId])
REFERENCES [dbo].[Inventory] ([Id])
GO

ALTER TABLE [dbo].[InventoryItem] CHECK CONSTRAINT [FK_InventoryItem_Inventory_InventoryId]
GO

ALTER TABLE [dbo].[InventoryItem]  WITH CHECK ADD  CONSTRAINT [FK_InventoryItem_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO

ALTER TABLE [dbo].[InventoryItem] CHECK CONSTRAINT [FK_InventoryItem_Product_ProductId]
GO

CREATE TABLE [dbo].[Vendor](
	[Id] [uniqueidentifier] NOT NULL DEFAULT(NEWSEQUENTIALID()),
	[Name] [nvarchar](200) NOT NULL,
	[Status] [int] NOT NULL,
	[IsTrash] [bit] NOT NULL DEFAULT(0),
 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Customer](
	[Id] [uniqueidentifier] NOT NULL DEFAULT(NEWSEQUENTIALID()),
	[Name] [nvarchar](200) NOT NULL,
	[Status] [int] NOT NULL,
	[IsTrash] [bit] NOT NULL DEFAULT(0),
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[ProductPricing](
	[Id] [uniqueidentifier] NOT NULL DEFAULT(NEWSEQUENTIALID()),
	[ProductId] [uniqueidentifier] NOT NULL,
	[UnitPrice] [decimal](10, 2) NOT NULL,
	[Type] [int] NOT NULL,
	[EffectiveDate] [datetime] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ProductPricing] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ProductPricing]  WITH CHECK ADD  CONSTRAINT [FK_ProductPricing_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO

ALTER TABLE [dbo].[ProductPricing] CHECK CONSTRAINT [FK_ProductPricing_Product]
GO

