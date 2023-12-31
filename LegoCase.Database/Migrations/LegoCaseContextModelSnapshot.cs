﻿// <auto-generated />
using System;
using LegoCase.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LegoCase.Database.Migrations
{
    [DbContext(typeof(LegoCaseContext))]
    partial class LegoCaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("LegoCase.Database.Equipment.EquipmentItem", b =>
                {
                    b.Property<Guid>("EquipmentItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("EquipmentItemName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("EquipmentItemId");

                    b.ToTable("EquipmentItems");
                });

            modelBuilder.Entity("LegoCase.Database.Equipment.EquipmentTrace", b =>
                {
                    b.Property<Guid>("EquipmentTraceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EquipmentItemId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("NewState")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PreviousState")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EquipmentTraceId");

                    b.HasIndex("EquipmentItemId");

                    b.ToTable("EquipmentTraces");
                });

            modelBuilder.Entity("LegoCase.Database.Equipment.EquipmentTrace", b =>
                {
                    b.HasOne("LegoCase.Database.Equipment.EquipmentItem", "EquipmentItem")
                        .WithMany("Traces")
                        .HasForeignKey("EquipmentItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquipmentItem");
                });

            modelBuilder.Entity("LegoCase.Database.Equipment.EquipmentItem", b =>
                {
                    b.Navigation("Traces");
                });
#pragma warning restore 612, 618
        }
    }
}
