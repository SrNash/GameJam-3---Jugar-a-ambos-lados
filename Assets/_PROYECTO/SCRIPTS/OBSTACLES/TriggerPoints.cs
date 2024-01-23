using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class TriggerPoints : MonoBehaviour
	{
        #region Static Fields
        #endregion
        #region Const Field
        #endregion
        #region Param Fields
        #endregion
        #region Private Fields
        [Header("Damage")]
        [SerializeField] private int _points;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _waitTime;
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
			
		}
	    
		// FixedUpdate is called at fixed time intervals
		void FixedUpdate()
		{
			
		}

        // LateUpdate is called after all Update functions have been called
        #endregion
        #region Private Methods
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                //Player suma puntos
                ScoreManager.Instance.AddPointsToScore(_points);

                GameObject _point = ObjectPool.Instance.GetPooledNumber();
                 
                if(_point != null)
                {
                    _point.GetComponentInChildren<TextMeshProUGUI>().text = _points.ToString();
                    _point.SetActive(true);
                	_point.transform.position = transform.parent.position + _offset;
                }
            }
        }
        #endregion
        #region Public Methods
        #endregion
    }
}