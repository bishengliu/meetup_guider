using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetupGuilder.Entities.Migrations
{
    public partial class updatemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupTopic_RSVPGroups_RSVPGroupId",
                table: "GroupTopic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupTopic",
                table: "GroupTopic");

            migrationBuilder.DropIndex(
                name: "IX_GroupTopic_RSVPGroupId",
                table: "GroupTopic");

            migrationBuilder.DropColumn(
                name: "RSVPGroupId",
                table: "GroupTopic");

            migrationBuilder.RenameTable(
                name: "GroupTopic",
                newName: "GroupTopics");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupTopics",
                table: "GroupTopics",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTopics_GroupId",
                table: "GroupTopics",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Topics",
                table: "GroupTopics",
                column: "GroupId",
                principalTable: "RSVPGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_Topics",
                table: "GroupTopics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupTopics",
                table: "GroupTopics");

            migrationBuilder.DropIndex(
                name: "IX_GroupTopics_GroupId",
                table: "GroupTopics");

            migrationBuilder.RenameTable(
                name: "GroupTopics",
                newName: "GroupTopic");

            migrationBuilder.AddColumn<int>(
                name: "RSVPGroupId",
                table: "GroupTopic",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupTopic",
                table: "GroupTopic",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTopic_RSVPGroupId",
                table: "GroupTopic",
                column: "RSVPGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTopic_RSVPGroups_RSVPGroupId",
                table: "GroupTopic",
                column: "RSVPGroupId",
                principalTable: "RSVPGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
