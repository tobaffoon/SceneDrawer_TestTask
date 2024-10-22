using SceneDrawer.SceneObjects;

namespace SceneDrawer.BmpScene {
	public class BitmapPainter {
		public BmpSceneBitmap Bitmap { get; }

		public BitmapPainter(BmpSceneBitmap bitmap) {
			Bitmap = bitmap;
		}

		public void FillRect(Rect rect, uint value = SceneBmpFileDrawer.WhitePixel) {
			int minX = Math.Min(rect.X1, rect.X2);
			int maxX = Math.Max(rect.X1, rect.X2);
			int minY = Math.Min(rect.Y1, rect.Y2);
			int maxY = Math.Max(rect.Y1, rect.Y2);

			for (int i = minX; i < maxX; i++) {
				for (int j = minY; j < maxY; j++) {
					Bitmap.pixels[i, j] = value;
				}
			}
		}
	}
}
