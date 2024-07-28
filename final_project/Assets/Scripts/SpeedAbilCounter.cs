using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedAbilCounter : MonoBehaviour
{
    [SerializeField] UI_Handler uI_Handler;
    [SerializeField] TextMeshProUGUI counterText;

    // Start is called before the first frame update
    void Start()
    {
        uI_Handler.OnSpeedUpdate += UpdateCountText;
    }

    public void UpdateCountText(int e){
        string numText = e.ToString();
        counterText.text = numText + " / 2";
    }
}
