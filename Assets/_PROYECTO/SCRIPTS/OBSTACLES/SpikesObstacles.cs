using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	[RequireComponent(typeof(Rigidbody2D))]
	public class SpikesObstacles : MonoBehaviour
	{
		#region Static Fields
		#endregion
		#region Const Field
		#endregion
		#region Param Fields
		#endregion
		#region Private Fields
		[Header("Rigidbody2D")]
		[SerializeField] private Rigidbody2D _rb;

        [Space(3)]
        [Header("Spikes Count")]
        [SerializeField] private float _count;
        [SerializeField] private int _spikesCount;
        [SerializeField] private GameObject[] _spikesList;

        [Space(3)]
        [Header("Patrol Waypoints")]
        [SerializeField] private GameObject _pointA;
        [SerializeField] private GameObject _pointB;
        [SerializeField] private Transform _currentPoint;

        [Space(3)]
        [Header("Move")]
        [SerializeField] private float _speed;

        [Space(3)]
        [Header("Timer")]
        [SerializeField]private float _timer = 0.0f;
        [SerializeField] private float _timeToStartMove;
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
			GetSpikes();
            _currentPoint = _pointB.transform;
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
        private void GetSpikes()
        {
            _count = Random.Range((int)1.0f, (int)4.0f);
            _spikesCount = (int)_count;

            for (int i = 0; i < _spikesCount; i++)
            {
                _spikesList[i].SetActive(true);
            }
        }
        #endregion
        #region Public Methods
        #endregion
        #region IEnumerators
        IEnumerator RestartSpiker()
        {
            transform.position = _currentPoint.position;
            yield return null;
        }
        #endregion
        private void OnDrawGizmos()
        {
            //Points Gizmos
            Gizmos.DrawWireSphere(_pointA.transform.position, 0.5f);
            Gizmos.DrawWireSphere(_pointB.transform.position, 0.5f);
            Gizmos.DrawLine(_pointA.transform.position, _pointB.transform.position);
        }
    }
 }