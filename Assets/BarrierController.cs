using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    public float deleteTime = 2.0f;
    private float timeElapsed = 0.0f;

    void Start()
    {
        timeElapsed = 0.0f;    
    }
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > deleteTime)
        {

            Destroy(gameObject);
        }
    }
}
