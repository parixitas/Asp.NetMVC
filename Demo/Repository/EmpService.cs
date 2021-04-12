using Demo.Models;
using Demo.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Repository
{
    public class EmpService : IEmp
    {
        private readonly EmpContext _context;
        public EmpService(EmpContext context)
        {
            _context = context;

        }
       public List<Emp> ListOfEmployee()
        {
            return _context.Employees.ToList();
        }

        public void AddEmployee(Emp emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
        }

        public Emp GetEmpById(int? id)
        {
            if(id != 0)
            {
               Emp em = _context.Employees.Find(id);
                return em;
            }
            return null;
        }

        public void DeleteEmployee(int id)
        {
            Emp emp = _context.Employees.Find(id);
            _context.Employees.Remove(emp);
            _context.SaveChanges();
        }

        public void EditEmployee(Emp e)
        {
            _context.Entry(e).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}