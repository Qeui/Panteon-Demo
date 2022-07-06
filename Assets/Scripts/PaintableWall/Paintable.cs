using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintable : MonoBehaviour
{
    [SerializeField] private GameObject _brush;
    [SerializeField] private Transform _brushHolder;
    [SerializeField] private FinishTrigger _trigger;
    [SerializeField] private RenderTexture _texture;
    [SerializeField] private Material _wallMat;
    [SerializeField] private Texture2D _defaultTexture;

    private void Start()
    {
        // Resets the wall material 
        _wallMat.mainTexture = _defaultTexture;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // Checks if the game is finished and player is touching
        if(Input.GetMouseButton(0) && _trigger._isGameFinished)
        {
            // If it is, it send a ray from the mouse position
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Checks if the ray hit something
            if(Physics.Raycast(Ray, out hit))
            {
                // Check if the hit object is the wall or not
                if (hit.transform.CompareTag("Paintable"))
                {
                    // If it is the wall, it spawns the brush in front of the wall so it will look like its painted
                    var go = Instantiate(_brush, hit.point - Vector3.forward * 0.001f, Quaternion.Euler(new Vector3(-90, 0, 0)), _brushHolder);
                }
            }
        }
        // Checks if the brush count is above 20
        if(_brushHolder.childCount >= 20)
        {
            // If it is, it starts the brushDestroyer
            StartCoroutine(brushDestroyer());
        }
        
    }
    IEnumerator brushDestroyer()
    {
        // This waits for the and of frame
        yield return new WaitForEndOfFrame();
        // Creates a 2d texture
        Texture2D tex = new Texture2D(_texture.width, _texture.height, TextureFormat.RGB24, false);
        RenderTexture.active = _texture;
        // Gets the pixel data from the render texture and apply to the 2d texture
        tex.ReadPixels(new Rect(0, 0, _texture.width, _texture.height), 0, 0);
        tex.Apply();
        // Applies the 2d texture to the wall material
        _wallMat.mainTexture = tex;
        // Destroys the brush childs
        foreach (Transform child in _brushHolder)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
