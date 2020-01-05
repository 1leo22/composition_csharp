using System;
using System.Collections.Generic;
using System.Text;
using ExercicioComposicao.Entities.Enum;

namespace ExercicioComposicao.Entities
{
	class Worker
	{
		public string Name { get; set; }
		public WorkerLevel MyProperty { get; set; }
		public double BaseSalary { get; private set; }
		public Department Department { get; set; }
		public List<HourContract> Contracts { get; set; } = new List<HourContract>();

		public Worker(string name, WorkerLevel myProperty, double baseSalary, Department department)
		{
			Name = name;
			MyProperty = myProperty;
			BaseSalary = baseSalary;
			Department = department;
		}

		public void AddContract(HourContract contract) 
		{
			Contracts.Add(contract);
		}

		public void RemoveContract(HourContract contract) 
		{
			Contracts.Remove(contract);
		}

		public double Income(int year, int month) 
		{
			List<HourContract> listHourContracts = Contracts.FindAll(contract => (contract.Date.Year == year) && (contract.Date.Month == month));
			
			double income = BaseSalary;
			
			foreach (HourContract contracts in listHourContracts) 
			{
				income += contracts.TotalValue();
			}

			return income;
		}
	}
}
