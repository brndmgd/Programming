using System;

class Spider
{
    static int[] ToCords(string s)
    {
        string[] array = s.Split();
        int[] cords = new int[5];
        for (int i = 0; i < 3; i++) cords[i] = Convert.ToInt32(array[i]);
        return cords;
    }
    static void FindFace(int[] coords, int[] maxes)
    {
        for (int i = 0; i < 3; i++)
        {
            if (coords[i] == 0)
            {
                coords[3] = i;
                coords[4] = 0;
            }
            else if (coords[i] == maxes[i])
            {
                coords[3] = i;
                coords[4] = 1;
            }
        }
    }

    static void Main()
    {
        Console.WriteLine("Введите высоту, ширину и длину комнаты:");
        int[] cube = ToCords(Console.ReadLine());
        Console.WriteLine("Введите координаты паука:");
        int[] spider = ToCords(Console.ReadLine());
        Console.WriteLine("Введите координаты мухи:");
        int[] fly = ToCords(Console.ReadLine());

        FindFace(spider, cube);
        FindFace(fly, cube);
        
        double result = 0;
        if (spider[3] == fly[3])
        {
            if (spider[4] == fly[4])
            {
                double squares = 0;
                for (int i = 0; i < 3; i++) squares += Math.Pow(spider[i] - fly[i], 2);
                squares -= Math.Pow(spider[spider[3]] - fly[fly[3]], 2);
                result = Math.Sqrt(squares);
            }

            else
            {
                string xyz = "012".Remove(spider[3], 1);
                result = Math.Pow(cube.Sum(), 2);
                for (int i = 0; i < 2; i++)
                {
                    int h, a;
                    for (int j = 0; j < 2; j++)
                    {
                        int sh = Math.Abs(cube[i] * j - spider[int.Parse(xyz[i] + "")]);
                        int fh = Math.Abs(cube[i] * j - fly[int.Parse(xyz[i] + "")]);
                        h = cube[spider[3]] + sh + fh;
                        a = spider[int.Parse(xyz[1 - i] + "")] - fly[int.Parse(xyz[1 - i] + "")];
                        result = Math.Min(result, Math.Sqrt(h * h + a * a));
                    }
                }
            }
        }
        else
        {
            string sxyz = "012".Remove(spider[3], 1);
            string fxyz = "012".Remove(fly[3], 1);
            int common = Convert.ToInt32(sxyz.Intersect(fxyz).First().ToString());
            int sdif = int.Parse(sxyz.Replace(common.ToString(), ""));
            int fdif = int.Parse(fxyz.Replace(common.ToString(), ""));
            int sh = Math.Abs(fly[sdif] - spider[sdif]);
            int fh = Math.Abs(spider[fdif] - fly[fdif]);
            int h = sh + fh;
            int a = spider[common] - fly[common];
            result = Math.Sqrt(a * a + h * h);
        }
        Console.WriteLine("Расстояние между пауком и мухой:");
        Console.WriteLine($"{result:N3}");
    }
}
