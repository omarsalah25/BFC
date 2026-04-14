using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BFC.Migrations
{
    /// <inheritdoc />
    public partial class AddHomeLabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarsSubtitleAr",
                table: "SiteSettings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CarsSubtitleEn",
                table: "SiteSettings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CarsTitleAr",
                table: "SiteSettings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CarsTitleEn",
                table: "SiteSettings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactSubtitleAr",
                table: "SiteSettings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactSubtitleEn",
                table: "SiteSettings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactTitleAr",
                table: "SiteSettings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactTitleEn",
                table: "SiteSettings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FeaturesTitleAr",
                table: "SiteSettings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FeaturesTitleEn",
                table: "SiteSettings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TestimonialsTitleAr",
                table: "SiteSettings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TestimonialsTitleEn",
                table: "SiteSettings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CarsSubtitleAr", "CarsSubtitleEn", "CarsTitleAr", "CarsTitleEn", "ContactSubtitleAr", "ContactSubtitleEn", "ContactTitleAr", "ContactTitleEn", "FeaturesTitleAr", "FeaturesTitleEn", "TestimonialsTitleAr", "TestimonialsTitleEn" },
                values: new object[] { "اختر سيارتك المثالية واستمتع بتجربة قيادة لا تُنسى", "Choose your perfect car and enjoy an unforgettable driving experience", "سياراتنا الفاخرة", "Our Luxury Fleet", "نحن هنا لمساعدتك 24 ساعة طوال أيام الأسبوع عبر واتساب", "We're here to help you 24/7 via WhatsApp", "تواصل معنا", "Contact Us", "مميزاتنا", "Our Advantages", "ماذا يقول عملاؤنا", "What Our Clients Say" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarsSubtitleAr",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "CarsSubtitleEn",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "CarsTitleAr",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "CarsTitleEn",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "ContactSubtitleAr",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "ContactSubtitleEn",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "ContactTitleAr",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "ContactTitleEn",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "FeaturesTitleAr",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "FeaturesTitleEn",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "TestimonialsTitleAr",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "TestimonialsTitleEn",
                table: "SiteSettings");
        }
    }
}
