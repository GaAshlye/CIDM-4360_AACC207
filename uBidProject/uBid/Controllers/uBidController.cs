using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using uBid.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using ValidationLib;
// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using uBid.Models;

// using ValidationLib;

namespace uBid.Controllers
{
    public class uBidController : Controller
    {
#region "Scaffold"
        private readonly uBidContext _context;

        public uBidController(uBidContext context)
        {
            _context = context;
        }

        // GET: uBid
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: uBid/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.User
                .SingleOrDefaultAsync(m => m.userID == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // GET: uBid/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: uBid/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("userID")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userModel);
        }
        

        // GET: uBid/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.User.SingleOrDefaultAsync(m => m.userID == id);
            if (userModel == null)
            {
                return NotFound();
            }
            return View(userModel);
        }

        // POST: uBid/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("userID")] UserModel userModel)
        {
            if (id != userModel.userID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModelExists(userModel.userID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userModel);
        }

        // GET: uBid/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.User
                .SingleOrDefaultAsync(m => m.userID == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // POST: uBid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userModel = await _context.User.SingleOrDefaultAsync(m => m.userID == id);
            _context.User.Remove(userModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserModelExists(int id)
        {
            return _context.User.Any(e => e.userID == id);
        }
#endregion

    //Login and logout session
#region "Login logout"
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
        #endregion


    }
}
