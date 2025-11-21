CREATE DATABASE smartcampus;
GO

USE smartcampus;
GO

CREATE TABLE tb_usuario (
    id_Usuario INT IDENTITY(1,1) PRIMARY KEY,
    ds_Nome VARCHAR(100) NOT NULL,
    ds_CPF VARCHAR(20) NOT NULL,
    ds_Email VARCHAR(100) NULL,
    ds_Login VARCHAR(100) NOT NULL,
    ds_Senha VARCHAR(500) NOT NULL,
    dt_Cadastro DATETIME NOT NULL
)

GO

CREATE TABLE tb_categoria (
    id_categoria INT IDENTITY(1,1) PRIMARY KEY,
    ds_nome VARCHAR(100) NOT NULL,
    dt_cadastro DATETIME NOT NULL
)

GO

CREATE TABLE tb_produto (
    id_produto INT IDENTITY(1,1) PRIMARY KEY,
    ds_nome VARCHAR(100) NOT NULL,
    int_quantidade INT NOT NULL,
    dt_validade DATETIME,
    dt_cadastro DATETIME NOT NULL,
    dm_valor DECIMAL(15,2),
    ds_observacao VARCHAR(150),
    id_categoria INT NOT NULL,
    
    CONSTRAINT FK_Categorias_Produtos
        FOREIGN KEY (id_categoria)
        REFERENCES tb_categoria(id_categoria)
)

GO

INSERT INTO tb_categoria (ds_nome, dt_cadastro) VALUES
('Bebida', GETDATE()),
('Alimento', GETDATE()),
('Eletrônicos', GETDATE()),
('Higiene Pessoal', GETDATE()),
('Vestuário', GETDATE()),
('Casa', GETDATE()),
('Acessórios', GETDATE())

GO