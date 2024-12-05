﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quize2.Db;

#nullable disable

namespace Quize2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Quize2.Entites.Card", b =>
                {
                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Balance")
                        .HasColumnType("real");

                    b.Property<float?>("DailyTransferAmount")
                        .HasColumnType("real");

                    b.Property<string>("HolderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TodayTransaction")
                        .HasColumnType("datetime2");

                    b.HasKey("CardNumber");

                    b.HasIndex("HolderName");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            CardNumber = "5892101407708383",
                            Balance = 500000f,
                            DailyTransferAmount = 0f,
                            HolderName = "alitn",
                            IsActive = true,
                            Password = "123"
                        },
                        new
                        {
                            CardNumber = "5892101407708384",
                            Balance = 500000f,
                            DailyTransferAmount = 0f,
                            HolderName = "reza",
                            IsActive = true,
                            Password = "123"
                        },
                        new
                        {
                            CardNumber = "5892101407708385",
                            Balance = 500000f,
                            DailyTransferAmount = 0f,
                            HolderName = "mamali",
                            IsActive = true,
                            Password = "123"
                        });
                });

            modelBuilder.Entity("Quize2.Entites.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<string>("DestinationCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsSuccessful")
                        .HasColumnType("bit");

                    b.Property<string>("SourceCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TransactionId");

                    b.HasIndex("DestinationCardNumber");

                    b.HasIndex("SourceCardNumber");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Quize2.Entites.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserName");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserName = "alitn",
                            FirstName = "ali",
                            LastName = "tahmasebinia",
                            NationalId = "0023527676",
                            Password = "123"
                        },
                        new
                        {
                            UserName = "reza",
                            FirstName = "reza",
                            LastName = "rezayi",
                            NationalId = "0023527677",
                            Password = "123"
                        },
                        new
                        {
                            UserName = "mamali",
                            FirstName = "mamad",
                            LastName = "mamali",
                            NationalId = "0023527678",
                            Password = "123"
                        });
                });

            modelBuilder.Entity("Quize2.Entites.Card", b =>
                {
                    b.HasOne("Quize2.Entites.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("HolderName")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Quize2.Entites.Transaction", b =>
                {
                    b.HasOne("Quize2.Entites.Card", "DestinationCard")
                        .WithMany("DestinationCards")
                        .HasForeignKey("DestinationCardNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Quize2.Entites.Card", "SourceCard")
                        .WithMany("SourceCards")
                        .HasForeignKey("SourceCardNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DestinationCard");

                    b.Navigation("SourceCard");
                });

            modelBuilder.Entity("Quize2.Entites.Card", b =>
                {
                    b.Navigation("DestinationCards");

                    b.Navigation("SourceCards");
                });

            modelBuilder.Entity("Quize2.Entites.User", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
