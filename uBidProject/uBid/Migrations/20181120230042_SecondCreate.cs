using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace uBid.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "endTime",
                table: "Item",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "highestBid",
                table: "Item",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "longDesc",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "modelNum",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "reservePrice",
                table: "Item",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "serialNum",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "shortDesc",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "startTime",
                table: "Item",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "endTime",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "highestBid",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "longDesc",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "modelNum",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "reservePrice",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "serialNum",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "shortDesc",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "startTime",
                table: "Item");
        }
    }
}
