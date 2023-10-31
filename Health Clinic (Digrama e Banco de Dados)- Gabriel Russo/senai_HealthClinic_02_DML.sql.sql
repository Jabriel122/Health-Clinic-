-- DML (Data Manipulation Language)
USE HealthClinic_Gabriel;

--Inserindo dados na tabela TipoDeUsuario
INSERT INTO TipoDeUsuario(TituloTipoUsuario)
VALUES
('Administrador'), ('Medico'), ('Paciente');

SELECT * FROM TipoDeUsuario;

--Inserindo dados na tabela Usuario
INSERT INTO Usuario(IdTipoDeUsuario,Email,Senha,Nome)
VALUES
(1,'gabriel@gmail.com','1562','Gabriel'),
(2,'pedro@gmail.com','1562','Pedro'),
(2,'allan@gmail.com','1562','Allan'),
(3,'andre@gmail.com','1562','Andre'),
(3,'rubens@gmail.com','1562','Rubens'),
(2,'carlos@gmail.com','1562','Carlos'),
(3,'diego@gmail.com','1562','Diego');

SELECT * FROM Usuario

--Inserindo dados na tabela Clinica
INSERT INTO Clinica(NomeFantasia,Endereco,RazaoSocial,HorarioAbertura,HorarioFechamento,CNPJ)
VALUES('HealthClinic','Av. Araucaria 1520, Pq. Oratorio Santo Andre, SP','Clinica de saúde Dr.Rofstar','07:00','18:00','15647896523145');

SELECT * FROM Clinica;

--Inserindo dados na tabela Especialidade
INSERT INTO Especialidade(NomeEspecialidade)
VALUES ('Ortopedista'),('Cardiologista'),('Vascular');

SELECT * FROM Especialidade;

--Inserindo dados na tabela Medico
INSERT INTO Medico(IdEspecialidade,IdClinica,IdUsuario,CRM)
VALUES 
(1,1,2,'85697894'),
(2,1,3,'52645369'),
(3,1,6,'14598752');

SELECT * FROM Medico;

--Inserindo dados na tabela Usuario
INSERT INTO Paciente(IdUsuario,DataNascimento,Sexo,CPF)
VALUES 
('4','16/05/2000','Masculino','26547895123'),
('5','16/05/2000','Masculino','15623478941'),
('7','16/05/2000','Masculino','26547894230');

SELECT * FROM Paciente;

--Inserindo dados na tabela Consulta
INSERT INTO Consulta(IdMedico,IdPaciente,DataConsulta,HorarioConsulta,Descricao)
VALUES
(1,1,'02/09/2023','07:50','Paciente se encontra com dores'),
(2,2,'10/09/2023','10:50','Paciente se encontra com dores'),
(3,3,'10/09/2023','15:50','Paciente se encontra com dores'),
(1,2,'28/09/2023','16:50','Paciente se encontra com dores');

SELECT * FROM Consulta;

--Inserindo dados na tabela ComentarioConsulta
INSERT INTO ComentarioConsulta(IdConsulta,Comentario)
VALUES
(1,'Ótimo profissional!'),
(4,'Excelente hospital e um ótimo médico');

SELECT * FROM ComentarioConsulta;