const { dest, parallel, series, src, watch }  = require('gulp');
const browsersync = require('browser-sync').create();
const concat      = require('gulp-concat');
const del         = require('del');
const sass        = require('gulp-sass');
const uglify      = require('gulp-uglify');
const { clean, restore, build, test, pack, publish, run } = require('gulp-dotnet-cli');

const files = {
    css : 'WeatherStation/wwwroot/css/',
    js  : 'WeatherStation/wwwroot/js/'
};

function buildDotnet(done) {
    return src('*.sln', {read: false})
        .pipe(build());
}

function cleanCss(done) {
    del(files.css + 'styles.css');
    done();
}

function cleanJs(done) {
    del(files.js + 'scripts.js');
    done();
}

function css() {
    return src(files.css + 'styles.scss')
      .pipe(sass())
      .pipe(dest(files.css))
      .pipe(browsersync.stream());
}

function js() {
    return src([
                    './node_modules/jquery/dist/jquery.min.js', 
                    './node_modules/moment/min/moment.min.js', 
                    files.js + 'api.js', 
                    files.js + 'weatherapp.js'
                ])
        .pipe(concat('scripts.js'))
        .pipe(uglify())
        .pipe(dest(files.js));
}

function runDotnet(done) {
    src('WeatherStation/WeatherStation.csproj', {read: false})
        .pipe(run());
    done();
}

function serve(done) {
    browsersync.init({
        proxy: "localhost:5000",
        files: ['WeatherStation/wwwroot/css/*.css']
    });

    watch([files.css + '*.scss'], css);
    done();
}


exports.css         = series(cleanCss, css);
exports.js          = series(cleanJs, js);
exports.buildDotnet = series(buildDotnet);
exports.runDotnet   = series(buildDotnet, runDotnet);
exports.serve       = series(runDotnet, serve);
exports.default     = series(parallel(cleanCss, cleanJs), parallel(css, js));

/*

TODO:
 - Build CSS
 - Build JS
 - Build & run dotnet
 - Run BrowserSync & watch
 */