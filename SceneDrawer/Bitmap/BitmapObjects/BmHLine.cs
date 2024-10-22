using SceneDrawer.SceneObjects;

namespace SceneDrawer.Bitmap.BitmapObjects {
	public class BmHLine : HLine {
		public BmHLine(int x1, int x2, int y) : base(x1, x2, y) {
		}

		public override void Draw(IDrawContext dc) {
			if (dc is not BmpSceneBitmap bmContext) {
				throw new ArgumentException($"{nameof(BmHLine)} tried to draw itself on {dc.GetType()} while expecting {typeof(BmpSceneBitmap)}");
			}

			for (int i = MinX; i <= MaxX; i++) {
				bmContext.SetUserScenePixel(i, Y);
			}
		}
	}
}
