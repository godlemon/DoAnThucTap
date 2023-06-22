using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnThucTap.Migrations
{
    /// <inheritdoc />
    public partial class lemon2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "active",
                table: "banners",
                newName: "Active");

            migrationBuilder.AddColumn<string>(
                name: "BannerImg",
                table: "banners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BannerImg",
                table: "banners");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "banners",
                newName: "active");
        }
    }
}
