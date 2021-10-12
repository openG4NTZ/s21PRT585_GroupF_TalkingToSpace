﻿// <auto-generated />
using System;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211012060849_UserEntityV2")]
    partial class UserEntityV2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entities.Message", b =>
                {
                    b.Property<long>("Message_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("message_id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message_Content")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("message_content");

                    b.Property<DateTime>("Message_Creation_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 10, 12, 6, 8, 48, 921, DateTimeKind.Utc).AddTicks(2548))
                        .HasColumnName("message_creation_date");

                    b.Property<DateTime>("Message_Modified_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("message_modified_date");

                    b.Property<DateTime>("Message_Sent_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("message_sent_date");

                    b.Property<string>("Message_Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("message_status");

                    b.Property<long>("User_ID")
                        .HasColumnType("bigint");

                    b.HasKey("Message_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("message");
                });

            modelBuilder.Entity("DAL.Entities.Reply", b =>
                {
                    b.Property<long>("Reply_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("reply_id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Message_ID")
                        .HasColumnType("bigint");

                    b.Property<string>("Reply_Content")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("reply_content");

                    b.Property<DateTime>("Reply_Creation_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 10, 12, 6, 8, 48, 924, DateTimeKind.Utc).AddTicks(3346))
                        .HasColumnName("reply_creation_date");

                    b.Property<DateTime>("Reply_Modified_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("reply_modified_date");

                    b.Property<DateTime>("Reply_Sent_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("reply_sent_date");

                    b.Property<string>("Reply_Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("reply_status");

                    b.Property<long>("User_ID")
                        .HasColumnType("bigint");

                    b.HasKey("Reply_ID");

                    b.HasIndex("Message_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("reply");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Property<long>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("user_id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("User_Creation_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 10, 12, 6, 8, 48, 904, DateTimeKind.Utc).AddTicks(8149))
                        .HasColumnName("user_creation_date");

                    b.Property<string>("User_Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("user_email");

                    b.Property<long>("User_Point")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L)
                        .HasColumnName("user_point");

                    b.Property<string>("User_Profile_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("user_profile_name");

                    b.Property<string>("User_Token")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("user_token");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("username");

                    b.HasKey("User_ID");

                    b.ToTable("user");
                });

            modelBuilder.Entity("DAL.Entities.Message", b =>
                {
                    b.HasOne("DAL.Entities.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.Reply", b =>
                {
                    b.HasOne("DAL.Entities.Message", "Message")
                        .WithMany("Replies")
                        .HasForeignKey("Message_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DAL.Entities.User", "User")
                        .WithMany("Replies")
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Message");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.Message", b =>
                {
                    b.Navigation("Replies");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Replies");
                });
#pragma warning restore 612, 618
        }
    }
}
