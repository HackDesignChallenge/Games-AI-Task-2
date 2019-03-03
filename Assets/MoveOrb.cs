using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveOrb : MonoBehaviour
{

    public KeyCode moveL;
    public KeyCode moveR;

    public float horizVel = 0;
    public int laneNum = 2;
    public bool controlLocked = false;

    public Transform boomObj;

    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horizVel, GM.vertVel, 4);

        if((Input.GetKeyDown (moveL)) && (laneNum>1) && !controlLocked)
        {
            horizVel = -2;
            StartCoroutine(stopSlide());
            laneNum -= 1;
            controlLocked = true;
        }
        if ((Input.GetKeyDown(moveR)) && (laneNum < 3) && !controlLocked)
        {
            horizVel = 2;
            StartCoroutine(stopSlide());
            laneNum += 1;
            controlLocked = true;
        }
    }
    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag.Contains("Missile"))
        {
            Destroy(gameObject);
            Instantiate(boomObj, transform.position, boomObj.rotation);
            GM.success = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="rampBottomTrig")
        {
            GM.vertVel = 1;
        }
        if (other.gameObject.name == "rampTopTrig")
        {
            GM.vertVel = 0;
        }
        if(other.gameObject.name.Contains("exit"))
        {
            SceneManager.LoadScene("LevelComp");
        }
        if(other.gameObject.name.Contains("Coin"))
        {
            Destroy(other.gameObject);
            GM.coinTotal += 1;
        }
        if (other.gameObject.name.Contains("Capsule"))
        {
            Destroy(other.gameObject);
        }
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(.5f);
            horizVel = 0;
        controlLocked = false;
    }
}
