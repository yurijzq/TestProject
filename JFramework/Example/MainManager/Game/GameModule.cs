using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JFramework;
using UnityEngine.SceneManagement;

namespace Game {
    public class GameModule : MainManager
    {
        //对外提供载入当前场景的静态方法
        public static void LoadModule()
        {
            SceneManager.LoadScene("Game");
        }
        protected override void LaunchInDevelopingMode()
        {
            //开发逻辑
            //加载资源
            //初始化SDK
            //Game准备（初始化角色，准备些假数据）
            Debug.Log("开发逻辑");
        }

        protected override void LaunchInTestMode()
        {
            //正常的 测试逻辑
            Debug.Log("测试逻辑");
        }

        protected override void LaunchInProductionMode()
        {
            //正常的 产品逻辑
            Debug.Log("产品逻辑");
        }
    }
}
