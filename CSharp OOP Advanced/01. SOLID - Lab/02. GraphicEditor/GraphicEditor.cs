using System;

public class GraphicEditor
{
    public void DrawShape(IShape shape)
    {
        Console.WriteLine(shape.Draw());
    }
}