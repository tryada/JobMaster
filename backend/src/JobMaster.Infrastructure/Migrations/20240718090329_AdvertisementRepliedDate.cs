using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobMaster.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdvertisementRepliedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReplyDate",
                table: "Advertisements",
                newName: "RepliedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RepliedDate",
                table: "Advertisements",
                newName: "ReplyDate");
        }
    }
}
