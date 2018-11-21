using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using uBid.Models;
using Microsoft.AspNetCore.Http;
using ValidationLib; 




namespace uBid.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }

        UserModel un = new UserModel(); 

        // public void Login(string userName, string passWord)
        // {
        //     Console.WriteLine("Please enter in your username: ");
        //     userName = Console.ReadLine();
        //     Console.WriteLine("Please enter in your password: ");
        //     passWord = Console.ReadLine(); 

        //     if (userName != un.userName)
        //     {
        //         if (passWord != un.passWord)
        //         {
        //             Console.WriteLine("Your username or password are incorrect. Please try again");
        //         }
        //     }
        //     else
        //     {
        //         Console.WriteLine("Congrats!");
        //     }
        // }
        public const string SESSION_LOGIN_KEY = "_UserLogin";

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DoAddUser(UserModel model)
        {

            try{
                //raises an error
                if(!LoginValidator.ValidateUsername(model.userName)){}
                if(!LoginValidator.ValidatePassword(model.passWord)){}
            }
            catch(Exception exp)
            {
                ViewData["ErrorMessage"] = exp.Message;
                return View("ErrorAddUser");
            }

            
            Repository.AddLogin(model);
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            
            if(HttpContext.Session.GetString(SESSION_LOGIN_KEY) == null){
                ViewData["IsLoggedIn"] = false;
                ViewData["LoginMessage"] = "Is Not Logged In";           
                return View();
                
            }else{

                string loginname = HttpContext.Session.GetString(SESSION_LOGIN_KEY);
                UserModel um = Repository.ValidateLogin(loginname);
                ViewData["IsLoggedIn"] = true;
                ViewData["LoginMessage"] = "Is Logged In";                     
                
                //chapter 5
                return View(um);
            }

        }

        [HttpPost]
        public IActionResult DoLogin(UserModel model)
        {

            if(Repository.ValidatePassword(model)){

                //overwrite session
                HttpContext.Session.Clear();
                HttpContext.Session.SetString(SESSION_LOGIN_KEY, model.userName);

                //set values for the view
                ViewData["IsLoggedIn"] = true;
                ViewData["LoginMessage"] = "Is Logged In";
            }
            else
            {
                //login was not correct
                ViewData["IsLoggedIn"] = false;
                ViewData["LoginMessage"] = "Username and/or Password is incorrect";
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            ViewData["IsLoggedIn"] = false;
            ViewData["LoginMessage"] = "User is logged out";
            return Redirect("~/Home/Index");
        }        

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
