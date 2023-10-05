using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab4_04_10_2023.Migrations
{
    public partial class AddDataToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Course_CourseID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Learner_LearnerID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Learner_Major_MajorID",
                table: "Learner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Major",
                table: "Major");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Learner",
                table: "Learner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Major",
                newName: "Majors");

            migrationBuilder.RenameTable(
                name: "Learner",
                newName: "Learners");

            migrationBuilder.RenameTable(
                name: "Enrollment",
                newName: "Enrollments");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_Learner_MajorID",
                table: "Learners",
                newName: "IX_Learners_MajorID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_LearnerID",
                table: "Enrollments",
                newName: "IX_Enrollments_LearnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_CourseID",
                table: "Enrollments",
                newName: "IX_Enrollments_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Majors",
                table: "Majors",
                column: "MajorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Learners",
                table: "Learners",
                column: "LearnerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments",
                column: "EnrollmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "CourseID");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseID", "Credits", "Title" },
                values: new object[,]
                {
                    { 1050, 3, "Chemistry" },
                    { 4022, 3, "Microeconomics" },
                    { 4041, 3, "Macroeconomics" }
                });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "MajorID", "MajorName" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "Economics" },
                    { 3, "Mathematics" }
                });

            migrationBuilder.InsertData(
                table: "Learners",
                columns: new[] { "LearnerID", "EnrollmentDate", "FirstMidName", "LastName", "MajorID" },
                values: new object[] { 1, new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carson", "Alexander", 1 });

            migrationBuilder.InsertData(
                table: "Learners",
                columns: new[] { "LearnerID", "EnrollmentDate", "FirstMidName", "LastName", "MajorID" },
                values: new object[] { 2, new DateTime(2002, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Meredith", "Alonso", 2 });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "EnrollmentID", "CourseID", "Grade", "LearnerID" },
                values: new object[,]
                {
                    { 1, 1050, 5.5f, 1 },
                    { 2, 4022, 7.5f, 1 },
                    { 3, 1050, 3.5f, 2 },
                    { 4, 4041, 7f, 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_CourseID",
                table: "Enrollments",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Learners_LearnerID",
                table: "Enrollments",
                column: "LearnerID",
                principalTable: "Learners",
                principalColumn: "LearnerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Learners_Majors_MajorID",
                table: "Learners",
                column: "MajorID",
                principalTable: "Majors",
                principalColumn: "MajorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_CourseID",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Learners_LearnerID",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Learners_Majors_MajorID",
                table: "Learners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Majors",
                table: "Majors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Learners",
                table: "Learners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "MajorID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 1050);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 4022);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 4041);

            migrationBuilder.DeleteData(
                table: "Learners",
                keyColumn: "LearnerID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Learners",
                keyColumn: "LearnerID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "MajorID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "MajorID",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Majors",
                newName: "Major");

            migrationBuilder.RenameTable(
                name: "Learners",
                newName: "Learner");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                newName: "Enrollment");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_Learners_MajorID",
                table: "Learner",
                newName: "IX_Learner_MajorID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_LearnerID",
                table: "Enrollment",
                newName: "IX_Enrollment_LearnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_CourseID",
                table: "Enrollment",
                newName: "IX_Enrollment_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Major",
                table: "Major",
                column: "MajorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Learner",
                table: "Learner",
                column: "LearnerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment",
                column: "EnrollmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Course_CourseID",
                table: "Enrollment",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Learner_LearnerID",
                table: "Enrollment",
                column: "LearnerID",
                principalTable: "Learner",
                principalColumn: "LearnerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Learner_Major_MajorID",
                table: "Learner",
                column: "MajorID",
                principalTable: "Major",
                principalColumn: "MajorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
