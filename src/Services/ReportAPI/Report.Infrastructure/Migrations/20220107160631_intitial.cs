using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Report.Infrastructure.Migrations
{
    public partial class intitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rapor_durumlar",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    durum = table.Column<string>(type: "varchar(50)", nullable: true),
                    create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastupDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rapor_durumlar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "raporlar",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    durum_id = table.Column<Guid>(type: "uuid", nullable: false),
                    path = table.Column<string>(type: "varchar(150)", nullable: true),
                    create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastupDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_raporlar", x => x.id);
                    table.ForeignKey(
                        name: "Rapor_Rapor_Durum_Durum_Id_Foreign_Key",
                        column: x => x.durum_id,
                        principalTable: "rapor_durumlar",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "rapor_durumlar",
                columns: new[] { "id", "create_date", "durum", "LastupDate" },
                values: new object[,]
                {
                    { new Guid("54a0bfc0-d88d-4e75-a067-9547e977c926"), new DateTime(2022, 1, 7, 19, 6, 30, 844, DateTimeKind.Local).AddTicks(6901), "HAZIRLANIYOR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2143a48a-7190-4ee0-a894-743733ac09b9"), new DateTime(2022, 1, 7, 19, 6, 30, 845, DateTimeKind.Local).AddTicks(6765), "TAMAMLANDI", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_raporlar_durum_id",
                table: "raporlar",
                column: "durum_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "raporlar");

            migrationBuilder.DropTable(
                name: "rapor_durumlar");
        }
    }
}
