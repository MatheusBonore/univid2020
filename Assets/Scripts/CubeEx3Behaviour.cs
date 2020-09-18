using UnityEngine;

public class CubeEx3Behaviour : MonoBehaviour
{
    private bool mouseInObject = false;

    public AudioSource audioBeep;

    // Update is called once per frame
    void Update()
    {
        if (mouseInObject && Input.GetMouseButtonDown(0))
            audioBeep.Play();
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
