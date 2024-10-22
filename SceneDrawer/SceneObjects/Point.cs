namespace SceneDrawer.SceneObjects {
	public abstract class Point : SceneObject {
		public int X { get; set; }
		public int Y { get; set; }

		public Point(int x, int y) {
			if (x < 0 || y < 0) {
				throw new ArgumentException($"Negative coordintate was passed as Point coordinates. Only non-negative coordinates are allowed.\n Passed coordinates: ({x}, {y})");
			}
			X = x;
			Y = y;
		}
	}
}
