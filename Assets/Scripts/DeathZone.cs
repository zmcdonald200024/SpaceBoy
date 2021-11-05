using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathZone : MonoBehaviour
{
    //public Text livesText;
    public int lives;
    public Transform Player;
    public Transform respawnPoint;

     void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        Player.transform.position = respawnPoint.transform.position;
        lives--;


        if (lives < 0)
        {

            SceneManager.LoadScene("RespawnScene");
        }
        else
        {
            UIEventController.Instance.UpdateLives(lives);
        }
    }
   
}
