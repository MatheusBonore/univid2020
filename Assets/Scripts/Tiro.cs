using UnityEngine;

public class Tiro : MonoBehaviour
{
    public int dano;
    public AudioClip shotSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //som de tiro
            audioSource.PlayOneShot(shotSound, 1);
            //TODO animacao de tiro

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 100))
            {
                Inimigo inimigo = hit.transform.gameObject.GetComponentInParent<Inimigo>();
                if (inimigo == null) return;

                inimigo.SendMessage("HitTarget", dano);
            }
        }
    }
}
