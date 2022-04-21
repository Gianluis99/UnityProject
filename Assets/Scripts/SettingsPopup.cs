using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//classe che gestisce il popup menu
public class SettingsPopup : MonoBehaviour
{

     [SerializeField] private  Text nameLabel;
     [SerializeField] private Image aim;



    // Start is called before the first frame update
    public void Open()
    {
        gameObject.SetActive(true); //rendiamo visibile il menu
        aim.enabled = false;
        PauseGame();//quando apriamo il menu mettiamo il gioco in pausa
    }

    


public void Close()
    {
        gameObject.SetActive(false); //rendiamo non attivo il menu (non visibile)
        aim.enabled = true;
        UnPauseGame();

    }

    public void OnSubmitName(string name)
    {
        nameLabel.text = name;
    }


    //questo metodo notifica il messenger quando ci saraà un cambiamento delle impostazioni e gli passa il valore spped

    public void OnSpeedValue(float value)
    {
        Debug.Log(value);
        //quando viene cambiato il valore  allora notifica il messenger e gli passa un float 
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, value);

    }

    public void PauseGame()
    {
        GameEvent.isPaused = true;//mettiamo a true la variabile in GameEvent 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void UnPauseGame()
    {
        GameEvent.isPaused = false;//mettiamo a false la variabile in Gameevnt
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
}
