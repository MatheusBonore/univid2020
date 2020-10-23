using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Transform player;
    public float velocidade;

    private float andandoVelocidade;
    private int morreu = 0;
    private bool atacando = false;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (morreu.Equals(0))
        {
            andandoVelocidade = 0.2f;
            // Movimentação
            Vector3 zombie = this.transform.position;
            zombie.x += (player.position.x - zombie.x) * velocidade;
            zombie.z += (player.position.z - zombie.z) * velocidade;
            zombie.y = 0;

            this.transform.position = zombie;

            // Rotação
            Vector3 currentPosition = this.transform.position;
            Vector3 moveDirection = player.position - currentPosition;

            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;

            this.transform.rotation = Quaternion.Slerp(
                this.transform.rotation,
                Quaternion.Euler(0, targetAngle, 0),
                Time.deltaTime
            );
        }

        atualizaParametrosAnimador();
    }

    void atualizaParametrosAnimador()
    {
        animator.SetFloat("velocidade", andandoVelocidade);
        animator.SetInteger("morreu", morreu);
        animator.SetBool("atacando", atacando);
    }
}