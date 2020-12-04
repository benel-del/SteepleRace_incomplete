using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start : MonoBehaviour
{
    public static float timer;
    public Text st;

    void FixedUpdate(){
        if(++timer % 50 == 0){
            if(timer % 50 == 0 && timer < 50*7)
                st.text = (--PlayerCollision.notMove - 1) + "";
            if(timer % 50 == 0 && timer == 50*7){
                st.text = "START";
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
}
