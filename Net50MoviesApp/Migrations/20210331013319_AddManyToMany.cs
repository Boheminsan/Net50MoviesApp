using Microsoft.EntityFrameworkCore.Migrations;

namespace Net50MoviesApp.Migrations
{
    public partial class AddManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieStaff");

            migrationBuilder.AddColumn<string>(
                name: "UserImg",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imdb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crew",
                columns: table => new
                {
                    CrewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew", x => x.CrewId);
                    table.ForeignKey(
                        name: "FK_Crew_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Crew_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    CastId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CharacterName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.CastId);
                    table.ForeignKey(
                        name: "FK_Players_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crew_MovieId",
                table: "Crew",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_PersonId",
                table: "Crew",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_People_UserId",
                table: "People",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_MovieId",
                table: "Players",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PersonId",
                table: "Players",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crew");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropColumn(
                name: "UserImg",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "MovieStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imdb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieStaff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieStaff_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieStaff_UserId",
                table: "MovieStaff",
                column: "UserId",
                unique: true);
        }
    }
}
