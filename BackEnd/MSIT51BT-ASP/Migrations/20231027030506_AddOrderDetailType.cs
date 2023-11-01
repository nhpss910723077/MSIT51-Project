using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSIT51BT_ASP.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderDetailType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "OrderDetail",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "OrderDetail");

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4009), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4009) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4011), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4011) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4012), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4012) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4013), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4013) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4014), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4014) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4015), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4015) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4016), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4016) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4017), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4017) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4018), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4018) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4019), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4019) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4020), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4020) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4021), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4021) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4022), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4022) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4023), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4023) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4024), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4024) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4025), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4025) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4026), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4026) });

            migrationBuilder.UpdateData(
                table: "NewsCategory",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(3922), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(3915) });

            migrationBuilder.UpdateData(
                table: "NewsCategory",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(3923), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(3923) });

            migrationBuilder.UpdateData(
                table: "Payment",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(3987), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(3986) });

            migrationBuilder.UpdateData(
                table: "Payment",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(3988), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(3988) });

            migrationBuilder.UpdateData(
                table: "Payment",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(3989), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(3989) });

            migrationBuilder.UpdateData(
                table: "Shipping",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(3999), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "Shipping",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4000), new DateTime(2023, 10, 25, 14, 22, 29, 544, DateTimeKind.Local).AddTicks(4000) });
        }
    }
}
