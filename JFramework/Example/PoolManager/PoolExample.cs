using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 使用PoolManager框架，实现简单对象池
/// 使用说明：
/// 1）构造对象池时需要提供创建GO的实现方法，提供GO的Reset方法（可以为null），制定对象池初始大小（会预先创建出这么多实例出来）
/// 2）构造 对象池对象后pool，使用pool.Allocate()获取一个实例go，使用pool.Recycle(go)来回收实例，回收过程会自动调用指定的Reset(GameObject)方法
/// </summary>
namespace JFramework
{
    public class PoolExample : MonoBehaviour
    {
        public GameObject fish;
        private SimpleObjectPool<GameObject> fishPool;
        void Start()
        {
            fishPool = new SimpleObjectPool<GameObject>(SpawnFish, ResetFish, 20);

            var fishOne = fishPool.Allocate();
            Debug.Log("fishPoolCount:" + fishPool.CurCount);

            fishPool.Recycle(fishOne);
            Debug.Log("fishPoolCount:" + fishPool.CurCount);

            for(int i = 0; i < 10; i++)
            {
                fishPool.Allocate();                
            }
            Debug.Log("fishPoolCount:" + fishPool.CurCount);

        }

        private GameObject SpawnFish()//创建对象池时，需给出创建GO的方法实现
        {
            return Instantiate(fish);
        }

        private void ResetFish(GameObject fish)
        {
            fish.transform.position = Vector3.one;
        }

    }
}