using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VictorRivero
{

    /// <summary>
    /// 
    /// </summary>

    public class ObstacleGenerator : MonoBehaviour
    {
        #region Static Fields
        #endregion
        #region Const Field
        const float _x = 0.0f;
        const float _y = 0.0f;
        const float _z = 180.0f;
        #endregion
        #region Param Fields
        #endregion
        #region Private Fields
        [Header("Object Pool")]
        [SerializeField] private ObjectPool _objectPool;

        [Space(3)]
        [Header("Init Positions")]
        [SerializeField] private Transform _pointA;
        [SerializeField] private Transform _pointB;
        [SerializeField] private Transform _pointC;
        [SerializeField] private Transform _pointD;

        [Space(3)]
        [Header("Times")]
        [SerializeField] private float _timer;
        [SerializeField] private float _timeToSpawn;
        private float _minTime = 1.0f;
        [SerializeField] private float _maxTime;
        #endregion
        #region Public Fields
        #endregion
        #region Lifecycle
        #endregion
        #region Public API
        #endregion
        #region Unity Methods
        // Start is called before the first frame update
        void Start()
        {
            //StartCoroutine(GeneretaObstacle());
        }
        // Update is called once per frame
        void Update()
        {
            _timer += Time.deltaTime;
            GenerateObstacles();
        }
        // Awake is called when the script is
        // first loaded or when an object is
        // attached to is instantiated
        void Awake()
        {
           
        }
        // FixedUpdate is called at fixed time intervals
        void FixedUpdate()
        {

        }
        // LateUpdate is called after all Update functions have been called
        void LateUpdate()
        {

        }
        #endregion
        #region Private Methods
       private void GenerateObstacles()
        {
            int randomInitPos = Random.Range(0, 2);
            GameObject _obstacle = _objectPool.GetPooledObstacle();

            if (_obstacle != null)
            {
                if (_timer >= _timeToSpawn)
                {
                    if (randomInitPos == 0)
                    {
                        Debug.Log("Point B");
                        //_obstacle.transform.position = _pointB.position;
                        _obstacle.transform.rotation = Quaternion.Euler(_x, _y, 0.0f);
                        _obstacle.GetComponent<ObstaclesMovement>().pointInit = _pointB.gameObject;
                        _obstacle.GetComponent<ObstaclesMovement>().pointFinal = _pointA.gameObject;
                        _obstacle.SetActive(true);
                    }
                    if (randomInitPos == 1)
                    {
                        Debug.Log("Point D");
                        // _obstacle.transform.position = _pointD.position;
                        _obstacle.transform.rotation = Quaternion.Euler(_x, _y, _z);
                        _obstacle.GetComponent<ObstaclesMovement>().pointInit = _pointD.gameObject;
                        _obstacle.GetComponent<ObstaclesMovement>().pointFinal = _pointC.gameObject;
                        _obstacle.SetActive(true);
                    }
                    
                    _timer = 0.0f;
                    _timeToSpawn = Random.Range(_minTime, _maxTime);
                }
            }
        }
        #endregion
        #region Public Methods
        #endregion
        #region IEnumerators
        #endregion
    }
}