namespace SceneDrawer.SceneObjects {
	public abstract class Polygon : SceneObject {
		protected List<(int,int)> _points = new List<(int, int)>();

		public void AddPoint(int x, int y) {
			if (x < 0 || y < 0) {
				throw new ArgumentException($"Negative coordintate was passed as Polygon vertex coordinates. Only non-negative coordinates are allowed.\n Passed coordinates: ({x}, {y})");
			}
			_points.Add((x, y));
		}

		public IEnumerable<(int, int)> GetPoints() {
			return _points;
		}
	}
}
