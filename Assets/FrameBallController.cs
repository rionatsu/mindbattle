using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameBallController : MonoBehaviour
{
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        // CPUとの接触
        if (collision.gameObject.name == "SapphiArtchan")
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHpCPU();

            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Shoot(new Vector3(0, 200, 2000));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
