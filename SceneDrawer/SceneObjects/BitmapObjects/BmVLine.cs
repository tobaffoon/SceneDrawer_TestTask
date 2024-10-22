using SceneDrawer.BmpScene;

namespace SceneDrawer.SceneObjects.BitmapObjects {
	public class BmVLine : VLine {
		public BmVLine(int x, int y1, int y2) : base(x, y1, y2) {
		}

		public override void Paint(IPaintContext dc) {
			if (dc is not BmpSceneBitmap bmContext) {
				throw new ArgumentException($"{nameof(BmVLine)} tried to draw itself on {dc.GetType()} while expecting {typeof(BmpSceneBitmap)}");
			}

			for (int i = Y1; i < Y2; i++) {
				bmContext.SetPixelUInt(X1, i, SceneBmpFileDrawer.BlackPixel);
			}
		}
	}
}
