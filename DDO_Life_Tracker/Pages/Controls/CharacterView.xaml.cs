using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DDO_Life_Tracker.Models;
using System.Text;

namespace DDO_Life_Tracker.Pages.Controls;

public partial class CharacterView : ContentView
{
	public static readonly BindableProperty ThisCharacterProperty = 
		BindableProperty.Create(nameof(ThisCharacter), typeof(Character), typeof(CharacterView), null);
	public static readonly BindableProperty CharacterNameProperty = 
		BindableProperty.Create(nameof(CharacterName), typeof(string), typeof(CharacterView), string.Empty);
	public static readonly BindableProperty NumberOfLivesProperty = 
		BindableProperty.Create(nameof(NumberOfLives), typeof(int), typeof(CharacterView), 0);
	public static readonly BindableProperty CreateDateProperty = 
		BindableProperty.Create(nameof(CreateDate), typeof(DateTime), typeof(CharacterView), null);
	public static readonly BindableProperty TextColorProperty =
		BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(CharacterView), Colors.White);
	public static readonly BindableProperty BorderColorProperty =
		BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CharacterView), Colors.Transparent);
	public static readonly BindableProperty ExpandArrowVisibleProperty = 
		BindableProperty.Create(nameof(ExpandArrowVisible), typeof(bool), typeof(CharacterView), false);
    public static readonly BindableProperty ExpandArrowRotationProperty =
    BindableProperty.Create(nameof(ExpandArrowRotation), typeof(double), typeof(CharacterView), 0.0);

    public Character ThisCharacter 
	{ 
		get => (Character)GetValue(ThisCharacterProperty);
		set => SetValue(ThisCharacterProperty, value);
	}
    public string CharacterName 
	{ 
		get => (string)GetValue(CharacterNameProperty);
		set => SetValue(CharacterNameProperty, value);
	}
	public int NumberOfLives 
	{
		get => (int)GetValue(NumberOfLivesProperty);
		set => SetValue(NumberOfLivesProperty, value);
	}
	public DateTime CreateDate 
	{
		get => (DateTime)GetValue(CreateDateProperty);
		set => SetValue(CreateDateProperty, value);
	}

	public Color TextColor
	{
		get => (Color)GetValue(TextColorProperty);
		set => SetValue(TextColorProperty, value);
	}

	public Color BorderColor
	{
		get => (Color)GetValue(BorderColorProperty);
		set => SetValue(BorderColorProperty, value);
	}

	public bool ExpandArrowVisible
	{
		get => (bool)GetValue(ExpandArrowVisibleProperty);
		set => SetValue (ExpandArrowVisibleProperty, value);
	}

	public double ExpandArrowRotation
	{
		get => (double)GetValue(ExpandArrowRotationProperty);
		set => SetValue(ExpandArrowRotationProperty, value);
	}

    public CharacterView()
	{
		InitializeComponent(); 
	}
}