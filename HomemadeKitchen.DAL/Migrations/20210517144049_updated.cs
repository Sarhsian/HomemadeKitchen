using Microsoft.EntityFrameworkCore.Migrations;

namespace HomemadeKitchen.DAL.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clothes_tbl");

            migrationBuilder.DropTable(
                name: "Brands_tbl");

            migrationBuilder.DropColumn(
                name: "BasketClothesId",
                table: "Baskets_tbl");

            migrationBuilder.AddColumn<int>(
                name: "BasketDishesId",
                table: "Baskets_tbl",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dishes_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    TagId = table.Column<int>(nullable: true),
                    ImageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dishes_tbl_Categories_tbl_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dishes_tbl_Images_tbl_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dishes_tbl_Tags_tbl_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_tbl_CategoryId",
                table: "Dishes_tbl",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_tbl_ImageId",
                table: "Dishes_tbl",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_tbl_TagId",
                table: "Dishes_tbl",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dishes_tbl");

            migrationBuilder.DropTable(
                name: "Categories_tbl");

            migrationBuilder.DropColumn(
                name: "BasketDishesId",
                table: "Baskets_tbl");

            migrationBuilder.AddColumn<int>(
                name: "BasketClothesId",
                table: "Baskets_tbl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Brands_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clothes_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: true)
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
    }
}
