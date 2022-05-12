Shader "Graph/Point Surface" {

	Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
		//_BaseColor ("Base Color", Color) = (1.0, 1.0, 1.0, 1.0)
		//_Smoothness ("Smoothness", Range(0,1)) = 0.5
	}
	
	SubShader {

         Tags { "Queue"="Overlay"}
    ZTest Always
    Blend OneMinusDstColor One
    ColorMask RGB

     CGPROGRAM
		#pragma surface surf Lambert
		#pragma instancing_options assumeuniformscaling procedural:ConfigureProcedural
		#pragma editor_sync_compilation

		#pragma target 4.5

        #include "PointGPU.hlsl"

		 sampler2D _MainTex;

		struct Input {
			float3 worldPos;
             float2 uv_MainTex;
		};

	//	float4 _BaseColor;
		//float _Smoothness;

		 void surf (Input IN, inout SurfaceOutput o) {
             half4 c = tex2D (_MainTex, IN.uv_MainTex);
             o.Albedo = c.rgb;
             
             o.Alpha = c.a;
         }
		ENDCG
	}

	FallBack "Diffuse"
}