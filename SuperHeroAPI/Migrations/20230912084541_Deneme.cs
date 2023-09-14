using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperHeroAPI.Migrations
{
    /// <inheritdoc />
    public partial class Deneme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserLikes_BookmarkId",
                table: "UserLikes",
                column: "BookmarkId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikes_UserId",
                table: "UserLikes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikes_Bookmarks_BookmarkId",
                table: "UserLikes",
                column: "BookmarkId",
                principalTable: "Bookmarks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikes_Users_UserId",
                table: "UserLikes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLikes_Bookmarks_BookmarkId",
                table: "UserLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikes_Users_UserId",
                table: "UserLikes");

            migrationBuilder.DropIndex(
                name: "IX_UserLikes_BookmarkId",
                table: "UserLikes");

            migrationBuilder.DropIndex(
                name: "IX_UserLikes_UserId",
                table: "UserLikes");
        }
    }
}
