using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Transform player;
    public float velocidade;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(0, targetAngle, 0), velocidade);
    }
}
