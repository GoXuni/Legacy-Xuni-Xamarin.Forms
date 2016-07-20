using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input101
{
    public class Employee
    {
        public string Name { get; set; }
        public Employee(string name)
        {
            this.Name = name;
        }
        public static List<Employee> GetEmployee()
        {
            List<Employee> data = new List<Employee>();
            data.Add(new Employee("Alabama"));
            data.Add(new Employee("Alaska"));
            data.Add(new Employee("american Samoa"));
            data.Add(new Employee("Arizona"));
            data.Add(new Employee("Arkansas"));
            data.Add(new Employee("California"));
            data.Add(new Employee("Colorado"));
            data.Add(new Employee("Connecticut"));
            data.Add(new Employee("Delaware"));
            data.Add(new Employee("District of Columbia"));
            data.Add(new Employee("Florida"));
            data.Add(new Employee("Georgia"));
            data.Add(new Employee("Guam"));
            data.Add(new Employee("Hawaii"));
            data.Add(new Employee("Idaho"));
            data.Add(new Employee("Illinois"));
            data.Add(new Employee("Indiana"));
            data.Add(new Employee("Iowa"));
            data.Add(new Employee("Kansas"));
            data.Add(new Employee("Kentucky"));
            data.Add(new Employee("Louisiana"));
            data.Add(new Employee("Maine"));
            data.Add(new Employee("Maryland"));
            data.Add(new Employee("Massachusetts"));
            data.Add(new Employee("Michigan"));
            data.Add(new Employee("Minnesota"));
            data.Add(new Employee("Mississippi"));
            data.Add(new Employee("Missouri"));
            data.Add(new Employee("Montana"));
            data.Add(new Employee("Nebraska"));
            return data;
        }
    }

}
