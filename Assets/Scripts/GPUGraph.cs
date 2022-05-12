using UnityEngine;

public class GPUGraph : MonoBehaviour {

	[SerializeField]
	float step;

	const int maxResolution = 50;

	static readonly int
		positionsId = Shader.PropertyToID("_Positions"),
		resolutionId = Shader.PropertyToID("_Resolution"),
		stepId = Shader.PropertyToID("_Step");


	[SerializeField]
	ComputeShader computeShader;

	[SerializeField]
	Material material;


	public Mesh mesh;

	[SerializeField, Range(10, maxResolution)]
	int resolution = 10;



	ComputeBuffer positionsBuffer;

	void OnEnable () {
		positionsBuffer = new ComputeBuffer(maxResolution * maxResolution, 3 * 4);
	}

	void OnDisable () {
		positionsBuffer.Release();
		positionsBuffer = null;
	}

	void Start () {



		computeShader.SetInt(resolutionId, resolution);
		computeShader.SetFloat(stepId, step);



		var kernelIndex = 0;


		computeShader.SetBuffer(kernelIndex, positionsId, positionsBuffer);

		int groups = Mathf.CeilToInt(resolution / 8f);
		computeShader.Dispatch(kernelIndex, groups, groups, 1);

		material.SetBuffer(positionsId, positionsBuffer);
		material.SetFloat(stepId, step);

	}


	public virtual void UpdateFunctionOnGPU () {

		FunctionOnGPU();
	}

    void FunctionOnGPU()
    {
		var bounds = new Bounds(Vector3.zero, Vector3.one * resolution);
		Graphics.DrawMeshInstancedProcedural(
			mesh, 0, material, bounds, resolution * resolution
		);
	}
}