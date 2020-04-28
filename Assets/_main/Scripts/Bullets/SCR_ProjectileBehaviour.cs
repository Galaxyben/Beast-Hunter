using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ProjectileBehaviour : MonoBehaviour
{
    public Projectile projectile;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject, 0.05f);
    }
}
