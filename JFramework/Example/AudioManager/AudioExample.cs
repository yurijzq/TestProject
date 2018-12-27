using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JFramework;
/// <summary>
/// AudioManager的使用者直接通过单例调用即可，无需再场景中创建挂在AudioManager的物体
/// GameManager物体将在AudioManager首次被调用时创建，并始终保留在场景中，而无需手动创建该物体
/// </summary>
public class AudioExample : MonoBehaviour
{
   
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            AudioManager.Instance.PlaySound("coin");
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            AudioManager.Instance.PlayMusic("BGM");
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            AudioManager.Instance.StopMusic();
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            AudioManager.Instance.PauseMusic();
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            AudioManager.Instance.ResumeMusic();
        }
    }
}
