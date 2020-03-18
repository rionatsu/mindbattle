using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameBallController : MonoBehaviour
{
    GameObject gd;
    GameDirector gd2;
   
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    private void OnParticleCollision(GameObject obj)
    {
        Debug.Log("Hit3");
        //Debug.Log("particle collision obj name : "+obj.gameObject.name);
        Debug.Log("particle collision obj tag  : " + obj.tag);
        Debug.Log("particle collision obj      : " + obj);
        //Debug.Log(this.ParticleSystem);

        var body = obj.GetComponent<Rigidbody>();

        //if (obj.gameObject.name != "unitychan_dynamic")
        //if (obj.gameObject.name == "Plane")
        //{
        //    Destroy(gameObject);
        //}
        
    }

    private void OnCollisionEnter(Collision collision)
    {
            Debug.Log("Hit1");
        GetComponent<Rigidbody>().isKinematic = true;
        Debug.Log("Collision not particle"+collision.gameObject.name);
        // CPUとの接触
        if (collision.gameObject.name == "SapphiArtchan")
        {
            Debug.Log("Collision Sapphichan");
            Destroy(this);
            gd2.DecreaseHpCPU();

            Debug.Log("Collision Sapphichan 2");

            //GameObject director = GameObject.Find("GameDirector");
            //director.GetComponent<GameDirector>().DecreaseHpCPU();

            Destroy(gameObject);
            Debug.Log("Hit2");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Shoot(new Vector3(0, 200, 2000));
        gd = GameObject.Find("Canvas");
        gd2 = gd.GetComponent<GameDirector>();
        Debug.Log("### " + gd2 + " ###");
    }

    // Update is called once per frame
    void Update()
    {
        Transform ts = transform;
        Vector3 pos = ts.position;
        //Debug.Log("X "+pos.x);
        //Debug.Log("Y " + pos.y);
        //Debug.Log("Z " + pos.z);

        this.gameObject.transform.Translate(0, -0.05f, 0);
    }

}
