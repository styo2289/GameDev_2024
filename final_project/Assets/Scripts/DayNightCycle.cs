using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{

    //Event to send to monster spawner, indicates night time
    public delegate void NightEventHandler(int num);
    public event NightEventHandler OnEnterNightTime, OnExitNightTime;

    public delegate void DayTracker(int num);
    public event DayTracker OnNewDay;

    private const float TIME_CHECK_EPSILON = 0.1f;


    //Day and Night struct for the different marks in the array
    [System.Serializable]
    public struct DayNightMarkers
    {
        public float timeMarker;
        public Color color;
        public float intensity;
    }

    
    [SerializeField] DayNightMarkers[] markList; //array holding the day/night markers
    [SerializeField] float cycleLength = 24; //how long the cycle/day should last
    [SerializeField] Light2D light2D;

    private int currMarkIndex, nextMarkIndex; // indicies for the array
    private float currMarkTime, nextMarkTime; //what the actual time is within the array
    private  float currCycleTime; // tracks active cycle time
    private float markTimeDifference;

    private int dayTally;

    // Start is called before the first frame update
    void Start()
    {
        dayTally = 0;
        currMarkIndex = -1;
        MarkCycle();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float t = (currCycleTime - currMarkTime) / markTimeDifference;

        currCycleTime = (currCycleTime + Time.deltaTime) % cycleLength;

        DayNightMarkers curr = markList[currMarkIndex], next = markList[nextMarkIndex];

        //LERP to change from night to day
        light2D.color = Color.Lerp(curr.color, next.color, t);
        light2D.intensity = Mathf.Lerp(curr.intensity, next.intensity, t);

        if(Mathf.Abs(currCycleTime - nextMarkTime) < TIME_CHECK_EPSILON){
            
            light2D.color = next.color;
            light2D.intensity = next.intensity;

            MarkCycle();
        }
    }

    public void MarkCycle(){
        currMarkIndex = (currMarkIndex + 1) % markList.Length; //returns the index back to 0 when EOA 
        nextMarkIndex = (currMarkIndex + 1) % markList.Length; //ditto

        switch(currMarkIndex){
            case 0:
                OnNewDay?.Invoke(dayTally);
                dayTally++;
                break;
            case 2:
                OnEnterNightTime?.Invoke(currMarkIndex);
                break;
            default:
                OnExitNightTime?.Invoke(currMarkIndex);
                break;
        }

        currMarkTime = markList[currMarkIndex].timeMarker * cycleLength;
        nextMarkTime = markList[nextMarkIndex].timeMarker * cycleLength;

        markTimeDifference = nextMarkTime - currMarkTime;

        if(markTimeDifference < 0){
            markTimeDifference += cycleLength;
        }
    }
}





        // if(currMarkIndex == 0){
        //     dayTally++;
        //     OnNewDay?.Invoke(dayTally);
        // }

        // //when it reaches "night time" send it to the monster spawner 
        // if(currMarkIndex == 2){
        //     OnEnterNightTime?.Invoke(currMarkIndex);
        // } else {
        //     OnExitNightTime?.Invoke(currMarkIndex);
        // }
