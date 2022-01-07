using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contact.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kisiler",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ad = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    soyad = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    firma = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    lastup_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kisiler", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "iletisim_bilgileri",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    kisi_id = table.Column<Guid>(type: "uuid", nullable: false),
                    telefon = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    konum = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    lastup_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iletisim_bilgileri", x => x.id);
                    table.ForeignKey(
                        name: "Iletisim_Bilgileri_Kisi_KisiId_Foreign_Key",
                        column: x => x.kisi_id,
                        principalTable: "kisiler",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "kisiler",
                columns: new[] { "id", "ad", "create_date", "firma", "lastup_date", "soyad" },
                values: new object[,]
                {
                    { new Guid("27714296-cbce-4ad3-a8fa-4980ac44987c"), "ad1", new DateTime(2022, 1, 7, 4, 38, 40, 6, DateTimeKind.Local).AddTicks(5018), "firma1", new DateTime(2022, 1, 7, 4, 38, 40, 6, DateTimeKind.Local).AddTicks(2535), "soyad1" },
                    { new Guid("3acf9782-999a-4364-aee6-c692f9d4ad4f"), "ad2", new DateTime(2022, 1, 7, 4, 38, 40, 6, DateTimeKind.Local).AddTicks(5522), "firma2", new DateTime(2022, 1, 7, 4, 38, 40, 6, DateTimeKind.Local).AddTicks(5510), "soyad2" }
                });

            migrationBuilder.InsertData(
                table: "iletisim_bilgileri",
                columns: new[] { "id", "create_date", "email", "kisi_id", "konum", "lastup_date", "telefon" },
                values: new object[,]
                {
                    { new Guid("1b85d9b8-7b7c-4efc-893e-45045c50d282"), new DateTime(2022, 1, 7, 4, 38, 40, 8, DateTimeKind.Local).AddTicks(1720), "kisi1@gmail.com", new Guid("27714296-cbce-4ad3-a8fa-4980ac44987c"), "ANKARA", new DateTime(2022, 1, 7, 4, 38, 40, 8, DateTimeKind.Local).AddTicks(1729), "(505)999 99 99" },
                    { new Guid("072593f9-cde8-4e75-a20a-c1e923580ae0"), new DateTime(2022, 1, 7, 4, 38, 40, 8, DateTimeKind.Local).AddTicks(3907), "kisi2@gmail.com", new Guid("3acf9782-999a-4364-aee6-c692f9d4ad4f"), "İSTANBUL", new DateTime(2022, 1, 7, 4, 38, 40, 8, DateTimeKind.Local).AddTicks(3912), "(505)555 55 55" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_iletisim_bilgileri_kisi_id",
                table: "iletisim_bilgileri",
                column: "kisi_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "iletisim_bilgileri");

            migrationBuilder.DropTable(
                name: "kisiler");
        }
    }
}
