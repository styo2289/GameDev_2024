using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayableCharacter : MonoBehaviour
{
    [SerializeField] float speed =  5.0f;
    [SerializeField] UI_Handler buttonHandler;

    private Rigidbody2D rigidbod;
    private SpriteRenderer spriteRenderer;
    private Health health;

    private List<int> coinList;

    void Awake(){
        rigidbod = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
        coinList = new List<int>();

        buttonHandler.OnHealthClick += IncreaseHealth;
        buttonHandler.OnSpeedClick += IncreaseSpeed;

    }


    // Update is called once per frame
    void Update()
    {
        if(health.GetCurrentHealth() < 1){
            Die();
        }
    }


    public void Move(Vector3 input){
        input *= speed;

        // flips sprite image
        if(input.x > 0){
            transform.localScale = new Vector3(-1,1,0);
        }
        if(input.x < 0){
            transform.localScale = new Vector3(1,1,0);
        }

        //moves the character based off the input velocity settings
        rigidbod.velocity = input;
        
    }

    private void Die(){
        SceneManager.LoadScene("Menu");
    }

    //--------------------

    public void SetPlayerSpeed(float newSpeed){
        speed = newSpeed;
    }

    public float GetPlayerSpeed(){
        return speed;
    }

    //--------------------

    public void SetPlayerCurrentHealth(int newHealth){
        health.SetCurrentHealth(newHealth);
    }

    public int GetPlayerCurrentHealth(){
        return health.GetCurrentHealth();
    }

    public void SetPlayerMaxHealth(int newHealth){
        health.SetMaxHealth(newHealth);
    }

    public int GetPlayerMaxHealth(){
        return health.GetMaxHealth();
    }

    //--------------------

    private void IncreaseHealth(int e){
        SetPlayerMaxHealth(GetPlayerMaxHealth() + e);
        SetPlayerCurrentHealth(GetPlayerMaxHealth());
    }

    private void IncreaseSpeed(int e){
        SetPlayerSpeed(GetPlayerSpeed() + e);
    }

}
