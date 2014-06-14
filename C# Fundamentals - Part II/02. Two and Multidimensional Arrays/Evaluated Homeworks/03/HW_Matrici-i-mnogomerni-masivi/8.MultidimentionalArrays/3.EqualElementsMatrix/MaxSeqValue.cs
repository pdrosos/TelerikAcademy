using System;
using System.Collections.Generic;

class MaxSeqValue
{


    static void Main(string[] args)
    {
        string[,] arr =
            {
                
               { "ha", "ha", "w" },
               { "fo", "ha", "w" },
               { "xxx", "ho", "w" }

            };
            int maxSeq = 0;
            string character = null;
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                   
                    string ch = null;
                    int sum = 1;
                    
                    for (int column = col; column < arr.GetLength(1)-1; column++)
                    {
                        
                        if (arr[row, column] == arr[row, column + 1])
                        {
                            sum++;
                            ch = arr[row, column];
                        }
                    }
                    if (sum > maxSeq)
                    {
                        maxSeq = sum;
                        character = ch;
                    }
                    sum = 1;
                    for (int rows = row; rows < arr.GetLength(0) - 1; rows++)
                    {
                        if (arr[rows, col] == arr[rows+1, col])
                        {
                            sum++;
                            ch = arr[rows, col];
                            
                        }
                    }
                    if (sum > maxSeq)
                    {
                        maxSeq = sum;
                        character = ch;
                    }
                    sum = 1;
                    for (int rows = row, column = col; rows < arr.GetLength(0)-1 && column < arr.GetLength(1)-1; rows++, column++)
                    {
                        if (arr[rows, column] == arr[rows + 1, column + 1])
                        {
                            sum++;
                            ch = arr[rows, column];
                        }
                    }
                    if (sum > maxSeq)
                    {
                        maxSeq = sum;
                        character = ch;
                    }
                   
                }
                
            }
            Console.WriteLine(maxSeq);
            for (int i = 0; i < maxSeq; i++)
            {
                Console.WriteLine(character);
            }
        }
    }

