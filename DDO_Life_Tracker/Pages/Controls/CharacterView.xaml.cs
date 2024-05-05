using CommunityToolkit.Mvvm.ComponentModel;
using DDO_Life_Tracker.Models;

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
    public CharacterView()
	{
		InitializeComponent(); 
	}
}