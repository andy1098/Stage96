internal class Program
{
    class MyException : Exception
    {
        public MyException(string message) : base(message) { }
        public MyException() : base("Введено некорректное значение") { }
        
    }
    internal static void ExceptionsWork()
    {
        Exception[] exceptions = new Exception[]
        {
            new FileNotFoundException("Файл не найден;"),
            new IndexOutOfRangeException("Индекс вне диапазона;"),
            new DivideByZeroException("Деление на ноль"),
            new KeyNotFoundException("Ключ не найден"),
            new MyException("Введено некорректное значение! Мое исключение работает...")
        };
        foreach (var exception in exceptions)
        {
            try
            {
                throw exception;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Сработало исключение: {ex.GetType().Name} - {ex.Message}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Сработало исключение: {ex.GetType().Name} - {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Сработало исключение: {ex.GetType().Name} - {ex.Message}");
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"Сработало исключение: {ex.GetType().Name} - {ex.Message}");
            }
            catch (MyException ex)
            {
                Console.WriteLine($"Сработало исключение: {ex.GetType().Name} - {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Вроде как все обработано...");
            }
        }
    }
    
    class SortSurnames
    {
        public delegate void NumberEnterDel(string[] surs, int num);
        public event NumberEnterDel NumberEnterEvent;
        public void Sorted(string[] sur)
        {
            Console.WriteLine("=========================");
            Console.Write("Необходимо ввести \"1\" для сортировки по возрастанию или \"2\" по убыванию => ");
            int numsort;
            if (!int.TryParse(Console.ReadLine(), out numsort))
            {
                throw new MyException();
            }
            if (numsort != 1 && numsort != 2)
            {
                throw new MyException();
            }
            NumEntered(sur, numsort);
        }

        protected virtual void NumEntered(string[] surs, int num)
        {
            NumberEnterEvent?.Invoke(surs, num);
        }
    }
    static void SortSurs(string[] surs, int num)
    {
        switch (num)
        {
            case 1:
                {
                    Array.Sort(surs);
                    break;
                }
            case 2:
                {
                    Array.Sort(surs);
                    Array.Reverse(surs);
                    break;
                }
        }
        foreach (string s in surs) {Console.WriteLine(s); }
    }
    private static void Main(string[] args)
    {
        ExceptionsWork();
        Console.ReadKey();

        string[] surnames = { "Иванов", "Петров", "Сидоров", "Ларионова", "Ионова" };
        SortSurnames sortSurnames  = new SortSurnames();
        sortSurnames.NumberEnterEvent += SortSurs;
        try
        {
            sortSurnames.Sorted(surnames);
        }
        catch (MyException ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
        finally
        { Console.ReadKey(); }

    }
}