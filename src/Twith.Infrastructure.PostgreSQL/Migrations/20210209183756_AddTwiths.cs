using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Twith.Infrastructure.PostgreSQL.Migrations
{
    public partial class AddTwiths : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Twiths",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorFirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    AuthorLastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    AuthorNickName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "varchar(140)", maxLength: 140, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Twiths", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Twiths");
        }
    }
}
