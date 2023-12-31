﻿// <auto-generated />
using System;
using DbManagment.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DbManagment.Migrations
{
    [DbContext(typeof(DbContextSMFY))]
    partial class DbContextSMFYModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DbManagment.Entities.Card", b =>
                {
                    b.Property<Guid>("CardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Animation")
                        .HasColumnType("text");

                    b.Property<string>("CardBackgroundColor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CardColor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CardTemplateID")
                        .HasColumnType("integer");

                    b.Property<string>("CardText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CardTextColor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserID")
                        .HasColumnType("integer");

                    b.HasKey("CardID");

                    b.HasIndex("CardTemplateID");

                    b.HasIndex("UserID");

                    b.ToTable("Cards", (string)null);
                });

            modelBuilder.Entity("DbManagment.Entities.CardImage", b =>
                {
                    b.Property<int>("CardImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CardImageID"));

                    b.Property<Guid>("CardID")
                        .HasColumnType("uuid");

                    b.Property<string>("CardImageName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CardImageOriginalName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CardImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CardImageID");

                    b.HasIndex("CardID");

                    b.ToTable("CardImages", (string)null);
                });

            modelBuilder.Entity("DbManagment.Entities.CardTemplate", b =>
                {
                    b.Property<int>("CardTemplateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CardTemplateID"));

                    b.Property<string>("CardTemplateContent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CardTemplateName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CardTemplateID");

                    b.ToTable("CardTemplates", (string)null);
                });

            modelBuilder.Entity("DbManagment.Entities.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserID"));

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserID");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("DbManagment.Entities.Card", b =>
                {
                    b.HasOne("DbManagment.Entities.CardTemplate", "CardTemplate")
                        .WithMany("Cards")
                        .HasForeignKey("CardTemplateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbManagment.Entities.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CardTemplate");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DbManagment.Entities.CardImage", b =>
                {
                    b.HasOne("DbManagment.Entities.Card", "Card")
                        .WithMany("CardImages")
                        .HasForeignKey("CardID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");
                });

            modelBuilder.Entity("DbManagment.Entities.Card", b =>
                {
                    b.Navigation("CardImages");
                });

            modelBuilder.Entity("DbManagment.Entities.CardTemplate", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("DbManagment.Entities.User", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
