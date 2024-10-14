using System;
using System.Collections.Generic;

public class TalentAssessmentSystem
{
    private PriorityQueue<int, int> minHeap;  // 最小堆，用于存储较大的一半数据
    private PriorityQueue<int, int> maxHeap;  // 最大堆，用于存储较小的一半数据

    public TalentAssessmentSystem()
    {
        minHeap = new PriorityQueue<int, int>();  
        maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));  
    }

    public void AddAbility(int ability)
    {
        if(minHeap.Count>=maxHeap.Count)
        {
            minHeap.Enqueue(ability.ability);
            maxHeap.Enqueue(minHeap.Peek(), minHeap.Peek());
            minHeap.Dequeue();
        }
        else{
            maxHeap.Enqueue(ability.ability);
            minHeap.Enqueue(maxHeap.Peek(), maxHeap.Peek());
            maxHeap.Dequeue();
        }
    }

    // 获取当前的中位数
    public double FindMedian()
    {
        if (maxHeap.Count > minHeap.Count)
        {
            
            return maxHeap.Peek();
        }
        else if(maxHeap.Count < minHeap.Count)
        {
            return minHeap.Peek();
        }

        return ((double)maxHeap.Peek()+(double)minHeap.Peek())/2.0;
    }
}
//通过维护一个大顶堆和一个小顶堆，即可实现快速的动态查找中位数
//时间复杂度：插入：O(log n)。查找中位数：O(1)。
//空间复杂度：两个堆共存储所有插入的数据，因此空间复杂度为 O(n)。