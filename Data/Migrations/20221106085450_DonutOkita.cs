using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class DonutOkita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    Ma = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CuaHang",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    Ma = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ThanhPho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QuocGia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuaHang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DongSp",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    Ma = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DongSp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    Ma = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TenDem = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Ho = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "DATE", nullable: false),
                    Sdt = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ThanhPho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QuocGia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MatKhau = table.Column<string>(type: "VARCHAR(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MauSac",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    Ma = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauSac", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nsx",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    Ma = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nsx", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    Ma = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    Ma = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TenDem = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Ho = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "DATE", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sdt = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    MatKhau = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    IdCh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCv = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdGuiBc = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanVien_ChucVu_IdCv",
                        column: x => x.IdCv,
                        principalTable: "ChucVu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVien_CuaHang_IdCh",
                        column: x => x.IdCh,
                        principalTable: "CuaHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVien_NhanVien_IdGuiBc",
                        column: x => x.IdGuiBc,
                        principalTable: "NhanVien",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietSp",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    NamBh = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    GiaNhap = table.Column<decimal>(type: "DECIMAL(20,0)", nullable: false, defaultValue: 0m),
                    GiaBan = table.Column<decimal>(type: "DECIMAL(20,0)", nullable: false, defaultValue: 0m),
                    Anh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdNsx = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMauSac = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDongSp = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietSp_DongSp_IdDongSp",
                        column: x => x.IdDongSp,
                        principalTable: "DongSp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSp_MauSac_IdMauSac",
                        column: x => x.IdMauSac,
                        principalTable: "MauSac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSp_Nsx_IdNsx",
                        column: x => x.IdNsx,
                        principalTable: "Nsx",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSp_SanPham_IdSp",
                        column: x => x.IdSp,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHang",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    Ma = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "DATE", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "DATE", nullable: false),
                    TenNguoiNhan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sdt = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: true),
                    IdKh = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdNv = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TinhTrang = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GioHang_KhachHang_IdKh",
                        column: x => x.IdKh,
                        principalTable: "KhachHang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GioHang_NhanVien_IdNv",
                        column: x => x.IdNv,
                        principalTable: "NhanVien",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    Ma = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayShip = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TinhTrang = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TenNguoiNhan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sdt = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    IdKh = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdNv = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDon_KhachHang_IdKh",
                        column: x => x.IdKh,
                        principalTable: "KhachHang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoaDon_NhanVien_IdNv",
                        column: x => x.IdNv,
                        principalTable: "NhanVien",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GioHangChiTiet",
                columns: table => new
                {
                    IdGioHang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdChiTietSp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "DECIMAL(20,0)", nullable: false, defaultValue: 0m),
                    DonGiaKhiGiam = table.Column<decimal>(type: "DECIMAL(20,0)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangChiTiet", x => new { x.IdGioHang, x.IdChiTietSp });
                    table.ForeignKey(
                        name: "FK_GioHangChiTiet_ChiTietSp_IdChiTietSp",
                        column: x => x.IdChiTietSp,
                        principalTable: "ChiTietSp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GioHangChiTiet_GioHang_IdGioHang",
                        column: x => x.IdGioHang,
                        principalTable: "GioHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonChiTiet",
                columns: table => new
                {
                    IdHoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdChiTietSp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "DECIMAL(20,0)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonChiTiet", x => new { x.IdHoaDon, x.IdChiTietSp });
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiet_ChiTietSp_IdChiTietSp",
                        column: x => x.IdChiTietSp,
                        principalTable: "ChiTietSp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiet_HoaDon_IdHoaDon",
                        column: x => x.IdHoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ChucVu",
                columns: new[] { "Id", "Ma", "Ten" },
                values: new object[] { new Guid("b29ceea6-16a5-4171-9486-621650b569a7"), "NV1", "Trần Nam" });

            migrationBuilder.InsertData(
                table: "CuaHang",
                columns: new[] { "Id", "DiaChi", "Ma", "QuocGia", "Ten", "ThanhPho" },
                values: new object[] { new Guid("b29ceea6-16a5-4171-9486-621650b569a8"), null, "CH1", null, "Minky Store", null });

            migrationBuilder.InsertData(
                table: "DongSp",
                columns: new[] { "Id", "Ma", "Ten" },
                values: new object[] { new Guid("b29ceea6-16a5-4171-9486-621650b569a1"), "DSP1", "Iphone" });

            migrationBuilder.InsertData(
                table: "KhachHang",
                columns: new[] { "Id", "DiaChi", "Ho", "Ma", "MatKhau", "NgaySinh", "QuocGia", "Sdt", "Ten", "TenDem", "ThanhPho" },
                values: new object[] { new Guid("fdb189b3-75f3-4636-9845-39166bb052c2"), null, null, "KH1", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Ánh", null, null });

            migrationBuilder.InsertData(
                table: "MauSac",
                columns: new[] { "Id", "Ma", "Ten" },
                values: new object[,]
                {
                    { new Guid("b29ceea6-16a5-4171-9486-621650b569a2"), "MS1", "Đỏ" },
                    { new Guid("b29ceea6-16a5-4171-9486-621650b569a5"), "MS1", "Trắng" },
                    { new Guid("b29ceea6-16a5-4171-9486-621650b569a6"), "MS1", "Đen" },
                    { new Guid("b29ceea6-16a5-4171-9486-621650b569a8"), "MS1", "Vàng" },
                    { new Guid("b29ceea6-16a5-4171-9486-621650b569a9"), "MS1", "Tím" }
                });

            migrationBuilder.InsertData(
                table: "Nsx",
                columns: new[] { "Id", "Ma", "Ten" },
                values: new object[] { new Guid("b29ceea6-16a5-4171-9486-621650b569a3"), "DSP1", "Apple" });

            migrationBuilder.InsertData(
                table: "SanPham",
                columns: new[] { "Id", "Ma", "Ten" },
                values: new object[] { new Guid("b29ceea6-16a5-4171-9486-621650b569a4"), "SP1", "Iphone 13 Promax" });

            migrationBuilder.InsertData(
                table: "ChiTietSp",
                columns: new[] { "Id", "Anh", "GiaBan", "GiaNhap", "IdDongSp", "IdMauSac", "IdNsx", "IdSp", "MoTa", "NamBh", "SoLuongTon" },
                values: new object[,]
                {
                    { new Guid("145ba541-041b-43fe-be1e-4cc3833789ac"), "https://cdn.tgdd.vn/Products/Images/42/247364/samsung-galaxy-m53-nau-thumb-600x600.jpg", 200000m, 900000m, new Guid("b29ceea6-16a5-4171-9486-621650b569a1"), new Guid("b29ceea6-16a5-4171-9486-621650b569a2"), new Guid("b29ceea6-16a5-4171-9486-621650b569a3"), new Guid("b29ceea6-16a5-4171-9486-621650b569a4"), "", 2002, 50 },
                    { new Guid("3b3339ff-977c-43bf-89ac-1adab4249a47"), "https://cdn.tgdd.vn/Products/Images/42/251703/oppo-a95-4g-bac-2-600x600.jpg", 200000m, 900000m, new Guid("b29ceea6-16a5-4171-9486-621650b569a1"), new Guid("b29ceea6-16a5-4171-9486-621650b569a9"), new Guid("b29ceea6-16a5-4171-9486-621650b569a3"), new Guid("b29ceea6-16a5-4171-9486-621650b569a4"), "", 2002, 50 },
                    { new Guid("8673efa6-de82-4ba0-9b3a-6ee7b18b52c7"), "https://cdn.tgdd.vn/Products/Images/42/230529/TimerThumb/iphone-13-pro-max-(18).jpg", 200000m, 900000m, new Guid("b29ceea6-16a5-4171-9486-621650b569a1"), new Guid("b29ceea6-16a5-4171-9486-621650b569a8"), new Guid("b29ceea6-16a5-4171-9486-621650b569a3"), new Guid("b29ceea6-16a5-4171-9486-621650b569a4"), "", 2002, 50 },
                    { new Guid("cd001834-cc8a-49bb-bd60-1e988b938ccb"), "https://cdn.tgdd.vn/Products/Images/42/247364/samsung-galaxy-m53-nau-thumb-600x600.jpg", 200000m, 900000m, new Guid("b29ceea6-16a5-4171-9486-621650b569a1"), new Guid("b29ceea6-16a5-4171-9486-621650b569a5"), new Guid("b29ceea6-16a5-4171-9486-621650b569a3"), new Guid("b29ceea6-16a5-4171-9486-621650b569a4"), "", 2002, 50 },
                    { new Guid("e1acf252-4aec-4e20-a1bf-1ab75a7ce9f0"), "https://cdn.tgdd.vn/Products/Images/42/247364/samsung-galaxy-m53-nau-thumb-600x600.jpg", 200000m, 900000m, new Guid("b29ceea6-16a5-4171-9486-621650b569a1"), new Guid("b29ceea6-16a5-4171-9486-621650b569a6"), new Guid("b29ceea6-16a5-4171-9486-621650b569a3"), new Guid("b29ceea6-16a5-4171-9486-621650b569a4"), "", 2002, 50 },
                    { new Guid("f1bd014f-87c6-4f78-af7a-229470672145"), "https://cdn.tgdd.vn/Products/Images/42/253402/realme-c21-y-blue-600x600.jpg", 200000m, 900000m, new Guid("b29ceea6-16a5-4171-9486-621650b569a1"), new Guid("b29ceea6-16a5-4171-9486-621650b569a9"), new Guid("b29ceea6-16a5-4171-9486-621650b569a3"), new Guid("b29ceea6-16a5-4171-9486-621650b569a4"), "", 2002, 50 }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "Id", "DiaChi", "GioiTinh", "Ho", "IdCh", "IdCv", "IdGuiBc", "Ma", "MatKhau", "NgaySinh", "Sdt", "Ten", "TenDem" },
                values: new object[] { new Guid("8850d2ff-77d5-476e-9123-f1a8864babe2"), "Hà Nội", "Nam", "Nguyễn", new Guid("b29ceea6-16a5-4171-9486-621650b569a8"), new Guid("b29ceea6-16a5-4171-9486-621650b569a7"), null, "NV1", "1234", new DateTime(2022, 11, 6, 15, 54, 49, 711, DateTimeKind.Local).AddTicks(9266), "1234", "Đăng", "Viết Hải" });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSp_IdDongSp",
                table: "ChiTietSp",
                column: "IdDongSp");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSp_IdMauSac",
                table: "ChiTietSp",
                column: "IdMauSac");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSp_IdNsx",
                table: "ChiTietSp",
                column: "IdNsx");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSp_IdSp",
                table: "ChiTietSp",
                column: "IdSp");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_IdKh",
                table: "GioHang",
                column: "IdKh");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_IdNv",
                table: "GioHang",
                column: "IdNv");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiet_IdChiTietSp",
                table: "GioHangChiTiet",
                column: "IdChiTietSp");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IdKh",
                table: "HoaDon",
                column: "IdKh");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IdNv",
                table: "HoaDon",
                column: "IdNv");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiet_IdChiTietSp",
                table: "HoaDonChiTiet",
                column: "IdChiTietSp");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_IdCh",
                table: "NhanVien",
                column: "IdCh");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_IdCv",
                table: "NhanVien",
                column: "IdCv");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_IdGuiBc",
                table: "NhanVien",
                column: "IdGuiBc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GioHangChiTiet");

            migrationBuilder.DropTable(
                name: "HoaDonChiTiet");

            migrationBuilder.DropTable(
                name: "GioHang");

            migrationBuilder.DropTable(
                name: "ChiTietSp");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "DongSp");

            migrationBuilder.DropTable(
                name: "MauSac");

            migrationBuilder.DropTable(
                name: "Nsx");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "CuaHang");
        }
    }
}
