using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createStone : MonoBehaviour
{
    GameObject stone;
    Transform player;
    int x, z;
    public static bool one;
    void Start()
    {
        player = GameObject.Find("player").GetComponent<Transform>();
        stone = (GameObject) Resources.Load("stone");
        
    }
    void FixedUpdate(){
        if(one && player.position.z > -240)
            StartCoroutine(create()); // InvokeRepeating은 active여부와 관계없이 계속 반복
    }
    IEnumerator create()
    {
        one = false;
        while(player.position.z < 200){
            x = Random.Range(-12, 12);
            z = Random.Range((int)player.position.z, (int)player.position.z + 40);
            Instantiate(stone, new Vector3(x*2.0f, 30, z), Quaternion.Euler(Random.Range(-5,5) * 10f, 0, 0));
            yield return new WaitForSeconds(0.2f);
        }
    }
}
