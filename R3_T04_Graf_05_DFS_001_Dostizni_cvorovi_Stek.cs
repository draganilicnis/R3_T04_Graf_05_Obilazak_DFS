using System;
using System.Collections.Generic;
class R3_T04_Graf_05_DFS_001_Dostizni_cvorovi_Stek
{
    static bool DFS_Rekz_Original(int Cvor_OD, int Cvor_DO, List<int>[] Veze, bool[] Posecen)
    {
        if (Cvor_OD == Cvor_DO) return true;        // 1. Da li smo sigli smo do ciljnog cvora, ako jesmo onda je bPovezani = T i izlazimo, u suprotnom nastavljamo
        if (Posecen[Cvor_OD]) return false;         // 2. Ako tekuci cvor OD nije posecen (i jos uvek nije povezan sa cvorom DO)
        Posecen[Cvor_OD] = true;                    // 3. Oznaci da je tekuci cvor (ruter) posecen
        foreach (var Cvor_Susedni in Veze[Cvor_OD]) // 4. Za svaki susedni cvor tekuceg cvora rekurzivni poziv
            if (DFS_Rekz(Cvor_Susedni, Cvor_DO, Veze, Posecen)) return true;
        return false;
    }
    static bool DFS_Rekz(int Cvor_OD, int Cvor_DO, List<int>[] Veze, bool[] Posecen)
    {
        bool bPovezani = (Cvor_OD == Cvor_DO);      // 1. Da li smo sigli smo do ciljnog cvora, ako jesmo onda je bPovezani = T i izlazimo, u suprotnom nastavljamo
        if (!bPovezani && !Posecen[Cvor_OD])        // 2. Ako tekuci cvor OD nije posecen (i jos uvek nije povezan sa cvorom DO)
        {
            Posecen[Cvor_OD] = true;                // 3. Oznaci da je tekuci cvor (ruter) posecen
            foreach (var Cvor_Susedni in Veze[Cvor_OD])     // 4. Za svaki susedni cvor tekuceg cvora rekurzivni poziv
                if (DFS_Rekz(Cvor_Susedni, Cvor_DO, Veze, Posecen)) return true;
        }
        return bPovezani;   // Vraca vrednost da li su povezani cvorovi Cvor_OD i Cvor_DO
    }

    static bool DFS_Stek(int Cvor_OD, int Cvor_DO, List<int>[] Veze, bool[] Posecen)
    {
        // int N_broj_Cvorova = Veze.Length;
        // bool[] Posecen = new bool[N_broj_Cvorova];   // Ne mora da se prenosi bool[] Posecen kao 4. parametar (argument)
        bool bPovezani = (Cvor_OD == Cvor_DO);          // 0. Da li smo sigli smo do ciljnog cvora, ako jesmo onda je bPovezani = T i izlazimo, u suprotnom nastavljamo
        var Magacin = new Stack<int>();                 // 0. Magacin (Stack)
        Magacin.Push(Cvor_OD);                          // 1. Dodaj pocetni cvor u kolekciju (magacin)
        Posecen[Cvor_OD] = true;                        // 1. Zapamti da si dodao pocetni cvor u kolekciju (magacin)

        while (!bPovezani && Magacin.Count > 0)     // 2. Dok kolekcija (magacin) nije prazna
        {
            int Cvor_OD_Pop = Magacin.Pop();                // 3. Uzmi cvor iz kolekcije
            foreach (var Cvor_Sused in Veze[Cvor_OD_Pop])
            {
                if (Cvor_Sused == Cvor_DO)
                {
                    bPovezani = true;
                    break;                                  // Ovde izlazi iz petlje foreach (testiraj za 1 i 2, ne ispituje sused 3)
                }
                if (!Posecen[Cvor_Sused])                   // 4. Ako cvor nije oznacen
                {
                    Posecen[Cvor_Sused] = true;             // 5. Oznaci cvor
                    Magacin.Push(Cvor_Sused);               // 6. Ubaci cvor u kolekciju
                }
            }
        }
        return bPovezani;   // Vraca vrednost da li su povezani cvorovi Cvor_OD i Cvor_DO
    }
    static bool DFS_Stek_v2(int Cvor_OD, int Cvor_DO, List<int>[] Veze, bool[] Posecen)
    {
        // int N_broj_Cvorova = Veze.Length;
        // bool[] Posecen = new bool[N_broj_Cvorova];   // Ne mora da se prenosi bool[] Posecen kao 4. parametar (argument)
        bool bPovezani = (Cvor_OD == Cvor_DO);          // 0. Da li smo sigli smo do ciljnog cvora, ako jesmo onda je bPovezani = T i izlazimo, u suprotnom nastavljamo
        var Magacin = new Stack<int>();                 // 0. Magacin (Stack)
        Magacin.Push(Cvor_OD);                          // 1. Dodaj pocetni cvor u kolekciju (magacin)
        Posecen[Cvor_OD] = true;

        while (!bPovezani && Magacin.Count > 0)         // 2. Dok kolekcija (magacin) nije prazna
        {
            int Cvor_OD_Pop = Magacin.Pop();                // 3. Uzmi cvor iz kolekcije
            int cvorID = 0;
            int broj_veza = Veze[Cvor_OD_Pop].Count;
            while (cvorID < broj_veza && !bPovezani)
            {
                var Cvor_Sused = Veze[Cvor_OD_Pop][cvorID];
                bPovezani = (Cvor_Sused == Cvor_DO);
                if (!bPovezani && !Posecen[Cvor_Sused])     // 4. Ako cvor nije oznacen
                {
                    Posecen[Cvor_Sused] = true;             // 5. Oznaci cvor
                    Magacin.Push(Cvor_Sused);               // 6. Ubaci cvor u kolekciju
                }
                cvorID++;
            }
        }
        return bPovezani;   // Vraca vrednost da li su povezani cvorovi Cvor_OD i Cvor_DO
    }

    static bool Korak_03_Cvorovi_R12_Povezani(int Cvor_Start, int Cvor_Cilj, List<int>[] Veze, int DFS_Verzija = 0)
    {
        int N_broj_Cvorova = Veze.Length;                           // Ukupan broj cvorova: zbog dimenzije niza bool Posecen[N]
        bool[] Posecen = new bool[N_broj_Cvorova];                  // Za svaki cvor F ili T da li je posecen:  bool Posecen[N]
        bool bCvorovi_Start_i_Cilj_su_povezani = false;             // Promenljiva u kojoj se cuva da li su dva konkretna cvora povezana

        DFS_Verzija = 2;            // Testiranje razlicitih verzija DFS metoda. U ovoj liniji koda rucno menjamo 0 ili 1.
        switch (DFS_Verzija)        // Testiranje razlicitih verzija DFS metoda
        {
            case 0: bCvorovi_Start_i_Cilj_su_povezani = DFS_Rekz(Cvor_Start, Cvor_Cilj, Veze, Posecen); break;  // DFS rekurzivno
            case 1: bCvorovi_Start_i_Cilj_su_povezani = DFS_Stek(Cvor_Start, Cvor_Cilj, Veze, Posecen); break;  // DFS koriscenjem steka umesto rekurzije
            case 2: bCvorovi_Start_i_Cilj_su_povezani = DFS_Stek_v2(Cvor_Start, Cvor_Cilj, Veze, Posecen); break;  // DFS koriscenjem steka umesto rekurzije
        }
        return bCvorovi_Start_i_Cilj_su_povezani;
    }

    static void Main()
    {
        List<int>[] Veze = Korak_01_Graf_Cvorovi_i_Veze_Niz_Listi_Ucitaj();     // Korak 1: ULAZ: Ucitavanje Grafa
        Korak_02_Graf_Obrada_Test_Primera(Veze);                                // Korak 2: ULAZ: Ucitavanje test primera
    }
    static List<int>[] Korak_01_Graf_Cvorovi_i_Veze_Niz_Listi_Ucitaj()
    {
        int N_broj_Cvorova = int.Parse(Console.ReadLine());
        var Veze = new List<int>[N_broj_Cvorova + 1];                   // + 1 -> Zato sto brojevi rutera idu od 1, a ne od 0 u test primerima
        for (int cvor = 0; cvor < N_broj_Cvorova + 1; cvor++) Veze[cvor] = new List<int>();

        int M_broj_Veza = int.Parse(Console.ReadLine());
        for (int i = 0; i < M_broj_Veza; i++)
        {
            string[] s = Console.ReadLine().Split();
            int Cvor_OD = int.Parse(s[0]);          // Cvor_OD != Cvor_DO => Cvor_OD i Cvor_DO su obavezno razliciti iz teksta zadatka
            int Cvor_DO = int.Parse(s[1]);          // Cvor_OD--; Cvor_DO--;  // Zato sto brojevi rutera idu od 1, a ne od 0 u test primerima
            Veze[Cvor_OD].Add(Cvor_DO);
        }
        return Veze;
    }
    static void Korak_02_Graf_Obrada_Test_Primera(List<int>[] Veze)
    {
        int P_broj_Parova = int.Parse(Console.ReadLine());
        for (int i = 0; i < P_broj_Parova; i++)
        {
            string[] s = Console.ReadLine().Split();
            int Ruter_Start = int.Parse(s[0]);
            int Ruter_Cilj = int.Parse(s[1]);   // Ruter_Start--; Ruter_Cilj--; // Zato sto brojevi rutera idu od 1, a ne od 0 u test primerima
            bool bDa_li_su_povezani_Ruteri_R1_i_R2 = Korak_03_Cvorovi_R12_Povezani(Ruter_Start, Ruter_Cilj, Veze);
            Console.WriteLine((bDa_li_su_povezani_Ruteri_R1_i_R2) ? "da" : "ne");
        }
    }
}

// R3 T04 Graf 05 Obilazak: DFS: Usmereni graf:
// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka3/dostizni_cvorovi
// https://app.diagrams.net/?title=R3_T04_Graf_05_Obilazak_DFS.drawio&lightbox=1&page-id=OvW9At-KTonu65IJHdt-&client=1
// https://app.diagrams.net/#Hdraganilicnis%2FR3_T04_Graf_05_Obilazak_DFS%2Fmain%2FR3_T04_Graf_05_Obilazak_DFS.drawio#%7B%22pageId%22%3A%22OvW9At-KTonu65IJHdt-%22%7D
