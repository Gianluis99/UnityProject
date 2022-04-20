using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")] //cambia il nome al component nell'inspector nel menu

public class FPSInput : MonoBehaviour
{
    
    public float speed = 6.0f;
    public float gravity = -9.8f; //aggiungiamo la gravità

    private CharacterController _characterController;// characterController per applciare le collisioni

    void Start()
    {
        _characterController = GetComponent<CharacterController>();//prendiampo il componente di tipo CharacterController

    }

    // Update is called once per frame
    void Update()
    {
        //prendiamo l'input
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);//nuova direzione Vector3
        movement = Vector3.ClampMagnitude(movement, speed);

        movement.y = gravity;

        movement *= Time.deltaTime;//variabile fondamentale
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);



    }
}
