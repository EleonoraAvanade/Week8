using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_Layer.Migrations
{
    public partial class Newmigration20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Danno = table.Column<int>(type: "int", nullable: false),
                    TipoPersonaggio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armi", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    Nick = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.Nick);
                });

            migrationBuilder.CreateTable(
                name: "Mostri",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idArma = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mostri", x => x.id);
                    table.ForeignKey(
                        name: "FK_Mostri_Armi_idArma",
                        column: x => x.idArma,
                        principalTable: "Armi",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Eroi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickUtente = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Livello = table.Column<int>(type: "int", nullable: false),
                    Esperienza = table.Column<int>(type: "int", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idArma = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eroi", x => x.id);
                    table.ForeignKey(
                        name: "FK_Eroi_Armi_idArma",
                        column: x => x.idArma,
                        principalTable: "Armi",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Eroi_Utenti_NickUtente",
                        column: x => x.NickUtente,
                        principalTable: "Utenti",
                        principalColumn: "Nick",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Armi",
                columns: new[] { "id", "Danno", "Nome", "TipoPersonaggio" },
                values: new object[,]
                {
                    { 1, 8, "Ascia", "Soldier" },
                    { 2, 5, "Mazza", "Soldier" },
                    { 3, 10, "Spada", "Soldier" },
                    { 4, 8, "Arco e frecce", "Wizard" },
                    { 5, 5, "Bacchetta", "Wizard" },
                    { 6, 10, "Bastone Magico", "Wizard" },
                    { 7, 7, "Arco", "Ghost" },
                    { 8, 5, "Clava", "Ghost" },
                    { 9, 15, "Divinazione", "Lucifer" },
                    { 10, 10, "Fulmine", "Lucifer" },
                    { 11, 8, "Tempesta", "Lucifer" },
                    { 12, 15, "Tempesta oscura", "Lucifer" }
                });

            migrationBuilder.InsertData(
                table: "Mostri",
                columns: new[] { "id", "Categoria", "idArma" },
                values: new object[] { 2, "Ghost", 7 });

            migrationBuilder.InsertData(
                table: "Mostri",
                columns: new[] { "id", "Categoria", "idArma" },
                values: new object[] { 1, "Lucifer", 11 });

            migrationBuilder.CreateIndex(
                name: "IX_Eroi_idArma",
                table: "Eroi",
                column: "idArma");

            migrationBuilder.CreateIndex(
                name: "IX_Eroi_NickUtente",
                table: "Eroi",
                column: "NickUtente");

            migrationBuilder.CreateIndex(
                name: "IX_Mostri_idArma",
                table: "Mostri",
                column: "idArma");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eroi");

            migrationBuilder.DropTable(
                name: "Mostri");

            migrationBuilder.DropTable(
                name: "Utenti");

            migrationBuilder.DropTable(
                name: "Armi");
        }
    }
}
