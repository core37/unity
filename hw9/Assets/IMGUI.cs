using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IMGUI : MonoBehaviour {
	private float hSliderValue = 75f;
    private void OnGUI()
    {
        Vector3 worldPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector2 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        hSliderValue = GUI.HorizontalSlider (new Rect(screenPos.x -50,screenPos.y,100,100), hSliderValue, 0.0f, 100.0f);
    }
}
