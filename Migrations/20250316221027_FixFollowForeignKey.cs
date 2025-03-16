using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Familestan.Migrations
{
    /// <inheritdoc />
    public partial class FixFollowForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Members_MemberId",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Members_MemberId1",
                table: "Follows");

            migrationBuilder.DropIndex(
                name: "IX_Follows_MemberId",
                table: "Follows");

            migrationBuilder.DropIndex(
                name: "IX_Follows_MemberId1",
                table: "Follows");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Follows");

            migrationBuilder.DropColumn(
                name: "MemberId1",
                table: "Follows");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MemberId",
                table: "Follows",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MemberId1",
                table: "Follows",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Follows_MemberId",
                table: "Follows",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_MemberId1",
                table: "Follows",
                column: "MemberId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_Members_MemberId",
                table: "Follows",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_Members_MemberId1",
                table: "Follows",
                column: "MemberId1",
                principalTable: "Members",
                principalColumn: "MemberId");
        }
    }
}
