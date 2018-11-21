using Microsoft.EntityFrameworkCore;


namespace uBid.Models
{
    public class uBidContext : DbContext
    {    
          
         public uBidContext (DbContextOptions<uBidContext> options)
            : base(options)
        {
        }        
    

        //public DbSet<uBid.Models.BidModel> Bid { get; set; }
        //public DbSet<uBid.Models.BuyerModel> Buyer {get; set;}
        public DbSet<uBid.Models.ItemModel> Item{get; set;}
       // public DbSet<uBid.Models.SellerModel> Seller{get; set;}
        public DbSet<uBid.Models.UserModel> User{get; set;}
        
    }
}