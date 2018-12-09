﻿namespace Xamarin.Forms
{
	public interface IShellAppearanceElement
	{
		Color EffectiveTabBarBackgroundColor { get; }
		Color EffectiveTabBarDisabledColor { get; }
		Color EffectiveTabBarForegroundColor { get; }
		Color EffectiveTabBarTitleColor { get; }
		Color EffectiveTabBarUnselectedColor { get; }
	}
}