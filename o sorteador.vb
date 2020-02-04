Module Module1

    Sub Main()
        ' Sorteando dez números que estejam entre o intervalo de 1 e 100.
        Console.WriteLine(String.Join(", ", SorteiaNumerosSemRepetir(100, 1, 100)))
        Console.ReadLine()
    End Sub

    Private Function SorteiaNumerosSemRepetir(quantidade As Integer, minimo As Integer, maximo As Integer) As Integer()
        ' Validações dos argumentos.
        If quantidade < 0 Then
            Throw New ArgumentException("Quantidade deve ser maior que zero.")
        ElseIf quantidade > maximo + 1 - minimo Then
            Throw New ArgumentException("Quantidade deve ser menor do que a diferença entre máximo e mínimo.")
        ElseIf maximo <= minimo Then
            Throw New ArgumentException("Máximo deve ser maior do que mínimo.")
        End If

        Dim numerosSorteados As New List(Of Integer)()
        Dim rnd As New Random()

        While numerosSorteados.Count < quantidade
            Dim numeroSorteado As Integer = rnd.[Next](minimo, maximo + 1)

            ' Número já foi sorteado? Então sorteamos novamente até o número não ter sido sorteado ainda.
            While numerosSorteados.Contains(numeroSorteado)
                numeroSorteado = rnd.[Next](minimo, maximo + 1)
            End While

            numerosSorteados.Add(numeroSorteado)
        End While

        Return numerosSorteados.ToArray()
    End Function
End Module
