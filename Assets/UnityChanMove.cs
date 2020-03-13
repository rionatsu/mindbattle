using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanMove : MonoBehaviour
{

    //Rigidbodyを変数に入れる
    Rigidbody rb;
    //Animatorを入れる変数
    private Animator animator;
    //ユニティちゃんの位置を入れる
    Vector3 playerPos;
    //地面に接触しているか否か
    bool ground;
    //ファイヤーボール
    public GameObject frameBallPrefab;
    // バリア
    public GameObject barrierPrefab;

    void Start()
    {
        //Rigidbodyを取得
        rb = GetComponent<Rigidbody>();
        //ユニティちゃんのAnimatorにアクセスする
        animator = GetComponent<Animator>();
        //ユニティちゃんの現在より少し前の位置を保存
        playerPos = transform.position;

    }

    void Update()
    {
        //地面に接触していると作動する
        if (ground)
        {
            // attack
            if (Input.GetKeyDown(KeyCode.A))
            {
                animator.SetBool("attack", true);
                GameObject fireBall = Instantiate(frameBallPrefab, animator.transform, false) as GameObject;
                //fireBall.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 100));
            }
            // guard
            else if (Input.GetKeyDown(KeyCode.G))
            {
                animator.SetBool("guard", true);
                GameObject barrier = Instantiate(barrierPrefab, animator.transform, false) as GameObject;
                barrier.transform.parent = animator.transform;
                //Invoke("Destroy(barrier)", 1);
            }
            else
            {
                animator.SetBool("attack", false);
                animator.SetBool("guard", false);
            }
            //ユニティちゃんの位置を更新する
            //playerPos = transform.position;
        }
    }

    //Planに触れている間作動
    void OnCollisionStay(Collision col)
    {
        ground = true;
    }

    //Planから離れると作動
    void OnCollisionExit(Collision col)
    {
        ground = false;
    }
}
