using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class t1 : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject cube;
    public VirtualButtonBehaviour[] VRbehaviours;

    void Start()
    {
        VRbehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();
        VRbehaviours[1].RegisterEventHandler(this);
        VRbehaviours[0].RegisterEventHandler(this);

        cube = GameObject.Find("Cube");
    }

    void Update()
    {

    }

    void IVirtualButtonEventHandler.OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("catch");
        cube.transform.position += new Vector3(-0.1f, 0, 0);

    }

    void IVirtualButtonEventHandler.OnButtonReleased(VirtualButtonBehaviour vb)
    {

    }
}