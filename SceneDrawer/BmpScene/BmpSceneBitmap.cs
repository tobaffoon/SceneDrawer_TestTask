namespace SceneDrawer.BmpScene {
	public class BmpSceneBitmap : BmpBitmap {
		public int UserSceneX1 { get; set; }
		public int UserSceneY1 { get; set; }
		public int UserSceneX2 { get; set; }
		public int UserSceneY2 { get; set; }
		public int UserSceneWidth => Math.Max(UserSceneX1, UserSceneX2) - Math.Min(UserSceneX1, UserSceneX2) + 1;
		public int UserSceneHeight => Math.Max(UserSceneY1, UserSceneY2) - Math.Min(UserSceneY1, UserSceneY2) + 1;

		private int _userSceneOffsetX => Math.Min(UserSceneX1, UserSceneX2);
		private int _userSceneOffsetY => Math.Min(UserSceneY1, UserSceneY2);

		public BmpSceneBitmap(int x1, int y1, int x2, int y2) : base(Math.Max(x1,x2), Math.Max(y1,y2)) {
			UserSceneX1 = x1;
			UserSceneY1 = y1;
			UserSceneX2 = x2;
			UserSceneY2 = y2;
		}

		public uint GetUserScenePixel(int x, int y) {
			return GetPixelUInt(x + _userSceneOffsetX, y + _userSceneOffsetY);
		}

		public void SetUserScenePixel(int x, int y, uint value) {
			SetPixelUInt(x + _userSceneOffsetX, y + _userSceneOffsetY, value);
		}
	}
}
