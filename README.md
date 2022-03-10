# grupo-ciencias-intranet-services

--Migrations--
dotnet ef dbcontext scaffold "Host=(yourhost);Database=(yourbd);Username=(user);Password=(password);Trust Server Certificate=true;" Npgsql.EntityFrameworkCore.PostgreSQL -o Models
