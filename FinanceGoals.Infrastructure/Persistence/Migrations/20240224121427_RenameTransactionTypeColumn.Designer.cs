﻿// <auto-generated />
using System;
using FinanceGoals.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinanceGoals.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240224121427_RenameTransactionTypeColumn")]
    partial class RenameTransactionTypeColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FinanceGoals.Core.Entities.Goal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("TargetAmount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("tbl_Goals", (string)null);
                });

            modelBuilder.Entity("FinanceGoals.Core.Entities.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("IdGoal")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdGoal");

                    b.ToTable("tbl_Transactions", (string)null);
                });

            modelBuilder.Entity("FinanceGoals.Core.Entities.Transaction", b =>
                {
                    b.HasOne("FinanceGoals.Core.Entities.Goal", null)
                        .WithMany("Transactions")
                        .HasForeignKey("IdGoal")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("FinanceGoals.Core.Entities.Goal", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
