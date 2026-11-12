using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIHelpAssistantWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class FixDocumentChunkRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentChunks_Documents_DocumentId1",
                table: "DocumentChunks");

            migrationBuilder.DropIndex(
                name: "IX_DocumentChunks_DocumentId1",
                table: "DocumentChunks");

            migrationBuilder.DropColumn(
                name: "DocumentId1",
                table: "DocumentChunks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DocumentId1",
                table: "DocumentChunks",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentChunks_DocumentId1",
                table: "DocumentChunks",
                column: "DocumentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentChunks_Documents_DocumentId1",
                table: "DocumentChunks",
                column: "DocumentId1",
                principalTable: "Documents",
                principalColumn: "Id");
        }
    }
}
