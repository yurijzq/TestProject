using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JFramework;

public class LevelExample : MonoBehaviour {

	void Start ()
    {
        LevelManager.Init(new List<string>
        {
            "Home","Game"
        });

        //LevelManager.LoadCurrent();
        LevelManager.LoadNext();
	}
	
	void Update () {
		
	}
}
