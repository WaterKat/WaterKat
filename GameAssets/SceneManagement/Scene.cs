using System;

namespace WaterKat.GameAssets.SceneManagement
{
    internal abstract partial class Scene
    {
        internal virtual Scene Update()
        {
            return this;
        }
    }
}