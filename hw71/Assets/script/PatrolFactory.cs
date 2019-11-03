using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Patrols;

namespace Com.Patrols {
    public class PatrolFactory : System.Object {
        private static PatrolFactory instance;
        private GameObject PatrolItem;

        private Vector3[] PatrolPosSet = new Vector3[] {
            new Vector3(-5f, 0.2f, -5f),
            new Vector3(-5f, 0.2f, 5f),
            new Vector3(5f, 0.2f, -5f),
            new Vector3(5f, 0.2f, 5f)};

        public static PatrolFactory getInstance() {
            if (instance == null)
                instance = new PatrolFactory();
            return instance;
        }

        public void initItem(GameObject _PatrolItem) {
            PatrolItem = _PatrolItem;
        }

        public GameObject getPatrol() {
            GameObject newPatrol = Camera.Instantiate(PatrolItem);
            return newPatrol;
        }

        public Vector3[] getPosSet() {
            return PatrolPosSet;
        }
    }
}

