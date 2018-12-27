using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JFramework;

namespace Game {
    public class HomeModule : MainManager
    {

        protected override void LaunchInDevelopingMode()
        {
            //开发逻辑    
            //开发模式下不载入下一个场景
        }
        protected override void LaunchInTestMode()
        {
            //测试逻辑
            //加载资源
            //初始化SDK
            //点击开始
            GameModule.LoadModule();//在测试和产品模式下，载入Game场景
    }

        protected override void LaunchInProductionMode()
        {
            //生产逻辑
            //加载资源
            //初始化SDK
            //点击开始
            GameModule.LoadModule();
        }

    }
}
