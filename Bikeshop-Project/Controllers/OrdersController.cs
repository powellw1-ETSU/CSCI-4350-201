using Bikeshop_Project.Data;
using Bikeshop_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace Bikeshop_Project.Controllers
{
    public class OrdersController : Controller
    {

        private readonly Bikeshop_ProjectContext _context;

        public OrdersController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            //Currently Errors out
            return View();
        }

        /*        // GET: Orders/Details/5
                public async Task<IActionResult> Details(decimal? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var order = await _context.Order
                        .FirstOrDefaultAsync(m => m.OrderID == id);
                    if (order == null)
                    {
                        return NotFound();
                    }

                    return View(order);
                }*/

        // GET: Orders/Create
        public IActionResult Create()
        {
            //The form where we gather info

            CustomOrderViewModel model = new CustomOrderViewModel();

            model.Paints = (from paint in _context.Paint select paint).ToList();
            model.LetterStyles = (from letterstyle in _context.LetterStyle select letterstyle).ToList();
            model.ModelTypes = (from modeltype in _context.ModelType select modeltype).ToList();





            return View(model);
        }


        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("paint, letterstyle, modeltype, spare_kits_quantity,")] OrderDetails orderdetails)
        {

            //THIS IS WHERE WE COLLECT ADDITIONAL METRICS
            //THIS IS WHERE THE CONNECTION TO THE OTHER SERVER WILL LIVE

            //CREATE A BIKE OBJECT
            //SAVE TO THING

            //BUILD ORDER OBJECT
            //SEND TO OTHER

            System.Console.WriteLine(orderdetails.ToString());
                                 
            if (ModelState.IsValid)
            {
                
                Bicycle newBike = new Bicycle();

                newBike.PAINTID = orderdetails.paintID;
                newBike.LETTERSTYLEID = orderdetails.letterStyle;
                newBike.MODELTYPE = orderdetails.modelType;
                newBike.SERIALNUMBER = 0;//create random serial here



                OrderMetric newMetric = new OrderMetric();
                newMetric.totalCost = System.Decimal.Multiply(orderdetails.kitQuantity , 45);
                newMetric.bicycleID = newBike.SERIALNUMBER;
                newMetric.purchaseDate = System.DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                
                
                newMetric.customerID = 0;//get customer info
                
                
                _context.Add(newBike);

                


                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
