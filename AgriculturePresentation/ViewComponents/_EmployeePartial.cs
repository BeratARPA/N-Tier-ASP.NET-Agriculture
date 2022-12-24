using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _EmployeePartial : ViewComponent
    {
        private readonly IEmployeeService _employeeService;

        public _EmployeePartial(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _employeeService.GetAll();
            return View(values);
        }
    }
}
