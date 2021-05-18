using Microsoft.EntityFrameworkCore.Migrations;

namespace HomemadeKitchen.DAL.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baskets_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentUser = table.Column<string>(nullable: true),
                    BasketClothesId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    isProcessed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderInfo_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNum = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderInfo_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clothes_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    BrandId = table.Column<int>(nullable: true),
                    TagId = table.Column<int>(nullable: true),
                    ImageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothes_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clothes_tbl_Brands_tbl_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clothes_tbl_Images_tbl_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clothes_tbl_Tags_tbl_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_tbl_BrandId",
                table: "Clothes_tbl",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_tbl_ImageId",
                table: "Clothes_tbl",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_tbl_TagId",
                table: "Clothes_tbl",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Baskets_tbl");

            migrationBuilder.DropTable(
                name: "Clothes_tbl");

            migrationBuilder.DropTable(
                name: "OrderInfo_tbl");

            migrationBuilder.DropTable(
                name: "Brands_tbl");

            migrationBuilder.DropTable(
                name: "Images_tbl");

            migrationBuilder.DropTable(
                name: "Tags_tbl");
        }
    }
}
