using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LifeBar : MonoBehaviour
{
    public Image lifeBar;
    public float actuaLife;
    public float maxlife;

   
    //Actualizar la barra de vida en funci�n de la vida actual 
    void UpdateLifeBar()
    {
        lifeBar.fillAmount = actuaLife / maxlife;
    }

    //Incrementa la vida 
    public void IncreaseLife(float amount)
    {
        actuaLife += amount;

        //no exceda el m�ximo de vida 
        actuaLife = Mathf.Min(actuaLife, maxlife);
        UpdateLifeBar();
    }
}
