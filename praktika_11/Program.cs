using System;

namespace praktika_11
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 11, x = 5, y = 5;
            Random a = new Random();
            char[] bukvy = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string original = "", crypted = "", decrypted = "";
            char manual;
            char[,] matrix = new char[size, size];
            char[,] decryptedmatrix = new char[size, size];
            char[] cryptedarr = new char[121];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    manual = bukvy[a.Next(0, 25)];
                    matrix[i, j] = manual;
                    original += manual;
                }
            }
            crypted += matrix[x, y];
            Console.WriteLine("Оригинальная строка:\n" + original);
            for (int i = 0, xy = 2; i < 5; i++, xy += 2)
            {
                crypted += matrix[x, --y];
                for (int j = 1; j < xy; j++)
                    crypted += matrix[++x, y];
                for (int j = 1; j <= xy; j++)
                    crypted += matrix[x, ++y];
                for (int j = 1; j <= xy; j++)
                    crypted += matrix[--x, y];
                for (int j = 1; j <= xy; j++)
                    crypted += matrix[x, --y];
            }
            cryptedarr = crypted.ToCharArray();
            Console.WriteLine("Зашифрованная строка:\n" + crypted);
            x = 5;
            y = 5;
            decryptedmatrix[x, y] = cryptedarr[0];
            for (int i = 0, z = 1, xy = 2; i < 5; i++, xy += 2)
            {
                decryptedmatrix[x, --y] = cryptedarr[z];
                z++;
                for (int j = 1; j < xy; j++, z++)
                    decryptedmatrix[++x, y] = cryptedarr[z];
                for (int j = 1; j <= xy; j++, z++)
                    decryptedmatrix[x, ++y] = cryptedarr[z];
                for (int j = 1; j <= xy; j++, z++)
                    decryptedmatrix[--x, y] = cryptedarr[z];
                for (int j = 1; j <= xy; j++, z++)
                    decryptedmatrix[x, --y] = cryptedarr[z];
            }
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    decrypted += decryptedmatrix[i, j];
            Console.WriteLine("Расшифрованная строка:\n" + decrypted);
            Console.ReadKey();
        }
    }
}
