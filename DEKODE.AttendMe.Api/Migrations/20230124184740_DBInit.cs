using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DEKODE.AttendMe.Data.Contract;

namespace DEKODE.AttendMe.Api.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Organisations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StreetNo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StreetName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Suburb = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactPhone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactEmail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Website = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditUser = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PatronTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditUser = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatronTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SbscrptnTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DevicesAllowed = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditUser = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SbscrptnTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Compliances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrganisationId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditUser = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compliances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compliances_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrganisationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrganisationId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditUser = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganisationUsers_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StaffMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactPhone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactEmail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pin = table.Column<int>(type: "int", nullable: false),
                    RefNo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrganisationId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditUser = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffMembers_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentIncidentActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrganisationId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditUser = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentIncidentActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentIncidentActions_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentIncidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrganisationId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditUser = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentIncidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentIncidents_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentIncidentSymptoms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrganisationId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditUser = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentIncidentSymptoms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentIncidentSymptoms_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentLogReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrganisationId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditUser = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLogReasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentLogReasons_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Grade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrganisationId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditUser = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Patrons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactPhone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactEmail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompanyName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TermsAndConditionCheck = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsAuthorizedToCollect = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ReferenceKeyId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PatronTypeId = table.Column<int>(type: "int", nullable: false),
                    OrganisationId = table.Column<int>(type: "int", nullable: false),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditUser = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patrons_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patrons_PatronTypes_PatronTypeId",
                        column: x => x.PatronTypeId,
                        principalTable: "PatronTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StaffLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LogType = table.Column<int>(type: "int", nullable: false),
                    LogDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffLog_StaffMembers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentIncidentLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IncidentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    StudentIncidentId = table.Column<int>(type: "int", nullable: false),
                    IncidentOther = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StudentIncidentSymptomId = table.Column<int>(type: "int", nullable: false),
                    SymptomsOther = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StudentIncidentActionId = table.Column<int>(type: "int", nullable: false),
                    ActionOther = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentIncidentLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentIncidentLogs_StaffMembers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentIncidentLogs_StudentIncidentActions_StudentIncidentAc~",
                        column: x => x.StudentIncidentActionId,
                        principalTable: "StudentIncidentActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentIncidentLogs_StudentIncidents_StudentIncidentId",
                        column: x => x.StudentIncidentId,
                        principalTable: "StudentIncidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentIncidentLogs_StudentIncidentSymptoms_StudentIncidentS~",
                        column: x => x.StudentIncidentSymptomId,
                        principalTable: "StudentIncidentSymptoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentIncidentLogs_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PatronCompliances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PatronId = table.Column<int>(type: "int", nullable: false),
                    ComplianceId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditUser = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatronCompliances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatronCompliances_Compliances_ComplianceId",
                        column: x => x.ComplianceId,
                        principalTable: "Compliances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatronCompliances_Patrons_PatronId",
                        column: x => x.PatronId,
                        principalTable: "Patrons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PatronStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatronId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditUser = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatronStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatronStudents_Patrons_PatronId",
                        column: x => x.PatronId,
                        principalTable: "Patrons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatronStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OtherReason = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LogDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LogType = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    StudentLogReasonId = table.Column<int>(type: "int", nullable: false),
                    PatronId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditUser = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentLogs_Patrons_PatronId",
                        column: x => x.PatronId,
                        principalTable: "Patrons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentLogs_StudentLogReasons_StudentLogReasonId",
                        column: x => x.StudentLogReasonId,
                        principalTable: "StudentLogReasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentLogs_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VisitorLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VisitingPerson = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Purpose = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    OutDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PatronId = table.Column<int>(type: "int", nullable: false),
                    OrganisationId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditUser = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitorLogs_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitorLogs_Patrons_PatronId",
                        column: x => x.PatronId,
                        principalTable: "Patrons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            // Create Parents table

            migrationBuilder.CreateTable(
            name: "Parents",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Workingwc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                ChildSafety = table.Column<bool>(type: "bit", nullable: false),
                VDS = table.Column<bool>(type: "bit", nullable: false),
                PatronTypeId = table.Column<int>(type: "int", nullable: false),
                StudentId = table.Column<int>(type: "int", nullable: false),
                OrganisationId = table.Column<int>(type: "int", nullable: false),
                Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                AuditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Parents", x => x.Id);
                table.ForeignKey(
                    name: "FK_Parents_Students_StudentId",
                    column: x => x.StudentId,
                    principalTable: "Students",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Parents_Organisations_OrganisationId",
                    column: x => x.OrganisationId,
                    principalTable: "Organisations",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Parents_PatronTypes_PatronTypeId",
                    column: x => x.PatronTypeId,
                    principalTable: "PatronTypes",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");



            // Create Relatives table
            migrationBuilder.CreateTable(
                name: "Relatives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Workingwc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ChildSafety = table.Column<bool>(type: "bit", nullable: false),
                    VDS = table.Column<bool>(type: "bit", nullable: false),
                    PatronTypeId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    OrganisationId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false),
                    AuditUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relatives_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Relatives_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Relatives_PatronTypes_PatronTypeId",
                        column: x => x.PatronTypeId,
                        principalTable: "PatronTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Relatives table"
            )
            .Annotation("MySql:CharSet", "utf8mb4");



            migrationBuilder.InsertData(
                table: "Organisations",
                columns: new[] { "Id", "AuditUser", "ContactEmail", "ContactName", "ContactPhone", "EffectiveEndDate", "EffectiveStartDate", "Guid", "IsDeleted", "Name", "Website", "Country", "PostCode", "State", "StreetName", "StreetNo", "Suburb" },
                values: new object[] { 1, "sys_admin", "gmaxwell@cricnsw.com.au", "Adam Gilchrist", "0421119636", new DateTime(9999, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), new Guid("00000000-0000-0000-0000-000000000000"), false, "Cricket NSW", null, "Australia", "3030", "VIC", "Main Street", "1", "Melbourne" });

            migrationBuilder.InsertData(
                table: "SbscrptnTypes",
                columns: new[] { "Id", "Amount", "AuditUser", "Description", "DevicesAllowed", "EffectiveEndDate", "EffectiveStartDate", "Guid", "IsDeleted" },
                values: new object[] { 1, 1200m, "sys_admin", "Annual", 2, new DateTime(9999, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), new Guid("00000000-0000-0000-0000-000000000000"), false });

            migrationBuilder.InsertData(
                table: "OrganisationUsers",
                columns: new[] { "Id", "AuditUser", "EffectiveEndDate", "EffectiveStartDate", "Email", "FirstName", "Guid", "IsDeleted", "LastName", "OrganisationId", "Password" },
                values: new object[] { 1, "sys_admin", new DateTime(9999, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), "dwarner@cricnsw.com.au", "David", new Guid("00000000-0000-0000-0000-000000000000"), false, "Warner", 1, "$2a$11$0yNqYtIew9pkuD/qpufX0.48klW6qfBZ3oWIsPdnrqjItvPziWyq." });

            migrationBuilder.InsertData(
                table: "OrganisationUsers",
                columns: new[] { "Id", "AuditUser", "EffectiveEndDate", "EffectiveStartDate", "Email", "FirstName", "Guid", "IsDeleted", "LastName", "OrganisationId", "Password" },
                values: new object[] { 2, "sys_admin", new DateTime(9999, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), "pratham369@yahoo.com", "Pratham", new Guid("00000000-0000-0000-0000-000000000000"), false, "Manocha", 1, "$2a$11$0yNqYtIew9pkuD/qpufX0.48klW6qfBZ3oWIsPdnrqjItvPziWyq." });

            migrationBuilder.InsertData(
                table: "PatronTypes",
                columns: new[] { "AuditUser", "EffectiveEndDate", "EffectiveStartDate", "Guid", "IsDeleted", "Name", "Description" },
                values: new object[] { "sys_admin", new DateTime(9999, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), new Guid("00000000-0000-0000-0000-000000000000"), false, "Parent", "" }
                );

            migrationBuilder.InsertData(
                table: "PatronTypes",
                columns: new[] { "AuditUser", "EffectiveEndDate", "EffectiveStartDate", "Guid", "IsDeleted", "Name", "Description" },
                values: new object[] { "sys_admin", new DateTime(9999, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), new Guid("3B4D7784-46AA-4C53-AD29-D99778277AD5"), false, "Parent", "parent" }
                );

            migrationBuilder.InsertData(
                table: "Patrons",
                columns: new[] { "Id", "AuditUser", "EffectiveEndDate", "EffectiveStartDate", "Guid", "IsDeleted", "OrganisationId", "FirstName", "LastName", "ContactPhone", "ContactEmail", "CompanyName", "TermsAndConditionCheck", "IsAuthorizedToCollect", "PatronTypeId" },
                values: new object[] { 1, "sys_admin", new DateTime(9999, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), new Guid("3B4D7784-46AA-4C53-AD29-D99778277AD5"), false, 1, "Pratham", "Manocha", "8527016872", "prathamabcd@gamil.com", "SaathivaCreations", false, false, 2 }
                );

            migrationBuilder.InsertData(
                table: "VisitorLogs",
                columns: new[] { "Id", "AuditUser", "EffectiveEndDate", "EffectiveStartDate", "Guid", "InDateTime", "IsDeleted", "OrganisationId", "OutDateTime", "Purpose", "VisitingPerson", "PatronId" },
                values: new object[] { 1, "sys_admin", new DateTime(9999, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Local), false, 1, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Local), "Pickup", "Father", 1 }
                );

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "FirstName", "LastName", "Grade", "Phone", "Email", "AuditUser", "EffectiveEndDate", "EffectiveStartDate", "Guid", "IsDeleted", "OrganisationId" },
                values: new object[] { "Pak", "Hoe", "11", "9810841257", "pakhoe@pakistan.com", "sys_admin", new DateTime(9999, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), new Guid("00000000-0000-0000-0000-000000000000"), false, 1 }
                );

            // Reference the StudentLogReasons table for foreign key constraint
            migrationBuilder.InsertData(
                table: "StudentLogReasons",
                columns: new[] { "Description", "OrganisationId", "Guid", "EffectiveStartDate", "EffectiveEndDate", "AuditUser", "IsDeleted" },
                values: new object[,]{
    { "Late Arrival", 1, Guid.NewGuid(), new DateTime(2023, 1, 1), new DateTime(9999, 12, 31), "sys_admin", false },
    { "Early Departure", 1, Guid.NewGuid(), new DateTime(2023, 1, 1), new DateTime(9999, 12, 31), "sys_admin", false },
    { "Absent", 1, Guid.NewGuid(), new DateTime(2023, 1, 1), new DateTime(9999, 12, 31), "sys_admin", false },
            });

            // Now insert data into the StudentLogs table
            migrationBuilder.InsertData(
                table: "StudentLogs",
                columns: new[] { "OtherReason", "LogDateTime", "LogType", "StudentId", "StudentLogReasonId", "PatronId", "Guid", "EffectiveStartDate", "EffectiveEndDate", "AuditUser", "IsDeleted" },
                values: new object[,]
                {
                { "Late arrival", new DateTime(2023, 4, 1, 8, 10, 0), 1, 1, 1, 1, Guid.NewGuid(), new DateTime(2023, 4, 1), new DateTime(2023, 4, 30), "sys_admin", false },
                { "Early departure", new DateTime(2023, 4, 1, 15, 45, 0), 2, 1, 2, 1, Guid.NewGuid(), new DateTime(2023, 4, 1), new DateTime(2023, 4, 30), "sys_admin", false },
                { "Absent", new DateTime(2023, 4, 3, 0, 0, 0), 3, 1, 3, 1, Guid.NewGuid(), new DateTime(2023, 4, 3), new DateTime(2023, 4, 3), "sys_admin", false },
                });


            //    migrationBuilder.InsertData(
            //        table: "Relatives",
            //        columns: new[]
            //        {
            //"FirstName", "LastName", "Company", "Phone", "Email", "Workingwc",
            //"ChildSafety", "VDS", "PatronTypeId", "StudentId", "OrganisationId",
            //"Guid", "AuditUser", "IsDeleted"
            //        },
            //        values: new object[,]
            //        {
            //{ "John", "Doe", "ABC Company", "1234567890", "john.doe@example.com", "Working", true, true, 1, 1, 1, Guid.NewGuid(), "Admin", false },
            //{ "Jane", "Smith", "XYZ Company", "9876543210", "jane.smith@example.com", "Working", true, false, 2, 2, 1, Guid.NewGuid(), "Admin", false },
            //        });

            //    migrationBuilder.InsertData(
            //        table: "Parents",
            //        columns: new[]
            //        {
            //"FirstName", "LastName", "Company", "Phone", "Email", "Workingwc",
            //"ChildSafety", "VDS", "StudentId", "OrganisationId",
            //"Guid", "AuditUser", "IsDeleted"
            //        },
            //        values: new object[,]
            //        {
            //{ "John", "Doe", "ABC Company", "1234567890", "john.doe@example.com", "Working", true, true, 1, 1, Guid.NewGuid(), "Admin", false },
            //{ "Jane", "Smith", "XYZ Company", "9876543210", "jane.smith@example.com", "Working", true, false, 2, 1, Guid.NewGuid(), "Admin", false },
            //        });




            migrationBuilder.CreateIndex(
                name: "IX_Compliances_OrganisationId",
                table: "Compliances",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationUsers_OrganisationId",
                table: "OrganisationUsers",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_PatronCompliances_ComplianceId",
                table: "PatronCompliances",
                column: "ComplianceId");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_StudentId",
                table: "Parents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Relatives_StudentId",
                table: "Relatives",
                column: "StudentId");


            migrationBuilder.CreateIndex(
                name: "IX_PatronCompliances_PatronId",
                table: "PatronCompliances",
                column: "PatronId");

            migrationBuilder.CreateIndex(
                name: "IX_Patrons_OrganisationId",
                table: "Patrons",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Patrons_PatronTypeId",
                table: "Patrons",
                column: "PatronTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PatronStudents_PatronId",
                table: "PatronStudents",
                column: "PatronId");

            migrationBuilder.CreateIndex(
                name: "IX_PatronStudents_StudentId",
                table: "PatronStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLog_StaffId",
                table: "StaffLog",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMembers_OrganisationId",
                table: "StaffMembers",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentIncidentActions_OrganisationId",
                table: "StudentIncidentActions",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentIncidentLogs_StaffId",
                table: "StudentIncidentLogs",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentIncidentLogs_StudentId",
                table: "StudentIncidentLogs",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentIncidentLogs_StudentIncidentActionId",
                table: "StudentIncidentLogs",
                column: "StudentIncidentActionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentIncidentLogs_StudentIncidentId",
                table: "StudentIncidentLogs",
                column: "StudentIncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentIncidentLogs_StudentIncidentSymptomId",
                table: "StudentIncidentLogs",
                column: "StudentIncidentSymptomId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentIncidents_OrganisationId",
                table: "StudentIncidents",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentIncidentSymptoms_OrganisationId",
                table: "StudentIncidentSymptoms",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLogReasons_OrganisationId",
                table: "StudentLogReasons",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLogs_PatronId",
                table: "StudentLogs",
                column: "PatronId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLogs_StudentId",
                table: "StudentLogs",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLogs_StudentLogReasonId",
                table: "StudentLogs",
                column: "StudentLogReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_OrganisationId",
                table: "Students",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorLogs_OrganisationId",
                table: "VisitorLogs",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorLogs_PatronId",
                table: "VisitorLogs",
                column: "PatronId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganisationUsers");

            migrationBuilder.DropTable(
                name: "PatronCompliances");

            migrationBuilder.DropTable(
                name: "PatronStudents");

            migrationBuilder.DropTable(
                name: "SbscrptnTypes");

            migrationBuilder.DropTable(
                name: "StaffLog");

            migrationBuilder.DropTable(
                name: "StudentIncidentLogs");

            migrationBuilder.DropTable(
                name: "StudentLogs");

            migrationBuilder.DropTable(
                name: "VisitorLogs");

            migrationBuilder.DropTable(
                name: "Compliances");

            migrationBuilder.DropTable(
                name: "StaffMembers");

            migrationBuilder.DropTable(
                name: "StudentIncidentActions");

            migrationBuilder.DropTable(
                name: "StudentIncidents");

            migrationBuilder.DropTable(
                name: "StudentIncidentSymptoms");

            migrationBuilder.DropTable(
                name: "StudentLogReasons");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Patrons");

            migrationBuilder.DropTable(
                name: "Organisations");

            migrationBuilder.DropTable(
                name: "PatronTypes");
        }
    }
}
