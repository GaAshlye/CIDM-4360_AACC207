using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace uBidProjectIdentity.Data.Migrations
{
    public partial class TRY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "bidID",
                table: "Item",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Bid",
                columns: table => new
                {
                    bidId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    bidAmount = table.Column<double>(nullable: false),
                    itemID = table.Column<int>(nullable: false),
                    maxBid = table.Column<double>(nullable: false),
                    timeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bid", x => x.bidId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bid");

            migrationBuilder.DropColumn(
                name: "bidID",
                table: "Item");
        }
    }
}
