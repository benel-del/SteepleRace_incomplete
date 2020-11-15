using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int notMove;
    public AudioSource wind, hurdle, stick, snow, portal;
    public GameObject portalA, portalB;
    public GameObject track1, track2, track3, track4;
    private int initSpeed, notMoveTime;
    private float initJump;
    private GameObject instance, effect;
    void Start()
    {
        notMove = 0;
        initSpeed = 10;
        initJump = 60f;
        notMoveTime = 3;
        effect = Resources.Load("particleEffect") as GameObject;
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.name == "board"){
            GetComponent<PlayerMove>().jump = 30f;
            GetComponent<PlayerMove>().speed = 5;
            //wind.Play();
        }
        else if(other.gameObject.tag == "snow_set"){
            GetComponent<PlayerMove>().jump = initJump;
            //snow.Play();
        }
        else{
            GetComponent<PlayerMove>().jump = initJump;
            GetComponent<PlayerMove>().speed = initSpeed;                
            if(other.gameObject.name == "hurdle"){
                notMove = notMoveTime;
                //hurdle.Play();
            }
            if(other.gameObject.tag == "stone")
                notMove = notMoveTime;
            if(other.gameObject.name == "stick"){
                notMove = notMoveTime;
                //stick.Play();
            }
            if(other.gameObject.name == "portal-C")
                transform.position = portalB.GetComponent<Transform>().position;
            if(other.gameObject.name == "portal-A"){
                if(track1.activeSelf){
                    track1.SetActive(false);
                    track2.SetActive(true);
                }
                else if(track2.activeSelf){
                    track2.SetActive(false);
                    track3.SetActive(true);
                }
                else if(track3.activeSelf){
                    track3.SetActive(false);
                    portalA.SetActive(false);
                    track4.SetActive(true);
                }
                transform.position = portalB.GetComponent<Transform>().position;
                //portal.Play();
            }
            if(other.gameObject.name == "portal-B"){
                instance = Instantiate(effect, new Vector3(transform.position.x, 0.5f, transform.position.z), Quaternion.Euler(-90, 0, 0));
                Destroy(instance, 3f);
            }
        }
        //Debug.Log(other.gameObject.name + ": " + GetComponent<PlayerMove>().speed);
    }

    void OnCollisionStay(Collision other){
        if(other.gameObject.name == "board" || other.gameObject.tag == "snow_set")
            transform.position = new Vector3(transform.position.x + Random.Range(-5, 5) * 0.01f, transform.position.y, transform.position.z);
        if(other.gameObject.tag == "ice"){
            GetComponent<PlayerMove>().jump = 30f;
            GetComponent<PlayerMove>().speed = 4;
        }
        else if(other.gameObject.tag == "snow_set"){
            GetComponent<PlayerMove>().speed = 4;
        }
    }
}
