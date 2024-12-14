/*
    2.класс, который описывает студента. поля - фио, год рождения, курс. в мейне создаём массив из заданного
     * количества объектов нашего класса, инициализируете значения полей каждого объекта, необходимо предусмотреть
     * выборку: выбрать всех студентов, которые родились в этот год, выдать студентов заданного курса.
     * меню : 1 - заполнение, 2 - модификация, 3 - первая выборка, 4 - вторая выборка, 5 - выход. Модифицировать 
     * данные мы будем по фио студента, в модификации предусмотреть вариант, что данных нет, в таком случае 
     * выдать сообщение
     * "базы данных нет, модификация невозможна"
*/
using System;
using System.Text;

namespace Lab0612
{
    class Student
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int Course { get; set; }

        public Student(string name, int year, int course)
        {
            Name = name;
            Year = year;
            Course = course;
        }

        public void Print()
        {
            Console.WriteLine($"Имя: {Name}; Год рождения: {Year}; Курс: {Course}");
        }

        public void Modify(int mod)
        {
            switch (mod)
            {
                case 1:
                    Console.WriteLine("Введите новое ФИО");
                    Name = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Введите новый год рождения");
                    Year = Convert.ToInt32(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("Введите новый курс");
                    Course = Convert.ToInt32(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Неверная опция, возврат в меню");
                    break;
            }
        }
    }

    class Working
    {
        static void Continue()
        {
            Console.WriteLine("\nНажмите любую кнопку для продолжения");
            Console.ReadKey();
            Console.Clear();
        }
        static void Main()
        {
            Console.OutputEncoding = Console.InputEncoding = Encoding.Unicode;

            Student[] students = new Student[1];
            bool empty = true;
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Выберите опцию от 1 до 5:");
                Console.WriteLine("\t1. Заполнение");
                Console.WriteLine("\t2. Модификация");
                Console.WriteLine("\t3. Выборка по году");
                Console.WriteLine("\t4. Выборка по курсу");
                Console.WriteLine("\t5. Выход");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        if (!empty)
                        {
                            Console.WriteLine("Список уже заполнен");
                            Continue();
                            break;
                        }
                        Console.WriteLine("Введите количество студентов");
                        int n = Convert.ToInt32(Console.ReadLine());
                        students = new Student[n];
                        Console.WriteLine("Введите имя, год и курс через \"/\" ");
                        for (int i = 0; i < n; i++)
                        {
                            string[] student = Console.ReadLine().Split('/');
                            students[i] = new Student(student[0], Convert.ToInt32(student[1]), Convert.ToInt32(student[2]));
                        }
                        empty = false;
                        Continue();
                        break;
                    case 2:
                        if (empty)
                        {
                            Console.WriteLine("Список пуст");
                            Continue();
                            break;
                        }
                        Console.WriteLine("Введите ФИО желаемого студента");
                        string curName = Console.ReadLine();
                        int id;
                        for (id = 0; id < students.Length; id++)
                        {
                            if (students[id].Name == curName) break;
                        }
                        students[id].Print();
                        Console.WriteLine("Выберите параметр, который хотите изменить");
                        Console.WriteLine("1. Имя");
                        Console.WriteLine("2. Год рождения");
                        Console.WriteLine("3. Курс");
                        students[id].Modify(Convert.ToInt32(Console.ReadLine()));
                        Continue();
                        break;
                    case 3:
                        if (empty)
                        {
                            Console.WriteLine("Список пуст");
                            Continue();
                            break;
                        }
                        Console.WriteLine("Введите год:");
                        int filterYear = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < students.Length; i++)
                        {
                            if (students[i].Year == filterYear) students[i].Print();
                        }
                        Continue();
                        break;
                    case 4:
                        if (empty)
                        {
                            Console.WriteLine("Список пуст");
                            Continue();
                            break;
                        }
                        Console.WriteLine("Введите курс:");
                        int filterCourse = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < students.Length; i++)
                        {
                            if (students[i].Course == filterCourse) students[i].Print();
                        }
                        Continue();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Выберите другую опцию.");
                        Continue();
                        break;
                }
            }
        }
    }
}
