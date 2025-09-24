using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _direction;  // direction dans laquelle le joueur se déplace
    [SerializeField] private float _vitesseJoueur = 10f;
    [SerializeField] private float _vitesseRotationJoueur = 1000f;

    private void Update()
    {
        // Récupérer les axes dans le input manager de Unity
        float directionH = Input.GetAxisRaw("Horizontal");
        float directionV = Input.GetAxisRaw("Vertical");

        _direction = new Vector3(directionH, 0f, directionV);

        _direction.Normalize();  // S'assurer que le vecteur ne dépasse pas 1

        transform.Translate(_direction * Time.deltaTime * _vitesseJoueur, Space.World);

        //Rotation du joueur dans la direction du mouvement
        if(_direction != Vector3.zero)
        {
            Quaternion directionRotation = Quaternion.LookRotation(_direction, Vector3.up);
            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, directionRotation,
                _vitesseRotationJoueur * Time.deltaTime);
        }
    }
}
