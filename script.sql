IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Pessoas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(40) NOT NULL,
    [Email] nvarchar(40) NOT NULL,
    [Senha] nvarchar(15) NOT NULL,
    [Telefone] nvarchar(13) NULL,
    [CRNM] nvarchar(15) NULL,
    [CPF] nvarchar(11) NULL,
    [Endereco] nvarchar(60) NULL,
    [Numero] int NOT NULL,
    [CEP] int NOT NULL,
    [Sexo] nvarchar(1) NULL,
    [DataNascimento] datetime NULL,
    [Nacionalidade] nvarchar(20) NULL,
    [DataCadastro] datetime NULL,
    [Classe] nvarchar(10) NULL,
    CONSTRAINT [PK_Pessoas] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Experiencias] (
    [Id] int NOT NULL IDENTITY,
    [Id_pessoa] int NOT NULL,
    [Nome] nvarchar(40) NULL,
    [Descricao] nvarchar(200) NULL,
    [Cargo] nvarchar(20) NULL,
    [Instituicao] nvarchar(20) NULL,
    [Inicio] datetime NULL,
    [Fim] datetime NULL,
    [PessoaId] int NULL,
    CONSTRAINT [PK_Experiencias] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Experiencias_Pessoas_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoas] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Formacoes] (
    [Id] int NOT NULL IDENTITY,
    [Id_pessoa] int NOT NULL,
    [Nome] nvarchar(40) NULL,
    [Descricao] nvarchar(200) NULL,
    [Instituicao] nvarchar(20) NULL,
    [Inicio] datetime NULL,
    [Fim] datetime NULL,
    [Situacao] nvarchar(10) NULL,
    [PessoaId] int NULL,
    CONSTRAINT [PK_Formacoes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Formacoes_Pessoas_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoas] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Moradias] (
    [Id] int NOT NULL IDENTITY,
    [Id_pessoa] int NOT NULL,
    [Name] nvarchar(40) NULL,
    [Descricao] nvarchar(200) NULL,
    [Tipo] nvarchar(15) NULL,
    [Preco] money NOT NULL,
    [Endereco] nvarchar(60) NULL,
    [Numero] int NOT NULL,
    [CEP] int NOT NULL,
    [UF] nvarchar(2) NULL,
    [Cidade] nvarchar(20) NULL,
    [NomeContato] nvarchar(40) NULL,
    [TelefoneContato] nvarchar(13) NULL,
    [EmailContato] nvarchar(40) NULL,
    [DataCadastro] datetime NOT NULL,
    [PessoaId] int NULL,
    CONSTRAINT [PK_Moradias] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Moradias_Pessoas_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoas] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Trabalhos] (
    [Id] int NOT NULL IDENTITY,
    [Id_pessoa] int NOT NULL,
    [Instituicao] nvarchar(20) NULL,
    [Nome] nvarchar(40) NULL,
    [Atividade] nvarchar(200) NULL,
    [Tipo] nvarchar(10) NULL,
    [Salario] money NOT NULL,
    [Endereco] nvarchar(60) NULL,
    [Numero] int NOT NULL,
    [CEP] int NOT NULL,
    [UF] nvarchar(max) NULL,
    [Cidade] nvarchar(20) NULL,
    [NomeContato] nvarchar(40) NULL,
    [TelefoneContato] nvarchar(13) NULL,
    [EmailContato] nvarchar(40) NULL,
    [DataCadastro] datetime NOT NULL,
    [PessoaId] int NULL,
    CONSTRAINT [PK_Trabalhos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Trabalhos_Pessoas_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoas] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Experiencias_PessoaId] ON [Experiencias] ([PessoaId]);
GO

CREATE INDEX [IX_Formacoes_PessoaId] ON [Formacoes] ([PessoaId]);
GO

CREATE INDEX [IX_Moradias_PessoaId] ON [Moradias] ([PessoaId]);
GO

CREATE INDEX [IX_Trabalhos_PessoaId] ON [Trabalhos] ([PessoaId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220108214811_migracaoazure', N'5.0.13');
GO

COMMIT;
GO

