﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProbSqlite;

namespace ProbSqlite.Migrations
{
    [DbContext(typeof(ProbContext))]
    [Migration("20210119165810_PotentialWithBattles")]
    partial class PotentialWithBattles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11");

            modelBuilder.Entity("ProbSqlite.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Kind")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Suit")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("ProbSqlite.PairOfCards", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FirstId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PairString")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PotentialId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SecondId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FirstId");

                    b.HasIndex("PotentialId");

                    b.HasIndex("SecondId");

                    b.ToTable("Pairs");
                });

            modelBuilder.Entity("ProbSqlite.PairToPairBattle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Draw")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FirstPairId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Lose")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SecondPairId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int>("Win")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FirstPairId");

                    b.HasIndex("SecondPairId");

                    b.ToTable("Battles");
                });

            modelBuilder.Entity("ProbSqlite.Potential", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Draw")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Lose")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.Property<int>("Win")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Potentials");
                });

            modelBuilder.Entity("ProbSqlite.PairOfCards", b =>
                {
                    b.HasOne("ProbSqlite.Card", "First")
                        .WithMany()
                        .HasForeignKey("FirstId");

                    b.HasOne("ProbSqlite.Potential", "Potential")
                        .WithMany()
                        .HasForeignKey("PotentialId");

                    b.HasOne("ProbSqlite.Card", "Second")
                        .WithMany()
                        .HasForeignKey("SecondId");
                });

            modelBuilder.Entity("ProbSqlite.PairToPairBattle", b =>
                {
                    b.HasOne("ProbSqlite.PairOfCards", "FirstPair")
                        .WithMany()
                        .HasForeignKey("FirstPairId");

                    b.HasOne("ProbSqlite.PairOfCards", "SecondPair")
                        .WithMany()
                        .HasForeignKey("SecondPairId");
                });
#pragma warning restore 612, 618
        }
    }
}
