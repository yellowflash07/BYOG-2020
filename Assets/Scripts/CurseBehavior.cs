using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurseBehavior : MonoBehaviour
{
    public GameObject sealPanel;
    public Text placeSeal;
    public Button cp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        placeSeal.gameObject.SetActive(true);
        cp.gameObject.SetActive(true);
        placeSeal.text = "Choose a seal to place, you won't be able to use it after placing";
    }

    private void OnDisable()
    {
        placeSeal.gameObject.SetActive(false);
        cp.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void PlaceSeal()
    {
        SealManager.currentSeal.isUsed = true;
    }
}
