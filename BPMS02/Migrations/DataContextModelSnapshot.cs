﻿// <auto-generated />
using BPMS02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BPMS02.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BPMS02.Models.Bridge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment")
                        .HasMaxLength(200);

                    b.Property<double>("Length");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("SpanNumber");

                    b.Property<int>("StructureType");

                    b.Property<double>("Width");

                    b.HasKey("Id");

                    b.ToTable("Bridges");
                });

            modelBuilder.Entity("BPMS02.Models.Contract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AcceptStaffId");

                    b.Property<int>("AcceptWay");

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<string>("Client")
                        .HasMaxLength(100);

                    b.Property<string>("ClientContactPerson")
                        .HasMaxLength(50);

                    b.Property<string>("ClientContactPersonPhone")
                        .HasMaxLength(20);

                    b.Property<int>("Deadline");

                    b.Property<string>("JobContent");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("No")
                        .IsRequired();

                    b.Property<string>("ProjectLocation")
                        .HasMaxLength(30);

                    b.Property<int>("PromisedDeadline");

                    b.Property<Guid>("ResponseStaffId");

                    b.Property<int>("SignStatus");

                    b.Property<DateTime>("SignedDate");

                    b.HasKey("Id");

                    b.HasIndex("AcceptStaffId");

                    b.HasIndex("ResponseStaffId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("BPMS02.Models.InspectionType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ProjectId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("InspectionTypes");
                });

            modelBuilder.Entity("BPMS02.Models.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<string>("Comment");

                    b.Property<Guid?>("ContractId");

                    b.Property<DateTime>("IssuedDate");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("BPMS02.Models.InvoiceDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<DateTime>("Date");

                    b.Property<Guid?>("InvoiceId");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("BPMS02.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BridgeId");

                    b.Property<decimal?>("CalcValue")
                        .HasColumnType("money");

                    b.Property<Guid?>("ContractId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<int>("DelayDays");

                    b.Property<decimal>("DelayRate");

                    b.Property<DateTime?>("EnterDate");

                    b.Property<int>("EnterProgress");

                    b.Property<DateTime?>("ExitDate");

                    b.Property<int>("InspectionType");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ProjectProgressExplanation");

                    b.Property<string>("ReportNo")
                        .HasMaxLength(20);

                    b.Property<int>("ReportProgress");

                    b.Property<DateTime?>("ReportPublishedDate");

                    b.Property<DateTime?>("SiteFinishedDate");

                    b.Property<int>("SiteProgress");

                    b.Property<decimal?>("StandardValue")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("BridgeId");

                    b.HasIndex("ContractId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("BPMS02.Models.ProjectInspectionType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("CalcValue")
                        .HasColumnType("money");

                    b.Property<Guid?>("InspectionTypeId");

                    b.Property<Guid?>("ProjectId");

                    b.Property<decimal?>("StandardValue")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("InspectionTypeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectInspectionTypes");
                });

            modelBuilder.Entity("BPMS02.Models.Staff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Education");

                    b.Property<int>("Gender");

                    b.Property<DateTime>("HiredDate");

                    b.Property<int>("JobTitle");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("No");

                    b.Property<string>("OfficePhone")
                        .HasMaxLength(20);

                    b.Property<int>("Position");

                    b.HasKey("Id");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("BPMS02.Models.StaffProject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("CalcValue")
                        .HasColumnType("money");

                    b.Property<int>("Labor");

                    b.Property<Guid?>("ProjectId");

                    b.Property<decimal?>("Ratio");

                    b.Property<Guid?>("StaffId");

                    b.Property<decimal?>("StandardValue")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StaffId");

                    b.ToTable("StaffProjects");
                });

            modelBuilder.Entity("BPMS02.Models.Contract", b =>
                {
                    b.HasOne("BPMS02.Models.Staff", "AcceptStaff")
                        .WithMany("AcceptContracts")
                        .HasForeignKey("AcceptStaffId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BPMS02.Models.Staff", "ResponseStaff")
                        .WithMany("ResponseContracts")
                        .HasForeignKey("ResponseStaffId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BPMS02.Models.InspectionType", b =>
                {
                    b.HasOne("BPMS02.Models.Project")
                        .WithMany("InspectionTypes")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("BPMS02.Models.Invoice", b =>
                {
                    b.HasOne("BPMS02.Models.Contract", "Contract")
                        .WithMany("Invoices")
                        .HasForeignKey("ContractId");
                });

            modelBuilder.Entity("BPMS02.Models.InvoiceDetail", b =>
                {
                    b.HasOne("BPMS02.Models.Invoice", "Invoice")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("InvoiceId");
                });

            modelBuilder.Entity("BPMS02.Models.Project", b =>
                {
                    b.HasOne("BPMS02.Models.Bridge", "Bridge")
                        .WithMany("Projects")
                        .HasForeignKey("BridgeId");

                    b.HasOne("BPMS02.Models.Contract", "Contract")
                        .WithMany("Projects")
                        .HasForeignKey("ContractId");
                });

            modelBuilder.Entity("BPMS02.Models.ProjectInspectionType", b =>
                {
                    b.HasOne("BPMS02.Models.InspectionType", "InspectionType")
                        .WithMany("ProjectInspectionTypes")
                        .HasForeignKey("InspectionTypeId");

                    b.HasOne("BPMS02.Models.Project", "Project")
                        .WithMany("ProjectInspectionTypes")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("BPMS02.Models.StaffProject", b =>
                {
                    b.HasOne("BPMS02.Models.Project", "Project")
                        .WithMany("StaffProjects")
                        .HasForeignKey("ProjectId");

                    b.HasOne("BPMS02.Models.Staff", "Staff")
                        .WithMany("StaffProjects")
                        .HasForeignKey("StaffId");
                });
#pragma warning restore 612, 618
        }
    }
}
