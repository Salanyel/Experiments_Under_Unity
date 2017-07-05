Shader "Custom/FirstShader" {

	Properties {
		_Tint ("Tint", Color) = (1, 1, 1, 1)
	}

	SubShader {

		Pass {
			CGPROGRAM

			#pragma vertex MyVertexProgram
			#pragma fragment MyFragmentProgram

			#include "UnityCG.cginc"

			float4 _Tint;

			struct Interpolators {
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			struct VertexData {
				float4 position : POSITION;
				float2 uv : TEXCOORD0;
			};

			Interpolators MyVertexProgram(VertexData p_vertexData) {
				Interpolators i;
				i.position = mul(UNITY_MATRIX_MVP, p_vertexData.position);
				i.uv = p_vertexData.uv;

				return i;
			}

			float4 MyFragmentProgram(Interpolators p_interpolators) : SV_TARGET {
				return float4(p_interpolators.uv, 1, 1) * _Tint;
			}

			ENDCG
		}
	}
}