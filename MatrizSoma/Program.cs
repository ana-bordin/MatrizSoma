// 2. faça um programa que leia uma matriz quadrada e faça a soma dos valores da linha, da coluna e da diagonal;
int tamanho, resultadoLinhaColuna = 0, resultadoDiagonal1 = 0, opcao = 0, resultadoDiagonal2 = 0, resultadoColuna = 0, indiceZero = 0;

int[,] CriarMatriz()
{
    int[,] matriz = new int[tamanho, tamanho];
    return matriz;
}

int MenuPreencher()
{
    Console.WriteLine("1 - para digitar todos elementos;");
    Console.WriteLine("2 - sortear números aleatórios;");
    opcao = int.Parse(Console.ReadLine());
    return opcao;
}
int[,] PreencherMatriz()
{
    opcao = MenuPreencher();

    switch (opcao)
    {
        case 1:
            return (PreencherManual());
        case 2:
            return (PreencherAleatorio());
        default:
            Console.WriteLine("Digite um número válido!");
            opcao = 0;
            return null;
    }
}
int[,] PreencherAleatorio()
{
    int[,] matriz = CriarMatriz();
    for (int linha = 0; linha < tamanho; linha++)
    {
        for (int coluna = 0; coluna < tamanho; coluna++)
            matriz[linha, coluna] = new Random().Next(0, 5);
    }
    return matriz;
}
int[,] PreencherManual()
{
    int[,] matriz = CriarMatriz();
    for (int linha = 0; linha < tamanho; linha++)
    {
        Console.WriteLine($"Linha {linha + 1}:");
        for (int coluna = 0; coluna < tamanho; coluna++)
            matriz[linha, coluna] = int.Parse(Console.ReadLine());
    }
    return matriz;
}

int Menu()
{
    Console.WriteLine("\n- definir operação dos elementos da matriz:");
    Console.WriteLine("1 - adição linha;");
    Console.WriteLine("2 - adição coluna;");
    Console.WriteLine("3 - adicão diagonal;");
    opcao = int.Parse(Console.ReadLine());
    return opcao;
}
void FazerOperacao(int[,] matriz, int[] vetorLinha, int[] vetorColuna, int[]vetorDiagonal)
{
    do
    {
        opcao = Menu();
        switch (opcao)
        {
            case 1:
                SomarLinhaColuna(matriz, vetorLinha, 1);
                break;
            case 2:
                SomarLinhaColuna(matriz, vetorColuna, 2);
                break;
            case 3:
                SomarDiagonal(matriz, vetorDiagonal);
                break;
            default:
                Console.WriteLine("Dgite uma operação valida!");
                opcao = 0;
                break;
        }
    } while (opcao == 0);
}
void SomarLinhaColuna(int[,] matriz,int[] vetorLinhaColuna, int opcao)
{
    for (int i = 0; i < tamanho; i++)
    {
        resultadoLinhaColuna = 0;
        for (int j = 0; j < tamanho; j++)
        {
            if (opcao == 1)
                resultadoLinhaColuna += matriz[i, j];
            else
                resultadoLinhaColuna += matriz[j, i];
            
        }
        vetorLinhaColuna[i] = resultadoLinhaColuna;
    }
    if (opcao == 1)
        ImprimirResultado(vetorLinhaColuna, "Linha");
    else
        ImprimirResultado(vetorLinhaColuna, "Coluna");

}
void SomarDiagonal(int[,] matriz, int[] vetorDiagonal)
{
    for (int i = 0; i < tamanho; i++)
    {
        for (int j = 0; j < tamanho; j++)
        {
            if (i == j)
                vetorDiagonal[0] += matriz[i, j];
            if (((tamanho - 1) - i) + ((tamanho - 1) - j) == tamanho - 1)
            {
                if (i + j == tamanho - 1)
                    vetorDiagonal[1] += matriz[i, j];
            }
        }
    }
    ImprimirResultado(vetorDiagonal, "Diagonal");
}
void ImprimirResultado(int[] vetor, string texto)
{
    for (int i = 0; i < tamanho; i++)
        Console.WriteLine($"{texto} {i + 1}: {vetor[i]};");
}
do
{
    Console.WriteLine("-Calculadora de valores de Matrizes:-");

    Console.WriteLine("\n- definir número de coluna e linhas:");
    tamanho = int.Parse(Console.ReadLine());

    Console.WriteLine("\n- definir números das posições da matriz:");
    int[,] matriz = PreencherMatriz();
    int[] vetorLinha = new int[tamanho], vetorColuna = new int[tamanho], vetorDiagonal= new int[2];

    Console.WriteLine("\n-mostrar matriz:");
    for (int linha = 0; linha < tamanho; linha++)
    {
        Console.WriteLine();
        for (int coluna = 0; coluna < tamanho; coluna++)
            Console.Write($"{matriz[linha, coluna]}, ");
    }
    Console.WriteLine("\n");
    FazerOperacao(matriz, vetorLinha, vetorColuna, vetorDiagonal);

    Console.WriteLine("Deseja começar de novo? Se deseja digite 0;\nse não, digite outro número;");
    opcao = int.Parse(Console.ReadLine());
} while (opcao == 0);