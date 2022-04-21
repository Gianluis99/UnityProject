using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//classe che gestisce la logica dei nemici
public class WanderingAI : MonoBehaviour
{

    public float speed = 3.0f;
    public const float basespeed = 3.0f;

    public float obstacleRange = 5.0f;
    private bool _alive;
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnSpeedChanged(float value)
    {
        speed = basespeed * value;
    }

    void Start()
    {
        _alive = true;// inizialmente settiamo la variabile vivo a true   
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_alive) //solo se il target è vivo si translerà
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            //utilizziamo il ray dove gli passiamo la posizione iniziale dell'enemy tramite tranform.position
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit; //utilizziamo il raycast in questo caso la sphereCast
           

            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                //creiamo la sfera quando noi ci troviamo nello spherecast del nemico
                //in modo tale che esso possa colpirci solo quando ci troviamo di fronte ad esso
                GameObject hitObject = hit.transform.gameObject;//il nemico grazie a questo di rende conto se ha un ostacolo di fronte

                //se il player è nel raggio dello spherecast
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if(_fireball == null)
                    {
                        //instanziamo la fireball
                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        

                        _fireball.transform.position =
                            transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRange)//se il ray incontra un ostacolo allora si sposta
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    public void setAlive(bool alive)
    {
        _alive = alive;

    }

    public bool getAlive()
    {
        return this._alive;
    }
}
