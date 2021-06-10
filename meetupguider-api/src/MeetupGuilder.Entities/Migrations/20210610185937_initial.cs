using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetupGuilder.Entities.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RSVP",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_RSVP", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RSVP");
        }
    }
}
