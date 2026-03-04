// DFS - Pecine
// Brzi ulaz/izlaz (BufferedReader + PrintWriter)

import java.io.*;
import java.util.*;

public class R2_T04_Graf_05_Obilazak_DFS_Pecine {

    static class Veza {
        int Cvor_DO;
        int Cvor_RV;

        public Veza(int Cvor_DO, int Cvor_RV) {
            this.Cvor_DO = Cvor_DO;
            this.Cvor_RV = Cvor_RV;
        }
    }

    static int DFS_Visina_Min(int Cvor_OD, int Cvor_OD_Visina, List<Veza>[] Veze) {
        int Nadmorska_Visina_Min = Cvor_OD_Visina;

        for (Veza v : Veze[Cvor_OD]) {
            int novaVisina = Cvor_OD_Visina + v.Cvor_RV;
            int minIzPodstabla = DFS_Visina_Min(v.Cvor_DO, novaVisina, Veze);

            if (Nadmorska_Visina_Min > minIzPodstabla) {
                Nadmorska_Visina_Min = minIzPodstabla;
            }
        }

        return Nadmorska_Visina_Min;
    }

    public static void main(String[] args) throws Exception {

        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        PrintWriter out = new PrintWriter(new BufferedWriter(new OutputStreamWriter(System.out)));

        // ULAZ
        int VT_Nadmorska_visina_tla = Integer.parseInt(br.readLine().trim());
        int N = Integer.parseInt(br.readLine().trim());
        int V = Integer.parseInt(br.readLine().trim());

        // Lista susedstva
        List<Veza>[] Veze = new ArrayList[N];
        for (int i = 0; i < N; i++) {
            Veze[i] = new ArrayList<>();
        }

        // Ucitavanje veza
        for (int i = 0; i < V; i++) {
            StringTokenizer st = new StringTokenizer(br.readLine());
            int Cvor_OD = Integer.parseInt(st.nextToken());
            int Cvor_DO = Integer.parseInt(st.nextToken());
            int Cvor_RV = Integer.parseInt(st.nextToken());

            Veze[Cvor_OD].add(new Veza(Cvor_DO, Cvor_RV));

            // Ako je neusmeren graf:
            // Veze[Cvor_DO].add(new Veza(Cvor_OD, -Cvor_RV));
        }

        // DFS
        int rezultat = DFS_Visina_Min(0, VT_Nadmorska_visina_tla, Veze);

        // IZLAZ
        out.println(rezultat);
        out.flush();
    }
}