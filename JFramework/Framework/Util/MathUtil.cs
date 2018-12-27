using UnityEngine;

namespace JFramework
{
    public class MathUtil
    {
        /// <summary>
        /// 输入概率值返回是否命中
        /// </summary>
        /// <param name="percent"></param>
        /// <returns></returns>
        public static bool Percent(int percent)
        {
            return Random.Range(0, 100) <= percent;
        }

        /// <summary>
        /// 从给出的数组（任意类型和容量）中，随机返回一个
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static T GetRandomValueFrom<T>(params T[] values)
        {
            return values[Random.Range(0, values.Length)];
        }
        
    }
}

