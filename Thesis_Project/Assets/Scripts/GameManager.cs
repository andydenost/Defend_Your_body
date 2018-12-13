using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {//should be a singleton

    // public GameObject player;
    //
    // Use this for initialization

    public static GameManager GM { get; private set; }



    public bool isGameStart;
    public int livePathoNum;

    private void Awake()
    {
        if (GM == null)
        {
            GM = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start () {
        //Vector3 startPoint = new Vector3(0, 1, 0);
        //Instantiate(player, startPoint, Quaternion.identity);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isGameStart = true;

        
    }

    // Update is called once per frame
    void Update () {
       

        
    }
}
