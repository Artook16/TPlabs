using Microsoft.AspNetCore.Mvc;
using Лабораторная_работа__1.Models;

namespace Лабораторная_работа__1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            CalculatorModel model = new CalculatorModel();
            ViewBag.ExpectedResult = 52.67f;
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(CalculatorModel model, string operation, string action)
        {
            model.Operation = operation;

            if (action == "Очистить")
            {
                ModelState.Clear();
                CalculatorModel emptyModel = new CalculatorModel();
                ViewBag.ExpectedResult = 52.67f;
                return View(emptyModel);
            }

            if (ModelState.IsValid)
            {
                bool isOperand1Valid = ulong.TryParse(model.Operand1String, out ulong operand1);
                bool isOperand2Valid = float.TryParse(model.Operand2String, out float operand2);

                if (isOperand1Valid && isOperand2Valid)
                {
                    float result = 0;

                    switch (operation)
                    {
                        case "+":
                            result = (float)operand1 + operand2;
                            break;
                        case "-":
                            result = (float)operand1 - operand2;
                            break;
                        case "*":
                            result = (float)operand1 * operand2;
                            break;
                        case "/":
                            if (operand2 != 0)
                                result = (float)operand1 / operand2;
                            else
                                ModelState.AddModelError("", "Деление на ноль невозможно!");
                            break;
                        default:
                            ModelState.AddModelError("", "Выберите операцию");
                            break;
                    }

                    model.Result = result;
                }
                else
                {
                    if (!isOperand1Valid)
                        ModelState.AddModelError("Operand1String", "Операнд 1 должен быть целым положительным числом (ulong)");
                    if (!isOperand2Valid)
                        ModelState.AddModelError("Operand2String", "Операнд 2 должен быть числом с плавающей точкой (float)");
                }
            }

            ViewBag.ExpectedResult = 52.67f;
            return View(model);
        }
        public IActionResult OperationDetails()
        {
            return View();
        }
    }
}