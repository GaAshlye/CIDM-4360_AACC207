using System;
using System.Text.RegularExpressions;

namespace uBid.Models
{
  
    public class UserModel
    {
        #region "Properties"
        string userName{get; set;}
        string passWord{get; set;}
        string emails{get; set;}
        string address{get; set;}
        string zip{get; set;}
       // int bidID Bid{get; set;}
       int userID {get; set;}
       long creditCard {get; set;}
       string billAddress{get;set;}
       string billZip{get;set;}
       
        #endregion 
        

       public UserModel()
       {
           //constructor
       }
       #region "Functions"
       public virtual void editAccountInfo()
       {
           // code
       }
       public static void Login()
       {
           //code
       }
       public static void Logout()
       {
           //code
       }
       public static void createAccount()
       {
           //code 
       }
       #endregion
    }
}