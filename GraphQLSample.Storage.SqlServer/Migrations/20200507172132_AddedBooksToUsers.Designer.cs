﻿// <auto-generated />
using System;
using GraphQLSample.Storage.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GraphQLSample.Storage.SqlServer.Migrations
{
    [DbContext(typeof(BoundaryDbContext))]
    [Migration("20200507172132_AddedBooksToUsers")]
    partial class AddedBooksToUsers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GraphQLSample.Core.Domains.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("GraphQLSample.Core.Domains.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("WeightLbs")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthday = new DateTime(1985, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "alperEb@hotmail.com",
                            FirstName = "Alper",
                            LastName = "Ebicoglu",
                            WeightLbs = 198f
                        },
                        new
                        {
                            Id = 2,
                            Birthday = new DateTime(1962, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "bobbo@burgers.com",
                            FirstName = "Bob",
                            LastName = "Burgers",
                            WeightLbs = 145f
                        },
                        new
                        {
                            Id = 3,
                            Birthday = new DateTime(1937, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Tarris@yahoo.com",
                            FirstName = "Tim",
                            LastName = "Farris",
                            WeightLbs = 184f
                        },
                        new
                        {
                            Id = 4,
                            Birthday = new DateTime(1953, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jodyS@gmail.com",
                            FirstName = "Jody",
                            LastName = "Stevenson",
                            WeightLbs = 173f
                        },
                        new
                        {
                            Id = 5,
                            Birthday = new DateTime(1999, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "scott@dunder.com",
                            FirstName = "Michael",
                            LastName = "Scott",
                            WeightLbs = 160f
                        });
                });

            modelBuilder.Entity("GraphQLSample.Core.Domains.Book", b =>
                {
                    b.HasOne("GraphQLSample.Core.Domains.User", null)
                        .WithMany("Books")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
