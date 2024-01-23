using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class CoinsGenerator : MonoBehaviour
	{
        #region Static Fields
        #endregion
        #region Const Field
        #endregion
        #region Param Fields
        #endregion
        #region Private Fields
        [Header("Coin GO")]
        [SerializeField] private GameObject _coinGo;

        [Space(3)]
        [Header("Init Positions")]
        [SerializeField] private Transform _spawnerBottom;
        [SerializeField] private Transform _spawnerTop;

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
        void Start()
        {
            
        }
        // Update is called once per frame
        void Update()
        {
            _timer += Time.deltaTime;
            GenerateCoins();
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
        #endregion
        #region Private Methods
        private void GenerateCoins()
        {
            int randomInitPos = Random.Range(0, 2);

            if (_timer >= _timeToSpawn)
            {
                if (randomInitPos == 0)
                {
                    Debug.Log("Generando abajo");

                    GameObject _coin = Instantiate(_coinGo, _spawnerBottom.position, Quaternion.identity);
                }
                if (randomInitPos == 1)
                {
                    Debug.Log("Generando arriba");

                    GameObject _coin = Instantiate(_coinGo, _spawnerTop.position, Quaternion.identity);
                }

                _timer = 0.0f;
                _timeToSpawn = Random.Range(_minTime, _maxTime);
            }
        }
        #endregion
        #region Public Methods
        #endregion
        
    }
}