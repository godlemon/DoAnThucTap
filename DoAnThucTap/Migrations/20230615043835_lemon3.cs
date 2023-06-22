using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnThucTap.Migrations
{
    /// <inheritdoc />
    public partial class lemon3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BannerImg",
                table: "banners");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BannerImg",
                table: "banners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
