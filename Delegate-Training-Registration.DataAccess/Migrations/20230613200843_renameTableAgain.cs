using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Delegate_Training_Registration.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class renameTableAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisteredTrainings");

            migrationBuilder.CreateTable(
                name: "RegisteredDelegateTrainings",
                columns: table => new
                {
                    RegisteredTrainingsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    PersonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredDelegateTrainings", x => x.RegisteredTrainingsID);
                    table.ForeignKey(
                        name: "FK_RegisteredDelegateTrainings_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisteredDelegateTrainings_Trainings_TrainingID",
                        column: x => x.TrainingID,
                        principalTable: "Trainings",
                        principalColumn: "TrainingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RegisteredDelegateTrainings",
                columns: new[] { "RegisteredTrainingsID", "PersonID", "TrainingID" },
                values: new object[,]
                {
                    { new Guid("33372fd5-4c85-4b76-bbed-58f0365dbc74"), new Guid("d72c6fef-e0b4-4e85-a630-b026118eef13"), new Guid("eb0551e1-87ff-4e9e-8806-8be3b2413674") },
                    { new Guid("59417cdd-0875-4385-bf11-c692583912f0"), new Guid("8ce12c33-3a41-483c-b3ed-5c079c3762f7"), new Guid("7c45fd03-f621-418d-92b5-541364f13e97") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredDelegateTrainings_PersonID",
                table: "RegisteredDelegateTrainings",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredDelegateTrainings_TrainingID",
                table: "RegisteredDelegateTrainings",
                column: "TrainingID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisteredDelegateTrainings");

            migrationBuilder.CreateTable(
                name: "RegisteredTrainings",
                columns: table => new
                {
                    RegisteredTrainingsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    PersonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredTrainings", x => x.RegisteredTrainingsID);
                    table.ForeignKey(
                        name: "FK_RegisteredTrainings_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisteredTrainings_Trainings_TrainingID",
                        column: x => x.TrainingID,
                        principalTable: "Trainings",
                        principalColumn: "TrainingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RegisteredTrainings",
                columns: new[] { "RegisteredTrainingsID", "PersonID", "TrainingID" },
                values: new object[,]
                {
                    { new Guid("33372fd5-4c85-4b76-bbed-58f0365dbc74"), new Guid("d72c6fef-e0b4-4e85-a630-b026118eef13"), new Guid("eb0551e1-87ff-4e9e-8806-8be3b2413674") },
                    { new Guid("59417cdd-0875-4385-bf11-c692583912f0"), new Guid("8ce12c33-3a41-483c-b3ed-5c079c3762f7"), new Guid("7c45fd03-f621-418d-92b5-541364f13e97") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredTrainings_PersonID",
                table: "RegisteredTrainings",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredTrainings_TrainingID",
                table: "RegisteredTrainings",
                column: "TrainingID");
        }
    }
}
