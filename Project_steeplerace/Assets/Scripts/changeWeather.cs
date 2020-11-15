using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeWeather : MonoBehaviour
{
    public GameObject player;
    public Light dl;
    public AudioSource sun, cloud, rain, snow;
    private object[] instance;
    private GameObject instance1;
    private Vector3 pos;
    int rand, pre;

    void Start(){
        instance = Resources.LoadAll("weather");    // cloud, rain, snow, sun
        pos = new Vector3(0, 150, 0);
        rand = Random.Range(0,4);
        pre = -1;
        InvokeRepeating("change", 1f, 30f);
        InvokeRepeating("delete", 30.1f, 30f);
    }

    void change(){
        if(GameObject.FindWithTag("result") == null){
            if(pre != rand)
                switch(rand){
                    case 3: // Gsun
                        dl.GetComponent<Light>().intensity = 1.2f;
                        instance1 = (GameObject) Instantiate(instance[rand] as GameObject, new Vector3(0, 0, 0), Quaternion.identity);
                        //sun.Play();
                        break;
                    case 0: // Gcloud
                        dl.GetComponent<Light>().intensity = 1f;
                        instance1 = (GameObject) Instantiate(instance[rand] as GameObject, pos, Quaternion.identity);
                        //cloud.Play();
                        break;
                    case 1: // Grain
                        dl.GetComponent<Light>().intensity = 0.8f;
                        instance1 = (GameObject) Instantiate(instance[rand] as GameObject, pos, Quaternion.identity);
                        player.GetComponent<PlayerMove>().speed -= 4;
                        player.GetComponent<PlayerCollision>().initSpeed -= 4;
                        //rain.Play();
                        break;
                    case 2: // Gsnow
                        dl.GetComponent<Light>().intensity = 0.8f;
                        instance1 = (GameObject) Instantiate(instance[rand] as GameObject, pos, Quaternion.identity);
                        //snow.Play();
                        break;
                }
        }
    }

    void delete(){
        if(GameObject.FindWithTag("result") == null){
            pre = rand;
            rand = Random.Range(0,4);
            if(pre != rand){
                Destroy(instance1);
                if(pre == 1){
                    player.GetComponent<PlayerMove>().speed += 4;
                    player.GetComponent<PlayerCollision>().initSpeed += 4;
                }
            }
        }
    }
}
