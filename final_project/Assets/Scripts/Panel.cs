using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{

    [SerializeField] GameObject panel;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        if(panel != null){
            panel.gameObject.SetActive(false);
        }
        
        target = GameObject.FindGameObjectWithTag("Player");
    }


    void OnTriggerEnter2D(Collider2D other){
        if(target){
            panel.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        panel.gameObject.SetActive(false);
    }
}
