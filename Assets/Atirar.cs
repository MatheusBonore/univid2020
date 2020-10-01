using UnityEngine;

public class Atirar : MonoBehaviour
{
    public GameObject projetil;
    public int velocidade = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject projetil_inst = Instantiate(projetil, transform.position, Quaternion.identity);
            Rigidbody projetil_inst_rigidbody = projetil_inst.GetComponent<Rigidbody>();
            projetil_inst_rigidbody.AddForce(Vector3.forward * velocidade);
        }
    }
}
