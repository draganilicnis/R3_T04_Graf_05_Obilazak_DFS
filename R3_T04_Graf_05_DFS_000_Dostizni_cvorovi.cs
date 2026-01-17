using System;
using System.Collections.Generic;
class R3_T04_Graf_05_DFS_000_Dostizni_cvorovi
{
    static bool DFS(int Ruter_OD, int Ruter_DO, bool[] Posecen, List<int>[] Veze)
    {
        bool bPovezani = false;                         // 0. Da li su povezani Ruter_OD i Ruter_DO : inicijalno (pre petlje) nisu
        if (Ruter_OD == Ruter_DO) bPovezani = true;     // 1. Stigli smo do ciljnog rutera
        else if(Posecen[Ruter_OD]) bPovezani = false;   // 2. Ako je tekuci ruter vec ranije bio posecen
        else 
        {
            Posecen[Ruter_OD] = true;                   // Oznaci da je tekuci ruter posecen
            int broj_susednih = Veze[Ruter_OD].Count;   // Broj susednih cvorova cvoru Ruter_OD
            int sused_id = 0;                           // Indeks prvog susednog cvora (rutera)
            while (sused_id < broj_susednih && !bPovezani)  // Za svaki susedni ruter tekuceg rutera
            {
                int Ruter_Susedni = Veze[Ruter_OD][sused_id];   // Trenutni susedni ruter tekucek rutera
                bPovezani = DFS(Ruter_Susedni, Ruter_DO, Posecen, Veze); // 3. 
                sused_id++;                             // Indeks sledeceg susednog cvora (rutera)
            }
        }
        return bPovezani;   // false;
    }
    static bool Korak_03_Ruteri_R12_Povezani(int Ruter_Start, int Ruter_Cilj, int broj_Rutera, List<int>[] Veze)
    {
        bool[] Posecen = new bool[broj_Rutera];
        return DFS(Ruter_Start, Ruter_Cilj, Posecen, Veze);
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
            int Ruter_OD = int.Parse(s[0]);
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
            bool bDa_li_su_povezani_Ruteri_R1_i_R2 = Korak_03_Ruteri_R12_Povezani(Ruter_Start, Ruter_Cilj, broj_Rutera, Veze);
            Console.WriteLine((bDa_li_su_povezani_Ruteri_R1_i_R2) ? "da" : "ne");
        }
    }
}

// R3 T04 Graf 05 Obilazak: DFS: Usmereni graf:
// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka3/dostizni_cvorovi
// https://app.diagrams.net/?title=R3_T04_Graf_05_Obilazak_DFS.drawio&lightbox=1&page-id=OvW9At-KTonu65IJHdt-&client=1
// https://app.diagrams.net/#Hdraganilicnis%2FR3_T04_Graf_05_Obilazak_DFS%2Fmain%2FR3_T04_Graf_05_Obilazak_DFS.drawio#%7B%22pageId%22%3A%22OvW9At-KTonu65IJHdt-%22%7D
