using UnityEngine;
using Unity.Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineCamera[] cameras;
    private int currentCameraIndex = 0;
    
    private void Start()
    {
        // Activar la primera cámara al inicio
        SwitchCamera(currentCameraIndex);
    }
    
    public void SwitchCamera(int newCameraIndex)
    {
        // Validar índice
        if (newCameraIndex < 0 || newCameraIndex >= cameras.Length) return;
        
        // Desactivar todas las cámaras
        foreach (var cam in cameras)
        {
            cam.Priority = 0;
        }
        
        // Activar la cámara seleccionada
        cameras[newCameraIndex].Priority = 10;
        currentCameraIndex = newCameraIndex;
    }
    
    // Ejemplo de uso con teclado
    public void CambiarCamara()
    {
        int nextIndex = (currentCameraIndex + 1) % cameras.Length;
        SwitchCamera(nextIndex);
    }
    
}
