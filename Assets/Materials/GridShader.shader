Shader "Custom/GridShader" {
	Properties
	{
		_TileColor1("GridColour1", Color) = (1,0,0,1)		//Default colour1
		_TileColor2("GridColour2", Color) = (0,1,0,1)		//Defautl colour2
		_RepeatX("RepeatX", Int) = 1
		_RepeatY("RepeatY", Int) = 1

	}
		SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata {
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;		//use UV to calculate tiles
			};

			struct v2f {
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			fixed4	_TileColor1;
			fixed4	_TileColor2;
			int		_RepeatX;
			int		_RepeatY;


			v2f vert(appdata v) {
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				int p = fmod(i.uv.x*_RepeatX,2.0) < 1.0;	//Gives a pattern of 0 and 1 across the view
				int q = fmod(i.uv.y*_RepeatY,2.0) > 1.0;	//Gives a pattern of 1 and 0 down the view
				return (_TileColor1 * ((p && q) || !(p || q))) + (_TileColor2 * !((p && q) || !(p || q)));	//Draw one colour or the other
			}
		ENDCG
		}
	}
}
