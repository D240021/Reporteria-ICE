# Usa la imagen oficial de SQL Server
FROM mcr.microsoft.com/mssql/server:2019-latest

# Configuración de entorno para aceptar la licencia y definir la contraseña de SA
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=YourStrongPassword123

# Crear una base de datos específica para las pruebas
ENV MSSQL_DATABASE ICE_TestDB

# Copiar scripts SQL de inicialización
COPY ./Database/ /usr/config/

# Configurar punto de entrada para ejecutar los scripts SQL después de iniciar SQL Server
CMD /bin/bash -c '/opt/mssql/bin/sqlservr & sleep 30 && /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "$SA_PASSWORD" -i /usr/config/init.sql && wait'
