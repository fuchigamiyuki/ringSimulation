using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void change_scenes(){
        SceneManager.LoadScene("Map");
    }

    public void return_scenes(){
        SceneManager.LoadScene("Simulation");
    }
}
