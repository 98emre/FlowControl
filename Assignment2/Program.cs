
namespace Assigment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {

                PrintAllOptions();

                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "0":
                        running = false;
                        Console.WriteLine("Programmet har avslutat, tack för idag :)");
                        break;

                    case "1":
                        CheckIndvidualPrice();
                        break;

                    case "2":
                        CheckGroupPrice();
                        break;

                    case "3":
                        RepeatText();
                        break;

                    case "4":
                        GetThirdWord();
                        break;

                    default:
                        Console.WriteLine("Felaktig input, dem giltiga input är 0 till 4, snälla gör ett nytt försök");
                        break;
                }
            }
        }

        static void PrintAllOptions()
        {
            Console.WriteLine("\nVälkommen till systemt");
            Console.WriteLine("0. Avsluta programmet");
            Console.WriteLine("1. Ungdom eller pensionär");
            Console.WriteLine("2. Räkna ut priset för sällskap");
            Console.WriteLine("3. Upprepa en text tio gånger");
            Console.WriteLine("4. Det tredje ordet");

            Console.Write("Välj ett alternativ: ");
        }

        static void CheckIndvidualPrice()
        {
            bool running = true;
            while (running)
            {
                Console.Write("\nAnge ålder: ");
                string input = Console.ReadLine()!;

                int age;

                if (int.TryParse(input, out age))
                {
                    running = false;
                    CalculatePrice(age);
                }

                else
                {
                    Console.WriteLine("Felaktig input, ange en ålder och gör ett nytt försök");
                }
            }
        }

        static void CheckGroupPrice()
        {
            bool running = true;

            while (running)
            {
                Console.Write("\nAnge antal personer i sällskapet: ");

                string input = Console.ReadLine()!;

                int number;

                if (int.TryParse(input, out number))
                {
                    running = false;
                    int sumOfPrice = 0;

                    for (int i = 0; i < number; i++)
                    {
                        Console.Write($"\nAnge ålder för person {(i + 1)}: ");
                        input = Console.ReadLine()!;

                        int age;

                        if (int.TryParse(input, out age))
                        {
                            sumOfPrice += CalculatePrice(age);
                        }

                        else
                        {
                            Console.WriteLine("Wrong input, try again\n");
                            i--;
                        }
                    }

                    Console.WriteLine($"Antal personer i sällskapet {number}");
                    Console.WriteLine($"Total kostnad: {sumOfPrice}\n");

                }


                else
                {
                    Console.WriteLine("Felaktig input, skriv om antal personer.\n");
                }
            }
        }

        private static int CalculatePrice(int age)
        {
            if (age < 5 || age > 100)
            {
                Console.WriteLine("Det är gratis för dig");
                return 0;
            }

            else if (age < 20)
            {
                Console.WriteLine("Ungdomspris: 80kr\n");
                return 80;
            }

            else if (age > 64)
            {
                Console.WriteLine("Pensionärspris: 90kr\n");
                return 90;
            }

            else
            {
                Console.WriteLine("Standardpris: 120kr\n");
                return 120;
            }
        }

        static void RepeatText()
        {
            Console.Write("\nAnge en text som ska upprepas: ");
            string input = Console.ReadLine()!;

            Console.WriteLine("\nUpprepade text");
            for (int i = 1; i <= 10; i++)
            {
                Console.Write((i == 10) ? $"{(i)}.{input}\n" : $"{(i + 1)}.{input},");
            }

        }

        static void GetThirdWord()
        {
            bool running = true;

            while (running)
            {
                Console.Write("\nAnge en mening med minst 3 ord: ");
                var input = Console.ReadLine();

                string[] words = input!.Trim().Split(' ');

                if (words.Length < 3)
                {
                    Console.WriteLine("\nAnge en mening som har minst 3 ord, gör ett nytt försök");
                }

                else
                {
                    running = false;
                    Console.WriteLine($"Tredje ordet: {words[2]}");
                }

            }
        }

    }
}
