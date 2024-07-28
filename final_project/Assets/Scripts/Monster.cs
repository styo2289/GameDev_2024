using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    private Health health;

    void Awake(){
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.GetCurrentHealth() < 1){
            Die();
        }
    }

    private void Die(){
        //GetComponent<SpriteRenderer>().color = Color.red; 
        Destroy(gameObject);
    }
}
