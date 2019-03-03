using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "CoinText")
        {
            GetComponent<TextMesh>().text = "Coins :" + GM.coinTotal;
        }
        if (gameObject.name == "TimeText")
        {
            GetComponent<TextMesh>().text = "Time :" + GM.timeTotal;
        }
        if (gameObject.name == "MainText")
        {
            string text = GM.success ? "Level Complete" : "Level Failed";
            GetComponent<TextMesh>().text = text;
        }
    }
}
