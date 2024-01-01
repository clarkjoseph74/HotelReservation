﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservation.Ef.Migrations
{
    /// <inheritdoc />
    public partial class updateTablse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Rooms");
        }
    }
}
