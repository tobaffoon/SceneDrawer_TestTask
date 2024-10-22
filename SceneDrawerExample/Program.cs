using SceneDrawer;
using SceneDrawer.BmpScene;
using SceneDrawer.SceneObjects;

namespace SceneDrawerExample {
	public class Program() {
		public static void Main(string[] args) {
			SceneTextFileParser sceneParser = new SceneTextFileParser();

			string path;
			if (args.Length > 0 && File.Exists(args[0])) {
				path = args[0];
			}
			else {
				path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, Properties.Resources.InputFilePath);
			}

			Scene scene = sceneParser.ParseScene(path);
			BmpSceneBitmap bmpSceneBitmap = new BmpSceneBitmap(scene.X1, scene.Y1, scene.X2, scene.Y2);
			BitmapPainter painter = new BitmapPainter(bmpSceneBitmap);
			painter.PaintScene(scene);
		}
	}
}