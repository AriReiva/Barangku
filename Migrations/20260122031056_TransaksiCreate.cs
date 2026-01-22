using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barangku.Migrations
{
    /// <inheritdoc />
    public partial class TransaksiCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transaksi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tanggal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bayar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kembali = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaksi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaksi_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailTransaksi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransaksiId = table.Column<int>(type: "int", nullable: false),
                    ProdukId = table.Column<int>(type: "int", nullable: false),
                    Jumlah = table.Column<int>(type: "int", nullable: false),
                    Harga = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailTransaksi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailTransaksi_Produk_ProdukId",
                        column: x => x.ProdukId,
                        principalTable: "Produk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailTransaksi_Transaksi_TransaksiId",
                        column: x => x.TransaksiId,
                        principalTable: "Transaksi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailTransaksi_ProdukId",
                table: "DetailTransaksi",
                column: "ProdukId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailTransaksi_TransaksiId",
                table: "DetailTransaksi",
                column: "TransaksiId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaksi_UserId",
                table: "Transaksi",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailTransaksi");

            migrationBuilder.DropTable(
                name: "Transaksi");
        }
    }
}
