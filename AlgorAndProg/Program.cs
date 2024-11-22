using System;

class Mold
{
    static void Detail(int[][,] data, int x)
    {
        for (int i = 0; i < data.Length; i++)
        {
            string[] input = Console.ReadLine().Split();
            data[i] = new int[x, 5];
            for (int j = 0; j < x; j++)
            {
                for (int k = 0; k < 5; k++)
                {
                    data[i][j, k] = Convert.ToInt32(input[5 * j + k]);
                }
            }
        }
    }

    static int[,] Rotate180(int[,] detail)
    {
        int[,] reversed = new int[3, 5];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                reversed[i, j] = detail[2-i, 4-j];
            }
        }
        return reversed;
    }

    static int[,] Mirror(int[,] detail)
    {
        int[,] mirrored = new int[3, 5];
        for (int i = 0; i < 3; i++)
        {
            for (int j1 = 4, j2 = 0; j1 >= 0; j1--, j2++)
            {
                mirrored[i, j2] = detail[i, j1];
            }
        }
        return mirrored;
    }

    static int[,] Rotate90(int[,] detail, int quantity)
    {
        int[,] result = new int[4, 5];

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                result[(quantity + i) % 4, j] = detail[i, j];
            }
        }
        return result;
    }

    static bool CompareDH(int[,] detail, int[,] half)
    {
        bool flag = true;
        for (int j = 0; j < 5; j++)
        {
            if (detail[0, j] != half[0, j] || detail[3,j] != half[1, j] || detail[2, j] != half[2, j])
            {
                flag = false;
                return flag;
            }
        }
        return flag;
    }

    static bool CompareHH(int[,] half1, int[,] half2)
    {
        bool flag = true;
        int[,] reverseHalf2 = Mirror(half2);
        for (int i = 0; i < 5; i++)
        {
            if (half1[0, i] != reverseHalf2[0, i] || half1[2, i] != reverseHalf2[2, i])
            {
                flag = false;
                break;
            }
        }
        if (flag) return flag;

        flag = true;
        reverseHalf2 = Rotate180(reverseHalf2);
        for (int i = 0; i < 5; i++)
        {
            if (half1[0, i] != reverseHalf2[0, i] || half1[2, i] != reverseHalf2[2, i])
            {
                flag = false;
                return flag;
            }
        }
        return flag;
    }

    static int[][,] CorrectHalfs(int[][,] correct, int[,] detail)
    {
        int[][,] result = new int[2][,];
        if (correct[2] == null)
        {
            result[0] = correct[0];
            result[1] = correct[1];
            return result;
        }
        if (correct[3] == null)
        {
            if (CompareHH(correct[0], correct[1]))
            {
                result[0] = correct[0];
                result[1] = correct[1];
            }
            else if (CompareHH(correct[0], correct[2]))
            {
                result[0] = correct[0];
                result[1] = correct[2];
            }
            else
            {
                result[0] = correct[1];
                result[1] = correct[2];
            }
            return result;
        }
        return correct;
    }
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[][,] details = new int[n][,];
        Detail(details, 4);
        int[][,] halfs = new int[2 * n][,];
        Detail(halfs, 3);
        int[][,] sortHalf = new int[2 * n][,];
        int[][,] guessHalf = new int[2 * n][,];
        int k = 0;
        int gk = 0;
        for (int i = 0; i < n; i++)
        {
            int[][,] correct = new int[4][,];
            int count = 0;
            for (int r = 0; r < 4; r++)
            {
                foreach (int[,] half in halfs)
                {
                    int[,] curDet = Rotate90(details[i], r);
                    if (CompareDH(curDet, half) || CompareDH(curDet, Rotate180(half)))
                    {
                        correct[count] = half;
                        count++;
                        break;
                    }
                }
            }
            int[][,] correctH = CorrectHalfs(correct, details[i]);
            if (correctH.Length == 2)
            {
                sortHalf[k * 2] = correctH[0];
                sortHalf[k * 2 + 1] = correctH[1];
            }
            else
            {
                for (int j = gk; j < gk + 4; j++)
                {
                    guessHalf[j] = correct[j%4];
                }
                gk += 4;
            }
            k++;
        }

        for (int i = 0; i < gk; i++)
        {
            if (Array.IndexOf(sortHalf, null) == -1) break;
            if (Array.IndexOf(sortHalf, guessHalf[i]) == -1) sortHalf[Array.IndexOf(sortHalf, null)] = guessHalf[i];
        }

        for (int i = 0; i < n; i++)
        {
            int ind1 = Array.IndexOf(halfs, sortHalf[i * 2]) + 1;
            int ind2 = Array.IndexOf(halfs, sortHalf[i * 2 + 1]) + 1;
            Console.WriteLine($"{Math.Min(ind1, ind2)} {Math.Max(ind1, ind2)}");
        }
    }
}