## Data Structures, Algorithms and Complexity
### _Homework_

1. What is the expected running time of the following C# code? Explain why.
  - Assume the array's size is `n`.

```cs
long Compute(int[] arr)
{
    long count = 0;
    for (int i=0; i<arr.Length; i++)
    {
        int start = 0, end = arr.Length-1;
        while (start < end)
            if (arr[start] < arr[end])
                { start++; count++; }
            else 
                end--;
    }
    return count;
}
```

####Answer: The outer 'for' will loop n times, the inner 'while' will loop another n times(because on every loop we either increase start or decrease end untill they are even, which takes exatly n operations). In conclusion the complexity is n*n. 

2. What is the expected running time of the following C# code?
  - Explain why.
  - Assume the input matrix has size of n * m.

```cs
long CalcCount(int[,] matrix)
{
    long count = 0;
    for (int row=0; row<matrix.GetLength(0); row++)
        if (matrix[row, 0] % 2 == 0)
            for (int col=0; col<matrix.GetLength(1); col++)
                if (matrix[row,col] > 0)
                    count++;
    return count;
}
```

####Answer: The outer 'for' will loop n times. On half of those loops the inner for is going to be called, which will loop m times. So we have n/2 + n/2 * m operations. This makes this algorithm with n * m complexity.

3. * What is the expected running time of the following C# code?
  - Explain why.
  - Assume the input matrix has size of n * m.

```cs
long CalcSum(int[,] matrix, int row)
{
    long sum = 0;
    for (int col = 0; col < matrix.GetLength(0); col++) 
        sum += matrix[row, col];
    if (row + 1 < matrix.GetLength(1)) 
        sum += CalcSum(matrix, row + 1);
    return sum;
}

Console.WriteLine(CalcSum(matrix, 0));
```

####Answer: We have a recursion here. The 'for' will loop n times every time we call the function. After the 'for' finishes the same function will be called with row + 1. So the function will be called m times, because when we hit the last row the recursion will stop. In conclusion the complexity of the algorithm is n * m.