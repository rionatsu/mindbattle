using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameBallController : MonoBehaviour
{
    GameObject gd;
    GameDirector gd2;
    long  livetime;//自爆さけるため
    long guardtime;
   
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

        //var body = obj.GetComponent<Rigidbody>();

        //if (obj.gameObject.name != "unitychan_dynamic")
        //if (obj.gameObject.name == "Plane")
        //{
        //    Destroy(gameObject);
        //}
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (this.livetime < 2)
        {
            Debug.Log("avoid"+this.livetime);
            return;
        }
        Debug.Log("livetime"+this.livetime);
        Debug.Log("Hit1");
        GetComponent<Rigidbody>().isKinematic = true;
        Debug.Log("Collision not particle" + collision.gameObject.name);
        Debug.Log("Collision not particle tag" + collision.gameObject.tag);
        // CPUとの接触
        if (collision.gameObject.name == "SapphiArtchan")
        {
            Debug.Log("Collision Sapphichan");
            Destroy(this);
            gd2.DecreaseHpCPU();

            Debug.Log("Collision Sapphichan 2");

            Destroy(gameObject);
            Debug.Log("Hit2");
        }

        if (collision.gameObject.name == "unitychan_dynamic")
        {
            Debug.Log("Collision unitychan_dynamic");
            Destroy(this);
            gd2.DecreaseHpPlayer();

            Debug.Log("Collision unitychan_dynamic 2");

            Destroy(gameObject);
            Debug.Log("Hit2");
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        this.livetime = 0;
        this.guardtime = 0;
        Shoot(new Vector3(0, 200, 2000));
        gd = GameObject.Find("Canvas");
        gd2 = gd.GetComponent<GameDirector>();
        Debug.Log("### " + gd2 + " ###");
    }

    // Update is called once per frame
    void Update()
    {
        this.livetime = this.livetime + 1;
        this.guardtime -= 1;
        Transform ts = transform;
        Vector3 pos = ts.position;
        //Debug.Log("X "+pos.x);
        //Debug.Log("Y " + pos.y);
        //Debug.Log("Z " + pos.z);

        Debug.Log("livetime" + this.livetime);
        this.gameObject.transform.Translate(0, -0.05f, 0);
    }

}
