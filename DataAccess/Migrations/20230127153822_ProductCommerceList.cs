using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ProductCommerceList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductCommerceList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a75d8857-6546-4cc0-8ca7-74c51f0ce3f2", "OMFASAGLAM@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEHTE6z0rGAcKQdJqltcv2BmFypfUVcmYAFns6vbNucwb9z8vjwWho9l7uRfCQmavKw==", "5ea2def3-290a-4e86-ac87-8e58fc08edcc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductCommerceList");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0cb7cc5-9701-4337-a461-0374a4ab5e8e", null, null, "AQAAAAEAACcQAAAAEBDCLRp2Rw8TSL0mtfNpkB9aJki+YXc5S2XKKDm57aBkux29QmmYA+LTZdKxJBXp9A==", "124b4d10-b445-4859-972e-721127e23a67" });
        }
    }
}
