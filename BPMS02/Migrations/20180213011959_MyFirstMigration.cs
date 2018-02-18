using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BPMS02.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bridges",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comment = table.Column<string>(maxLength: 200, nullable: true),
                    Length = table.Column<double>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    SpanNumber = table.Column<int>(nullable: false),
                    StructureType = table.Column<int>(nullable: false),
                    Width = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bridges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Education = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    HiredDate = table.Column<DateTime>(nullable: false),
                    JobTitle = table.Column<int>(nullable: false),
                    MobilePhone = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    No = table.Column<int>(nullable: false),
                    OfficePhone = table.Column<string>(maxLength: 20, nullable: true),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AcceptStaffId = table.Column<Guid>(nullable: true),
                    AcceptWay = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Client = table.Column<string>(maxLength: 100, nullable: true),
                    ClientContactPerson = table.Column<string>(maxLength: 50, nullable: true),
                    ClientContactPersonPhone = table.Column<string>(maxLength: 20, nullable: true),
                    Deadline = table.Column<int>(nullable: false),
                    JobContent = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    No = table.Column<string>(nullable: false),
                    ProjectLocation = table.Column<string>(maxLength: 30, nullable: true),
                    PromisedDeadline = table.Column<int>(nullable: false),
                    ResponseStaffId = table.Column<Guid>(nullable: true),
                    SignStatus = table.Column<int>(nullable: false),
                    SignedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Staffs_AcceptStaffId",
                        column: x => x.AcceptStaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_Staffs_ResponseStaffId",
                        column: x => x.ResponseStaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    ContractId = table.Column<Guid>(nullable: true),
                    IssuedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BridgeId = table.Column<Guid>(nullable: true),
                    CalcValue = table.Column<decimal>(type: "money", nullable: true),
                    ContractId = table.Column<Guid>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    DelayDays = table.Column<int>(nullable: false),
                    DelayRate = table.Column<decimal>(nullable: false),
                    EnterDate = table.Column<DateTime>(nullable: true),
                    EnterProgress = table.Column<int>(nullable: false),
                    ExitDate = table.Column<DateTime>(nullable: true),
                    InspectionType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ProjectProgressExplanation = table.Column<DateTime>(nullable: true),
                    ReportNo = table.Column<string>(maxLength: 20, nullable: true),
                    ReportProgress = table.Column<int>(nullable: false),
                    ReportPublishedDate = table.Column<DateTime>(nullable: true),
                    SiteFinishedDate = table.Column<DateTime>(nullable: true),
                    SiteProgress = table.Column<int>(nullable: false),
                    StandardValue = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Bridges_BridgeId",
                        column: x => x.BridgeId,
                        principalTable: "Bridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    InvoiceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionTypes_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CalcValue = table.Column<decimal>(type: "money", nullable: true),
                    Labor = table.Column<int>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: true),
                    Ratio = table.Column<decimal>(nullable: true),
                    StaffId = table.Column<Guid>(nullable: true),
                    StandardValue = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffProjects_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectInspectionTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CalcValue = table.Column<decimal>(type: "money", nullable: true),
                    InspectionTypeId = table.Column<Guid>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: true),
                    StandardValue = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectInspectionTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectInspectionTypes_InspectionTypes_InspectionTypeId",
                        column: x => x.InspectionTypeId,
                        principalTable: "InspectionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectInspectionTypes_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_AcceptStaffId",
                table: "Contracts",
                column: "AcceptStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ResponseStaffId",
                table: "Contracts",
                column: "ResponseStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionTypes_ProjectId",
                table: "InspectionTypes",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ContractId",
                table: "Invoices",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectInspectionTypes_InspectionTypeId",
                table: "ProjectInspectionTypes",
                column: "InspectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectInspectionTypes_ProjectId",
                table: "ProjectInspectionTypes",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_BridgeId",
                table: "Projects",
                column: "BridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ContractId",
                table: "Projects",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffProjects_ProjectId",
                table: "StaffProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffProjects_StaffId",
                table: "StaffProjects",
                column: "StaffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "ProjectInspectionTypes");

            migrationBuilder.DropTable(
                name: "StaffProjects");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "InspectionTypes");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Bridges");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Staffs");
        }
    }
}
