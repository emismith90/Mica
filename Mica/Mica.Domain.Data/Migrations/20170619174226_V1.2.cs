using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mica.Domain.Data.Migrations
{
    public partial class V12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonInChargeId",
                table: "Tickets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PersonInChargeId",
                table: "Tickets",
                column: "PersonInChargeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_PersonInChargeId",
                table: "Tickets",
                column: "PersonInChargeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_PersonInChargeId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_PersonInChargeId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PersonInChargeId",
                table: "Tickets");
        }
    }
}
