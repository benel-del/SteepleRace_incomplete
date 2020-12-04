using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class before : MonoBehaviour
{
    public GameObject str, end;
    public GameObject script, player, sp;
    public GameObject track1, track2, track3, track4, portalA;
    public AudioSource bgm;
    public Text[] text = new Text[8];
    public GameObject[] grass = new GameObject[6];

    public static bool RestartButton = false;
    public static bool StartButton = false;
    void Start()
    {
        init();
    }
    public void RestartButtonDown(){
        RestartButton = true;
    }
    public void StartButtonDown(){
        StartButton = true;
    }
    void FixedUpdate(){
        if(RestartButton){
            end.SetActive(false);
            str.SetActive(true);
            init();
            RestartButton = false;
        }
        if(StartButton){
            str.SetActive(false);
            gameStart();
            StartButton = false;
        }
    }
    void gameStart(){
        script.GetComponent<start>().enabled = true;

        // player setting
        player.transform.position = new Vector3(0, 3, -255);
        player.GetComponent<PlayerCollision>().enabled = true;

        // UI setting
        text[0].text = "Distance : 2000m";
        text[1].text = "Speed : 10m/s";
        text[2].text = "Time : 500s";
        text[3].text = "WEATHER EFFECT";
        text[4].text = "Track : 1 / 4";

        // start.cs setting
        PlayerCollision.notMove = 7;
        start.timer = 0;

        // weather setting
        changeWeather.start = true;
    }
    void init(){
        // scriptObject setting
        script.GetComponent<start>().enabled = false;
        script.GetComponent<InitScene>().enabled = false;
        script.GetComponent<changeWeather>().enabled = false;

        // bgm setting
        bgm.loop = true;
        bgm.Stop();

        // InitScence.cs setting
        InitScene.oneTime = true;
        InitScene.limit_time = 500;
        InitScene.distance = InitScene.trackLength * 4;
        InitScene.timerCount = 0;

        // UI setting
        for(int i = 0; i < 8; i++)
            text[i].text = "";
        text[7].enabled = true;

        // player setting
        player.GetComponent<PlayerCollision>().enabled = false;
        player.transform.position = new Vector3(0, 0, -255);
        sp.SetActive(false);

        // player move setting
        PlayerMove.speed = PlayerCollision.initSpeed = 10;
        PlayerMove.jump = PlayerCollision.initJump = 80f;
        PlayerMove.isJump = false;
        PlayerMove.move1 = PlayerMove.move2 = false;

        // track setting
        track1.SetActive(true);
        track2.SetActive(false);
        track3.SetActive(false);
        track4.SetActive(false);
        portalA.SetActive(true);

        // grass setting
        grass[0].SetActive(true);
        grass[1].SetActive(true);
        for(int i = 2; i < 6; i++)
            grass[i].SetActive(false);
        
        // weather setting
        GameObject ob;
        if(ob = GameObject.FindWithTag("Gsun"))
            Destroy(ob);
        if(ob = GameObject.FindWithTag("Gcloud"))
            Destroy(ob);
        if(ob = GameObject.FindWithTag("Grain"))
            Destroy(ob);
        if(ob = GameObject.FindWithTag("Gsnow"))
            Destroy(ob);

        // obstacle-stone setting
        createStone.one = true;
    }
}
