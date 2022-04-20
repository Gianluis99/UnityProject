using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{

    //Usiamo [SerializeField] per rendere visibile il campo una volta attaccato all'oggetto e di conseguenza collegare oggetti della scena allo script
    [SerializeField] private Text scoreLabel;
    [SerializeField] private SettingsPopup settingsPopup;


    // Start is called before the first frame update
    void Start()
    {
        settingsPopup.Close(); //menu chiuso non visibile
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = Time.realtimeSinceStartup.ToString();
        
    }

    public void OnOpenSettings()
    {
        //Debug.Log("Open Settings");
        settingsPopup.Open();
    }
}
