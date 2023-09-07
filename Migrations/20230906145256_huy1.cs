using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiforapp.Migrations
{
    public partial class huy1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "foodParts",
                columns: table => new
                {
                    IdFoodPart = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameFoodPart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fat = table.Column<float>(type: "real", nullable: false),
                    calories = table.Column<float>(type: "real", nullable: false),
                    cacbonhydrat = table.Column<float>(type: "real", nullable: false),
                    protein = table.Column<float>(type: "real", nullable: false),
                    Desciption = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_foodParts", x => x.IdFoodPart);
                });

            migrationBuilder.CreateTable(
                name: "FoodTypes",
                columns: table => new
                {
                    IdFoodType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTypes", x => x.IdFoodType);
                });

            migrationBuilder.CreateTable(
                name: "nutributions",
                columns: table => new
                {
                    IdNutribution = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nutributions", x => x.IdNutribution);
                });

            migrationBuilder.CreateTable(
                name: "Purposes",
                columns: table => new
                {
                    IdPurpose = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    desciption = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purposes", x => x.IdPurpose);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "Statebody",
                columns: table => new
                {
                    IdStatebody = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statebody", x => x.IdStatebody);
                });

            migrationBuilder.CreateTable(
                name: "foods",
                columns: table => new
                {
                    IdFood = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameFoodPart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fat = table.Column<float>(type: "real", nullable: false),
                    calories = table.Column<float>(type: "real", nullable: false),
                    cacbonhydrat = table.Column<float>(type: "real", nullable: false),
                    protein = table.Column<float>(type: "real", nullable: false),
                    Desciption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ratecount = table.Column<int>(type: "int", nullable: false),
                    IdFoodTypes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_foods", x => x.IdFood);
                    table.ForeignKey(
                        name: "FK_foods_FoodTypes_IdFoodTypes",
                        column: x => x.IdFoodTypes,
                        principalTable: "FoodTypes",
                        principalColumn: "IdFoodType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passsword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    weight = table.Column<int>(type: "int", nullable: false),
                    heigh = table.Column<int>(type: "int", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idStatebody = table.Column<int>(type: "int", nullable: false),
                    idRole = table.Column<int>(type: "int", nullable: false),
                    roleIdRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_users_Roles_roleIdRole",
                        column: x => x.roleIdRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_Statebody_idStatebody",
                        column: x => x.idStatebody,
                        principalTable: "Statebody",
                        principalColumn: "IdStatebody",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detailNutributionFoods",
                columns: table => new
                {
                    IdNutributionFood = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFoods = table.Column<int>(type: "int", nullable: false),
                    foodIdFood = table.Column<int>(type: "int", nullable: false),
                    IdNutribution = table.Column<int>(type: "int", nullable: false),
                    nutributionIdNutribution = table.Column<int>(type: "int", nullable: false),
                    level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailNutributionFoods", x => x.IdNutributionFood);
                    table.ForeignKey(
                        name: "FK_detailNutributionFoods_foods_foodIdFood",
                        column: x => x.foodIdFood,
                        principalTable: "foods",
                        principalColumn: "IdFood",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detailNutributionFoods_nutributions_nutributionIdNutribution",
                        column: x => x.nutributionIdNutribution,
                        principalTable: "nutributions",
                        principalColumn: "IdNutribution",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rates",
                columns: table => new
                {
                    IdRate = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idFood = table.Column<int>(type: "int", nullable: false),
                    foodIdFood = table.Column<int>(type: "int", nullable: false),
                    idFoodpart = table.Column<int>(type: "int", nullable: false),
                    foodpartIdFoodPart = table.Column<int>(type: "int", nullable: false),
                    rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rates", x => x.IdRate);
                    table.ForeignKey(
                        name: "FK_rates_foodParts_foodpartIdFoodPart",
                        column: x => x.foodpartIdFoodPart,
                        principalTable: "foodParts",
                        principalColumn: "IdFoodPart",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rates_foods_foodIdFood",
                        column: x => x.foodIdFood,
                        principalTable: "foods",
                        principalColumn: "IdFood",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detailPurposes",
                columns: table => new
                {
                    idPurposedetail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    userIdUser = table.Column<int>(type: "int", nullable: false),
                    idPurpose = table.Column<int>(type: "int", nullable: false),
                    purposeIdPurpose = table.Column<int>(type: "int", nullable: false),
                    level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailPurposes", x => x.idPurposedetail);
                    table.ForeignKey(
                        name: "FK_detailPurposes_Purposes_purposeIdPurpose",
                        column: x => x.purposeIdPurpose,
                        principalTable: "Purposes",
                        principalColumn: "IdPurpose",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detailPurposes_users_userIdUser",
                        column: x => x.userIdUser,
                        principalTable: "users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "diets",
                columns: table => new
                {
                    idDiet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<int>(type: "int", nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    usserIdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diets", x => x.idDiet);
                    table.ForeignKey(
                        name: "FK_diets_users_usserIdUser",
                        column: x => x.usserIdUser,
                        principalTable: "users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detailDietFoods",
                columns: table => new
                {
                    idDetailDietFood = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idFood = table.Column<int>(type: "int", nullable: false),
                    foodIdFood = table.Column<int>(type: "int", nullable: false),
                    idDiet = table.Column<int>(type: "int", nullable: false),
                    dietidDiet = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bref = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailDietFoods", x => x.idDetailDietFood);
                    table.ForeignKey(
                        name: "FK_detailDietFoods_diets_dietidDiet",
                        column: x => x.dietidDiet,
                        principalTable: "diets",
                        principalColumn: "idDiet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detailDietFoods_foods_foodIdFood",
                        column: x => x.foodIdFood,
                        principalTable: "foods",
                        principalColumn: "IdFood",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_detailDietFoods_dietidDiet",
                table: "detailDietFoods",
                column: "dietidDiet");

            migrationBuilder.CreateIndex(
                name: "IX_detailDietFoods_foodIdFood",
                table: "detailDietFoods",
                column: "foodIdFood");

            migrationBuilder.CreateIndex(
                name: "IX_detailNutributionFoods_foodIdFood",
                table: "detailNutributionFoods",
                column: "foodIdFood");

            migrationBuilder.CreateIndex(
                name: "IX_detailNutributionFoods_nutributionIdNutribution",
                table: "detailNutributionFoods",
                column: "nutributionIdNutribution");

            migrationBuilder.CreateIndex(
                name: "IX_detailPurposes_purposeIdPurpose",
                table: "detailPurposes",
                column: "purposeIdPurpose");

            migrationBuilder.CreateIndex(
                name: "IX_detailPurposes_userIdUser",
                table: "detailPurposes",
                column: "userIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_diets_usserIdUser",
                table: "diets",
                column: "usserIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_foods_IdFoodTypes",
                table: "foods",
                column: "IdFoodTypes");

            migrationBuilder.CreateIndex(
                name: "IX_rates_foodIdFood",
                table: "rates",
                column: "foodIdFood");

            migrationBuilder.CreateIndex(
                name: "IX_rates_foodpartIdFoodPart",
                table: "rates",
                column: "foodpartIdFoodPart");

            migrationBuilder.CreateIndex(
                name: "IX_users_idStatebody",
                table: "users",
                column: "idStatebody");

            migrationBuilder.CreateIndex(
                name: "IX_users_roleIdRole",
                table: "users",
                column: "roleIdRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detailDietFoods");

            migrationBuilder.DropTable(
                name: "detailNutributionFoods");

            migrationBuilder.DropTable(
                name: "detailPurposes");

            migrationBuilder.DropTable(
                name: "rates");

            migrationBuilder.DropTable(
                name: "diets");

            migrationBuilder.DropTable(
                name: "nutributions");

            migrationBuilder.DropTable(
                name: "Purposes");

            migrationBuilder.DropTable(
                name: "foodParts");

            migrationBuilder.DropTable(
                name: "foods");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "FoodTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Statebody");
        }
    }
}
