﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoListDatabase.Database;

#nullable disable

namespace TodoListDatabase.Migrations.TodoDB
{
    [DbContext(typeof(TodoDBContext))]
    partial class TodoDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("TodoListDatabase.Models.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDone")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Task")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("VerifyId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}
