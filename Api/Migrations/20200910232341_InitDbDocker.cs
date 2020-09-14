using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace Api.Migrations
{
    public partial class InitDbDocker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserType",
                table: "User",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "PasswordRecovery",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Recovered",
                table: "PasswordRecovery",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Address",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Address",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AddColumn<Geometry>(
                name: "Location",
                table: "Address",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "PasswordRecovery");

            migrationBuilder.DropColumn(
                name: "Recovered",
                table: "PasswordRecovery");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Address");

            migrationBuilder.AlterColumn<int>(
                name: "UserType",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Address",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Address",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
