using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampusCardWebApi.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "V_UserLog_WebAPIs",
                columns: table => new
                {
                    AccountName = table.Column<string>(nullable: false),
                    EmpCode = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Section = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    
                    table.PrimaryKey("PK_V_UserLog_WebAPIs", x => x.AccountName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "V_UserLog_WebAPIs");
        }
    }
}
