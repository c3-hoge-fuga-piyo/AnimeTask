using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AnimeTask
{
    public static partial class TranslateTo
    {
        public static UniTask ToMaterialPropertyColor(this IAnimator<Color> animator, Renderer renderer, int nameID, CancellationToken cancellationToken = default, SkipToken skipToken = default, IScheduler scheduler = default) => Anime.Play(animator, new MaterialPropertyColorTranslator(renderer, nameID), scheduler, CancellationTokenSource.CreateLinkedTokenSource(renderer.GetCancellationTokenOnDestroy(), cancellationToken).Token, skipToken);
        public static UniTask ToMaterialPropertyColor(this IAnimator<Color> animator, Renderer renderer, string name, CancellationToken cancellationToken = default, SkipToken skipToken = default, IScheduler scheduler = default) => Anime.Play(animator, new MaterialPropertyColorTranslator(renderer, name), scheduler, CancellationTokenSource.CreateLinkedTokenSource(renderer.GetCancellationTokenOnDestroy(), cancellationToken).Token, skipToken);
        public static UniTask ToMaterialPropertyColor(this IAnimatorWithStartValue<Color> animator, Renderer renderer, int nameID, CancellationToken cancellationToken = default, SkipToken skipToken = default, IScheduler scheduler = default) => Anime.PlayTo(animator, new MaterialPropertyColorTranslator(renderer, nameID), scheduler, CancellationTokenSource.CreateLinkedTokenSource(renderer.GetCancellationTokenOnDestroy(), cancellationToken).Token, skipToken);
        public static UniTask ToMaterialPropertyColor(this IAnimatorWithStartValue<Color> animator, Renderer renderer, string name, CancellationToken cancellationToken = default, SkipToken skipToken = default, IScheduler scheduler = default) => Anime.PlayTo(animator, new MaterialPropertyColorTranslator(renderer, name), scheduler, CancellationTokenSource.CreateLinkedTokenSource(renderer.GetCancellationTokenOnDestroy(), cancellationToken).Token, skipToken);

        public static UniTask ToMaterialPropertyFloat(this IAnimator<float> animator, Renderer renderer, int nameID, CancellationToken cancellationToken = default, SkipToken skipToken = default, IScheduler scheduler = default) => Anime.Play(animator, new MaterialPropertyFloatTranslator(renderer, nameID), scheduler, CancellationTokenSource.CreateLinkedTokenSource(renderer.GetCancellationTokenOnDestroy(), cancellationToken).Token, skipToken);
        public static UniTask ToMaterialPropertyFloat(this IAnimator<float> animator, Renderer renderer, string name, CancellationToken cancellationToken = default, SkipToken skipToken = default, IScheduler scheduler = default) => Anime.Play(animator, new MaterialPropertyFloatTranslator(renderer, name), scheduler, CancellationTokenSource.CreateLinkedTokenSource(renderer.GetCancellationTokenOnDestroy(), cancellationToken).Token, skipToken);
        public static UniTask ToMaterialPropertyFloat(this IAnimatorWithStartValue<float> animator, Renderer renderer, int nameID, CancellationToken cancellationToken = default, SkipToken skipToken = default, IScheduler scheduler = default) => Anime.PlayTo(animator, new MaterialPropertyFloatTranslator(renderer, nameID), scheduler, CancellationTokenSource.CreateLinkedTokenSource(renderer.GetCancellationTokenOnDestroy(), cancellationToken).Token, skipToken);
        public static UniTask ToMaterialPropertyFloat(this IAnimatorWithStartValue<float> animator, Renderer renderer, string name, CancellationToken cancellationToken = default, SkipToken skipToken = default, IScheduler scheduler = default) => Anime.PlayTo(animator, new MaterialPropertyFloatTranslator(renderer, name), scheduler, CancellationTokenSource.CreateLinkedTokenSource(renderer.GetCancellationTokenOnDestroy(), cancellationToken).Token, skipToken);

        public static UniTask ToMaterialPropertyInt(this IAnimator<int> animator, Renderer renderer, int nameID, CancellationToken cancellationToken = default, SkipToken skipToken = default, IScheduler scheduler = default) => Anime.Play(animator, new MaterialPropertyIntTranslator(renderer, nameID), scheduler, CancellationTokenSource.CreateLinkedTokenSource(renderer.GetCancellationTokenOnDestroy(), cancellationToken).Token, skipToken);
        public static UniTask ToMaterialPropertyInt(this IAnimator<int> animator, Renderer renderer, string name, CancellationToken cancellationToken = default, SkipToken skipToken = default, IScheduler scheduler = default) => Anime.Play(animator, new MaterialPropertyIntTranslator(renderer, name), scheduler, CancellationTokenSource.CreateLinkedTokenSource(renderer.GetCancellationTokenOnDestroy(), cancellationToken).Token, skipToken);
        public static UniTask ToMaterialPropertyInt(this IAnimatorWithStartValue<int> animator, Renderer renderer, int nameID, CancellationToken cancellationToken = default, SkipToken skipToken = default, IScheduler scheduler = default) => Anime.PlayTo(animator, new MaterialPropertyIntTranslator(renderer, nameID), scheduler, CancellationTokenSource.CreateLinkedTokenSource(renderer.GetCancellationTokenOnDestroy(), cancellationToken).Token, skipToken);
        public static UniTask ToMaterialPropertyInt(this IAnimatorWithStartValue<int> animator, Renderer renderer, string name, CancellationToken cancellationToken = default, SkipToken skipToken = default, IScheduler scheduler = default) => Anime.PlayTo(animator, new MaterialPropertyIntTranslator(renderer, name), scheduler, CancellationTokenSource.CreateLinkedTokenSource(renderer.GetCancellationTokenOnDestroy(), cancellationToken).Token, skipToken);
    }

    public class MaterialPropertyColorTranslator : IValueTranslator<Color>
    {
        private readonly Renderer renderer;
        private readonly int nameID;
        private readonly MaterialPropertyBlock materialPropertyBlock;

        public Color Current => materialPropertyBlock.GetColor(nameID);

        public MaterialPropertyColorTranslator(Renderer renderer, int nameID)
        {
            this.renderer = renderer;
            this.nameID = nameID;
            materialPropertyBlock = new MaterialPropertyBlock();
            renderer.GetPropertyBlock(materialPropertyBlock);
        }

        public MaterialPropertyColorTranslator(Renderer renderer, string name)
        {
            this.renderer = renderer;
            nameID = Shader.PropertyToID(name);
            materialPropertyBlock = new MaterialPropertyBlock();
            renderer.GetPropertyBlock(materialPropertyBlock);
        }

        public void Update(Color value)
        {
            materialPropertyBlock.SetColor(nameID, value);
            renderer.SetPropertyBlock(materialPropertyBlock);
        }
    }

    public class MaterialPropertyFloatTranslator : IValueTranslator<float>
    {
        private readonly Renderer renderer;
        private readonly int nameID;
        private readonly MaterialPropertyBlock materialPropertyBlock;

        public float Current => materialPropertyBlock.GetFloat(nameID);

        public MaterialPropertyFloatTranslator(Renderer renderer, int nameID)
        {
            this.renderer = renderer;
            this.nameID = nameID;
            materialPropertyBlock = new MaterialPropertyBlock();
            renderer.GetPropertyBlock(materialPropertyBlock);
        }

        public MaterialPropertyFloatTranslator(Renderer renderer, string name)
        {
            this.renderer = renderer;
            nameID = Shader.PropertyToID(name);
            materialPropertyBlock = new MaterialPropertyBlock();
            renderer.GetPropertyBlock(materialPropertyBlock);
        }

        public void Update(float value)
        {
            materialPropertyBlock.SetFloat(nameID, value);
            renderer.SetPropertyBlock(materialPropertyBlock);
        }
    }

    public class MaterialPropertyIntTranslator : IValueTranslator<int>
    {
        private readonly Renderer renderer;
        private readonly int nameID;
        private readonly MaterialPropertyBlock materialPropertyBlock;

        public int Current => materialPropertyBlock.GetInt(nameID);

        public MaterialPropertyIntTranslator(Renderer renderer, int nameID)
        {
            this.renderer = renderer;
            this.nameID = nameID;
            materialPropertyBlock = new MaterialPropertyBlock();
            renderer.GetPropertyBlock(materialPropertyBlock);
        }

        public MaterialPropertyIntTranslator(Renderer renderer, string name)
        {
            this.renderer = renderer;
            nameID = Shader.PropertyToID(name);
            materialPropertyBlock = new MaterialPropertyBlock();
            renderer.GetPropertyBlock(materialPropertyBlock);
        }

        public void Update(int value)
        {
            materialPropertyBlock.SetInt(nameID, value);
            renderer.SetPropertyBlock(materialPropertyBlock);
        }
    }
}