using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameBallController : MonoBehaviour
{
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    private void OnParticleCollision(GameObject obj)
    {
        Debug.Log("Hit3");
        Debug.Log(obj.gameObject.name);
        Debug.Log(obj.tag);
        Debug.Log(obj);
        //Debug.Log(this.ParticleSystem);

        var body = obj.GetComponent<Rigidbody>();

        if (obj.gameObject.name != "unitychan_dynamic")
        {
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
            Debug.Log("Hit1");
        GetComponent<Rigidbody>().isKinematic = true;
        Debug.Log(collision.gameObject.name);
        // CPUとの接触
        if (collision.gameObject.name == "SapphiArtchan")
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHpCPU();

            Destroy(gameObject);
            Debug.Log("Hit2");
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
        Transform ts = transform;
        Vector3 pos = ts.position;
        //Debug.Log("X "+pos.x);
        //Debug.Log("Y " + pos.y);
        //Debug.Log("Z " + pos.z);
    }

}
