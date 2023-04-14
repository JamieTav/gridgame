using System.IO;

class Sprite {
    public ColorCharacter[,] texture;
    public Sprite(string file){
        var w = 0;
        var h = 0;
        var lines = File.ReadLines($"./sprites/{file}"); 

        // ConsoleColor.Parse()
        var fg = Enum.Parse<ConsoleColor>(lines.ElementAt(0));
        var bg = Enum.Parse<ConsoleColor>(lines.ElementAt(1));
        // var fgString =  lines.ElementAt(0);
        // var fg = ConsoleColor.White;
        // if(fgString == "Red") {
        //     fg = ConsoleColor.Red;
        // } else if(fgString == "DarkRed") {
        //     fg = ConsoleColor.DarkRed;
        // }

        // find the size of the texture
        foreach (string line in lines.Skip(2)){
            var tw = 0;
            h = h+1;
            // line
            foreach (var character in line){
                tw = tw+1;
            }
            if (tw > w){
                w = tw;
            }
        }

        // create the texture
        texture = new ColorCharacter[h,w];

        // populate the texture with the file information
        // h = 4, w =  10
        // aaaaaaaaaa
        // b         
        // ttt       
        // dd        

        for(var v=0; v < h; v++){
            for(var u = 0; u < w; u++) {
                var l = lines.ElementAt(v+2);
                var c = ' ';
                if (u < l.Length) {
                    c = l[u];
                }

                var cc = new ColorCharacter(c, fg, bg);
                texture[v, u] = cc;
            }
        }
    }

    public Sprite(ColorCharacter[,] texture){
        this.texture = texture;
    }
}