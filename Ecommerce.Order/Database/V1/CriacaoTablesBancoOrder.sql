CREATE TABLE Pedido(
Id int IDENTITY(1,1) NOT NULL Primary Key,
Numero int NOT NULL,
Forma_Pagamento int NOT NULL,
Create_Date datetime NOT NULL,
Update_Date datetime NOT NULL)
Go
	
Create Table Categoria(
Id int IDENTITY(1,1) NOT NULL Primary Key,
Descricao Varchar(200) not null,
Create_Date datetime NOT NULL,
Update_Date datetime NOT NULL) 
Go

Create Table Produto(
Id int IDENTITY(1,1) NOT NULL Primary key,
Codigo int,
Descricao varchar(200) not null,
Preco_Custo decimal not null,
Preco_Venda decimal not null,
Quantidade_Estoque int NOT NULL,
Id_Categoria int not null,
Create_Date datetime NOT NULL,
Update_Date datetime NOT NULL)
Go

ALTER TABLE Produto  WITH CHECK ADD CONSTRAINT FK_Produto_Categoria FOREIGN KEY(Id_Categoria)
REFERENCES Categoria (id)
GO

CREATE TABLE Item_Pedido(
Id int IDENTITY(1,1) NOT NULL,
Preco_Unitario decimal not null,
Quantidade int not null,
Id_Produto int not null,
Id_Pedido int not null, 
Create_Date datetime NOT NULL,
Update_Date datetime NOT NULL)
Go

ALTER TABLE Item_Pedido  WITH CHECK ADD CONSTRAINT FK_ItemPedido_Produto FOREIGN KEY(Id_Produto)
REFERENCES Produto (Id)
Go

ALTER TABLE Item_Pedido  WITH CHECK ADD CONSTRAINT FK_ItemPedido_Pedido FOREIGN KEY(Id_Pedido)
REFERENCES Pedido (Id)
Go


insert into [dbo].[Categoria] (Descricao, Create_Date, Update_date) values('Higiene Pessoal', GETDATE(), Getdate())



drop table Item_Pedido
drop table Produto
drop table Categoria
drop table pedido

