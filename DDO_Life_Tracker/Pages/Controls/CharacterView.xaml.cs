using CommunityToolkit.Mvvm.ComponentModel;
using DDO_Life_Tracker.Models;

namespace DDO_Life_Tracker.Pages.Controls;

public partial class CharacterView : ContentView
{
	public static readonly BindableProperty ThisCharacterProp = 
		BindableProperty.Create(nameof(ThisCharacter), typeof(Character), typeof(CharacterView), null);
	public static readonly BindableProperty CharacterNameProp = 
		BindableProperty.Create(nameof(CharacterName), typeof(string), typeof(CharacterView), string.Empty);
	public static readonly BindableProperty NumberOfLivesProp = 
		BindableProperty.Create(nameof(NumberOfLives), typeof(int), typeof(CharacterView), 0);
	public static readonly BindableProperty CreateDateProp = 
		BindableProperty.Create(nameof(CreateDate), typeof(DateTime), typeof(CharacterView), null);

	public Character ThisCharacter 
	{ 
		get => (Character)GetValue(ThisCharacterProp);
		set => SetValue(ThisCharacterProp, value);
	}
    public string CharacterName 
	{ 
		get => ThisCharacter.Name;
		set => SetValue(CharacterNameProp, value);
	}
	public int NumberOfLives 
	{
		get => ThisCharacter.NumberOfLives;
		set => SetValue(NumberOfLivesProp, value);
	}
	public DateTime CreateDate 
	{
		get => ThisCharacter.CreateDate;
		set => SetValue(CreateDateProp, value);
	}
    public CharacterView()
	{
		InitializeComponent(); 
	}
}