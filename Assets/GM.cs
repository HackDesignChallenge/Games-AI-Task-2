using System;
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
    public Dictionary<int, Transform> randomGameAssets;

    private LinkedList<Tuple<int, List<GameObject>>> gameObjects;


    public static float zVelAdj = 1;
    public static int health = 5;


    public Transform player;
    public Transform fragment;
    public Transform hole;
    public Transform coinObj;
    public Transform obsctacleObj;
    public Transform powerUpObjc;
    public Transform exit;

    void Start()
    {
        gameObjects = new LinkedList<Tuple<int, List<GameObject>>>();
        randomGameAssets = RandomGameAssets();
        InstantiateObjects(100);
        InstantiateObjects(200);
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

    private void InstantiateObjects(int limit)
    {
        var instantiated = new List<Transform>();
        for (int i = limit - 100; i < limit; i += 4)
        {
            instantiated.Add(Instantiate(fragment, new Vector3(0, 0, i), fragment.rotation));
        }

        System.Random fractalMultiplier = new System.Random();
        System.Random obj = new System.Random();
        for (int j = -1; j < 2; j++)
        {
            int placement = 4;
            int fraction = fractalMultiplier.Next(41);
            float multiplier = 1.0f + (fraction / 10.0f);

            for (int i = 0; i < modulSixFibonacciFractal.Length; i++)
            {
                Transform objectToPlace = randomGameAssets[obj.Next(20)];
                int nextPlacement = (int)((placement += modulSixFibonacciFractal[i]) * multiplier);
                if (nextPlacement >= limit)
                {
                    break;
                }
                instantiated.Add(Instantiate(objectToPlace, new Vector3(j, 1, nextPlacement), objectToPlace.rotation));
                placement++;
            }
        }
        gameObjects.
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
    private Dictionary<int, Transform> RandomGameAssets()
    {
        Dictionary<int, Transform> gameAssets = new Dictionary<int, Transform>();
        gameAssets.Add(0, hole);
        gameAssets.Add(1, coinObj);
        gameAssets.Add(2, obsctacleObj);
        gameAssets.Add(3, powerUpObjc);
        gameAssets.Add(4, coinObj);
        gameAssets.Add(5, coinObj);
        gameAssets.Add(6, coinObj);
        gameAssets.Add(7, coinObj);
        gameAssets.Add(8, coinObj);
        gameAssets.Add(10, coinObj);
        gameAssets.Add(11, coinObj);
        gameAssets.Add(12, coinObj);
        gameAssets.Add(13, coinObj);
        gameAssets.Add(14, coinObj);
        gameAssets.Add(15, obsctacleObj);
        gameAssets.Add(16, obsctacleObj);
        gameAssets.Add(17, obsctacleObj);
        gameAssets.Add(18, obsctacleObj);
        gameAssets.Add(19, hole);
        gameAssets.Add(9, hole);
        return gameAssets;
    }
}
