using UnityEngine;

public class Remedio : MonoBehaviour
{
    private GameObject remedio;

    // Start is called before the first frame update
    void Start()
    {
        remedio = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void HitTarget()
    {
        Destroy(remedio);
    }
}
