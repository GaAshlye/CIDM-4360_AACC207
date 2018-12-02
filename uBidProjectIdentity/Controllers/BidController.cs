using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using uBidProjectIdentity.Data;
using uBidProjectIdentity.Models;
using uBidProjectIdentity.Controllers; 

namespace uBidProjectIdentity.Controllers
{
    public class BidController : Controller
    {


         private readonly ApplicationDbContext _context;

         public BidController(ApplicationDbContext context)
         {
             _context = context; //link to dbsets 
         }

         public void Create(BidModel bidID, ItemModel ItemID, AuctionUser userName)//needs to be public IActionResult Create(etc)
         {
             if (ModelState.IsValid)
             {
                
                ItemModel item = _context.Item.Find(ItemID);    //Find(itemID);
                BidModel activeBid = _context.Bid.Find(item.bidID);
                //AuctionUser users = users.GetUsr(db, usrId);

            //base case, starting bid
            // if (item.ActiveBidId == null && item.Bids.Count == 0)
            // {
            //     bid.BidId = Guid.NewGuid();
            //     bid.ItemId = item.ItemId;
            //     bid.BidderId = usr.UsrId;
            //     bid.BidDate = DateTime.Now;

            //     bid.CurBid = item.InitialBid;
            //     bid.BidStatusId = 1;
            //     item.ActiveBidId = bid.BidId;
            //     db.Bids.Add(bid);
            // }
            // else
            // {
            //     //Validation for bid
            //     if (bid.MaxBid < activeBid.CurBid)
            //     {
            //         ModelState.AddModelError(string.Empty, "Your maximum bid must be greater than the current bid."); //does not currently show the error on create page
            //         return RedirectToAction("Create", "Bids", new { itemId, usrId });
            //     }

            //     //If the user is the active bidder, they are updating their max bid
            //     if (usr.UsrId == activeBid.Usr.UsrId)
            //     {
            //         activeBid.MaxBid = bid.MaxBid; 
            //     }
            //     //They are bidding against another user 
            //     else
            //     {
            //         //Start creating new bid info
            //         bid.BidId = Guid.NewGuid();
            //         bid.ItemId = item.ItemId;
            //         bid.BidderId = usr.UsrId;
            //         bid.BidDate = DateTime.Now;

            //         //1 is Active, 2 is Outbid, 3 is Superceded, 4 is inactive

            //         //if bidder's max is higher than current bid's max, they are the new active bid
            //         if (bid.MaxBid > activeBid.MaxBid)
            //         {
            //             //if the active bid isn't maxed out, then create a new maxed out autobid for that user
            //             if(activeBid.CurBid != activeBid.MaxBid)
            //             {
            //                 Bid activeMax = new Bid(Guid.NewGuid(), itemId, activeBid.Usr.UsrId, activeBid.MaxBid, activeBid.MaxBid, DateTime.Now, 3, null, item, null, activeBid.Usr);
            //                 db.Bids.Add(activeMax);
            //             }
            //             activeBid.BidStatusId = 3;
            //             //if the bid is less than the increment but more than current max, leave at max
            //             if(bid.MaxBid < activeBid.MaxBid + item.IncrementBy)
            //             {
            //                 bid.CurBid = bid.MaxBid;
            //             }
            //             //else increment the amount plus the current max bid
            //             else
            //             {
            //                 bid.CurBid = activeBid.MaxBid + item.IncrementBy;
            //             }
            //             bid.BidStatusId = 1;
            //             item.ActiveBidId = bid.BidId;
            //             db.Bids.Add(bid);
            //         }
            //         //if bidder's max is  lower than the current bid's max, then an auto bid is created
            //         // and the active bidder is still the active bidder with updated auto max bid
            //         else if (bid.MaxBid < activeBid.MaxBid)
            //         {
            //             bid.CurBid = bid.MaxBid;
            //             bid.BidStatusId = 2;
            //             db.Bids.Add(bid);
            //             activeBid.BidStatusId = 3;
            //             Bid newActive;
            //             if (activeBid.MaxBid < bid.MaxBid + item.IncrementBy)
            //             {
            //                 newActive = new Bid(Guid.NewGuid(), itemId, activeBid.Usr.UsrId, activeBid.MaxBid, activeBid.MaxBid, DateTime.Now, 1, null, item, null, activeBid.Usr);
            //             }
            //             else
            //             {
            //                 newActive = new Bid(Guid.NewGuid(), itemId, activeBid.Usr.UsrId, activeBid.MaxBid, bid.MaxBid + item.IncrementBy, DateTime.Now, 1, null, item, null, activeBid.Usr);
            //             }
            //             db.Bids.Add(newActive);
            //             item.ActiveBidId = newActive.BidId;
            //         }
            //         //If the max's are the same then the activebidder is still the active bidder
            //         //since he bid first, the bid will not show up on list currently (marked as outbid)
            //         else if (bid.MaxBid == activeBid.MaxBid)
            //         {
            //             bid.CurBid = bid.MaxBid;
            //             bid.BidStatusId = 2;
            //             db.Bids.Add(bid);
            //             activeBid.BidStatusId = 3;
            //             Bid newActive = new Bid(Guid.NewGuid(), itemId, activeBid.Usr.UsrId, activeBid.MaxBid, activeBid.MaxBid, DateTime.Now, 1, null, item, null, activeBid.Usr);
            //             db.Bids.Add(newActive);
            //             item.ActiveBidId = newActive.BidId;
            //         }
            //     }
            }
        }
        //Save changes to the db and redirect to the item's detail page
       // db.SaveChanges();
       // return RedirectToAction("Details", "Items", new { id = itemId });
             }
         }

        // public ItemController(ApplicationDbContext context)
        // {
        //     _context = context;
        // }

        // // GET: Item
        // public async Task<IActionResult> Index()
        // {
        //     return View(await _context.Item.ToListAsync());
        // }

        // // GET: Item/Details/5
        // public async Task<IActionResult> Details(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var itemModel = await _context.Item
        //         .SingleOrDefaultAsync(m => m.itemID == id);
        //     if (itemModel == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(itemModel);
        // }

        // // GET: Item/Create
        // public IActionResult Create()
        // {
        //     return View();
        // }

        // // POST: Item/Create
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("itemID,name,longDesc,shortDesc,serialNum,modelNum,reservePrice,category,highestBid,startTime,endTime")] ItemModel itemModel)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(itemModel);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(itemModel);
        // }

        // // GET: Item/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var itemModel = await _context.Item.SingleOrDefaultAsync(m => m.itemID == id);
        //     if (itemModel == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(itemModel);
        // }

        // // POST: Item/Edit/5
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("itemID,name,longDesc,shortDesc,serialNum,modelNum,reservePrice,category,highestBid,startTime,endTime")] ItemModel itemModel)
        // {
        //     if (id != itemModel.itemID)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(itemModel);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!ItemModelExists(itemModel.itemID))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(itemModel);
        // }

        // // GET: Item/Delete/5
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var itemModel = await _context.Item
        //         .SingleOrDefaultAsync(m => m.itemID == id);
        //     if (itemModel == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(itemModel);
        // }

        // // POST: Item/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     var itemModel = await _context.Item.SingleOrDefaultAsync(m => m.itemID == id);
        //     _context.Item.Remove(itemModel);
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        // private bool ItemModelExists(int id)
        // {
        //     return _context.Item.Any(e => e.itemID == id);
        // }
        // public async Task<IActionResult> MakeBid(double bid)
        // {
        //     //using (var db = ApplicationDbContext())

        //     if (ModelState.IsValid)
        //     {
        //         // ItemModel item = _context.Item.Find(itemId);
        //         // Bid activeBid = db.Bids.Find(item.ActiveBidId);
        //         // Usr usr = Usr.GetUsr(db, usrId);

        //     }
            
        //     return ; 
        // }
   // }
//}

