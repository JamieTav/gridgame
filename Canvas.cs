class Canvas {
    ConsoleCanvas consoleCanvas = new ConsoleCanvas(Constants.width, Constants.height);

    public void Clear() {
        consoleCanvas.Clear();
    }

    public void Draw(GameObject go) {
        // floor => floor(10.24) = 10    floor(30.3) = 30  floor (28.99999999) = 28

        // (type)object => tries converting the object into the new type
        var x = (int)MathF.Floor(go.position.x); 
        var y = (int)MathF.Floor(go.position.y); 

        if(go.sprite != null && go.sprite.texture !=null){
            for (int v = 0; v < go.sprite.texture.GetLength(0); v++)
            {
                for (int u = 0; u < go.sprite.texture.GetLength(1); u++){
                    var cc = go.sprite.texture[v,u];
                    consoleCanvas.Draw(cc.c, x+u, y+v, cc.fg, cc.bg);
                }
            }
        }
        else if(go.character!=null){
            consoleCanvas.Draw(go.character.c, x, y, go.character.fg, go.character.bg);
        }
    }
    
    public void Render(){
       consoleCanvas.Render();
    }

    public string Read (){
        return Console.ReadKey().Key.ToString().ToLower();
    }
}