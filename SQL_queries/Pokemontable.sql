--CREATE TABLE Pokemon
--(
--	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
--	[Name] NVARCHAR(25),
--	[Url] NVARCHAR(40),
--	UserId NVARCHAR(450) FOREIGN KEY REFERENCES AspNetUsers(Id)
--);

--Go to tools -> options -> Designers -> Table and Database Designers -> Uncheck (Prevent Saving Changes...)
--Then Right click on table FavPokemon and click Design
--Then select the data type column under row URL and change the Data type to NVARCHAR(200)
--Lastly Save then run the below.

  --ALTER TABLE FavPokemon
  --ADD [Image] NVARCHAR(200);

  --ALTER TABLE FavPokemon
  --ADD Type1 NVARCHAR(30);

  --ALTER TABLE FavPokemon
  --ADD Type2 NVARCHAR(30);

  --Lastly run this command in the Nuget Package Console in Visual Studio to scaffold the changes.
  -- Scaffold-DbContext "Server=.\SQLExpress;Database=PokemonDb;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force