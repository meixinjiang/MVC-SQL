using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Linq.Dynamic;

namespace WebApplication1.Controllers
{
    public class SqlController : Controller
    {
        public SqlController()
        {
            Thread.CurrentThread.CurrentCulture =
                new System.Globalization.CultureInfo("en-NZ"); // ru-RU
        }

        // GET: WebGrid?page=1&rowsPerPage=10&sort=OrderID&sortDir=ASC
        public ActionResult WebGrid(int page = 1, int rowsPerPage = 10, string sortCol = "OrderID", string sortDir = "ASC")
        {
            List<MyModel> res;
            int count;
            string sql = "";
            string direction;
            var sortBy = "";

            if (sortDir == "ASC" || sortDir == "asc") direction = " Ascending";
            else direction = " Descending";

            if (sortCol == "CompanyName" || sortCol == "ContactName") { sortBy = "Customer." + sortCol; }
            else if (sortCol == "EmpFirstName") { sortBy = "Employee.FirstName"; }
            else if (sortCol == "EmpLastName") { sortBy = "Employee.LastName"; }
            else sortBy = sortCol;

            using (var nwd = new NorthwindEntities())
            {

                var _res = nwd.Orders
                    .OrderBy(sortBy + " " + sortDir + ", " + "OrderID " + sortDir)
                    .Skip((page - 1) * rowsPerPage)
                    .Take(rowsPerPage)
                    .Select(o => new MyModel
                    {
                        OrderID = o.OrderID,
                        OrderDate = o.OrderDate,
                        Freight = o.Freight,
                        ShipCity = o.ShipCity,
                        ShipCountry = o.ShipCountry,
                        CompanyName = o.Customer.CompanyName,
                        ContactName = o.Customer.ContactName,
                        EmpFirstName = o.Employee.FirstName,
                        EmpLastName = o.Employee.LastName,
                    });

                res = _res.ToList();
                sql = sql + _res;
                count = nwd.Orders.Count();
            }

            ViewBag.sortCol = sortCol;
            ViewBag.rowsPerPage = rowsPerPage;
            ViewBag.count = count;
            ViewBag.sql = sql;
            ViewBag.direction = direction;
            return View(res);
        }
    }


    public class MyModel
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? Freight { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
    }
}