using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixedRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Countries_country_id",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_author_id",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_category_id",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Countries_countr_id",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_user_id",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Countries_country_id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Reports_user_id",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Books_category_id",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Authors_country_id",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "country_id",
                table: "Users",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "Full_name",
                table: "Users",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "Users",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Users_country_id",
                table: "Users",
                newName: "IX_Users_CountryId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Reports",
                newName: "ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "Page_name",
                table: "Reports",
                newName: "PageName");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "Reports",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Reports",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "Events",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Events",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "Countries",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Countries",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "Categories",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Categories",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "countr_id",
                table: "Books",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "Books",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "author_id",
                table: "Books",
                newName: "AuthorId");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "Books",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Books",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Books_countr_id",
                table: "Books",
                newName: "IX_Books_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_author_id",
                table: "Books",
                newName: "IX_Books_AuthorId");

            migrationBuilder.RenameColumn(
                name: "country_id",
                table: "Authors",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Authors",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "Full_name",
                table: "Authors",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Deleted_at",
                table: "Authors",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Authors",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Bio_wikipediya",
                table: "Authors",
                newName: "BioWikipediya");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId1",
                table: "Reports",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Events",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Books",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Authors",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookCategories",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => new { x.BooksId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_BookCategories_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ApplicationUserId",
                table: "Reports",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ApplicationUserId1",
                table: "Reports",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ApplicationUserId",
                table: "Events",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_CountryId",
                table: "Authors",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategories_CategoryId",
                table: "BookCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Countries_CountryId",
                table: "Authors",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Countries_CountryId",
                table: "Books",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_ApplicationUserId",
                table: "Events",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_ApplicationUserId",
                table: "Reports",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_ApplicationUserId1",
                table: "Reports",
                column: "ApplicationUserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Countries_CountryId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Countries_CountryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_ApplicationUserId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_ApplicationUserId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_ApplicationUserId1",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "BookCategories");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ApplicationUserId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ApplicationUserId1",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Events_ApplicationUserId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Authors_CountryId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Users",
                newName: "Full_name");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Users",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Users",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Users",
                newName: "country_id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CountryId",
                table: "Users",
                newName: "IX_Users_country_id");

            migrationBuilder.RenameColumn(
                name: "PageName",
                table: "Reports",
                newName: "Page_name");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Reports",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Reports",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Reports",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Events",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Events",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Countries",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Countries",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Categories",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Categories",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Books",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Books",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Books",
                newName: "countr_id");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Books",
                newName: "category_id");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Books",
                newName: "author_id");

            migrationBuilder.RenameIndex(
                name: "IX_Books_CountryId",
                table: "Books",
                newName: "IX_Books_countr_id");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                newName: "IX_Books_author_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Authors",
                newName: "Deleted_at");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Authors",
                newName: "Full_name");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Authors",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Authors",
                newName: "country_id");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Authors",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "BioWikipediya",
                table: "Authors",
                newName: "Bio_wikipediya");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_user_id",
                table: "Reports",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_category_id",
                table: "Books",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_country_id",
                table: "Authors",
                column: "country_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Countries_country_id",
                table: "Authors",
                column: "country_id",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_author_id",
                table: "Books",
                column: "author_id",
                principalTable: "Authors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_category_id",
                table: "Books",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Countries_countr_id",
                table: "Books",
                column: "countr_id",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_user_id",
                table: "Reports",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Countries_country_id",
                table: "Users",
                column: "country_id",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
