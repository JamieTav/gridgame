class ColorCharacter {
    public char c;
    public ConsoleColor bg = ConsoleColor.Black;
    public ConsoleColor fg = ConsoleColor.White;

    public ColorCharacter(){
        c = ' ';
    }

    public ColorCharacter(char c, ConsoleColor fg, ConsoleColor bg){
        this.c = c;
        this.bg = bg;
        this.fg = fg;
    }

    public ColorCharacter(char c, ConsoleColor fg){
        this.c = c;
        this.fg = fg;
    }

    public ColorCharacter(char c)
    {
        this.c = c;
    }
}

//setting the value sets a default