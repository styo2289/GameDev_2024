using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NightText : MonoBehaviour
{
    [SerializeField] DayNightCycle dayNightCycle;
    [SerializeField] TextMeshProUGUI counterText;

    // Start is called before the first frame update
    void Start()
    {
        dayNightCycle.OnNewDay += UpdateNightText;
    }

    public void UpdateNightText(int e){
        string numText = e.ToString();
        counterText.text = numText + " / 4";
    }
}
