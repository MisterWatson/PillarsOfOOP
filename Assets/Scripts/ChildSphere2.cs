using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildSphere2 : ParentSphere
{
    protected Vector3 originalSphereScale;
    protected Vector3 scaleChangeFactor = new Vector3(0.9f, 0.75f, 1.3f);

    [SerializeField] protected Material changeMaterial2;
    [SerializeField] protected Material changeMaterial3;

    private void Awake()
    {
        originalSphereScale = gameObject.transform.localScale;
        originalMaterial = gameObject.GetComponent<MeshRenderer>().material;
    }

    protected override IEnumerator ResetGameObject() // POLYMORPHISM
    {
        gameObject.transform.localScale = Vector3.Scale(gameObject.transform.localScale, scaleChangeFactor);
        gameObject.GetComponent<MeshRenderer>().material = changeMaterial;
        yield return new WaitForSeconds(1);
        gameObject.transform.localScale = Vector3.Scale(gameObject.transform.localScale, scaleChangeFactor);
        gameObject.GetComponent<MeshRenderer>().material = changeMaterial2;
        yield return new WaitForSeconds(1);
        gameObject.transform.localScale = Vector3.Scale(gameObject.transform.localScale, scaleChangeFactor);
        gameObject.GetComponent<MeshRenderer>().material = changeMaterial3;
        yield return new WaitForSeconds(1);

        // Reset sphere to original configuration
        gameObject.transform.localScale = originalSphereScale;
        gameObject.GetComponent<MeshRenderer>().material = originalMaterial;
        Debug.Log("Sphere scale and color has been reset");
        isClicked = false;
    }

}
