namespace Guess_the_password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Воин, приветствую тебя в испытании! Твоя задача — угадать зашифрованный код.");
            Console.WriteLine("Выбери свой путь: ");
            Console.WriteLine("1. Легкий (4-значный код)");
            Console.WriteLine("2. Средний (6-значный код)");
            Console.WriteLine("3. Сложный (8-значный код)");


            int level = int.Parse(Console.ReadLine());
            int passwordLength = 4;

            switch (level)
            {
                case 1:
                    passwordLength = 4;
                    break;
                case 2:
                    passwordLength = 6;
                    break;
                case 3:
                    passwordLength = 8;
                    break;
                default:
                    Console.WriteLine("Некорректный уровень сложности. Будет выбран легкий уровень.");
                    break;
            }

            string password = GeneratePassword(passwordLength);
            int attempts = 0;
            bool guessed = false;

            Console.WriteLine($"Попробуйте угадать {passwordLength}-значный пароль.");

            while (!guessed)
            {
                Console.Write("Введите ваш вариант пароля: ");
                string userGuess = Console.ReadLine();
                attempts++;

                if (userGuess.Length != passwordLength)
                {
                    Console.WriteLine($"Пароль должен состоять из {passwordLength} цифр.");
                    continue;
                }

                if (!IsAllDigits(userGuess))
                {
                    Console.WriteLine("Пароль должен содержать только цифры.");
                    continue;
                }

                string result = CheckGuess(password, userGuess);

                if (result == password)
                {
                    guessed = true;
                    Console.WriteLine($"Поздравляем! Вы угадали пароль {password} за {attempts} попыток.");
                }
                else
                {
                    Console.WriteLine($"Результат: {result}");
                }
            }
        }

        static string GeneratePassword(int length)
        {
            Random rnd = new Random();
            string password = "";
            for (int i = 0; i < length; i++)
            {
                password += rnd.Next(0, 10).ToString();
            }
            return password;
        }

        static string CheckGuess(string password, string userGuess)
        {
            string result = "";
            for (int i = 0; i < password.Length; i++)
            {
                if (userGuess[i] == password[i])
                {
                    result += userGuess[i];
                }
                else
                {
                    result += 'X';
                }
            }
            return result;
        }

        static bool IsAllDigits(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

