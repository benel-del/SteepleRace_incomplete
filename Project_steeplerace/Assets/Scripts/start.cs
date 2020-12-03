using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start : MonoBehaviour
{
    private float timer = 0;
    public Text st;
    void Start(){
        GetComponent<InitScene>().enabled = false;
        GetComponent<changeWeather>().enabled = false;
        PlayerCollision.notMove = 7;
    }

    void FixedUpdate(){
        if(++timer % 50 == 0 && timer < 50*7){
            st.text = (--PlayerCollision.notMove - 1) + "";
        }
        if(timer % 50 == 0 && timer == 50*7){
            st.text = "시작~!";
            --PlayerCollision.notMove;
            GetComponent<InitScene>().enabled = true;
            GetComponent<changeWeather>().enabled = true;
            GameObject.Find("player").GetComponent<PlayerMove>().bgmplay();
        }
        if(timer % 50 == 0 && timer == 50*8){
            st.enabled = false;
        }
    }
}
