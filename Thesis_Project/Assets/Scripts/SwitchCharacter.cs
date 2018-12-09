using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour {

    public GameObject[] player;
    public Camera characterCamera;
    [SerializeField]
    public int CharcaterCount = 0;

    void Start()
    {
        for (int i=0;i<3;i++)
        {

            player[i].SetActive(false);
 
            player[i].transform.SetParent(this.transform);

            player[i].transform.position = this.transform.position;

        }


    }

    void Update()
    {
        ChangeCharacter();
    }

    void ChangeCharacter()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CharcaterCount++;
            if (CharcaterCount >= player.Length)
            {
                CharcaterCount = 0;
            }
        }

        switch (CharcaterCount)
        {
            case 0:
                {
                  
                    player[0].SetActive(true);
                    player[1].SetActive(false);
                    player[2].SetActive(false);
                    characterCamera.transform.localPosition = new Vector3(0f,0.6f,-2f);
                }
                break;
            case 1:
                {
                    
                    player[0].SetActive(false);
                    player[1].SetActive(true);
                    player[2].SetActive(false);
                    characterCamera.transform.localPosition = new Vector3(0f, 0.6f, -2f);

                }
                break;
            case 2:
                {
                    
                    player[0].SetActive(false);
                    player[1].SetActive(false);
                    player[2].SetActive(true);
                    characterCamera.transform.localPosition = new Vector3(0f, 1.2f, -4f);

                }
                break;

            default:
                break;
        }
        
    }
}
