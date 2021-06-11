using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetupGuilder.Entities.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RSVPGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Lon = table.Column<decimal>(nullable: false),
                    Lat = table.Column<decimal>(nullable: false),
                    RsvpId = table.Column<int>(nullable: false),
                    Event = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: false),
                    Mtime = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RSVPGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupTopic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(nullable: false),
                    UrlKey = table.Column<string>(nullable: true),
                    TopicName = table.Column<string>(nullable: true),
                    RSVPGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTopic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupTopic_RSVPGroups_RSVPGroupId",
                        column: x => x.RSVPGroupId,
                        principalTable: "RSVPGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupTopic_RSVPGroupId",
                table: "GroupTopic",
                column: "RSVPGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupTopic");

            migrationBuilder.DropTable(
                name: "RSVPGroups");
        }
    }
}
