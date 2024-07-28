using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    [SerializeField] Health health;
    
    public void Hurt(int damage){
        Debug.Log("HURT BOX - take damage");
        health.TakeDamage(damage);
    }
}
