﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using iThome2024.ProcessService.Data;

#nullable disable

namespace iThome2024.ProcessService.Migrations
{
    [DbContext(typeof(TicketSalesContext))]
    [Migration("20240930141552_destid_index")]
    partial class destid_index
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("iThome2024.ProcessService.Data.Model.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("varchar(2000)");

                    b.Property<DateTime>("EndSalesDate")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("timestamp");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Remark")
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("StartSalesDate")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("iThome2024.ProcessService.Data.Model.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Area")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Seat");
                });

            modelBuilder.Entity("iThome2024.ProcessService.Data.Model.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp");

                    b.Property<int>("SeatId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SeatId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("iThome2024.ProcessService.Data.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Username")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("iThome2024.ProcessService.Data.Model.Seat", b =>
                {
                    b.HasOne("iThome2024.ProcessService.Data.Model.Event", "Event")
                        .WithMany("Seats")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("iThome2024.ProcessService.Data.Model.Ticket", b =>
                {
                    b.HasOne("iThome2024.ProcessService.Data.Model.Seat", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("iThome2024.ProcessService.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("iThome2024.ProcessService.Data.Model.Event", b =>
                {
                    b.Navigation("Seats");
                });
#pragma warning restore 612, 618
        }
    }
}
