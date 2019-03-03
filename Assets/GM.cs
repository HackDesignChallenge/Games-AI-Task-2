using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public static float vertVel = 0;
    public static int coinTotal = 0;
    public static float timeTotal = 0;
    public static bool success = true;
    public float waitToLoad = 0;

    public static float zVelAdj = 1;

    public Transform bbNoObstArea;
    public Transform bbMidPitArea;
    public Transform coinObj;
    public Transform obsctacleObj;
    public Transform powerUpObjc;
    public Transform exit;

    void Start()
    {
        float i;
        for (i = 34.89f; i < 100; i+=8)
        {
            Instantiate(bbNoObstArea, new Vector3(0, 3.13f, i), bbNoObstArea.rotation);
            Instantiate(bbMidPitArea, new Vector3(0, 3.13f, i+4), bbMidPitArea.rotation);
        }
        Instantiate(exit, new Vector3(0, 4.13f, i-3), exit.rotation);
    }

    void Update()
    {
        timeTotal += Time.deltaTime;

        if(!success)
        {
            waitToLoad += Time.deltaTime;
        }

        if(waitToLoad > 2)
        {
            SceneManager.LoadScene("LevelComp");
        }
    }
}
