using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class msy2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamDuration",
                table: "Exam");

            migrationBuilder.AddColumn<string>(
                name: "IsVerify",
                table: "AspNetUsers",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVerify",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ExamDuration",
                table: "Exam",
                type: "int",
                nullable: true);
        }
    }
}
