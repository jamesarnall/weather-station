# Weather Station

This is just a pet project. It's intended to run on a tablet or similar display
device, as an ambient info source for what the weather is like.

Live app: http://jamesarnall-weather.azurewebsites.net/


## Dependencies

- The DarkSky API
- jQuery
- Bootstrap 4.0.0
- Roboto font
- Weather Icons, from Erik Flowers:   
  [http://erikflowers.github.io/weather-icons/](http://erikflowers.github.io/weather-icons/)

## To Run

From root:
```
dotnet run
```

This will start an HTTP server, runnning on ```http://localhost:5000```.

## Preprocess view assets

From root:
```
gulp build
```

## To Do

- [x] Get better icons
- [x] Nice animated fade when the display updates?
- [ ] There's no error handling really going on. Might change this, for
  academic reasons.
- [x] Deployment somewhere, presumably Azure. Git hooks, all of that.
- [ ] Scaffold up some tests

## Someday?
- [ ] Allow ZIP lookup, so anyone can use this; after looking up ZIP, it cookies their prefs

