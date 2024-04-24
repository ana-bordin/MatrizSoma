// 2. faça um programa que leia uma matriz quadrada e faça a soma dos valores da linha, da coluna e da diagonal;
int tamanho = 5, resultadoLinha = 0, resultadoDiagonal1 = 0, resultadoDiagonal2 = 0, resultadoColuna = 0;
int[,] matriz = new int[tamanho, tamanho];
int[] matrizLinha = new int[tamanho], matrizColuna = new int[tamanho];

for (int i = 0; i < tamanho; i++)
{
    for (int j = 0; j < tamanho; j++)
    {
        matriz[i, j] = new Random().Next(1, 5);
        Console.Write($"{matriz[i, j]}, ");
    }
    Console.WriteLine();
}

for (int i = 0; i < tamanho; i++)
{
    resultadoLinha = 0;
    resultadoColuna = 0;

    for (int j = 0; j < tamanho; j++)
    {
        resultadoLinha += matriz[i, j];
        resultadoColuna += matriz[j, i];
    }
    matrizLinha[i] = resultadoLinha;
    matrizColuna[i] = resultadoColuna;
}

for (int i = 0; i < tamanho; i++)
{
    for (int j = 0; j < tamanho; j++)
    {
        if (i == j)
            resultadoDiagonal1 += matriz[i, j];
    }
}

for (int i = tamanho - 1; i > -1; i--)
{
    for (int j = tamanho - 1; j > -1; j--)
    {
        if (i + j == tamanho - 1)
            resultadoDiagonal2 += matriz[i, j];
    }
}

for (int i = 0; i < tamanho; i++)
    Console.WriteLine($"linha {i + 1}: {matrizLinha[i]};");
for (int i = 0; i < tamanho; i++)
    Console.WriteLine($"coluna {i + 1}: {matrizColuna[i]};");
    
Console.WriteLine($"diagonal 1: {resultadoDiagonal1};\ndiagonal 2: {resultadoDiagonal2};");
