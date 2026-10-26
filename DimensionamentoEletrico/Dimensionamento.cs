using System.Globalization;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

string continuar = "S";

while (continuar == "S")
{
    Console.WriteLine();
    Console.WriteLine("===== SISTEMA DE DIMENSIONAMENTO ELÉTRICO SENAI =====");

    Console.Write("> Informe o nome do equipamento: ");
    string nome = Console.ReadLine() ?? "";

    double potencia = 0;
    while (potencia <= 0)
    {
        Console.Write("> Informe a potência elétrica (Watts): ");
        string texto = Console.ReadLine() ?? "";
        double.TryParse(texto.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out potencia);

        if (potencia <= 0)
        {
            Console.WriteLine("Potência inválida. Digite um número maior que zero.");
        }
    }

    int tensao = 0;
    while (tensao != 127 && tensao != 220)
    {
        Console.Write("> Tensão da rede (127 ou 220 Volts): ");
        int.TryParse(Console.ReadLine() ?? "", out tensao);

        if (tensao != 127 && tensao != 220)
        {
            Console.WriteLine("Tensão inválida. Digite 127 ou 220.");
        }
    }

    double corrente = potencia / tensao;

    string bitola;
    if (corrente <= 15.5)
    {
        bitola = "1.5 mm²";
    }
    else if (corrente <= 21.0)
    {
        bitola = "2.5 mm²";
    }
    else if (corrente <= 28.0)
    {
        bitola = "4.0 mm²";
    }
    else if (corrente <= 36.0)
    {
        bitola = "6.0 mm²";
    }
    else if (corrente <= 50.0)
    {
        bitola = "10.0 mm²";
    }
    else
    {
        bitola = "16.0 mm² ou superior";
    }

    Console.WriteLine();
    Console.WriteLine("---------------- RESULTADO DO CÁLCULO ----------------");
    Console.WriteLine("- Equipamento: " + nome);
    Console.WriteLine("- Potência Registrada: " + potencia.ToString("0.##", CultureInfo.InvariantCulture) + " W");
    Console.WriteLine("- Tensão da Rede: " + tensao + " V");
    Console.WriteLine("- Corrente Elétrica Calculada: " + corrente.ToString("F2", CultureInfo.InvariantCulture) + " A");
    Console.WriteLine("- Bitola Mínima do Condutor (Cobre): " + bitola);
    Console.WriteLine("------------------------------------------------------");

    Console.WriteLine();
    Console.Write("Deseja calcular outro equipamento? (S/N): ");
    continuar = (Console.ReadLine() ?? "N").Trim().ToUpper();
}

Console.WriteLine("Programa encerrado.");
