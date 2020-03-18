using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject hpGaugePlayer;
    GameObject hpGaugeCPU;

    // Start is called before the first frame update
    void Start()
    {
        this.hpGaugePlayer = GameObject.Find("HPGaugePlayer");
        this.hpGaugeCPU = GameObject.Find("HPGaugeCPU");
        Debug.Log(this.hpGaugeCPU);

        GameObject WinText = GameObject.Find("WinText");
        Text tx = WinText.GetComponent<Text>();
        tx.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseHpPlayer()
    {
        //this.hpGaugePlayer.GetComponent<Image>().fillAmount -= 0.1f;
        Image im = this.hpGaugePlayer.GetComponent<Image>();
        im.fillAmount -= 0.1f;
    }

    public void DecreaseHpCPU()
    {
        Debug.Log("Call Decrease CPU HP");
        //this.hpGaugeCPU.GetComponent<Image>().fillAmount -= 0.1f;
        //Image im = this.hpGaugeCPU.GetComponent<Image>();
        //im.fillAmount -= 0.1f;

        GameObject HPCPU = GameObject.Find("HPGaugeCPU");
        Image im = HPCPU.GetComponent<Image>();
        im.fillAmount -= 0.1f;
        Debug.Log(im);
        if (im.fillAmount <= 0.0f)
        {
            GameObject WinText = GameObject.Find("WinText");
            Text tx = WinText.GetComponent<Text>();
            tx.enabled = true;
        }
    }
}
