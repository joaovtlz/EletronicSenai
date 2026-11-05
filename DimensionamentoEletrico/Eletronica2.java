package ELETRONICA;

import java.util.Scanner;

public class Eletronica2 {

        public static void main(String[] args) {
            Scanner input = new Scanner(System.in);

            int potencia = 20650;

            System.out.print("Tensao da casa (127 ou 220): ");
            int tensao = input.nextInt();

            if (tensao == 127 || tensao == 220) {
                double corrente = (double) potencia / tensao;

                System.out.println("Potencia total: " + potencia + " W");
                System.out.printf("Corrente: %.2f A%n", corrente);

                if (potencia <= 10000)
                    System.out.println("Disjuntor: 40A ou 50A | Cabo: 10mm²");
                else if (potencia <= 15000)
                    System.out.println("Disjuntor: 63A | Cabo: 16mm²");
                else if (potencia <= 22000)
                    System.out.println("Disjuntor: 70A ou 80A | Cabo: 25mm²");
                else if (potencia <= 38000)
                    System.out.println("Disjuntor: 100A | Cabo: 35mm²");
                else if (potencia <= 47000)
                    System.out.println("Disjuntor: 125A | Cabo: 50mm²");
                else
                    System.out.println("Potencia acima da tabela!");
            } else {
                System.out.println("Tensao invalida!");
            }

            input.close();
        }
    }

