public class ArrayCreator
{
    public static T[] Create<T>(int length, T item)
    {
        T[] newArray = new T[length];

        for(int i = 0; i < length; i++)
        {
            newArray[i] = item;
        }

        return newArray;
    }
}
