using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rubicon_blog.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Slug = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Slug);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Slug = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Slug);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    BlogPostSlug = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TagSlug = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => new { x.BlogPostSlug, x.TagSlug });
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_BlogPostSlug",
                        column: x => x.BlogPostSlug,
                        principalTable: "Posts",
                        principalColumn: "Slug",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_TagSlug",
                        column: x => x.TagSlug,
                        principalTable: "Tags",
                        principalColumn: "Slug",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Slug", "Body", "CreatedAt", "Description", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { "augmented-reality-ios-application", "The app is simple to use, and will help you decide on your best furniture fit.", new DateTime(2021, 4, 27, 2, 57, 6, 321, DateTimeKind.Local).AddTicks(8383), "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.", "Augmented Reality iOS Application", new DateTime(2021, 4, 27, 2, 57, 6, 324, DateTimeKind.Local).AddTicks(9508) },
                    { "augmented-reality-ios-application-2", "The app is simple to use, and will help you decide on your best furniture fit.", new DateTime(2021, 4, 27, 2, 57, 6, 325, DateTimeKind.Local).AddTicks(313), "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.", "Augmented Reality iOS Application 2", new DateTime(2021, 4, 27, 2, 57, 6, 325, DateTimeKind.Local).AddTicks(332) }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Slug", "Name" },
                values: new object[,]
                {
                    { "ios", "iOS" },
                    { "ar", "Augmented Reality" },
                    { "gazzda", "Gazzda" }
                });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "BlogPostSlug", "TagSlug" },
                values: new object[] { "augmented-reality-ios-application", "ios" });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "BlogPostSlug", "TagSlug" },
                values: new object[] { "augmented-reality-ios-application", "ar" });

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagSlug",
                table: "PostTags",
                column: "TagSlug");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
