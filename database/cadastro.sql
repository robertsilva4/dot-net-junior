CREATE DATABASE CADASTRO
	CREATE TABLE CLIENTE(
		ID_CLIENTE int not null identity(1,1),
		NOME varchar(120) not null,
		CPF_CNPJ varchar(18) not null,
		RUA varchar(120) not null,
		NUMERO varchar(50) not null,
		BAIRRO varchar(120) not null,
		CIDADE varchar(120) not null,
		CEP varchar(10) not null,
		TIPO_CASA varchar(10) not null,
		DDD varchar(2) not null,
		NUM_TELEFONE varchar(9) not null,
		TIPO_TELEFONE varchar(12) not null
		constraint PK_CLIENTE primary key(ID_CLIENTE)
	)
DECLARE @TEXTO VARCHAR(20) = '45.542.444-56' 
DECLARE @CPF_CNPJ VARCHAR(20) = ''
;WITH SPLIT AS
(
    SELECT 1 AS ID, SUBSTRING(@TEXTO, 1, 1) AS LETRA
    UNION ALL
    SELECT ID + 1, SUBSTRING(@TEXTO, ID + 1, 1)
    FROM SPLIT
    WHERE ID < LEN(@TEXTO)
)
  
SELECT @CPF_CNPJ += LETRA
FROM SPLIT
WHERE LETRA LIKE '[0-9]'
OPTION(MAXRECURSION 0)
  
IF LEN(@CPF_CNPJ) NOT IN (11, 14)
BEGIN
    SELECT 'Inválido'
    RETURN
END
 
DECLARE
    @I INT,
    @J INT = 1,
    @N INT = LEN(@CPF_CNPJ),
    @DIGITO1 INT = SUBSTRING(@CPF_CNPJ, LEN(@CPF_CNPJ) - 1, 1),
    @DIGITO2 INT = SUBSTRING(@CPF_CNPJ, LEN(@CPF_CNPJ), 1),
    @TOTAL_TMP INT,
    @COEFICIENTE_TMP INT,
    @DIGITO_TMP INT,
    @VALOR_TMP INT,
    @VALOR1 INT,
    @VALOR2 INT
  
WHILE @J <= 2
BEGIN
    SELECT
        @TOTAL_TMP = 0,
        @COEFICIENTE_TMP = 2,
        @I = @N + @J - 3
     
    WHILE @I >= 0
    BEGIN
        SELECT
            @DIGITO_TMP = SUBSTRING(@CPF_CNPJ, @I, 1),
            @TOTAL_TMP += @DIGITO_TMP * @COEFICIENTE_TMP,
            @COEFICIENTE_TMP = @COEFICIENTE_TMP + 1,
            @I -= 1
  
        IF @COEFICIENTE_TMP > 9 AND @N = 14
            SET @COEFICIENTE_TMP = 2
    END
  
    SET @VALOR_TMP = 11 - (@TOTAL_TMP % 11)
  
    IF (@VALOR_TMP >= 10)
        SET @VALOR_TMP = 0
  
    IF @J = 1
        SET @VALOR1 = @VALOR_TMP
    ELSE
        SET @VALOR2 = @VALOR_TMP
 
    SET @J += 1
END
  
SELECT
    CASE WHEN @VALOR1 = @DIGITO1 AND @VALOR2 = @DIGITO2
        THEN 'Válido'
        ELSE 'Inválido'
    END

 INSERT INTO CLIENTE(NOME, CPF_CNPJ, RUA, NUMERO, BAIRRO, CIDADE, CEP, TIPO_CASA, DDD, NUM_TELEFONE, TIPO_TELEFONE) 
	OUTPUT inserted.ID_CLIENTE 
    VALUES ('robert', '12345','seila','12345','seila','seila', '12345','res','11','123456','res' ) 
USE CADASTRO
UPDATE CLIENTE SET	NOME = 'robert richard', 
					CPF_CNPJ = '12345',
					RUA = 'rua da sé',
					NUMERO = '1234',
					BAIRRO = 'seila',
					CIDADE = 'seila',
					CEP = '1235',
					TIPO_CASA = 'res',
					DDD = '11',
					NUM_TELEFONE = '12345',
					TIPO_TELEFONE = 'res' 
      WHERE ID_CLIENTE = '1'

--	CREATE TABLE TB_TELEFONE(
--		ddd char(2) not null,
--		numero varchar(9) not null,
--		tipo varchar(12) not null, 
--		constraint PK_Telefone primary key(numero)
--	)
--	CREATE TABLE TB_ENDERECO(
--		idEndereco int not null identity(1,1),
--		rua varchar(120) not null,
--		numero int not null,
--		bairro varchar(120) not null,
--		cidade varchar(120) not null,
--		cep varchar(10) not null,
--		tipo varchar(10) not null,
--		constraint PK_Endereco primary key(idEndereco)
--	)
	
--	CREATE TABLE TB_CLIENTE(
--		idCliente int not null identity(1,1),
--		nome varchar(120) not null,
--		cpf_cnpj varchar(18) not null,
--		endereco int not null,
--		telefone char(9) not null,
--		constraint PK_Cliente primary key(idCliente),
--		constraint FK_Endereco foreign key (endereco) references TB_ENDERECO(idEndereco),
--		constraint FK_telefone foreign key (telefone) references TB_TELEFONE(numero)
--	)


--UPDATE TB_CLIENTE SET
--	  nome = 'seila', cpf_cnpj = '1234',endereco ='1',telefone = '12' 
--      WHERE idCliente = '1' 

-- SELECT 
--	TB_CLIENTE.idCliente AS ID_CLIENTE,
--	TB_CLIENTE.nome AS CLIENTE_NOME, 
--	TB_CLIENTE.cpf_cnpj AS CPFCNPJ_CLIENTE, 
--	TB_CLIENTE.endereco AS ENDERECO_CLIENTE, 
--	TB_CLIENTE.telefone AS CLIENTE_TELEFONE
--	FROM TB_CLIENTE
--	JOIN TB_ENDERECO ON TB_ENDERECO.idEndereco = TB_CLIENTE.endereco
--	JOIN TB_TELEFONE ON TB_TELEFONE.numero = TB_CLIENTE.telefone

--use CADASTRO
--drop table TB_CLIENTE
--DROP TABLE TB_ENDERECO
--DROP TABLE TB_TELEFONE

--INSERT INTO TB_ENDERECO(rua, numero,bairro,cidade, cep, tipo) 
--            OUTPUT inserted.idEndereco 
--            VALUES ('SEILA', '123','seila','SEILA','1234','res')

--INSERT INTO TB_CLIENTE(nome, cpf_cnpj,endereco,telefone) 
--            OUTPUT inserted.idCliente 
--            VALUES ('SEILA', '1234567','4','SEILA')
--CREATE DATABASE CADASTRO

--	CREATE TABLE TB_TELEFONE(
--		ddd char(2) not null,
--		numero char(9) not null,
--		tipo varchar(12) not null, 
--		constraint PK_Telefone primary key(numero)
--	)
--	CREATE TABLE TB_ENDERECO(
--		idEndereco int not null,
--		rua varchar(120) not null,
--		numero int not null,
--		bairro varchar(120) not null,
--		cidade varchar(120) not null,
--		cep varchar(10) not null,
--		tipo varchar(10) not null,
--		constraint PK_Endereco primary key(idEndereco)
--	)
	
--	CREATE TABLE TB_CLIENTE(
--		idCliente int not null,
--		nome varchar(120) not null,
--		cpf varchar(13) not null,
--		cnpj varchar(18) not null,
--		endereco int not null,
--		telefone char(9) not null,
--		constraint PK_Cliente primary key(idCliente),
--		constraint FK_Endereco foreign key(endereco) references TB_ENDERECO,
--		constraint FK_Numero foreign key(telefone) references TB_TELEFONE
--	)