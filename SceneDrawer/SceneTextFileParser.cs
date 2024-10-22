using SceneDrawer.Bitmap.BitmapObjects;
using SceneDrawer.SceneObjects;

namespace SceneDrawer {
	/// <summary>
	/// Class to deserialize scene from a text file.
	/// 
	/// Format of these files are:
	/// X1 Y1 X2 Y2
	/// [object_name] [parameters]
	/// [object_name] [parameters]
	/// ...
	/// 
	/// Where X1, Y2, X2, Y2 - coordinates representing borders of the scene,
	/// object_name - name of an object on scene. Currently it can equal to: point, rect, hline, vline, line and poly,
	/// parameters - parameters to pass to object's constructor. Usually they hust represent coordinates.
	/// 
	/// Number of entries "[object_name] [parameters]" is not limited.
	/// </summary>
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
			string? currentLine;
			using (StreamReader reader = new StreamReader(fs)) {
				currentLine = reader.ReadLine();
				if (currentLine == null) {
					throw new ArgumentException($"File {fs.Name} is empty, so parsing of the scene failed");
				}

				int[] sceneCoords = currentLine.Trim().Split(' ').Select(int.Parse).ToArray();
				if (sceneCoords.Length != 4) {
					throw new ArgumentException($"Coords: ({string.Join(", ", sceneCoords)}) were passed as Scene boarders. They have {sceneCoords.Length} coordinates, however 4 are expected");
				}
				scene = new Scene(sceneCoords[0], sceneCoords[1], sceneCoords[2], sceneCoords[3]);

				while ((currentLine = reader.ReadLine()) != null) {
					scene.DrawObjects.Add(ParseDrawObject(currentLine));
				}
			}

			return scene;
		}

		private SceneObject ParseDrawObject(string s) {
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
			if (args.Length != 2) {
				throw new ArgumentException($"Coords: ({string.Join(", ", args)}) were passed as Point parameters. They have {args.Length} coordinates, however 2 are expected");
			}
			
			return new BmPoint(int.Parse(args[0]), int.Parse(args[1]));
		}

		private Rect ParseRect(string[] args) {
			if (args.Length != 4) {
				throw new ArgumentException($"Coords: ({string.Join(", ", args)}) were passed as Rect parameters. They have {args.Length} coordinates, however 4 are expected");
			}
			
			return new BmRect(int.Parse(args[0]), int.Parse(args[1]), int.Parse(args[2]), int.Parse(args[3]));
		}

		private HLine ParseHLine(string[] args) {
			if (args.Length != 3) {
				throw new ArgumentException($"Coords: ({string.Join(", ", args)}) were passed as HLine parameters. They have {args.Length} coordinates, however 3 are expected");
			}
			
			return new BmHLine(int.Parse(args[0]), int.Parse(args[1]), int.Parse(args[2]));
		}

		private VLine ParseVLine(string[] args) {
			if (args.Length != 3) {
				throw new ArgumentException($"Coords: ({string.Join(", ", args)}) were passed as VLine parameters. They have {args.Length} coordinates, however 3 are expected");
			}
			
			return new BmVLine(int.Parse(args[0]), int.Parse(args[1]), int.Parse(args[2]));
		}

		private Line ParseLine(string[] args) {
			if (args.Length != 4) {
				throw new ArgumentException($"Coords: ({string.Join(", ", args)}) were passed as Line parameters. They have {args.Length} coordinates, however 4 are expected");
			}
			
			return new BmLine(int.Parse(args[0]), int.Parse(args[1]), int.Parse(args[2]), int.Parse(args[3]));
		}

		private Polygon ParsePolygon(string[] args) {
			if (args.Length % 2 != 0) {
				throw new ArgumentException($"Coords: ({string.Join(", ", args)}) were passed as Polygon parameters. They have uneven ({args.Length}) number of coordinates, however even number is expected as they represent coordinates of polygon's vertices");
			}

			if (args.Length / 2 < 3) {
				throw new ArgumentException($"Coords: ({string.Join(", ", args)}) were passed as Polygon parameters. They represent {args.Length / 2} vertices, however at least 3 are expected");
			}
			
			Polygon polygon = new BmPolygon();
			for (int i = 0; i < args.Length; i+=2) {
				polygon.AddPoint(int.Parse(args[i]), int.Parse(args[i + 1]));
			}
			return polygon;
		}
	}
}
