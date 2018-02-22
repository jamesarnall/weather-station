# Weather Station

This is just a pet project. It's intended to run on a tablet or similar display
device, as an ambient info source for what the weather is like.

Live app: http://jamesarnall-weather.azurewebsites.net/


## Dependencies

- The DarkSky API
- The DarkSky nuget package
- jQuery
- Bootstrap 3.37
- Roboto font
- The Sunrise Sunset API:
  [https://sunrise-sunset.org/api](https://sunrise-sunset.org/api)

## To Run

```
dotnet run
```

This will start an HTTP server, runnning on ```http://localhost:5000```.


## To Do

- [ ] Get better icons
- [ ] Nice animated fade when the display updates?
- [ ] There's no error handling really going on. Might change this, for
  academic reasons.
- [x] Deployment somewhere, presumably Azure. Git hooks, all of that.
- [ ] Scaffold up some tests
