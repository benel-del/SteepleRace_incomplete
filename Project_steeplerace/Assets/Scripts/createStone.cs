using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createStone : MonoBehaviour
{
    GameObject stone;
    Transform player;
    int x, z;
    void Start()
    {
        player = GameObject.Find("player").transform;
        stone = (GameObject) Resources.Load("stone");
        StartCoroutine(create()); // InvokeRepeating은 active여부와 관계없이 계속 반복
    }
    IEnumerator create()
    {
        while(player.position.z > -240 && player.position.z < 210){
            x = Random.Range(-12, 12);
            z = Random.Range((int)player.position.z, (int)player.position.z + 60);
            Instantiate(stone, new Vector3(x*2.0f, 30, z), Quaternion.Euler(0, 0, Random.Range(0, 90)));
            yield return new WaitForSeconds(0.2f);
        }
    }
}
