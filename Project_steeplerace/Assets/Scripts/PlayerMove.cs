using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static int speed;
    public static float jump;
    public AudioSource falling;
    private Animation ani;
    private List<string> aniArr;

    private float sun;
    void Start()
    {
        speed = 10;
        jump = 60f;
        sun = 0;
        transform.position = new Vector3(0, 3, -255);
        ani = GetComponent<Animation>();
        aniArr = new List<string>();

        int index = 0;
        foreach(AnimationState state in ani){
            aniArr.Add(state.name);
            index++;
        }
    }

    void FixedUpdate()
    {
        //ani.Play(aniArr[3]);
        ani.AddClip(aniArr[3]);
        if(InitScene.oneTime) {
            if(PlayerCollision.notMove != 0)
                ani.Play(aniArr[2]);
            else{
                if(transform.position.y < -1)
                    falling.Play();
                else{
                    falling.Stop();
                    if(transform.position.z > 259)
                        transform.position = new Vector3(transform.position.x, transform.position.y, 259);
                    if(Input.GetKey(KeyCode.Space))
                        if(transform.position.y < 0.5){
                            GetComponent<Rigidbody>().AddForce(Vector3.up * jump);
                            ani.Play(aniArr[1]);
                        }
                    if(Input.GetKey(KeyCode.UpArrow)){
                        transform.Translate(Vector3.forward * speed * Time.deltaTime);
                        ani.Play(aniArr[0]);
                        if(GameObject.FindWithTag("Gsun"))
                            sun += Time.deltaTime;
                        else 
                            sun = 0;
                    }
                    else{
                        sun = 0;
                    }
                    if(Input.GetKey(KeyCode.LeftArrow)){
                        if(transform.position.x >= -24)
                            transform.Translate(Vector3.left * speed * Time.deltaTime);
                        ani.Play(aniArr[0]);
                    }
                    if(Input.GetKey(KeyCode.RightArrow)){
                        if(transform.position.x <= 24)
                            transform.Translate(Vector3.right * speed * Time.deltaTime);
                    }
                }
                if(sun > 15){
                    PlayerCollision.notMove = 3;
                    sun = 0;
                }
            }
        }
    }
}
