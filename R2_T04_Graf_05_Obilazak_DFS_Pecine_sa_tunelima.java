// DFS - Pecine

import java.util.*;

public class R2_T04_Graf_05_Obilazak_DFS_Pecine {

    // Klasa Veza (Hodnik) izmedu dva cvora (dvorane)
    static class Veza {
        int Cvor_DO;   // Do kog cvora vodi veza
        int Cvor_RV;   // Razlika visina

        public Veza(int Cvor_B, int Cvor_V) {
            this.Cvor_DO = Cvor_B;
            this.Cvor_RV = Cvor_V;
        }
    }

    // DFS metoda za pronalaženje minimalne nadmorske visine
    static int DFS_Visina_Min(int Cvor_OD, int Cvor_OD_Visina, List<Veza>[] Veze) {
        int Nadmorska_Visina_Min = Cvor_OD_Visina;

        for (Veza Cvor_OD_Veza : Veze[Cvor_OD]) {
            int Cvor_DO_Visina_Pom = Cvor_OD_Visina + Cvor_OD_Veza.Cvor_RV;
            int Cvor_DO_Visina_Min = DFS_Visina_Min(
                    Cvor_OD_Veza.Cvor_DO,
                    Cvor_DO_Visina_Pom,
                    Veze
            );

            if (Nadmorska_Visina_Min > Cvor_DO_Visina_Min) {
                Nadmorska_Visina_Min = Cvor_DO_Visina_Min;
            }
        }

        return Nadmorska_Visina_Min;
    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        // ULAZ
        int VT_Nadmorska_visina_tla = sc.nextInt(); // pocetna visina tla
        int N = sc.nextInt();                       // broj cvorova
        int V = sc.nextInt();                       // broj veza

        // Niz listi susedstva
        List<Veza>[] Veze = new ArrayList[N];
        for (int c = 0; c < N; c++) {
            Veze[c] = new ArrayList<>();
        }

        // Ucitavanje veza
        for (int v = 0; v < V; v++) {
            int Cvor_OD = sc.nextInt();
            int Cvor_DO = sc.nextInt();
            int Cvor_RV = sc.nextInt();

            Veze[Cvor_OD].add(new Veza(Cvor_DO, Cvor_RV));

            // Ako je neusmeren graf:
            // Veze[Cvor_DO].add(new Veza(Cvor_OD, -Cvor_RV));
        }

        // DFS poziv
        int rezultat = DFS_Visina_Min(
                0,
                VT_Nadmorska_visina_tla,
                Veze
        );

        // Izlaz
        System.out.println(rezultat);

        sc.close();
    }
}