using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class Criandoroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "223c6c4e-f3bb-4ae8-9144-f224c6af5827");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99997, "4575b424-52e5-4416-a680-cbbf8e2ea9ac", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd3aba61-0201-4a54-b380-a61d40d0bac5", "AQAAAAEAACcQAAAAECqUA5HyYCQd2Sd+E+fo2kouAJ0gg9DNrFr7I+R9rS1y+zG+QymW9FaNGW1az4xpJA==", "3d0ab36b-63b3-45ad-ab56-24e0067b2b2b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "b21d0a75-76e1-4af5-b7d3-a4530863c5a9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2215ce9e-d548-4449-a5ec-9833b01ca7fc", "AQAAAAEAACcQAAAAEF3woqec4dV4zFm9dh65TtYm0AQ4BMv74OAhYlgyQqU5I1kQcSXFCYj3EhMfd0JMmA==", "7a773bf4-b77f-4d46-bf93-1e89bbe3370a" });
        }
    }
}
