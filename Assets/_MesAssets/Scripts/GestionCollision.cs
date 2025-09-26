using UnityEngine;

public class GestionCollision : MonoBehaviour
{
    private bool _estTouche = false;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (!_estTouche)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;

            //Ajouter une collision
            GameManager.Instance.AugmenterCollisions();
            _estTouche = true;
        }
    }
}
