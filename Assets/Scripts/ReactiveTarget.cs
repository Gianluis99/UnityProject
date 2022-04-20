using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{

    private WanderingAI behavior;
    private bool die = false; //variabile che ci permette di eseguire l'effetto morte una sola volta
    public void ReactToHit()
    {
        behavior = GetComponent<WanderingAI>();
        if(behavior != null)  //quando viene colpito settiamo alive a false
        {
            behavior.setAlive(false);
        }
        StartCoroutine(Die());  //quando l'oggetto viene colpito startiamo la courotine che esegue Die

    }

   
    private  IEnumerator Die()
    {
        if (!behavior.getAlive() && !die)
        {
            die = true;
            this.transform.Rotate(-75, 0, 0); //fa ruotare l'oggetto
            yield return new WaitForSeconds(1.6f);//aspetta 1.6f

            Destroy(this.gameObject);//elimina l'oggetto
        }
    }



    
}
