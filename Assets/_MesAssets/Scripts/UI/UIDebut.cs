using UnityEngine;
using UnityEngine.SceneManagement;

public class UIDebut : MonoBehaviour
{
    [SerializeField] private GameObject _panneauInstructions = default(GameObject);

    private void Awake()
    {
        // Vérifie s'il existe un GameManager si oui on le détruit
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        UIGame uiGame = FindAnyObjectByType<UIGame>();
        if (gameManager != null) 
        {
            Destroy(gameManager.gameObject);
        }

        if (uiGame != null)
        {
            Destroy(uiGame.gameObject);
        }

    }

    public void OnQuitterClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnInstructionsClick()
    {
        _panneauInstructions.SetActive(true);
    }

    public void OnDemarrerClick()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }

    public void OnFermerClick()
    {
        _panneauInstructions.SetActive(false);
    }
}
