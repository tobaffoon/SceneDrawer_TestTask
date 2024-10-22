namespace SceneDrawer {
	/// <summary>
	/// Interface to deserialize scenes.
	/// </summary>
	public interface ISceneParser {
		/// <summary>
		/// Deserialize scene from stream
		/// </summary>
		Scene ParseScene(Stream iStream);
	}
}
