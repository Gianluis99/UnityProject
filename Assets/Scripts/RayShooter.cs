using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    public Texture cursorTexture;
    public int cursorSize;

    public GameObject sniperScope; //modalità sniper
    private bool sniperMode = false;    


    void Start()
    {
        _camera = GetComponent<Camera>();
        (sniperScope.GetComponent<Renderer>()).enabled = false;

       // Cursor.lockState = CursorLockMode.Locked;
       // Cursor.visible = false;  //rendiamo invisibile il cursore del mouse
    }

    //metodo per visualizzare il puntatore che ci indicherà il bersaglio sarà al centro della camera
    void OnGUI()
    {
        if (!sniperMode)
        {
            int size = 12;
            float posX = _camera.pixelWidth / 2 - size / 4;
            float posY = _camera.pixelHeight / 2 - size / 2;
            GUI.Label(new Rect(posX, posY, size, size), "*");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())//quando clicchiamo sul tasto 0 del mouse  
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);//posizione 
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;//ritorna il punto colpito


            if(Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();//ci prendiamo il target 
                if (target != null)//se l'oggetto target(nemico) viene colpito
                {
                    //Debug.Log("Target hit");

                    target.ReactToHit();//esegue il metodo di ReactiveTarget
                }
                else//se il target non viene colpito allora sparerà a vuoto
                {
                    StartCoroutine(SphereIndicator(hit.point)); //gli passiamo al metodo il punto colpito

                }

            }



        }
        //modalità smiper aumentiamo la sensività 
        if (Input.GetMouseButtonDown(1) && !sniperMode)
        {
            _camera.fieldOfView = 10f;
            MouseLook sensVert = GetComponent<MouseLook>();
            sensVert.sensitivityVert = 1f;
            (sniperScope.GetComponent<Renderer>()).enabled = true;
            PlayerCharacter player = GetComponentInParent<PlayerCharacter>();
            MouseLook sensHor = player.GetComponent<MouseLook>();
            sensHor.sensitivityHor = 1f;
            sniperMode = true;
        }


        if (Input.GetMouseButtonUp(1) && sniperMode)
        {
            _camera.fieldOfView = 60f;
            MouseLook sensVert = GetComponent<MouseLook>();
            sensVert.sensitivityVert = 9.0f;
            (sniperScope.GetComponent<Renderer>()).enabled = false;
            
            PlayerCharacter player = GetComponentInParent<PlayerCharacter>();
            MouseLook sensHor = player.GetComponent<MouseLook>();
            sensHor.sensitivityHor = 9.0f;
            sniperMode = false;
        }

    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere); //creiamo una sphera
        sphere.transform.position = pos;    //nella posizione colpita
        //sphere.transform.localScale=newVector3(0.2f,0.2f,0.2f);
        yield return new WaitForSeconds(1);
        Destroy(sphere); //verrà distrutta dopo un secondo
    }


}
