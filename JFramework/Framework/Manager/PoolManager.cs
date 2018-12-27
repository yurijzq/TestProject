using System;
using System.Collections.Generic;
/// <summary>
/// 功能说明：对象池 架构与对GO的创建、重置具体实现过程分离，构造对象池时需传入实现GO创建和重置的具体实现方法
/// 使用说明：
/// 1）使用pool创建对象前需要先构造对象池
/// 2）构造对象池时，需要提供创建GO的实现方法，提供GO的Reset方法（可以为null），制定对象池初始大小（会预先创建出这么多实例出来）
/// 3）构造对象池pool后，使用pool.Allocate()获取一个实例go，使用pool.Recycle(go)来回收实例，回收过程会自动调用指定的Reset(GameObject)方法
/// </summary>
namespace JFramework
{
    public interface IObjectFactory<T>
    {
        T Create();
    }

    public class CustomObjectFactory<T> : IObjectFactory<T>
    {
        private Func<T> mFactoryMethod;

        public CustomObjectFactory(Func<T> factoryMethod)//构造工厂时，需传入一个创建对象的方法，该方法由使用者自行实现
        {
            mFactoryMethod = factoryMethod;
        }

        public T Create() { return mFactoryMethod(); }  //通过传入的创建对象方法来实现Create方法，对象创建过程的实现与对象池架构分离
    }

    public interface IPool<T>
    {
        T Allocate();
        bool Recycle(T obj);
    }

    public abstract class Pool<T> : IPool<T>
    {
        public int CurCount { get { return mCacheStack.Count; } }//用来监控当前池中对象个数

        protected Stack<T> mCacheStack = new Stack<T>();
        protected int mMaxCount = 5;

        protected IObjectFactory<T> mFactory;

        public virtual T Allocate()
        {
            return mCacheStack.Count == 0 ? mFactory.Create() : mCacheStack.Pop();
        }

        public abstract bool Recycle(T obj);
    }

    public class SimpleObjectPool<T> : Pool<T>
    {
        readonly Action<T> mResetMethod;//GO入池前重置状态（位置，速度，显隐，组件等）

        //构造对象池：给出创建方法，通过创建方法构造工厂；给出GO重置方法，用于物体入池前重置状态；给出初始容量，然后初始化Stack(使用工厂创建一些对象待用)
        public SimpleObjectPool(Func<T> factoryMethod, Action<T> resetMethod = null, int initCount = 0)
        {
            mFactory = new CustomObjectFactory<T>(factoryMethod);
            mResetMethod = resetMethod;

            for (var i = 0; i < initCount; i++)
            {
                mCacheStack.Push(mFactory.Create());
            }
        }

        public override bool Recycle(T obj)
        {
            if (mResetMethod != null) mResetMethod(obj);
            mCacheStack.Push(obj);//对象入栈，进行回收
            return true;
        }

       

    }



}

