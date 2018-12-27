using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 功能说明：
/// 1）该类在MonoBehaivour类的基础上，对一些常用的功能实现进行了封装，比如开启协程功能，切换物体显隐功能等
/// 2）对这些功能进行了分类，GameObjectSimplify,TransformSimlify，其具体实现分别在对应的类中，Timer作为一个单独功能直接在这里实现
/// 3）搭建了消息机制
/// 使用说明：
/// 1) 新建类继承MonoBehaviourSimplify，同时便自动继承了MonoBehaviour
/// 2）开启协程功能：直接使用Delay方法开启携程，传递延迟秒数和onFinish方法
/// </summary>
namespace JFramework
{
    public abstract partial class MonoBehaviourSimplify : MonoBehaviour //使用Partial修饰的类，可以在多个partial calss MonoBehaivourSimplify定义中补充追加功能
    {
        //#region GameObjectSimplify
        ////因为GameObject相关的简化方法可能会比较多，所以具体功能实现放在GameObjectSimplify类中实现
        //public void Show()
        //{
        //    GameObjectSimplify.Show(gameObject);  
        //}
        //#endregion

        //#region TransformSimplify
        ////因为GameObject相关的简化方法可能会比较多，所以具体功能实现放在GameObjectSimplify类中实现
        //public void Show()
        //{
        //    GameObjectSimplify.Show(gameObject);
        //}
        //#endregion

        #region Timer
        //因为Timer难以归类，暂时放在此类中直接实现
        public void Delay(float seconds,Action onFinished)
        {
            StartCoroutine(DelayCoroutine(seconds, onFinished));
        }

        private static IEnumerator DelayCoroutine(float seconds, Action onFinished)
        {
            yield return new WaitForSeconds(seconds);
            onFinished();
        }

        #endregion

    }

}
