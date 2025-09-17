using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _direction;  // direction dans laquelle le joueur se déplace
    
    private void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            _direction = new Vector3(1f, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _direction = new Vector3(-1f, 0f, 0f);
        }
        else
        {
            _direction= Vector3.zero;
        }

        transform.Translate(_direction);
    }
}
