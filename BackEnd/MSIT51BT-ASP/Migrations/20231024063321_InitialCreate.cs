using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MSIT51BT_ASP.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banner",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Link = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Img1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Img2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banner", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Config",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCategory = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataValue = table.Column<int>(type: "int", nullable: false),
                    DataName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LineBind",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineBind", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FbMemberNumber = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    GoogleMemberNumber = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    LineMemberNumber = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Account = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    County = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    District = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Zipcode = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LineBindCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ShoppingMoney = table.Column<int>(type: "int", nullable: false),
                    VerifyCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    VerifyStatus = table.Column<bool>(type: "bit", nullable: false),
                    PublicBookcase = table.Column<bool>(type: "bit", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NewsCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EcpayName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SearchKeyword",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchKeyword", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Shipping",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EcpayName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    AllowPayment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Fee = table.Column<int>(type: "int", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipping", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MemberMessage",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberMessage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MemberMessage_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderForm",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    ShippingFee = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    ShippingType = table.Column<int>(type: "int", nullable: false),
                    ReceiveName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReceiveEmail = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ReceivePhone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReceiveCounty = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ReceiveDistrict = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ReceiveZipcode = table.Column<int>(type: "int", nullable: false),
                    ReceiveAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVSID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CVSStoreName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CVSStoreAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ATMBankCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ATMAccount = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShippingNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShippingCVSPaymentNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentStatus = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderForm", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderForm_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingMoneyRecord",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    Money = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingMoneyRecord", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShoppingMoneyRecord_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsCategoryID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Img1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.ID);
                    table.ForeignKey(
                        name: "FK_News_NewsCategory_NewsCategoryID",
                        column: x => x.NewsCategoryID,
                        principalTable: "NewsCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategoryID = table.Column<int>(type: "int", nullable: false),
                    ISBN10 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ISBN13 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ListPrice = table.Column<int>(type: "int", nullable: false),
                    SalePrice = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Sold = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Translator = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Publisher = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Img1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory_ProductCategoryID",
                        column: x => x.ProductCategoryID,
                        principalTable: "ProductCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderCancel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderFormID = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCancel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderCancel_OrderForm_OrderFormID",
                        column: x => x.OrderFormID,
                        principalTable: "OrderForm",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderReturn",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderFormID = table.Column<int>(type: "int", nullable: false),
                    ReturnProduct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderReturn", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderReturn_OrderForm_OrderFormID",
                        column: x => x.OrderFormID,
                        principalTable: "OrderForm",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookcase",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ReviewTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookcase", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bookcase_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookcase_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Favorite",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorite", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Favorite_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favorite_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderFormID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SalePrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderDetail_OrderForm_OrderFormID",
                        column: x => x.OrderFormID,
                        principalTable: "OrderForm",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsedSale",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    SalePrice = table.Column<int>(type: "int", nullable: false),
                    WithdrawType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RemitAccount = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BookStatus = table.Column<int>(type: "int", nullable: false),
                    Img1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Img2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Img3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Img4 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Img5 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    VerifyStatus = table.Column<int>(type: "int", nullable: false),
                    VerifyDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sold = table.Column<bool>(type: "bit", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsedSale", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsedSale_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsedSale_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsedSeek",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    SeekPrice = table.Column<int>(type: "int", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsedSeek", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsedSeek_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsedSeek_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    UsedID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cart_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cart_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cart_UsedSale_UsedID",
                        column: x => x.UsedID,
                        principalTable: "UsedSale",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Config",
                columns: new[] { "ID", "CreateTime", "DataCategory", "DataName", "DataValue", "Enable", "Sort", "UpdateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1048), "Enable", "停用", 0, true, 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1048) },
                    { 2, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1050), "Enable", "啟用", 1, true, 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1050) },
                    { 3, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1051), "OrderStatus", "訂單成立", 0, true, 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1051) },
                    { 4, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1052), "OrderStatus", "訂單待收貨", 1, true, 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1052) },
                    { 5, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1053), "OrderStatus", "訂單完成", 2, true, 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1053) },
                    { 6, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1054), "OrderStatus", "訂單取消", 3, true, 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1054) },
                    { 7, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1055), "OrderStatus", "訂單退貨", 4, true, 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1055) },
                    { 8, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1056), "BookStatus", "全新", 0, true, 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1056) },
                    { 9, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1057), "BookStatus", "良好", 1, true, 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1057) },
                    { 10, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1059), "BookStatus", "有註記", 2, true, 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1058) },
                    { 11, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1060), "BookVerifyStatus", "審核中", 0, true, 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1059) },
                    { 12, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1061), "BookVerifyStatus", "銷售中", 1, true, 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1060) },
                    { 13, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1062), "BookVerifyStatus", "已售出", 2, true, 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1061) },
                    { 14, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1063), "BookVerifyStatus", "已下架", 3, true, 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1062) },
                    { 15, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1064), "Gender", "男性", 0, true, 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1063) },
                    { 16, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1065), "Gender", "女性", 1, true, 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1064) },
                    { 17, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1066), "Gender", "不提供", 2, true, 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1065) }
                });

            migrationBuilder.InsertData(
                table: "NewsCategory",
                columns: new[] { "ID", "CreateTime", "Enable", "Name", "Sort", "UpdateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(925), true, "優惠活動", 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(916) },
                    { 2, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(927), true, "最新公告", 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(926) }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "ID", "CreateTime", "EcpayName", "Enable", "Name", "Sort", "UpdateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1017), null, true, "銀行轉帳", 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1016) },
                    { 2, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1019), null, true, "貨到付款", 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1018) },
                    { 3, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1020), "XXXXXXX", true, "信用卡", 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1020) }
                });

            migrationBuilder.InsertData(
                table: "Shipping",
                columns: new[] { "ID", "AllowPayment", "CreateTime", "EcpayName", "Enable", "Fee", "Name", "Sort", "UpdateTime" },
                values: new object[,]
                {
                    { 1, "[1, 2, 3]", new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1030), "DDDDDDDDD", true, 60, "超商取貨", 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1030) },
                    { 2, "[1, 3]", new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1036), null, true, 100, "宅配", 0, new DateTime(2023, 10, 24, 14, 33, 21, 21, DateTimeKind.Local).AddTicks(1036) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookcase_MemberID",
                table: "Bookcase",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookcase_ProductID",
                table: "Bookcase",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_MemberID",
                table: "Cart",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductID",
                table: "Cart",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UsedID",
                table: "Cart",
                column: "UsedID");

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_MemberID",
                table: "Favorite",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_ProductID",
                table: "Favorite",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Member_Account",
                table: "Member",
                column: "Account",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_FbMemberNumber",
                table: "Member",
                column: "FbMemberNumber",
                unique: true,
                filter: "[FbMemberNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Member_GoogleMemberNumber",
                table: "Member",
                column: "GoogleMemberNumber",
                unique: true,
                filter: "[GoogleMemberNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Member_LineMemberNumber",
                table: "Member",
                column: "LineMemberNumber",
                unique: true,
                filter: "[LineMemberNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MemberMessage_MemberID",
                table: "MemberMessage",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_News_NewsCategoryID",
                table: "News",
                column: "NewsCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderCancel_OrderFormID",
                table: "OrderCancel",
                column: "OrderFormID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderFormID",
                table: "OrderDetail",
                column: "OrderFormID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductID",
                table: "OrderDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderForm_MemberID",
                table: "OrderForm",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderForm_Number",
                table: "OrderForm",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderReturn_OrderFormID",
                table: "OrderReturn",
                column: "OrderFormID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ISBN10",
                table: "Product",
                column: "ISBN10",
                unique: true,
                filter: "[ISBN10] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ISBN13",
                table: "Product",
                column: "ISBN13",
                unique: true,
                filter: "[ISBN13] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryID",
                table: "Product",
                column: "ProductCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingMoneyRecord_MemberID",
                table: "ShoppingMoneyRecord",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_UsedSale_MemberID",
                table: "UsedSale",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_UsedSale_ProductID",
                table: "UsedSale",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_UsedSeek_MemberID",
                table: "UsedSeek",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_UsedSeek_ProductID",
                table: "UsedSeek",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banner");

            migrationBuilder.DropTable(
                name: "Bookcase");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Config");

            migrationBuilder.DropTable(
                name: "Favorite");

            migrationBuilder.DropTable(
                name: "LineBind");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "MemberMessage");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "OrderCancel");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "OrderReturn");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "SearchKeyword");

            migrationBuilder.DropTable(
                name: "Shipping");

            migrationBuilder.DropTable(
                name: "ShoppingMoneyRecord");

            migrationBuilder.DropTable(
                name: "UsedSeek");

            migrationBuilder.DropTable(
                name: "UsedSale");

            migrationBuilder.DropTable(
                name: "NewsCategory");

            migrationBuilder.DropTable(
                name: "OrderForm");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "ProductCategory");
        }
    }
}
