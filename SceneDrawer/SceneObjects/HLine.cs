namespace SceneDrawer.SceneObjects {
	public abstract class HLine : SceneObject {
		public int X1 { get; set; }
		public int X2 { get; set; }
		public int Y { get; set; }
		public int MinX => Math.Min(X1, X2);
		public int MaxX => Math.Max(X1, X2);

		public HLine(int x1, int x2, int y) {
			X1 = x1;
			X2 = x2;
			Y = y;
		}
	}
}
