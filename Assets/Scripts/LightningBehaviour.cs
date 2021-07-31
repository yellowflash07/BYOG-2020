using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightningBehaviour : MonoBehaviour
{
    public GameObject lights;
    AudioSource thunderSFX;
    int timer = -1;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("StartTimer", 0, 1);
        thunderSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartLightning();
        }        
    }

    private void OnEnable()
    {
        timerText.gameObject.SetActive(true);
    }
    private void OnDisable()
    {
        timerText.gameObject.SetActive(false);
    }

    void StartLightning()
    {
        if (timer <= 0)
        {
            thunderSFX.Play();
            StartCoroutine(StartLightningCO());
            timer = 15;
        }
    }

    IEnumerator StartLightningCO()
    {
        lights.SetActive(true);
        foreach (var light in lights.GetComponentsInChildren<Light>())
        {
            light.GetComponent<Animator>().Play("Lightning");
        }
        yield return new WaitForSeconds(1.2f);
        lights.SetActive(false);
    }


    void StartTimer()
    {       
        timer--;
        if (timer <= 0)
        {
            timer = 0;
            timerText.text = "Summon lightning now";
        }
        else
        {
            timerText.text = "Summon lightning in:-" + timer.ToString();
        }

    }



}
