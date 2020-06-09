using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hollywood.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Age = table.Column<byte>(type: "tinyint", nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Award",
                columns: table => new
                {
                    Title = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Year = table.Column<short>(type: "smallint", nullable: false),
                    ActorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Award", x => new { x.Title, x.Year });
                    table.ForeignKey(
                        name: "FK_Award_Actor_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    DirectorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_Director_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Director",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorMovie",
                columns: table => new
                {
                    ActorId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovie", x => new { x.ActorId, x.MovieId });
                    table.ForeignKey(
                        name: "Awarded",
                        column: x => x.ActorId,
                        principalTable: "Actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovie_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "Age", "FullName" },
                values: new object[,]
                {
                    { 1, (byte)55, "Jack Nicholson" },
                    { 2, (byte)68, "Marlon Brando" },
                    { 3, (byte)54, "Robert De Niro" },
                    { 4, (byte)64, "Al Pacino" },
                    { 5, (byte)55, "Tom Hanks" },
                    { 6, (byte)66, "Anthony Hopkins" },
                    { 7, (byte)60, "Denzel Washington" },
                    { 8, (byte)61, "Morgan Freeman" },
                    { 9, (byte)70, "Clint Eastwood" },
                    { 10, (byte)30, "Leonardo DiCaprio" }
                });

            migrationBuilder.InsertData(
                table: "Director",
                columns: new[] { "Id", "FullName" },
                values: new object[,]
                {
                    { 1, "Steven Spielberg" },
                    { 2, "Martin Scorsese" },
                    { 3, "Quentin Jerome Tarantino" },
                    { 4, "Christopher Jonathan James Nolan" }
                });

            migrationBuilder.InsertData(
                table: "Award",
                columns: new[] { "Title", "Year", "ActorId" },
                values: new object[,]
                {
                    { "Oscar", (short)2018, 1 },
                    { "GoldenGlobe", (short)2019, 1 },
                    { "BAFTA", (short)2019, 1 },
                    { "Oscar", (short)2019, 2 },
                    { "BAFTA", (short)2018, 2 },
                    { "GoldenGlobe", (short)2018, 3 }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "DirectorId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Jaws" },
                    { 2, 2, "The Wolf of Wall Street" },
                    { 3, 3, "Pulp Fiction" },
                    { 4, 4, "Interstellar" }
                });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 8, 4 },
                    { 7, 4 },
                    { 4, 4 },
                    { 3, 4 },
                    { 2, 4 },
                    { 10, 3 },
                    { 9, 3 },
                    { 8, 3 },
                    { 4, 3 },
                    { 2, 3 },
                    { 6, 2 },
                    { 5, 2 },
                    { 3, 2 },
                    { 2, 2 },
                    { 1, 2 },
                    { 9, 4 },
                    { 10, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovie_MovieId",
                table: "ActorMovie",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Award_ActorId",
                table: "Award",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_DirectorId",
                table: "Movie",
                column: "DirectorId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMovie");

            migrationBuilder.DropTable(
                name: "Award");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Director");
        }
    }
}
