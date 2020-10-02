using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Tiro : MonoBehaviour
{
    public int dano = 1;
    VRInput vrInput;
    // Start is called before the first frame update
    void Awake()
    {
        vrInput = ReferenceManagerIndependent.Instance.VRInput;
    }

    private void OnEnable()
    {
        vrInput.OnClick += Disparar;
    }

    private void OnDisable()
    {
        vrInput.OnClick -= Disparar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Disparar()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            if(hit.transform.GetComponent<Inimigo>())
            {
                hit.transform.GetComponent<Inimigo>().vida -= dano;
                if (hit.transform.GetComponent<Inimigo>().vida < 0)
                    Destroy(hit.transform.gameObject);
            }
        }
        //tocar som
        //animacao de tiro
    }
}
