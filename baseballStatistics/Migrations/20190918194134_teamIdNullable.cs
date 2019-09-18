using Microsoft.EntityFrameworkCore.Migrations;

namespace baseballStatistics.Migrations
{
    public partial class teamIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Player",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5fe935cb-909d-49ee-90e2-ec125faca0f0", "AQAAAAEAACcQAAAAEDeRtGbT5wIlC0428DfgOAB2FbZTpvw/tkvcOP6glKk8KKAs26bARzi4yoRuZajamg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Player",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "64e8e518-3a87-4f70-a790-2a51c0f2be16", "AQAAAAEAACcQAAAAELHfMPlLGUdrvIbv1nTL6n5Zm/TgltVas1HKH3VdGX5hrY71WAi8pUbP2i4+8WxoaA==" });
        }
    }
}
