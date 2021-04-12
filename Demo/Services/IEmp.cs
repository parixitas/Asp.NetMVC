using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Services
{
    public interface IEmp
    {
        List<Emp> ListOfEmployee();

        void AddEmployee(Emp e);

        Emp GetEmpById(int? id);

        void DeleteEmployee(int id);

        void EditEmployee(Emp e);
    }
}
