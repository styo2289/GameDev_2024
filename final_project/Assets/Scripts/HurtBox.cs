using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    [SerializeField] Health health;
    
    public void Hurt(int damage){
        health.TakeDamage(damage);
    }
}
