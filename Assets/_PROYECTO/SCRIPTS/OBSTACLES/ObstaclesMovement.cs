using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VictorRivero;

public class ObstaclesMovement : MonoBehaviour
{
    [Header("Rigidbody2D")]
    [SerializeField] private Rigidbody2D _rb;

    [Space(3)]
    [Header("Patrol Waypoints")]
    [SerializeField] private GameObject _pointFinal;
    [SerializeField] private GameObject _pointInit;
    [SerializeField] private Transform _currentPoint;

    [Space(3)]
    [Header("Move")]
    [SerializeField] private float _speed;

    [Space(3)]
    [Header("Object Pool")]
    [SerializeField] private ObjectPool _objectPool;

    public GameObject pointInit { get { return _pointInit; } set { _pointInit = value; } }
    public GameObject pointFinal { get { return _pointFinal; } set { _pointFinal = value; } }
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _objectPool = FindObjectOfType<ObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentPoint == _pointInit.transform)
        {
            transform.position = _currentPoint.position;
        }
        else
        {
            _rb.velocity = new Vector2(-_speed, 0.0f);
        }

        if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == _pointInit.transform)
        {
            _currentPoint = _pointFinal.transform;
        }

        if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == _pointFinal.transform)
        {
            transform.position = _pointInit.transform.position;
            gameObject.SetActive(false);
            Debug.Log("Desactivando");
        }
    }

    void OnEnable()
    {
        _currentPoint = _pointInit.transform;
        _objectPool = FindObjectOfType<ObjectPool>();
    }
}
