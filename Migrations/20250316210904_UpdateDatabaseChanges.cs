using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Familestan.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "MemberPasswordHash",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberOtpCode",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MemberOtpExpiration",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MemberPasswordHash",
                table: "Members");
        }
    }
}
