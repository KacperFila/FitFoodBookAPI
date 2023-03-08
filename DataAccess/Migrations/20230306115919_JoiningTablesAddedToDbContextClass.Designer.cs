﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(FitFoodBookDbContext))]
    [Migration("20230306115919_JoiningTablesAddedToDbContextClass")]
    partial class JoiningTablesAddedToDbContextClass
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.1.23111.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Carbohydrates")
                        .HasColumnType("int");

                    b.Property<int>("Fats")
                        .HasColumnType("int");

                    b.Property<int>("Proteins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Domain.Entities.IngredientTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IngredientTags");
                });

            modelBuilder.Entity("Domain.Entities.Ingredient_IngredientTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IngredientTagId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("IngredientTagId");

                    b.ToTable("IngredientIngredientTags");
                });

            modelBuilder.Entity("Domain.Entities.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AmountOfServings")
                        .HasColumnType("int");

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<int>("Carbohydrates")
                        .HasColumnType("int");

                    b.Property<int>("Fats")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Proteins")
                        .HasColumnType("int");

                    b.Property<int>("TimeOfPreparing")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Domain.Entities.RecipeTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RecipeTags");
                });

            modelBuilder.Entity("Domain.Entities.Recipe_Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("Domain.Entities.Recipe_RecipeTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RecipeTagId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("RecipeTagId");

                    b.ToTable("RecipeRecipeTags");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("IngredientIngredientTag", b =>
                {
                    b.Property<Guid>("IngredientTagsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IngredientsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IngredientTagsId", "IngredientsId");

                    b.HasIndex("IngredientsId");

                    b.ToTable("IngredientIngredientTag");
                });

            modelBuilder.Entity("IngredientRecipe", b =>
                {
                    b.Property<Guid>("IngredientsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RecipesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IngredientsId", "RecipesId");

                    b.HasIndex("RecipesId");

                    b.ToTable("IngredientRecipe");
                });

            modelBuilder.Entity("RecipeRecipeTag", b =>
                {
                    b.Property<Guid>("RecipeTagsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RecipesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RecipeTagsId", "RecipesId");

                    b.HasIndex("RecipesId");

                    b.ToTable("RecipeRecipeTag");
                });

            modelBuilder.Entity("Domain.Entities.Ingredient_IngredientTag", b =>
                {
                    b.HasOne("Domain.Entities.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.IngredientTag", "IngredientTag")
                        .WithMany()
                        .HasForeignKey("IngredientTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("IngredientTag");
                });

            modelBuilder.Entity("Domain.Entities.Recipe", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Recipes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Recipe_Ingredient", b =>
                {
                    b.HasOne("Domain.Entities.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("Domain.Entities.Recipe_RecipeTag", b =>
                {
                    b.HasOne("Domain.Entities.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.RecipeTag", "RecipeTag")
                        .WithMany()
                        .HasForeignKey("RecipeTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("RecipeTag");
                });

            modelBuilder.Entity("IngredientIngredientTag", b =>
                {
                    b.HasOne("Domain.Entities.IngredientTag", null)
                        .WithMany()
                        .HasForeignKey("IngredientTagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IngredientRecipe", b =>
                {
                    b.HasOne("Domain.Entities.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecipeRecipeTag", b =>
                {
                    b.HasOne("Domain.Entities.RecipeTag", null)
                        .WithMany()
                        .HasForeignKey("RecipeTagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}