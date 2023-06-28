CREATE DATABASE Telcel
USE Telcel

--Scaffold-DbContext "Server=.; Database= Telcel; TrustServerCertificate=True; User ID=sa; Password=pass@word1;" Microsoft.EntityFrameworkCore.SqlServer


CREATE TABLE Empleado
(
	IdEmpleado INT IDENTITY(1,1) CONSTRAINT PK_Empleado PRIMARY KEY,
	Nombre VARCHAR(50),
	IdPuesto INT NOT NULL CONSTRAINT FK_Empleado_Puesto
	FOREIGN KEY (IdPuesto)
	REFERENCES Puesto(IdPuesto),
	IdDepartamento INT NOT NULL CONSTRAINT FK_Empleado_Departamento
	FOREIGN KEY (IdDepartamento)
	REFERENCES Departamento(IdDepartamento)
)

CREATE TABLE Departamento
(
	IdDepartamento INT IDENTITY(1,1) CONSTRAINT PK_Departamento PRIMARY KEY,
	Descripcion VARCHAR(50)
)

CREATE TABLE Puesto
(
	IdPuesto INT IDENTITY(1,1) CONSTRAINT PK_Puesto PRIMARY KEY,
	Descripcion VARCHAR(20)
)

SELECT	Empleado.IdEmpleado,
		Empleado.Nombre,
		Empleado.IdDepartamento,
		Departamento.Descripcion,
		Empleado.IdPuesto,
		Puesto.Descripcion
FROM Empleado
INNER JOIN Departamento ON Empleado.IdDepartamento = Departamento.IdDepartamento
INNER JOIN Puesto ON Empleado.IdPuesto = Puesto.IdPuesto
GO

CREATE PROCEDURE PuestoGetAll
AS
SELECT	Puesto.IdPuesto,
		Puesto.Descripcion
FROM Puesto
GO

CREATE PROCEDURE DepartamentoGetAll
AS
SELECT	Departamento.IdDepartamento,
		Departamento.Descripcion
FROM Departamento
GO

CREATE PROCEDURE EmpleadoAdd
@Nombre VARCHAR(50),
@IdPuesto INT,
@IdDepartamento INT
AS
INSERT INTO Empleado
(
	Nombre,
	IdPuesto,
	IdDepartamento
)
VALUES
(
	@Nombre,
	@IdPuesto,
	@IdDepartamento
)
GO

CREATE PROCEDURE EmpleadoDelete
@IdEmpleado INT
AS
DELETE FROM Empleado
WHERE IdEmpleado = @IdEmpleado
GO

ALTER PROCEDURE EmpleadoGetAll
@Nombre VARCHAR(50)
AS
IF @Nombre = ''
BEGIN
	SELECT	Empleado.IdEmpleado,
			Empleado.Nombre,
			Empleado.IdDepartamento,
			Departamento.Descripcion AS DescripcionDepartamento,
			Empleado.IdPuesto,
			Puesto.Descripcion AS DescripcionPuesto
	FROM Empleado
	INNER JOIN Departamento ON Empleado.IdDepartamento = Departamento.IdDepartamento
	INNER JOIN Puesto ON Empleado.IdPuesto = Puesto.IdPuesto
END
ELSE
BEGIN
	SELECT	Empleado.IdEmpleado,
			Empleado.Nombre,
			Empleado.IdDepartamento,
			Departamento.Descripcion AS DescripcionDeparatamento,
			Empleado.IdPuesto,
			Puesto.Descripcion AS DescripcionPuesto
	FROM Empleado
	INNER JOIN Departamento ON Empleado.IdDepartamento = Departamento.IdDepartamento
	INNER JOIN Puesto ON Empleado.IdPuesto = Puesto.IdPuesto
	WHERE Empleado.Nombre LIKE '%'+ @Nombre +'%'
END
GO