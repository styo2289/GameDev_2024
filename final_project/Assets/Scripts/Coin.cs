using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int count;
    [SerializeField] AudioClip clip;
    
    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            AudioSource.PlayClipAtPoint(clip, transform.position);
            Destroy(gameObject);

            count++;
            CoinCounterText.instance.UpdateCoinText(count);
            
        }
    }
}
