using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshAttach : MonoBehaviour
{
    [SerializeField]
    private Material screenColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshFilter>().mesh = AvatarMeshNow.avatarMesh;

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        
        meshRenderer.sharedMaterial = screenColor;
    }
}
