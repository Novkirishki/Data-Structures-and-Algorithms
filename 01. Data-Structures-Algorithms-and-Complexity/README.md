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

####Answer: The outer 'for' will loop n times, the inner 'while' will loop another n times(because on every loop we either increase start or decrease end). In conclusion the complexity is n*n. 

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

####Answer: We have a recursion here. The outer 'for' will loop n times. On every loop it will call the same function with row + 1. The newly called functions will do exaclty the same by calling new n functions with row+2. When we hit the last row the recursion will stop. This algorith makes a tree like this one: 

![tree](tree.png)

It has a dept of m and width of n ^ (m - 1). In conclusion the complexity is n ^ m.