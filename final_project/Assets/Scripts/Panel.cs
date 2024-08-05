using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{

    [SerializeField] GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        if(panel != null){
            panel.gameObject.SetActive(false);
        }
        
    }


    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            panel.gameObject.SetActive(true);
            PauseGame();
        }
    }

    // void OnTriggerExit2D(Collider2D other){
    //     panel.gameObject.SetActive(false);
    // }

    void PauseGame(){
        Time.timeScale = 0;
    }
}
