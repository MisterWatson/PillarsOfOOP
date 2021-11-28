using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentSphere : MonoBehaviour
{
    [SerializeField] protected Material originalMaterial; // ENCAPSULATION
    [SerializeField] protected Material changeMaterial; 

    [SerializeField] protected int resetTimer = 3;

    [SerializeField] protected bool isClicked = false;

    private void Awake()
    {
        originalMaterial = gameObject.GetComponent<MeshRenderer>().material;
    }

    protected virtual void OnMouseDown() // POLYMORPHISM
    {
        if (isClicked == false)
        {
            Debug.Log("Clicked the sphere");
            isClicked = true;
            gameObject.GetComponent<MeshRenderer>().material = changeMaterial;
            StartCoroutine(ResetGameObject());
        }
    }

    protected virtual IEnumerator ResetGameObject()
    {
        yield return new WaitForSeconds(resetTimer);
        gameObject.GetComponent<MeshRenderer>().material = originalMaterial;
        isClicked = false;
        Debug.Log("Sphere color has been reset");
    }

}
