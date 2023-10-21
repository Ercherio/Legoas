using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logoas.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_accounts",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_accounts", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_offices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_accountoffices",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_accountoffices", x => new { x.Email, x.OfficeId });
                    table.ForeignKey(
                        name: "FK_tb_tr_accountoffices_tb_m_accounts_Email",
                        column: x => x.Email,
                        principalTable: "tb_m_accounts",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_tr_accountoffices_tb_m_offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "tb_m_offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_account_roles",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_account_roles", x => new { x.Email, x.RoleId });
                    table.ForeignKey(
                        name: "FK_tb_tr_account_roles_tb_m_accounts_Email",
                        column: x => x.Email,
                        principalTable: "tb_m_accounts",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_tr_account_roles_tb_m_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tb_m_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_account_roles_RoleId",
                table: "tb_tr_account_roles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_accountoffices_OfficeId",
                table: "tb_tr_accountoffices",
                column: "OfficeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_tr_account_roles");

            migrationBuilder.DropTable(
                name: "tb_tr_accountoffices");

            migrationBuilder.DropTable(
                name: "tb_m_roles");

            migrationBuilder.DropTable(
                name: "tb_m_accounts");

            migrationBuilder.DropTable(
                name: "tb_m_offices");
        }
    }
}
