using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Skill : MonoBehaviour
{
    public string sealName;
    public string description;
    public int useTime;
    public int rechargeTime;
    public Text sealText;
    public Text descriptionText;
    public Text rechargeText;
    public bool isUsed;
    public bool isActive;
    public bool isRecharging;
    public bool sealSelected;

    int currentUseTime, currentRechargeTime;

    public void SetupUI()
    {
        sealText.text = sealName;
        descriptionText.text = description;
    }

    public void InvokeTimer()
    {
        currentUseTime = useTime;
        currentRechargeTime = rechargeTime;
        InvokeRepeating("UseTimer", 0, 1);
    }

    public void ResetTimer()
    {
        currentUseTime = useTime;
        currentRechargeTime = rechargeTime;
    }

    public void UseTimer()
    {
        if (isActive)
        {
            if (currentUseTime > 0)
            {
                currentUseTime--;
                currentRechargeTime = rechargeTime;
                rechargeText.text = "Seal will expire in:-" + currentUseTime.ToString();
            }
            if (currentUseTime <= 0)
            {
                currentUseTime = 0;
                isActive = false;                
                isRecharging = true;                
            }
        }
        else if (isRecharging)
        {
            currentRechargeTime--;
            rechargeText.text = "Seal will recharge in:-" + currentRechargeTime.ToString();
            if (currentRechargeTime <= 0)
            {                
                currentRechargeTime = 0;
                isRecharging = false;
                rechargeText.text = "Ready to use";
                currentUseTime = useTime;
            }
        }
        else if (!isActive)
        {
            rechargeText.text = "Seal not active";
        }

        if (isUsed)
        {
            rechargeText.text = "This seal is no longer available";
        }
    }

}
