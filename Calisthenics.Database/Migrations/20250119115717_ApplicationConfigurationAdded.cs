using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Calisthenics.Database.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationConfigurationAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExerciseProgress_Exercises_ExerciseId1",
                table: "UserExerciseProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Users_UserId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_UserId",
                table: "Workouts");

            migrationBuilder.RenameColumn(
                name: "ExerciseId1",
                table: "UserExerciseProgress",
                newName: "ExerciseEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_UserExerciseProgress_ExerciseId1",
                table: "UserExerciseProgress",
                newName: "IX_UserExerciseProgress_ExerciseEntityId");

            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "Workouts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ApplicationConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationConfigurations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ApplicationConfigurations",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[,]
                {
                    { 1, "AppName", "Calisthenics Coach" },
                    { 2, "Environment", "Development" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_UserEntityId",
                table: "Workouts",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExerciseProgress_Exercises_ExerciseEntityId",
                table: "UserExerciseProgress",
                column: "ExerciseEntityId",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Users_UserEntityId",
                table: "Workouts",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExerciseProgress_Exercises_ExerciseEntityId",
                table: "UserExerciseProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Users_UserEntityId",
                table: "Workouts");

            migrationBuilder.DropTable(
                name: "ApplicationConfigurations");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_UserEntityId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Workouts");

            migrationBuilder.RenameColumn(
                name: "ExerciseEntityId",
                table: "UserExerciseProgress",
                newName: "ExerciseId1");

            migrationBuilder.RenameIndex(
                name: "IX_UserExerciseProgress_ExerciseEntityId",
                table: "UserExerciseProgress",
                newName: "IX_UserExerciseProgress_ExerciseId1");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_UserId",
                table: "Workouts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExerciseProgress_Exercises_ExerciseId1",
                table: "UserExerciseProgress",
                column: "ExerciseId1",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Users_UserId",
                table: "Workouts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
