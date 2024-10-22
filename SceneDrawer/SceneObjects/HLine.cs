namespace SceneDrawer.SceneObjects {
	public abstract class HLine : Line {
		private int _y;
		public new int Y1 {
			get {
				return _y;
			}
			set {
				_y = value;
			}
		}
		public new int Y2 {
			get {
				return _y;
			}
			set {
				_y = value;
			}
		}
		public HLine(int x1, int x2, int y) : base(x1, y, x2, y) { }
	}
}
