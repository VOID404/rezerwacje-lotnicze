﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using rezerwacje_lotnicze.Infrastructure;

#nullable disable

namespace rezerwacje_lotnicze.Migrations
{
    [DbContext(typeof(FlightBookingDbContext))]
    partial class FlightBookingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("rezerwacje_lotnicze.Domain.Entities.Flights.BaseFlight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ArrivalLocation")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<int?>("BaseTicketId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DepartureLocation")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<int>("FlightType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BaseTicketId");

                    b.ToTable("Flights");

                    b.HasDiscriminator<int>("FlightType");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("rezerwacje_lotnicze.Domain.Entities.Tickets.BaseTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("TicketType")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tickets");

                    b.HasDiscriminator<int>("TicketType");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("rezerwacje_lotnicze.Domain.Entities.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("rezerwacje_lotnicze.Domain.Entities.Flights.CargoFlight", b =>
                {
                    b.HasBaseType("rezerwacje_lotnicze.Domain.Entities.Flights.BaseFlight");

                    b.Property<int>("CargoVolume")
                        .HasColumnType("integer");

                    b.Property<int>("CargoWeight")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("rezerwacje_lotnicze.Domain.Entities.Flights.PassengerFlight", b =>
                {
                    b.HasBaseType("rezerwacje_lotnicze.Domain.Entities.Flights.BaseFlight");

                    b.Property<double>("SeatPrice")
                        .HasColumnType("double precision");

                    b.Property<int>("SeatsCapacity")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("rezerwacje_lotnicze.Domain.Entities.Tickets.CargoTicket", b =>
                {
                    b.HasBaseType("rezerwacje_lotnicze.Domain.Entities.Tickets.BaseTicket");

                    b.Property<int>("CargoVolume")
                        .HasColumnType("integer");

                    b.Property<int>("CargoWeight")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("rezerwacje_lotnicze.Domain.Entities.Tickets.PassengerTicket", b =>
                {
                    b.HasBaseType("rezerwacje_lotnicze.Domain.Entities.Tickets.BaseTicket");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("rezerwacje_lotnicze.Domain.Entities.Flights.BaseFlight", b =>
                {
                    b.HasOne("rezerwacje_lotnicze.Domain.Entities.Tickets.BaseTicket", null)
                        .WithMany("Flights")
                        .HasForeignKey("BaseTicketId");
                });

            modelBuilder.Entity("rezerwacje_lotnicze.Domain.Entities.Tickets.BaseTicket", b =>
                {
                    b.HasOne("rezerwacje_lotnicze.Domain.Entities.User.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("rezerwacje_lotnicze.Domain.Entities.Tickets.BaseTicket", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("rezerwacje_lotnicze.Domain.Entities.User.User", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
