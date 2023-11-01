using Microsoft.EntityFrameworkCore;

namespace MSIT51BT_ASP.Models
{
    public class SqlContext : DbContext {
        public SqlContext(DbContextOptions<SqlContext> options)
            : base(options) {
        }

        public DbSet<Config> Config { get; set; }
        public DbSet<NewsCategory> NewsCategory { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<MemberMessage> MemberMessage { get; set; }
        public DbSet<Bookcase> Bookcase { get; set; }
        public DbSet<ShoppingMoneyRecord> ShoppingMoneyRecord { get; set; }
        public DbSet<SearchKeyword> SearchKeyword { get; set; }
        public DbSet<UsedSale> UsedSale { get; set; }
        public DbSet<UsedSeek> UsedSeek { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Shipping> Shipping { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<OrderForm> OrderForm { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
		public DbSet<OrderReturn> OrderReturn { get; set; }
		public DbSet<OrderCancel> OrderCancel { get; set; }
		public DbSet<Banner> Banner { get; set; }
		public DbSet<Manager> Manager { get; set; }
		public DbSet<LineBind> LineBind { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Config>(entity => {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.DataCategory)
                    .HasMaxLength(20);

                entity.Property(e => e.DataName)
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime2");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime2");
            });

            modelBuilder.Entity<NewsCategory>(entity => {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime2");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime2");
            });

            modelBuilder.Entity<News>(entity => {
                entity.HasKey(e => e.ID);

                entity.HasOne(e => e.NewsCategory)
                    .WithMany()
                    .HasForeignKey(e => e.NewsCategoryID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.Img1)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.Content)
                    .IsRequired(false);

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime2")
                    .IsRequired(false);

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime2")
                    .IsRequired(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime2");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime2");
            });

            modelBuilder.Entity<ProductCategory>(entity => {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime2");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime2");
            });

            modelBuilder.Entity<Product>(entity => {
                entity.HasKey(e => e.ID);

                entity.HasOne(e => e.ProductCategory)
                    .WithMany()
                    .HasForeignKey(e => e.ProductCategoryID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.ISBN10)
                    .HasMaxLength(30)
					.IsRequired(false);
				entity.HasIndex(e => e.ISBN10)
                    .IsUnique();

                entity.Property(e => e.ISBN13)
                    .HasMaxLength(30)
					.IsRequired(false);
				entity.HasIndex(e => e.ISBN13)
                    .IsUnique();

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.Author)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.Translator)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.Publisher)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.PublishDate)
                    .HasColumnType("datetime2");

                entity.Property(e => e.Img1)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.Content)
                    .IsRequired(false);

                entity.Property(e => e.AuthorContent)
                    .IsRequired(false);

                entity.Property(e => e.Specification)
                    .IsRequired(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime2");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime2");
            });

            modelBuilder.Entity<Member>(entity => {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.FbMemberNumber)
                    .HasMaxLength(300)
					.IsRequired(false);
                entity.HasIndex(e => e.FbMemberNumber)
                    .IsUnique();

                entity.Property(e => e.GoogleMemberNumber)
                    .HasMaxLength(300)
					.IsRequired(false);
				entity.HasIndex(e => e.GoogleMemberNumber)
                    .IsUnique();

                entity.Property(e => e.LineMemberNumber)
                    .HasMaxLength(300)
					.IsRequired(false);
				entity.HasIndex(e => e.LineMemberNumber)
                    .IsUnique();

                entity.Property(e => e.Account)
                    .HasMaxLength(300);
                entity.HasIndex(e => e.Account)
                    .IsUnique();

				entity.Property(e => e.Password)
					.IsRequired(false);

				entity.Property(e => e.Name)
                    .HasMaxLength(100);

                entity.Property(e => e.NickName)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.County)
                    .HasMaxLength(10)
                    .IsRequired(false);

                entity.Property(e => e.District)
                    .HasMaxLength(10)
                    .IsRequired(false);

				entity.Property(e => e.Address)
					.HasMaxLength(100)
					.IsRequired(false);

				entity.Property(e => e.Birthday)
					.HasColumnType("datetime2")
					.IsRequired(false);

				entity.Property(e => e.LineBindCode)
                    .HasMaxLength(30);

                entity.Property(e => e.VerifyCode)
                    .HasMaxLength(30);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime2");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime2");
            });

            modelBuilder.Entity<MemberMessage>(entity => {
                entity.HasKey(e => e.ID);

                entity.HasOne(e => e.Member)
                    .WithMany()
                    .HasForeignKey(e => e.MemberID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.Content)
                    .IsRequired(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime2");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime2");
            });

            modelBuilder.Entity<Bookcase>(entity => {
                entity.HasKey(e => e.ID);

                entity.HasOne(e => e.Member)
                    .WithMany()
                    .HasForeignKey(e => e.MemberID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Product)
                    .WithMany()
                    .HasForeignKey(e => e.ProductID)
                    .OnDelete(DeleteBehavior.Restrict);

				entity.Property(e => e.ReviewTitle)
					.HasMaxLength(200)
					.IsRequired(false);

				entity.Property(e => e.Review)
					.IsRequired(false);

				entity.Property(e => e.Score)
					.IsRequired(false);

				entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime2");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime2");
            });

            modelBuilder.Entity<ShoppingMoneyRecord>(entity => {
                entity.HasKey(e => e.ID);

                entity.HasOne(e => e.Member)
                    .WithMany()
                    .HasForeignKey(e => e.MemberID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime2");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime2");
            });

            modelBuilder.Entity<SearchKeyword>(entity => {
                entity.HasKey(e => e.ID);
            });

            modelBuilder.Entity<UsedSale>(entity => {
                entity.HasKey(e => e.ID);

                entity.HasOne(e => e.Member)
                    .WithMany()
                    .HasForeignKey(e => e.MemberID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Product)
                    .WithMany()
                    .HasForeignKey(e => e.ProductID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.WithdrawType)
                    .HasMaxLength(20);

                entity.Property(e => e.RemitAccount)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.Img1)
                    .HasMaxLength(200)
                    .IsRequired(false);

                entity.Property(e => e.Img2)
                    .HasMaxLength(200)
                    .IsRequired(false);

                entity.Property(e => e.Img3)
                    .HasMaxLength(200)
                    .IsRequired(false);

                entity.Property(e => e.Img4)
                    .HasMaxLength(200)
                    .IsRequired(false);

                entity.Property(e => e.Img5)
                    .HasMaxLength(200)
                    .IsRequired(false);

                entity.Property(e => e.VerifyDateTime)
                    .HasColumnType("datetime2");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime2");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime2");
            });

            modelBuilder.Entity<UsedSeek>(entity => {
                entity.HasKey(e => e.ID);

                entity.HasOne(e => e.Member)
                    .WithMany()
                    .HasForeignKey(e => e.MemberID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Product)
                    .WithMany()
                    .HasForeignKey(e => e.ProductID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime2");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime2");
            });

            modelBuilder.Entity<Favorite>(entity => {
                entity.HasKey(e => e.ID);

                entity.HasOne(e => e.Member)
                    .WithMany()
                    .HasForeignKey(e => e.MemberID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Product)
                    .WithMany()
                    .HasForeignKey(e => e.ProductID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Payment>(entity => {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.EcpayName)
                    .HasMaxLength(30)
                    .IsRequired(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime2");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime2");
            });

            modelBuilder.Entity<Shipping>(entity => {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.EcpayName)
                    .HasMaxLength(30)
                    .IsRequired(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime2");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime2");
            });

            modelBuilder.Entity<Cart>(entity => {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.Type)
                    .HasMaxLength(10);

                entity.HasOne(e => e.Member)
                    .WithMany()
                    .HasForeignKey(e => e.MemberID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Product)
                    .WithMany()
                    .HasForeignKey(e => e.ProductID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.UsedSale)
                    .WithMany()
                    .HasForeignKey(e => e.UsedID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime2");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime2");
            });

            modelBuilder.Entity<OrderForm>(entity => {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.Number)
                    .HasMaxLength(20);
                entity.HasIndex(e => e.Number)
                    .IsUnique();

                entity.HasOne(e => e.Member)
                    .WithMany()
                    .HasForeignKey(e => e.MemberID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.ReceiveName)
                    .HasMaxLength(100)
					.IsRequired(false);

				entity.Property(e => e.ReceiveEmail)
                    .HasMaxLength(300)
					.IsRequired(false);

				entity.Property(e => e.ReceivePhone)
                    .HasMaxLength(100)
					.IsRequired(false);

				entity.Property(e => e.ReceiveCounty)
                    .HasMaxLength(10)
					.IsRequired(false);

				entity.Property(e => e.ReceiveDistrict)
					.HasMaxLength(10)
					.IsRequired(false);

				entity.Property(e => e.ReceiveZipcode)
					.IsRequired(false);

				entity.Property(e => e.ReceiveAddress)
					.HasMaxLength(100)
					.IsRequired(false);

				entity.Property(e => e.Remark)
					.IsRequired(false);

				entity.Property(e => e.CVSID)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.CVSStoreName)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.CVSStoreAddress)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.ATMBankCode)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.ATMAccount)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.ExpireDate)
                    .HasColumnType("datetime2")
                    .IsRequired(false);

                entity.Property(e => e.ShippingNumber)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.ShippingCVSPaymentNo)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.ShippingDate)
                    .HasColumnType("datetime2")
                    .IsRequired(false);

                entity.Property(e => e.PaymentTime)
                    .HasColumnType("datetime2")
                    .IsRequired(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime2");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime2");
            });

            modelBuilder.Entity<OrderDetail>(entity => {
                entity.HasKey(e => e.ID);

				entity.Property(e => e.Type)
					.HasMaxLength(10);

				entity.HasOne(e => e.OrderForm)
                    .WithMany()
                    .HasForeignKey(e => e.OrderFormID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Product)
                    .WithMany()
                    .HasForeignKey(e => e.ProductID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100);

				entity.HasOne(e => e.UsedSale)
					.WithMany()
					.HasForeignKey(e => e.UsedID)
					.OnDelete(DeleteBehavior.Restrict)
					.IsRequired(false);
			});

			modelBuilder.Entity<OrderReturn>(entity => {
				entity.HasKey(e => e.ID);

				entity.HasOne(e => e.OrderForm)
					.WithMany()
					.HasForeignKey(e => e.OrderFormID)
					.OnDelete(DeleteBehavior.Restrict);

				entity.Property(e => e.UpdateTime)
					.HasColumnType("datetime2");

				entity.Property(e => e.CreateTime)
					.HasColumnType("datetime2");
			});

			modelBuilder.Entity<OrderCancel>(entity => {
				entity.HasKey(e => e.ID);

				entity.HasOne(e => e.OrderForm)
					.WithMany()
					.HasForeignKey(e => e.OrderFormID)
					.OnDelete(DeleteBehavior.Restrict);

				entity.Property(e => e.UpdateTime)
					.HasColumnType("datetime2");

				entity.Property(e => e.CreateTime)
					.HasColumnType("datetime2");
			});

			modelBuilder.Entity<Banner>(entity => {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.Category)
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.Link)
                    .HasMaxLength(200)
                    .IsRequired(false);

                entity.Property(e => e.Img1)
                    .HasMaxLength(200)
                    .IsRequired(false);

                entity.Property(e => e.Img2)
                    .HasMaxLength(200)
                    .IsRequired(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime2");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime2");
            });

            modelBuilder.Entity<Manager>(entity => {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.Account)
                    .HasMaxLength(300);

                entity.Property(e => e.Password)
                    .HasMaxLength(300);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime2");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime2");
            });

            /*
             範例

             modelBuilder.Entity<XXXXXXX>(entity => {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime2");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime2");
            });


                // FK
                entity.HasOne(e => e.Member)
                    .WithMany()
                    .HasForeignKey(e => e.MemberID)
                    .OnDelete(DeleteBehavior.Restrict);

                // unique
                entity.Property(e => e.ISBN10)
                    .HasMaxLength(30);
                entity.HasIndex(e => e.ISBN10)
                    .IsUnique();
             */

            // 新增種子資料
            SqlSeedData.SeedData(modelBuilder);
        }
    }
}
