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

		public BmpSceneBitmap(int userSceneX1, int userSceneY1, int userSceneX2, int userSceneY2) : base(Math.Max(userSceneX1,userSceneX2), Math.Max(userSceneY1,userSceneY2)) {
			UserSceneX1 = userSceneX1;
			UserSceneY1 = userSceneY1;
			UserSceneX2 = userSceneX2;
			UserSceneY2 = userSceneY2;
		}

		public uint GetUserScenePixel(int x, int y) {
			return GetPixelUInt(x + _userSceneOffsetX, y + _userSceneOffsetY);
		}

		public void SetUserScenePixel(int x, int y, uint value) {
			SetPixelUInt(x + _userSceneOffsetX, y + _userSceneOffsetY, value);
		}
	}
}
