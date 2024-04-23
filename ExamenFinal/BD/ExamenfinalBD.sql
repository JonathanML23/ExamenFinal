create DATABASE examenfinal
go
use examenfinal

CREATE TABLE Agentes (
    ID INT identity PRIMARY KEY,
    Nombre VARCHAR(50),
    Email VARCHAR(100),
    Telefono VARCHAR(20)
)
go

CREATE TABLE Clientes (
    ID INT identity PRIMARY KEY,
    Nombre VARCHAR(50),
    Email VARCHAR(100),
    Telefono VARCHAR(20)
)
go

CREATE TABLE Casas (
    ID INT identity PRIMARY KEY,
    Direccion VARCHAR(100),
    Ciudad VARCHAR(50),
    Precio DECIMAL(10, 2)
)
go

CREATE TABLE Ventas (
    ID INT identity PRIMARY KEY,
    ID_Agente INT,
    ID_Cliente INT,
    ID_Casa INT,
    Fecha DATE,
    FOREIGN KEY (ID_Agente) REFERENCES Agentes(ID),
    FOREIGN KEY (ID_Cliente) REFERENCES Clientes(ID),
    FOREIGN KEY (ID_Casa) REFERENCES Casas(ID)
)
go

INSERT INTO Agentes (Nombre, Email, Telefono) VALUES
('Juan Pérez', 'juan@example.com', '123-456-7890'),
('María López', 'maria@example.com', '987-654-3210'),
('Carlos González', 'carlos@example.com', '456-789-0123')

INSERT INTO Clientes (Nombre, Email, Telefono) VALUES
('Laura Martínez', 'laura@example.com', '111-222-3333'),
('Pedro Rodríguez', 'pedro@example.com', '444-555-6666'),
('Ana García', 'ana@example.com', '777-888-9999')

INSERT INTO Casas (Direccion, Ciudad, Precio) VALUES
('Calle 123', 'Madrid', 250000.00),
('Avenida 456', 'Barcelona', 300000.00),
('Calle 789', 'Valencia', 200000.00)

INSERT INTO Ventas (ID_Agente, ID_Cliente, ID_Casa, Fecha) VALUES
(1, 2, 1, '2024-04-01'),
(2, 3, 2, '2024-04-03'),
(3, 1, 3, '2024-04-05')

go

alter PROCEDURE GestionarAgentes
    @accion NVARCHAR(10),
    @agente_id INT = NULL,
    @agente_nombre NVARCHAR(50) = NULL,
    @agente_email NVARCHAR(100) = NULL,
    @agente_telefono NVARCHAR(20) = NULL
AS
BEGIN
    IF @accion = 'agregar'
    BEGIN
        INSERT INTO Agentes (Nombre, Email, Telefono) VALUES (@agente_nombre, @agente_email, @agente_telefono)
    END
    ELSE IF @accion = 'borrar'
    BEGIN
        DELETE FROM Agentes WHERE ID = @agente_id
    END
    ELSE IF @accion = 'modificar'
    BEGIN
        UPDATE Agentes SET 
            Nombre = @agente_nombre,
            Email = @agente_email,
            Telefono = @agente_telefono
        WHERE ID = @agente_id
    END
    ELSE IF @accion = 'consultar'
    BEGIN
        SELECT * FROM Agentes
    END
    ELSE
    BEGIN
        SELECT 'Acción no válida'
    END
END
go

EXEC GestionarAgentes 'agregar', NULL, 'Nuevo Agente', 'nuevo@example.com', '123-456-7890'
EXEC GestionarAgentes 'borrar', 4
EXEC GestionarAgentes 'modificar', 1, 'Juan Pérez Modificado', 'juan_modificado@example.com', '123-456-7890'
EXEC GestionarAgentes 'consultar'


-- Agregar tabla UsuariosLogin
CREATE TABLE UsuariosLogin (
    ID INT IDENTITY PRIMARY KEY,
    NombreUsuario VARCHAR(50),
    Contraseña VARCHAR(255) 
)
GO

-- Insertar usuarios de ejemplo
INSERT INTO UsuariosLogin (NombreUsuario, Contraseña) VALUES
('Jonathan', '231118'), 
('David', '123')  
GO

CREATE PROCEDURE LoginUsuario
    @nombre_usuario VARCHAR(50),
    @contraseña VARCHAR(255)
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM UsuariosLogin
        WHERE NombreUsuario = @nombre_usuario AND Contraseña = @contraseña
    )
    BEGIN
        SELECT 'Login exitoso' AS Estado
    END
    ELSE
    BEGIN
        SELECT 'Credenciales incorrectas' AS Estado
    END
END
GO

CREATE PROCEDURE GestionarClientes
    @accion NVARCHAR(10),
    @cliente_id INT = NULL,
    @cliente_nombre NVARCHAR(50) = NULL,
    @cliente_email NVARCHAR(100) = NULL,
    @cliente_telefono NVARCHAR(20) = NULL
AS
BEGIN
    IF @accion = 'agregar'
    BEGIN
        INSERT INTO Clientes (Nombre, Email, Telefono) VALUES (@cliente_nombre, @cliente_email, @cliente_telefono)
    END
    ELSE IF @accion = 'borrar'
    BEGIN
        DELETE FROM Clientes WHERE ID = @cliente_id
    END
    ELSE IF @accion = 'modificar'
    BEGIN
        UPDATE Clientes SET 
            Nombre = @cliente_nombre,
            Email = @cliente_email,
            Telefono = @cliente_telefono
        WHERE ID = @cliente_id
    END
    ELSE IF @accion = 'consultar'
    BEGIN
        SELECT * FROM Clientes
    END
    ELSE
    BEGIN
        SELECT 'Acción no válida' AS Error
    END
END
go

-- Ejemplos de uso del procedimiento almacenado GestionarClientes
EXEC GestionarClientes 'agregar', NULL, 'Nuevo Cliente', 'nuevo_cliente@example.com', '123-456-7890'
EXEC GestionarClientes 'borrar', 4
EXEC GestionarClientes 'modificar', 1, 'Cliente Modificado', 'cliente_modificado@example.com', '123-456-7890'
EXEC GestionarClientes 'consultar'




select * from UsuariosLogin
select * from Agentes
select * from UsuariosLogin
select * from UsuariosLogin