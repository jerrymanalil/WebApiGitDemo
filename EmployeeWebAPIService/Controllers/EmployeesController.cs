using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeWebAPIService.Controllers
{
    public class EmployeesController : ApiController
    {

        public IEnumerable<Employee> Get(int pageIndex = 1)
        {
            using (AngularDemoEntities entities = new AngularDemoEntities())
            {
                return entities.Employees.Take(pageIndex * 2).ToList();
            }
        }

        public Employee Get(string code)
        {
            int currentPageIndex = 1;
            int.TryParse(code, out currentPageIndex);
            using (AngularDemoEntities entities = new AngularDemoEntities())
            {
                return entities.Employees.FirstOrDefault(emp => emp.Code.Equals(code));
            }
        }
    }
}
