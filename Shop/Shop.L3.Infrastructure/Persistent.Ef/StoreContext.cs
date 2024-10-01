
using Microsoft.EntityFrameworkCore;
using Shop.L1.Domain.Category_Aggregate;
using Shop.L1.Domain.Comment_Aggregate;
using Shop.L1.Domain.Order_Aggregate;
using Shop.L1.Domain.Product_Aggregate;
using Shop.L1.Domain.Role_Aggregate;
using Shop.L1.Domain.Seller_Aggregate;
using Shop.L1.Domain.SiteEntities;
using Shop.L1.Domain.User_Aggregate;


namespace Shop.L3.Infrastructure.Persistent.Ef
{
	public class StoreContext : DbContext
	{
        public DbSet<Category> Categories {  get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders {  get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Seller> Sellers { get; set; }
		public DbSet<SellerInventory> Inventories { get; set; }

		public DbSet<Slider> Sliders { get; set; }
        public DbSet<Banner> Banners { get; set; }
		public DbSet<ShippingMethod> ShippingMethods { get; set; }
		public DbSet<User> Users { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options) 
        {
            
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreContext).Assembly);
			base.OnModelCreating(modelBuilder);
		}
	}
}
