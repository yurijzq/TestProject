using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JFramework;

public class GUIExample : MonoBehaviour {

    private void Start()
    {
        GUIManager.SetResolution(1280, 720, 0);
        GUIManager.LoadPanel("HomePanel", UILayer.Top);
        //GUIManager.UnLoadPanel("HomePanel");
    }

}
