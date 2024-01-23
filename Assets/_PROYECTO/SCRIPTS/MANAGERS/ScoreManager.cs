using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class ScoreManager : MonoBehaviour
	{
		#region Static Fields
		private static ScoreManager _instance;
		public static ScoreManager Instance { get { return _instance; } }
		#endregion
		#region Const Field
		#endregion
		#region Param Fields
		#endregion
		#region Private Fields
		[Header("Score")]
		[SerializeField] private TextMeshProUGUI _scoreText;
		[SerializeField] private int _score;
		[SerializeField] int _pointsToGetATry;
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
            //_scoreText.text = _score.ToString().PadLeft(4, '0');
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

			DontDestroyOnLoad(this);
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
		private void CheckPoints()
		{
			if (_score % _pointsToGetATry == 0)
			{
				PlayerLife.instance.ChangeTries(1);
			}
		}
		#endregion
		#region Public Methods
		public void AddPointsToScore(int amount)
		{
			_score += amount;
            _scoreText.text = _score.ToString().PadLeft(4, '0');
            CheckPoints();
		}
		#endregion
	}
}