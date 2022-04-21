using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//classe che controlla l'interfaccia ovvero glie lementi che vediamo metre giochiamo
public class UIController : MonoBehaviour
{

    //Usiamo [SerializeField] per rendere visibile il campo una volta attaccato all'oggetto e di conseguenza collegare oggetti della scena allo script
    [SerializeField] private Text scoreLabel;
    [SerializeField] private SettingsPopup settingsPopup;
    private int score;


    void Awake()
    {
        //aggingiamo il listner e dichiariamo quale metodo gestisce l'evento
        Messenger.AddListener(GameEvent.ENEMY_HIT,OnEnemyHit);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT,OnEnemyHit);
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreLabel.text = score.ToString();

        settingsPopup.Close(); //menu chiuso non visibile
    }

    //metodo che gestisce l'evento di quando si colpisce un nemico
    private void OnEnemyHit()
    {
        //si aggiorna il punteggio
        score += 1;
        scoreLabel.text = score.ToString();//si aggiorna la stringa che mostra il punteggio
    }

    // Update is called once per frame
    void Update()
    {
        //quando premiamo esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingsPopup.Open();
        }
        //scoreLabel.text = Time.realtimeSinceStartup.ToString();

    }

    public void OnOpenSettings()
    {
        //Debug.Log("Open Settings");
        settingsPopup.Open();
    }

    public void OnPointDown()
    {
        Debug.Log("pointer down");
    }
}
