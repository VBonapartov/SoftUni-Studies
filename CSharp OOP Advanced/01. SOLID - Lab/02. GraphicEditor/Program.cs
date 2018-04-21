namespace _02._GraphicEditor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IShape rectangle = new Rectangle();

            GraphicEditor myGraphEditor = new GraphicEditor();

            myGraphEditor.DrawShape(rectangle);
        }
    }
}
