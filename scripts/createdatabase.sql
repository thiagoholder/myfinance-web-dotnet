-- Verifica se o banco de dados existe
IF DB_ID('myfinance') IS NULL
BEGIN
    -- Cria o banco de dados se ele não existir
    CREATE DATABASE myfinance;
END
GO
	USE myfinance;
GO

IF OBJECT_ID('dbo.PlanoConta', 'U') IS NULL
	BEGIN
		CREATE TABLE dbo.PlanoConta(
			Id UNIQUEIDENTIFIER PRIMARY KEY,
			Descricao VARCHAR(50) NOT NULL,
			Tipo INT NOT NULL
		);

		INSERT INTO dbo.PlanoConta(Id,Descricao, Tipo) VALUES('5cfeb921-26a1-4ebc-babb-0a201d2b6f8d','Combustível', 0)
		INSERT INTO dbo.PlanoConta(Id,Descricao, Tipo) VALUES('07385332-3b7c-4855-9bfd-3f7ef898ca18','Salário', 1)
		INSERT INTO dbo.PlanoConta(Id,Descricao, Tipo) VALUES('a1dabee7-6baa-4ad1-ac0f-07f46afbc1ce','Alimentação', 0)
		INSERT INTO dbo.PlanoConta(Id,Descricao, Tipo) VALUES('3530b2b5-90f7-4b89-9fb9-7f4a6787b5d9','Impostos', 0)
		INSERT INTO dbo.PlanoConta(Id,Descricao, Tipo) VALUES('9f0b2c40-84ab-4270-9990-ae21a9328c27','Água', 0)
		INSERT INTO dbo.PlanoConta(Id,Descricao, Tipo) VALUES('8d6ad165-221c-4816-8340-33825fe2ad5b','Luz', 0)
		INSERT INTO dbo.PlanoConta(Id,Descricao, Tipo) VALUES('f2916a16-1cf3-4704-a3ca-5804347b3f55','Internet', 0)
	END
GO

IF OBJECT_ID('dbo.Transacao', 'U') IS NULL
BEGIN
	CREATE TABLE [dbo].[Transacao](
		[id] UNIQUEIDENTIFIER NOT NULL,
		[data] [datetime] NOT NULL,
		[valor] [decimal](9, 2) NOT NULL,
		[historico] [varchar](100) NULL,
		[planoconta_id] UNIQUEIDENTIFIER NOT NULL,
	PRIMARY KEY CLUSTERED 
	(
		[id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]

	INSERT [dbo].[Transacao] ([id], [data], [valor], [historico], [planoconta_id]) 
		   VALUES ('d8a1b033-1ef5-4a3a-b1b5-ae3f49060212', CAST(N'2023-06-22T14:37:51.177' AS DateTime), CAST(25.00 AS Decimal(9, 2)), N'Café da manhã', 'a1dabee7-6baa-4ad1-ac0f-07f46afbc1ce')
	INSERT [dbo].[Transacao] ([id], [data], [valor], [historico], [planoconta_id]) 
		   VALUES ('29a8c363-d6be-46c3-b9eb-380739c8fb25', CAST(N'2023-06-22T14:40:54.380' AS DateTime), CAST(40.00 AS Decimal(9, 2)), N'Gasolina', '5cfeb921-26a1-4ebc-babb-0a201d2b6f8d')
	INSERT [dbo].[Transacao] ([id], [data], [valor], [historico], [planoconta_id]) 
		   VALUES ('53e0e504-4d5d-4a29-9f25-3d20a2158c39', CAST(N'2023-06-15T00:00:00.000' AS DateTime), CAST(1000.00 AS Decimal(9, 2)), N'Salário', '07385332-3b7c-4855-9bfd-3f7ef898ca18')
	INSERT [dbo].[Transacao] ([id], [data], [valor], [historico], [planoconta_id]) 
	       VALUES ('b5736f56-704e-406e-aa54-ac37f8a73201', CAST(N'2023-06-10T00:00:00.000' AS DateTime), CAST(48.00 AS Decimal(9, 2)), N'Imposto', '3530b2b5-90f7-4b89-9fb9-7f4a6787b5d9')
	INSERT [dbo].[Transacao] ([id], [data], [valor], [historico], [planoconta_id]) 
	       VALUES ('e99c88c9-7798-4fb7-927a-1f7f0c789240', CAST(N'2023-06-08T00:00:00.000' AS DateTime), CAST(150.00 AS Decimal(9, 2)), N'Copasa', '9f0b2c40-84ab-4270-9990-ae21a9328c27')
	INSERT [dbo].[Transacao] ([id], [data], [valor], [historico], [planoconta_id]) 
	       VALUES ('87a72264-b7f2-44be-b246-c3f0db4ba46f', CAST(N'2023-06-08T00:00:00.000' AS DateTime), CAST(180.00 AS Decimal(9, 2)), N'Cemig', '8d6ad165-221c-4816-8340-33825fe2ad5b')
	INSERT [dbo].[Transacao] ([id], [data], [valor], [historico], [planoconta_id]) 
	       VALUES ('3e19b896-bf0b-4982-b0a7-2a5b17330ebc', CAST(N'2023-06-18T00:00:00.000' AS DateTime), CAST(110.00 AS Decimal(9, 2)), N'Blink internet', 'f2916a16-1cf3-4704-a3ca-5804347b3f55')
	INSERT [dbo].[Transacao] ([id], [data], [valor], [historico], [planoconta_id]) 
	       VALUES ('282d61c1-f26e-4553-b0cb-fc0965130a1e', CAST(N'2023-06-15T00:00:00.000' AS DateTime), CAST(11000.00 AS Decimal(9, 2)), N'Cartão Itau', '3530b2b5-90f7-4b89-9fb9-7f4a6787b5d9')
	INSERT [dbo].[Transacao] ([id], [data], [valor], [historico], [planoconta_id]) 
	       VALUES ('b22e62ae-0650-4438-9ec3-ca472e9f7a9d', CAST(N'2023-06-22T16:36:07.657' AS DateTime), CAST(45.00 AS Decimal(9, 2)), N'Gasolina carro', '5cfeb921-26a1-4ebc-babb-0a201d2b6f8d')

	ALTER TABLE [dbo].[Transacao]  WITH CHECK ADD FOREIGN KEY([planoconta_id])
	REFERENCES [dbo].[PlanoConta] ([id])
END
