using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeWeather : MonoBehaviour
{
    public GameObject player;
    public Light dl;
    public AudioSource sun, cloud, rain, snow, thunder;
    public static int rand;
    private object[] instance;
    private GameObject instance1;
    private Vector3 pos;
    int pre;

    void Start(){
        instance = Resources.LoadAll("weather");    // cloud, rain, snow, sun
        pos = new Vector3(0, 150, 0);
        rand = Random.Range(0,4);
        pre = -1;
        InvokeRepeating("change", 5.05f, 30.05f);
        InvokeRepeating("delete", 35.05f, 30.05f);
    }

    void change(){
        if(InitScene.oneTime){
            if(pre != rand){
                if(rand == 0){
                    dl.GetComponent<Light>().intensity = 1f;
                        instance1 = (GameObject) Instantiate(instance[rand] as GameObject, pos, Quaternion.identity);
                        cloud.Play();
                }
                else{
                    cloud.Stop();
                }
                if(rand == 1){
                    dl.GetComponent<Light>().intensity = 0.8f;
                    instance1 = (GameObject) Instantiate(instance[rand] as GameObject, pos, Quaternion.identity);
                    PlayerMove.speed -= 4;
                    PlayerCollision.initSpeed -= 4;
                    rain.Play();
                    thunder.Play();
                }
                else{
                    rain.Stop();
                    thunder.Stop();
                }
                if(rand == 2){
                    dl.GetComponent<Light>().intensity = 0.8f;
                    instance1 = (GameObject) Instantiate(instance[rand] as GameObject, pos, Quaternion.identity);
                    snow.Play();
                }
                else{
                    snow.Stop();
                }
                if(rand == 3){
                    dl.GetComponent<Light>().intensity = 1.2f;
                    instance1 = (GameObject) Instantiate(instance[rand] as GameObject, new Vector3(0, 0, 0), Quaternion.identity);
                    sun.Play();
                }
                else{
                    sun.Stop();
                }
            }
        }
    }

    void delete(){
        if(InitScene.oneTime){
            pre = rand;
            rand = Random.Range(0,4);
            if(pre != rand){
                Destroy(instance1);
                if(pre == 1){
                    PlayerMove.speed += 4;
                    PlayerCollision.initSpeed += 4;
                }
            }
        }
    }
}
