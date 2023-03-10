class Canvas {
    ConsoleCanvas consoleCanvas = new ConsoleCanvas(Constants.width, Constants.height);

    public void Clear() {
        consoleCanvas.Clear();
    }

    public void Draw(GameObject go) {
        consoleCanvas.Draw(go.character.c, go.position.x, go.position.y, go.character.fg, go.character.bg);
    }

    public void Render(){
       consoleCanvas.Render();
    }

    public string Read (){
        return Console.ReadKey().Key.ToString().ToLower();
    }
}