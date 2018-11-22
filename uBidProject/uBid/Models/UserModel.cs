using System;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore; 
using System.ComponentModel.DataAnnotations;

namespace uBid.Models
{
  
    public class UserModel
    {
      
        [Key]
        public int userID {get; set;}      
       
        public string userName{get; set;}
        public string passWord{get; set;}
        public string emails{get; set;}
        public string address{get; set;}
        public string zip{get; set;}           
        public long creditCard {get; set;}
        public string billAddress{get;set;}
        public string billZip{get;set;}
       
      
        

       #region "Constructor"
    //    public UserModel()
    //    {
    //        //constructor
    //    }
       #endregion
       #region "Functions"
       public static void AddLogin(string username, string passWord)
       {
            
       }
       
    //    public virtual void editAccountInfo()
    //    {
    //        // code
    //    }
    //    public static void Login()
    //    {
    //        //code
    //    }
    //    public static void Logout()
    //    {
    //        //code
    //    }
    //    public static void createAccount()
    //    {
    //        //code 
    //    }
       #endregion
    }
}