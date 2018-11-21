using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace uBid.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    itemID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.itemID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    address = table.Column<string>(nullable: true),
                    billAddress = table.Column<string>(nullable: true),
                    billZip = table.Column<string>(nullable: true),
                    creditCard = table.Column<long>(nullable: false),
                    emails = table.Column<string>(nullable: true),
                    passWord = table.Column<string>(nullable: true),
                    userName = table.Column<string>(nullable: true),
                    zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
