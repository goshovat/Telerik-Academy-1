using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        byte[] a = new byte[22];
        byte[] b = new byte[22];
        byte[] c = new byte[22];
        a[0] = 0;
        b[0] = 1;
        int pren = 0;

        for (int i = 0; i < 100; i++)
        {
            for (int i2 = 21; i2 >= 0; i2--)
            {
                Console.Write(a[i2]);

            }
            Console.WriteLine();

            for (int i1 = 0; i1 < 22; i1++)
            {
                c[i1] = (byte)((a[i1] + b[i1] + pren) % 10);
                pren = (byte)((a[i1] + b[i1] + pren) / 10);
                a[i1] = b[i1];
                b[i1] = c[i1];
            }


        }

    }
}