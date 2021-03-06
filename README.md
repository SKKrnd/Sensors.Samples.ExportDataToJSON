# Wstęp

Projekt aplikacji konsolowej .NET Core, obrazujący sposób na pobranie odczytów dla określonego **orderId** i **orderUnitId**.

# Terminologia
**clientId** – id klienta. Publiczny kod będący identyfikatorem klienta. Nadawany przez firmę SKK.

**clientSecret** – prywatny klucz służący do autoryzacji. Nadawany przez firmę SKK.

**accessToken** – ciąg znaków określający zasoby, do których ma dostęp dany użytkownik. Wydawany jest przez serwer autoryzacyjny. 

**orderId** - identyfikator GUID zamówienia. 

**orderUnitId** - identyfikator GUID jednostki logistycznej zamówienia. 

# Autoryzacja
Do autoryzacji wykorzystywany jest protokół [OAuth2](https://oauth.net). Użytkownik autoryzuje się przy użyciu **clientId** oraz **clientSecret** w zewnętrznym serwisie identyfikacyjnym https://identity.skkhive.com. Serwer udostępnia użytkownikowi **accessToken**, który jest potrzebny do uzyskania dostępu do zasobów. 

# Przygotowanie do uruchomienia
**TargetFramework** : [.Net Core 2.2](https://dotnet.microsoft.com/download)

1. Uzupełnić **clientId** i **clientSecret** w pliku Program.cs.
	``` C#
	static async Task Main(string[] args)
			{
				Tokens.ClientId = "<clientId>";
				Tokens.ClientSecret = "<clientSecret>";
	```
2. Pobrać identyfikatory **orderId** i **orderUnitId** zamówienia ze strony [SKK Hive Sensor](https://sensor.skkhive.com/) - w trakcie działania programu będzie wymagane ich wprowadzenie.

Program jest przygotowany do uruchomienia.

# Pomoc
W celu uzyskania pomoc, proszę kontaktować się z działem R&D firmy [SKK S.A](https://www.skk.com.pl/pl/kontakt.html).

![RnD Logo](RnDLogo.jpeg)
