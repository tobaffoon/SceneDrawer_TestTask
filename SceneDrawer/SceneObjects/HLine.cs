namespace SceneDrawer.SceneObjects {
	/// <summary>
	/// Class that represent horizontal line on an abstract 2D scene.
	/// </summary>
	public abstract class HLine : SceneObject {
		public int X1 { get; set; }
		public int X2 { get; set; }
		public int Y { get; set; }
		public int MinX => Math.Min(X1, X2);
		public int MaxX => Math.Max(X1, X2);

		public HLine(int x1, int x2, int y) {
			if (x1 < 0 || x2 < 0 || y < 0) {
				throw new ArgumentException($"Negative coordintate was passed as HLine coordinates. Only non-negative coordinates are allowed.\n Passed coordinates: ({x1}, {x2}, {y})");
			}
			X1 = x1;
			X2 = x2;
			Y = y;
		}
	}
}
