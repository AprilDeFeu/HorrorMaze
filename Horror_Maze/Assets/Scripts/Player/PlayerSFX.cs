using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    GameObject walk;
    GameObject run;
    float speed;
    bool isRun;
    bool isWalk;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        walk = transform.GetChild(0).gameObject;
        run = transform.GetChild(1).gameObject;

        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        isWalk = player.GetComponent<Movement>().isWalking;
        speed = player.GetComponent<Movement>().speed;
        if (isWalk && speed == 5f)  
        {
            walk.SetActive(true);
        }
        else walk.SetActive(false);

        if (isWalk && speed > 5f)  
        {
            walk.SetActive(false);
            run.SetActive(true);
        }
        else run.SetActive(false);
    }
}
