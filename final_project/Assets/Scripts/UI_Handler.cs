using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Handler : MonoBehaviour
{
    public delegate void UIButtonHandler(int num);
    public event UIButtonHandler OnHealthClick, OnSpeedClick, OnSheepHealthClick,
    OnHealthUpdate, OnSpeedUpdate, OnSheepUpdate;
    
    private int healthCounter = 0, speedCounter = 0, sheepCounter = 0;
    private bool selected = false;
    private AudioSource audioSource;

    public void Start(){
        audioSource = GetComponent<AudioSource>();
    }
    
    public void IncreaseHealth(){
        if(!selected && healthCounter < 2){
            OnHealthClick?.Invoke(2);
            audioSource.Play();

            Debug.Log("CLICK");
            healthCounter++;
            OnHealthUpdate?.Invoke(healthCounter);

            selected = true;
        }
    }

    public void IncreaseSpeed(){
        if(!selected && speedCounter < 2){
            OnSpeedClick?.Invoke(2);
            audioSource.Play();

            Debug.Log("CLICK");
            speedCounter++;
            OnSpeedUpdate?.Invoke(speedCounter);

            selected = true;
        }
    }

    public void IncreaseSheepHealth(){
        if(!selected && sheepCounter < 2){
            OnSheepHealthClick?.Invoke(2);
            audioSource.Play();

            Debug.Log("CLICK");
            sheepCounter++;
            OnSheepUpdate?.Invoke(sheepCounter);

            selected = true;
        }
    }

    public void ClosePanel(){
        selected = false;
        gameObject.SetActive(false);
        ResumeGame();
        Debug.Log("CLICK");
    }

    void ResumeGame(){
        Time.timeScale = 1;
    }
}
