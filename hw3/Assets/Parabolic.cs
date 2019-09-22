```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solar : MonoBehaviour
{
    public Transform Mercury;  //水星
    public Transform Venus;  //金星
    public Transform Earth;  //地球
    public Transform Mars;  //火星
    public Transform Jupiter;  //木星
    public Transform Saturn;  //土星
    public Transform Uranus;  //天王星
    public Transform Neptune;  //海王星

    // Start is called before the first frame update
    void Start()
    {
        Sun.position = new Vector3(0, 0, 0);
        Mercury.position = new Vector3(2, 0, 0);
        Venus.position = new Vector3(33, 0, 0);
        Earth.position = new Vector3(4, 0, 0);
        Mars.position = new Vector3(5, 0, 0);
        Jupiter.position = new Vector3(6, 0, 0);
        Saturn.position = new Vector3(7, 0, 0);
        Uranus.position = new Vector3(8, 0, 0);
        Neptune.position = new Vector3(9, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Mercury.RotateAround(Sun.position, new Vector3(0, 3, 1), 23 * Time.deltaTime);
        Venus.RotateAround(Sun.position, new Vector3(0, 2, 1), 17 * Time.deltaTime);
        Earth.RotateAround(Sun.position, new Vector3(0, 1, 0), 10 * Time.deltaTime);
        Mars.RotateAround(Sun.position, new Vector3(0, 13, 5), 9 * Time.deltaTime);
        Jupiter.RotateAround(Sun.position, new Vector3(0, 8, 3), 8 * Time.deltaTime);
        Saturn.RotateAround(Sun.position, new Vector3(0, 2, 1), 7 * Time.deltaTime);
        Uranus.RotateAround(Sun.position, new Vector3(0, 9, 1), 4 * Time.deltaTime);
        Neptune.RotateAround(Sun.position, new Vector3(0, 7, 1), 3 * Time.deltaTime);

        Venus.Rotate(new Vector3(0, 3, 1) * 25 * Time.deltaTime);
        Mercury.Rotate(new Vector3(0, 2, 1) * 20 * Time.deltaTime);
        Earth.Rotate(new Vector3(0, 1, 0) * 30 * Time.deltaTime);
        Mars.Rotate(new Vector3(0, 3, 2) * 20 * Time.deltaTime);
        Jupiter.Rotate(new Vector3(0, 2, 1) * 30 * Time.deltaTime);
        Saturn.Rotate(new Vector3(0, 4, 1) * 20 * Time.deltaTime);
        Uranus.Rotate(new Vector3(0, 7, 1) * 20 * Time.deltaTime);
        Neptune.Rotate(new Vector3(0, 3, 1) * 30 * Time.deltaTime);
    }

```