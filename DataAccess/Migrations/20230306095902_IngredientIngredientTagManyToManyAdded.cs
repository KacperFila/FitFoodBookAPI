using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IngredientIngredientTagManyToManyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IngredientIngredientTag",
                columns: table => new
                {
                    IngredientTagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredientsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientIngredientTag", x => new { x.IngredientTagsId, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_IngredientIngredientTag_IngredientTags_IngredientTagsId",
                        column: x => x.IngredientTagsId,
                        principalTable: "IngredientTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientIngredientTag_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientIngredientTag_IngredientsId",
                table: "IngredientIngredientTag",
                column: "IngredientsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientIngredientTag");
        }
    }
}
