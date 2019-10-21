using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace myspace
{
    public class DiskFactory : MonoBehaviour
    {
        public GameObject diskPrefab;

        private List<GameObject> usingDisks = new List<GameObject>();   //正在使用
        private List<GameObject> freeDisks = new List<GameObject>();     //使用过已被释放的，可以重复使用

        int nameIndex;

        private void Awake()
        {
            diskPrefab = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/disk"), Vector3.zero, Quaternion.identity);
            diskPrefab.name = "prefab";
            diskPrefab.SetActive(false);
            nameIndex = 0;
        }

        public GameObject getDisk(int round)
        {
            GameObject newDisk = null;
            if (freeDisks.Count > 0)
            {
                newDisk = freeDisks[0].gameObject;
                freeDisks.Remove(freeDisks[0]);
            }
            else
            {
                newDisk = GameObject.Instantiate<GameObject>(diskPrefab, Vector3.zero, Quaternion.identity);
                newDisk.AddComponent<Disk>();
                newDisk.name = nameIndex.ToString();
                nameIndex++;
            }
            return newDisk;
        }

        public void freeDisk(GameObject usedDisk)
        {
           if(usedDisk != null)
           {
                usedDisk.SetActive(false);
                usingDisks.Remove(usedDisk);
                freeDisks.Add(usedDisk);
           }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
