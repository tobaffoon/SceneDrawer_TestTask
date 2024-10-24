﻿using SceneDrawer.SceneObjects;

namespace SceneDrawer {
	/// <summary>
	/// Class representing 2D scene with abstract object on it.
	/// </summary>
	public class Scene {
		public int X1 { get; set; }
		public int Y1 { get; set; }
		public int X2 { get; set; }
		public int Y2 { get; set; }

		public Scene(int x1, int y1, int x2, int y2) {
			if(x1 < 0 || y1 < 0 || x2 < 0 || y2 < 0) {
				throw new ArgumentException($"Negative coordintate was passed as Scene boarders. Only non-negative coordinates are allowed.\n Passed coordinates: ({x1}, {y1}, {x2}, {y2})");
			}
			if (x1 == x2 || y1 == y2) {
				throw new ArgumentException($"Scene of zero area was attempted to initialise, only scenes with positive areas are allowed.\n Passed coordinates: ({x1}, {y1}, {x2}, {y2})");
			}
			X1 = x1;
			Y1 = y1;
			X2 = x2;
			Y2 = y2;
		}

		public List<SceneObject> DrawObjects { get; } = new List<SceneObject>();
	}
}
