using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static int notMove, initSpeed;
    public AudioSource wind, hurdle, stick, snow_set, ice, portal;
    public GameObject portalA, portalB;
    public GameObject track1, track2, track3, track4;
    private int notMoveTime;
    private float initJump;
    private GameObject instance, effect;
    void Start()
    {
        initSpeed = 10;
        initJump = 60f;
        notMoveTime = 3;
        effect = Resources.Load("particleEffect") as GameObject;
        PlayerMove.jump = initJump;
        PlayerMove.speed = initSpeed;
    }
    void onCollisionExit(Collision other){
        Debug.Log(other.gameObject.name);
        if(other.gameObject.tag == "snow_set"){
            PlayerMove.speed = initSpeed;
            snow_set.Stop();
        }
            
        if(other.gameObject.tag == "ice"){
            PlayerMove.jump = initJump;
            PlayerMove.speed = initSpeed;
            ice.Stop();
        }
            
        if(other.gameObject.name == "board"){
            PlayerMove.jump = initJump;
            PlayerMove.speed = initSpeed;
            wind.Stop();
        } 
    }
    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "hurdle"){
            GetComponent<Rigidbody>().AddForce(Vector3.back * 200f);
            notMove = notMoveTime;
            hurdle.Play();
        }
        if(other.gameObject.tag == "stone")
            notMove = notMoveTime;
        if(other.gameObject.tag == "stick"){
            GetComponent<Rigidbody>().AddForce(Vector3.back * 200f);
            notMove = notMoveTime;
            stick.Play();
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
            portal.Play();
        }
        if(other.gameObject.name == "portal-B"){
            instance = Instantiate(effect, new Vector3(transform.position.x, 0.5f, transform.position.z), Quaternion.Euler(-90, 0, 0));
            Destroy(instance, 3f);
        }
        if(other.gameObject.name == "board"){
            PlayerMove.jump = 30f;
            PlayerMove.speed = initSpeed - 3;
            wind.Play();
        }
        if(other.gameObject.tag == "snow_set"){
            PlayerMove.speed = initSpeed - 4;
            snow_set.Play();
        }
        if(other.gameObject.tag == "ice"){
            PlayerMove.jump = 30f;
            PlayerMove.speed = initSpeed - 4;
            ice.Play();
        }
    }

    void OnCollisionStay(Collision other){
        if(other.gameObject.name == "board" || other.gameObject.tag == "snow_set")
            transform.position = new Vector3(transform.position.x + Random.Range(-3, 3) * 0.01f, transform.position.y, transform.position.z);
    }
}
