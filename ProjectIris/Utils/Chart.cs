using ProjectIris.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIris.Utils
{
    public class Chart
    {
        private static Entities db = new Entities();

        public static int[] getYearPurchases()
        {
            List<purchases_log> logs = db.purchases_log.ToList();
            int[] year = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach(purchases_log log in logs)
            {
                int months = DateTime.Now.Month - log.dateofpurchase.Month;
                if (months <= 12)
                {
                    year[months]++;
                }
            }
            return year;
        }

        public static int[] getYearClients()
        {
            List<client> clients = db.clients.ToList();
            int[] clientarray = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach (client client in clients)
            {
                int months = DateTime.Now.Month - client.dateofbirth.Month;
                if (months <= 12)
                {
                    clientarray[months]++;
                }
            }
            return clientarray;
        }
    }
}