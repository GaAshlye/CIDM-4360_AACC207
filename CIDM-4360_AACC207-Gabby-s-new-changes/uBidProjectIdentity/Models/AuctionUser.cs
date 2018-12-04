using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace uBidProjectIdentity.Models
{
    public class AuctionUser : IdentityUser
    {
#region "Properties"
        public string name {get;set;}       
        public string creditCard {get; set;}
        public string address {get; set;}
        public string zipCode {get; set;}
#endregion

        #region "Functions"
        // public override void editAccountInfo()
        // {
        //     //code
        // }
        public void GetUser()
        {
            //code 
        }
        #endregion
    }
}