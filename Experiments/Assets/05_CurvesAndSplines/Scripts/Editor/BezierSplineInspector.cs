using UnityEditor;
using UnityEngine;

namespace _05_CurvesAndSplines
{
	[CustomEditor(typeof(BezierSpline))]
	public class BezierSplineInspector : Editor {

		private BezierSpline spline;
		private Transform handleTransform;
		private Quaternion handleRotation;
		private int selectedIndex = -1;

		private const int _lineStep = 10;
		private const float _directionScale = 0.5f;
		private const float _handleSize = 0.04f;
		private const float _pickSize = 0.06f;

		public override void OnInspectorGUI()
		{
			//DrawDefaultInspector();
			spline = target as BezierSpline;
			if (selectedIndex >= 0 && selectedIndex < spline.ControlPointCount)
			{
				DrawSelectedPointInspector();
			}

			if (GUILayout.Button("Add Curve"))
			{
				Undo.RecordObject(spline, "Add Curve");
				spline.AddCurve();
				EditorUtility.SetDirty(spline);	
			}
		}

		private void DrawSelectedPointInspector()
		{
			GUILayout.Label("Selected point");
			EditorGUI.BeginChangeCheck();
			Vector3 point = EditorGUILayout.Vector3Field("Position", spline.GetControlPoint(selectedIndex));
			if (EditorGUI.EndChangeCheck())
			{
				Undo.RecordObject(spline, "Move Point");
				EditorUtility.SetDirty(spline);
				spline.SetControlPoint(selectedIndex, point);
			}

			EditorGUI.BeginChangeCheck();
			BezierControlPointMode mode = (BezierControlPointMode) 
				EditorGUILayout.EnumPopup("Mode", spline.GetControlPointMode(selectedIndex));
			if (EditorGUI.EndChangeCheck())
			{
				Undo.RecordObject(spline, "Change Point Mode");
				spline.SetControlPointMode(selectedIndex, mode);
				EditorUtility.SetDirty(spline);
			}
		}

		private void OnSceneGUI()
		{
			spline = target as BezierSpline;
			handleTransform = spline.transform;
			handleRotation = handleTransform.rotation;

			Vector3 p0 = ShowPoint(0);
			
			for (int i = 1; i < spline.ControlPointCount; i += 3)
			{
				Vector3 p1 = ShowPoint(i);
				Vector3 p2 = ShowPoint(i + 1);
				Vector3 p3 = ShowPoint(i + 2);

				Handles.color = Color.gray;
				Handles.DrawLine(p0, p1);
				Handles.DrawLine(p2, p3);

				Handles.DrawBezier(p0, p3, p1, p2, Color.white, null, 2f);

				p0 = p3;
			}

			/*Vector3 lineStart = curve.GetPoint(0f);
			Handles.color = Color.green;
			Handles.DrawLine(lineStart, lineStart + curve.GetDirection(0f));
			for (int i=1; i <= _lineStep; i++)
			{
				Vector3 lineEnd = curve.GetPoint(i / (float)_lineStep);
				Handles.color = Color.white;
				Handles.DrawLine(lineStart, lineEnd);

				Handles.color = Color.green;
				Handles.DrawLine(lineEnd, lineEnd + curve.GetDirection(i / (float) _lineStep));
				lineStart = lineEnd;
			}*/

			ShowDirections();
		}

		///Display the directions of each segment for the bezier curve
		private void ShowDirections()
		{
			Handles.color = Color.green;
			Vector3 point = spline.GetPoint(0f);
			Handles.DrawLine(point, point + spline.GetDirection(0f) * _directionScale);
			for (int i=1; i <= _lineStep; i++)
			{
				point = spline.GetPoint(i / (float) _lineStep);
				Handles.DrawLine(point, point + spline.GetDirection(i / (float) _directionScale));
			}
		}

		private Vector3 ShowPoint(int index)
		{
			if (index > spline.points.Length)
			{
				return Vector3.zero;
			}

			Vector3 point = handleTransform.TransformPoint(spline.GetControlPoint(index));
			float size = HandleUtility.GetHandleSize(point);

			Handles.color = Color.white;
			if (Handles.Button(point, handleRotation, size * _handleSize, size * _pickSize, Handles.DotCap))
			{
				selectedIndex = index;
				Repaint();
			}
			
			if (selectedIndex == index)
			{
				EditorGUI.BeginChangeCheck();
				point = Handles.DoPositionHandle(point, handleRotation);

				if (EditorGUI.EndChangeCheck())
				{
					Undo.RecordObject(spline, "Move Point");
					EditorUtility.SetDirty(spline);
					spline.SetControlPoint(index, handleTransform.InverseTransformPoint(point));
				}
			}

			return point;
		}
	}
}