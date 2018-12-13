using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {//should be a singleton

    public GameObject pathogenSpawnerA;
    public GameObject pathogenSpawnerB;
    bool hasStartB;
    bool hasStartA;
    int waveALength;

    // Use this for initialization
    void Start () {
        pathogenSpawnerA.GetComponent<PathogenSpawner>().isStart = false;
        pathogenSpawnerB.GetComponent<PathogenSpawner>().isStart = false;
        hasStartB = false;
        hasStartA = false;

        waveALength = pathogenSpawnerA.GetComponent<PathogenSpawner>().waves.Length;
    }

    // Update is called once per frame
    void Update () {
        if (GameManager.GM.isGameStart == true && hasStartA == false)
        {
            pathogenSpawnerA.GetComponent<PathogenSpawner>().isStart = true;
            hasStartA = true;
        }

        if (pathogenSpawnerA.GetComponent<PathogenSpawner>().waveNum == waveALength && GameManager.GM.livePathoNum == 0 && hasStartB == false)
        {
            
            Invoke("StartSpawnerB", 10);
            hasStartB = true;
        }
    }

    void StartSpawnerB()
    {
        Debug.Log("come on");
        pathogenSpawnerB.GetComponent<PathogenSpawner>().isStart = true;
    }
}
