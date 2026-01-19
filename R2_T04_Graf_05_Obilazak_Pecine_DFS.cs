// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka3/pecine
// DFS

using System;
using System.Collections.Generic;

class R2_T04_Graf_05_Obilazak_DFS
{

    struct Hodnik
    {
        public int Cvor_DO;
        public int Cvor_RV;         // Razlika visina izmedju Cvora_OD i Cvora_DO
        public Hodnik(int Cvor_DO, int Cvor_RV)
        {
            this.Cvor_DO = Cvor_DO;
            this.Cvor_RV = Cvor_RV;
        }
    }

    static int DFS_Visina_Min(int Cvor_OD, int Cvor_OD_Visina, List<Hodnik>[] Hodnici)
    {
        int Visina_Min = Cvor_OD_Visina;
        foreach (Hodnik Cvor_OD_Hodnik in Hodnici[Cvor_OD])
        {
            int Cvor_DO_Visina = DFS_Visina_Min(Cvor_OD_Hodnik.Cvor_DO, Cvor_OD_Visina + Cvor_OD_Hodnik.Cvor_RV, Hodnici);
            if (Visina_Min > Cvor_DO_Visina) Visina_Min = Cvor_DO_Visina;
        }
        return Visina_Min;
    }

    static void Main()
    {
        int Visina_Tla = int.Parse(Console.ReadLine());     // Visina tla: Pocetna visina
        int N = int.Parse(Console.ReadLine());              // N: Broj dvorana (cvorova)

        List<Hodnik>[] Hodnici = new List<Hodnik>[N];       // Niz Hodnik-a
        for (int i = 0; i < N; i++) Hodnici[i] = new List<Hodnik>();    // za svaki Hodnici[i] prazna Lista Hodnik-a

        for (int i = 0; i < N - 1; i++)
        {
            string[] sHodnik_OD_DO_RV = Console.ReadLine().Split(); // Cvor_OD Cvor_DO Razlika_visina
            int Cvor_OD = int.Parse(sHodnik_OD_DO_RV[0]);           // Cvor_OD
            int Cvor_DO = int.Parse(sHodnik_OD_DO_RV[1]);           // Cvor_DO
            int Cvor_RV = int.Parse(sHodnik_OD_DO_RV[2]);           // Razlika visina izmedju Cvora_OD i Cvora_DO
            Hodnici[Cvor_OD].Add(new Hodnik(Cvor_DO, Cvor_RV));
        }
        Console.WriteLine(DFS_Visina_Min(0, Visina_Tla, Hodnici));    // Pocetak: Cvor 0, Visina_Tla, Niz hodnika
    }
}
