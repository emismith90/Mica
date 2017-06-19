using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mica.Domain.Data.Migrations
{
    public partial class V11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EffortId",
                table: "EffortOperations",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_EffortOperations_EffortId",
                table: "EffortOperations",
                column: "EffortId");

            migrationBuilder.AddForeignKey(
                name: "FK_EffortOperations_Efforts_EffortId",
                table: "EffortOperations",
                column: "EffortId",
                principalTable: "Efforts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EffortOperations_Efforts_EffortId",
                table: "EffortOperations");

            migrationBuilder.DropIndex(
                name: "IX_EffortOperations_EffortId",
                table: "EffortOperations");

            migrationBuilder.DropColumn(
                name: "EffortId",
                table: "EffortOperations");
        }
    }
}
