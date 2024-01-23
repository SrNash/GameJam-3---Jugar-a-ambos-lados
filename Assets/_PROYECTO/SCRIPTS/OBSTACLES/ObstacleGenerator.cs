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
        #endregion
        #region Param Fields
        #endregion
        #region Private Fields
        [Header("Object Pool")]
        [SerializeField] private ObjectPool _objectPool;

        [Space(3)]
        [Header("Init Positions")]
        [SerializeField] private Transform _pointB;
        [SerializeField] private Transform _pointD;

        [Space(3)]
        [Header("Times")]
        [SerializeField] private float _timer;
        [SerializeField] private float _timeToSpawn = Random.Range(1.0f, 4.0f);
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
                        _obstacle.transform.position = _pointB.position;
                        _obstacle.SetActive(true);
                    }
                    else if (randomInitPos == 1)
                    {
                        _obstacle.transform.position = _pointD.position;
                        _obstacle.SetActive(true);
                    }
                    
                    _timer = 0.0f;
                    _timeToSpawn = Random.Range(1.0f, 4.0f);
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