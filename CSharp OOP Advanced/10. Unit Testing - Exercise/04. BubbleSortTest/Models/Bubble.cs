public class Bubble
{
    public void Sort(int[] numbers)
    {
        bool swapped = true;

        while (swapped)
        {
            swapped = false;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i - 1] > numbers[i])
                {
                    int temp = numbers[i - 1];
                    numbers[i - 1] = numbers[i];
                    numbers[i] = temp;
                    swapped = true;
                }
            }
        }
    }
}
