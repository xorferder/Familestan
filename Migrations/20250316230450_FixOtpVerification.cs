using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Familestan.Migrations
{
    /// <inheritdoc />
    public partial class FixOtpVerification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberOtpCode",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MemberOtpExpiration",
                table: "Members");

            migrationBuilder.CreateTable(
                name: "OtpVerifications",
                columns: table => new
                {
                    OtpId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OtpCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtpTarget = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtpType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtpExpiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OtpIsUsed = table.Column<bool>(type: "bit", nullable: false),
                    OtpMemberId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpVerifications", x => x.OtpId);
                    table.ForeignKey(
                        name: "FK_OtpVerifications_Members_OtpMemberId",
                        column: x => x.OtpMemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OtpVerifications_OtpMemberId",
                table: "OtpVerifications",
                column: "OtpMemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtpVerifications");

            migrationBuilder.AddColumn<string>(
                name: "MemberOtpCode",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MemberOtpExpiration",
                table: "Members",
                type: "datetime2",
                nullable: true);
        }
    }
}
