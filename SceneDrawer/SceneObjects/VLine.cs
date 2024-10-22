namespace SceneDrawer.SceneObjects {
	public abstract class VLine : Line {
		private int _x;
		public new int X1 {
			get {
				return _x;
			}
			set {
				_x = value;
			}
		}
		public new int X2 {
			get {
				return _x;
			}
			set {
				_x = value;
			}
		}

		public VLine(int x, int y1, int y2) : base(x, y1, x, y2) { }
	}
}
