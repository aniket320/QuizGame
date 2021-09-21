using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameplay : MonoBehaviour
{
    public GameObject[] Levels;
    int currentlevel;
    private float timer = 15f;
    public GameObject retry;
    public Slider time;
    public GameObject wrong;
    public AudioSource tim;
    public AudioSource vic;
    public AudioSource fail;
    public Toggle vol;
    public GameObject stars;
    public GameObject ban;
    private float Life=0;
    public Text lif;
    public Text btimer;
    private float btime = 30f;
    // Start is called before the first frame update
    void Start()
    {
        load();
        stars.SetActive(true);  ///partical system
        if (PlayerPrefs.GetInt("volt") == 1)   ///TOGGLE
        {
            vol.isOn = true;
        }
        else
        {
            vol.isOn = false;
        }
        time.value = timer;
        
    }

    
    // Update is called once per frame
    void Update()
    {
        save();
        lif.text=Mathf.Round (Life).ToString();
        time.value = timer -= 1 * Time.deltaTime; ////slider timer
        btimer.text = Mathf.Round(btime).ToString();
        btime-=1 * Time.deltaTime;

        if (Life < 0)
        {
            Life = 0f;
            ban.SetActive(true);
            btime = 30f;
            Life = +2;
        }

        if (btime <= 0)
        {
            btime = 0;
            ban.SetActive(false);
           
        }
        if (timer >= 6)
        {
            tim.Play();
        }

        if (timer <= 1)
        {
            timer = 0;
            retry.SetActive(true);
        }
        else
        {
            retry.SetActive(false);
        }


        if (vol.isOn == true)           ///TOGGLE
        {
            PlayerPrefs.SetInt("volt", 1);
        }

        else
        {
            PlayerPrefs.SetInt("volt", 0);
        }
    }

  
    public void back()   ///BUTTON
    {
        SceneManager.LoadScene("menu");
    }

    public void Correctans()      ///BUTTON
    {
       
        vic.Play();
        Levels[currentlevel].SetActive(false);
        currentlevel++;
        Levels[currentlevel].SetActive(true);
        timer = 15f;
        Life += 0.40f;
        //if (currentlevel + 1 != Random.Range(0,Levels.Length)){}
    }

   
    
    public void WrongAns()
    {
        fail.Play();
        Life--;
        Handheld.Vibrate();
        wrong.SetActive(true);
        //Debug.Log("vibrating");
    }

    public void tryb()    ///BUTTON
    {
        timer = 15f;
        retry.SetActive(false);
    }

    private void save()
    {
       PlayerPrefs.SetInt("que", currentlevel);
       PlayerPrefs.SetFloat("extra", Life);
    }
    private void load()
    {
        currentlevel = PlayerPrefs.GetInt("que");
        Life = PlayerPrefs.GetFloat("extra");
    }


    public void sce() ///wrong panel try button
    {
        wrong.SetActive(false);
    }
    public void last()
    {
        SceneManager.LoadScene("menu");  ////fore Last Question of game
    }

}
