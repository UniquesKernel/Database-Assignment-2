﻿// <auto-generated />
using System;
using Assignment2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220511181844_Test")]
    partial class Test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Assignment2.Models.Municipality", b =>
                {
                    b.Property<int>("MunicipalityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MunicipalityId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MunicipalityId");

                    b.ToTable("Municipalities");
                });

            modelBuilder.Entity("Assignment2.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"), 1L, 1);

                    b.Property<long>("CPR")
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassPortNr")
                        .HasColumnType("int");

                    b.Property<long>("PhoneNr")
                        .HasColumnType("bigint");

                    b.HasKey("PersonId");

                    b.HasIndex("CPR")
                        .IsUnique();

                    b.ToTable("People");
                });

            modelBuilder.Entity("Assignment2.Models.Property_Type", b =>
                {
                    b.Property<int>("Property_TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Property_TypeId"), 1L, 1);

                    b.Property<string>("Item")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Room_LocationId")
                        .HasColumnType("int");

                    b.HasKey("Property_TypeId");

                    b.HasIndex("Item")
                        .IsUnique();

                    b.HasIndex("Room_LocationId");

                    b.ToTable("Property_Types");
                });

            modelBuilder.Entity("Assignment2.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"), 1L, 1);

                    b.Property<int>("BookedRoomsRoom_LocationId")
                        .HasColumnType("int");

                    b.Property<int>("BookingMembersPersonId")
                        .HasColumnType("int");

                    b.Property<int>("BookingSocietySocietyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ReservationId");

                    b.HasIndex("BookedRoomsRoom_LocationId");

                    b.HasIndex("BookingMembersPersonId");

                    b.HasIndex("BookingSocietySocietyId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Assignment2.Models.Room_Location", b =>
                {
                    b.Property<int>("Room_LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Room_LocationId"), 1L, 1);

                    b.Property<string>("AccessMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MaxOccupants")
                        .HasColumnType("int");

                    b.Property<int?>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<int>("RoomNr")
                        .HasColumnType("int");

                    b.HasKey("Room_LocationId");

                    b.HasIndex("MunicipalityId");

                    b.HasIndex("RoomNr", "Address")
                        .IsUnique();

                    b.ToTable("Room_Locations");
                });

            modelBuilder.Entity("Assignment2.Models.Society", b =>
                {
                    b.Property<int>("SocietyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SocietyId"), 1L, 1);

                    b.Property<string>("Activity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ApprovedMemberPersonId")
                        .HasColumnType("int");

                    b.Property<int>("CVR")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SocietyId");

                    b.HasIndex("ApprovedMemberPersonId");

                    b.ToTable("Societies");
                });

            modelBuilder.Entity("Assignment2.Models.Property_Type", b =>
                {
                    b.HasOne("Assignment2.Models.Room_Location", null)
                        .WithMany("Items")
                        .HasForeignKey("Room_LocationId");
                });

            modelBuilder.Entity("Assignment2.Models.Reservation", b =>
                {
                    b.HasOne("Assignment2.Models.Room_Location", "BookedRooms")
                        .WithMany("Reservations")
                        .HasForeignKey("BookedRoomsRoom_LocationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Assignment2.Models.Person", "BookingMembers")
                        .WithMany()
                        .HasForeignKey("BookingMembersPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment2.Models.Society", "BookingSociety")
                        .WithMany()
                        .HasForeignKey("BookingSocietySocietyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookedRooms");

                    b.Navigation("BookingMembers");

                    b.Navigation("BookingSociety");
                });

            modelBuilder.Entity("Assignment2.Models.Room_Location", b =>
                {
                    b.HasOne("Assignment2.Models.Municipality", null)
                        .WithMany("Room_Locations")
                        .HasForeignKey("MunicipalityId");
                });

            modelBuilder.Entity("Assignment2.Models.Society", b =>
                {
                    b.HasOne("Assignment2.Models.Person", "ApprovedMember")
                        .WithMany("Society")
                        .HasForeignKey("ApprovedMemberPersonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ApprovedMember");
                });

            modelBuilder.Entity("Assignment2.Models.Municipality", b =>
                {
                    b.Navigation("Room_Locations");
                });

            modelBuilder.Entity("Assignment2.Models.Person", b =>
                {
                    b.Navigation("Society");
                });

            modelBuilder.Entity("Assignment2.Models.Room_Location", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
