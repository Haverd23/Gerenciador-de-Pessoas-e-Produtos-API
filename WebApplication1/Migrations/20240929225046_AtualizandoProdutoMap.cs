using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoProdutoMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Pessoas_PessoaId",
                table: "Produtos");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Pessoas_PessoaId",
                table: "Produtos",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Pessoas_PessoaId",
                table: "Produtos");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Pessoas_PessoaId",
                table: "Produtos",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id");
        }
    }
}
