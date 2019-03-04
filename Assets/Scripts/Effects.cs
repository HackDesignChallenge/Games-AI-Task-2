using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name.Contains("Capsule"))
        {
            transform.Rotate(0, 3, 0);
        }
        if (gameObject.name.Contains("Coin"))
        {
            transform.Rotate(0, 0, 3);
        }

    }
}
