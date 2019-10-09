using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace myGame
{
    public class Ruler
    {
        public int[] score;
        public int side;
        public Ruler()
        {
            score = new int[10];
        }

        public void setDiskProperty(GameObject disk, int round)
        {

            disk.transform.position = this.setRandomInitPos(round);
            disk.GetComponent<Renderer>().material.color = setRandomColor();
            disk.transform.localScale = setScale(round);
            disk.GetComponent<Disk>().angle = setRandomAngle();
            disk.GetComponent<Disk>().power = setPower(round);
            disk.GetComponent<Disk>().color = disk.GetComponent<Renderer>().material.color;
        }

        public Vector3 setRandomInitPos(int level)
        {

            float jud = Random.Range(-0.5f, 0.5f);
            if (jud > 0) side = 1;
            else side = -1;
            float x = (-15 + Random.Range(-3f, 3f)) * side;
            float y = 3 + Random.Range(-0.5f, 0.5f) * (level * 0.2f + 1) ;
            float z = Random.Range(-1f, 1f)+ level*0.3f + 3;
            return new Vector3(x, y, z);
        }

        public Vector4 setRandomColor()
        {
            float jud = Random.Range(0f, 10f);

            if(jud < 1f){

            return Color.red;
            }
            if(jud >= 1f && jud < 3f){

            return Color.yellow;
            }
            if(jud >= 3f && jud < 6f){

            return Color.blue;
            }
            if(jud >= 6f){

            return Color.grey;
            }
            return new Vector4(0, 0, 0, 1);

        }

        public Vector3 setScale(int level)
        {
            float x = 3f - level * 0.2f;
            float y = 0.3f - level * 0.1f;
            if (y<0.1f) y = 0.1f;
            float z = 3f - level * 0.2f;
            return new Vector3(x, y, z);
        }

        public float setRandomAngle()
        {
            if (side > 0)
            return Random.Range(-10f, 10f);
            else return Random.Range(-170f, -190f);
        }

        public float setPower(int round)
        {
            return 2f + 1.5f * round;
        }

        public float setInterval(int round)
        {
            return (float)(2 - 0.2 * round);
        }

        public int getTargetThisRound(int round)
        {
            if (round != -1)
            {
                return 8 + round;
            }
            return 0;
        }

        public bool enterNextRound(int round)
        {
            if (round != -1 && this.score[round - 1] >= (5 + round > 10 ? 10 : 5 + round))
            {
                return true;
            }
            return false;
        }
    }
}
