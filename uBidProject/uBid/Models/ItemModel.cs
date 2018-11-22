using System;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore; 
using System.ComponentModel.DataAnnotations;

namespace uBid.Models
{
    public class ItemModel
    {
        
        [Key]
        public int itemID {get; set;}
        public string name{get;set;}       
        public string longDesc{get;set;}
        public string shortDesc{get; set;}
        public string serialNum{get;set;}
        public string modelNum{get;set;}
        public double reservePrice{get;set;}
        public int category{get; set;}
        //cat 1 = clothing
        //cat 2 = automobile
        //cat 3 = property
        //cat 4 = electronics
        public double highestBid{get; set;}
        public DateTime startTime{get;set;}
        public DateTime endTime{get;set;}

        
        SellerModel seller{get;set;}
        

        // public void calcHighBid()
        // {
        //     //code
        // }
        // public void displayHighestBid()
        // {
        //     //code 
        // }
    }
}