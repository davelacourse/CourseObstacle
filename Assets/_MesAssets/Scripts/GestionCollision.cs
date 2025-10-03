using UnityEngine;

public class GestionCollision : MonoBehaviour
{
    [SerializeField] private Material _materielCollision = default(Material);
    private bool _estTouche = false;
    
    private void OnCollisionEnter(Collision collision)
    {
        
        if(this.transform.tag != "Fin")
        {
            if (!_estTouche && collision.transform.tag == "Player")
            {
                GetComponent<MeshRenderer>().material = _materielCollision;

                //Ajouter une collision
                GameManager.Instance.AugmenterCollisions();
                _estTouche = true;
            }
        }
        else
        {
            GameManager.Instance.FinNiveau();
        }
 
    }
}
