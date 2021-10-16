using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCheckpoint : MonoBehaviour
{
    public GameObject Checkpoint;

    private void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Player") ;
    }
}
