using Microsoft.EntityFrameworkCore.Migrations;

namespace baseballStatistics.Migrations
{
    public partial class AddFullNameAndJerseyNumberToPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JerseyNumber",
                table: "Player",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb1a35e0-0aa9-49d6-b374-ce755c796f6b", "AQAAAAEAACcQAAAAEGSKUJDFThz4zBTlC3uCYkpSa7hYdsDCIaViR5D6t/APc4wXWsgGZd0DdTBFIvLgtQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JerseyNumber",
                table: "Player");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1a6ef6f2-4d9d-4c0f-8a35-574d2ae49eb0", "AQAAAAEAACcQAAAAEAbYvmIBE5j9aB99s71OJoGd83qNZAgt1Up41D4vj8YaqCs/ys3Dj99bcpG0aySJhw==" });
        }
    }
}
