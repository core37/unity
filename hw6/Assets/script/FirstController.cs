using myspace;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, UserAction
{

    public int round;
    public int trial;
    public float interval;
    public int score;
    public UserGUI userGUI;

    private Queue<GameObject> disksQueue = new Queue<GameObject>();
    public Ruler ruler;
    public FirstActionManager actionManager;

    //public DiskFactory diskFactory;

    void Awake()
    {
        Director director = Director.GetInstance();
        director.currentSceneController = this;
        director.currentSceneController.loadResources();

        userGUI = gameObject.AddComponent<UserGUI>() as UserGUI;
        this.gameObject.AddComponent<DiskFactory>();
        actionManager = gameObject.AddComponent<FirstActionManager>() as FirstActionManager;
    }

    public void loadResources()
    {
        ruler = new Ruler();
    }

	// Use this for initialization
	void Start () {
        round = 1;
        interval = 0;
        trial = 0;
        getDisksForNextRound();
        userGUI.targetThisRound = ruler.getTargetThisRound(round);
    }

	// Update is called once per frame
	void Update () {
        if (ruler.enterNextRound(round))
        {
            round++;
            trial = 0;
            getDisksForNextRound();
            userGUI.score = this.score = 0;
            userGUI.targetThisRound = ruler.getTargetThisRound(round);
        }
        else if (!ruler.enterNextRound(round) && trial == 11)
        {
            round = -1;
        }

        if (this.round >= 1)
        {
            if (interval > ruler.setInterval(round))
            {
                if(trial < 10)
                {
                    throwDisk();
                    interval = 0;
                    trial++;
                }
                else if (trial == 10)
                {
                    trial++;
                }
            }
            else
            {
                interval += Time.deltaTime;
            }
        }

        userGUI.round = this.round;
	}

    public void throwDisk()
    {
        if (disksQueue.Count != 0)
        {
            GameObject disk = disksQueue.Dequeue();
            ruler.setDiskProperty(disk, round);
            disk.SetActive(true);
            actionManager.diskFly(disk, disk.GetComponent<Disk>().angle, disk.GetComponent<Disk>().power);
        }
    }

    public void getDisksForNextRound()
    {
        DiskFactory diskFactory = Singleton<DiskFactory>.Instance;
        int numDisk = 10;
        for (int i = 0; i < numDisk; i++)
        {
            GameObject disk = diskFactory.getDisk(round);
            disksQueue.Enqueue(disk);
        }
    }

    public void hit(Vector3 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];

            if (hit.collider.gameObject.GetComponent<Disk>() != null)
            {
                //Debug.Log("hit");
                int u= 0;
                hit.collider.gameObject.SetActive(false);
                if (hit.collider.gameObject.GetComponent<Disk>().color == Color.red) u = 4;
                if (hit.collider.gameObject.GetComponent<Disk>().color == Color.yellow) u = 3;
                if (hit.collider.gameObject.GetComponent<Disk>().color == Color.blue) u = 2;
                if (hit.collider.gameObject.GetComponent<Disk>().color == Color.gray) u = 1;

                userGUI.score += u;
                ruler.score[round - 1] += u;
            }
        }
    }

    public void restart()
    {
        Debug.Log("restart");
        round = 1;
        userGUI.round = 1;
        interval = 0;
        trial = 0;
        getDisksForNextRound();
        userGUI.targetThisRound = ruler.getTargetThisRound(round);
    }

}
