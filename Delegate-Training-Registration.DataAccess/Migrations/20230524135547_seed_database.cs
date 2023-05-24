using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Delegate_Training_Registration.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seed_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TrainingCost",
                table: "Trainings",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseCode", "CourseDescription", "CourseName" },
                values: new object[,]
                {
                    { new Guid("7aaa6300-d539-45de-b0a1-2f4d5750f75b"), "Numbers & operators", "Mathematics" },
                    { new Guid("e288a507-bb38-477e-b985-c7afd1ee8057"), "Software & hardware", "Computer science" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "CompanyName", "Dietary", "Email", "FirstName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("8ce12c33-3a41-483c-b3ed-5c079c3762f7"), "Epoch", 1, "P1@gmail.com", "P1", 625896325 },
                    { new Guid("d72c6fef-e0b4-4e85-a630-b026118eef13"), "Namtek", 0, "P2@gmail.com", "P2", 786525896 }
                });

            migrationBuilder.InsertData(
                table: "PhysicalAddresses",
                columns: new[] { "PhysicalAddressesID", "PersonID", "PostalCode", "StreetAddress" },
                values: new object[,]
                {
                    { new Guid("c6b59163-5a28-42ce-952c-f5b0b390865a"), new Guid("8ce12c33-3a41-483c-b3ed-5c079c3762f7"), 1111, "P1Street" },
                    { new Guid("e78f535c-d26c-4f18-bcaf-3b01d66942d8"), new Guid("d72c6fef-e0b4-4e85-a630-b026118eef13"), 1100, "P2Street" }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "TrainingID", "AvailableSeats", "CourseCode", "TrainingCost", "TrainingDate", "TrainingName", "TrainingRegistrationClosingDate", "TrainingVenue" },
                values: new object[,]
                {
                    { new Guid("7c45fd03-f621-418d-92b5-541364f13e97"), 10, new Guid("e288a507-bb38-477e-b985-c7afd1ee8057"), 299.33m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CSC101", new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lab Center" },
                    { new Guid("eb0551e1-87ff-4e9e-8806-8be3b2413674"), 20, new Guid("7aaa6300-d539-45de-b0a1-2f4d5750f75b"), 599.33m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MTM101", new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accounting Center" }
                });

            migrationBuilder.InsertData(
                table: "RegisteredTrainings",
                columns: new[] { "RegisteredTrainingsID", "PersonID", "TrainingID" },
                values: new object[,]
                {
                    { new Guid("33372fd5-4c85-4b76-bbed-58f0365dbc74"), new Guid("d72c6fef-e0b4-4e85-a630-b026118eef13"), new Guid("eb0551e1-87ff-4e9e-8806-8be3b2413674") },
                    { new Guid("59417cdd-0875-4385-bf11-c692583912f0"), new Guid("8ce12c33-3a41-483c-b3ed-5c079c3762f7"), new Guid("7c45fd03-f621-418d-92b5-541364f13e97") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PhysicalAddresses",
                keyColumn: "PhysicalAddressesID",
                keyValue: new Guid("c6b59163-5a28-42ce-952c-f5b0b390865a"));

            migrationBuilder.DeleteData(
                table: "PhysicalAddresses",
                keyColumn: "PhysicalAddressesID",
                keyValue: new Guid("e78f535c-d26c-4f18-bcaf-3b01d66942d8"));

            migrationBuilder.DeleteData(
                table: "RegisteredTrainings",
                keyColumn: "RegisteredTrainingsID",
                keyValue: new Guid("33372fd5-4c85-4b76-bbed-58f0365dbc74"));

            migrationBuilder.DeleteData(
                table: "RegisteredTrainings",
                keyColumn: "RegisteredTrainingsID",
                keyValue: new Guid("59417cdd-0875-4385-bf11-c692583912f0"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonID",
                keyValue: new Guid("8ce12c33-3a41-483c-b3ed-5c079c3762f7"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonID",
                keyValue: new Guid("d72c6fef-e0b4-4e85-a630-b026118eef13"));

            migrationBuilder.DeleteData(
                table: "Trainings",
                keyColumn: "TrainingID",
                keyValue: new Guid("7c45fd03-f621-418d-92b5-541364f13e97"));

            migrationBuilder.DeleteData(
                table: "Trainings",
                keyColumn: "TrainingID",
                keyValue: new Guid("eb0551e1-87ff-4e9e-8806-8be3b2413674"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseCode",
                keyValue: new Guid("7aaa6300-d539-45de-b0a1-2f4d5750f75b"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseCode",
                keyValue: new Guid("e288a507-bb38-477e-b985-c7afd1ee8057"));

            migrationBuilder.AlterColumn<decimal>(
                name: "TrainingCost",
                table: "Trainings",
                type: "decimal(4,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");
        }
    }
}
