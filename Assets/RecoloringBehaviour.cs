using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RecoloringBehaviour : MonoBehaviour
{
    [SerializeField] private float _recoloringDuration = 0.3f;
    private Color _startColor;
    private Color _nextColor;
    private Renderer _renderer;

    private float _currentTime;


    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        GenerateNextColor();
    }

    private void GenerateNextColor()
    {
        _startColor = _renderer.material.color;
        _nextColor = Random.ColorHSV(0f, 1f, 0.8f, 1f, 1f, 1f);
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        var progress = _currentTime / _recoloringDuration;

        var currentColor = Color.Lerp(_startColor, _nextColor, progress);

        _renderer.material.color = currentColor;

        if (_currentTime >= _recoloringDuration)
        {
            _currentTime = 0f;
            GenerateNextColor();
        }
    }
}