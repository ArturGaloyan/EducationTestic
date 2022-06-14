using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationDproc.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    license_key = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    zipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true),
                    fatherName = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    license_key = table.Column<string>(nullable: true),
                    schoolID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.id);
                    table.ForeignKey(
                        name: "FK_Directors_Schools_schoolID",
                        column: x => x.schoolID,
                        principalTable: "Schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    schoolID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.id);
                    table.ForeignKey(
                        name: "FK_Subjects_Schools_schoolID",
                        column: x => x.schoolID,
                        principalTable: "Schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    license_key = table.Column<string>(nullable: true),
                    schoolID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Teachers_Schools_schoolID",
                        column: x => x.schoolID,
                        principalTable: "Schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ClassNumberSubjects",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    classNumber = table.Column<string>(nullable: true),
                    subjectID = table.Column<int>(nullable: false),
                    schoolID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassNumberSubjects", x => x.id);
                    table.ForeignKey(
                        name: "FK_ClassNumberSubjects_Schools_schoolID",
                        column: x => x.schoolID,
                        principalTable: "Schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClassNumberSubjects_Subjects_subjectID",
                        column: x => x.subjectID,
                        principalTable: "Subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    classNumber = table.Column<string>(nullable: true),
                    classGroup = table.Column<string>(nullable: true),
                    schoolID = table.Column<int>(nullable: false),
                    teacherID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Classes_Schools_schoolID",
                        column: x => x.schoolID,
                        principalTable: "Schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Classes_Teachers_teacherID",
                        column: x => x.teacherID,
                        principalTable: "Teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TestEdus",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    classNumber = table.Column<string>(nullable: true),
                    paragraph = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    isEduStarted = table.Column<int>(nullable: false),
                    subjectID = table.Column<int>(nullable: false),
                    teacherID = table.Column<int>(nullable: false),
                    schoolID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestEdus", x => x.id);
                    table.ForeignKey(
                        name: "FK_TestEdus_Schools_schoolID",
                        column: x => x.schoolID,
                        principalTable: "Schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TestEdus_Subjects_subjectID",
                        column: x => x.subjectID,
                        principalTable: "Subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TestEdus_Teachers_teacherID",
                        column: x => x.teacherID,
                        principalTable: "Teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ClassSubjectsTeachers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    classesID = table.Column<int>(nullable: false),
                    subjectID = table.Column<int>(nullable: false),
                    teacherID = table.Column<int>(nullable: false),
                    schoolID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubjectsTeachers", x => x.id);
                    table.ForeignKey(
                        name: "FK_ClassSubjectsTeachers_Classes_classesID",
                        column: x => x.classesID,
                        principalTable: "Classes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClassSubjectsTeachers_Schools_schoolID",
                        column: x => x.schoolID,
                        principalTable: "Schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClassSubjectsTeachers_Subjects_subjectID",
                        column: x => x.subjectID,
                        principalTable: "Subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClassSubjectsTeachers_Teachers_teacherID",
                        column: x => x.teacherID,
                        principalTable: "Teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    timer = table.Column<int>(nullable: false),
                    point = table.Column<int>(nullable: false),
                    question = table.Column<string>(nullable: true),
                    answer1 = table.Column<string>(nullable: true),
                    answer2 = table.Column<string>(nullable: true),
                    answer3 = table.Column<string>(nullable: true),
                    answer4 = table.Column<string>(nullable: true),
                    order = table.Column<int>(nullable: false),
                    trueAnswer = table.Column<string>(nullable: true),
                    testEduID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Questions_TestEdus_testEduID",
                        column: x => x.testEduID,
                        principalTable: "TestEdus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Testings",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    testingDate = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    classGroup = table.Column<string>(nullable: true),
                    testEduID = table.Column<int>(nullable: false),
                    teacherID = table.Column<int>(nullable: false),
                    schoolID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testings", x => x.id);
                    table.ForeignKey(
                        name: "FK_Testings_Schools_schoolID",
                        column: x => x.schoolID,
                        principalTable: "Schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Testings_Teachers_teacherID",
                        column: x => x.teacherID,
                        principalTable: "Teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Testings_TestEdus_testEduID",
                        column: x => x.testEduID,
                        principalTable: "TestEdus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AnswerStudents",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    answer = table.Column<int>(nullable: false),
                    isTrue = table.Column<int>(nullable: false),
                    point = table.Column<int>(nullable: false),
                    studentID = table.Column<int>(nullable: false),
                    questionID = table.Column<int>(nullable: false),
                    testingID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerStudents", x => x.id);
                    table.ForeignKey(
                        name: "FK_AnswerStudents_Questions_questionID",
                        column: x => x.questionID,
                        principalTable: "Questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AnswerStudents_Students_studentID",
                        column: x => x.studentID,
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AnswerStudents_Testings_testingID",
                        column: x => x.testingID,
                        principalTable: "Testings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TestingResults",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    testingDate = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    classNumber = table.Column<string>(nullable: true),
                    classGroup = table.Column<string>(nullable: true),
                    paragraph = table.Column<string>(nullable: true),
                    isTrueCount = table.Column<int>(nullable: false),
                    isFalseCount = table.Column<int>(nullable: false),
                    isNoneCount = table.Column<int>(nullable: false),
                    resultPoint = table.Column<int>(nullable: false),
                    maxPoint = table.Column<int>(nullable: false),
                    subjectID = table.Column<int>(nullable: false),
                    testEduID = table.Column<int>(nullable: false),
                    testingID = table.Column<int>(nullable: false),
                    studentID = table.Column<int>(nullable: false),
                    teacherID = table.Column<int>(nullable: false),
                    schoolID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestingResults", x => x.id);
                    table.ForeignKey(
                        name: "FK_TestingResults_Schools_schoolID",
                        column: x => x.schoolID,
                        principalTable: "Schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TestingResults_Students_studentID",
                        column: x => x.studentID,
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TestingResults_Subjects_subjectID",
                        column: x => x.subjectID,
                        principalTable: "Subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TestingResults_Teachers_teacherID",
                        column: x => x.teacherID,
                        principalTable: "Teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TestingResults_TestEdus_testEduID",
                        column: x => x.testEduID,
                        principalTable: "TestEdus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TestingResults_Testings_testingID",
                        column: x => x.testingID,
                        principalTable: "Testings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerStudents_questionID",
                table: "AnswerStudents",
                column: "questionID");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerStudents_studentID",
                table: "AnswerStudents",
                column: "studentID");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerStudents_testingID",
                table: "AnswerStudents",
                column: "testingID");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_schoolID",
                table: "Classes",
                column: "schoolID");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_teacherID",
                table: "Classes",
                column: "teacherID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassNumberSubjects_schoolID",
                table: "ClassNumberSubjects",
                column: "schoolID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassNumberSubjects_subjectID",
                table: "ClassNumberSubjects",
                column: "subjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectsTeachers_classesID",
                table: "ClassSubjectsTeachers",
                column: "classesID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectsTeachers_schoolID",
                table: "ClassSubjectsTeachers",
                column: "schoolID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectsTeachers_subjectID",
                table: "ClassSubjectsTeachers",
                column: "subjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectsTeachers_teacherID",
                table: "ClassSubjectsTeachers",
                column: "teacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Directors_schoolID",
                table: "Directors",
                column: "schoolID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_testEduID",
                table: "Questions",
                column: "testEduID");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_schoolID",
                table: "Subjects",
                column: "schoolID");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_schoolID",
                table: "Teachers",
                column: "schoolID");

            migrationBuilder.CreateIndex(
                name: "IX_TestEdus_schoolID",
                table: "TestEdus",
                column: "schoolID");

            migrationBuilder.CreateIndex(
                name: "IX_TestEdus_subjectID",
                table: "TestEdus",
                column: "subjectID");

            migrationBuilder.CreateIndex(
                name: "IX_TestEdus_teacherID",
                table: "TestEdus",
                column: "teacherID");

            migrationBuilder.CreateIndex(
                name: "IX_TestingResults_schoolID",
                table: "TestingResults",
                column: "schoolID");

            migrationBuilder.CreateIndex(
                name: "IX_TestingResults_studentID",
                table: "TestingResults",
                column: "studentID");

            migrationBuilder.CreateIndex(
                name: "IX_TestingResults_subjectID",
                table: "TestingResults",
                column: "subjectID");

            migrationBuilder.CreateIndex(
                name: "IX_TestingResults_teacherID",
                table: "TestingResults",
                column: "teacherID");

            migrationBuilder.CreateIndex(
                name: "IX_TestingResults_testEduID",
                table: "TestingResults",
                column: "testEduID");

            migrationBuilder.CreateIndex(
                name: "IX_TestingResults_testingID",
                table: "TestingResults",
                column: "testingID");

            migrationBuilder.CreateIndex(
                name: "IX_Testings_schoolID",
                table: "Testings",
                column: "schoolID");

            migrationBuilder.CreateIndex(
                name: "IX_Testings_teacherID",
                table: "Testings",
                column: "teacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Testings_testEduID",
                table: "Testings",
                column: "testEduID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerStudents");

            migrationBuilder.DropTable(
                name: "ClassNumberSubjects");

            migrationBuilder.DropTable(
                name: "ClassSubjectsTeachers");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "TestingResults");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Testings");

            migrationBuilder.DropTable(
                name: "TestEdus");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
