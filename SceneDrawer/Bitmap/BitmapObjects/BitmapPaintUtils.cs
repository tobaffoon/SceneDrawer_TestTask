namespace SceneDrawer.Bitmap.BitmapObjects {
	public static class BitmapPaintUtils {
		/// <summary>
		/// Using Bresenham’s Line Algorithm to generate pixel coordinates of a line
		/// </summary>
		/// <param name="x1"></param>
		/// <param name="y1"></param>
		/// <param name="x2"></param>
		/// <param name="y2"></param>
		/// <returns></returns>
		public static IEnumerable<(int, int)> GetLinePixelsGenerator(int x1, int y1, int x2, int y2) {
			int w = x2 - x1;
			int h = y2 - y1;
			int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
			if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
			if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
			if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;

			int longest = Math.Abs(w);
			int shortest = Math.Abs(h);
			if (!(longest > shortest)) {
				longest = Math.Abs(h);
				shortest = Math.Abs(w);
				if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
				dx2 = 0;
			}
			int numerator = longest >> 1; //
			for (int i = 0; i <= longest; i++) {
				yield return (x1, y1);

				numerator += shortest;
				if (!(numerator < longest)) {
					numerator -= longest;
					x1 += dx1;
					y1 += dy1;
				}
				else {
					x1 += dx2;
					y1 += dy2;
				}
			}
		}
	}
}
