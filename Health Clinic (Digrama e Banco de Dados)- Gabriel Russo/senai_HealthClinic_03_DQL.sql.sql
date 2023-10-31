-- DQL DATA QUERY LANGUAGE

/* Criar script que exiba os seguintes dados:

- Id Consulta
- Data da Consulta
- Horario da Consulta
- Nome da Clinica
- Nome do Paciente
- Nome do Medico
- Especialidade do Medico
- CRM
- Prontuário ou Descricao
- FeedBack(Comentario da consulta)

Criar função para retornar os médicos de uma determinada especialidade

* Criar procedure para retornar a idade de um determinado usuário específico */

USE HealthClinic_Gabriel;

SELECT
	Consulta.IdConsulta,
	Consulta.DataConsulta,
	Consulta.HorarioConsulta,
	Clinica.NomeFantasia AS Clinica,
	PacienteUser.Nome AS NomePaciente,
	MedicoUser.Nome AS NomeMedico,
	Especialidade.NomeEspecialidade AS Especialidade,
	Medico.CRM,
	Consulta.Descricao,
	ComentarioConsulta.Comentario AS Comentario
FROM
	Consulta LEFT JOIN ComentarioConsulta ON Consulta.IdConsulta = ComentarioConsulta.IdConsulta
	LEFT JOIN Medico ON Medico.IdMedico = Consulta.IdMedico
	LEFT JOIN Paciente ON Paciente.IdPaciente = Consulta.IdPaciente
	LEFT JOIN Especialidade ON Especialidade.IdEspecialidade = Medico.IdEspecialidade
	LEFT JOIN Clinica ON Clinica.IdClinica = Medico.IdClinica
	LEFT JOIN Usuario AS PacienteUser ON PacienteUser.IdUsuario = Paciente.IdUsuario
	LEFT JOIN Usuario AS MedicoUser ON MedicoUser.IdUsuario = Medico.IdUsuario


	SELECT
		MedicoUser.Nome,
		Especialidade.NomeEspecialidade
	FROM
		Medico LEFT JOIN Especialidade ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
		LEFT JOIN Usuario AS MedicoUser ON MedicoUser.IdUsuario = Medico.IdUsuario

	
