
namespace SceneDrawer.BmpFileDrawer {
	public class SceneBmpFileDrawer : ISceneDrawer {
		public readonly byte[] BlackPixel = [0x00, 0x00, 0x00];
		public void DrawScene(Scene scene, Stream oStream) {
			throw new NotImplementedException();
		}
	}
}
