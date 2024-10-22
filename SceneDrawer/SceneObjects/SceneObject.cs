namespace SceneDrawer.SceneObjects {
	/// <summary>
	/// Class that represent abstract object on an 2D scene.
	/// </summary>
	public abstract class SceneObject {
		public abstract void Draw(IDrawContext dc);
	}
}
