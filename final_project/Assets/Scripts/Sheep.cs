using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    [SerializeField] UI_Handler buttonHandler;

    private Health health;
    private FollowTarget followTarget;
    

    void Awake(){
        health = GetComponent<Health>();
        followTarget = GetComponent<FollowTarget>();

        buttonHandler.OnSheepHealthClick += IncreaseHealth;
        buttonHandler.OnSpeedClick += IncreaseSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health.GetCurrentHealth() < 1){
            Die();
        }
    }

    private void Die(){
        Destroy(gameObject);
    }

    //--------------------

    public void SetSheepSpeed(float newSpeed){
        followTarget.SetSpeed(newSpeed);
    }

    public float GetSheepSpeed(){
        return followTarget.GetSpeed();
    }

    //--------------------

    public void SetSheepCurrentHealth(int newHealth){
        health.SetCurrentHealth(newHealth);
    }

    public int GetSheepCurrentHealth(){
        return health.GetCurrentHealth();
    }


    public void SetSheepMaxHealth(int newHealth){
        health.SetMaxHealth(newHealth);
    }

    public int GetSheepMaxHealth(){
        return health.GetMaxHealth();
    }

    //--------------------

    private void IncreaseHealth(int e){
        SetSheepMaxHealth(GetSheepMaxHealth() + e);
        SetSheepCurrentHealth(GetSheepMaxHealth());
    }

    private void IncreaseSpeed(int e){
        SetSheepSpeed(GetSheepSpeed() + e);
    }
}
