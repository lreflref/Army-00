using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPUManager : MonoBehaviour
{
    [SerializeField]
    GameObject referenceMesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        referenceMesh.GetComponent<CreateMesh>().SetAvatarMesh();
        GetComponent<SetMesh>().SetGPUGraphMesh();
        GetComponent<GPUGraph>().UpdateFunctionOnGPU();
    }
}
