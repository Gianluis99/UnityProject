using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//classe che gestsce la creazione dei nemici
public class SceneControllerN : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject[] _enemies;
    public int enemiesCount;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        _enemies = new GameObject[enemiesCount];
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < _enemies.Length; i++)
        {
            if (_enemies[i] == null)
            {
                //instaziazione di n nemici
                _enemies[i] = Instantiate(enemyPrefab, new Vector3(Random.Range(1f, 5f), 1f, Random.Range(1f, 5f)),
                 Quaternion.Euler(0, Random.Range(0, 360f), 0));
                _enemies[i].GetComponent<WanderingAI>().speed = speed;


            }
        }
        
    }



    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED,UpdateNewEnemiesSpeed);
    }
    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, UpdateNewEnemiesSpeed);
    }

    private void UpdateNewEnemiesSpeed(float speed)
    {
        this.speed = WanderingAI.basespeed * speed;  
    }
}
