using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MersisNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxOffice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeCount = table.Column<int>(type: "int", nullable: true),
                    FoundationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContractExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
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
                name: "DepartmentCompany",
                columns: table => new
                {
                    DepartmentCompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentCompany", x => x.DepartmentCompanyID);
                    table.ForeignKey(
                        name: "FK_DepartmentCompany_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentCompany_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActivityStatus = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    JobID = table.Column<int>(type: "int", nullable: true),
                    CompanyID = table.Column<int>(type: "int", nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "JobID");
                });

            migrationBuilder.CreateTable(
                name: "Advances",
                columns: table => new
                {
                    AdvanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvanceType = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    AppUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advances", x => x.AdvanceID);
                    table.ForeignKey(
                        name: "FK_Advances_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                name: "Expenses",
                columns: table => new
                {
                    ExpenseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    AppUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ExpenseID);
                    table.ForeignKey(
                        name: "FK_Expenses_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    LeaveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveType = table.Column<int>(type: "int", nullable: false),
                    LeaveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    AppUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.LeaveID);
                    table.ForeignKey(
                        name: "FK_Leaves_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "c83fd66d-9647-42be-b514-8e67981a525b", "Admin", "ADMIN" },
                    { 2, "c473b1ca-d97d-4368-b6dc-21870951ab3c", "Director", "DIRECTOR" },
                    { 3, "b2abfa45-82c1-4bcd-bffa-9c05932fc64c", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivityStatus", "Address", "BirthDate", "BirthPlace", "CompanyID", "ConcurrencyStamp", "CreationDate", "DeletedDate", "DepartmentID", "Email", "EmailConfirmed", "ImagePath", "JobID", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondLastName", "SecondName", "SecurityStamp", "StartDate", "Status", "TC", "TerminationDate", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, null, "Uskudar", new DateTime(2024, 8, 25, 19, 54, 16, 35, DateTimeKind.Local).AddTicks(557), null, null, "627b19d2-75f0-4210-84ab-677f9fadcc29", null, null, null, "Bora@gmail.com", false, "/images/default.jpg", null, "Yildirim", false, null, null, "Bora", "BORA@GMAIL.COM", "BORA@GMAIL.COM", "AQAAAAIAAYagAAAAEMZPZftJnhUnIfjPJsy/xrYoTNUjK9EQdY46HGp3Iphwp1+JrZfzhUArOxA16Ii2eQ==", null, false, null, null, null, "cfc671b1-31a0-4ce0-91e3-cb8d303e133d", null, null, "11111111111", null, false, "Bora@gmail.com" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyID", "Address", "CompanyName", "CompanyTitle", "ContractExpirationDate", "ContractStartDate", "CreationDate", "DeletedDate", "Email", "EmployeeCount", "FoundationDate", "LogoPath", "MersisNo", "ModifiedDate", "PhoneNumber", "Status", "TaxNo", "TaxOffice" },
                values: new object[,]
                {
                    { 1, "İstanbul", "myob", "Ltd.sti", new DateTime(2028, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "myob@support.com", 15, new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "\\LandingPage\\assets\\img\\clients\\client-1.png", "01111111111111115", null, "0111 222 3344", 1, "9111111111", "İstanbul Vergi Dairesi" },
                    { 2, "Ankara", "Belimo", "A.Ş.", new DateTime(2028, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "belimo@support.com", 15, new DateTime(2005, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "/LandingPage/assets/img/clients/client-2.png", "02222222222222226", null, "0222 333 4455", 1, "9222222222", "Ankara Vergi Dairesi" },
                    { 3, "İzmir", "LifeGroups", "Ltd. Şti.", new DateTime(2028, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "lifegroups@support.com", 15, new DateTime(2010, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "/LandingPage/assets/img/clients/client-3.png", "03333333333333337", null, "0333 444 5566", 1, "9333333333", "İzmir Vergi Dairesi" },
                    { 4, "İzmir", "grabyo", "Ltd. Şti.", new DateTime(2028, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "grabyo@support.com", 15, new DateTime(2010, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "/LandingPage/assets/img/clients/client-4.png", "03333333333333337", null, "0333 444 5566", 1, "9333333333", "İzmir Vergi Dairesi" },
                    { 5, "İzmir", "citrus", "Ltd. Şti.", new DateTime(2028, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "citrus@support.com", 15, new DateTime(2010, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "\\LandingPage\\assets\\img\\clients\\client-5.png", "03333333333333337", null, "0333 444 5566", 1, "9333333333", "İzmir Vergi Dairesi" },
                    { 6, "İzmir", "Trustly", "Ltd. Şti.", new DateTime(2028, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "trustly@support.com", 15, new DateTime(2010, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "/LandingPage/assets/img/clients/client-6.png", "03333333333333337", null, "0333 444 5566", 1, "9333333333", "İzmir Vergi Dairesi" },
                    { 7, "İzmir", "oldendoff", "Ltd. Şti.", new DateTime(2028, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "oldendoff@support.com", 15, new DateTime(2010, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "/LandingPage/assets/img/clients/client-7.png", "03333333333333337", null, "0333 444 5566", 1, "9333333333", "İzmir Vergi Dairesi" },
                    { 8, "İzmir", "Lilly", "Ltd. Şti.", new DateTime(2028, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "lilly@support.com", 15, new DateTime(2010, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/LandingPage/assets/img/clients/client-8.png", "03333333333333337", null, "0333 444 5566", 1, "9333333333", "İzmir Vergi Dairesi" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "CreationDate", "DeletedDate", "DepartmentName", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 1, null, null, "Management", null, null },
                    { 2, null, null, "Research And Development", null, null },
                    { 3, null, null, "Programming", null, null }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobID", "CreationDate", "DeletedDate", "JobName", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 1, null, null, "Director", null, null },
                    { 2, null, null, "Developer", null, null },
                    { 3, null, null, "Data Analyst", null, null },
                    { 4, null, null, "Data Scientist", null, null },
                    { 5, null, null, "Database Expert", null, null },
                    { 6, null, null, "AI Expert", null, null },
                    { 7, null, null, "Human Resources", null, null },
                    { 8, null, null, "Technical Support", null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivityStatus", "Address", "BirthDate", "BirthPlace", "CompanyID", "ConcurrencyStamp", "CreationDate", "DeletedDate", "DepartmentID", "Email", "EmailConfirmed", "ImagePath", "JobID", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondLastName", "SecondName", "SecurityStamp", "StartDate", "Status", "TC", "TerminationDate", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 2, 0, 1, "Antalya", new DateTime(2024, 8, 25, 19, 54, 16, 242, DateTimeKind.Local).AddTicks(2161), null, 1, "e5d27431-19b6-4464-8391-85d9dc1783fd", null, null, 1, "Mahmut@bilgeadam.com", false, null, 1, "Taylan", false, null, null, "Mahmut", "MAHMUT@BİLGEADAM.COM", "MAHMUT@BİLGEADAM.COM", null, null, false, 75000m, null, null, "3a1528ab-5093-40f8-aba1-c0d370e55e93", null, null, "11111111111", null, false, "Mahmut@bilgeadam.com" },
                    { 3, 0, 1, "Kadikoy", new DateTime(2024, 8, 25, 19, 54, 16, 242, DateTimeKind.Local).AddTicks(2242), null, 1, "8f3329ee-4e7e-4f86-96f0-f4e189513c55", null, null, 1, "Eylem@bilgeadam.com", false, null, 2, "Eryılmaz", false, null, null, "Eylem", "EYLEM@BİLGEADAM.COM", "EYLEM@BİLGEADAM.COM", null, null, false, 10000m, null, null, "038b06c1-5286-4a13-babf-6f3a97699de9", null, null, "11111111111", null, false, "Eylem@bilgeadam.com" },
                    { 4, 0, 1, "Ankara", new DateTime(2024, 8, 25, 19, 54, 16, 242, DateTimeKind.Local).AddTicks(2267), null, 1, "4b82c95e-edce-4fd9-abcc-00a56b2d128d", null, null, 1, "Ahmet@bilgeadam.com", false, null, 2, "Yılmaz", false, null, null, "Ahmet", "AHMET@BILGEADAM.COM", "AHMET@BILGEADAM.COM", null, null, false, 10000m, null, null, "caee71ea-99a8-4f06-9d47-ae5b20b0beca", null, null, "22222222222", null, false, "Ahmet@bilgeadam.com" },
                    { 5, 0, 1, "Edirne", new DateTime(2024, 8, 25, 19, 54, 16, 242, DateTimeKind.Local).AddTicks(2418), null, 1, "3e6a53ae-f681-408a-97a6-6808d4f24080", null, null, 1, "Mukul@bilgeadam.com", false, null, 2, "Bekfilavioglu", false, null, null, "Mukul", "MUKUL@BILGEADAM.COM", "MUKUL@BILGEADAM.COM", null, null, false, null, null, null, "ff89ec0d-fdb2-49a0-8faf-2cb4347ea8aa", null, null, "33333333333", null, false, "Mukul@bilgeadam.com" }
                });

            migrationBuilder.InsertData(
                table: "DepartmentCompany",
                columns: new[] { "DepartmentCompanyID", "CompanyID", "CreationDate", "DeletedDate", "DepartmentID", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 1, 1, null, null, 1, null, null },
                    { 2, 2, null, null, 1, null, null },
                    { 3, 3, null, null, 1, null, null },
                    { 4, 1, null, null, 2, null, null },
                    { 5, 2, null, null, 2, null, null },
                    { 6, 3, null, null, 2, null, null },
                    { 7, 1, null, null, 3, null, null },
                    { 8, 2, null, null, 3, null, null },
                    { 9, 3, null, null, 3, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advances_AppUserID",
                table: "Advances",
                column: "AppUserID");

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
                name: "IX_AspNetUsers_CompanyID",
                table: "AspNetUsers",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentID",
                table: "AspNetUsers",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_JobID",
                table: "AspNetUsers",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentCompany_CompanyID",
                table: "DepartmentCompany",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentCompany_DepartmentID",
                table: "DepartmentCompany",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_AppUserID",
                table: "Expenses",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_AppUserID",
                table: "Leaves",
                column: "AppUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advances");

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
                name: "DepartmentCompany");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
