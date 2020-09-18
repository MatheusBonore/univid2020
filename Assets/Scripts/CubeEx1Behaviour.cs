using UnityEngine;

public class CubeEx1Behaviour : MonoBehaviour
{
    private bool mouseInObject = false;
    public GameObject hiddenObject;

    // Update is called once per frame
    void Update()
    {
        if (mouseInObject && Input.GetMouseButtonDown(0))
        {
            hiddenObject.GetComponent<Renderer>().enabled = !hiddenObject.GetComponent<Renderer>().enabled;
            hiddenObject.GetComponent<Collider>().enabled = hiddenObject.GetComponent<Renderer>().enabled;
        }
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
