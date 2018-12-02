using System;
using System.Text.RegularExpressions; 
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace uBidProjectIdentity.Models
{
    public class BidModel
    {
        [Key]
        public int bidId{get;set;}
        public AuctionUser user;  
        //BuyerModel user{get;set;}
        public double maxBid{get;set;}
        public double bidAmount{get;set;}
        public DateTime timeStamp{get;set;}
        public int itemID{get;set;}
        public BidModel()
        {
            //constructor
        }
        #region "Functions"
        public void distributePayment()
        {
            //code
        }
        public void createBidLog()
        {
            //code 
        }
        public void storeBid()
        {
            //code
        }
        #endregion
    }
}