using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    // IMPLEMENTACIÓN DINÁMICA //
public class ConjuntoLD : iConjunto
{
 Node c;
 public void InicializarConjunto()
 {
     c = null; 
 }
 public bool ConjuntoVacio()
 {
     return (c == null);
 }
 public void Agregar(int x)
 {
     /* Verifica que x no este en el conjunto */
     if (!this.Pertenece(x))
     {
         Node aux = new Node();
         aux.info = x;
         aux.sig = c;
         c = aux;
     }
 }
 public int Elegir()
 {
     return c.info;
 }
 public void Sacar(int x)
 {
     if (c != null)
     {
         // si es el primer elemento de la lista
         if (c.info == x)
         {
             c = c.sig;
         }
         else
         {
             Node aux = c;
             while (aux.sig != null && aux.sig.info != x)
                 aux = aux.sig;
             if (aux.sig != null)
                 aux.sig = aux.sig.sig;
         }
     }
 }
 public bool Pertenece(int x)
 {
     Node aux = c;
     while ((aux != null) && (aux.info != x))
     {
         aux = aux.sig;
     }
     return (aux != null);
 }
 } 