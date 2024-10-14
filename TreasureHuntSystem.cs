using System;
using System.Collections.Generic;

public class TreasureHuntSystem
{
    public static int MaxTreasureValue(int[] treasures)
    {
        int n = treasures.Length;
        if (n == 0) return 0;
        if (n == 1) return Math.Max(treasures[0],0);
        
        int[] dp = new int[n];
        
        dp[0] = Math.Max(treasures[0],0);
        dp[1] = Math.Max(dp[0], treasures[1]);
        
        for (int i = 2; i < n; i++)
        {
            dp[i] = Math.Max(dp[i-1], treasures[i] + Math.Max(0, treasures[i]));
        }
        
        return dp[n-1];
    }
}
//时间复杂度为 O(n)，因为我们只需要一次遍历数组即可完成计算。
//空间复杂度为 O(n)，因为我们使用了一个动态规划数组来存储中间结果。如果优化成只使用常量空间，则空间复杂度可以降为 O(1)。

public class TreasureHuntSystemTests
{
    [Test]
    public void TestMaxTreasureValue()
    {
        int[] treasures = { 3, 1, 5, 2, 4 };
        int result = TreasureHuntSystem.MaxTreasureValue(treasures);
        Console.WriteLine(result);  // 输出: 12

        int[] treasures = { -1, -2, -3 };
        result = TreasureHuntSystem.MaxTreasureValue(treasures);
        NUnit.Framework.Assert.AreEqual(0, result);  // 预期结果：所有宝箱都是负值，应该跳过
    }
}