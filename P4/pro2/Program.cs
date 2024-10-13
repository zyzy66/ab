using System;
using System.Collections.Generic;


//多数组
public class MultiArrayMedian
{
    public static double FindMedianOfMultipleSortedArrays(int[][] arrays)
    {

        var minHeap = new SortedSet<(int value, int arrayIndex, int elementIndex)>(Comparer<(int value, int arrayIndex, int elementIndex)>.Create((a, b) =>
        {
            int cmp = a.value.CompareTo(b.value);
            if (cmp == 0) return a.arrayIndex.CompareTo(b.arrayIndex);
            return cmp;
        }));

        int totalLength = 0;

        // 初始化堆
        for (int i = 0; i < arrays.Length; i++)
        {
            if (arrays[i].Length > 0)
            {
                minHeap.Add((arrays[i][0], i, 0));
                totalLength += arrays[i].Length;
            }
        }

        int medianPos1 = (totalLength - 1) / 2;
        int medianPos2 = totalLength / 2;
        int currentPos = 0;
        int median1 = 0, median2 = 0;

        while (minHeap.Count > 0)
        {
            var minElement = minHeap.Min;
            minHeap.Remove(minElement);
            var (value, arrayIndex, elementIndex) = minElement;

            if (currentPos == medianPos1)
            {
                median1 = value;
            }

            if (currentPos == medianPos2)
            {
                median2 = value;
                break;
            }

            currentPos++;

            // 插入该数组的下一个元素
            if (elementIndex + 1 < arrays[arrayIndex].Length)
            {
                minHeap.Add((arrays[arrayIndex][elementIndex + 1], arrayIndex, elementIndex + 1));
            }
        }

        // 如果总长度是奇数，返回 median1；否则返回两个中位数的平均值
        return totalLength % 2 == 1 ? median1 : (median1 + median2) / 2.0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[][] arrays = new int[][]
        {
            new int[] {1, 3, 5},
            new int[] {2, 4, 6},
            new int[] {0, 8, 9},
            new int[] {10, 12},
            new int[] {7, 11, 13}
        };

        double result = MultiArrayMedian.FindMedianOfMultipleSortedArrays(arrays);
        Console.WriteLine($"Median: {result}");
    }
}





