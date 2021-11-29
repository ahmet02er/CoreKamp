using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_newMessage_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewMessages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageSenderId = table.Column<int>(type: "int", nullable: true),
                    MessageReceiverId = table.Column<int>(type: "int", nullable: true),
                    MessageSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewMessages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_NewMessages_Writers_MessageReceiverId",
                        column: x => x.MessageReceiverId,
                        principalTable: "Writers",
                        principalColumn: "WriterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewMessages_Writers_MessageSenderId",
                        column: x => x.MessageSenderId,
                        principalTable: "Writers",
                        principalColumn: "WriterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewMessages_MessageReceiverId",
                table: "NewMessages",
                column: "MessageReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_NewMessages_MessageSenderId",
                table: "NewMessages",
                column: "MessageSenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewMessages");
        }
    }
}
