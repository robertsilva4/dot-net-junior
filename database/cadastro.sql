CREATE DATABASE CADASTRO

	CREATE TABLE TB_TELEFONE(
		ddd char(2) not null,
		numero char(9) not null,
		tipo varchar(12) not null, 
		constraint PK_Telefone primary key(numero)
	)
	CREATE TABLE TB_ENDERECO(
		idEndereco int not null,
		rua varchar(120) not null,
		numero int not null,
		bairro varchar(120) not null,
		cidade varchar(120) not null,
		cep varchar(10) not null,
		tipo varchar(10) not null,
		constraint PK_Endereco primary key(idEndereco)
	)
	
	CREATE TABLE TB_CLIENTE(
		idCliente int not null,
		nome varchar(120) not null,
		cpf varchar(13) not null,
		cnpj varchar(18) not null,
		endereco int not null,
		telefone char(9) not null,
		constraint PK_Cliente primary key(idCliente),
		constraint FK_Endereco foreign key(endereco) references TB_ENDERECO,
		constraint FK_Numero foreign key(telefone) references TB_TELEFONE
	)