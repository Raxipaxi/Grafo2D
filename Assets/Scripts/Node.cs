using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    // Start is called before the first frame update
        public int info;
        public GameObject planet;
        public Node sig;


        void Awake()
        {
            planet = gameObject;
        }
        // void Update()
        // {

        // }
}
