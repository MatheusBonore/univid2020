using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int vida = 10;

    public void HitTarget(int dano)
    {
        if (vida == 0)
        {
            Destroy(this.gameObject);
        } else
        {
            vida -= dano;
        }
    }
}
