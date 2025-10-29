using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Définir singleton ---------------------------------------------
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //---------------------------------------------------------------


    [SerializeField] private GameObject _panneauPause = default(GameObject);
    private int _nbCollisions;
    public int NbCollisions => _nbCollisions; // accesseur public de l'attribut _nbCollisions

    private float _tempsFinNiveau;
    private bool _enPause = false;

    
    private void Start()
    {
        _nbCollisions = 0;
        UIGame.Instance.ChangerCollisions();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        _enPause = !_enPause;
        _panneauPause.SetActive(_enPause);
        if (_enPause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void AugmenterCollisions()
    {
        _nbCollisions++;
        UIGame.Instance.ChangerCollisions();
    }

    public void FinNiveau()
    {
        // Récupérer l'index de la scène en cours
        int noScene = SceneManager.GetActiveScene().buildIndex;
        
        // Vérifie si je suis sur la dernière scène ou non
        if(SceneManager.sceneCountInBuildSettings != noScene + 1)
        {
            // Change à la scène suivante
            SceneManager.LoadScene(noScene + 1);
        }
        else
        {
            // Trouve le joueur sur ma scene et lance la méthode fin de partie
            Player player = FindAnyObjectByType<Player>();
            player.FinDePartie();

            // Affichage final
            _tempsFinNiveau = Time.time;
            Debug.Log("Fin de la partie");
            Debug.Log("Temps : " + _tempsFinNiveau.ToString("f2") + " secondes.");
            Debug.Log("Pénalité : " + _nbCollisions.ToString() + " secondes.");
            float tempsfinal = _tempsFinNiveau + _nbCollisions;
            Debug.Log("Temps final : " + tempsfinal.ToString("f2") + " secondes.");
        }
    }
}
