using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildSphere : ParentSphere
{
    protected Vector3 originalSphereScale;
    protected Vector3 scaleChangeFactor = new Vector3(0.8f, 0.8f, 0.8f);

    private void Awake()
    {
        originalSphereScale = gameObject.transform.localScale;
    }

    protected override void OnMouseDown() // POLYMORPHISM
    {
        if (isClicked == false)
        {
            Debug.Log("Clicked the sphere");
            isClicked = true;
            StartCoroutine(ResetGameObject());
        }
    }

    protected override IEnumerator ResetGameObject() // POLYMORPHISM
    {
        gameObject.transform.localScale = Vector3.Scale(gameObject.transform.localScale, scaleChangeFactor) ;
        yield return new WaitForSeconds(1);
        gameObject.transform.localScale = Vector3.Scale(gameObject.transform.localScale, scaleChangeFactor);
        yield return new WaitForSeconds(1);
        gameObject.transform.localScale = Vector3.Scale(gameObject.transform.localScale, scaleChangeFactor);
        yield return new WaitForSeconds(1);
        gameObject.transform.localScale = originalSphereScale;
        Debug.Log("Sphere scale has been reset");
        isClicked = false;
    }

}
