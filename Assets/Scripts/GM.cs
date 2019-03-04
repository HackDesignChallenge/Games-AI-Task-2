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

    private LinkedList<Tuple<int, List<Transform>>> gameObjects;


    public static float zVelAdj = 1;
    public static int health;
    public static bool videoPlayed;

    public Transform player;
    public Transform fragment;
    public Transform hole;
    public Transform coinObj;
    public Transform obsctacleObj;
    public Transform powerUpObjc;
    public Transform exit;

    public Transform house1;
    public Transform house2;
    public Transform house3;
    public Transform house4;
    public Transform house5;
    public Transform house6;
    public Transform house7;
    private List<Transform> houses;

    void Start()
    {
        health = 5;
        success = true;
        timeTotal = 0;
        waitToLoad = 0;
        gameObjects = new LinkedList<Tuple<int, List<Transform>>>();
        randomGameAssets = RandomGameAssets();
        houses = allHouses();
        InstantiateObjects(100);
        InstantiateObjects(200);
    }

    void Update()
    {
        if(!success)
        {
            waitToLoad += Time.deltaTime;
        }

        if(waitToLoad > 1)
        {
            SceneManager.LoadScene("Video");
        }

        if (player != null && player.position.z > gameObjects.First.Value.Item1)
        {
            InstantiateObjects(gameObjects.Last.Value.Item1 + 100);
            gameObjects.First.Value.Item2.ForEach(o => Destroy(o.gameObject));
        }
        timeTotal += Time.deltaTime;
    }


    
    private void InstantiateObjects(int limit)
    {
        var instantiated = new List<Transform>();
        for (int i = limit - 100; i < limit; i += 4)
        {
            instantiated.Add(Instantiate(fragment, new Vector3(0, 0, i), fragment.rotation));
        }

        System.Random random = new System.Random();
        for (int j = -1; j < 2; j++)
        {
            int placement = 4 + limit - 100;
            int fraction = random.Next(41);
            float multiplier = 1.0f + (fraction / 10.0f);

            for (int i = 0; i < modulSixFibonacciFractal.Length; i++)
            {
                Transform objectToPlace = randomGameAssets[random.Next(20)];
                int nextPlacement = placement += (int)(modulSixFibonacciFractal[i] * multiplier);
                if (nextPlacement >= limit)
                {
                    break;
                }
                float y = objectToPlace.gameObject.tag.Contains("Hole") ? 0.5f : 1;
                instantiated.Add(Instantiate(objectToPlace, new Vector3(j, y, nextPlacement), objectToPlace.rotation));
                placement++;
            }
        }
        int housePlacement = limit - 100;
        for (int i = 0; i < modulSixFibonacciFractal.Length; i++)
        {
            housePlacement = housePlacement + modulSixFibonacciFractal[i];
            if (housePlacement >= limit)
            {
                break;
            }
            Quaternion rotation = new Quaternion();
            rotation.eulerAngles = new Vector3(-90, 90,0);
            instantiated.Add(Instantiate(houses[random.Next(7)], new Vector3(2, 0.5f, housePlacement), rotation));

        }
        int secondHousePlacement = limit - 100;
        for (int i = 0; i < modulSixFibonacciFractal.Length; i++)
        {
            secondHousePlacement = secondHousePlacement + (int)(1.2 * modulSixFibonacciFractal[i]);
            if (secondHousePlacement >= limit)
            {
                break;
            }
            Quaternion rotation = new Quaternion();
            rotation.eulerAngles = new Vector3(-90, 270, 0);
            instantiated.Add(Instantiate(houses[random.Next(7)], new Vector3(-2, 0.5f, secondHousePlacement), rotation));

        }
        gameObjects.AddLast(Tuple.Create(limit, instantiated));
    }

    private List<Transform> allHouses()
    {
        var houses = new List<Transform>();
        houses.Add(house1);
        houses.Add(house2);
        houses.Add(house3);
        houses.Add(house4);
        houses.Add(house5);
        houses.Add(house6);
        houses.Add(house7);
        return houses;
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
