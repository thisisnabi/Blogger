using Blogger.Application.ApplicationServices;

namespace Blogger.Infrastructure.Services;
public class LinkGenerator : ILinkGenerator
{

    private const string Characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    private static readonly object LockObject = new object();
    private static long _lastTimestamp = -1L;
    private static long _sequence = 0L;
    private const long MaxSequence = 4095; // 12-bit sequence

    // implementing snowflakes algorithm to generate short and unique link
    public string Generate()
    {
        lock (LockObject)
        {
            long timestamp = GetTimestamp();

            if (timestamp == _lastTimestamp)
            {
                _sequence = (_sequence + 1) & MaxSequence;
                if (_sequence == 0)
                {
                    // Wait for the next millisecond if the sequence is full
                    timestamp = WaitForNextMillis(_lastTimestamp);
                }
            }
            else
            {
                _sequence = 0;
            }

            _lastTimestamp = timestamp;

            string uniqueId = Base62Encode(timestamp) + Base62Encode(_sequence);
            return uniqueId;
        }
    }

    private static long GetTimestamp()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    private static long WaitForNextMillis(long lastTimestamp)
    {
        long timestamp;
        do
        {
            timestamp = GetTimestamp();
        } while (timestamp <= lastTimestamp);
        return timestamp;
    }

    private static string Base62Encode(long value)
    {
        var sb = new StringBuilder();
        int baseSize = Characters.Length;
        do
        {
            sb.Insert(0, Characters[(int)(value % baseSize)]);
            value /= baseSize;
        } while (value > 0);
        return sb.ToString();
    }
}
