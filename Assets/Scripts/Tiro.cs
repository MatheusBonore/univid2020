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

    //APENAS PARA TESTE NO UNITY
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 100))
            {
                Inimigo inimigo = hit.transform.gameObject.GetComponentInParent<Inimigo>();
                if (inimigo == null) return;

                //TODO tocar som
                //TODO animacao de tiro

                inimigo.SendMessage("HitTarget", dano);
            }
        }
    }

    public void Disparar()
    {
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.position, out RaycastHit hit, 100))
        {
            Inimigo inimigo = hit.transform.GetComponent<Inimigo>();
            if (inimigo == null) return;

            //TODO tocar som
            //TODO animacao de tiro

            inimigo.SendMessage("HitTarget", dano);
        }
    }
}
