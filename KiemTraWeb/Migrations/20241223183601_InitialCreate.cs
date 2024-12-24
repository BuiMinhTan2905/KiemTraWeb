﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KiemTraWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HocPhan",
                columns: table => new
                {
                    MaHP = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TenHP = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SoTinChi = table.Column<int>(type: "int", nullable: false),
                    SoLuongDuKien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocPhan", x => x.MaHP);
                });

            migrationBuilder.CreateTable(
                name: "NganhHoc",
                columns: table => new
                {
                    MaNganh = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    TenNganh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NganhHoc", x => x.MaNganh);
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    MaSV = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hinh = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MaNganh = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.MaSV);
                    table.ForeignKey(
                        name: "FK_SinhVien_NganhHoc_MaNganh",
                        column: x => x.MaNganh,
                        principalTable: "NganhHoc",
                        principalColumn: "MaNganh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DangKy",
                columns: table => new
                {
                    MaDK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSV = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NgayDK = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangKy", x => x.MaDK);
                    table.ForeignKey(
                        name: "FK_DangKy_SinhVien_MaSV",
                        column: x => x.MaSV,
                        principalTable: "SinhVien",
                        principalColumn: "MaSV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDangKy",
                columns: table => new
                {
                    MaCTDK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDK = table.Column<int>(type: "int", nullable: false),
                    MaHP = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDangKy", x => x.MaCTDK);
                    table.ForeignKey(
                        name: "FK_ChiTietDangKy_DangKy_MaDK",
                        column: x => x.MaDK,
                        principalTable: "DangKy",
                        principalColumn: "MaDK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDangKy_HocPhan_MaHP",
                        column: x => x.MaHP,
                        principalTable: "HocPhan",
                        principalColumn: "MaHP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "NganhHoc",
                columns: new[] { "MaNganh", "TenNganh" },
                values: new object[,]
                {
                    { "CNTT", "Công nghệ thông tin" },
                    { "HTTT", "Hệ thống thông tin" },
                    { "KHMT", "Khoa học máy tính" },
                    { "KTPM", "Kỹ thuật phần mềm" },
                    { "TMDT", "Thương mại điện tử" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDangKy_MaDK",
                table: "ChiTietDangKy",
                column: "MaDK");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDangKy_MaHP",
                table: "ChiTietDangKy",
                column: "MaHP");

            migrationBuilder.CreateIndex(
                name: "IX_DangKy_MaSV",
                table: "DangKy",
                column: "MaSV");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_MaNganh",
                table: "SinhVien",
                column: "MaNganh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDangKy");

            migrationBuilder.DropTable(
                name: "DangKy");

            migrationBuilder.DropTable(
                name: "HocPhan");

            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "NganhHoc");
        }
    }
}
