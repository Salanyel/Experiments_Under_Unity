Shader "Custom/Textured With Detail" {

	Properties {
		_Tint ("Tint", Color) = (1, 1, 1, 1)
		_MainTex ("Texture", 2D) = "white" {}
		_DetailTex ("Detail Texture", 2D) = "gray" {}
		_Repetition ("Repetition", Float) = 1
	}

	SubShader {

		Pass {
			CGPROGRAM

			#pragma vertex MyVertexProgram
			#pragma fragment MyFragmentProgram

			#include "UnityCG.cginc"

			float4 _Tint;
			float _Repetition;

			sampler2D _MainTex, _DetailTex;
			float4 _MainTex_ST, _DetailTex_ST;

			struct Interpolators {
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;
				float2 uvDetail : TEXCOORD1;
			};

			struct VertexData {
				float4 position : POSITION;
				float2 uv : TEXCOORD0;
			};

			Interpolators MyVertexProgram(VertexData p_vertexData) {
				Interpolators i;
				i.position = mul(UNITY_MATRIX_MVP, p_vertexData.position);
				i.uv = TRANSFORM_TEX(p_vertexData.uv, _MainTex);
				i.uvDetail = TRANSFORM_TEX(p_vertexData.uv, _DetailTex);

				return i;
			}

			float4 MyFragmentProgram (Interpolators p_interpolators) : SV_TARGET {
				float4 color = tex2D(_MainTex, p_interpolators.uv) * _Tint;
				color *= tex2D(_DetailTex, p_interpolators.uvDetail * _Repetition) * unity_ColorSpaceDouble;
				return color;
			}

			ENDCG
		}
	}
}