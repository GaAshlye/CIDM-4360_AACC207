using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using uBid.Models;
using System.Collections.Generic;
namespace uBid.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new uBidContext(
                serviceProvider.GetRequiredService<DbContextOptions<uBidContext>>()))
            {
#region "Users Seeded"
                // Look for any users
                
                if (context.User.Any())
                {
                    return;
                }
                //Users
                var users = new List<UserModel>
                {
                    new UserModel
                    {
                        userName = "abc",
                        passWord = "abc123@abc123",
                        emails = "abc123@gmail.com",
                        address = "12 Tarter Ave Amarillo TX",
                        zip = "78163",
                        creditCard = 8888888888888888,
                        billAddress = "12 Tarter Ave Amarillo TX 12645",
                        billZip = "78163"
                    },
                    new UserModel
                    {
                        userName = "def",
                        passWord = "def123@def123",
                        emails = "def123@gmail.com",
                        address = "14 Coulter Cincinati OH ",
                        zip = "78999",
                        creditCard = 1111222233334444,
                        billAddress = "14 Coulter Cincinati OH ",
                        billZip = "78999"
                    },
                    new UserModel
                    {
                        userName = "def",
                        passWord = "def123@def123",
                        emails = "def123@gmail.com",
                        address = "14 Coulter Cincinati OH ",
                        zip = "78999",
                        creditCard = 1111222233334444,
                        billAddress = "14 Coulter Cincinati OH ",
                        billZip = "78999"
                    }
                };
                context.AddRange(users);
                context.SaveChanges(); 
#endregion

#region "Items Seeded"   
                if (context.Item.Any())
                {
                    return; //there is already data in the database
                }
                var items = new List<ItemModel>
                {
                    new ItemModel
                     {
                         name = "Jacket",
                         longDesc = "Gently worn guess jacket that I bought last year hardly worn.",
                         shortDesc = "Jacket lightly worn",
                         serialNum = "NA",
                         modelNum = "NA",
                         reservePrice = 50.00,
                         category = 1,
                         startTime = new DateTime(2012, 12, 31, 16, 45, 0),
                         endTime = new DateTime(2012, 12, 31, 16, 50, 0)
                     },

                     new ItemModel
                     {
                         name = "Toyota Corolla",
                         longDesc = "Blue toyota corolla 2014, 30,000 miles and clean",
                         shortDesc = "Blue 2014 Toyota Corolla",
                         serialNum = "123456",
                         modelNum = "abc1234567",
                         reservePrice = 60000,
                         category = 2,
                         startTime = new DateTime(2012, 12, 31, 17, 45, 0),
                         endTime = new DateTime(2012, 12, 31, 17, 50, 0)
                     },
                     
                     new ItemModel
                     {
                         name = "Lamp",
                         longDesc = "Silver lamp, year 1940, only 5 made ever. ",
                         shortDesc = "silver lamp",
                         serialNum = "555666",
                         modelNum = "abcdeflkaj99",
                         reservePrice = 1000,
                         category = 3,
                         startTime = new DateTime(2012, 12, 31, 17, 45, 0),
                         endTime = new DateTime(2012, 12, 31, 18, 50, 0)
                     },
                     
                     new ItemModel
                     {
                         name = "IPAD Pro",
                         longDesc = "2016 IPAD Pro, 12.7 inches, retina display",
                         shortDesc = "Ipad Pro with Retina",
                         serialNum = "123456789",
                         modelNum = "abc12345676666",
                         reservePrice = 1400,
                         category = 4,
                         startTime = new DateTime(2012, 12, 31, 17, 45, 0),
                         endTime = new DateTime(2012, 12, 31, 19, 50, 0)
                     }      
                };
                context.AddRange(items);
                context.SaveChanges();
            }
#endregion            
        }
    }
}