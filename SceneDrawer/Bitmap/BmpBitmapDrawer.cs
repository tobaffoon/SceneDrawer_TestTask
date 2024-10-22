using SceneDrawer.SceneObjects;

namespace SceneDrawer.Bitmap {
	public class BmpBitmapDrawer : ISceneDrawer {
		public const uint BlackPixel = 0xFF000000;
		public const uint WhitePixel = 0xFFFFFFFF;

		public void DrawScene(Scene scene, IDrawContext context) {
			if (context is not BmpSceneBitmap bm) {
				throw new ArgumentException($"{nameof(BmpBitmapDrawer)} tried to draw {scene} on {context.GetType()} while expecting {typeof(BmpSceneBitmap)}");
			}

			foreach (SceneObject drawable in scene.DrawObjects) {
				drawable.Draw(bm);
			}
		}
	}
}
