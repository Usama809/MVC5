using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Db.DbOperations
{
    public class EmployeeRepository
    {
        public int AddEmployee(Employee model)
        {
            using (var context = new TestDBEntities())
            {

                if (model.Address != null)
                {
                    Address objadd = new Address()
                   {
                       Details = model.Address.Details,
                       Country = model.Address.Country,
                       State = model.Address.State
                   };
                    context.Addresses.Add(objadd);
                    context.SaveChanges();
                    model.AddressId = objadd.Id;
                }
                Employee emp = new Employee()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Code = model.Code,
                    AddressId = model.AddressId
                    //AddressId=_add.Id
                };

                context.Employees.Add(emp);
                context.SaveChanges();
                return emp.Id;
            }
        }

     public List<EmployeeModel> GetAllEmployees()
     {
     using (var context = new TestDBEntities())
    {
       var result = context.Employeees
        .Select (x=> new EmployeeModel()
       {
          Id = x.Id,
          AddressId = x.AddressId,
          Code = x.Code,
          Email = x.Email,
          FirstName = x.FirstName,
          LastName = x.LastName,
          Address = new Address()
          {
              Id = x.Address.Id,
              Details = x.Address.Details,
              Country = x.Address.Country,
              State = x.Address.State
          }
      }).ToList();
      return result;
      }
     }
    }
}
