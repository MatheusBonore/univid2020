using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float vida = 10;
    public float dano = 1;

    public float velocidade = 5;
    private float distancia;

    private GameObject player;
    private GameObject zombie;

    private enum ZombiStates
    {
        wait = 0,
        run = 1,
        attack = 2,
    };
    private ZombiStates currentState = ZombiStates.run;

    private AudioSource audioSource;
    public AudioClip[] zombieAttack;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        zombie = this.gameObject;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector3.Distance(player.transform.position, zombie.transform.position);

        if (distancia > 15)
            currentState = ZombiStates.wait;
        else if (distancia < 2)
            currentState = ZombiStates.attack;
        else
            currentState = ZombiStates.run;

        switch (currentState)
        {
            case ZombiStates.wait:
                startState(ZombiStates.wait);
                break;
            case ZombiStates.run:
                startState(ZombiStates.run);

                Vector3 zombiePostion = zombie.transform.position;
                zombiePostion.x += (player.transform.position.x - zombiePostion.x) * (velocidade / 1000);
                zombiePostion.z += (player.transform.position.z - zombiePostion.z) * (velocidade / 1000);
                zombiePostion.y = 0;

                zombie.transform.position = zombiePostion;

                Vector3 currentPosition = this.transform.position;
                Vector3 moveDirection = player.transform.position - currentPosition;

                float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;

                this.transform.rotation = Quaternion.Slerp(
                    this.transform.rotation,
                    Quaternion.Euler(0, targetAngle, 0),
                    distancia
                );
                break;
            case ZombiStates.attack:
                startState(ZombiStates.attack);
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 100))
                {                    
                    audioSource.clip = zombieAttack[Random.Range(0,zombieAttack.Length)];
                    audioSource.Play();

                    player.SendMessage("HitTarget", dano);
                }
                break;
            default:
                break;
        }
    }
    
    void  HitTarget(float dano)
    {
        if (vida != 0)
            vida -= dano;
        else
            Destroy(zombie);
    }

    void startState(ZombiStates newState)
    {
        currentState = newState;

        this.transform.GetComponent<Animator>().SetBool("wait", false);
        this.transform.GetComponent<Animator>().SetBool("run", false);
        this.transform.GetComponent<Animator>().SetBool("attack", false);

        switch (currentState)
        {
            case ZombiStates.wait:
                this.transform.GetComponent<Animator>().SetBool("wait", true);
                break;
            case ZombiStates.run:
                this.transform.GetComponent<Animator>().SetBool("run", true);
                break;
            case ZombiStates.attack:
                this.transform.GetComponent<Animator>().SetBool("attack", true);
                break;
            default:
                break;
        }
    }
}