using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    [SerializeField] private LayerMask Clickable;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, Mathf.Infinity, Clickable))
            {
                raycastHit.collider.GetComponent<NodoGrafo>().ClickMe();
            }

        }

    }
}
