using Microsoft.EntityFrameworkCore.Migrations;

namespace SaltpayBank.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.CreateTable(
        //        name: "Customers",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Customers", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Accounts",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Amount = table.Column<double>(type: "float", nullable: false),
        //            CustomerId = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Accounts", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Accounts_Customers_CustomerId",
        //                column: x => x.CustomerId,
        //                principalTable: "Customers",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.InsertData(
        //        table: "Customers",
        //        columns: new[] { "Id", "Name" },
        //        values: new object[,]
        //        {
        //            { 1, "Arisha Barron" },
        //            { 2, "Branden Gibson" },
        //            { 3, "Rhonda Church" },
        //            { 4, "Georgina Hazel" }
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Accounts_CustomerId",
        //        table: "Accounts",
        //        column: "CustomerId");
        //}

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropTable(
        //        name: "Accounts");

        //    migrationBuilder.DropTable(
        //        name: "Customers");
        }
    }
}
