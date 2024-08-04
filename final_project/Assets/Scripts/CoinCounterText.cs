using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class CoinCounterText : MonoBehaviour
{
    public static CoinCounterText instance;

    [SerializeField] TextMeshProUGUI coinText;
    private int coinCount = 0;

    void Awake(){
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        UpdateCoinText(0);
    }

    // Update is called once per frame
    public void UpdateCoinText(int e){
        Debug.Log(e);
        coinCount += e;
        coinText.text = coinCount.ToString() + " / 6";

        if(coinCount == 6){
            EndGame();
        }
    }

    public void EndGame(){
        SceneManager.LoadScene("End");
    }
}
