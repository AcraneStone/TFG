using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public CombatManager combat;
    public Evento[] eventos;
    private Evento activeEvent;
    public float tiempo = 60f;//en segs
    private int temp=0;
     private Coroutine corutina;

    // Start is called before the first frame update
    void Start()
    {
         InvokeRepeating("efecto", tiempo, tiempo); 
    }
    private void efecto(){
        if(combat.getIsCombatActive() == false){
            if(temp ==0){
                
                    int i = escogerEvento();
                    combat.setActivePanel(true);
                    // Debug.Log("temp "+ temp);
                    eventos[i].active = true;
                    eventos[i].efecto();
                    activeEvent = eventos[i];
                    temp++;
                    corutina = StartCoroutine(quitarPanel());
                
            }
            else{
                
                activeEvent.desactivar();
                Debug.Log("hola");
                temp--;
                corutina = StartCoroutine(quitarPanel());
            }
        }
        
    }

    private IEnumerator quitarPanel(){
          if(combat.getIsCombatActive() == false){
         yield return new WaitForSeconds(3f);
         Debug.Log("quitamos panel");
         combat.setActivePanel(false);
         StopCoroutine(corutina);
       // Quitamos panel
          }
    }

    private int escogerEvento(){
        return 2;//Random.Range(0, eventos.Length-1);
       
    }
   
}
