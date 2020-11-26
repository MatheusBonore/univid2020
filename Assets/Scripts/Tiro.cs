using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float dano;

    private GameObject zombie;

    private AudioSource audioSource;
    public AudioClip shotSound;

    private void Start()
    {
        zombie = GameObject.Find("Zombie");

        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            audioSource.PlayOneShot(shotSound, 1);

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 100))
            {
                if (hit.transform.gameObject == zombie)
                    zombie.SendMessage("HitTarget", dano);
            }
        }
    }
}
