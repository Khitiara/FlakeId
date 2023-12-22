using System;

namespace FlakeId;

#if NET8_0_OR_GREATER
public sealed class IdGenerator(TimeProvider timeProvider)
{
    private readonly TimeProvider _timeProvider = timeProvider;

    public Id Create()
    {
        var elapsed = _timeProvider.GetUtcNow() - MonotonicTimer.Epoch;
        long millis = (long)elapsed.TotalMilliseconds;
        Id id = new();
        id.CreateInternalFromMilliseconds(millis);
        return id;
    }
}
#endif
