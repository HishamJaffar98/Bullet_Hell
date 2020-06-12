using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float scrollingSpeed = 0.5f;
    Material myMaterial;
    Vector2 offSet;
    void Start()
    {
        myMaterial = gameObject.GetComponent<MeshRenderer>().material;
        offSet = new Vector2(0f, scrollingSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
