--DQL

USE SP_MedicalGroups;
GO

SELECT * FROM tipoUsuarios;

SELECT * FROM usuarios

SELECT * FROM prontuarios;

SELECT * FROM medicos;

SELECT * FROM especialidades;

SELECT * FROM clinicas;

SELECT * FROM Situações;

SELECT * FROM consultas;

--FUNÇÕES

SELECT tituloTipoUsuario AS TipoUsuario, email AS Email FROM tipoUsuarios
	INNER JOIN usuarios
	ON tipoUsuarios.idTipoUsuario = usuarios.idTipoUsuario;

	SELECT nomeProntuario AS Paciente, nomeMedico AS Médico, titulosEspecialidades AS Especialidade, dataConsulta AS DiaAgendamento, DataConsulta AS HoraAgendamento, tituloSituação AS Situação FROM consultas
	INNER JOIN prontuarios
	ON consultas.idProntuario = prontuarios.idProntuario
	INNER JOIN medicos
	ON consultas.idMedico = medicos.idMedico
	INNER JOIN especialidades
	ON especialidades.idEspecialidade = medicos.IdEspecialidades
	INNER JOIN Situações
	ON consultas.IdSituação = Situações.IdSituação;

	SELECT nomeFantasia, razaoSocial, cnpj, endereço, HorarioFuncionamento, HorarioFechamento FROM clinicas;

	SELECT nomeMedico AS Médico, nomeProntuario AS Prontuário,Relatorio AS Relatorio, dataConsulta AS DataAgendamento, DataConsulta AS HoraAgendamento, tituloSituação AS Agendamento FROM medicos
	INNER JOIN consultas
	ON medicos.idMedico = consultas.idMedico
	INNER JOIN prontuarios
	ON consultas.idProntuario = prontuarios.idProntuario
	INNER JOIN Situações
	ON consultas.IdSituação = Situações.IdSituação
	WHERE medicos.idMedico = 2; 

	SELECT nomeProntuario AS Prontuário, nomeMedico AS Médico, Relatorio AS Relatorio, dataConsulta AS DataAgendamento, DataConsulta AS HoraAgendamento, tituloSituação AS Agendamento FROM medicos
	INNER JOIN consultas
	ON medicos.idMedico = consultas.idMedico
	INNER JOIN prontuarios
	ON consultas.idProntuario = prontuarios.idProntuario
	INNER JOIN Situações
	ON consultas.IdSituação = Situações.IdSituação
	WHERE prontuarios.idProntuario = 7;

	--Login
	SELECT tituloTipoUsuario AS TipoUsuario, email AS Emails, senha AS Senhas FROM usuarios
	INNER JOIN tipoUsuarios
	ON usuarios.idTipoUsuario = tipoUsuarios.idTipoUsuario
	WHERE email = 'adm@adm.com' AND senha = 'adm123';

	--capacidades

	SELECT COUNT (usuarios.idUsuario) AS QtdUsuarios FROM usuarios;

	SELECT nomeProntuario AS Nomes, CONVERT (VARCHAR, dataNascimento, 101) AS DataNascimento FROM prontuarios;

	SELECT nomeProntuario AS Nomes, DATEDIFF(HOUR, dataNascimento,GETDATE())/8766 AS Idades FROM prontuarios;


	SELECT prontuarios.nomeProntuario, prontuarios.dataNascimento,
	CASE 
	WHEN DATEPART(MONTH, prontuarios.dataNascimento) <= DATEPART(MONTH, GETDATE()) 
	AND DATEPART(DAY, prontuarios.dataNascimento) <= DATEPART(DAY, GETDATE())
	THEN (DATEDIFF(YEAR, prontuarios.dataNascimento,GETDATE()))
	ELSE (DATEDIFF(YEAR, prontuarios.dataNascimento,GETDATE())) - 1 
	END AS IdadeAtual
	FROM prontuarios
	WHERE prontuarios.idProntuario = 7


	SELECT prontuarios.nomeProntuario, prontuarios.dataNascimento,
	DATEDIFF(YEAR, prontuarios.dataNascimento,GETDATE()) AS IdadeAtual
	FROM prontuarios;

	CREATE FUNCTION QntdMedicos(@idEspecialidade VARCHAR(200))
		AS 
		BEGIN 
			DECLARE @qntd AS INT 
			SET @qntd = 
			(
			SELECT COUNT(nomeMedico) FROM medicos 
			INNER JOIN especialidades 
			ON medicos.IdEspecialidades = especialidades.idEspecialidade
			WHERE especialidades.titulosEspecialidades = IdEspecialidade 
			)
			RETURN @qntd 
		END
		GO

		SELECT qntd = dbo.QntdMedicos('Psiquiatria');

		SELECT dbo.QntdMedicos('Psiquiatria') AS QuantidadeMedicos;

		--STORED PROCEDURE

			CREATE PROCEDURE CalcularIdadeTodos
		AS
		SELECT prontuarios.nomeProntuario, prontuarios.dataNascimento,
		DATEDIFF(YEAR, prontuarios.dataNascimento,GETDATE()) AS IdadeAtual
		FROM prontuarios;
		GO

		EXECUTE CalcularIdadeTodos;

		CREATE PROCEDURE CalcularIdadeEspecifica(@nomeProntuario VARCHAR(100))
		AS
		SELECT prontuarios.nomeProntuario, prontuarios.dataNascimento,
		DATEDIFF(YEAR, prontuarios.dataNascimento,GETDATE()) AS IdadeAtual
		FROM prontuarios
		WHERE prontuarios.nomeProntuario = @nomeProntuario;
		GO

		EXECUTE CalcularIdadeEspecifica @nomeProntuario = 'Mariana';