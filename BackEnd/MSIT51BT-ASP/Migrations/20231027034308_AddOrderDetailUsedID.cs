using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSIT51BT_ASP.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderDetailUsedID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsedID",
                table: "OrderDetail",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9590), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9590) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9592), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9592) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9593), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9593) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9594), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9594) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9595), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9595) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9596), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9596) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9597), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9597) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9598), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9598) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9599), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9599) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9600), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9600) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9601), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9601) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9602), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9602) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9603), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9603) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9604), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9603) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9605), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9604) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9606), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9605) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9607), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9606) });

            migrationBuilder.UpdateData(
                table: "NewsCategory",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9497), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9491) });

            migrationBuilder.UpdateData(
                table: "NewsCategory",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9498), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9498) });

            migrationBuilder.UpdateData(
                table: "Payment",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9567), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9566) });

            migrationBuilder.UpdateData(
                table: "Payment",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9568), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9568) });

            migrationBuilder.UpdateData(
                table: "Payment",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9569), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9569) });

            migrationBuilder.UpdateData(
                table: "Shipping",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9578), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9578) });

            migrationBuilder.UpdateData(
                table: "Shipping",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9580), new DateTime(2023, 10, 27, 11, 43, 7, 952, DateTimeKind.Local).AddTicks(9580) });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_UsedID",
                table: "OrderDetail",
                column: "UsedID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_UsedSale_UsedID",
                table: "OrderDetail",
                column: "UsedID",
                principalTable: "UsedSale",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_UsedSale_UsedID",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_UsedID",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "UsedID",
                table: "OrderDetail");

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2537), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2536) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2538), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2538) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2539), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2539) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2540), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2540) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2541), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2541) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2542), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2542) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2543), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2543) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2544), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2544) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2545), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2545) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2546), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2546) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2547), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2547) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2548), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2548) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2549), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2549) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2550), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2550) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2551), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2551) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2552), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2552) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2553), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2553) });

            migrationBuilder.UpdateData(
                table: "NewsCategory",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2447), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2441) });

            migrationBuilder.UpdateData(
                table: "NewsCategory",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2449), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2448) });

            migrationBuilder.UpdateData(
                table: "Payment",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2515), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2515) });

            migrationBuilder.UpdateData(
                table: "Payment",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2517), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2517) });

            migrationBuilder.UpdateData(
                table: "Payment",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2518), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2518) });

            migrationBuilder.UpdateData(
                table: "Shipping",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2526), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2526) });

            migrationBuilder.UpdateData(
                table: "Shipping",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2528), new DateTime(2023, 10, 27, 11, 5, 5, 907, DateTimeKind.Local).AddTicks(2528) });
        }
    }
}
