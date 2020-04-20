using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadzoneFollowCamera : MonoBehaviour
{
    public GameLevelManager GameLevelManager;
    public float DeadzoneSize = 0.6f;
    public float Drag = 0.95f;
    
    private Camera _gameCamera;
    private float _initialHeight;
    private float _velocity;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameCamera = this.gameObject.GetComponent<Camera>();
        _initialHeight = _gameCamera.gameObject.transform.position.y;
        _velocity = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameLevelManager.LiveBalls.Count > 0)
        {
            Transform cameraTransform = this.gameObject.transform;

            float targetHeight = 0.0f;
            foreach (GameObject goBall in GameLevelManager.LiveBalls)
            {
                targetHeight += goBall.transform.position.y;
            }
            targetHeight /= GameLevelManager.LiveBalls.Count;
            
            Vector3 targetPos = new Vector3(0.0f, targetHeight, 0.0f);
            Vector3 vpPos = _gameCamera.WorldToViewportPoint(targetPos);

            float origHeight = cameraTransform.position.y;
            float newHeight = origHeight;
            float livezoneSize = (1.0f - DeadzoneSize) / 2.0f;
            if ((vpPos.y < livezoneSize) || (vpPos.y > (1.0f - livezoneSize)))
            {
                float closestDeadzone = Mathf.Clamp(vpPos.y, livezoneSize, 1.0f - livezoneSize);
                Vector3 newVPPos = new Vector3(vpPos.x, closestDeadzone, vpPos.z);
                Vector3 wsPosInDeadzone = _gameCamera.ViewportToWorldPoint(newVPPos);
                Vector3 wsOffset = targetPos - wsPosInDeadzone;
                newHeight += wsOffset.y;

                if (newHeight < _initialHeight)
                {
                    newHeight = _initialHeight;
                }

                Vector3 newPos = cameraTransform.position;
                newPos.y = newHeight;
                cameraTransform.position = newPos;

                _velocity = newHeight - origHeight;
            }
            else
            {
                if (_velocity > 0.01f)
                {
                    _velocity *= Drag;

                    Vector3 newPos = cameraTransform.position;
                    newPos.y += _velocity;
                    cameraTransform.position = newPos;
                }
                else
                {
                    _velocity = 0.0f;
                }
            }
        }
        else
        {
            _velocity = 0.0f;
        }
    }
}
