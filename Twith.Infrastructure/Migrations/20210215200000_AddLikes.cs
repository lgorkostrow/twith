using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Twith.Infrastructure.Migrations
{
    public partial class AddLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LikesCount",
                table: "Twiths",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TwithId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorIdentificator = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorFirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    AuthorLastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    AuthorNickName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Twiths_TwithId",
                        column: x => x.TwithId,
                        principalTable: "Twiths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_TwithId",
                table: "Likes",
                column: "TwithId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropColumn(
                name: "LikesCount",
                table: "Twiths");
        }
    }
}
