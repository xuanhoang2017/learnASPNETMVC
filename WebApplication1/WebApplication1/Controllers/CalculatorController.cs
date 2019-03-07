using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class CalculatorController : Controller
    {
        //
        // GET: /Calculator/
        public ActionResult Index()
        {
            return View();
        }
        public string ShowAuthor()
        {
            return "Vu Xuan Hoang";
        }
        public double Factorial(int id)
        {
            int n = id;
            double f = 1;
            for (int i = 2; i <= n;i++ )
            {
                f = f * i;
            }
                return f;
        }
        public int Sum(int a, int b){
            int sum = 0;
            sum = a + b;
            return sum;
        }
        

	}
}