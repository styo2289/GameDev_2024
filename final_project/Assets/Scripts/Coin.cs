using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public delegate void CoinHandler(int num);
    public event CoinHandler OnCoinPickup;
    private int coins = 0;

    [SerializeField] AudioClip clip;
    public void OnTriggerEnter2D(Collider2D other){
        AudioSource.PlayClipAtPoint(clip, transform.position);
        Destroy(gameObject);
        coins++;

        OnCoinPickup?.Invoke(coins);
    }
}
