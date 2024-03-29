﻿// <auto-generated />
using System;
using Homework15_LiudvynskyiV.S.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Homework15_LiudvynskyiV.S.Migrations
{
    [DbContext(typeof(CinemaNetworkDbContext))]
    [Migration("20230123020109_fixSeatProps")]
    partial class fixSeatProps
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Homework15_LiudvynskyiV.S.Models.Domain.Cinema", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("Homework15_LiudvynskyiV.S.Models.Domain.Hall", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CinemaId")
                        .HasColumnType("uuid");

                    b.Property<int>("HallNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("Homework15_LiudvynskyiV.S.Models.Domain.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Homework15_LiudvynskyiV.S.Models.Domain.Seat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CinemaId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("HallId")
                        .HasColumnType("uuid");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.HasIndex("HallId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("Homework15_LiudvynskyiV.S.Models.Domain.Showtime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Showtimes");
                });

            modelBuilder.Entity("Homework15_LiudvynskyiV.S.Models.Domain.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<Guid>("SeatId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ShowtimeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("SeatId");

                    b.HasIndex("ShowtimeId");

                    b.HasIndex("UserId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Homework15_LiudvynskyiV.S.Models.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Homework15_LiudvynskyiV.S.Models.Domain.Hall", b =>
                {
                    b.HasOne("Homework15_LiudvynskyiV.S.Models.Domain.Cinema", "Cinema")
                        .WithMany("Halls")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("Homework15_LiudvynskyiV.S.Models.Domain.Seat", b =>
                {
                    b.HasOne("Homework15_LiudvynskyiV.S.Models.Domain.Cinema", "Cinema")
                        .WithMany()
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Homework15_LiudvynskyiV.S.Models.Domain.Hall", null)
                        .WithMany("Seats")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("Homework15_LiudvynskyiV.S.Models.Domain.Ticket", b =>
                {
                    b.HasOne("Homework15_LiudvynskyiV.S.Models.Domain.Movie", "Movie")
                        .WithMany("Tickets")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Homework15_LiudvynskyiV.S.Models.Domain.Seat", "Seat")
                        .WithMany("Tickets")
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Homework15_LiudvynskyiV.S.Models.Domain.Showtime", "Showtime")
                        .WithMany("Tickets")
                        .HasForeignKey("ShowtimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Homework15_LiudvynskyiV.S.Models.Domain.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Seat");

                    b.Navigation("Showtime");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Homework15_LiudvynskyiV.S.Models.Domain.Cinema", b =>
                {
                    b.Navigation("Halls");
                });

            modelBuilder.Entity("Homework15_LiudvynskyiV.S.Models.Domain.Hall", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("Homework15_LiudvynskyiV.S.Models.Domain.Movie", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Homework15_LiudvynskyiV.S.Models.Domain.Seat", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Homework15_LiudvynskyiV.S.Models.Domain.Showtime", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Homework15_LiudvynskyiV.S.Models.Domain.User", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
