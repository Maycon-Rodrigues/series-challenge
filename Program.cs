using System;
using SeriesChallenge.Class;
using SeriesChallenge.Enum;

namespace SeriesChallenge
{
    class Program
    {
    static SerieRepository repository = new SerieRepository();
    static void Main(string[] args)
        {
            string userOption = UserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
				{
					case "1":
						AllSeries();
						break;
					case "2":
						NewSeries();
						break;
					case "3":
						UpdateSeries();
						break;
					case "4":
						DeleteSeries();
						break;
					case "5":
						GetSeries();
						break;
					default:
						throw new ArgumentOutOfRangeException();
                
				}
                
                userOption = UserOption();

            }
        }

        private static void AllSeries()
        {
            Console.WriteLine("All Series!");
            Console.WriteLine();

            var series = repository.GetAll();

            if (series.Count == 0)
                Console.WriteLine("No have series yet :(");
            
            foreach (var serie in series)
            {
                var active = serie.isActive ? "" : "Inactive";
                Console.WriteLine($"#{serie.id} - {serie.title} {active}");
            }

        }
        private static void NewSeries()
        {
            Console.WriteLine("Add new Series");
            Console.WriteLine();
           
            foreach (int i in Category.GetValues(typeof(Category)))
			{
				Console.WriteLine("{0} - {1}", i, Category.GetName(typeof(Category), i));
			}

            Console.WriteLine();
            Console.WriteLine("Choose one category:");
            int category = int.Parse(Console.ReadLine());

            Console.WriteLine("Title:");
            string title = Console.ReadLine();

            Console.WriteLine("Description:");
            string description = Console.ReadLine();

            Console.WriteLine("Year:");
            int year = int.Parse(Console.ReadLine());

            Serie serie = new Serie(id: repository.NextId(), (Category)category,title,description,year);

            repository.Create(serie);
        }
        private static void GetSeries()
        {
            Console.WriteLine("Enter the series id:");
            int id = int.Parse(Console.ReadLine());

            var serie = repository.GetById(id);
                
            Console.WriteLine(serie);
        }
        private static void UpdateSeries()
        {
            Console.WriteLine("Update Series");
            Console.WriteLine();

            Console.WriteLine("Enter the series id:");
            int id = int.Parse(Console.ReadLine());

            var serie = repository.GetById(id);
           
            Console.WriteLine();
            foreach (int i in Category.GetValues(typeof(Category)))
			{
				Console.WriteLine("{0} - {1}", i, Category.GetName(typeof(Category), i));
			}

            Console.WriteLine();
            Console.WriteLine("Choose one category:");
            int category = int.Parse(Console.ReadLine());

            Console.WriteLine("Title:");
            string title = Console.ReadLine();

            Console.WriteLine("Description:");
            string description = Console.ReadLine();

            Console.WriteLine("Year:");
            int year = int.Parse(Console.ReadLine());

            serie = new Serie(id, (Category)category,title,description,year);

            repository.Update(id, serie);
        }
        private static void DeleteSeries()
        {
            Console.WriteLine("Enter the series id:");
            int id = int.Parse(Console.ReadLine());

            var serie = repository.GetById(id);

            repository.Delete(serie.id);
        }
        private static string UserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Series Challenge!!!");
            Console.WriteLine("Enter your option:");
            Console.WriteLine();

            Console.WriteLine("1- List all series");
            Console.WriteLine("2- Add new series");
            Console.WriteLine("3- Update serie");
            Console.WriteLine("4- Delete serie");
            Console.WriteLine("5- Get serie");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
