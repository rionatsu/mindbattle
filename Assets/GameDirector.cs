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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseHpPlayer()
    {
        this.hpGaugePlayer.GetComponent<Image>().fillAmount -= 0.1f;
    }

    public void DecreaseHpCPU()
    {
        this.hpGaugeCPU.GetComponent<Image>().fillAmount -= 0.1f;
    }
}
