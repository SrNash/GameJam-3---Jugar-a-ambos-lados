using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class ObjectPool : MonoBehaviour
	{
		#region Static Fields
		public static ObjectPool _instance;
		public static ObjectPool Instance { get { return _instance; } }
		#endregion
		#region Const Field
		#endregion
		#region Param Fields
		#endregion
		#region Private Fields
		[Header("Pooled Objects")]
		[SerializeField]private List<GameObject> _pooledObstacles = new List<GameObject> ();
		[SerializeField] private int _obstaclesToPool;
        [SerializeField] private List<GameObject> _pooledFloatNumber = new List<GameObject>();
        [SerializeField] private int _numbersToPool;

		[Space(1)]
		[Header("GameObjects to Pool")]
		[SerializeField] private GameObject _spikesObstacleGo;
		[SerializeField] private GameObject _radialObstacleGo;
		[SerializeField] private GameObject _postObstacleGo;
		[SerializeField] private GameObject _numberGo;

        [Space(3)]
        [Header("Init Positions")]
        [SerializeField] private Transform _pointA;
        [SerializeField] private Transform _pointB;

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
			for (int i = 0; i < _obstaclesToPool/3; i++)
			{
                GameObject obj = Instantiate(_spikesObstacleGo);

                //obj.transform.parent = transform;
                obj.SetActive(false);
				_pooledObstacles.Add(obj);
			}
            for (int i = 0; i < _obstaclesToPool/3; i++)
            {
                GameObject obj = Instantiate(_radialObstacleGo);

                //obj.transform.parent = transform;
                obj.SetActive(false);
                _pooledObstacles.Add(obj);
            }
            for (int i = 0; i < _obstaclesToPool/3; i++)
            {
                GameObject obj = Instantiate(_postObstacleGo);

                //obj.transform.parent = transform;
                obj.SetActive(false);
                _pooledObstacles.Add(obj);
            }

            for (int i = 0; i < _numbersToPool; i++)
			{
				GameObject obj = Instantiate(_numberGo);
				//obj.transform.parent = transform;
				obj.SetActive(false);
				_pooledFloatNumber.Add(obj);
			}
        }

            // Update is called once per frame
            void Update()
		{
			
		}

		// Awake is called when the script is
		// first loaded or when an object is
		// attached to is instantiated
		void Awake()
		{
			if (_instance is null)
			{
				_instance = this;
			}

			//DontDestroyOnLoad(this.gameObject);
		}
	    
		// FixedUpdate is called at fixed time intervals
		void FixedUpdate()
		{
			
		}
            
		// LateUpdate is called after all Update functions have been called
		#endregion
		#region Private Methods
		#endregion            
		#region Public Methods
		public GameObject GetPooledObstacle()
		{
			int random = Random.Range(0, _obstaclesToPool - 1);
			for (int i = 0; i < _pooledObstacles.Count; i++)
			{
				if (!_pooledObstacles[random].activeInHierarchy)
				{
					return _pooledObstacles[random];
				}
			}
			
			return null;
		}
		public GameObject GetPooledNumber()
		{
			for (int i = 0; i < _pooledFloatNumber.Count; i++)
			{
				if (!_pooledFloatNumber[i].activeInHierarchy)
				{
					return _pooledFloatNumber[i];
				}
				else { i++; }
			}
			
			return null;
		}
        #endregion

        /// <summary>
        /// En el script que controle tanto la aparicion de los obtaculos
        /// como los que añadan puntuacion para utilizar los objetos pooleados
        /// deberan utilizar la siguiente forma.
        /// 
		/// PUNTOS:
        /// GameObject _points = ObjectPool.Instance.GetPooledNumber();
        /// 
        /// if(_points != null)
        /// {
        ///		_points.SetActive(true);
        ///		_points.transform.position = transform.position;
        /// }
		/// 
		/// OBSTACULOS:
		/// GameObject _obstacle = ObjectPool.Instance.GetPooledObstacle();
		/// if(_obstacle != null)
		/// {
		///		_obtacle.SetActive(true);
		///		_obtacle.transform.position = transform.position;
		///	}
		///	
		/// Y para finalizar utilizaremos la sentencia gameObject.SetActive(false);
		/// para desactivar el objeto en lugar dfe destruirlo.
        /// </summary>

    }
}