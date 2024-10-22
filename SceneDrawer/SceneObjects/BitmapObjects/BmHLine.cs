using SceneDrawer.BmpScene;

namespace SceneDrawer.SceneObjects.BitmapObjects {
	public class BmHLine : HLine {
		public BmHLine(int x1, int x2, int y) : base(x1, x2, y) {
		}

		public override void Paint(IPaintContext dc) {
			if (dc is not BmpSceneBitmap bmContext) {
				throw new ArgumentException($"{nameof(BmHLine)} tried to draw itself on {dc.GetType()} while expecting {typeof(BmpSceneBitmap)}");
			}

			for (int i = X1; i < X2; i++) {
				bmContext.SetPixelUInt(i, Y1, SceneBmpFileDrawer.BlackPixel);
			}
		}
	}
}
