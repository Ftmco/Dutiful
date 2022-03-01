using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dutiful.DataBase.Migrations
{
    public partial class ReBuildDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_WorkList_WorkListId",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Team_TeamId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkList_Project_ProjectId",
                table: "WorkList");

            migrationBuilder.DropTable(
                name: "WorkTask");

            migrationBuilder.DropIndex(
                name: "IX_WorkList_ProjectId",
                table: "WorkList");

            migrationBuilder.DropIndex(
                name: "IX_Project_TeamId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Card_WorkListId",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "WorkList");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Card");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "WorkList",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Team",
                newName: "Bio");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Project",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "WorkListId",
                table: "Card",
                newName: "OwnerId");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "WorkList",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ListId",
                table: "Card",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Directory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enum = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "ProjectMembers");

            migrationBuilder.DropTable(
                name: "TaskItem");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "WorkList");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ListId",
                table: "Card");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "WorkList",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Bio",
                table: "Team",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Project",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Card",
                newName: "WorkListId");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "WorkList",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Type",
                table: "Card",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateTable(
                name: "WorkTask",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkTask_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkList_ProjectId",
                table: "WorkList",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_TeamId",
                table: "Project",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_WorkListId",
                table: "Card",
                column: "WorkListId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTask_CardId",
                table: "WorkTask",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_WorkList_WorkListId",
                table: "Card",
                column: "WorkListId",
                principalTable: "WorkList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Team_TeamId",
                table: "Project",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkList_Project_ProjectId",
                table: "WorkList",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");
        }
    }
}
