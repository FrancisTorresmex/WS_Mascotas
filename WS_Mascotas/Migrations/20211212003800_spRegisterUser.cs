using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WS_Mascotas.Migrations
{
    public partial class spRegisterUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			//stored procedure que compara si ya existe el telefono, si existe no inserta nada y retorna un 0, si no existe lo inserta y retorna la id recien agregada
            string procedure = @"CREATE OR ALTER PROCEDURE [dbo].[spRegisterUser]
								@FirstName varchar(MAX),
								@lastName varchar(MAX),
								@CellPhone varchar(MAX),
								@Date datetime2(7)
								AS
								BEGIN
									if((select COUNT(*) from [Users] where CellPhone = @CellPhone) > 0)
									begin										
										select 0  
									end

									else
									begin
										insert into [Users]	(FirstName, lastName, CellPhone, Date) values (@FirstName, @lastName, @CellPhone, @Date)										
										declare @id int = @@IDENTITY 
										select @id
									end									
								END";

			migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			string procedure = @"DROP OR ALTER PROCEDURE [dbo].[spRegisterUser]";
			migrationBuilder.Sql(procedure);
		}
    }
}
