Create Database SP_MedicalGroups;
GO

USE SP_MedicalGroups;
GO


Create Table TipoUsuarios
(
	IdTipoUsuario INT PRIMARY KEY IDENTITY
	,tituloTipoUsuario VARCHAR(250) UNIQUE NOT NULL
);
GO

Create Table Usuarios
(
		IdUsuario INT PRIMARY KEY IDENTITY,
		IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuarios(IdTipoUsuario),
		Email VARCHAR(100) UNIQUE NOT NULL,
		senha VARCHAR(30) NOT NULL,
);
GO

Create Table Clinicas
(
	IdClinica INT PRIMARY KEY IDENTITY,
	cnpj CHAR(14) UNIQUE NOT NULL,
	nomeFantasia VARCHAR(255) UNIQUE NOT NULL,
	razaoSocial VARCHAR(255) NOT NULL,
	endereço VARCHAR(120) UNIQUE NOT NULL,
	HorarioFuncionamento TIME NOT NULL,
	HorarioFechamento TIME NOT NULL,
);
GO

Create Table Especialidades
(
	IdEspecialidade INT PRIMARY KEY IDENTITY,
	titulosEspecialidades VARCHAR(300) UNIQUE NOT NULL,
);
GO

Create Table Prontuarios
(
	IdProntuario INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES usuarios(IdUsuario),
	NomeProntuario VARCHAR (200) NOT NULL,
	RG VARCHAR (20) UNIQUE NOT NULL,
	CPF VARCHAR (20) UNIQUE NOT NULL, 
	DataNascimento DATE NOT NULL,
	TelefoneProntuario CHAR(200) UNIQUE NOT NULL,
	Endereço VARCHAR(200) NOT NULL,
);
GO

Create Table Medicos
(
	IdMedico INT PRIMARY KEY IDENTITY,
	Idusuario INT FOREIGN KEY REFERENCES usuarios(IdUsuario),
	IdClinica INT FOREIGN KEY REFERENCES Clinicas(IdClinica),
	IdEspecialidades INT FOREIGN KEY REFERENCES Especialidades(IdEspecialidade),
	nomeMedico VARCHAR(200) NOT NULL,
	crm CHAR(8) UNIQUE NOT NULL
);
GO

Create Table Situações
(
	IdSituação INT PRIMARY KEY IDENTITY,
	tituloSituação VARCHAR(100) UNIQUE NOT NULL,
);
GO

Create Table Consultas
(
	IdConsulta INT PRIMARY KEY IDENTITY,
	IdMedico INT FOREIGN KEY REFERENCES Medicos(IdMedico),
	IdProntuario INT FOREIGN KEY REFERENCES Prontuarios(IdProntuario),
	IdSituação INT FOREIGN KEY REFERENCES Situações(IdSituação),
	DataConsulta DATE NOT NULL,
	Relatorio VARCHAR (400) DEFAULT ('Relatorio não Informado...')
);
GO
