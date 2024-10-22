namespace SceneDrawer.SceneObjects {
	public abstract class Point : SceneObject {
		public int X { get; set; }
		public int Y { get; set; }

		public Point(int x, int y) {
			X = x;
			Y = y;
		}
	}
}
