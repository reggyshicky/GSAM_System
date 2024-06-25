using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class External : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ClaimRequestDetails",
                table: "Internals",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "ApproverRemarks",
                table: "Internals",
                type: "nvarchar(600)",
                maxLength: 600,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ClaimAmount",
                table: "Internals",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Externals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ServiceProvider = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ClaimAmount = table.Column<decimal>(type: "money", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClaimRequestDetails = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ApproverRemarks = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    CreatedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VerifiedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    VerifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DeletedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RejectedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    RejectedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    RejectedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Externals", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Externals");

            migrationBuilder.DropColumn(
                name: "ApproverRemarks",
                table: "Internals");

            migrationBuilder.DropColumn(
                name: "ClaimAmount",
                table: "Internals");

            migrationBuilder.AlterColumn<string>(
                name: "ClaimRequestDetails",
                table: "Internals",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }
    }
}
