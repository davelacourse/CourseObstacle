using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _vitesseJoueur = 10f;
    [SerializeField] private float _vitesseRotationJoueur = 1000f;

    private Vector3 _direction;  // direction dans laquelle le joueur se d�place
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MouvementsJoueur();
    }

    // M�thode qui effectue les d�placements du joueur en translation et rotation
    private void MouvementsJoueur()
    {
        // R�cup�rer les axes dans le input manager de Unity
        float directionH = Input.GetAxisRaw("Horizontal");
        float directionV = Input.GetAxisRaw("Vertical");

        _direction = new Vector3(directionH, 0f, directionV);

        _direction.Normalize();  // S'assurer que le vecteur ne d�passe pas 1


        // D�placement par transform (t�l�portation)
        // transform.Translate(_direction * Time.deltaTime * _vitesseJoueur, Space.World);

        // D�place le corps physique � une certaine vitesse dans la direction voulu
        _rb.linearVelocity = _direction * Time.fixedDeltaTime * _vitesseJoueur;

        // Appliquer une force dans la direction voulu
        //_rb.AddForce(_direction * Time.fixedDeltaTime * _vitesseJoueur);
        
        //Rotation du joueur dans la direction du mouvement
        if (_direction != Vector3.zero)
        {
            Quaternion directionRotation = Quaternion.LookRotation(_direction, Vector3.up);
            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, directionRotation,
                _vitesseRotationJoueur * Time.deltaTime);
        }
    }

    public void FinDePartie()
    {
        this.gameObject.SetActive(false);
    }
}
