using System;
using UnityEngine;

namespace GameAssets.Scripts.Player
{
    public class PlayerBorders : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private Transform border;
        private Transform _playerTransform;
        private float _minX, _maxX, _minY;
        private void Awake()
        {
            _playerTransform = player.transform;
            _minX = Camera.main.ScreenToWorldPoint(new Vector3(0, 1)).x+.5f;
            _maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 1)).x-.5f;
            _minY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).y+.5f;
        }

        private void Update()
        {
            if (_playerTransform)
            {
                Vector3 currentPos = _playerTransform.position;
                currentPos.x = Mathf.Clamp(currentPos.x, _minX, _maxX);
                currentPos.y = Mathf.Clamp(currentPos.y, _minY, border.position.y-.5f);
                _playerTransform.position = currentPos;
            }
        }
    }
}