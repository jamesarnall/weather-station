const gulp   = require('gulp')
  ,   bs     = require('browser-sync').create()
  ,   concat = require('gulp-concat')
  ,   sass   = require('gulp-sass')
  ,   uglify = require('gulp-uglify')
;

var paths = {
    src  : './app',
    dest : './dist'
};

function html() {
    return gulp.src(paths.src + '/*.html')
             .pipe(gulp.dest(paths.dest));
};

function img() {
    return gulp.src(paths.src + '/img/**/*.*')
             .pipe(gulp.dest(paths.dest + '/img'));
};


function fontsRoboto() {
    return gulp.src('./node_modules/roboto-fontface/fonts/roboto/*.*')
             .pipe(gulp.dest('./WeatherStation/wwwroot/fonts/roboto'));
};


function fontsWeather() {
    return gulp.src('./lib/weather-icons-master/font/*.*')
             .pipe(gulp.dest('./WeatherStation/wwwroot/fonts/weather'));
};

function browserSync() {
    var files = [
       './WeatherStation/wwwroot/css/*.scss'
    ];

    bs.init(files, {

        proxy: "http://localhost:5000/"
    });
};

function js() {
    return gulp.src([
            './node_modules/jquery/dist/jquery.min.js', 
            './node_modules/moment/min/moment.min.js', 
            './WeatherStation/wwwroot/js/api.js', 
            './WeatherStation/wwwroot/js/weatherapp.js'
        ])
        .pipe(concat('scripts.js'))
        .pipe(uglify())
        .pipe(gulp.dest('./WeatherStation/wwwroot/js'));
};


var fonts = gulp.parallel(fontsRoboto, fontsWeather);

var runSass = gulp.series(fonts, function() {
    return gulp.src('./WeatherStation/wwwroot/css/*.scss')
             .pipe(sass())
             .pipe(gulp.dest('./WeatherStation/wwwroot/css'))
             .pipe(bs.stream());
           ;
});

var build = gulp.series(html, img, runSass, js);

var watchSass = gulp.series(runSass, function() {
    gulp.watch("./WeatherStation/wwwroot/css/*.scss", ['sass', bs.reload]);
});

var serve = gulp.series(build, function() {

    browserSync();

    gulp.watch("app/sass/*.scss", gulp.series(runSass));
    gulp.watch([paths.src + "/*.html", paths.src + "/js/**.*/*.js"], gulp.series(build, runSass))
          .on('change', bs.reload);
});

exports.build        = build;
exports.fonts        = fonts;
exports.fontsRoboto  = fontsRoboto;
exports.fontsWeather = fontsWeather;
exports.html         = html;
exports.img          = img;
exports.js           = js;
exports.browserSync  = browserSync;
exports.sass         = sass;
exports.serve        = serve;
exports.watchSass    = watchSass;
exports.default      = build;
