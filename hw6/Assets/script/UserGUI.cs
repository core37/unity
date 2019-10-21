using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using myspace;

namespace myspace
{
    public class UserGUI : MonoBehaviour
    {
        private UserAction action;
        public int round = 0;
        public int score = 0;
        public int targetThisRound = 0;

        // Use this for initialization
        void Start()
        {
            action = Director.GetInstance().currentSceneController as UserAction;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                //Debug.Log("Fire1");
                Vector3 pos = Input.mousePosition;
                action.hit(pos);
            }
        }

        // Update is called once per frame
        void OnGUI()
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 40, 360, 80, 35), "Reset"))
                action.restart();
            GUI.Label(new Rect(Screen.width / 4 * 3, 50, 180, 50), "score:" + score.ToString());
            GUI.Label(new Rect(Screen.width / 4 , 10, 300, 100), "Introduction:\nRed:4pt\nYellow:3pt\nBule:2pt\nGray:1pt");
            GUI.Label(new Rect(Screen.width / 4 * 3, 30, 180, 50), "target:" + targetThisRound.ToString());
            if (round != -1)
                GUI.Label(new Rect(Screen.width / 4 * 3, 10, 100, 50), "Round:" + round.ToString());
            else if (round == -1)
                GUI.Label(new Rect(Screen.width / 4 * 3, 10, 100, 50), "Lose!");

        }

    }
}

