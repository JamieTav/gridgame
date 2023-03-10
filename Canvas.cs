class Canvas {
    ColorCharacter[,] matrix = new ColorCharacter[Constants.height,Constants.width];

    public void Clear() {
        for(var w = 0; w < Constants.width; w++) {
            // Console.WriteLine(canvas[n,o]);
            for (var h = 0; h < Constants.height; h++){     
                matrix[h,w] = new ColorCharacter() {
                    c= ' ',
                };
                if (h == Constants.height-2) {
                    matrix[h,w] = new ColorCharacter() {
                        c='='
                    };
                }
                if (w == Constants.width-1 || w == 0) {
                    matrix[h,w] = new ColorCharacter() {
                        c='|'
                    };
                }
                if (h == Constants.height-1 || h == 0) {
                    matrix[h,w] = new ColorCharacter(){
                        c='-'
                    };
                }
            }
        }
    }

    public void Set(GameObject a) {
        matrix[a.position.y, a.position.x] = a.c;
    }

    public void Draw(){
        Console.Clear();
        for(var n = 0; n < matrix.GetLength(0); n++) {
            // Console.canvas[n,o]);
            for (var o = 0; o < matrix.GetLength(1); o++) {     
                Console.BackgroundColor=matrix[n,o].bg;   
                Console.ForegroundColor=matrix[n,o].fg;
                Console.Write(matrix[n,o].c);
            }
            Console.Write("\n");
        }
    }

    public string Read (){
        return Console.ReadKey().Key.ToString().ToLower();
    }
}