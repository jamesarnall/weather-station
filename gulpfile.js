var { gulp, src, dest, watch, series, parallel } = require('gulp')
,   { clean, restore, build, test, pack, publish, run } = require('gulp-dotnet-cli')
,   browserSync = require('browser-sync')
,   concat      = require('gulp-concat')
,   sass        = require('gulp-sass')
,   uglify      = require('gulp-uglify')
;

var paths = {
    src  : './app',
    dest : './dist'
};

var fontsRoboto = function(done) {
    return src('./node_modules/roboto-fontface/fonts/roboto/*.*')
             .pipe(dest('./WeatherStation/wwwroot/fonts/roboto'));
}

var fontsWeather = function(done) {
    return src('./lib/weather-icons-master/font/*.*')
             .pipe(dest('./WeatherStation/wwwroot/fonts/weather'));
}

var buildSass = function(done) {
    return src('./WeatherStation/wwwroot/css/*.scss')
             .pipe(sass())
             .pipe(dest('./WeatherStation/wwwroot/css'))
             .pipe(browserSync.stream());
           ;
}

var bSync = function(done) {
    var files = [
       './WeatherStation/wwwroot/css/*.scss'
    ];

    browserSync.init(files, {
        proxy: "http://localhost:5000/"
    });
}

var buildDotnet = function(done) {
    return src('*.sln', {read: false})
        .pipe(build());
}


var runDotnet = function(done) {
    return src('WeatherStation/WeatherStation.csproj', {read: false})
            .pipe(run());
}

/*
 TODO
 - IIS/.NET server
   - Live reloading & CSS injection
 - JS
   - JSlint
   - Uglify
 - Image compression
 - Base64 images in styles
 - Image optim
 */


// //browsersync
// gulp.task('browserSync', function () {
//     var files = [
//        './WeatherStation/wwwroot/css/*.scss'
//     ];

//     browserSync.init(files, {

//         proxy: "http://localhost:5000/"
//     });
// });

// gulp.task('js', function() {
//     return gulp.src([
//             './node_modules/jquery/dist/jquery.min.js', 
//             './node_modules/moment/min/moment.min.js', 
//             './WeatherStation/wwwroot/js/api.js', 
//             './WeatherStation/wwwroot/js/weatherapp.js'
//         ])
//         .pipe(concat('scripts.js'))
//         .pipe(uglify())
//         .pipe(gulp.dest('./WeatherStation/wwwroot/js'));
// });

// gulp.task('build', ['html','img','sass', 'js'], function() {



// });

exports.default = parallel(fontsRoboto, fontsWeather, buildSass);
exports.build   = series(buildDotnet);
exports.run     = series(runDotnet);