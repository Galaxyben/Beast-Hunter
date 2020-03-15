using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public GameObject echo;
    
    void Update()
    {
        if(timeBtwSpawns <= 0)
        {
            GameObject go = Instantiate(echo, PlayerStats.playerStats.playerSprite.transform.position, Quaternion.identity);
            Destroy(go, 0.5f);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
