using UnityEngine;

public class BotonAsiste : MonoBehaviour
{
    public void BotonEscena(string escena)
    {
        GameManager.Instancia.CargarEscena(escena);
    }
}
