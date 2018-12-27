using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 功能说明：
/// 使用说明：
/// 1）使用LevelManager前先通过Init方法初始化关卡名列表
/// 2）调用Init方法时，提供List<string>
/// 3）关卡数量少时直接列出关卡名，需要简单多载入方案时，不同的顺序和组合方案分别存放在LevelList1/2/3中
/// 4）关卡数量多，需要更多顺序调整功能时，通过配置表初始化LevelNameList，然后使用该List执行Init方法
/// 5）待补充：使用配置表导入关卡列表（及不同组合方案）功能
/// </summary>
namespace JFramework
{
    public class LevelManager : MonoBehaviour
    {
        private static List<string> mLevelNames;//LevelList

        public static int Index { get; set; }//当前Level索引

        public static void Init(List<string> levelNames)
        {
            Index = 0;
            mLevelNames = levelNames;
        }

        public static void LoadCurrent()
        {
            SceneManager.LoadScene(mLevelNames[Index]);
        }

        public static void LoadNext()
        {
            Index++;
            if (Index >= mLevelNames.Count) Index = 0;
            SceneManager.LoadScene(mLevelNames[Index]);
        }
    }

}
