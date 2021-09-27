using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasSc : MonoBehaviour
{
    public GameObject ball;
    public GameObject [] stars;

    private void Start()
    {
        int amount = ball.GetComponent<Ball>().starAmount;
        for(int i = 0; i < amount; i++)
        {
            stars[i].SetActive(true);
        }
    }
    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
   
    
}
