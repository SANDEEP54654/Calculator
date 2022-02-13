using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace Calculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult<IEnumerable<string>> CalculateData([FromBody] Calculation Calculation)
        {
            String Data = Calculation.CData.Trim();
            String Value1 = Calculation.Value1.Trim();
            String Value2 = Calculation.Value2.Trim();
            String Type = Calculation.Type.Trim();

            if (Data != "")
            {
                try
                {
                    DataTable dt = new DataTable();
                    Decimal answer = (Decimal)Convert.ToDecimal(dt.Compute(Data, ""));
                    String RData = answer.ToString("0.00");
                    return new string[] { RData };
                }
                catch (Exception)
                {
                    return new string[] { "0" };
                }
            }
            else if (Value1.Trim() !="" && Value2.Trim() !="" && Type.Trim() !="")
            {
                Calculator objCalculator = new Calculator();
                String RData = "0";
                if (Type.Trim().ToUpper() == "ADD")
                {
                    RData = Convert.ToString(objCalculator.Add(Convert.ToInt32(Value1.Trim()), Convert.ToInt32(Value2.Trim())));
                }
                else if (Type.Trim() == "SUB")
                {
                    RData = Convert.ToString(objCalculator.Sub(Convert.ToInt32(Value1.Trim()), Convert.ToInt32(Value2.Trim())));
                }
                else if (Type.Trim() == "MUL")
                {
                    RData = Convert.ToString(objCalculator.Mul(Convert.ToInt32(Value1.Trim()), Convert.ToInt32(Value2.Trim())));
                }
                else if (Type.Trim() == "DIV")
                {
                    RData = Convert.ToString(objCalculator.Div(Convert.ToInt32(Value1.Trim()), Convert.ToInt32(Value2.Trim())));
                }

                return new string[] { RData };
            }
            else
            {
                return new string[] { "0" };
            }
        }
    }


    public class Calculation
    {
        public string CData { get; set; }

        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Type { get; set; }
    }

    public class Calculator
    {
        public int Add(int num1, int num2)
        {
            int result = num1 + num2;
            System.Diagnostics.Debug.WriteLine("Test Result is" + " " + result);
            return result;
        }

        public int Sub(int num1, int num2)
        {
            int result = num1 - num2;
            System.Diagnostics.Debug.WriteLine("Test Result is" + " " + result);
            return result;

        }

        public int Mul(int num1, int num2)
        {
            int result = num1 * num2;
            System.Diagnostics.Debug.WriteLine("Test Result is" + " " + result);
            return result;


        }
        public int Div(int num1, int num2)
        {
            int result = num1 / num2;
            System.Diagnostics.Debug.WriteLine("Test Result is" + " " + result);
            return result;

        }

    }
}