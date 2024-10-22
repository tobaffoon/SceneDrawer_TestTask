namespace SceneDrawer.SceneObjects {
	public abstract class Polygon : SceneObject {
		public List<System.Drawing.Point> Points { get; } = new List<System.Drawing.Point>();
	}
}
