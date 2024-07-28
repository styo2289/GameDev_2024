using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private Transform target;
    private SpriteRenderer sprite;
    [SerializeField] string gameObjectTag;
    [SerializeField] float distanceFromTarget = 2.0f;
    [SerializeField] float speed = 2.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag(gameObjectTag).GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target == null){
            UpdateTarget();
            Follow();
        }//if object is certain distance from target, follow, otherwise stop. (maintains distance)
        else if(Vector3.Distance(transform.position, target.position) > distanceFromTarget){
            Follow();
        }


        if(target.position.x < gameObject.transform.position.x){
            sprite.flipX = false;
        }
        if(target.position.x > gameObject.transform.position.x){
            sprite.flipX = true;
        }
        
    }

    public void SetSpeed(float newSpeed){
        speed = newSpeed;
    }

    public float GetSpeed(){
        return speed;
    }

    public void UpdateTarget(){
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void Follow(){
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
    }
}
