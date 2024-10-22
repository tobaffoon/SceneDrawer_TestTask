using SceneDrawer;
using SceneDrawer.Bitmap;

namespace SceneDrawerExample {
	public class Program() {
		public static int Main(string[] args) {
			SceneTextFileParser sceneParser = new SceneTextFileParser();

			string inPath;
			if (args.Length == 0) {
				Console.Error.WriteLine("No input filepath is provided");
				return -1;
			}
			if (!File.Exists(args[0])) {
				Console.Error.WriteLine($"Input file at {args[0]} doesn't exists");
				return -1;
			}
			else {
				inPath = args[0];
			}

			string outPath;
			if (args.Length > 1) {
				outPath = args[1];
			}
			else {
				outPath = Path.Combine(Environment.CurrentDirectory, "out.bmp");
			}

			try {
				Scene scene = sceneParser.ParseScene(inPath);
				BmpSceneBitmap bmpSceneBitmap = new BmpSceneBitmap(scene.X1, scene.Y1, scene.X2, scene.Y2);
				BmpBitmapDrawer drawer = new BmpBitmapDrawer();
				drawer.DrawScene(scene, bmpSceneBitmap);

				BitmapToBmpMarshaller.MarshallBitmap(bmpSceneBitmap, outPath);
			}
			catch (Exception ex) {
				Console.Error.WriteLine($"Error while executing example program. Caught exception of type {ex.GetType()}");
				Console.Error.WriteLine("---------------------------------------");
				Console.Error.WriteLine($"Message:\n{ex.Message}");
				Console.Error.WriteLine("---------------------------------------");
				Console.Error.WriteLine($"StackTrace:\n{ex.StackTrace}");
				return -1;
			}

			return 0;
		}
	}
}