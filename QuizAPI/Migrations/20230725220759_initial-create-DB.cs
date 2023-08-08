using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialcreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prashanja",
                columns: table => new
                {
                    PrashanjeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prashanje = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    ImeSlika = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Opcija1 = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Opcija2 = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Opcija3 = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Opcija4 = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Odgovor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prashanja", x => x.PrashanjeId);
                });

            migrationBuilder.CreateTable(
                name: "Ucesnici",
                columns: table => new
                {
                    UcesnikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Lozinka = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Poeni = table.Column<int>(type: "int", nullable: false),
                    Vreme = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ucesnici", x => x.UcesnikId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prashanja");

            migrationBuilder.DropTable(
                name: "Ucesnici");
        }
    }
}
