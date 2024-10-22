using SceneDrawer;
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
			foreach (SceneObject dobj in scene.DrawObjects) {
				switch (dobj) {
					case Point point:
						Console.WriteLine($"Point: {point.X}, {point.Y}");
						break;
					case Rect rect:
						Console.WriteLine($"Rect: ({rect.X1}, {rect.Y1}), ({rect.X2}, {rect.Y2})");
						break;
					case Line line:
						Console.WriteLine($"Line: ({line.X1}, {line.Y1}), ({line.X2}, {line.Y2})");
						break;
					case Polygon poly:
                        Console.WriteLine("Polygon:");
						foreach (System.Drawing.Point point in poly.Points) {
							Console.WriteLine($"\t({point.X}, {point.Y})");
						}
						break;
				}
			}
		}
	}
}