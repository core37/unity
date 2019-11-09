using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partscript : MonoBehaviour {

    public float Revs;
    public float exhaustRate;

    ParticleSystem exhaust;


    void Start () {
        exhaust = GetComponent<ParticleSystem>();
    }


    void Update () {
        exhaust.emissionRate = Revs * exhaustRate;
        Revs = Revs+1;
    }
}
