namespace Algorithms
{
    class SelectionSort : ISorter
    {
        public void Sort(int[] array)
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                var smallestIndex = i;
                var smallestValue = array[i];

                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < smallestValue)
                    {
                        smallestIndex = j;
                        smallestValue = array[j];
                    }
                }

                array[smallestIndex] = array[i];
                array[i] = smallestValue;
            }
        }
    }
}
