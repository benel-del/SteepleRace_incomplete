using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCloud : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.right * 5f * Time.deltaTime);
    }
}
