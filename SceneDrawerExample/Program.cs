using SceneDrawer;
using SceneDrawer.BmpScene;

namespace SceneDrawerExample {
	public class Program() {
		public static void Main(string[] args) {
			SceneTextFileParser sceneParser = new SceneTextFileParser();

			string inPath;
			if (args.Length > 0 && File.Exists(args[0])) {
				inPath = args[0];
			}
			else {
				inPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, Properties.Resources.InputFilePath);
			}

			string outPath;
			if (args.Length > 1) {
				outPath = args[1];
			}
			else {
				outPath = Path.Combine(Environment.CurrentDirectory, "out.bmp");
			}

			Scene scene = sceneParser.ParseScene(inPath);
			BmpSceneBitmap bmpSceneBitmap = new BmpSceneBitmap(scene.X1, scene.Y1, scene.X2, scene.Y2);
			BmpBitmapPainter painter = new BmpBitmapPainter(bmpSceneBitmap);
			painter.PaintScene(scene);

			SceneBmpFileDrawer drawer = new SceneBmpFileDrawer();
			drawer.DrawScene(scene, bmpSceneBitmap, outPath);
		}
	}
}