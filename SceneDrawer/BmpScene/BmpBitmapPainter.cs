using SceneDrawer.SceneObjects;

namespace SceneDrawer.BmpScene {
	public class BmpBitmapPainter {
		public BmpSceneBitmap Bitmap { get; }

		public BmpBitmapPainter(BmpSceneBitmap bitmap) {
			Bitmap = bitmap;
		}

		public void PaintScene(Scene scene) {
			foreach (SceneObject paintable in scene.DrawObjects) {
				paintable.Paint(Bitmap);
			}
		}
	}
}
