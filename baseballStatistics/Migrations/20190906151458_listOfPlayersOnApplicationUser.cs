using Microsoft.EntityFrameworkCore.Migrations;

namespace baseballStatistics.Migrations
{
    public partial class listOfPlayersOnApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1a6ef6f2-4d9d-4c0f-8a35-574d2ae49eb0", "AQAAAAEAACcQAAAAEAbYvmIBE5j9aB99s71OJoGd83qNZAgt1Up41D4vj8YaqCs/ys3Dj99bcpG0aySJhw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4183ffbd-0e01-4248-b930-9d44c2fb80c3", "AQAAAAEAACcQAAAAEH51y73rqS5GntyurjqYmUMIuTlBwM6Vqy+0YbRVBIZKoYp3J3wwaRQQHnyZ82JoDA==" });
        }
    }
}
