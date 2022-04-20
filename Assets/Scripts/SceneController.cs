using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour 
{
    [SerializeField] private GameObject enemyPrefab; //aggangiamo il prefab al controller con seralizeField lo vediamo nell'inspector
    private GameObject _enemy;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject; //instanziamo l'oggetto prefab
            _enemy.transform.position = new Vector3(0, 1, 0); //gli assegnamo l aposizione all'oggetto
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
        
    }
}
