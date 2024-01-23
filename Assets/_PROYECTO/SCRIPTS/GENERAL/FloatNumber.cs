using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class FloatNumber : MonoBehaviour
	{
		#region Static Fields
		#endregion
		#region Const Field
		#endregion
		#region Param Fields
		#endregion
		#region Private Fields
		private float _timer = 0.0f;
		private float _timeToDessapear = 1.5f;
		#endregion
		#region Public Fields
		#endregion
		#region Lifecycle
		#endregion
		#region Public API
		#endregion
		#region Unity Methods
		private void OnEnable()
		{
			//_timer += Time.deltaTime;
		}
		// Start is called before the first frame update
		void Start()
		{
			
		}

		// Update is called once per frame
		void Update()
		{
            _timer += Time.deltaTime;
            if (_timer >= _timeToDessapear)
			{
				gameObject.SetActive(false);
				_timer = 0.0f;
			}
		}

		// Awake is called when the script is
		// first loaded or when an object is
		// attached to is instantiated
		void Awake()
		{
            //_timer += Time.deltaTime;
			_timer = 0.0f;
			DontDestroyOnLoad(gameObject);
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
		#endregion
	}
}