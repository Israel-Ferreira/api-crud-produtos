using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCrudProdutos.Migrations
{
    /// <inheritdoc />
    public partial class AddProductSKUForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Produtos_ProdutoSku",
                table: "Estoques");
            

            migrationBuilder.DropIndex(
                name: "IX_Estoques_ProdutoSku",
                table: "Estoques");
            
            
            migrationBuilder.DropColumn(
                name: "ProdutoSku",
                table: "Estoques");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Estoques",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_ProdutoId",
                table: "Estoques",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Produtos_ProdutoId",
                table: "Estoques",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Produtos_ProdutoId",
                table: "Estoques");

            migrationBuilder.DropIndex(
                name: "IX_Estoques_ProdutoId",
                table: "Estoques");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Estoques");

            migrationBuilder.AddColumn<string>(
                name: "TempId",
                table: "Produtos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProdutoSku",
                table: "Estoques",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Produtos_TempId",
                table: "Produtos",
                column: "TempId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_ProdutoSku",
                table: "Estoques",
                column: "ProdutoSku");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Produtos_ProdutoSku",
                table: "Estoques",
                column: "ProdutoSku",
                principalTable: "Produtos",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
