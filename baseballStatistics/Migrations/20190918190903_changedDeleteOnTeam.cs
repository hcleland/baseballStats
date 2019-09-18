using Microsoft.EntityFrameworkCore.Migrations;

namespace baseballStatistics.Migrations
{
    public partial class changedDeleteOnTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "64e8e518-3a87-4f70-a790-2a51c0f2be16", "AQAAAAEAACcQAAAAELHfMPlLGUdrvIbv1nTL6n5Zm/TgltVas1HKH3VdGX5hrY71WAi8pUbP2i4+8WxoaA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb1a35e0-0aa9-49d6-b374-ce755c796f6b", "AQAAAAEAACcQAAAAEGSKUJDFThz4zBTlC3uCYkpSa7hYdsDCIaViR5D6t/APc4wXWsgGZd0DdTBFIvLgtQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
