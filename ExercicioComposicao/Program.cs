using System;
using ExercicioComposicao.Entities.Enum;
using ExercicioComposicao.Entities;
using System.Globalization;
namespace ExercicioComposicao
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Enter departments name: ");
			string department = Console.ReadLine();

			Console.WriteLine("Enter worker data:");
			Console.Write("Name: ");
			string name = Console.ReadLine();

			Console.Write("Level (Junior/MidLevel/Senior): ");
			WorkerLevel workerLevel = Enum.Parse<WorkerLevel>(Console.ReadLine());
			
			Console.Write("Base salary: ");
			double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
			
			Department depart = new Department(department);
			Worker worker = new Worker(name, workerLevel, baseSalary, depart);

			Console.Write("How many contracts to this worker? ");
			int numberContract = int.Parse(Console.ReadLine());

			for(int i = 1; i <= numberContract; i++) 
			{
				Console.WriteLine($"Enter #{i} contract data:");
				Console.Write("Date (DD/MM/YYYY): ");
				DateTime date = DateTime.Parse(Console.ReadLine());

				Console.Write("Value per hour: ");
				double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

				Console.Write("Duration (hours): ");
				int durationHour = int.Parse(Console.ReadLine());

				HourContract hourContract = new HourContract(date, valuePerHour, durationHour);

				worker.AddContract(hourContract);
				Console.WriteLine();
			}

			Console.Write("Enter month and year to calculate income (MM/YYYY): ");
			string monthAndYear = Console.ReadLine();
			
			int month = int.Parse(monthAndYear.Substring(0, 2));
			int year = int.Parse(monthAndYear.Substring(3));
			double income = worker.Income(year, month);
			
			Console.WriteLine("Name: " + worker.Name);
			Console.WriteLine("Department: " + worker.Department.Name);
			Console.WriteLine($"Income for {month}/{year}: {income}");
		}
	}
}
