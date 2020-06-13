using System;

namespace praktika_11
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 11, x=5, y=5;
            Random a = new Random();
            string original = "", crypted = "", decrypted = "", manual;
            string[,] matrix = new string[size, size];
            string[,] decryptedmatrix = new string[size, size];
            char[] cryptedarr = new char[121];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    manual = (a.Next(0, 9)).ToString();
                    matrix[i, j] = manual;
                    original += manual;
                }
            }
            crypted = matrix[x, y];
            Console.WriteLine("Оригинальная строка:\n" + original);
            for (int i = 0, x1=2, y1=2; i < 5; i++, x1+=2, y1+=2)
            {
                crypted += matrix[x, --y];
                for (int j=1; j < x1 ; j++)
                    crypted += matrix[++x, y];
                for (int j = 1; j <= y1; j++)
                    crypted += matrix[x, ++y];
                for (int j = 1; j <= x1; j++)
                    crypted += matrix[--x, y];
                for (int j = 1; j <= y1; j++)
                    crypted += matrix[x, --y];
            }
            cryptedarr = crypted.ToCharArray();
            Console.WriteLine("Зашифрованная строка:\n" + crypted);
            x = 5;
            y = 5;
            decryptedmatrix[x, y] = cryptedarr[0].ToString();
            for (int i = 0, z = 1, x1 = 2, y1 = 2; i < 5; i++, x1 += 2, y1 += 2)
            {
                decryptedmatrix[x, --y] = cryptedarr[z].ToString();
                z++;
                for (int j = 1; j < x1; j++, z++)
                    decryptedmatrix[++x, y] = cryptedarr[z].ToString();
                for (int j = 1; j <= y1; j++, z++)
                    decryptedmatrix[x, ++y] = cryptedarr[z].ToString();
                for (int j = 1; j <= x1; j++, z++)
                    decryptedmatrix[--x, y] = cryptedarr[z].ToString();
                for (int j = 1; j <= y1; j++, z++)
                    decryptedmatrix[x, --y] = cryptedarr[z].ToString();
            }
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    decrypted += decryptedmatrix[i, j];
            Console.WriteLine("Расшифрованная строка:\n" + decrypted);
            Console.ReadKey();
        }
    }
}
