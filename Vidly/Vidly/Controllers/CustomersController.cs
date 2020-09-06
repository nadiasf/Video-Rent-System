using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        //cretae Object from ApllicationDbContext to connect database
        private ApplicationDbContext _context;
        /// <summary>
        /// Default Constructor create new object from DbContext 
        /// </summary>

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        /// <summary>
        /// Dispose DatabaseContext by override
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Cutomers
        public ActionResult Index()
        {
            return View();
        }

        //GET: Customers/New
        public ActionResult New()
        {
            var memberShipType = _context.MemberShipTypes.ToList();
            var CustomerViewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MemberShipTypes = memberShipType
            };
            return View("CustomerForm", CustomerViewModel);
        }


        //POST :Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var customerVM = new NewCustomerViewModel
                {
                    Customer = customer,
                    MemberShipTypes = _context.MemberShipTypes.ToList()
                };
                return View("CustomerForm", customerVM);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribeToNewsLetter = customer.IsSubscribeToNewsLetter;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        //Get:Customers/Detail
        public ActionResult Detail(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var customer = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //Get :Customers/CustomerForm
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var customerViewModel = new NewCustomerViewModel()
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };
            return View("CustomerForm", customerViewModel);
        }
    }
}