namespace Algorithms.Sorting
{
    class BubbleSort : ISorter
    {
        public void Sort(int[] array)
        {
            for (var i = 0; i < array.Length - 1; i++)
                for (var j = array.Length - 1; i < j; j--)
                    if (array[j] < array[j - 1])
                    {
                        var t = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = t;
                    }
        }
    }
}
