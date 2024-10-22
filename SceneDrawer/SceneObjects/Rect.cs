namespace SceneDrawer.SceneObjects {
	public abstract class Rect : SceneObject {
		public int X1 { get; set; }
		public int Y1 { get; set; }
		public int X2 { get; set; }
		public int Y2 { get; set; }
		public int MinX => Math.Min(X1, X2);
		public int Miny => Math.Min(Y1, Y2);
		public int MaxX => Math.Max(X1, X2);
		public int Maxy => Math.Max(Y1, Y2);

		public Rect(int x1, int y1, int x2, int y2) {
			X1 = x1;
			Y1 = y1;
			X2 = x2;
			Y2 = y2;
		}
	}
}
