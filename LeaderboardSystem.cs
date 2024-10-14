using System;
using System.Collections.Generic;

public class LeaderboardSystem
{
    public static List<int> GetTopScores(int[] scores, int m)
    {
        if (scores == null || scores.Length == 0 || m <= 0)
        {
            return new List<int>();
        }

        m = Math.Min(m, scores.Length);

        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

        foreach (int score in scores)
        {
            if (minHeap.Count < m)
            {
                minHeap.Enqueue(score, score);
            }
            else if (score > minHeap.Peek())
            {
                minHeap.Dequeue();
                minHeap.Enqueue(score, score);
            }
        }

        List<int> result = new List<int>(minHeap.Count);
        while (minHeap.Count > 0)
        {
            result.Add(minHeap.Dequeue().Element);
        }
        result.Sort((a, b) => b.CompareTo(a)); 

        return result;
    }
}
//时间复杂度：遍历 scores 数组需要 O(n)。每次插入或删除堆顶元素的操作是 O(log m)。
//整体时间复杂度为 O(n log m)，尤其适用于 m 远小于 n 的情况。
//空间复杂度：使用了一个大小为 m 的最小堆，空间复杂度为 O(m)。


public class LeaderboardSystemTests
{
    [Test]
    public void TestGetTopScores_NormalCase()
    {
        int[] scores = { 100, 50, 75, 80, 65 };
        int m = 3;
        List<int> result = LeaderboardSystem.GetTopScores(scores, m);
        List<int> expected = new List<int> { 100, 80, 75 };

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestGetTopScores_EmptyArray()
    {
        int[] scores = { };
        int m = 3;
        List<int> result = LeaderboardSystem.GetTopScores(scores, m);
        List<int> expected = new List<int>();

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestGetTopScores_MGreaterThanLength()
    {
        int[] scores = { 100, 50, 75 };
        int m = 5;
        List<int> result = LeaderboardSystem.GetTopScores(scores, m);
        List<int> expected = new List<int> { 100, 75, 50 };

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestGetTopScores_MEqualZero()
    {
        int[] scores = { 100, 50, 75 };
        int m = 0;
        List<int> result = LeaderboardSystem.GetTopScores(scores, m);
        List<int> expected = new List<int>();

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestGetTopScores_NullArray()
    {
        int[] scores = null;
        int m = 3;
        List<int> result = LeaderboardSystem.GetTopScores(scores, m);
        List<int> expected = new List<int>();

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void TestGetTopScores_WithDuplicates()
    {
        int[] scores = { 100, 50, 75, 80, 65, 80, 100 };
        int m = 3;
        List<int> result = LeaderboardSystem.GetTopScores(scores, m);
        List<int> expected = new List<int> { 100, 100, 80 };

        Assert.AreEqual(expected, result);
    }
}
