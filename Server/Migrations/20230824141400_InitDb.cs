using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NguoiDungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDangNhap = table.Column<string>(type: "VARCHAR(16)", maxLength: 16, nullable: false),
                    MatKhau = table.Column<string>(type: "VARCHAR(16)", maxLength: 16, nullable: false),
                    HoTen = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    NgaySinh = table.Column<DateOnly>(type: "DATE", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    SoDienThoai = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: true),
                    DiaChi = table.Column<string>(type: "NVARCHAR(300)", maxLength: 300, nullable: true),
                    HinhAnh = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    VaiTro = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 8, 24, 21, 14, 0, 386, DateTimeKind.Local).AddTicks(7678))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDungs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDungs_TenDangNhap",
                table: "NguoiDungs",
                column: "TenDangNhap",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NguoiDungs");
        }
    }
}
