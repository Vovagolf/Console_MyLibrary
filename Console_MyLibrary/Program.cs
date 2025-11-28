using System;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RunLibraryApp();
        }

        static void RunLibraryApp()
        {
            DisplayWelcomeMessage();

            bool running = true;
            while (running)
            {
                DisplayLibraryItems();

                string userInput = GetUserInput();
                int selectedNumber = ParseUserInput(userInput);

                if (selectedNumber == -1)
                {
                    // некоректний ввід
                    ContinuePrompt();
                    continue;
                }

                if (selectedNumber == 0)
                {
                    // вихiд
                    running = false;
                    break;
                }

                if (selectedNumber >= 1 && selectedNumber <= 5)
                {
                    DisplaySelectedItem(selectedNumber);

                    Console.WriteLine();
                    Console.Write("Натиснiть Enter, щоб повернутися до списку, або введiть 0 для виходу: ");
                    string afterView = Console.ReadLine()?.Trim() ?? string.Empty;
                    if (afterView == "0")
                    {
                        running = false;
                        break;
                    }

                    // поворот до списку
                }
                else
                {
                    Console.WriteLine("Помилка: Твору з таким номером не iснує!");
                    Console.WriteLine("Будь ласка, виберiть номер вiд 1 до 5 або 0 для виходу.");
                    ContinuePrompt();
                }
            }

            SayGoodbye();
        }

        static void DisplayWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("=======================================");
            Console.WriteLine("     ВIТАЮ В МОЇЙ miniUgi БIБЛIОТЕЦI!");
            Console.WriteLine("=======================================");
            Console.WriteLine();
        }

        static void DisplayLibraryItems()
        {
            Console.WriteLine("# Список доступних творiв:");
            Console.WriteLine("1. «Захар Беркут» - Iван Франко");
            Console.WriteLine("2. «Слово о полку Iгоревiм»");
            Console.WriteLine("3. «Лiсова пiсня» - Леся Українка");
            Console.WriteLine("4. «Енеїда» - Iван Котляревський");
            Console.WriteLine("5. «Сон» - Тарас Шевченко");
            Console.WriteLine("0. Вийти");
            Console.WriteLine();
        }

        static string GetUserInput()
        {
            Console.Write("Введiть номер твору, який вас цiкавить (1-5) або 0 для виходу: ");
            return Console.ReadLine();
        }

        static int ParseUserInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Помилка: Пустий ввід!");
                return -1;
            }

            bool success = int.TryParse(input.Trim(), out int number);

            if (!success)
            {
                Console.WriteLine("Помилка: Введено некоректне число!");
                return -1;
            }

            return number;
        }

        static void DisplaySelectedItem(int itemNumber)
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------");

            switch (itemNumber)
            {
                case 1:
                    DisplayZaharBerkut();
                    break;
                case 2:
                    DisplaySlovoOPolku();
                    break;
                case 3:
                    DisplayLisovaPisnya();
                    break;
                case 4:
                    DisplayEneida();
                    break;
                case 5:
                    DisplaySon();
                    break;
                default:
                    Console.WriteLine("Помилка: Твору з таким номером не iснує!");
                    Console.WriteLine("Будь ласка, виберiть номер вiд 1 до 5.");
                    break;
            }
        }

        static void DisplayZaharBerkut()
        {
            Console.WriteLine("«Захар Беркут» - Iван Франко");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Iсторична повiсть про боротьбу українських");
            Console.WriteLine("опришкiв проти монголо-татарських загарбникiв.");
            Console.WriteLine("Головний герой - Захар Беркут, мудрий старiйшина,");
            Console.WriteLine("який органiзовує спротив ворогу.");
        }

        static void DisplaySlovoOPolku()
        {
            Console.WriteLine("«Слово о полку Iгоревiм»");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Давньоруський героїчний епос XII столiття.");
            Console.WriteLine("Оповiдає про похiд князя Iгоря Святославича");
            Console.WriteLine("проти половцiв та важкi наслiдки поразки.");
        }

        static void DisplayLisovaPisnya()
        {
            Console.WriteLine("«Лiсова пiсня» - Леся Українка");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Драма-феєрiя, що поєднує реальний свiт");
            Console.WriteLine("з казковим. Розповiдає про кохання");
            Console.WriteLine("дiвчини Мавки до Лукаша та конфлiкт");
            Console.WriteLine("мiж природою та цивiлiзацiєю.");
        }

        static void DisplayEneida()
        {
            Console.WriteLine("«Енеїда» - Iван Котляревський");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Бурлескна поема, перший твiр нової");
            Console.WriteLine("української лiтератури. Переробка");
            Console.WriteLine("античного сюжету про Енея в українському");
            Console.WriteLine("нацiональному дусi з гумором.");
        }

        static void DisplaySon()
        {
            Console.WriteLine("«Сон» - Тарас Шевченко");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Усiм вiдомий вiрш з збiрки «Кобзар\":");
            Console.WriteLine();
            Console.WriteLine("У всякого своя доля");
            Console.WriteLine("I свiй шлях широкий:");
            Console.WriteLine("Той мурує, той руйнує,");
            Console.WriteLine("Той неситим оком");
            Console.WriteLine("За красою в небi сяє,");
            Console.WriteLine("Над морем блука...");
        }

        static void SayGoodbye()
        {
            Console.WriteLine();
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("Дякую за вiзит до моєї бiблiотеки!");
            Console.WriteLine("Гарного дня! ");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine();
        }

        static void ContinuePrompt()
        {
            Console.WriteLine();
            Console.Write("Натиснiть Enter, щоб продовжити...");
            Console.ReadLine();
        }
    }
}
