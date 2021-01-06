﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AnimeTask.Sample
{
    public class Sample : MonoBehaviour
    {
        private static readonly int ShaderColor = Shader.PropertyToID("_Color");

        public async Task Sample01()
        {
            using (var cubes = new SampleCubes(new Vector3(-5f, 0f, 0f)))
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1));
                await Easing.Create<OutCubic>(new Vector3(5f, 0f, 0f), 2f).ToLocalPosition(cubes[0]);
                await UniTask.Delay(TimeSpan.FromSeconds(1));
            }
        }

        public async Task Sample02()
        {
            using (var cubes = new SampleCubes(new Vector3(0f, 3f, 0f), new Vector3(0f, 3f, 0f), new Vector3(0f, 3f, 0f)))
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1));
                await UniTask.WhenAll(
                    CircleAnimation(cubes[0], 0.0f),
                    CircleAnimation(cubes[1], 0.2f),
                    CircleAnimation(cubes[2], 0.4f)
                );
                await UniTask.Delay(TimeSpan.FromSeconds(1));
            }
        }

        public async Task Sample03()
        {
            using (var cubes = new SampleCubes(new Vector3(-5f, 0f, 0f)))
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1));
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                cancellationTokenSource.Token.Register(() => Debug.Log("Cancel"));
                cancellationTokenSource.CancelAfter(500);

                await Easing.Create<OutCubic>(new Vector3(5f, 0f, 0f), 2f).ToLocalPosition(cubes[0], cancellationTokenSource.Token);
                await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: cancellationTokenSource.Token);
            }
        }

        private async UniTask CircleAnimation(GameObject go, float delay)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(delay));
            await Easing.Create<OutCubic>(0.0f, Mathf.PI * 2.0f, 2f)
                .Convert(x => new Vector3(Mathf.Sin(x), Mathf.Cos(x), 0.0f) * 3.0f)
                .ToLocalPosition(go);
        }

        public async Task Sample04()
        {
            using (var cubes = new SampleCubes(new Vector3(-5f, 0f, 0f)))
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1));
                await UniTask.WhenAll(
                    Moving.Linear(2f, 2f).ToLocalPositionX(cubes[0]),
                    Animator.Delay<Vector3>(1.8f).Concat(Easing.Create<Linear>(Vector3.zero, 0.2f)).DebugLog().ToLocalScale(cubes[0])
                );
                await UniTask.Delay(TimeSpan.FromSeconds(1));
            }
        }

        public async Task Sample05()
        {
            using (var cubes = new SampleCubes(new Vector3(-5f, 0f, 0f)))
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1));
                await UniTask.WhenAll(
                    Easing.Create<OutCubic>(Quaternion.identity, Quaternion.Euler(30f, 0f, 0f), 0.5f).ToGlobalRotation(cubes[0])
                );
                await UniTask.Delay(TimeSpan.FromSeconds(1));
            }
        }

        public async Task Sample06()
        {
            var p = Enumerable.Range(0, 11)
                .Select(x => Enumerable.Range(0, 11).Select(y => new Vector3(x - 5f, y - 5f, 0)))
                .SelectMany(x => x)
                .ToArray();
            using (var cubes = new SampleCubes(p))
            {
                for (var i = 0; i < 100; ++i)
                {
                    await UniTask.WhenAll(
                        cubes.All.Select(x =>
                        {
                            var r = x.GetComponent<MeshRenderer>();
                            var pb = new MaterialPropertyBlock();
                            r.GetPropertyBlock(pb);
                            return Easing.Create<InOutCubic>(pb.GetColor(ShaderColor), UnityEngine.Random.ColorHSV(), 0.5f).ToMaterialPropertyColor(r, "_Color");
                        })
                    );
                }
            }
        }

        public async Task Sample07()
        {
            using (var cubes = new SampleCubes(new Vector3(-5f, 0f, 0f)))
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1));

                var a = Easing.Create<OutCubic>(new Vector3(-5f, 0f, 0f), new Vector3(5f, 0f, 0f), 2f);
                await UniTask.WhenAll(
                    a.ToLocalPosition(cubes[0]),
                    a.Convert(x => Vector3.one * Mathf.Abs(x.x)).ToLocalScale(cubes[0])
                );

                await UniTask.Delay(TimeSpan.FromSeconds(1));
            }
        }

        public async Task Sample08()
        {
            using (var cubes = new SampleCubes(new Vector3(-5f, -1f, 0f), new Vector3(0f, 1f, 0f)))
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1));

                var a = Easing.Create<OutCubic>(new Vector3(5f, 0f, 0f), 2f);
                await UniTask.WhenAll(
                    a.ToLocalPosition(cubes[0]),
                    a.ToLocalPosition(cubes[1])
                );

                await UniTask.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}
