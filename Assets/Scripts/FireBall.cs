using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime); //moviamo la sfera sull'asse z

    }

    //quando il nostro plyayer viene colpito dalla fireball c'è una collisione 
    void OnTriggerEnter(Collider other)
    {
        //se è il nostro player è presente nel collider 
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.hurt(damage); //mettiamo solo player poiche il player ha attaccato a se PlayerCharacter e qundi lo vedrà automaticamnete 
        }

        Destroy(this.gameObject);
    }
}
