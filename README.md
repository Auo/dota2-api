# dota2-api

This is a C# wrapper for the Dota 2 api, it's packaged as a net-standard library.

To get this working, you need an [API key from valve](http://steamcommunity.com/dev/apikey).
Then edit the `App.config` file in the Test project and you can run the tests.

## supported API methods
* `GetHeroes`
* `GetMatchHistory`
* `GetMatchDetails`
* `GetLeagueListings`
* `GetLiveLeagueGames`
* `GetTeamInfoById` -currently not working 
* `GetTournamentPrizePool`
* `GetPlayerSummary`


## additional methods
These two methods will call the Steam CDN for images and download them.
* `GetHeroPortrait` - Will return a `byte[]` of a .png or .jpg image depending on choices.
* `GetItemIcon` - Will return a `byte[]` of a .png image


## usage 
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

## work left
Some restructuring and renaming might be good
* Extract HTTP methods from ApiHandler
* Extract QueryBuilder from ApiHandler
* Fix `GetTeamInfoById` or remove it
