using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class propertyNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProductCommerceList",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e849f06-c36f-4f10-936d-0bbdfbdc412c", "AQAAAAEAACcQAAAAECoJvibzl1z6F300XiLEICxUAC8WnoGVsMx03sF69lN7jhRzyWs46sIO88nyj7b8lQ==", "804d3255-0100-4cdf-9bf0-c1153dfabdd6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProductCommerceList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a75d8857-6546-4cc0-8ca7-74c51f0ce3f2", "AQAAAAEAACcQAAAAEHTE6z0rGAcKQdJqltcv2BmFypfUVcmYAFns6vbNucwb9z8vjwWho9l7uRfCQmavKw==", "5ea2def3-290a-4e86-ac87-8e58fc08edcc" });
        }
    }
}
