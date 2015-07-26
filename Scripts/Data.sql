USE [SaleAssistant]

INSERT INTO [Unit] ([Id], [Name], [Status], [IsTrash])
VALUES ('85C65762-6DC7-4503-9271-74A43D2CA9AB', 'Kg', 1, 0),
	   ('29F4A4DA-F35B-4275-B4D8-DE63F5748C42', 'Bottle', 1, 0)

GO

INSERT INTO [Product] ([Id], [Name], [Code], [UnitId], [Status])
VALUES ('E03A8954-2740-435B-B95C-327B02608011', 'Bio Speclin', 'B001', '29F4A4DA-F35B-4275-B4D8-DE63F5748C42', 1),
       ('68745266-F2F7-446E-B702-A207D0F5D363', 'Bio Sone', 'N001', '29F4A4DA-F35B-4275-B4D8-DE63F5748C42', 1),
       ('B5E2C358-DF12-4BFB-B301-3D23B3258190', 'Bio Norxacin', 'B002', '29F4A4DA-F35B-4275-B4D8-DE63F5748C42', 1),
       ('198180AA-D148-4C0D-B85A-43D9C8C8C0BE', 'Bio Fer', 'N002', '29F4A4DA-F35B-4275-B4D8-DE63F5748C42', 1),
       ('57BF44DC-4743-409D-B3FD-622F7CBE512D', 'Bio Dexa', 'N003', '29F4A4DA-F35B-4275-B4D8-DE63F5748C42', 1)
GO

INSERT INTO [ProductPricing] ([Id], [ProductId], [UnitPrice], [Type], [EffectiveDate], [CreatedDate])
VALUES ('1D4DA207-EA40-409F-9D84-6B0252B10D0B', 'E03A8954-2740-435B-B95C-327B02608011', 137000, 0, '2015-07-19 00:00:00.000', '2015-07-19 00:00:00.000'),
       ('A1006E17-89E2-4D30-A1D1-5B9379A5AFC1', '68745266-F2F7-446E-B702-A207D0F5D363', 120000, 0, '2015-07-19 00:00:00.000', '2015-07-19 00:00:00.000'),
       ('9691509E-F22D-4297-BC45-BC4327F4D946', 'B5E2C358-DF12-4BFB-B301-3D23B3258190', 200000, 0, '2015-07-19 00:00:00.000', '2015-07-19 00:00:00.000'),
       ('5A605BC2-562B-4FEE-8E51-49E07785E97A', '198180AA-D148-4C0D-B85A-43D9C8C8C0BE', 185000, 0, '2015-07-19 00:00:00.000', '2015-07-19 00:00:00.000'),
       ('0536DA3A-80D3-41D5-BEF1-5DAFB20EFE4A', '57BF44DC-4743-409D-B3FD-622F7CBE512D', 100000, 0, '2015-07-19 00:00:00.000', '2015-07-19 00:00:00.000'),
       
       ('F71E737B-473B-4C47-8068-00D3506A336E', 'E03A8954-2740-435B-B95C-327B02608011', 150000, 1, '2015-07-19 00:00:00.000', '2015-07-19 00:00:00.000'),
       ('76739F31-9557-478D-948A-DE0016EEA301', '68745266-F2F7-446E-B702-A207D0F5D363', 140000, 1, '2015-07-19 00:00:00.000', '2015-07-19 00:00:00.000'),
       ('65FD1C45-F254-4978-8694-275BDA0A3B6C', 'B5E2C358-DF12-4BFB-B301-3D23B3258190', 230000, 1, '2015-07-19 00:00:00.000', '2015-07-19 00:00:00.000'),
       ('8D70ADA8-02D3-46B1-B630-BB382FBE1BB2', '198180AA-D148-4C0D-B85A-43D9C8C8C0BE', 205000, 1, '2015-07-19 00:00:00.000', '2015-07-19 00:00:00.000'),
       ('6E7B0DD0-7EFA-43B6-9FB2-44943D7843D9', '57BF44DC-4743-409D-B3FD-622F7CBE512D', 130000, 1, '2015-07-19 00:00:00.000', '2015-07-19 00:00:00.000')
GO

INSERT INTO [Inventory] ([Id], [Name], [Status])
VALUES ('3A8ED735-F959-4D67-9E57-F781B746E0E9', 'Store GK', 1),
       ('29A39E35-9934-492D-A2A8-D84D48645AE8', 'Store TS', 1)

GO

INSERT INTO [InventoryItem] ([Id], [InventoryId], [ProductId], [Quantity])
VALUES ('B8A1F37E-A82F-4438-A974-FA7D6ED3617C', '3A8ED735-F959-4D67-9E57-F781B746E0E9', 'E03A8954-2740-435B-B95C-327B02608011', 10),
       ('AF445D79-9012-4A44-8875-09276034EBB1', '3A8ED735-F959-4D67-9E57-F781B746E0E9', 'B5E2C358-DF12-4BFB-B301-3D23B3258190', 15),
       ('CF32D68C-BC8C-473B-B748-01F47445773B', '29A39E35-9934-492D-A2A8-D84D48645AE8', '68745266-F2F7-446E-B702-A207D0F5D363', 5),
       ('7F394D7D-B5CF-4287-B13E-A6CEACBBF761', '29A39E35-9934-492D-A2A8-D84D48645AE8', '198180AA-D148-4C0D-B85A-43D9C8C8C0BE', 30),
       ('910C171D-694C-4429-896C-5EA948EB7219', '29A39E35-9934-492D-A2A8-D84D48645AE8', '57BF44DC-4743-409D-B3FD-622F7CBE512D', 25)
GO

INSERT INTO [Vendor] ([Id], [Name], [Status])
VALUES ('36224766-91D2-4213-B0FF-4FD2D19462CB', 'Bio', 1),
       ('089A3247-C91C-46F6-88F6-3F176FA173DD', 'Pfizer', 1)
GO
    
INSERT INTO [Customer] ([Id], [Name], [Status])
VALUES ('05730B2F-262F-4070-8A7F-AAF6464EEDC9', 'Farm GK', 1),
       ('2DA40B0E-6B01-4025-84DC-6DC0BF13EAC0', 'Farm TS', 1)
GO       

