using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections;

public class mainmenu : MonoBehaviour
{
    public GameObject confirm;
    public void Play()
    {
        SceneManager.LoadScene("game");
        
    }
  
    public void quit()
    {
            Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            confirm.SetActive(true);
        }
    }


}

