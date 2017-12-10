using System.Web.Mvc;
using Calculator_CSharp.Models;
using System;

namespace Calculator_CSharp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Calculator calculator)
        {
            return View(calculator);
        }

        [HttpPost]
        public ActionResult Calculate(Calculator calculator)
        {
            calculator.Result = CalculateResult(calculator);

            return RedirectToAction("Index", calculator);
        }

        public decimal CalculateResult(Calculator calculator)
        {
            decimal result = 0m;

            switch(calculator.Operator)
            {
                case "+":
                    result = calculator.LeftOperand + calculator.RightOperand;
                    break;

                case "-":
                    result = calculator.LeftOperand - calculator.RightOperand;
                    break;

                case "*":
                    result = calculator.LeftOperand * calculator.RightOperand;
                    break;

                case "/":
                    result = calculator.LeftOperand / calculator.RightOperand;
                    break;

                case "^":
                    result = (decimal)Math.Pow((double)calculator.LeftOperand, (double)calculator.RightOperand);
                    break;

                case "AND":
                    result = (long)calculator.LeftOperand & (long)calculator.RightOperand;
                    break;

                case "OR":
                    result = (long)calculator.LeftOperand | (long)calculator.RightOperand;
                    break;

                case "XOR":
                    result = (long)calculator.LeftOperand ^ (long)calculator.RightOperand;
                    break;
            }

            return result;
        }
    }
}