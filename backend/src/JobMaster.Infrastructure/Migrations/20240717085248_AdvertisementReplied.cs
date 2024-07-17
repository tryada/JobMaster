using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobMaster.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdvertisementReplied : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Replied",
                table: "Advertisements",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReplyDate",
                table: "Advertisements",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Replied",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "ReplyDate",
                table: "Advertisements");
        }
    }
}
