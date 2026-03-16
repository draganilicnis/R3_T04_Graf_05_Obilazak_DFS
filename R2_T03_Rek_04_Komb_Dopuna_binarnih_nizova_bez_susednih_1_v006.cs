using System;
using System.Text;
class R2_T03_Rek_04_Komb_Dopuna_binarnih_nizova_bez_susednih_1_v006
{
    static void Main()
    {
        string s = Console.ReadLine();      // ULAZ: Ulazni string (delimicno popunjen niz nula i jedinica: 1...0
        int[] a = new int[s.Length];
        Popuni_Rekurz(s, a, 0);
    }
    static void Popuni_Rekurz(string s, int[] a, int i) // Rekurzivno sledeca
    {
        int n = a.Length;
        if (i == n) 
        {
            Niz_Ispisi(a);
            return;
        }

        // Ako je '.'
        if (s[i] != '.')
        {
            a[i] = s[i] - '0';
            if (!(i > 0 && a[i] == 1 && a[i - 1] == 1))
                Popuni_Rekurz(s, a, i + 1);
            return;
        }

        // Pokusaj sa 0
        a[i] = 0;
        Popuni_Rekurz(s, a, i + 1);

        // Pokusaj sa 1 (samo ako levo nije 1)
        if (!(i > 0 && a[i - 1] == 1))
        {
            a[i] = 1;
            Popuni_Rekurz(s, a, i + 1);
        }
    }
    static void Niz_Ispisi(int[] a)                             // IZLAZ: Ispisivanje vrednosti elemenata niza
    {
        int n = a.Length;                                       // Duzina niza
        StringBuilder s = new StringBuilder();
        for (int i = 0; i < n; i++) s.Append(a[i]);             // Console.Write(a[i]);
        Console.WriteLine(s);                                   // Console.WriteLine();
    }
}
