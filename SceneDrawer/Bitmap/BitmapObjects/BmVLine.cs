using SceneDrawer.SceneObjects;

namespace SceneDrawer.Bitmap.BitmapObjects {
	public class BmVLine : VLine {
		public BmVLine(int y1, int y2, int x) : base(y1, y2, x) {
		}

		public override void Draw(IPaintContext dc) {
			if (dc is not BmpSceneBitmap bmContext) {
				throw new ArgumentException($"{nameof(BmVLine)} tried to draw itself on {dc.GetType()} while expecting {typeof(BmpSceneBitmap)}");
			}

			for (int i = MinY; i <= MaxY; i++) {
				bmContext.SetUserScenePixel(X, i);
			}
		}
	}
}
