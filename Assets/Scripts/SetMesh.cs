using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMesh : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<GPUGraph>().mesh = AvatarMeshNow.avatarMesh;
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<GPUGraph>().mesh = AvatarMeshNow.avatarMesh;
    }

    public virtual void SetGPUGraphMesh()
    {
        SetGPUMesh();
    }

    void SetGPUMesh()
    {
        GetComponent<GPUGraph>().mesh = AvatarMeshNow.avatarMesh;
    }
}
