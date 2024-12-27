/*
 * класс человек (фио, год рождения)
 * класс студент(массив оценок)
 * класс преподаватель (массив наименований предметовв которые они ведут)
 * 1. заполнение
 * 2. вывод данных
 * 3. выборка студентов гр
 * 4. выборка преподавателей по предметам
 * 5. выход
 * нельзя сделать выборку, если данные не занесены
 * данные подаются корректно
*/
using System;
using System.Text;

namespace Lab0612
{
    class Human
    {
        public string Name { get; set; }
        public int Year { get; set; }

        public Human(string name, int year)
        {
            Name = name;
            Year = year;
        }
    }

    class Student : Human
    {
        public int[] Marks { get; set; }

        public Student(string name, int year, int[] marks) : base(name, year)
        {
            Marks = marks;
        }

        public void Print()
        {
            Console.WriteLine($"ФИО: {Name}; Год рождения: {Year}; Оценки: {String.Join(' ', Marks)}");
        }
    }

    class Teacher : Human
    {
        public string[] Subjects { get; set; }

        public Teacher(string name, int year, string[] subjects) : base(name, year)
        {
            Subjects = subjects;
        }

        public void Print()
        {
            string[] curSubjects = new string[Subjects.Length];
            for (int i = 0; i < Subjects.Length; i++) curSubjects[i] = Subjects[i][0].ToString().ToUpper() + Subjects[i].Substring(1);
            Console.WriteLine($"ФИО: {Name}; Год рождения: {Year}; Предметы: {String.Join(", ", curSubjects)}");
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
            Teacher[] teachers = new Teacher[1];
            bool empty = true;
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Выберите опцию от 1 до 5:");
                Console.WriteLine("\t1. Заполнение");
                Console.WriteLine("\t2. Вывод");
                Console.WriteLine("\t3. Выборка студентов по году");
                Console.WriteLine("\t4. Выборка преподавателей по предмету");
                Console.WriteLine("\t5. Выход");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        if (empty == false)
                        {
                            Console.WriteLine("Список уже заполнен");
                            Continue();
                            break;
                        }
                        Console.WriteLine("Введите количество студентов");
                        int n = Convert.ToInt32(Console.ReadLine());
                        students = new Student[n];
                        Console.WriteLine("Введите имя, год, оценки(через пробел) через \"/\" ");
                        for (int i = 0; i < n; i++)
                        {
                            string[] student = Console.ReadLine().Split('/');
                            string[] inputMarks = student[2].Split();
                            int[] marks = new int[inputMarks.Length];
                            for (int j = 0; j < inputMarks.Length; j++) marks[j] = Convert.ToInt32(inputMarks[j]);
                            students[i] = new Student(student[0], Convert.ToInt32(student[1]), marks);
                        }
                        Console.WriteLine("Введите количество преподавателей");
                        n = Convert.ToInt32(Console.ReadLine());
                        teachers = new Teacher[n];
                        Console.WriteLine("Введите имя, год, предметы(через запятую с пробелом) через \"/\" ");
                        for (int i = 0; i < n; i++)
                        {
                            string[] teacher = Console.ReadLine().Split('/');
                            string[] subjects = teacher[2].Split(", ");
                            for (int j = 0; j < subjects.Length; j++) subjects[j] = subjects[j].ToLower();
                            teachers[i] = new Teacher(teacher[0], Convert.ToInt32(teacher[1]), subjects);
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
                        Console.WriteLine("Студенты: ");
                        for (int i = 0; i < students.Length; i++)
                        {
                            students[i].Print();
                        }
                        Console.WriteLine("Преподаватели: ");
                        for (int i = 0; i < teachers.Length; i++)
                        {
                            teachers[i].Print();
                        }
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
                        Console.WriteLine("Введите предмет:");
                        string filterSubject = Console.ReadLine();
                        for (int i = 0; i < teachers.Length; i++)
                        {
                            if (teachers[i].Subjects.Contains(filterSubject.ToLower())) teachers[i].Print();
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
