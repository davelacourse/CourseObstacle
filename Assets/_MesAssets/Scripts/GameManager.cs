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


    private int _nbCollisions;
    private float _tempsFinNiveau;
    private float _tempsFinNiveau2;
    private int _accrochageNiveau1;

    
    private void Start()
    {
        _nbCollisions = 0;
    }

    public void AugmenterCollisions()
    {
        _nbCollisions++;
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
