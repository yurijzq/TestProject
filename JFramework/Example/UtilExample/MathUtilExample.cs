using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JFramework;

public class MathUtilExample : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(MathUtil.Percent(50));

        Debug.Log(MathUtil.GetRandomValueFrom(1, 2, 3));
        Debug.Log(MathUtil.GetRandomValueFrom("abc","fff","eee"));

    }

    // Update is called once per frame
    void Update () {
		
	}
}
