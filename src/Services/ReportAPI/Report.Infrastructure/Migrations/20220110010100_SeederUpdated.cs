using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Report.Infrastructure.Migrations
{
    public partial class SeederUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastupDate",
                table: "raporlar",
                newName: "lastup_date");

            migrationBuilder.RenameColumn(
                name: "LastupDate",
                table: "rapor_durumlar",
                newName: "lastup_date");

            migrationBuilder.UpdateData(
                table: "rapor_durumlar",
                keyColumn: "id",
                keyValue: new Guid("2143a48a-7190-4ee0-a894-743733ac09b9"),
                columns: new[] { "create_date", "lastup_date" },
                values: new object[] { new DateTime(2022, 1, 10, 4, 1, 0, 234, DateTimeKind.Local).AddTicks(9654), new DateTime(2022, 1, 10, 4, 1, 0, 234, DateTimeKind.Local).AddTicks(9661) });

            migrationBuilder.UpdateData(
                table: "rapor_durumlar",
                keyColumn: "id",
                keyValue: new Guid("54a0bfc0-d88d-4e75-a067-9547e977c926"),
                columns: new[] { "create_date", "lastup_date" },
                values: new object[] { new DateTime(2022, 1, 10, 4, 1, 0, 233, DateTimeKind.Local).AddTicks(8198), new DateTime(2022, 1, 10, 4, 1, 0, 234, DateTimeKind.Local).AddTicks(7723) });

            migrationBuilder.InsertData(
                table: "rapor_durumlar",
                columns: new[] { "id", "create_date", "durum", "lastup_date" },
                values: new object[] { new Guid("1563a48a-7190-4ee0-a894-743733ac09b9"), new DateTime(2022, 1, 10, 4, 1, 0, 234, DateTimeKind.Local).AddTicks(9672), "BİLİNMİYOR", new DateTime(2022, 1, 10, 4, 1, 0, 234, DateTimeKind.Local).AddTicks(9673) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "rapor_durumlar",
                keyColumn: "id",
                keyValue: new Guid("1563a48a-7190-4ee0-a894-743733ac09b9"));

            migrationBuilder.RenameColumn(
                name: "lastup_date",
                table: "raporlar",
                newName: "LastupDate");

            migrationBuilder.RenameColumn(
                name: "lastup_date",
                table: "rapor_durumlar",
                newName: "LastupDate");

            migrationBuilder.UpdateData(
                table: "rapor_durumlar",
                keyColumn: "id",
                keyValue: new Guid("2143a48a-7190-4ee0-a894-743733ac09b9"),
                columns: new[] { "create_date", "LastupDate" },
                values: new object[] { new DateTime(2022, 1, 7, 19, 6, 30, 845, DateTimeKind.Local).AddTicks(6765), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "rapor_durumlar",
                keyColumn: "id",
                keyValue: new Guid("54a0bfc0-d88d-4e75-a067-9547e977c926"),
                columns: new[] { "create_date", "LastupDate" },
                values: new object[] { new DateTime(2022, 1, 7, 19, 6, 30, 844, DateTimeKind.Local).AddTicks(6901), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
