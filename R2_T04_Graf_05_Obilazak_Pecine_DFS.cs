// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka3/pecine
// DFS

using System;
using System.Collections.Generic;

class R2_T04_Graf_05_Obilazak_DFS
{

    struct Veza                                 // Veza (Hodnik) izmedju dva cvora (dvorane)
    {
        public int Cvor_DO;                     // Do kod cvora (dvorane) vodi veza (hodnik)
        public int Cvor_RV;                     // Razlika visina izmedju Cvora_OD i Cvora_DO u toj vezi (hodniku)
        public Veza(int Cvor_DO, int Cvor_RV)   // Konstruktor strukture Veza: Poziva se kada se u programu pozove naredba: new Veza(Cvor_DO, Cvor_RV)
        {                                       // Konstruktor strukture mora da ima isto ime (Veza) kao i sam struktura (Veza)
            this.Cvor_DO = Cvor_DO;             // this.Cvor_DO ukazuje na polje Veza.Cvor_DO koje dobija vrednost iz 1. argumenta metode konstruktora (Cvor_DO)
            this.Cvor_RV = Cvor_RV;             // this.Cvor_OD ukazuje na polje Veza.Cvor_OD koje dobija vrednost iz 2. argumenta metode konstruktora (Cvor_OD)
        }
    }

    static int DFS_Visina_Min(int Cvor_OD, int Cvor_OD_Visina, List<Veza>[] Veze)   // U prvom pozivu iz Main Cvor_OD=0, Cvor_OD_Visina=Pocetna_visina_tla
    {
        int Nadmorska_Visina_Min = Cvor_OD_Visina;              // Nadmorska visina za Cvor_OD (pocetak veze, odnosno hodnika) je inicijalno najmanja
        foreach (Veza Cvor_OD_Veza in Veze[Cvor_OD])            // Za svaku Vezu (hodnih) od Cvora_OD
        {
            int Cvor_DO_Visina_Pom = Cvor_OD_Visina + Cvor_OD_Veza.Cvor_RV;                                 // Pomocna promenljiva = nadmorska visina za Cvor_DO
            int Cvor_DO_Visina_Min = DFS_Visina_Min(Cvor_OD_Veza.Cvor_DO, Cvor_DO_Visina_Pom, Veze);        // DFS 
            if (Nadmorska_Visina_Min > Cvor_DO_Visina_Min)
                Nadmorska_Visina_Min = Cvor_DO_Visina_Min;
        }
        return Nadmorska_Visina_Min;
    }

    static void Main()
    {
        // Korak 1.0: ULAZ: 2 broja: Pocetna nadmorska visina tla i broj cvorova (dvorana)
        int VT_Nadmorska_visina_tla = int.Parse(Console.ReadLine());    // Visina tla: Pocetna nadmorska visina tla
        int N = int.Parse(Console.ReadLine());                          // N: Broj cvorova (dvorana)
        // int V = int.Parse(Console.ReadLine());                       // V: Broj veza
        int V = N - 1;                                                  // V: Broj veza je N - 1 iz teksta zadatka

        // Korak 1.1: Veze[N]: Niz listi Veza: prazne 
        List<Veza>[] Veze = new List<Veza>[N];                          // Niz Veza (Hodnik-a)
        for (int c = 0; c < N; c++) Veze[c] = new List<Veza>();         // za svaki Veze[c] (Hodnici[c]) prazna Lista Veza (Hodnik-a)

        // Korak 1.2: ULAZ: za svaku vezu (hodnik) izmedju dva cvora (dvorana) ucitavaju se po 3 podatka: Cvor_OD, Cvor_DO i Razlika_visina
        for (int v = 0; v < V; v++)
        {
            string[] sVeza_OD_DO_RV = Console.ReadLine().Split();       // ULAZ: Cvor_OD Cvor_DO Razlika_visina
            int Cvor_OD = int.Parse(sVeza_OD_DO_RV[0]);                 // ulaz u int: Cvor_OD
            int Cvor_DO = int.Parse(sVeza_OD_DO_RV[1]);                 // ulaz u int: Cvor_DO
            int Cvor_RV = int.Parse(sVeza_OD_DO_RV[2]);                 // ulaz u int: Razlika visina izmedju Cvora_OD i Cvora_DO
            Veze[Cvor_OD].Add(new Veza(Cvor_DO, Cvor_RV));              // Dodaje se nova Veza za Cvor_OD do Cvor_DO sa Razlikom visine
            // Veze[Cvor_DO].Add(new Veza(Cvor_OD, -Cvor_RV));          // Dodaje se nova Veza za Cvor_DO do Cvor_OD sa negativnom Razlikom visine, SAMO ako je NEUSMER graf
        }

        // Korak 2: DFS -->> DFS (0, Posetna_nadmorska_visina_tla, Veze)                                // Pocetak: Cvor = 0, Visina_Tla, Niz listi Veze (hodnika)
        int VT_Nadmorska_visina_Najniza_Rezultat = DFS_Visina_Min(0, VT_Nadmorska_visina_tla, Veze);    // Pocetak: Cvor = 0, Visina_Tla, Niz listi Veze (hodnika)

        // Korak 3: Izlaz
        Console.WriteLine(VT_Nadmorska_visina_Najniza_Rezultat);    
    }
}
