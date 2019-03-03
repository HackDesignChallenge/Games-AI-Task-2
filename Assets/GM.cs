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
    public static int[] modulSixFibonacciFractal = ModuleSixFibonacci();

    public static float zVelAdj = 1;

    public Transform fragment;
    public Transform hole;
    public Transform coinObj;
    public Transform obsctacleObj;
    public Transform powerUpObjc;
    public Transform exit;

    void Start()
    {
        float i;
        for (i = 0; i < 100; i+=4)
        {
            Instantiate(fragment, new Vector3(0, 0, i), fragment.rotation);
        }
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

    private static int[] CalculateFractalValues()
    {
        int[] values = new int[24];
        values[0] = 1;
        values[1] = 1;
        for (int i = 2; i < 24; i++)
        {
            values[i] = values[i - 1] + values[i - 2];
        }
        return values;
    }

    private static int[] ModuleSixFibonacci()
    {
        int[] fibonacciFractal = CalculateFractalValues();
        int[] values = new int[24];
        for (int i = 0; i < 24; i++)
        {
            values[i] = fibonacciFractal[i] % 6;
        }
        return values;
    }

}
