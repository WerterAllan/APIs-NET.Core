using System.Collections.Generic;

namespace WerterStore.Shared.Extensions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> DequeueChunk<T>(this Queue<T> queue, int chunkSize)
        {
            for (int index = 0; index < chunkSize && queue.Count > 0; index++)
                yield return queue.Dequeue();
            
        }
    }
}
