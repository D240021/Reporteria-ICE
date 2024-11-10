USE ICE_TestDB;

-- Inserci�n de datos en UnidadRegional
INSERT INTO UnidadRegional (NombreUbicacion, Identificador) VALUES ('San Jos�', 'SJ001');
INSERT INTO UnidadRegional (NombreUbicacion, Identificador) VALUES ('Alajuela', 'AL002');
INSERT INTO UnidadRegional (NombreUbicacion, Identificador) VALUES ('Cartago', 'CA003');
INSERT INTO UnidadRegional (NombreUbicacion, Identificador) VALUES ('Heredia', 'HE004');
INSERT INTO UnidadRegional (NombreUbicacion, Identificador) VALUES ('Puntarenas', 'PU005');

-- Inserci�n de datos en Subestacion (asociadas a UnidadRegional)
INSERT INTO Subestacion (NombreUbicacion, Identificador, UnidadRegionalId) VALUES ('Subestacion Central', 'SUB001', 1);
INSERT INTO Subestacion (NombreUbicacion, Identificador, UnidadRegionalId) VALUES ('Subestacion Norte', 'SUB002', 2);
INSERT INTO Subestacion (NombreUbicacion, Identificador, UnidadRegionalId) VALUES ('Subestacion Sur', 'SUB003', 3);
INSERT INTO Subestacion (NombreUbicacion, Identificador, UnidadRegionalId) VALUES ('Subestacion Este', 'SUB004', 4);
INSERT INTO Subestacion (NombreUbicacion, Identificador, UnidadRegionalId) VALUES ('Subestacion Oeste', 'SUB005', 5);

-- Inserci�n de datos en LineaTransmision
INSERT INTO LineaTransmision (NombreUbicacion, Identificador) VALUES ('Linea A', 'LT001');
INSERT INTO LineaTransmision (NombreUbicacion, Identificador) VALUES ('Linea B', 'LT002');
INSERT INTO LineaTransmision (NombreUbicacion, Identificador) VALUES ('Linea C', 'LT003');
INSERT INTO LineaTransmision (NombreUbicacion, Identificador) VALUES ('Linea D', 'LT004');
INSERT INTO LineaTransmision (NombreUbicacion, Identificador) VALUES ('Linea E', 'LT005');

-- Inserci�n de datos en Usuario (asociados opcionalmente a Subestacion y UnidadRegional)
INSERT INTO Usuario (Contrasenia, NombreUsuario, Correo, Nombre, Apellido, Identificador, Rol, SubestacionId, UnidadRegionalId)
VALUES ('password123', 'usuario1', 'usuario1@test.com', 'Juan', 'Perez', 'U001', 'T�cnicos de Lineas', 1, 1);

INSERT INTO Usuario (Contrasenia, NombreUsuario, Correo, Nombre, Apellido, Identificador, Rol, SubestacionId, UnidadRegionalId)
VALUES ('password123', 'usuario2', 'usuario2@test.com', 'Maria', 'Lopez', 'U002', 'T�cnicos de PM', 2, 2);

INSERT INTO Usuario (Contrasenia, NombreUsuario, Correo, Nombre, Apellido, Identificador, Rol, SubestacionId, UnidadRegionalId)
VALUES ('password123', 'usuario3', 'usuario3@test.com', 'Carlos', 'Sanchez', 'U003', 'Supervisor', 3, 3);

INSERT INTO Usuario (Contrasenia, NombreUsuario, Correo, Nombre, Apellido, Identificador, Rol, SubestacionId, UnidadRegionalId)
VALUES ('password123', 'usuario4', 'usuario4@test.com', 'Ana', 'Diaz', 'U004', 'T�cnicos de Lineas', 4, 4);

INSERT INTO Usuario (Contrasenia, NombreUsuario, Correo, Nombre, Apellido, Identificador, Rol, SubestacionId, UnidadRegionalId)
VALUES ('password123', 'usuario5', 'usuario5@test.com', 'Luis', 'Garcia', 'U005', 'T�cnicos de PM', 5, 5);
--El usuario 5 se usa como las pruebas de Registrar Invalidos y Actualizar Invalidos