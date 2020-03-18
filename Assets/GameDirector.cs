using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject hpGaugePlayer;
    GameObject hpGaugeCPU;
    bool isPlayerGaurd;
    long guardtime;

    // Start is called before the first frame update
    void Start()
    {
        this.hpGaugePlayer = GameObject.Find("HPGaugePlayer");
        this.hpGaugeCPU = GameObject.Find("HPGaugeCPU");
        Debug.Log(this.hpGaugeCPU);

        GameObject LoseText = GameObject.Find("LoseText");
        Text tx2 = LoseText.GetComponent<Text>();
        tx2.enabled = false;

        GameObject WinText = GameObject.Find("WinText");
        Text tx = WinText.GetComponent<Text>();
        tx.enabled = false;

        isPlayerGaurd = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerGaurd)
        {
            Debug.Log("Gurad");
            this.guardtime -= 1;
            if(this.guardtime <= 0)
            {
                isPlayerGaurd = false;
            }
        }   
    }

    public void updatePlayerGaurd(bool isGaurded)
    {
        if (isGaurded)
        {
            this.guardtime = 20;
            this.isPlayerGaurd = isGaurded;
        }
    }

    public void DecreaseHpPlayer()
    {
        //this.hpGaugePlayer.GetComponent<Image>().fillAmount -= 0.1f;
        //Image im = this.hpGaugePlayer.GetComponent<Image>();
        //im.fillAmount -= 0.1f;
        if (isPlayerGaurd)
        {
            return;
        }
        GameObject HPPlayer = GameObject.Find("HPGaugePlayer");
        Image im = HPPlayer.GetComponent<Image>();
        if (!isPlayerGaurd)
        {
            im.fillAmount -= 0.1f;
        }
        Debug.Log(im);
        if (im.fillAmount <= 0.0f)
        {
            GameObject LoseText = GameObject.Find("LoseText");
            Text tx = LoseText.GetComponent<Text>();
            tx.enabled = true;
        }
    }

    public void DecreaseHpCPU()
    {
        Debug.Log("Call Decrease CPU HP");

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
