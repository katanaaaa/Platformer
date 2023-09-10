using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.UIService
{
    public class UIService : IUIService
    {
        private Transform _deactivatedContainer;

        private readonly UIRoot _uiRoot;
        private readonly Dictionary<Type, UIWindow> _viewStorage = new();
        private readonly Dictionary<Type, GameObject> _initWindows = new();

        private const string UISource = "";

        public UIService(UIRoot uiRoot, Camera camera)
        {
            _uiRoot = uiRoot;
        }

        public T Get<T>() where T : UIWindow
        {
            throw new NotImplementedException();
        }

        public void Hide<T>(Action onEnd = null) where T : UIWindow
        {
            throw new NotImplementedException();
        }

        public void InitWindows(Transform poolDeactiveContainer)
        {
            throw new NotImplementedException();
        }

        public void LoadWindows(string source)
        {
            throw new NotImplementedException();
        }

        public T Show<T>() where T : UIWindow
        {
            throw new NotImplementedException();
        }
    }
}
