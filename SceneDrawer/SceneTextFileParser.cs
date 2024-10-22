using SceneDrawer.DrawObjects;

namespace SceneDrawer {
	public class SceneTextFileParser : ISceneParser {
		public Scene ParseScene(Stream iStream) {
			if (iStream is not FileStream fs) {
				throw new ArgumentException($"{nameof(SceneTextFileParser)} expected {typeof(FileStream)} but recieved {iStream.GetType()}");
			}

			return ParseScene(fs);
		}

		public Scene ParseScene(string path) {
			return ParseScene(new FileStream(path, FileMode.Open));
		}
		
		public Scene ParseScene(FileStream fs) {
			Scene scene;
			string currentLine;
			using (StreamReader reader = new StreamReader(fs)) {
				currentLine = reader.ReadLine();
				int[] sceneCoords = currentLine.Trim().Split(' ').Select(int.Parse).ToArray();
				scene = new Scene(sceneCoords[0], sceneCoords[1], sceneCoords[2], sceneCoords[3]);

				while ((currentLine = reader.ReadLine()) != null) {
					scene.DrawObjects.Add(ParseDrawObject(currentLine));
				}
			}

			return scene;
		}

		private DrawObject ParseDrawObject(string s) {
			string[] tokens = s.Split(' ');
			switch (tokens[0]) {
				case "point":
					return ParsePoint(tokens[1..]);
				case "rect":
					return ParseRect(tokens[1..]);
				case "hline":
					return ParseHLine(tokens[1..]);
				case "vline":
					return ParseVLine(tokens[1..]);
				case "line":
					return ParseLine(tokens[1..]);
				case "poly":
					return ParsePolygon(tokens[1..]);
				default:
					throw new ArgumentException($"{tokens[0]} is not a valid entry");
			}
		}

		private Point ParsePoint(string[] args) {
			return new Point(int.Parse(args[0]), int.Parse(args[1]));
		}

		private Rect ParseRect(string[] args) {
			return new Rect(int.Parse(args[0]), int.Parse(args[1]), int.Parse(args[2]), int.Parse(args[3]));
		}

		private HLine ParseHLine(string[] args) {
			return new HLine(int.Parse(args[0]), int.Parse(args[1]), int.Parse(args[2]));
		}

		private VLine ParseVLine(string[] args) {
			return new VLine(int.Parse(args[0]), int.Parse(args[1]), int.Parse(args[2]));
		}

		private Line ParseLine(string[] args) {
			return new Line(int.Parse(args[0]), int.Parse(args[1]), int.Parse(args[2]), int.Parse(args[3]));
		}

		private Polygon ParsePolygon(string[] args) {
			Polygon polygon = new Polygon();
			for (int i = 0; i < args.Length; i+=2) {
				polygon.Points.Add(
					new System.Drawing.Point(int.Parse(args[i]), int.Parse(args[i + 1]))
					);
			}
			return polygon;
		}
	}
}
