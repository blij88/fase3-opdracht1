using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneShop.Business.Migrations
{
    public partial class updateEf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Motorola" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Xiaomi" });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "BrandId", "Description", "Price", "Stock", "Type" },
                values: new object[,]
                {
                    { 1, 1, "testing", 54.0, 12, "test1" },
                    { 3, 1, "testing", 54.0, 12, "test3" },
                    { 5, 1, "testing", 54.0, 12, "test5" },
                    { 2, 2, "testing", 54.0, 12, "test2" },
                    { 4, 2, "testing", 54.0, 12, "test4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phones_BrandId",
                table: "Phones",
                column: "BrandId");
        }

    }
}
