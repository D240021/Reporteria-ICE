# Eliminar la imagen antigua de Docker si existe
docker images 'server-sqlserver' -q | ForEach-Object { if ($_ -ne "") { docker rmi --force $_ } }

# Construir la imagen de Docker para SQL Server
docker build -t server-sqlserver .\

# Iniciar el contenedor de SQL Server con el puerto 1433
docker run -d -p 1434:1433 server-sqlserver