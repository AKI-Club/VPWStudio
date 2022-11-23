using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace VPWStudio
{
	// http://neokabuto.blogspot.com/2014/01/opentk-tutorial-5-basic-camera.html
	// https://learnopengl.com/Getting-started/Camera
	// https://opentk.net/learn/chapter1/9-camera.html

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
		public Vector2 Rotation;

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

		public readonly Vector3 Front = new Vector3(0.0f, 0.0f, -1.0f);

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Camera3D()
		{
			Position = new Vector3(0.0f, 0.0f, 0.0f);
			Rotation = new Vector2(0.0f, 0.0f);
			Target = Front;
			UpdateAntiAxis();
		}

		/// <summary>
		/// Constructor with specific position.
		/// </summary>
		/// <param name="position">Camera starting position.</param>
		public Camera3D(Vector3 pos)
		{
			Position = pos;
			Rotation = new Vector2(0.0f, 0.0f);
			Target = Front;
			UpdateAntiAxis();
		}

		/// <summary>
		/// Constructor with specific position and rotation.
		/// </summary>
		/// <param name="pos">Camera starting position.</param>
		/// <param name="rot">Camera starting rotation.</param>
		public Camera3D(Vector3 pos, Vector2 rot)
		{
			Position = pos;
			Rotation = rot;
			Target = Front;
			UpdateAntiAxis();
		}

		/// <summary>
		/// Constructor with specific position, rotation, and target.
		/// </summary>
		/// <param name="pos">Camera starting position.</param>
		/// <param name="rot">Camera starting potation.</param>
		/// <param name="lookAt">Camera starting target/"look at" point.</param>
		public Camera3D(Vector3 pos, Vector2 rot, Vector3 lookAt)
		{
			Position = pos;
			Rotation = rot;
			Target = lookAt;
			UpdateAntiAxis();
		}
		#endregion

		/// <summary>
		/// Updates AntiTarget, RightAxis, and UpAxis.
		/// </summary>
		private void UpdateAntiAxis()
		{
			AntiTarget = Vector3.Normalize(Position - Target);
			RightAxis = Vector3.Normalize(Vector3.Cross(Vector3.UnitY, AntiTarget));
			UpAxis = Vector3.Cross(AntiTarget, RightAxis);
		}

		/// <summary>
		/// Returns the view matrix for the camera.
		/// </summary>
		/// <returns>Camera view matrix.</returns>
		public Matrix4 GetView()
		{
			return Matrix4.LookAt(Position, Position + Target, Vector3.UnitY);
		}

		#region Movement
		/// <summary>
		/// Move camera using relative X/Y/Z values.
		/// </summary>
		/// <param name="x">Amount to move camera on X axis.</param>
		/// <param name="y">Amount to move camera on Y axis.</param>
		/// <param name="z">Amount to move camera on Z axis.</param>
		public void Move(float x, float y, float z)
		{
			Position.X += x;
			Position.Y += y;
			Position.Z += z;
			UpdateAntiAxis();
		}

		/// <summary>
		/// Move camera relative to a Vector3.
		/// </summary>
		/// <param name="moveVec">Vector3 with values to move camera.</param>
		public void Move(Vector3 moveVec)
		{
			Position += moveVec;
			UpdateAntiAxis();
		}

		/// <summary>
		/// Move the camera to an absolute position.
		/// </summary>
		/// <param name="newPos">Vector3 with new absolute camera position.</param>
		public void MoveAbsolute(Vector3 newPos)
		{
			Position = newPos;
			UpdateAntiAxis();
		}
		#endregion

		#region Rotation
		/// <summary>
		/// Rotate camera using relative X/Y values.
		/// </summary>
		/// <param name="rotX">Amount to rotate camera on X axis.</param>
		/// <param name="rotY">Amount to rotate camera on Y axis.</param>
		public void Rotate(float rotX, float rotY)
		{
			Rotation.X += rotX;
			Rotation.Y += rotY;
		}

		/// <summary>
		/// Rotate camera relative to a Vector2.
		/// </summary>
		/// <param name="rotVec">Vector2 with values to rotate camera.</param>
		public void Rotate(Vector2 rotVec)
		{
			Rotation += rotVec;
		}

		/// <summary>
		/// Set camera rotation to an absolute value.
		/// </summary>
		/// <param name="newRot">Vector2 with new absolute camera rotation.</param>
		public void RotateAbsolute(Vector2 newRot)
		{
			Rotation = newRot;
		}
		#endregion
	}
}
