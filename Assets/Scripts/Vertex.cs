using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex : MonoBehaviour
{
    public GameObject[] Vertexs;
    float[] closestDist =  new float[2] {Mathf.Infinity , Mathf.Infinity};
    GameObject[] closestObj = new GameObject[2];

    // Start is called before the first frame update
    void Awake()
    {
       Vertexs = GameObject.FindGameObjectsWithTag("Vertex");  
       GetCloseVertexs();

    }

    void GetCloseVertexs()
    { 
        Vector2 position =  transform.position;

        foreach (var vertex in Vertexs)
        {
            Vector2 diff = (Vector2)vertex.transform.position - position;
            float curDistance =  diff.sqrMagnitude;
            if (curDistance!=0)
            {
                if (curDistance < closestDist[0])
                {
                    closestDist[0] = curDistance;
                    closestObj[0] = vertex;

                } else if (curDistance < closestDist[1])
                {
                    closestDist[1] = curDistance;
                    closestObj[1] = vertex; 
                }
            }
        }
    }

    // Update is called once per frame

}
