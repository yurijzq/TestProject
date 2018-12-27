using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JFramework
{
    public enum EnvironmentMode
    {
        Developing,//开发状态，不切换场景
        Test,
        Production//产品状态，经过Home场景后，会按照逻辑切入Game场景
    }
    /// <summary>
    /// 入口管理，根据当前处在开发，测试，产品阶段来控制是否进行“资源载入，SDK激活，场景切换等功能”
    /// </summary>
    public abstract class MainManager : MonoBehaviour
    {
        public EnvironmentMode Mode;

        private static EnvironmentMode mSharedMode;
        private static bool mModeSetted = false;

        void Start()
        {
            if (!mModeSetted)//bool锁，控制mSharedMode变量只被赋值一次，Home场景中挂在的子类HomeModule对其赋值一次后，后续场景Game中子类GameModule不能再更改其值而是延续之前的赋值
            {
                mSharedMode = Mode;
                mModeSetted = true;
            }
            switch (mSharedMode)
            {
                case EnvironmentMode.Developing:
                    LaunchInDevelopingMode();
                    break;
                case EnvironmentMode.Test:
                    LaunchInTestMode();
                    break;
                case EnvironmentMode.Production:
                    LaunchInProductionMode();
                    break;
                default:
                    break;
            }
        }
        //子类必须实现三个方法来制定在不通开发阶段，场景的入口执行内容（是否加载某些资源，是否场景切换）
        protected abstract void LaunchInDevelopingMode();
        protected abstract void LaunchInTestMode();
        protected abstract void LaunchInProductionMode();


    }

}
