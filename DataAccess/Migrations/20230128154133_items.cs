using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class items : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76ca3750-e8b1-42ce-b3d9-e403ad9f9466", "AQAAAAEAACcQAAAAEAsty4zBaUFwfUhcB2GUtfgFdzPIzSEWoFWQIFqWKYKOJGAZjp3/vqiQasn/MqXmAg==", "8f03c6ca-7740-4c21-941a-3b8f7b6bd72c" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Gıda" },
                    { 2, "Hijyen" },
                    { 3, "Kıyafet" },
                    { 4, "Elektronik" },
                    { 5, "Kırtasiye" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "PhotoUrl", "ProductName" },
                values: new object[,]
                {
                    { 10, 1, "https://image.pngaaa.com/811/324811-middle.png", "Salça" },
                    { 11, 1, "https://images.migrosone.com/sanalmarket/product/05120000/05120000-a957e2-1650x1650.jpg", "Ekmek" },
                    { 12, 1, "https://productimages.hepsiburada.net/s/44/375/10818919890994.jpg", "Soğan" },
                    { 21, 2, "https://productimages.hepsiburada.net/s/6/375/9729860632626.jpg", "Bez" },
                    { 22, 2, "https://www.ecolabel.com/images/eco-label/deterjan.jpg", "Deterjan" },
                    { 23, 2, "https://cdn.thomasnet.com/insights-images/embedded-images/4399ffd9-4ce9-4ba7-a008-c41bed53921a/cec9fc52-c432-4d7d-8583-77c18c6e7601/FullHD/private-label-soap-suppliers.jpg", "Sabun" },
                    { 31, 3, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRMAKVjxVwhCvmhbnjggKlsehqXzaOr0Mi0yA&usqp=CAU", "Tişört" },
                    { 32, 3, "https://img-incommerce-yargici.mncdn.com/Content/Images/Thumbs/22152666_mor-mini-etek-1yket4104x050.jpeg", "Etek" },
                    { 33, 2, "https://sarar.com/sarar-jam-lacivert-blazer-ceket-4387-blazer-ceket-sarar-3771-43-K.jpg", "Ceket" },
                    { 41, 4, "https://www.monofiyat.com/images/thumbs/0009879_mf-product-shift-0112-wireless-mouse-siyah.jpeg", "Mouse" },
                    { 42, 4, "https://www.dhresource.com/0x0/f2/albu/g5/M01/F2/54/rBVaJFk0tMqAEu5SAADL85n_65Y599.jpg", "Klavye" },
                    { 43, 4, "https://d9v7j6n3.rocketcdn.me/wp-content/uploads/2022/05/oppo-a16-1024x576.jpg", "Akıllı Telefon" },
                    { 51, 5, "https://cdn.shopify.com/s/files/1/0266/6967/8627/products/00_defter_ic_9558d3c7-5d3a-4815-b246-03881fd7b46f_700x700.jpg?v=1603360470", "Defter" },
                    { 52, 5, "https://www.ilpen.com.tr/6706-large_default/koseli-naturel-kursun-kalem.jpg", "Kalem" },
                    { 53, 5, "https://bilimgenc.tubitak.gov.tr/sites/default/files/styles/bp-770px-custom_user_desktop_1x/public/silgi_kapak2.jpg?itok=XzuMmKjw", "Silgi" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e79c35b9-2905-4a61-be0c-d320dc182e11", "AQAAAAEAACcQAAAAEPDaZ921QlcqChfN55x73y7ig7/QZ+v8I30oKCQjggDI+YMu6WVnw4u1hLUJfvgDVw==", "e88b96c4-6d9d-4081-a9d0-49e7cb8d5797" });
        }
    }
}
