namespace SceneDrawer {
	/// <summary>
	/// Interface that displays abstract objects on scene to IDrawContext.
	/// </summary>
	public interface ISceneDrawer {
		/// <summary>
		/// Display abstract objects on scene to DrawContext.
		/// </summary>
		/// <param name="scene">Scene to be displayed</param>
		/// <param name="context">IDrawContext to be displayed on</param>
		void DrawScene(Scene scene, IDrawContext context);
	}
}
