using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var values = _employeeService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            EmployeeValidation validationRules = new EmployeeValidation();
            ValidationResult validationResult = validationRules.Validate(employee);

            if (validationResult.IsValid)
            {
                _employeeService.Add(employee);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            var value = _employeeService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateEmployee(Employee employee)
        {
            EmployeeValidation validationRules = new EmployeeValidation();
            ValidationResult validationResult = validationRules.Validate(employee);

            if (validationResult.IsValid)
            {
                _employeeService.Update(employee);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public IActionResult DeleteEmployee(int id)
        {
            var value = _employeeService.GetById(id);
            _employeeService.Delete(value);
            return RedirectToAction("Index");
        }
    }
}
