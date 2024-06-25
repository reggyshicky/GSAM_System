using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seruuuu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PfNumber = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ActiveFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    RegisteredTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ModifiedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ActivatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeactivatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DeactivatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DeletedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceBookingId = table.Column<int>(type: "int", nullable: false),
                    Folder = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    UploadedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    UploadedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    VerifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VerifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerifiedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    RejectedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    RejectedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RejectedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Folder = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    LoanAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VerifiedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    UploadedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recovers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CifID = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CaseNumber = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanAccount = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SolId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LoanAmount = table.Column<decimal>(type: "money", nullable: false),
                    LoanPaid = table.Column<decimal>(type: "money", nullable: false),
                    LoanBalance = table.Column<decimal>(type: "money", nullable: false),
                    MonthsInDefault = table.Column<int>(type: "int", nullable: false),
                    RecoveredFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    RecoveredBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    RecoveredTime = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_Recovers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Refinances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CifID = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LoanAccount = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CaseNumber = table.Column<int>(type: "int", nullable: false),
                    LoanBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoanAmount = table.Column<decimal>(type: "money", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SolId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    InitialInstalments = table.Column<decimal>(type: "money", nullable: false),
                    RefinanceAmount = table.Column<decimal>(type: "money", nullable: false),
                    NewInstalments = table.Column<decimal>(type: "money", nullable: false),
                    LoanTenure = table.Column<int>(type: "int", nullable: false),
                    NewLoanTenure = table.Column<int>(type: "int", nullable: false),
                    ApproverRemarks = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    RefinancedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    RefinancedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    RefinancedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_Refinances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    CreatedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ModifiedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    DeletedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restructures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CifID = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LoanAccount = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CaseNumber = table.Column<int>(type: "int", nullable: false),
                    LoanAmount = table.Column<decimal>(type: "money", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SolId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LoanBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InitialInstalments = table.Column<decimal>(type: "money", nullable: false),
                    NewInstalments = table.Column<decimal>(type: "money", nullable: false),
                    LoanTenure = table.Column<int>(type: "int", nullable: false),
                    NewLoanTenure = table.Column<int>(type: "int", nullable: false),
                    ApproverRemarks = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    RestructuredFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    RestructuredBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    RestructuredTime = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_Restructures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    ProviderEmail = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ProviderPostal = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProviderPhoneNumber = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ProviderAccountNumber = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ApproverComments = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    BookedBy = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    BookedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ModifiedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerifiedBy = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    VerifiedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    VerifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DeletedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RejectedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    RejectedBy = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    RejectedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosedBy = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CloseTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceBookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    CreatedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ModifiedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    DeletedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchCode = table.Column<int>(type: "int", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleNameId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetRoles_RoleNameId",
                        column: x => x.RoleNameId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    CaseNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CifId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    LoanAmount = table.Column<decimal>(type: "money", nullable: false),
                    LoanBalance = table.Column<decimal>(type: "money", nullable: false),
                    LoanAccount = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LoanTenure = table.Column<int>(type: "int", nullable: false),
                    SolId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ApproverRemarks = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SyndicatedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Assigned = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    AssignedEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AssignedId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    AssignedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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
                    RejectedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CloseTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RestructuredFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    RefinancedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    RecoveredFlag = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.CaseNumber);
                    table.ForeignKey(
                        name: "FK_Cases_AspNetUsers_AssignedId",
                        column: x => x.AssignedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Postal = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    CreatedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DeletedFlag = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviders_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceProviders_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_AssignedId",
                table: "Cases",
                column: "AssignedId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_LoanAccount",
                table: "Cases",
                column: "LoanAccount",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleNameId",
                table: "Employees",
                column: "RoleNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Refinances_LoanAccount",
                table: "Refinances",
                column: "LoanAccount",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_RegionName",
                table: "Regions",
                column: "RegionName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restructures_LoanAccount",
                table: "Restructures",
                column: "LoanAccount",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_RegionId",
                table: "ServiceProviders",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_ServiceId",
                table: "ServiceProviders",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceName",
                table: "Services",
                column: "ServiceName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BookingDocuments");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Recovers");

            migrationBuilder.DropTable(
                name: "Refinances");

            migrationBuilder.DropTable(
                name: "Restructures");

            migrationBuilder.DropTable(
                name: "ServiceBookings");

            migrationBuilder.DropTable(
                name: "ServiceProviders");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
