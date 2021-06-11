using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetupGuilder.Entities.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryTopics",
                columns: table => new
                {
                    Country = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Lon = table.Column<float>(nullable: false),
                    Lat = table.Column<float>(nullable: false),
                    TopicName = table.Column<string>(nullable: true),
                    TopicCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTopics", x => x.Country);
                });

            migrationBuilder.CreateTable(
                name: "RSVPCities",
                columns: table => new
                {
                    City = table.Column<string>(nullable: false),
                    GroupId = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    CityCount = table.Column<int>(nullable: false),
                    Lat = table.Column<float>(nullable: false),
                    Lon = table.Column<float>(nullable: false),
                    RsvpId = table.Column<int>(nullable: false),
                    EventId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RSVPCities", x => x.City);
                });

            migrationBuilder.CreateTable(
                name: "RSVPGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<long>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Lon = table.Column<float>(nullable: false),
                    Lat = table.Column<float>(nullable: false),
                    RsvpId = table.Column<int>(nullable: false),
                    Event = table.Column<string>(nullable: true),
                    EventId = table.Column<string>(nullable: true),
                    Mtime = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RSVPGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupTopics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(nullable: false),
                    UrlKey = table.Column<string>(nullable: true),
                    TopicName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_Topics",
                        column: x => x.GroupId,
                        principalTable: "RSVPGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupTopics_GroupId",
                table: "GroupTopics",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryTopics");

            migrationBuilder.DropTable(
                name: "GroupTopics");

            migrationBuilder.DropTable(
                name: "RSVPCities");

            migrationBuilder.DropTable(
                name: "RSVPGroups");
        }
    }
}
