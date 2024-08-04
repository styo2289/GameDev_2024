using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    void Start(){
        
    }

    public void Aim(Vector3 targetPosition){
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPosition - transform.position);

        // if(targetPosition.x < gameObject.transform.position.x){
        //     transform.localScale = new Vector3(1,1,0);
        // }
        // if(targetPosition.x > gameObject.transform.position.x){
        //     transform.localScale = new Vector3(-1,1,0);
        // }
    }
}
