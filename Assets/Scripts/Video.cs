using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Video : MonoBehaviour
{

    void Update()
    {
        StartCoroutine(loadScene());
    }

    IEnumerator loadScene()
    {
        AudioSource background = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        float prevVol = background.volume;
        background.volume = 0;
        yield return new WaitForSeconds(3);
        background.volume = prevVol;
        SceneManager.LoadScene("LevelComp");
    }
}
