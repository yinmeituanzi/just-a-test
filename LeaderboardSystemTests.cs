using NUnit.Framework;
using System.Collections.Generic;

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
