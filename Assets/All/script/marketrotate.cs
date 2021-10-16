using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marketrotate : MonoBehaviour
{
    public float ror = 50;
    void Update()
    {
        transform.Rotate(0, ror * Time.deltaTime, 0);
    }
}
