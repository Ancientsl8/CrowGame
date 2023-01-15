using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //This is just to manage Game Overs;
    int Counter;
    [SerializeField] private GameObject GameOver;
    public void Die()
    {
        Counter++;
        if (Counter >= 4)
        {
            Time.timeScale = 0f;
            GameOver.SetActive(true);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
