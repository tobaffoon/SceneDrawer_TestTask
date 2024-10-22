namespace SceneDrawer.SceneObjects {
	public abstract class Polygon : SceneObject {
		public List<(int,int)> Points { get; } = new List<(int, int)>();
	}
}
