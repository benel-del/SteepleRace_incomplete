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
    private int count;

    void Start(){
        instance = Resources.LoadAll("weather");
        pos = new Vector3(0, 150, 0);
        count = 0;
        
        while(GameObject.FindWithTag("result") == null){
            int rand = Random.Range(0,4);
            switch(rand){
                case 0: // Gsun
                    dl.GetComponent<Light>().intensity = 1f;
                    instance1 = (GameObject) Instantiate(instance[0] as GameObject, new Vector3(0, 0, 0), Quaternion.identity);
                    player.GetComponent<PlayerMove>().speed -= 10;
                    //sun.Play();
                    wating();
                    player.GetComponent<PlayerMove>().speed += 10;
                    break;
                case 1: // Gcloud
                    dl.GetComponent<Light>().intensity = 0.8f;
                    instance1 = (GameObject) Instantiate(instance[1] as GameObject, pos, Quaternion.identity);
                    //cloud.Play();
                    wating();
                    break;
                case 2: // Grain
                    dl.GetComponent<Light>().intensity = 0.5f;
                    instance1 = (GameObject) Instantiate(instance[2] as GameObject, pos, Quaternion.identity);
                    player.GetComponent<Rigidbody>().drag += 10;
                    //rain.Play();
                    wating();
                    player.GetComponent<Rigidbody>().drag -= 10;
                    break;
                case 3: // Gsnow
                    dl.GetComponent<Light>().intensity = 0.5f;
                    instance1 = (GameObject) Instantiate(instance[3] as GameObject, pos, Quaternion.identity);
                    player.GetComponent<PlayerMove>().speed -= 5;
                    //snow.Play();
                    wating();
                    player.GetComponent<PlayerMove>().speed += 5;
                    break;
            }
            Destroy(instance1);
        }
    }

    void wating(){
        if(count % 50*30 == 0)
            return;
    }

    void FixedUpdate(){
        count++;
    }
}
