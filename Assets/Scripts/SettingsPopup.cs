using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopup : MonoBehaviour
{
    // Start is called before the first frame update
   public void Open()
    {
        gameObject.SetActive(true); //rendiamo visibile il menu
    }

    public void Close()
    {
        gameObject.SetActive(false); //rendiamo non attivo il menu (non visibile)
    }

    public void OnSubmitName(string name)
    {
        Debug.Log(name);
    }

    public void OnSpeedValue(float value)
    {
        Debug.Log(value);
    }
}
