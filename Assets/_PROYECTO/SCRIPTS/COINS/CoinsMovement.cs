using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class CoinsMovement : MonoBehaviour
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
        [Header("Move")]
        [SerializeField] private float _speed;
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
			_rb.velocity = new Vector2(-_speed, _rb.velocity.y);
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
		#endregion            
		#region Public Methods
		#endregion
	}
}