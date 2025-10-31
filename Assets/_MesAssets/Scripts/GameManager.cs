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

    private float _tempsDepart;
    
    private float _tempsFinNiveau;
    public float TempsFinNiveau => _tempsFinNiveau;
    
    private bool _enPause = false;

    
    private void Start()
    {
        _nbCollisions = 0;
        _tempsDepart = Time.time;
        UIGame.Instance.ChangerCollisions();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            TogglePause();
        }
    }

    public void TogglePause()
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
        
        // Si je suis à la scene finale calcule le temps
        if(SceneManager.sceneCountInBuildSettings == noScene + 2)
        {
            _tempsFinNiveau = Time.time - _tempsDepart;
        }

        SceneManager.LoadScene(noScene + 1);
    }
}
