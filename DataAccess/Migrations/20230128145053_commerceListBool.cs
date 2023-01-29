using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class commerceListBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBought",
                table: "ProductCommerceList",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnMarket",
                table: "CommerceLists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e79c35b9-2905-4a61-be0c-d320dc182e11", "AQAAAAEAACcQAAAAEPDaZ921QlcqChfN55x73y7ig7/QZ+v8I30oKCQjggDI+YMu6WVnw4u1hLUJfvgDVw==", "e88b96c4-6d9d-4081-a9d0-49e7cb8d5797" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBought",
                table: "ProductCommerceList");

            migrationBuilder.DropColumn(
                name: "IsOnMarket",
                table: "CommerceLists");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e849f06-c36f-4f10-936d-0bbdfbdc412c", "AQAAAAEAACcQAAAAECoJvibzl1z6F300XiLEICxUAC8WnoGVsMx03sF69lN7jhRzyWs46sIO88nyj7b8lQ==", "804d3255-0100-4cdf-9bf0-c1153dfabdd6" });
        }
    }
}
