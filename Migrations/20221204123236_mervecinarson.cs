using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication13.Migrations
{
    /// <inheritdoc />
    public partial class mervecinarson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    DepartmentName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "CosRepresantatives",
                columns: table => new
                {
                    CosRepresantativeId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    LastName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CosRepresantatives", x => x.CosRepresantativeId);
                    table.ForeignKey(
                        name: "FK__CosRepresantatives__Depar__398D8EEE",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    LastName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    point = table.Column<int>(type: "int", nullable: true),
                    CosRepresantativeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK__Customers__CosRepresantative__398D8EEE",
                        column: x => x.CosRepresantativeId,
                        principalTable: "CosRepresantatives",
                        principalColumn: "CosRepresantativeId");
                });

            migrationBuilder.CreateTable(
                name: "RequestComplaints",
                columns: table => new
                {
                    RequestComplaintId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    Text = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestComplaints", x => x.RequestComplaintId);
                    table.ForeignKey(
                        name: "FK__RequestComplaints__Customer__398D8EEE",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    CosRepresantativeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totalScore = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    CosRepresantativeId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.CosRepresantativeId);
                    table.ForeignKey(
                        name: "FK_Score_CosRepresantatives_CosRepresantativeId1",
                        column: x => x.CosRepresantativeId1,
                        principalTable: "CosRepresantatives",
                        principalColumn: "CosRepresantativeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Score_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CosRepresantatives_DepartmentId",
                table: "CosRepresantatives",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CosRepresantativeId",
                table: "Customers",
                column: "CosRepresantativeId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestComplaints_CustomerId",
                table: "RequestComplaints",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_CosRepresantativeId1",
                table: "Score",
                column: "CosRepresantativeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Score_CustomerId",
                table: "Score",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestComplaints");

            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "CosRepresantatives");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
