using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calisthenics.Database.Migrations
{
    /// <inheritdoc />
    public partial class ModifyExerciseAndWorkoutEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Workouts_WorkoutId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExerciseProgress_Exercises_ExerciseEntityId",
                table: "UserExerciseProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExerciseProgress_Exercises_ExerciseId",
                table: "UserExerciseProgress");

            migrationBuilder.DropIndex(
                name: "IX_UserExerciseProgress_ExerciseId",
                table: "UserExerciseProgress");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_WorkoutId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "Exercises");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseEntityId",
                table: "UserExerciseProgress",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutEntityId",
                table: "Exercises",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_WorkoutEntityId",
                table: "Exercises",
                column: "WorkoutEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Workouts_WorkoutEntityId",
                table: "Exercises",
                column: "WorkoutEntityId",
                principalTable: "Workouts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExerciseProgress_Exercises_ExerciseEntityId",
                table: "UserExerciseProgress",
                column: "ExerciseEntityId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Workouts_WorkoutEntityId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExerciseProgress_Exercises_ExerciseEntityId",
                table: "UserExerciseProgress");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_WorkoutEntityId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "WorkoutEntityId",
                table: "Exercises");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseEntityId",
                table: "UserExerciseProgress",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                table: "Exercises",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserExerciseProgress_ExerciseId",
                table: "UserExerciseProgress",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_WorkoutId",
                table: "Exercises",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Workouts_WorkoutId",
                table: "Exercises",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExerciseProgress_Exercises_ExerciseEntityId",
                table: "UserExerciseProgress",
                column: "ExerciseEntityId",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExerciseProgress_Exercises_ExerciseId",
                table: "UserExerciseProgress",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
