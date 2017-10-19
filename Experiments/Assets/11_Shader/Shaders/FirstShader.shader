Shader "Custom/FirstShader" {

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
			};

			struct VertexData {
				float4 position : POSITION;
				float2 uv : TEXCOORD0;
			};

			Interpolators MyVertexProgram(VertexData p_vertexData) {
				Interpolators i;
				i.position = mul(UNITY_MATRIX_MVP, p_vertexData.position);
				i.uv = TRANSFORM_TEX(p_vertexData.uv, _MainTex);

				return i;
			}

			float4 MyFragmentProgram(Interpolators p_interpolators) : SV_TARGET {
				//return float4(p_interpolators.uv, 1, 1) * _Tint;
				return tex2D(_MainTex, p_interpolators.uv) * _Tint;
			}

			ENDCG
		}
	}
}