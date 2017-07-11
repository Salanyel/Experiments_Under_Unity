Shader "Custom/Lighting_Shader_01" {

	Properties {
		_Tint ("Tint", Color) = (1, 1, 1, 1)
		_MainTex ("Texture", 2D) = "white" {}
	}

	SubShader {

		Pass {
			CGPROGRAM

			#pragma vertex MyVertexProgram
			#pragma fragment MyFragmentProgram

			#include "UnityCG.cginc"

			float4 _Tint;
			sampler2D _MainTex;
			float4 _MainTex_ST;

			struct Interpolators {
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : TEXCOORD1;
			};

			struct VertexData {
				float4 position : POSITION;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			Interpolators MyVertexProgram(VertexData p_vertexData) {
				Interpolators i;
				i.position = mul(UNITY_MATRIX_MVP, p_vertexData.position);
				i.normal = UnityObjectToWorldNormal(p_vertexData.normal);
				i.normal = normalize(i.normal);
				p_vertexData.normal;
				i.uv = TRANSFORM_TEX(p_vertexData.uv, _MainTex);
				return i;
			}

			float4 MyFragmentProgram(Interpolators p_interpolator) : SV_TARGET {
				p_interpolator.normal = normalize(p_interpolator.normal);
				return float4(p_interpolator.normal * 0.5 + 0.5, 1);
			}

			ENDCG
		}
	}
}