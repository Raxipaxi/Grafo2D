using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] NodoGrafo[] Planets;
    [SerializeField] private LayerMask Clickable;
    [SerializeField] Button Bcalculate;
    [SerializeField] Text Tcost;
    int[] origin = { 1, 1, 2, 2, 3, 3, 4, 5, 6, 6, 7, 7, 8, 9, 10, 10, 11 };
    int[] destination = { 2, 3, 4, 5, 4, 6, 8, 10, 8, 7, 9, 11, 9, 11, 9, 12, 12 };
    int[] cost = { 8, 2, 4, 9, 3, 5, 3, 7, 2, 1, 9, 15, 6, 11, 1, 8, 4 };
    int[] vertices = {1,2,3,4,5,6,7,8,9,10,11,12};

    int[] path;
    int pathindex = 0;
    public GrafoLA graph;
    public ConjuntoLD selectedPlanets;
    void Start()
    {  
        Bcalculate.onClick.AddListener(CalculateCost);
        path = new int[Planets.Length];
        graph = new GrafoLA();
        selectedPlanets = new ConjuntoLD();
        graph.InicializarGrafo();
        LoadGraph();
    }
    void LoadGraph()
    {
        // agrego los vértices
     
        for (int i = 0; i < vertices.Length; i++)
        {
            //graph.AgregarVertice(Planets[i].valorNodo);
            graph.AgregarVertice(vertices[i]);       
        }
        // agrego las aristas
        for (int i = 0; i < cost.Length; i++)
        {
            graph.AgregarArista(origin[i], destination[i], cost[i]);
        }
        // Listado de Nodos
        PrintNodesTags();
        // Listado de Aristas
        PrintEdges();
    }
    void PrintNodesTags()
    {
        print("\nListado de Etiquetas de los nodos");
        NodoGrafo aux = graph.origen;
        while (aux != null)
        {
            print("\n " + aux.valorNodo);
            aux = aux.sigNodo;
        }
    }
    void PrintEdges()
    {
        print("\nListado de Aristas (Inicio, Fin, Peso)");
        NodoGrafo aux = graph.origen;
        NodoArista aristAux = aux.arista;
        while (aux != null)
        {
            print("\n Nodo :" + aux.valorNodo);
            if (aux.arista != null)
            {
                aristAux = aux.arista;
                print("\n Nodo Destino " + aux.arista.nodoDestino.valorNodo + " peso " + aux.arista.pesoArista);
                aristAux = aristAux.sigArista;
                while (aristAux != null)
                {
                    print("\n Nodo Destino " + aristAux.nodoDestino.valorNodo + " peso " + aristAux.pesoArista);
                    aristAux = aristAux.sigArista;
                }
            }

            aux = aux.sigNodo;

        }
    }

        // Update is called once per frame
    void Update()
    {
       // SelectPlanets();
        CheckSelected();
    }
    //void SelectPlanets()
    //{
        

    //}
    void CheckSelected()
    {
        bool selected = false;
        for (int i = 0; i < Planets.Length; i++)
        {
            
            if (Planets[i].planet.enabled)
            {
                
                if (pathindex>0)
                {
                    for (int j = 0; j < pathindex; j++)
                    {
                        if (path[j] == Planets[i].valorNodo)
                        {
                            selected = true;
                        }
                    }
                    if (!selected)
                    {
                        path[pathindex++] = Planets[i].valorNodo;
                        
                    }
                }
                else
                {
                    path[pathindex++] = Planets[i].valorNodo;
                }
                
                selected = false;
            }
        }
        

    }   
    void CalculateCost()
    {
        bool bFoundNode;
        bool bFoundEdge;
        int finalcost = 0;
        NodoGrafo tempNode;
        NodoArista tempEdge;

        for (int i = 0; i < path.Length && path[i] != 0; i++)
        {
            print("Path Nodes " + path[i]);  
        }

        for (int i = 0; i < path.Length-1 && path[i]!=0; i++)
        {
            bFoundNode = false;
            bFoundEdge = false;
            tempNode = graph.origen;
            while (tempNode != null || !bFoundNode)
            {
                print("Nodo :" + path[i]);
                if (path[i] == tempNode.valorNodo)
                {
                    bFoundNode = true;
                    tempEdge = tempNode.arista;
                        
                    while (tempEdge != null || !bFoundEdge)
                    {
                        if (tempEdge.nodoDestino.valorNodo == path[i + 1])
                        {
                            bFoundEdge = true;
                            finalcost = finalcost + tempEdge.pesoArista;
                            print("Nodo : " + tempNode.valorNodo + " Costo hasta ahora : " + finalcost);
                        }                             
                        tempEdge = tempEdge.sigArista;
                    }                        
                } 
                tempNode = tempNode.sigNodo;
                
            }
        }
        Tcost.text =  finalcost.ToString();
    }

}
