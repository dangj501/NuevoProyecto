from mcr.microsoft.com/dotnet/sdk:latest
copy ./Presupuestos /Presupuestos
workdir /Presupuestos
cmd ["dotnet", "run"]