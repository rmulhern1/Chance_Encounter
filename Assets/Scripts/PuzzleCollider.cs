using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCollider : MonoBehaviour
{
    [SerializeField] GameManager gm;

    public Collider targetElement;

    public Material mat1;
    public Material mat2;

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "PuzzleElement") {
            targetElement.transform.GetComponent<MeshRenderer>().material = mat1;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Puzzle Element entered boundary");
        if (collider.gameObject.tag == "PuzzleElement") {
            gm.addPuzzleElement();
        }
    }

    /*private void OnTriggerExit(Collider collider)
    {
        Debug.Log("Puzzle Element exited boundary");
        targetElement.transform.GetComponent<MeshRenderer>().material = mat2;
        gm.minusPuzzleElement();
    }*/
}
