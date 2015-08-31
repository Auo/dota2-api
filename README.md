# dota2-api
a C# wrapper for the Dota 2 api, it's a portable class library (pcl).

To get this working, you need an [API key from valve](http://steamcommunity.com/dev/apikey).
Then edit the App.config file in the Test project and you can run the tests.

## supported API methods
* GetHeroes
* GetMatchHistory
* GetMatchDetails
* GetleagueListings
* GetLiveLeagueGames
* GetTeamInfoById
* GetTournamentPrizePool
* GetPlayerSummary 



##additional methods
* GetHeroPortrait - Will return a byte[] of an .png or .jpg image depending on choices
* GetItemIcon - Will return a byte[] of an .png image



Import the namespace

````csharp
using Dota2Api
````

Then use the class! 

````csharp
  using (ApiHandler handler = new ApiHandler("API-KEY-HERE"))
  {
    var matchResult = await handler.GetMatchHistory();
  }
````




