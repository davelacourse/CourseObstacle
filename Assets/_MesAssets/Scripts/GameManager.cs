using UnityEngine;

public class GameManager : MonoBehaviour
{
    //D�finir singleton ---------------------------------------------
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    //---------------------------------------------------------------


    private int _nbCollisions;

    private void Start()
    {
        _nbCollisions = 0;
    }

    public void AugmenterCollisions()
    {
        _nbCollisions++;
        Debug.Log("Collisions : " + _nbCollisions.ToString());
    }
}
