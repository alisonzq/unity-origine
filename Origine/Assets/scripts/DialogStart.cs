using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogStart : MonoBehaviour
{
    public GameObject dialog;
    public GameObject graph;
    public GameObject removeGraph;

    void OnCollisionEnter2D(Collision2D other)
    {
        dialog.SetActive (true);
        gameObject.SetActive(false);
        if(graph != null)
        {
            graph.SetActive(true);
        }

        if(removeGraph != null)
        {
            removeGraph.SetActive(false);
        }
        
    }

}
