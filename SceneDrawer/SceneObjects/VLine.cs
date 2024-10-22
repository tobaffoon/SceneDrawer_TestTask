namespace SceneDrawer.SceneObjects {
	/// <summary>
	/// Class that represent vertical line on an abstract 2D scene.
	/// </summary>
	public abstract class VLine : SceneObject {
		public int X { get; set; }
		public int Y1 { get; set; }
		public int Y2 { get; set; }
		public int MinY => Math.Min(Y1, Y2);
		public int MaxY => Math.Max(Y1, Y2);

		public VLine(int y1, int y2, int x) {
			if (y1 < 0 || y2 < 0 || x < 0) {
				throw new ArgumentException($"Negative coordintate was passed as VLine coordinates. Only non-negative coordinates are allowed.\n Passed coordinates: ({y1}, {y2}, {x})");
			}
			Y1 = y1;
			Y2 = y2;
			X = x;
		}
	}
}
