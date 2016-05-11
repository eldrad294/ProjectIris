using ProjectIris.Models;
using ProjectIris.Utils;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectIris.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private Entities db = new Entities();

        public ActionResult Index()
        {
            //Count client row count
            var ClientCount = db.clients.ToList().Count;
            int EmployeeCount = db.AspNetUsers.ToList().Count;
            int AccountCount = db.accounts.ToList().Count;
            int Purchases = db.purchases_log.ToList().Count;
            ViewBag.ClientCount = ClientCount;
            ViewBag.EmployeeCount = EmployeeCount;
            ViewBag.AccountCount = AccountCount;
            ViewBag.Purchases = Purchases;

            //Last Message Log
            var clientlogs = (from po in db.clients_log
                              select po into newPO
                              select new MessageLogViewModel
                              {
                                  id = newPO.id,
                                  datecreated = newPO.datecreated,
                                  message = newPO.message,
                                  info = newPO.clientidnumber,
                                  type = "clientlogs"
                              });

            var employeelogs = (from po in db.employees_log
                                select po into newPO
                                select new MessageLogViewModel
                                {
                                    id = newPO.id,
                                    datecreated = newPO.datecreated,
                                    message = newPO.message,
                                    info = newPO.employeeid,
                                    type = "employeelogs"
                                });

            var accountlogs = (from po in db.accounts_log
                                select po into newPO
                                select new MessageLogViewModel
                                {
                                    id = newPO.id,
                                    datecreated = newPO.datecreated,
                                    message = newPO.message,
                                    info = newPO.accountnumber,
                                    type = "accountlogs"
                                });

            var vendorlogs = (from po in db.purchases_log
                              select po into newPO
                              select new MessageLogViewModel
                              {
                                  id = newPO.Id,
                                  datecreated = newPO.dateofpurchase,
                                  message = newPO.message,
                                  info = newPO.employeeid,
                                  type = "purchaselogs"
                              });

            var finalList = clientlogs.Union(employeelogs).Union(accountlogs).ToList().OrderByDescending(x => x.datecreated).Take(7);

            ViewBag.YearPurchases = Chart.getYearPurchases();
            ViewBag.EnrolledClients = Chart.getYearClients();

            return View(finalList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}