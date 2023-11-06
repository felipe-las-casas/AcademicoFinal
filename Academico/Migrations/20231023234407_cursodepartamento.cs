using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academico.Migrations
{
    /// <inheritdoc />
    public partial class cursodepartamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AlunosDisciplinas",
                table: "AlunosDisciplinas");

            migrationBuilder.AddColumn<long>(
                name: "DepartamentoId",
                table: "Cursos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlunosDisciplinas",
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "Semestre", "Ano" });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_DepartamentoId",
                table: "Cursos",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Departamentos_DepartamentoId",
                table: "Cursos",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Departamentos_DepartamentoId",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_DepartamentoId",
                table: "Cursos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlunosDisciplinas",
                table: "AlunosDisciplinas");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Cursos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlunosDisciplinas",
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" });
        }
    }
}
