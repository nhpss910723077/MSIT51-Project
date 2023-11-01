using Microsoft.EntityFrameworkCore;

namespace MSIT51BT_ASP.Models
{
    public class SqlSeedData
    {

        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsCategory>().HasData(
                new NewsCategory
                {
                    ID = 1,
                    Name = "優惠活動",
                    Sort = 0,
                    Enable = true,
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now
                },
                new NewsCategory
                {
                    ID = 2,
                    Name = "最新公告",
                    Sort = 0,
                    Enable = true,
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now
                }
            );

            modelBuilder.Entity<Payment>().HasData(
                new Payment {
                    ID = 1,
                    EcpayName = null,
                    Name = "銀行轉帳",
                    Sort = 0,
                    Enable = true,
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now
                },
                new Payment {
                    ID = 2,
                    EcpayName = null,
                    Name = "貨到付款",
                    Sort = 0,
                    Enable = true,
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now
                },
                new Payment {
                    ID = 3,
                    EcpayName = "XXXXXXX",
                    Name = "信用卡",
                    Sort = 0,
                    Enable = true,
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now
                }
            );

            modelBuilder.Entity<Shipping>().HasData(
                new Shipping {
                    ID = 1,
                    EcpayName = "DDDDDDDDD",
                    AllowPayment = "[1, 2, 3]",
                    Name = "超商取貨",
                    Fee = 60,
                    Sort = 0,
                    Enable = true,
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now
                },
                new Shipping {
                    ID = 2,
                    EcpayName = null,
                    AllowPayment = "[1, 3]",
                    Name = "宅配",
                    Fee = 100,
                    Sort = 0,
                    Enable = true,
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now
                }
            );

            modelBuilder.Entity<Config>().HasData(
                new Config {
                    ID = 1,
                    DataCategory = "Enable",
                    DataValue = 0,
                    DataName = "停用",
                    Sort = 0,
                    Enable = true,
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now
                },
                new Config {
                    ID = 2,
                    DataCategory = "Enable",
                    DataValue = 1,
                    DataName = "啟用",
                    Sort = 0,
                    Enable = true,
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now
                },
                new Config {
                    ID = 3,
                    DataCategory = "OrderStatus",
                    DataValue = 0,
                    DataName = "訂單成立",
                    Sort = 0,
                    Enable = true,
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now
                },
                new Config {
                    ID = 4,
                    DataCategory = "OrderStatus",
                    DataValue = 1,
                    DataName = "訂單待收貨",
                    Sort = 0,
                    Enable = true,
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now
                },
                new Config {
                    ID = 5,
                    DataCategory = "OrderStatus",
                    DataValue = 2,
                    DataName = "訂單完成",
                    Sort = 0,
                    Enable = true,
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now
                },
                new Config {
                    ID = 6,
                    DataCategory = "OrderStatus",
                    DataValue = 3,
                    DataName = "訂單取消",
                    Sort = 0,
                    Enable = true,
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now
                },
                new Config {
                    ID = 7,
                    DataCategory = "OrderStatus",
                    DataValue = 4,
                    DataName = "訂單退貨",
                    Sort = 0,
                    Enable = true,
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now
                },
				new Config {
					ID = 8,
					DataCategory = "BookStatus",
					DataValue = 0,
					DataName = "全新",
					Sort = 0,
					Enable = true,
					UpdateTime = DateTime.Now,
					CreateTime = DateTime.Now
				},
				new Config {
					ID = 9,
					DataCategory = "BookStatus",
					DataValue = 1,
					DataName = "良好",
					Sort = 0,
					Enable = true,
					UpdateTime = DateTime.Now,
					CreateTime = DateTime.Now
				},
				new Config {
                    ID = 10,
                    DataCategory = "BookStatus",
                    DataValue = 2,
                    DataName = "有註記",
                    Sort = 0,
                    Enable = true,
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now
                },
                new Config {
                    ID = 11,
                    DataCategory = "BookVerifyStatus",
                    DataValue = 0,
                    DataName = "審核中",
                    Sort = 0,
                    Enable = true,
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now
                },
                new Config {
                    ID = 12,
                    DataCategory = "BookVerifyStatus",
                    DataValue = 1,
                    DataName = "銷售中",
                    Sort = 0,
                    Enable = true,
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now
                },
				new Config {
					ID = 13,
					DataCategory = "BookVerifyStatus",
					DataValue = 2,
					DataName = "已售出",
					Sort = 0,
					Enable = true,
					UpdateTime = DateTime.Now,
					CreateTime = DateTime.Now
				},
				new Config {
					ID = 14,
					DataCategory = "BookVerifyStatus",
					DataValue = 3,
					DataName = "已下架",
					Sort = 0,
					Enable = true,
					UpdateTime = DateTime.Now,
					CreateTime = DateTime.Now
				},
				new Config {
					ID = 15,
					DataCategory = "Gender",
					DataValue = 0,
					DataName = "男性",
					Sort = 0,
					Enable = true,
					UpdateTime = DateTime.Now,
					CreateTime = DateTime.Now
				},
				new Config {
					ID = 16,
					DataCategory = "Gender",
					DataValue = 1,
					DataName = "女性",
					Sort = 0,
					Enable = true,
					UpdateTime = DateTime.Now,
					CreateTime = DateTime.Now
				},
				new Config {
					ID = 17,
					DataCategory = "Gender",
					DataValue = 2,
					DataName = "不提供",
					Sort = 0,
					Enable = true,
					UpdateTime = DateTime.Now,
					CreateTime = DateTime.Now
				}
			);

            /*
            範例
            modelBuilder.Entity<XXXXXXXXXX>().HasData(
                new XXXXXXXXX {
                    ID = 1,
                    Name = "DDDDDDDDD",
                    Sort = 0,
                    Enable = true,
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now
                },
            );
            */
        }
    }
}
