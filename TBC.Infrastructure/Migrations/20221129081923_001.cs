using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TBC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    PersonalNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonEntity_CityEntity_CityId",
                        column: x => x.CityId,
                        principalTable: "CityEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonNumber",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberType = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PersonEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonNumber", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_PersonNumber_PersonEntity_PersonEntityId",
                        column: x => x.PersonEntityId,
                        principalTable: "PersonEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RelatedPersonEntity",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelatedPersonId = table.Column<int>(type: "int", nullable: false),
                    PersonType = table.Column<int>(type: "int", nullable: true),
                    PersonEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedPersonEntity", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_RelatedPersonEntity_PersonEntity_PersonEntityId",
                        column: x => x.PersonEntityId,
                        principalTable: "PersonEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityEntity_Name",
                table: "CityEntity",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonEntity_CityId",
                table: "PersonEntity",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEntity_FirstName",
                table: "PersonEntity",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEntity_LastName",
                table: "PersonEntity",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEntity_PersonalNumber",
                table: "PersonEntity",
                column: "PersonalNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonNumber_Number",
                table: "PersonNumber",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_PersonNumber_PersonEntityId",
                table: "PersonNumber",
                column: "PersonEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedPersonEntity_PersonEntityId",
                table: "RelatedPersonEntity",
                column: "PersonEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedPersonEntity_PersonType",
                table: "RelatedPersonEntity",
                column: "PersonType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonNumber");

            migrationBuilder.DropTable(
                name: "RelatedPersonEntity");

            migrationBuilder.DropTable(
                name: "PersonEntity");

            migrationBuilder.DropTable(
                name: "CityEntity");
        }
    }
}
