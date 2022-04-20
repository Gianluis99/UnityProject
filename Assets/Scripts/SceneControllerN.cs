using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControllerN : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject[] _enemies;
    public int enemiesCount;

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

            }
        }
        
    }
}
