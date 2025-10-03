using UnityEngine;

public class RotationObjets : MonoBehaviour
{
    [SerializeField] private float _vitesseRotation = 10f;

    private void Update()
    {
        transform.Rotate(0f, _vitesseRotation * Time.deltaTime, 0f);
    }
}
