using System.Collections.Generic;
using UnityEngine;

public class CubeEx2Behaviour : MonoBehaviour
{
    private bool mouseInObject = false;

    public Material[] materialsColor;

    // Update is called once per frame
    void Update()
    {
        if (mouseInObject && Input.GetMouseButtonDown(0))
            this.GetComponent<Renderer>().material = materialsColor[Random.Range(0, materialsColor.Length)];
    }

    void OnMouseEnter()
    {
        mouseInObject = !mouseInObject;
    }

    void OnMouseExit()
    {
        mouseInObject = !mouseInObject;
    }
}
