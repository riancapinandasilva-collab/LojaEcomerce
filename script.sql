-- CRIANDO O BANCO DE DADOS
CREATE DATABASE dbProjetoLoja;

-- USANDO O BANCO DE DADOS
USE dbProjetoLoja;

-- CRIANDO AS TABELAS DO BANCO DE DADOS
CREATE TABLE tb_Usuario(
 Id int primary key auto_increment,
 Nome varchar(50) not null,
 Email varchar(50) not null,
 Senha varchar(250) not null,
 Nivel varchar(50) not null
);

--  CONSULTANDO A TABELA DO BANCO DE DADOS

SELECT * FROM tb_Usuario;

-- INSERINDO DADOS NA TABELA DO BANCO DE DADOS

INSERT INTO tb_Usuario(Nome,Email,Senha, Nivel) VALUES 
('Administrador','admin@email.com','123456','Admin');