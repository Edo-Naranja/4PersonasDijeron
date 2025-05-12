using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Variable estática que almacena la única instancia del GameManager
    private static GameManager instancia;
    public static string lenguaje;

    // Método para obtener la instancia del GameManager
    public static GameManager Instancia
    {
        get
        {
            if (instancia == null)
            {
                // Si no existe una instancia, intentamos encontrar una en la escena
                instancia = FindFirstObjectByType<GameManager>();

                // Si no se encuentra en la escena, creamos una nueva instancia
                if (instancia == null)
                {
                    GameObject gameManagerObject = new ();
                    instancia = gameManagerObject.AddComponent<GameManager>();
                }
            }
            return instancia;
        }
    }

    // Método para inicializar el GameManager (puede ser llamado desde otro script)
    public void Initialize()
    {
        Invoke(nameof(ToStart),3f);
    }

    // Aquí puedes agregar más métodos y lógica de juego según tus necesidades
    private void Awake()
    {
        // Asegura que solo haya una instancia del GameManager
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // Evita que el objeto se destruya al cargar una nueva escena
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruye esta
        }
    }
    private void Start()
    {
        // Inicializa el GameManager cuando comienza el juego
        Initialize();
    }
   
    public void SaveBool(string key, bool value)
    {
        // Convertir el bool a int (true -> 1, false -> 0)
        PlayerPrefs.SetInt(key, value ? 1 : 0);

        // Guardar los cambios
        PlayerPrefs.Save();
    }
    bool LoadBool(string key)
    {
        // Cargar el valor como int y convertirlo a bool
        return PlayerPrefs.GetInt(key) == 1; // 1 -> true, 0 -> false
    }
    public void CargarEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }
    private void ToStart()
    {
        CargarEscena("Start");
    }
    
}
