using System;

namespace uBid.Models
{
    public class ItemModel
    {
        int itemID {get; set;}
        string name{get;set;}
        char image{get;set;}
        string longDesc{get;set;}
        string shortDesc{get; set;}
        string serialNum{get;set;}
        string modelNum{get;set;}
        double reservePrice{get;set;}
        DateTime startTime{get;set;}
        DateTime endTime{get;set;}
        SellerModel seller{get;set;}
        double highestBid{get; set;}

        public void calcHighBid()
        {
            //code
        }
        public void displayHighestBid()
        {
            //code 
        }
    }
}