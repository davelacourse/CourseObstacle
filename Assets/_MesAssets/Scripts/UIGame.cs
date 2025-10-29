using UnityEngine;
using TMPro;

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
}
