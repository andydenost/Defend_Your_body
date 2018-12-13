using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathogenSpawner : MonoBehaviour {

    public int waveNum;
    public Wave[] waves;
    public Transform StartPoint;
    private List<Transform> targetList;
    public float interval;
    public bool isStart;
    // Use this for initialization
    void Start() {
        StartPoint = transform;
        waveNum = 0;
        //targetList = new List<Transform>();

    }

    // Update is called once per frame
    void Update() {
        if (isStart == true)
        {
            StartCoroutine(SpawnPathogen());
            isStart = false;
        }
    }

    IEnumerator SpawnPathogen()
    {
        foreach (Wave wave in waves)
        {
            waveNum++;
            targetList = new List<Transform>();

            foreach (Transform t in wave.routePoints)
            {
                targetList.Add(t);
            }
            Debug.Log(targetList);
            for (int i = 0; i<wave.count;i++)
            {

                GameObject go = Instantiate(wave.pathogenInfo.pathoPrefab, StartPoint.position, Quaternion.Euler(90f,90f,90f));
                go.GetComponent<PathogenScript>().HP = wave.pathogenInfo.HP;
                go.transform.localScale =(1 + (wave.pathogenInfo.HP/4)) * go.transform.localScale;
                go.GetComponent<PathogenScript>().targetlist = targetList;
                go.GetComponent<PathogenScript>().pathoSpeed = wave.speed;
                 yield return new WaitForSeconds(wave.rate);
            }
            yield return new WaitForSeconds(interval);

        }
    }
}
