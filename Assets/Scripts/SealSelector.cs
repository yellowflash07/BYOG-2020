using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SealSelector : MonoBehaviour
{
    Toggle[] toggles;
    Seal[] seals;
    // Start is called before the first frame update
    void Start()
    {
        toggles = FindObjectsOfType<Toggle>();
        seals = FindObjectsOfType<Seal>();
        foreach (var seal in seals)
        {
            seal.InvokeTimer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.gameObject.activeInHierarchy)
            transform.position = Input.mousePosition;
        foreach (var toggle in toggles)
        {
            if (!toggle.isOn)
                toggle.GetComponent<Seal>().isActive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Seal seal = collision.GetComponent<Seal>();
        SealManager.currentSeal = seal;
        if (!collision.GetComponent<Seal>().isRecharging)
        {
            collision.GetComponent<Toggle>().isOn = true;
            seal.sealSelected = true;
            seal.isActive = true;
            seal.rechargeText.text = "Ready to use";
            
        }
        else if(collision.GetComponent<Seal>().isRecharging)
        {
           // seal.rechargeText.text = "Recharging..";
        }
    }
}
