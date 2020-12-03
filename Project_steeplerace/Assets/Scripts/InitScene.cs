using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitScene : MonoBehaviour
{
    public Text distanceText, speedText, timeText, resultText, weatherText, trackText, moveText;
    public AudioSource stone;
    public GameObject player;
    public static bool oneTime = true;
    private int limit_time, trackLength, track;
    private int timerCount = 0;
    private float distance, z;
    void Start()
    {
        limit_time = 500;
        trackLength = 500;
        distance = trackLength * 4;
    }

    void FixedUpdate()
    {
        if(oneTime){
            if(distance <= 0){
                resultText.text = "Game Clear";
                oneTime = !oneTime;
            }
            else if(limit_time == ++timerCount/50){
                resultText.text = "Game Over";
                timeText.text = "Time : 0s";
                oneTime = !oneTime;
            }
            else{
                if(PlayerCollision.notMove != 0 && timerCount % 50 == 0)
                    PlayerCollision.notMove --;
            }
        }
        if(timerCount/50 >= limit_time - 20){
            if(timerCount / 5 % 4 != 0)
                timeText.color =  Color.white;
            else
                timeText.color =  Color.red;
        }
        getDistance();
        ShowText();
    }
    
    void ShowText(){
        if(oneTime){ 
            trackText.text = "Track : " + track.ToString() + " / 4";
            distanceText.text = "Distance : " + ((int)distance).ToString() + "m";
            speedText.text = "Speed : " + PlayerMove.speed.ToString() + "m/s";
            if(timerCount % 50 == 0){
                timeText.text = "Time : " + (limit_time - timerCount/50).ToString() + "s";
            }
            switch(changeWeather.rand){ // cloud, rain, snow, sun
                case 0:
                    weatherText.text = "CLOUD :: 그림자";
                    break;
                case 1:
                    weatherText.text = "RAIN :: 그림자, 이동속도 감소";
                    break;
                case 2:
                    weatherText.text = "SNOW :: 그림자, 장애물 생성";
                    break;
                case 3:
                    weatherText.text = "SUN :: 탈진";
                    break;
            }
            if(PlayerCollision.notMove != 0)
                moveText.text = "Not move! " + PlayerCollision.notMove + "s";
            else
                moveText.text = "";
        }
    }

    void getDistance(){
        if(player.transform.position.z < -250)
            z = -250;
        else
            z = player.transform.position.z;
        z = (z > 0) ? 250 + z : 250 + z;
        
        if(GameObject.Find("track 1")){
            distance = trackLength * 4 - z;
            track = 1;
        }
        else if(GameObject.Find("track 2")){
            distance = trackLength * 3 - z;
            track = 2;
        }
        else if(GameObject.Find("track 3")){
            distance = trackLength * 2 - z;
            track = 3;
        }
        else if(GameObject.Find("track 4")){
            distance = trackLength * 1 - z;
            track = 4;
        }
    }

    public void StonePlay(){
        stone.Play();
    }
}