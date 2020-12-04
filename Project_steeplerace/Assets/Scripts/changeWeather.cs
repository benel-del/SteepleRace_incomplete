using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeWeather : MonoBehaviour
{
    public GameObject player;
    public Light dl;
    public AudioSource rain, thunder;
    public GameObject spring, spring1, raining, raining1, winter, winter1;
    public GameObject sp;
    public static int rand;
    private object[] instance;
    private GameObject instance1;
    private Vector3 pos;
    int pre;

    public static bool start;
    void FixedUpdate(){
        if(!InitScene.oneTime){
            rain.Stop();
            thunder.Stop();
        }
        if(start){
            start = false;
            rand = Random.Range(0,4);
            pre = -1;
            StartCoroutine(change());
        }
        if(!InitScene.oneTime)
            StopAllCoroutines();
    }

    void Start(){
        instance = Resources.LoadAll("weather");    // cloud, rain, snow, sun
        pos = new Vector3(0, 150, 0);
    }

    IEnumerator change(){
        while(InitScene.oneTime){
            if(pre != rand){
                if(rand == 0){
                    dl.GetComponent<Light>().intensity = 1f;
                    instance1 = (GameObject) Instantiate(instance[rand] as GameObject, pos, Quaternion.identity);
                }
                if(rand == 1){
                    dl.GetComponent<Light>().intensity = 0.8f;
                    instance1 = (GameObject) Instantiate(instance[rand] as GameObject, pos, Quaternion.identity);
                    PlayerMove.speed -= 4;
                    PlayerCollision.initSpeed -= 4;
                    rain.Play();
                    thunder.Play();
                    raining.SetActive(true);
                    raining1.SetActive(true);
                }
                else{
                    rain.Stop();
                    thunder.Stop();
                    raining.SetActive(false);
                    raining1.SetActive(false);
                }
                if(rand == 2){
                    dl.GetComponent<Light>().intensity = 0.8f;
                    instance1 = (GameObject) Instantiate(instance[rand] as GameObject, pos, Quaternion.identity);
                    winter.SetActive(true);
                    winter1.SetActive(true);
                }
                else{
                    winter.SetActive(false);
                    winter1.SetActive(false);
                }
                if(rand == 3){
                    dl.GetComponent<Light>().intensity = 1.2f;
                    instance1 = (GameObject) Instantiate(instance[rand] as GameObject, new Vector3(0, 0, 0), Quaternion.identity);
                }

                if(rand != 1 && rand != 2)
                    sp.SetActive(false);
                else
                    sp.SetActive(true);
                if(rand != 0 && rand != 3){
                    spring.SetActive(false);
                    spring1.SetActive(false);
                }
                else{
                    spring.SetActive(true);
                    spring1.SetActive(true);
                }
            }
            yield return new WaitForSeconds(30.05f);
            delete();
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
