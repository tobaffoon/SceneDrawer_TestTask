﻿namespace SceneDrawer.Bitmap {
	/// <summary>
	/// BmpBitmap that has special space allocated for drawing.
	/// 
	/// This space is alligned to bottom-right of the bitmap.
	/// </summary>
	public class BmpSceneBitmap : BmpBitmap {
		/// <summary>
		/// First of the X coordinates of allocated drawing space.
		/// </summary>
		public int UserSpaceX1 { get; set; }
		/// <summary>
		/// First of the Y coordinates of allocated drawing space.
		/// </summary>
		public int UserSpaceY1 { get; set; }
		/// <summary>
		/// Second of the X coordinates of allocated drawing space.
		/// </summary>
		public int UserSpaceX2 { get; set; }
		/// <summary>
		/// Second of the Y coordinates of allocated drawing space.
		/// </summary>
		public int UserSpaceY2 { get; set; }
		/// <summary>
		/// Width of allocated drawing space.
		/// </summary>
		public int UserSceneWidth => Math.Max(UserSpaceX1, UserSpaceX2) - Math.Min(UserSpaceX1, UserSpaceX2) + 1;
		/// <summary>
		/// Height of allocated drawing space.
		/// </summary>
		public int UserSceneHeight => Math.Max(UserSpaceY1, UserSpaceY2) - Math.Min(UserSpaceY1, UserSpaceY2) + 1;

		private int _userSpaceOffsetX => Math.Min(UserSpaceX1, UserSpaceX2);
		private int _userSpaceOffsetY => Math.Min(UserSpaceY1, UserSpaceY2);

		/// <summary>
		/// Creates a BmpSceneBitmap that will fit the allocated drawing space. 
		/// 
		/// Note that it is possible to reference [userSpaceX1, userSpaceX2], [userSpaceY1, userSpaceY2] pixels (both borders are included).
		/// </summary>
		public BmpSceneBitmap(int userSpaceX1, int userSpaceY1, int userSpaceX2, int userSpaceY2) : base(Math.Max(userSpaceX1,userSpaceX2)+1, Math.Max(userSpaceY1,userSpaceY2)+1) {
			if (userSpaceX1 < 0 || userSpaceY1 < 0 || userSpaceX2 < 0 || userSpaceY2 < 0) {
				throw new ArgumentException($"Negative coordinate was passed as User Space boarders of Bitmap. Only non-negative coordinates are allowed.\n Passed coordinates: ({userSpaceX1}, {userSpaceY1}, {userSpaceX2}, {userSpaceY2})");
			}
			UserSpaceX1 = userSpaceX1;
			UserSpaceY1 = userSpaceY1;
			UserSpaceX2 = userSpaceX2;
			UserSpaceY2 = userSpaceY2;
		}

		/// <summary>
		/// Convenient method for getting bitmap pixel in allocated drawing space. 
		/// </summary>
		public uint GetUserScenePixel(int x, int y) {
			return GetPixelUInt(x + _userSpaceOffsetX, y + _userSpaceOffsetY);
		}

		/// <summary>
		/// Convenient method for setting bitmap pixel in allocated drawing space. 
		/// </summary>
		public void SetUserScenePixel(int x, int y) {
			SetPixelUInt(x + _userSpaceOffsetX, y + _userSpaceOffsetY);
		}
	}
}
