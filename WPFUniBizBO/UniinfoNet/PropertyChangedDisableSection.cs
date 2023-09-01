// Decompiled with JetBrains decompiler
// Type: UniinfoNet.PropertyChangedDisableSection
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;

namespace UniinfoNet
{
  public class PropertyChangedDisableSection : IDisposable
  {
    public WeakReference<BindableBase> Target { get; protected set; }

    public bool EnableStateWhenStart { get; protected set; }

    public PropertyChangedSectionEndMode EndMode { get; protected set; } = PropertyChangedSectionEndMode.RestoreEnable;

    public PropertyChangedDisableSection(BindableBase bindable)
    {
      this.Target = new WeakReference<BindableBase>(bindable);
      this.EnableStateWhenStart = bindable._EnablePropertyChanged;
      bindable._EnablePropertyChanged = false;
    }

    public void Dispose()
    {
      BindableBase target;
      if (!this.Target.TryGetTarget(out target))
        return;
      switch (this.EndMode)
      {
        case PropertyChangedSectionEndMode.AbsoluteEnable:
          target._EnablePropertyChanged = true;
          break;
        case PropertyChangedSectionEndMode.RestoreEnable:
          target._EnablePropertyChanged = this.EnableStateWhenStart;
          break;
      }
    }
  }
}
