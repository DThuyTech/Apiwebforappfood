using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiforapp.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<double>(type: "float", nullable: false),
                    Protein = table.Column<double>(type: "float", nullable: false),
                    Carbohydrates = table.Column<double>(type: "float", nullable: false),
                    Fat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    weigh = table.Column<double>(type: "float", nullable: false),
                    heigh = table.Column<double>(type: "float", nullable: false),
                    gender = table.Column<bool>(type: "bit", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.idUser);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
