using System.Threading;
using Cysharp.Threading.Tasks;

namespace AnimeTask
{
    public static partial class TranslateTo
    {
        public static UniTask ToNone<T>(this IAnimator<T> animator, CancellationToken cancellationToken = default, SkipToken skipToken = default, IScheduler scheduler = default) => Anime.Play(animator, new NoneTranslator<T>(), scheduler, cancellationToken, skipToken);
        public static UniTask ToNone<T>(this IAnimatorWithStartValue<T> animator, CancellationToken cancellationToken = default, SkipToken skipToken = default, IScheduler scheduler = default) => Anime.PlayTo(animator, new NoneTranslator<T>(), scheduler, cancellationToken, skipToken);
    }

    public class NoneTranslator<T> : IValueTranslator<T>
    {
        public T Current => default;

        public void Update(T value)
        {
        }
    }
}