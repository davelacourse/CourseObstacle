using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIFin : MonoBehaviour
{

    [SerializeField] private TMP_Text _txtTemps = default(TMP_Text);
    [SerializeField] private TMP_Text _txtCollisions = default(TMP_Text);
    [SerializeField] private TMP_Text _txtFinal = default(TMP_Text);

    private void Start()
    {
        _txtTemps.text = "Temps : " + GameManager.Instance.TempsFinNiveau.ToString("f2") + " secondes";
        _txtCollisions.text = "Collisions : " + GameManager.Instance.NbCollisions.ToString();
        float tempsFinal = GameManager.Instance.TempsFinNiveau + GameManager.Instance.NbCollisions;
        _txtFinal.text = "Temps final : " + tempsFinal.ToString("f2") + " secondes";
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
        SceneManager.LoadScene(0);
    }
}
