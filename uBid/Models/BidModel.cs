using System;

namespace uBid.Models
{
    public class BidModel
    {
        int bidId{get;set;}
        BuyerModel user{get;set;}
        double bidAmount{get;set;}
        DateTime timeStamp{get;set;}
        int itemID{get;set;}
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