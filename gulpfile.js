const { dest, parallel, series, src, watch }  = require('gulp');
const browsersync = require('browser-sync').create();
const concat      = require('gulp-concat');
const del         = require('del');
const sass        = require('gulp-sass');
const uglify      = require('gulp-uglify');

const files = {
    css : 'WeatherStation/wwwroot/css/',
    js  : 'WeatherStation/wwwroot/js/'
};

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
      .pipe(dest(files.css));
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

exports.css     = series(cleanCss, css);
exports.js      = series(cleanJs, js);
exports.default = series(parallel(cleanCss, cleanJs), parallel(css, js));