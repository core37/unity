using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Patrols;

//----------------------------------
// 此脚本加在主人公hero上
//----------------------------------

public class HeroStatus : MonoBehaviour {
    public int standOnArea = -1;

	void Start () {

	}

	void Update () {
        modifyStandOnArea();
	}

    //检测所在区域
    void modifyStandOnArea() {
    float posX = this.gameObject.transform.position.x;
    float posZ = this.gameObject.transform.position.z;
        if (posX <= 0) {
            if (posZ < 0)
                standOnArea = 0;
            else
                standOnArea = 1;
        }
        else {
            if (posZ < 0)
                standOnArea = 2;
            else
                standOnArea = 3;
        }
    }
}
