using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start : MonoBehaviour
{
    private float timer = 0;
    public Text st;
    public AudioSource audio1, audio2;
    void Start(){
        GetComponent<InitScene>().enabled = false;
        GetComponent<changeWeather>().enabled = false;
        PlayerCollision.notMove = 7;
    }

    void FixedUpdate(){
        if(++timer % 50 == 0 && timer < 50*7){
            audio1.Play();
            st.text = (--PlayerCollision.notMove - 1) + "";
        }
        if(timer % 50 == 0 && timer == 50*7){
            audio2.Play();
            st.text = "땅~!";
            --PlayerCollision.notMove;
            GetComponent<InitScene>().enabled = true;
            GetComponent<changeWeather>().enabled = true;
        }
        if(timer % 50 == 0 && timer == 50*8){
            st.enabled = false;
            Debug.Log(PlayerCollision.notMove);
        }
    }
}
