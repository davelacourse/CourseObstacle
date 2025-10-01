using UnityEngine;
using System.Collections.Generic;

public class ZonesPieges : MonoBehaviour
{
    [SerializeField] private List<GameObject>  _listePieges = new List<GameObject>();
    [SerializeField] private float _intensiteForce = 200f;

    [Header("Direction en X, Y et Z du vecteur de force")]
    [SerializeField] private float _directionX = 0f;
    [SerializeField] private float _directionY = -1f;
    [SerializeField] private float _directionZ = 0f;

    private Vector3 _direction;
    private List<Rigidbody> _listeRb = new List<Rigidbody>();

    private void Start()
    {
        foreach(var piege in _listePieges)
        {
            _listeRb.Add(piege.GetComponent<Rigidbody>());
        }

        _direction = new Vector3(_directionX, _directionY, _directionZ);    
    }

    private void OnTriggerEnter(Collider other)
    {
        //Rigidbody rb = _piege.GetComponent<Rigidbody>();
        //rb.useGravity = true;
        //rb.AddForce(_direction * _intensiteForce);
    }
}
