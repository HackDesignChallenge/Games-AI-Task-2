using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveOrb : MonoBehaviour
{
    public AudioSource startEngine;
    public AudioSource coinPickup;
    public AudioSource toolsPickup;
    public AudioSource crash;
    public AudioSource engineRunning;

    public KeyCode moveL;
    public KeyCode moveR;

    public float horizVel = 0;
    public int laneNum = 2;
    public bool controlLocked = false;

    public Transform boomObj;

    void Start()
    {
        startEngine.Play(0);
        engineRunning.PlayDelayed(2);
    }


    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horizVel, GM.vertVel, 4);

        if((Input.GetKeyDown(moveL)) && (laneNum>1) && !controlLocked)
        {
            horizVel = -4;
            StartCoroutine(StopSlide());
            laneNum -= 1;
            controlLocked = true;
        }
        if ((Input.GetKeyDown(moveR)) && (laneNum < 3) && !controlLocked)
        {
            horizVel = 4;
            StartCoroutine(StopSlide());
            laneNum += 1;
            controlLocked = true;
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
            coinPickup.Play(0);
        }
        if (other.gameObject.name.Contains("Capsule"))
        {
            Destroy(other.gameObject);
            GM.health++;
            toolsPickup.Play(0);
        }
        if (other.gameObject.tag.Contains("Wall"))
        {
            HitBadObjectAndLoseHealth(3, other);
        }
        if (other.gameObject.tag.Contains("Hole"))
        {
            HitBadObjectAndLoseHealth(1, other);
        }
    }

    private void HitBadObjectAndLoseHealth(int healthToLose, Collider badObject)
    {
        crash.Play(0);
        Destroy(badObject.gameObject);
        GM.health -= healthToLose;
        if (GM.health <= 0)
        {
            Destroy(gameObject);
            Instantiate(boomObj, transform.position, boomObj.rotation);
            GM.success = false;
        }
    }

    IEnumerator StopSlide()
    {
        yield return new WaitForSeconds(.25f);
        horizVel = 0;
        controlLocked = false;
    }
}
