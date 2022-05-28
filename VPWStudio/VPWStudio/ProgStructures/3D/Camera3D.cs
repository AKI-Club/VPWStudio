using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace VPWStudio
{
	// http://neokabuto.blogspot.com/2014/01/opentk-tutorial-5-basic-camera.html
	// https://learnopengl.com/Getting-started/Camera

	/// <summary>
	/// Camera for viewing a 3D scene.
	/// </summary>
	public class Camera3D
	{
		#region Class Members
		/// <summary>
		/// Camera position in world space.
		/// </summary>
		public Vector3 Position;

		/// <summary>
		/// Camera rotation.
		/// </summary>
		public Vector3 Rotation;

		/// <summary>
		/// Camera target/"look at" point.
		/// </summary>
		public Vector3 Target;

		/// <summary>
		/// Camera "direction" (actually points *away* from the target)
		/// </summary>
		/// "cameraDirection" in learnopengl tutorial
		public Vector3 AntiTarget;

		/// <summary>
		/// Camera "up" axis.
		/// </summary>
		public Vector3 UpAxis;

		/// <summary>
		/// Camera "right" axis.
		/// </summary>
		public Vector3 RightAxis;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Camera3D()
		{
			Position = new Vector3(0.0f, 0.0f, 0.0f);
			Rotation = new Vector3(0.0f, 0.0f, 0.0f);
			Target = new Vector3(0.0f, 0.0f, 0.0f);
			AntiTarget = Vector3.Normalize(Position - Target);
			RightAxis = Vector3.Normalize(Vector3.Cross(Vector3.UnitY, AntiTarget));
			UpAxis = Vector3.Cross(AntiTarget, RightAxis);
		}

		/// <summary>
		/// Constructor with specific position.
		/// </summary>
		/// <param name="position">Camera starting position.</param>
		public Camera3D(Vector3 pos)
		{
			Position = pos;
			Rotation = new Vector3(0.0f, 0.0f, 0.0f);
			Target = new Vector3(0.0f, 0.0f, 0.0f);
			AntiTarget = Vector3.Normalize(Position - Target);
			RightAxis = Vector3.Normalize(Vector3.Cross(Vector3.UnitY, AntiTarget));
			UpAxis = Vector3.Cross(AntiTarget, RightAxis);
		}

		/// <summary>
		/// Constructor with specific position and rotation.
		/// </summary>
		/// <param name="pos">Camera starting position.</param>
		/// <param name="rot">Camera starting rotation.</param>
		public Camera3D(Vector3 pos, Vector3 rot)
		{
			Position = pos;
			Rotation = rot;
			Target = new Vector3(0.0f, 0.0f, 0.0f);
			AntiTarget = Vector3.Normalize(Position - Target);
			RightAxis = Vector3.Normalize(Vector3.Cross(Vector3.UnitY, AntiTarget));
			UpAxis = Vector3.Cross(AntiTarget, RightAxis);
		}

		/// <summary>
		/// Constructor with specific position, rotation, and target.
		/// </summary>
		/// <param name="pos">Camera starting position.</param>
		/// <param name="rot">Camera starting potation.</param>
		/// <param name="lookAt">Camera starting target/"look at" point.</param>
		public Camera3D(Vector3 pos, Vector3 rot, Vector3 lookAt)
		{
			Position = pos;
			Rotation = rot;
			Target = lookAt;
			AntiTarget = Vector3.Normalize(Position - Target);
			RightAxis = Vector3.Normalize(Vector3.Cross(Vector3.UnitY, AntiTarget));
			UpAxis = Vector3.Cross(AntiTarget, RightAxis);
		}
		#endregion

		public void Move(float x, float y, float z)
		{
		}

		/// <summary>
		/// Move the camera to an absolute position.
		/// </summary>
		/// <param name="newPos">New absolute position for the camera.</param>
		public void MoveAbsolute(Vector3 newPos)
		{
			Position = newPos;
			AntiTarget = Vector3.Normalize(Position - Target);
			RightAxis = Vector3.Normalize(Vector3.Cross(Vector3.UnitY, AntiTarget));
			UpAxis = Vector3.Cross(AntiTarget, RightAxis);
		}

		public Matrix4 GetView()
		{
			return Matrix4.LookAt(Position, Target, Vector3.UnitY);
		}
	}
}
