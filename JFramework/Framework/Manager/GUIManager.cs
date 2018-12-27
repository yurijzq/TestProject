using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 使用说明：
/// 1）Panel需要以Prefab存放在Resources文件夹下
/// 2）直接通过GUIManager.LoadPanel(panelName)方法加载面板到自动生成的UIRoot(canvas)下指定的层级中
/// 3）通过UnLoad(panelName)方法销毁指定面板
/// 4）通脱SetResolution方法调整Canvas分辨率和横竖屏适应方式(0-横屏，1-竖屏)
/// </summary>
namespace JFramework
{
    public enum UILayer { Bg,Common,Top }

    public class GUIManager : MonoBehaviour
    {
        //使用字典管理所有已加载的Panel
        private static Dictionary<string, GameObject> mPanelsDict = new Dictionary<string, GameObject>();

        //调用loadPanel加载面板时，自动创建名为UIRoot的Canvas到场景中，该Canvas包含了Bg/Common/Top三个层级
        private static GameObject mPrivateUIRoot;
        public static GameObject UIRoot
        {
            get
            {
                if (mPrivateUIRoot == null)
                {
                    var uirootPrefab = Resources.Load<GameObject>("UIRoot");
                    mPrivateUIRoot = Instantiate(uirootPrefab);
                    mPrivateUIRoot.name = "UIRoot";
                }
                return mPrivateUIRoot;
            }
        }
        
        /// <summary>
        /// 加载Panel的方法，首次调用时会创建UIRoot(Canvas)，然后将加载的UI放置到指定的层中来管理叠放次序
        /// </summary>
        /// <param name="panelName"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static GameObject LoadPanel(string panelName,UILayer layer)
        {
            var panelPrefab = Resources.Load<GameObject>(panelName);
            var panel = Instantiate(panelPrefab);
            panel.name = panelName;
            mPanelsDict.Add(panel.name, panel);

            switch (layer)
            {
                case UILayer.Bg:
                    panel.transform.SetParent(UIRoot.transform.Find("Bg"));
                    break;
                case UILayer.Common:
                    panel.transform.SetParent(UIRoot.transform.Find("Common"));
                    break;
                case UILayer.Top:
                    panel.transform.SetParent(UIRoot.transform.Find("Top"));
                    break;
                default:
                    break;
            }

            var panelRectTrans = panel.transform as RectTransform; //将指定Panel放置到目标层级物体下后，设置其对其方式为中心全屏

            panelRectTrans.offsetMin = Vector2.zero;
            panelRectTrans.offsetMax = Vector2.zero;
            panelRectTrans.anchoredPosition3D = Vector3.zero;
            panelRectTrans.anchorMin = Vector2.zero;
            panelRectTrans.anchorMax = Vector2.one;//注意这里不是zero
           

            return panel;
        }
        /// <summary>
        /// 通过面板名称销毁面板对象
        /// </summary>
        /// <param name="panelName"></param>
        public static void UnLoadPanel(string panelName)
        {
            if (mPanelsDict.ContainsKey(panelName))
            {
                Destroy(mPanelsDict[panelName]);
            }
        }

        /// <summary>
        /// 调整Canvas分辨率及相关参数的方法
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="matchWidthOrHeight"></param>
        public static void SetResolution(float width,float height,float matchWidthOrHeight)
        {
            var canvasScaler = UIRoot.GetComponent<CanvasScaler>();
            canvasScaler.referenceResolution = new Vector2(width, height);
            canvasScaler.matchWidthOrHeight = matchWidthOrHeight;

        }
        
    }
}

