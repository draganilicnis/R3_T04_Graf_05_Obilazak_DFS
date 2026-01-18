using System;
using System.Collections.Generic;
class R3_T04_Graf_05_DFS_001_Dostizni_cvorovi_Stek
{
    static bool DFS_Stek(int Cvor_OD, int Cvor_DO, List<int>[] Veze, bool[] Posecen)
    {
        int broj_Cvorova = Veze.Length;
        // bool[] Posecen = new bool[broj_Cvorova];
        var Magacin = new Stack<int>();
        Magacin.Push(Cvor_OD);
        Posecen[Cvor_OD] = true;
        bool bPovezani = (Cvor_OD == Cvor_DO);      // bool bPovezani = false;  // 1. da li smo sigli smo do ciljnog rutera, ako jesmo onda je bPovezani = T i izlazimo, u suprotnom nastavljamo

        while (!bPovezani && Magacin.Count > 0)
        {
            int Cvor_Pop = Magacin.Pop();
            foreach (var Cvor_Sused in Veze[Cvor_Pop])
            {
                if (Cvor_Sused == Cvor_DO)
                {
                    bPovezani = true;
                    break;
                }
                if (!Posecen[Cvor_Sused])
                {
                    Posecen[Cvor_Sused] = true;
                    Magacin.Push(Cvor_Sused);
                }
            }
        }

        // bool bPovezani = (Cvor_OD == Cvor_DO);  // 1. da li smo sigli smo do ciljnog rutera, ako jesmo onda je bPovezani = T i izlazimo, u suprotnom nastavljamo
        //if (!bPovezani && !Posecen[Cvor_OD])    // 2. Ako tekuci cvor (ruter) OD nije posecen (i jos uvek nije povezan sa cvorom DO)
        //{
        //    Posecen[Cvor_OD] = true;                    // Oznaci da je tekuci cvor (ruter) posecen
        //    int broj_susednih = Veze[Cvor_OD].Count;    // Broj susednih cvorova cvoru Cvor_OD
        //    int sused_id = 0;                           // Indeks prvog susednog cvora (rutera)
        //    while (sused_id < broj_susednih && !bPovezani)  // Za svaki susedni cvor (ruter) tekuceg cvora (rutera) 
        //    {
        //        int Cvor_Sused = Veze[Cvor_OD][sused_id];           // Trenutni susedni cvor (ruter) tekuceg cvora (rutera) Cvor_OD
        //        bPovezani = DFS_Stek(Cvor_Sused, Cvor_DO, Veze, Posecen);// 3. Rekurzivni poziv DFS (susedni, DO)
        //        sused_id++;                                         // Indeks sledeceg susednog cvora (rutera) cvoru Cvor_OD
        //    }
        //}
        return bPovezani;   // Vraca vrednost da li su povezani cvorovi Cvor_OD i Cvor_DO
    }
    static bool Korak_03_Ruteri_R12_Povezani(int Ruter_Start, int Ruter_Cilj, List<int>[] Veze, int broj_Rutera)
    {
        // int broj_Rutera = Veze.Length;
        bool[] Posecen = new bool[broj_Rutera];
        return DFS_Stek(Ruter_Start, Ruter_Cilj, Veze, Posecen);
    }
    static void Main()
    {
        List<int>[] Veze = Korak_01_Graf_Ruteri_i_Veze_Niz_Listi_Ucitaj();  // Korak 1: ULAZ: Ucitavanje Grafa
        Korak_02_Graf_Obrada_Test_Primera(Veze);                            // Korak 2: ULAZ: Ucitavanje test primera
    }
    static List<int>[] Korak_01_Graf_Ruteri_i_Veze_Niz_Listi_Ucitaj()
    {
        int broj_Rutera = int.Parse(Console.ReadLine());
        List<int>[] Veze = new List<int>[broj_Rutera + 1];  // + 1 -> Zato sto brojevi rutera idu od 1, a ne od 0 u test primerima
        for (int i = 0; i < broj_Rutera + 1; i++) Veze[i] = new List<int>();

        int broj_Veza = int.Parse(Console.ReadLine());
        for (int i = 0; i < broj_Veza; i++)
        {
            string[] s = Console.ReadLine().Split();
            int Ruter_OD = int.Parse(s[0]);     // Ruter_OD != Ruter_DO => Rueter_OD i Ruter_DO su obavezno razliciti iz teksta zadatka
            int Ruter_DO = int.Parse(s[1]);     // Ruter_OD--; Ruter_DO--;  // Zato sto brojevi rutera idu od 1, a ne od 0 u test primerima
            Veze[Ruter_OD].Add(Ruter_DO);
        }
        return Veze;
    }
    static void Korak_02_Graf_Obrada_Test_Primera(List<int>[] Veze)
    {
        int broj_Rutera = Veze.Length;
        int broj_Parova = int.Parse(Console.ReadLine());
        for (int i = 0; i < broj_Parova; i++)
        {
            string[] s = Console.ReadLine().Split();
            int Ruter_Start = int.Parse(s[0]);
            int Ruter_Cilj = int.Parse(s[1]);   // Ruter_Start--; Ruter_Cilj--; // Zato sto brojevi rutera idu od 1, a ne od 0 u test primerima
            bool bDa_li_su_povezani_Ruteri_R1_i_R2 = Korak_03_Ruteri_R12_Povezani(Ruter_Start, Ruter_Cilj, Veze, broj_Rutera);
            Console.WriteLine((bDa_li_su_povezani_Ruteri_R1_i_R2) ? "da" : "ne");
        }
    }
}

// R3 T04 Graf 05 Obilazak: DFS: Usmereni graf:
// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka3/dostizni_cvorovi
// https://app.diagrams.net/?title=R3_T04_Graf_05_Obilazak_DFS.drawio&lightbox=1&page-id=OvW9At-KTonu65IJHdt-&client=1
// https://app.diagrams.net/#Hdraganilicnis%2FR3_T04_Graf_05_Obilazak_DFS%2Fmain%2FR3_T04_Graf_05_Obilazak_DFS.drawio#%7B%22pageId%22%3A%22OvW9At-KTonu65IJHdt-%22%7D
