using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesObstacle : MonoBehaviour
{
    [Header("Spikes Count")]
    [SerializeField] private float _count;
    [SerializeField] private int _spikesCount;
    [SerializeField] private GameObject[] _spikesList;

    [Header("Move")]
    [SerializeField] private float _speed;
    // Start is called before the first frame update
    void Start()
    {
        _count = Random.Range((int)1.0f, (int)4.0f);
        _spikesCount = (int)_count;

        for (int i = 0; i < _spikesCount; i++)
        {
            _spikesList[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-1.0f, transform.position.y, 0.0f) * _speed * Time.deltaTime;
    }
}
