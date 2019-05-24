using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLID_OCP
{
    /// <summary>
    /// Example 1.
    /// In this example, if we want to add new calculation logic, all we have to do is to add another class with its own calculation logic.
    /// 
    /// Example 2.
    /// Here, we are adding another filtering class when we need another filtering logic. We don't want to change existing.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Example 1.
            var devCalculations = new List<BaseSalaryCalculator>
            {
                new SeniorDevSalaryCalculator(new DeveloperReport {Id = 1, Name = "Dev1", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 160 }),
                new JuniorDevSalaryCalculator(new DeveloperReport {Id = 2, Name = "Dev2", Level = "Junior developer", HourlyRate = 20, WorkingHours = 150 }),
                new SeniorDevSalaryCalculator(new DeveloperReport {Id = 3, Name = "Dev3", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 180 })
            };

            var calculator = new SalaryCalculator(devCalculations);
            Console.WriteLine($"Sum of all the developer salaries is {calculator.CalculateTotalSalaries()} dollars");

            // Example 2.
            var monitors = new List<ComputerMonitor>
            {
                new ComputerMonitor { Name = "Samsung S345", Screen = Screen.CurvedScreen, Type = MonitorType.OLED },
                new ComputerMonitor { Name = "Philips P532", Screen = Screen.WideScreen, Type = MonitorType.LCD },
                new ComputerMonitor { Name = "LG L888", Screen = Screen.WideScreen, Type = MonitorType.LED },
                new ComputerMonitor { Name = "Samsung S999", Screen = Screen.WideScreen, Type = MonitorType.OLED },
                new ComputerMonitor { Name = "Dell D2J47", Screen = Screen.CurvedScreen, Type = MonitorType.LCD }
            };

            var filter = new MonitorFilter();

            var lcdMonitors = filter.Filter(monitors, new MonitorTypeSpecification(MonitorType.LCD));
            Console.WriteLine("All LCD monitors");
            foreach (var monitor in lcdMonitors)
            {
                Console.WriteLine($"Name: {monitor.Name}, Type: {monitor.Type}, Screen: {monitor.Screen}");
            }
        }

        public abstract class BaseSalaryCalculator
        {
            protected DeveloperReport DeveloperReport { get; private set; }

            public BaseSalaryCalculator(DeveloperReport developerReport)
            {
                DeveloperReport = developerReport;
            }

            public abstract double CalculateSalary();
        }

        public class SeniorDevSalaryCalculator : BaseSalaryCalculator
        {
            public SeniorDevSalaryCalculator(DeveloperReport report)
                : base(report)
            {
            }

            public override double CalculateSalary() => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours * 1.2;
        }

        public class JuniorDevSalaryCalculator : BaseSalaryCalculator
        {
            public JuniorDevSalaryCalculator(DeveloperReport developerReport)
                : base(developerReport)
            {
            }

            public override double CalculateSalary() => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours;
        }


        public class DeveloperReport
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Level { get; set; }
            public int WorkingHours { get; set; }
            public double HourlyRate { get; set; }
        }

        public class SalaryCalculator
        {
            private readonly IEnumerable<BaseSalaryCalculator> _developerCalculation;

            public SalaryCalculator(IEnumerable<BaseSalaryCalculator> developerCalculation)
            {
                _developerCalculation = developerCalculation;
            }

            public double CalculateTotalSalaries()
            {
                double totalSalaries = 0D;

                foreach (var devCalc in _developerCalculation)
                {
                    totalSalaries += devCalc.CalculateSalary();
                }

                return totalSalaries;
            }
        }

        public enum MonitorType
        {
            OLED,
            LCD,
            LED
        }

        public enum Screen
        {
            WideScreen,
            CurvedScreen
        }

        public class ComputerMonitor
        {
            public string Name { get; set; }
            public MonitorType Type { get; set; }
            public Screen Screen { get; set; }
        }

        public interface ISpecification<T>
        {
            bool isSatisfied(T item);
        }

        public interface IFilter<T>
        {
            List<T> Filter(IEnumerable<T> monitors, ISpecification<T> specification);
        }

        public class MonitorTypeSpecification : ISpecification<ComputerMonitor>
        {
            private readonly MonitorType _type;

            public MonitorTypeSpecification(MonitorType type)
            {
                _type = type;
            }

            public bool isSatisfied(ComputerMonitor item) => item.Type == _type;
        }

        public class MonitorFilter : IFilter<ComputerMonitor>
        {
            public List<ComputerMonitor> Filter(IEnumerable<ComputerMonitor> monitors, ISpecification<ComputerMonitor> specification) =>
                monitors.Where(m => specification.isSatisfied(m)).ToList();
        }
    }
}
