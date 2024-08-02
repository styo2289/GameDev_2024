using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] int damage = 1;

    bool disabled = false;

    private float coolDown;

    public void Update(){
        if(coolDown > 0){
            coolDown -= Time.deltaTime;
        }
    }

    public void DisableHitBox(){
        disabled = true;
    }

    void OnTriggerStay2D(Collider2D other){
        if(disabled){
            return;
        }

        if(coolDown <= 0 && other.GetComponent<HurtBox>() != null){
            coolDown = 0.25f;
            other.GetComponent<HurtBox>().Hurt(damage);
        }
    }
}
