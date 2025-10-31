using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIGame : MonoBehaviour
{
    //Définir singleton ---------------------------------------------
    public static UIGame Instance;

    private void Awake()
    {
        if (Instance == null)
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

    [SerializeField] private TMP_Text _txtCollisions = default(TMP_Text);

    public void ChangerCollisions()
    {
        _txtCollisions.text = "Collisions : " + GameManager.Instance.NbCollisions;
    }

    public void OnQuitterClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnRecommencerClick()
    {
        GameManager.Instance.TogglePause();
        SceneManager.LoadScene(0);
        
    }
}
