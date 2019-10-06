﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Return.Persistence;

namespace Return.Persistence.Migrations
{
    [DbContext(typeof(ReturnDbContext))]
    [Migration("20191006101831_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Return.Domain.Entities.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreationTimestamp")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("LaneId")
                        .HasColumnType("int");

                    b.Property<int?>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<int>("RetrospectiveId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(2048)")
                        .HasMaxLength(2048);

                    b.HasKey("Id");

                    b.HasIndex("LaneId");

                    b.HasIndex("ParticipantId");

                    b.HasIndex("RetrospectiveId");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("Return.Domain.Entities.NoteLane", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("NoteLanes");
                });

            modelBuilder.Entity("Return.Domain.Entities.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Participant");
                });

            modelBuilder.Entity("Return.Domain.Entities.Retrospective", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreationTimestamp")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("HashedPassphrase")
                        .HasColumnType("char(64)")
                        .IsFixedLength(true)
                        .HasMaxLength(64)
                        .IsUnicode(false);

                    b.Property<string>("ManagerHashedPassphrase")
                        .IsRequired()
                        .HasColumnType("char(64)")
                        .IsFixedLength(true)
                        .HasMaxLength(64)
                        .IsUnicode(false);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Retrospectives");
                });

            modelBuilder.Entity("Return.Domain.Entities.Note", b =>
                {
                    b.HasOne("Return.Domain.Entities.NoteLane", "Lane")
                        .WithMany()
                        .HasForeignKey("LaneId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Return.Domain.Entities.Participant", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Return.Domain.Entities.Retrospective", "Retrospective")
                        .WithMany("Notes")
                        .HasForeignKey("RetrospectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Return.Domain.Entities.Participant", b =>
                {
                    b.OwnsOne("Return.Domain.ValueObjects.ParticipantColor", "Color", b1 =>
                        {
                            b1.Property<int>("ParticipantId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<byte>("B")
                                .HasColumnType("tinyint");

                            b1.Property<byte>("G")
                                .HasColumnType("tinyint");

                            b1.Property<byte>("R")
                                .HasColumnType("tinyint");

                            b1.HasKey("ParticipantId");

                            b1.ToTable("Participant");

                            b1.WithOwner()
                                .HasForeignKey("ParticipantId");
                        });
                });

            modelBuilder.Entity("Return.Domain.Entities.Retrospective", b =>
                {
                    b.OwnsOne("Return.Domain.ValueObjects.RetroIdentifier", "UrlId", b1 =>
                        {
                            b1.Property<int>("RetrospectiveId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("StringId")
                                .IsRequired()
                                .HasColumnType("varchar(32)")
                                .HasMaxLength(32)
                                .IsUnicode(false);

                            b1.HasKey("RetrospectiveId");

                            b1.HasIndex("StringId")
                                .IsUnique()
                                .HasFilter("[UrlId_StringId] IS NOT NULL");

                            b1.ToTable("Retrospectives");

                            b1.WithOwner()
                                .HasForeignKey("RetrospectiveId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}