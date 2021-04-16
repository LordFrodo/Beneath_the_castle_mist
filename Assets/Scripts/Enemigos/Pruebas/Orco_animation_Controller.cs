using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orco_animation_Controller : Enemy_Animation_Controller
{
    
  
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(enemigo.transform.position, jugador.transform.position) < distancia && vida_enemigo.barra_vida.fillAmount > 0.3)
        {
            tiempo += Time.deltaTime;
            if(Walking_Audio!=null)Walking_Audio(true);

            animator.SetBool("Walking", false);
            
            if (tiempo > 3f)
            {
                animator.SetTrigger("Attack");
                print("Ataque_mamon");
                tiempo = 0;
            }
        }

        else if (Vector3.Distance(enemigo.transform.position, jugador.transform.position) > distancia && vida_enemigo.barra_vida.fillAmount > 0.3)
        {
            animator.SetBool("Walking", true);
            if (Walking_Audio != null) Walking_Audio(true);
        }
        else if (Vector3.Distance(enemigo.transform.position, jugador.transform.position) > distancia && vida_enemigo.barra_vida.fillAmount < 0.3&&vida_enemigo.barra_vida.fillAmount>0)
        {
            animator.SetBool("Walking", false);
            if (Walking_Audio != null) Walking_Audio(false);
            animator.SetBool("Shield", true);
        }
        else if(Vector3.Distance(enemigo.transform.position, jugador.transform.position) < distancia && vida_enemigo.barra_vida.fillAmount < 0.3 && vida_enemigo.barra_vida.fillAmount > 0)
        {
            tiempo += Time.deltaTime;

            animator.SetBool("Walking", false);
            if (Walking_Audio != null) Walking_Audio(false);
            animator.SetBool("Shield", true);
            if (tiempo > 3f)
            {
                animator.SetBool("Shield", false);
                animator.SetTrigger("Attack");
                tiempo = 0;
            }
        }

        else
        {
            animator.SetBool("Walking", false);
            animator.SetBool("Shield", false);
            animator.SetBool("Die", true);
        }
    }
}
