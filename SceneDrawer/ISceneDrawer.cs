using SceneDrawer.BmpScene;

namespace SceneDrawer {
	public interface ISceneDrawer {
		void DrawScene(Scene scene, IBitmap bm, Stream oStream);
	}
}
