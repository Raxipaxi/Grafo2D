using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodoGrafo : MonoBehaviour
{
    // Start is called before the first frame update
    public int valorNodo;
    public SpriteRenderer planet;
    public NodoArista arista;
    public NodoGrafo sigNodo;
    void Awake()
    {
        
        planet.enabled =  false;
    }

    public void ClickMe()
    {
        planet.enabled = true;
    }
}
