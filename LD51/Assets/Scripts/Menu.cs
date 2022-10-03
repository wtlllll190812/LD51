using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text text;

    public float timer=10f;
    private void Update()
    {
        timer -= Time.deltaTime;
        text.text = $"{(int)timer}";
    }
    public void QuitGame()
   {
        Application.Quit();
   }

   public void GoBackToMenu()
   {
        SceneManager.LoadScene("Menu");      
   }

   public void StartGame()
   {
       SceneManager.LoadScene("Scene1");
   }
}
