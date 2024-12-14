using System;

namespace Lab0612
{
    /*
     * 1. 2 поля int, 3 конструктора (0, 1, 2 аргумента), 4 метода. Сложение двух переменных, вычитание из первого 
     * второй, деление, умножение.
     * В мейне создание 3 объектов с использованием трёх разных конструкторов, для каждого объекта используются свои
     * методы. Метод который позволяет выдавать разность сначала х - у и у - х
     * 2. класс, который описывает студента. поля - фио, год рождения, курс. в мейне создаём массив из заданного
     * количества объектов нашего класса, инициализируете значения полей каждого объекта, необходимо предусмотреть
     * выборку: выбрать всех студентов, которые родились в этот год, выдать студентов заданного курса.
     * меню : 1 - заполнение, 2 - модификация, 3 - первая выборка, 4 - вторая выборка, 5 - выход. Модифицировать 
     * данные мы будем по фио студента, в модификации предусмотреть вариант, что данных нет, в таком случае 
     * выдать сообщение
     * "базы данных нет, модификация невозможна"
    */
    class ExampleClass
    {
        public int a, b;
        public ExampleClass()
        {
            a = 0;
            b = 0;
        }
        public ExampleClass(int x)
        {
            a = x;
            b = 0;
        }
        public ExampleClass(int x, int y)
        {
            a = x;
            b = y;
        }

        public void Sum()
        {
            Console.WriteLine($"Сумма: {a + b}");
        }
        public void Diff()
        {
            Console.WriteLine($"Разность 1: {a - b}");
            Console.WriteLine($"Разность 2: {b - a}");
        }
        public void Mult()
        {
            Console.WriteLine($"Произведение: {a * b}");
        }
        public void Div()
        {
            if (b == 0) Console.WriteLine("Деление на ноль невозможно");
            else Console.WriteLine($"Частное: {a / (double)b}");
        }
    }

    class Working
    {
        static void Main()
        {
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());
            ExampleClass first = new ExampleClass();
            ExampleClass second = new ExampleClass(x);
            ExampleClass third = new ExampleClass(x, y);
            Console.WriteLine("Методы первого:");
            first.Sum(); first.Diff(); first.Mult(); first.Div();
            Console.WriteLine();
            Console.WriteLine("Методы второго:");
            second.Sum(); second.Diff(); second.Mult(); second.Div();
            Console.WriteLine();
            Console.WriteLine("Методы третьего:");
            third.Sum(); third.Diff(); third.Mult(); third.Div();
        }
    }
}