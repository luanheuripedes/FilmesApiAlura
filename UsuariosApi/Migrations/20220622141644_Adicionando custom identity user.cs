using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class Adicionandocustomidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "1c6103e4-e392-4875-8db0-11166ad0331f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "8bc6371e-dafc-41ce-a0a7-678104849831");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e44c6c1-33e1-4574-a622-5dc393be5baa", "AQAAAAEAACcQAAAAEGrLhKH+bMx3qPwILhuJBUCzHS33eQacW36aMJersJDok0GPGRI9/Bdp3/tJ7L0eHw==", "fd1f1258-b95a-454e-8b7e-42360a4b6a53" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "4575b424-52e5-4416-a680-cbbf8e2ea9ac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "223c6c4e-f3bb-4ae8-9144-f224c6af5827");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd3aba61-0201-4a54-b380-a61d40d0bac5", "AQAAAAEAACcQAAAAECqUA5HyYCQd2Sd+E+fo2kouAJ0gg9DNrFr7I+R9rS1y+zG+QymW9FaNGW1az4xpJA==", "3d0ab36b-63b3-45ad-ab56-24e0067b2b2b" });
        }
    }
}
