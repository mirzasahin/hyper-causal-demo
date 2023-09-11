using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    PlayerStackController playerStackController;
    CubeController cubeController;
    public bool isLive = true;
    // Start is called before the first frame update
    void Start()
    {
        playerStackController = GameObject.FindObjectOfType<PlayerStackController>();
        cubeController = GameObject.FindObjectOfType<CubeController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerLifeControl();
    }

    public void PlayerLifeControl()
    {
        Debug.Log(playerStackController.blockList.Count);
        if(playerStackController.blockList.Count == 1 && cubeController.touchedObstacle)
        {
            isLive = false;
            Debug.Log(isLive);
        }
        else
        {
            isLive = true;
        }
    }
}
