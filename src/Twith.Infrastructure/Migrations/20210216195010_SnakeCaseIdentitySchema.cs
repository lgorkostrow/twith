using Microsoft.EntityFrameworkCore.Migrations;

namespace Twith.Infrastructure.Migrations
{
    public partial class SnakeCaseIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Twiths_TwithId",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Twiths",
                table: "Twiths");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Twiths",
                newName: "twiths");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "likes");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "users",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "NickName",
                table: "users",
                newName: "nick_name");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "users",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "users",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "users",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_Users_NickName",
                table: "users",
                newName: "ix_users_nick_name");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                table: "users",
                newName: "ix_users_email_value");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "twiths",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "twiths",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "twiths",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "LikesCount",
                table: "twiths",
                newName: "likes_count");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "twiths",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "AuthorNickName",
                table: "twiths",
                newName: "author_nick_name");

            migrationBuilder.RenameColumn(
                name: "AuthorLastName",
                table: "twiths",
                newName: "author_last_name");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "twiths",
                newName: "author_id");

            migrationBuilder.RenameColumn(
                name: "AuthorFirstName",
                table: "twiths",
                newName: "author_first_name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "likes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "likes",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "TwithId",
                table: "likes",
                newName: "twith_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "likes",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "AuthorNickName",
                table: "likes",
                newName: "author_nick_name");

            migrationBuilder.RenameColumn(
                name: "AuthorLastName",
                table: "likes",
                newName: "author_last_name");

            migrationBuilder.RenameColumn(
                name: "AuthorIdentificator",
                table: "likes",
                newName: "author_id");

            migrationBuilder.RenameColumn(
                name: "AuthorFirstName",
                table: "likes",
                newName: "author_first_name");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_TwithId",
                table: "likes",
                newName: "ix_likes_twith_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_twiths",
                table: "twiths",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_likes",
                table: "likes",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_likes_twiths_twith_id",
                table: "likes",
                column: "twith_id",
                principalTable: "twiths",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_likes_twiths_twith_id",
                table: "likes");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_twiths",
                table: "twiths");

            migrationBuilder.DropPrimaryKey(
                name: "pk_likes",
                table: "likes");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "twiths",
                newName: "Twiths");

            migrationBuilder.RenameTable(
                name: "likes",
                newName: "Likes");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Users",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "nick_name",
                table: "Users",
                newName: "NickName");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "ix_users_nick_name",
                table: "Users",
                newName: "IX_Users_NickName");

            migrationBuilder.RenameIndex(
                name: "ix_users_email_value",
                table: "Users",
                newName: "IX_Users_Email");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Twiths",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Twiths",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Twiths",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "likes_count",
                table: "Twiths",
                newName: "LikesCount");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Twiths",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "author_nick_name",
                table: "Twiths",
                newName: "AuthorNickName");

            migrationBuilder.RenameColumn(
                name: "author_last_name",
                table: "Twiths",
                newName: "AuthorLastName");

            migrationBuilder.RenameColumn(
                name: "author_id",
                table: "Twiths",
                newName: "AuthorId");

            migrationBuilder.RenameColumn(
                name: "author_first_name",
                table: "Twiths",
                newName: "AuthorFirstName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Likes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Likes",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "twith_id",
                table: "Likes",
                newName: "TwithId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Likes",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "author_nick_name",
                table: "Likes",
                newName: "AuthorNickName");

            migrationBuilder.RenameColumn(
                name: "author_last_name",
                table: "Likes",
                newName: "AuthorLastName");

            migrationBuilder.RenameColumn(
                name: "author_id",
                table: "Likes",
                newName: "AuthorIdentificator");

            migrationBuilder.RenameColumn(
                name: "author_first_name",
                table: "Likes",
                newName: "AuthorFirstName");

            migrationBuilder.RenameIndex(
                name: "ix_likes_twith_id",
                table: "Likes",
                newName: "IX_Likes_TwithId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Twiths",
                table: "Twiths",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Twiths_TwithId",
                table: "Likes",
                column: "TwithId",
                principalTable: "Twiths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
