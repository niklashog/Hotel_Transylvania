﻿// <auto-generated />
using System;
using Hotel_Transylvania.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotel_Transylvania.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241218212428_ReservationID in Room Model now nullable")]
    partial class ReservationIDinRoomModelnownullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hotel_Transylvania.Models.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsGuestActive")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReservationHistory")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("Hotel_Transylvania.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CheckinDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckoutDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GuestID")
                        .HasColumnType("int");

                    b.Property<bool>("IsReservationActive")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfAdditionalBeds")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeOfReservation")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GuestID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Hotel_Transylvania.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdditionalBeddingNumber")
                        .HasColumnType("int");

                    b.Property<bool>("IsRoomActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<int>("RoomSize")
                        .HasColumnType("int");

                    b.Property<string>("RoomType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Hotel_Transylvania.Models.Reservation", b =>
                {
                    b.HasOne("Hotel_Transylvania.Models.Guest", null)
                        .WithMany("Reservations")
                        .HasForeignKey("GuestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hotel_Transylvania.Models.Room", b =>
                {
                    b.HasOne("Hotel_Transylvania.Models.Reservation", null)
                        .WithMany("Rooms")
                        .HasForeignKey("ReservationId");
                });

            modelBuilder.Entity("Hotel_Transylvania.Models.Guest", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Hotel_Transylvania.Models.Reservation", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
