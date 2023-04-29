using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace human
{
   public class Person
    {
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if(this is Student &&value >=20&&value <= 6) { throw new ArgumentException("Unvalid student age"); }
                else if (this is Employee&& value<18) { throw new ArgumentException("Unvalid employee age"); }
                if (value <= 0)
                    throw new ArgumentException("Enter age");
                _age = value;
            }
        }

        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
    }

    public class Employee:Person
    {
        private double _salaryofhour;
        public double SalaryOfHour {
            get { return _salaryofhour; } set
            {
                if (value <= 0)
                    throw new ArgumentException("Enter salary per hour");
                _salaryofhour = value;
            }
        }
        private int _workinghour;
        public int WorkingHour { get { return _workinghour; } 
            set
            {if (value <= 0&&value>8)

                    throw new ArgumentException("Enter valid working hour");
                    _workinghour=value;
                
            }
        }
         
        public double CalculateSalary()
        {
            double salary = WorkingHour * SalaryOfHour * 25;//həftədə 25 gün işlədiyini düşünək
            if(salary < 250)
            {
                throw new ArgumentException("low salary");
            }
           else return salary;
        }
        public Employee(string name,string surname, double salaryhour,int workingtime,int age )
        {
            Age= age;
            Name= name;
            Surname= surname;
            SalaryOfHour= salaryhour;
            WorkingHour = workingtime;
        }
    }

    public class Student : Person
    {
        private int iq;
        private int lr;
        public int IqRank { get { return iq; } set { if (iq < 0 && iq > 100) throw new Exception("invalid value"); else { iq = value; } }
            
            } 
        public int LanguageRank { get { return lr; } set {
                if (lr > 100 && lr < 0)
                {
                    throw new Exception("invalid value");

                }
                lr = value;
            } }

        public bool ExamResult()
        {
           
            if (IqRank +LanguageRank > 120) { return true; }
            else  { return false; }
        }
        public Student(string name,string surname,int age, int iq,int lr)
        {
            Age=age;
            Name= name;
            Surname = surname;
            IqRank = iq;
            LanguageRank = lr;
        }

    }
}
