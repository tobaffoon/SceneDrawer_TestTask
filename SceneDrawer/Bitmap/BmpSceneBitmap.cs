namespace SceneDrawer.Bitmap {
	public class BmpSceneBitmap : BmpBitmap {
		public int UserSpaceX1 { get; set; }
		public int UserSpaceY1 { get; set; }
		public int UserSpaceX2 { get; set; }
		public int UserSpaceY2 { get; set; }
		public int UserSceneWidth => Math.Max(UserSpaceX1, UserSpaceX2) - Math.Min(UserSpaceX1, UserSpaceX2) + 1;
		public int UserSceneHeight => Math.Max(UserSpaceY1, UserSpaceY2) - Math.Min(UserSpaceY1, UserSpaceY2) + 1;

		private int _userSpaceOffsetX => Math.Min(UserSpaceX1, UserSpaceX2);
		private int _userSpaceOffsetY => Math.Min(UserSpaceY1, UserSpaceY2);

		public BmpSceneBitmap(int userSpaceX1, int userSpaceY1, int userSpaceX2, int userSpaceY2) : base(Math.Max(userSpaceX1,userSpaceX2), Math.Max(userSpaceY1,userSpaceY2)) {
			if (userSpaceX1 < 0 || userSpaceY1 < 0 || userSpaceX2 < 0 || userSpaceY2 < 0) {
				throw new ArgumentException($"Negative coordinate was passed as User Space boarders of Bitmap. Only non-negative coordinates are allowed.\n Passed coordinates: ({userSpaceX1}, {userSpaceY1}, {userSpaceX2}, {userSpaceY2})");
			}
			UserSpaceX1 = userSpaceX1;
			UserSpaceY1 = userSpaceY1;
			UserSpaceX2 = userSpaceX2;
			UserSpaceY2 = userSpaceY2;
		}

		public uint GetUserScenePixel(int x, int y) {
			return GetPixelUInt(x + _userSpaceOffsetX, y + _userSpaceOffsetY);
		}

		public void SetUserScenePixel(int x, int y) {
			SetPixelUInt(x + _userSpaceOffsetX, y + _userSpaceOffsetY);
		}
	}
}
