using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SealManager : MonoBehaviour
{

    public static Skill currentSeal;
    public Text timeLeft;
    public Text rechargeTime;
    public Collider playerSphere,playerCollider;
    GameObject[] inLights;

    // Start is called before the first frame update
    void Start()
    {
        inLights = GameObject.FindGameObjectsWithTag("inLights");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSeal != null)
        {
            if (currentSeal.sealSelected && !currentSeal.isUsed)
            {
                rechargeTime.text = "Selected" + " " +currentSeal.sealName;

                currentSeal.ResetTimer();

                if (!currentSeal.isRecharging)
                {                    
                    if (currentSeal.sealName == "Seal of Asura")
                    {
                        Debug.Log("called");
                        StartCoroutine(SealOfAsura());
                        ResetDarcySeal();
                        ResetRaijinSeal();
                    }

                    if (currentSeal.sealName == "Seal of Raijin")
                    {
                        StartCoroutine(SealOfRaijin());
                        ResetDarcySeal();
                        ResetAsuraSeal();
                    }

                    if (currentSeal.sealName == "Seal of Darcy")
                    {
                        StartCoroutine(SealOfDarcy());
                        ResetAsuraSeal();
                        ResetRaijinSeal();
                    }
                }
                else if (currentSeal.isRecharging)
                {
                    rechargeTime.text = "Seal is recharging";
                }

                currentSeal.sealSelected = false;
            }
        }
        else
        {
            timeLeft.text = "Select a seal";            
        }
    }

    IEnumerator SealOfAsura()
    {       
        playerSphere.enabled = false;
        yield return new WaitForSeconds(currentSeal.useTime);
      //  currentSeal.isActive = false;
        playerSphere.enabled = true;
    }

    void ResetAsuraSeal()
    {
        playerSphere.enabled = true;
    }

    IEnumerator SealOfRaijin()
    {
        foreach (var light in inLights)
        {
            light.GetComponent<Light>().intensity =  1.5f;
        }
        yield return new WaitForSeconds(currentSeal.useTime);
      //  currentSeal.isActive = false;
        foreach (var light in inLights)
        {
            light.GetComponent<Light>().intensity = 1.2f;
        }
    }

    void ResetRaijinSeal()
    {
        foreach (var light in inLights)
        {
            light.GetComponent<Light>().intensity = 1.2f;
        }
    }

    IEnumerator SealOfDarcy()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls)
        {
            wall.GetComponent<BoxCollider>().enabled = false;
        }
        yield return new WaitForSeconds(currentSeal.useTime);
      //  currentSeal.isActive = false;
        foreach (var wall in walls)
        {
            wall.GetComponent<BoxCollider>().enabled = true;
        }
    }

    void ResetDarcySeal()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls)
        {
            wall.GetComponent<BoxCollider>().enabled = true;
        }
    }


}
