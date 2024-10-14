using System;
using System.Collections.Generic;

public class EnergyFieldSystem
{
    public static float MaxEnergyField(int[] heights)
    {
        // 边界情况
        if (heights == null || heights.Length < 2)
        {
            return 0;
        }

        int left = 0;
        int right = heights.Length - 1;
        float maxArea = 0;

        while(left<right)
        {
            int height1=heights[left];
            int height2=heights[right];
            int width=right-left;
            if(height1==0)
            {
                left++;
                continue;
            }
            else if(height2==0)
            {
                right--;
                continue;
            }

            float area = (height1 + height2) * width / 2.0f;
            maxArea = Math.Max(maxArea, area);
            if(left<right)
            {
                left++;
            }
            else
            {
                right++;
            }
        }
        return maxArea;
    }
}
//时间复杂度：双指针法遍历数组一次，每次移动一端的指针，时间复杂度为 O(n)，其中 n 是塔的数量。
//空间复杂度：除了存储少量的指针和中间变量，算法只需要常量的额外空间，空间复杂度为 O(1)。

public class EnergyFieldSystemTests
{
    [Test]
    public void TestMaxEnergyField()
    {
        int[] heights1 = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
        Assert.AreEqual(52.5f, EnergyFieldSystem.MaxEnergyField(heights1), 1e-5);

        int[] heights2 = { 1, 1 };
        Assert.AreEqual(1.0f, EnergyFieldSystem.MaxEnergyField(heights2), 1e-5);

        int[] heights3 = { 10, 9, 8, 7, 6 };
        Assert.AreEqual(42.0f, EnergyFieldSystem.MaxEnergyField(heights3), 1e-5);
        
        int[] heights4 = { 5, 3, 9, 7, 4 };
        Assert.AreEqual(32.0f, EnergyFieldSystem.MaxEnergyField(heights4), 1e-5);

        int[] heights5 = { };
        Assert.AreEqual(0.0f, EnergyFieldSystem.MaxEnergyField(heights5), 1e-5);

        int[] heights6 = { 8 };
        Assert.AreEqual(0.0f, EnergyFieldSystem.MaxEnergyField(heights6), 1e-5);
    }
}