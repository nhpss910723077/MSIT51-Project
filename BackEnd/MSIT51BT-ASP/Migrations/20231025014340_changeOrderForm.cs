using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSIT51BT_ASP.Migrations
{
    /// <inheritdoc />
    public partial class changeOrderForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                table: "OrderForm",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ReceivePhone",
                table: "OrderForm",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiveName",
                table: "OrderForm",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiveEmail",
                table: "OrderForm",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiveDistrict",
                table: "OrderForm",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiveCounty",
                table: "OrderForm",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiveAddress",
                table: "OrderForm",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9556), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9555) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9557), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9557) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9559), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9558) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9560), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9559) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9561), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9560) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9562), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9561) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9563), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9563) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9564), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9564) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9565), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9565) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9566), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9566) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9567), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9567) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9568), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9568) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9569), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9569) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9570), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9570) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9571), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9571) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9572), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9572) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9573), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9573) });

            migrationBuilder.UpdateData(
                table: "NewsCategory",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9471), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9463) });

            migrationBuilder.UpdateData(
                table: "NewsCategory",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9472), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9472) });

            migrationBuilder.UpdateData(
                table: "Payment",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9536), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9535) });

            migrationBuilder.UpdateData(
                table: "Payment",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9538), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9537) });

            migrationBuilder.UpdateData(
                table: "Payment",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9539), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9538) });

            migrationBuilder.UpdateData(
                table: "Shipping",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9546), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9545) });

            migrationBuilder.UpdateData(
                table: "Shipping",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9547), new DateTime(2023, 10, 25, 9, 43, 40, 474, DateTimeKind.Local).AddTicks(9547) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                table: "OrderForm",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceivePhone",
                table: "OrderForm",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiveName",
                table: "OrderForm",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiveEmail",
                table: "OrderForm",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiveDistrict",
                table: "OrderForm",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiveCounty",
                table: "OrderForm",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiveAddress",
                table: "OrderForm",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1048), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1048) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1050), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1050) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1051), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1051) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1052), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1052) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1053), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1053) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1054), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1054) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1055), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1055) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1056), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1056) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1057), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1057) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1059), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1058) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1060), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1059) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1061), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1060) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1062), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1061) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1063), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1062) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1064), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1063) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1065), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1064) });

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1066), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1065) });

            migrationBuilder.UpdateData(
                table: "NewsCategory",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(925), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(916) });

            migrationBuilder.UpdateData(
                table: "NewsCategory",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(927), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(926) });

            migrationBuilder.UpdateData(
                table: "Payment",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1017), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1016) });

            migrationBuilder.UpdateData(
                table: "Payment",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1019), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1018) });

            migrationBuilder.UpdateData(
                table: "Payment",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1020), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1020) });

            migrationBuilder.UpdateData(
                table: "Shipping",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1030), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "Shipping",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1036), new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1036) });
        }
    }
}
