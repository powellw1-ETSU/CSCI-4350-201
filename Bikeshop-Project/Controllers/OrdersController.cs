using Bikeshop_Project.Data;
using Bikeshop_Project.Models;
using Bikeshop_Project.LoggerModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace Bikeshop_Project.Controllers
{
    public class OrdersController : Controller
    {
        private readonly string baseUriMonitoring = "monitoringteamapi.azurewebsites.net/api";
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
        public async Task<IActionResult> Create([Bind("paint, letterstyle, modeltype, kitQuantity")] OrderDetails orderdetails)
        {                              
            if (ModelState.IsValid)
            {
                // Create Bicycle from order information
                Bicycle newBike = new Bicycle();

                newBike.PAINTID = orderdetails.paintID;
                newBike.LETTERSTYLEID = orderdetails.letterStyle;
                newBike.MODELTYPE = orderdetails.modelType;
                newBike.SERIALNUMBER = GenerateRandomSerialNum();
                newBike.ORDERDATE = DateTime.Now;
                newBike.STARTDATE = DateTime.Today.AddDays(1);
                newBike.SHIPDATE = DateTime.Today.AddDays(2);

                // Create metric for order information to send to monitoring team
                decimal totalCost = 99;                              // Could not get data properly. sorry
                int bicycleID = Convert.ToInt32(newBike.SERIALNUMBER);
                DateTime purchaseDate = DateTime.Now;
                int customerID = 1; // would need to replace in the future with a way to grab Customer info

                // Monitoring team does not automatically create and increment orderID, so this code determines next ID
                int orderID = await GetNextOrderID();

                // send information to monitoring team
                Orders orderMetrics = new Orders(orderID, totalCost, purchaseDate, bicycleID, customerID);
                Logger.logOrders(orderMetrics);

                // _context.Add(newBike);
                // await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index), "home");
            }
            return View();
        }

        /// <summary>
        /// generates random serial number of 9 length
        /// </summary>
        /// <returns></returns>
        public decimal GenerateRandomSerialNum()
        {
            Random r = new Random();
            string temp = string.Empty;
            for (int i = 0; i < 9; i++)
            {
                temp = String.Concat(temp, r.Next(10).ToString());
            }

            decimal d = Convert.ToDecimal(temp);
            return d;
        }

        public async Task<int> GetNextOrderID()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response;                       // will hold response from server
            List<Orders> orderList;                         // will hold list of orders returned
            string uri = $"http://{baseUriMonitoring}/orders";    // uri to send request to

            response = await client.GetAsync(uri);         // send the request

            // convert json response to string and deserialize it
            Task<string> json = response.Content.ReadAsStringAsync();
            string jsonString = json.Result.ToString();
            orderList = JsonConvert.DeserializeObject<List<Orders>>(jsonString);

            // Find last item in list, (most recent Order added, with most recent OrderID)
            Orders lastOrder = orderList[orderList.Count - 1];
            int mostRecentID = lastOrder.orderID;
            int newID = mostRecentID + 1;

            return newID;
        }
    }
}
