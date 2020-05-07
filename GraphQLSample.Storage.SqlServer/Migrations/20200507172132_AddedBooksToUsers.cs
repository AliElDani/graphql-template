using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQLSample.Storage.SqlServer.Migrations
{
    public partial class AddedBooksToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Birthday", "Email", "FirstName", "LastName", "WeightLbs" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "alperEb@hotmail.com", "Alper", "Ebicoglu", 198f },
                    { 2, new DateTime(1962, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "bobbo@burgers.com", "Bob", "Burgers", 145f },
                    { 3, new DateTime(1937, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tarris@yahoo.com", "Tim", "Farris", 184f },
                    { 4, new DateTime(1953, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "jodyS@gmail.com", "Jody", "Stevenson", 173f },
                    { 5, new DateTime(1999, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "scott@dunder.com", "Michael", "Scott", 160f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_UserId",
                table: "Book",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
