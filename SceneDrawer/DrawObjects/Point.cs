namespace SceneDrawer.DrawObjects {
	public class Point : DrawObject {
		public int X { get; set; }
		public int Y { get; set; }

		public Point(int x, int y) {
			X = x;
			Y = y;
		}

		public override void Draw() {
			throw new NotImplementedException();
		}
	}
}
