namespace SceneDrawer.SceneObjects {
	public abstract class VLine : SceneObject {
		public int X { get; set; }
		public int Y1 { get; set; }
		public int Y2 { get; set; }
		public int MinY => Math.Min(Y1, Y2);
		public int MaxY => Math.Max(Y1, Y2);

		public VLine(int y1, int y2, int x) {
			Y1 = y1;
			Y2 = y2;
			X = x;
		}
	}
}
