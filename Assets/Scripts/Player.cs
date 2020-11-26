using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float vida = 20;

    private GameObject remedio;

    private AudioSource audioSource;
    public AudioClip shotSound;

    // Start is called before the first frame update
    void Start()
    {
        remedio = GameObject.Find("Remedio");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 100))
            {
                if (hit.transform.gameObject == remedio)
                {
                    vida += 50;
                    remedio.SendMessage("HitTarget");
                }
            }
        }
    }
    
    public void HitTarget(float dano)
    {
        if (vida == 0)
            GameOver();
        else
        {
            audioSource.clip = shotSound;
            audioSource.Play();
            vida -= dano;
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("ZombieBasicos");
    }
}
